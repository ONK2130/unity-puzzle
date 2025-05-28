using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour    // 遊戲主要邏輯控制類別
{
    // public GameObject[] img = new GameObject[10]; // Game.cs 分散掛載後，此陣列不再適用於單一實例控制所有圖片
    // public GameObject txt_count; // 計數器更新建議由更中心化的腳本處理
    public int logicalTilePosition; // 在 Unity Editor 中為每個拼圖塊設定 (1-9)

    private Image _imageComponent;

    void Start()
    {
        _imageComponent = GetComponent<Image>();
        if (_imageComponent == null)
        {
            Debug.LogError($"Game.cs is attached to GameObject '{this.gameObject.name}' which does not have an Image component. Please ensure Game.cs is only attached to GameObjects that represent a puzzle tile and have an Image component.");
        }
        UpdateVisualState(); // 初始更新一次狀態
    }

    void Update()    // 每幀更新，檢查遊戲是否完成並更新顯示
    {
        // 檢查拼圖是否完成的邏輯，由 Btn.cs 的 GameDone 或玩家移動觸發 global.correct 的變化
        // 此處主要負責根據 global 狀態更新單個拼圖塊的視覺

        // 重新計算 correct 狀態，確保與 global.po 同步
        // 這一部分可以考慮是否保留，或者完全依賴外部設定 global.correct
        int currentCorrect = 1;
        for (int i = 0; i < 9; i++)
        {
            if (global.po[i] != i + 1)
            {
                currentCorrect = 0;
                break;
            }
        }
        // 如果 Btn.cs 中的 GameDone 已經設定了 global.correct = 1，這裡的計算可以作為驗證
        // 或者，如果希望 Game.cs 自身也能獨立判斷完成狀態，則保留此邏輯
        // 為了簡化，暫時假設 global.correct 由外部（如Btn.cs或點擊邏輯）正確設定
        if (global.correct != currentCorrect) // 只有在狀態改變時才更新
        {
            global.correct = currentCorrect;
            if (global.correct == 1)
            {
                global.lastMoveCount = global.count; // 記錄本局移動次數
                Debug.Log("[Game.cs] Game Solved! Moves: " + global.count + ". global.lastMoveCount set to: " + global.lastMoveCount);
            }
        }

        UpdateVisualState();
    }

    void UpdateVisualState()
    {
        if (_imageComponent == null || logicalTilePosition < 1 || logicalTilePosition > 9)
        {
            return; // 如果沒有 Image 元件或 logicalTilePosition 無效，則不執行任何操作
        }

        if (global.correct == 1) // 遊戲已完成
        {
            // 所有塊都顯示其正確的數字圖片
            string imageNameCompleted = global.po[logicalTilePosition - 1].ToString();
            _imageComponent.sprite = Resources.Load<Sprite>(imageNameCompleted);
            _imageComponent.enabled = true; // 確保圖片可見
        }
        else // 遊戲進行中
        {
            if (logicalTilePosition - 1 >= 0 && logicalTilePosition - 1 < global.po.Length) // 使用 .Length 因為 global.po 將是 int[]
            {
                int imageNumber = global.po[logicalTilePosition - 1];
                // 假設在 global.po 中，數字 9 代表空格 (這是基於 Btn.cs 中 GameOpen 的初始化邏輯推斷的)
                if (imageNumber == 9) // 如果這個位置是空格
                {
                    _imageComponent.sprite = null;
                    _imageComponent.enabled = false; // 或者禁用 Image 元件使空格不可見
                }
                else
                {
                    string imageNameInProgress = imageNumber.ToString();
                    _imageComponent.sprite = Resources.Load<Sprite>(imageNameInProgress);
                    _imageComponent.enabled = true; // 確保圖片可見
                }
            }
            else
            {
                Debug.LogError($"logicalTilePosition {logicalTilePosition} is out of bounds for global.po array.");
            }
        }
    }

    // 以下是處理九宮格中每個位置點擊的方法 (已重構)

    // 輔助方法：嘗試與指定的相鄰邏輯位置交換（如果相鄰位置是空格）
    private void TrySwapIfAdjacentIsSpace(int adjacentLogicalPos)
    {
        if (global.correct == 1) return; // 遊戲完成後不允許移動

        // 檢查 logicalTilePosition 是否有效
        if (this.logicalTilePosition < 1 || this.logicalTilePosition > 9)
        {
            Debug.LogError($"Invalid logicalTilePosition: {this.logicalTilePosition} on GameObject {this.gameObject.name}");
            return;
        }
        // 檢查 adjacentLogicalPos 是否有效
        if (adjacentLogicalPos < 1 || adjacentLogicalPos > 9)
        {
            // This can happen if a tile is at the edge, and we try to check an "out of bounds" adjacent position.
            // It's not an error, just means no swap is possible in that direction.
            return;
        }

        int currentPoIndex = this.logicalTilePosition - 1; // 當前塊在 global.po 中的索引
        int adjacentPoIndex = adjacentLogicalPos - 1;   // 相鄰塊在 global.po 中的索引

        // 再次檢查索引範圍，雖然 adjacentLogicalPos 已經檢查過，但多一層保護
        if (currentPoIndex < 0 || currentPoIndex >= global.po.Length || adjacentPoIndex < 0 || adjacentPoIndex >= global.po.Length) // 使用 .Length
        {
            Debug.LogError($"Index out of bounds. currentPoIndex: {currentPoIndex}, adjacentPoIndex: {adjacentPoIndex}");
            return;
        }

        // 檢查相鄰位置是否為空格 (假設空格用數字9表示)
        if (global.po[adjacentPoIndex] == 9) // 9 代表空格
        {
            // 交換 global.po 中的值
            int temp = global.po[currentPoIndex];
            global.po[currentPoIndex] = global.po[adjacentPoIndex]; // 當前位置變為空格 (9)
            global.po[adjacentPoIndex] = temp; // 相鄰位置變為原來的數字

            // 更新移動次數
            global.count++;
            // 更新計數器顯示 (臨時方案)
            GameObject txtCountObj = GameObject.Find("txt_count"); // 假設計數器的 GameObject 名字是 "txt_count"
            if (txtCountObj != null)
            {
                Text countText = txtCountObj.GetComponent<Text>();
                if (countText != null)
                {
                    countText.text = global.count.ToString();
                }
                else
                {
                    Debug.LogWarning("'txt_count' GameObject does not have a Text component.");
                }
            }
            else
            {
                Debug.LogWarning("'txt_count' GameObject not found in scene. Count display will not be updated by click.");
            }
            // UpdateVisualState() 會在下一幀自動更新所有塊的視覺
        }
    }

    public void click1()    // 處理 logicalTilePosition 為 1 的塊的點擊
    {
        if (this.logicalTilePosition != 1 && Application.isEditor) { Debug.LogWarning($"click1 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(2); // 嘗試與右邊 (位置2) 交換
        TrySwapIfAdjacentIsSpace(4); // 嘗試與下面 (位置4) 交換
    }

    public void click2()    // 處理 logicalTilePosition 為 2 的塊的點擊
    {
        if (this.logicalTilePosition != 2 && Application.isEditor) { Debug.LogWarning($"click2 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(1); // 左
        TrySwapIfAdjacentIsSpace(3); // 右
        TrySwapIfAdjacentIsSpace(5); // 下
    }

    public void click3()    // 處理 logicalTilePosition 為 3 的塊的點擊
    {
        if (this.logicalTilePosition != 3 && Application.isEditor) { Debug.LogWarning($"click3 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(2); // 左
        TrySwapIfAdjacentIsSpace(6); // 下
    }

    public void click4()    // 處理 logicalTilePosition 為 4 的塊的點擊
    {
        if (this.logicalTilePosition != 4 && Application.isEditor) { Debug.LogWarning($"click4 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(1); // 上
        TrySwapIfAdjacentIsSpace(5); // 右
        TrySwapIfAdjacentIsSpace(7); // 下
    }

    public void click5()    // 處理 logicalTilePosition 為 5 的塊的點擊
    {
        if (this.logicalTilePosition != 5 && Application.isEditor) { Debug.LogWarning($"click5 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(2); // 上
        TrySwapIfAdjacentIsSpace(8); // 下
        TrySwapIfAdjacentIsSpace(4); // 左
        TrySwapIfAdjacentIsSpace(6); // 右
    }

    public void click6()    // 處理 logicalTilePosition 為 6 的塊的點擊
    {
        if (this.logicalTilePosition != 6 && Application.isEditor) { Debug.LogWarning($"click6 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(3); // 上
        TrySwapIfAdjacentIsSpace(9); // 下
        TrySwapIfAdjacentIsSpace(5); // 左
    }

    public void click7()    // 處理 logicalTilePosition 為 7 的塊的點擊
    {
        if (this.logicalTilePosition != 7 && Application.isEditor) { Debug.LogWarning($"click7 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(4); // 上
        TrySwapIfAdjacentIsSpace(8); // 右
    }

    public void click8()    // 處理 logicalTilePosition 為 8 的塊的點擊
    {
        if (this.logicalTilePosition != 8 && Application.isEditor) { Debug.LogWarning($"click8 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(5); // 上
        TrySwapIfAdjacentIsSpace(7); // 左
        TrySwapIfAdjacentIsSpace(9); // 右
    }

    public void click9()    // 處理 logicalTilePosition 為 9 的塊的點擊
    {
        if (this.logicalTilePosition != 9 && Application.isEditor) { Debug.LogWarning($"click9 called on a tile with logicalTilePosition: {this.logicalTilePosition}"); return; }
        TrySwapIfAdjacentIsSpace(6); // 上
        TrySwapIfAdjacentIsSpace(8); // 左
    }

    // public void SetPuzzleToSolvedState() // 此方法的功能已由 Btn.cs 中的 GameDone() 和 Game.cs 中的 UpdateVisualState() 取代
    // {
    // }
}
