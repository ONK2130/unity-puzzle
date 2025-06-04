// Assets/Scripts/Game_H.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_H : MonoBehaviour    // 困難難度的遊戲邏輯控制類別
{
    public int logicalTilePosition; // 在 Unity Editor 中為每個拼圖塊設定 (1-15)

    private Image _imageComponent;

    // Game_H 類的靜態變數，由 Btn_H.cs 初始化和管理
    public static int[] po = new int[15]; // 適應15塊
    public static int count = 0;
    public static int correct = 0;


    void Start()
    {
        _imageComponent = GetComponent<Image>();
        if (_imageComponent == null)
        {
            Debug.LogError($"Game_H.cs is attached to GameObject '{this.gameObject.name}' which does not have an Image component.");
        }
        UpdateVisualState();
    }

    void Update()
    {
        if (Game_H.po == null || Game_H.po.Length != 15) return;

        int currentCorrectCheck = 1;
        for (int i = 0; i < 15; i++) // 改為15
        {
            // 期望順序 31, 32, ..., 46 (46代表空格的最終位置)
            if (Game_H.po[i] != i + 31)
            {
                currentCorrectCheck = 0;
                break;
            }
        }

        if (Game_H.correct != currentCorrectCheck)
        {
            // 只有在狀態改變時才更新
            if (Game_H.correct != currentCorrectCheck || global.correct != currentCorrectCheck)
            {
                Game_H.correct = currentCorrectCheck;
                global.correct = currentCorrectCheck; // 同步設定 global.correct
                if (Game_H.correct == 1)
                {
                    global.lastMoveCount = Game_H.count; // 記錄本局移動次數
                    Debug.Log($"[Game_H.cs] Game Solved! Moves: {Game_H.count}. Final state: " + string.Join(", ", Game_H.po) + "; global.correct set to " + global.correct + "; global.lastMoveCount set to " + global.lastMoveCount);
                    // CompletionManager 的 Update() 方法會自動檢測 global.correct 並顯示面板
                }
            }
        }

        if (Game_H.correct == 1 && !this.enabled && this.gameObject.activeInHierarchy)
        {
        }
        else
        {
            UpdateVisualState();
        }

        if (Game_H.correct == 1 && this.enabled)
        {
            StartCoroutine(DisableUpdateNextFrame());
        }
    }

    IEnumerator DisableUpdateNextFrame()
    {
        yield return null;
        if (Game_H.correct == 1) this.enabled = false;
    }

    void UpdateVisualState()
    {
        if (_imageComponent == null) return;
        if (logicalTilePosition < 1 || logicalTilePosition > 15) // 改為15
        {
            return;
        }
        if (Game_H.po == null || Game_H.po.Length != 15) return;

        int imageNumber = Game_H.po[logicalTilePosition - 1];
        string imageNameInProgress; // 與 Game.cs 保持一致

        if (Game_H.correct == 1) // 遊戲已完成
        {
            // 圖片名稱直接是數字 31-46
            imageNameInProgress = imageNumber.ToString();
            _imageComponent.sprite = Resources.Load<Sprite>(imageNameInProgress);
            _imageComponent.enabled = true; // 確保圖片可見
        }
        else // 遊戲進行中
        {
            if (imageNumber == 46) // 如果當前塊的邏輯值是46 (代表空格)
            {
                _imageComponent.sprite = null;
                _imageComponent.enabled = false; // 隱藏空格塊
            }
            else // 非空格塊 (邏輯值為31-45)
            {
                imageNameInProgress = imageNumber.ToString();
                _imageComponent.sprite = Resources.Load<Sprite>(imageNameInProgress);
                _imageComponent.enabled = true; // 確保圖片可見
            }
        }
        if (_imageComponent.enabled && _imageComponent.sprite == null && !(Game_H.correct == 0 && imageNumber == 46))
        {
            // Debug.LogWarning($"[Game_H.cs] UpdateVisualState on '{this.gameObject.name}': Failed to load sprite for imageNumber '{imageNumber}'. LogicalPos: {logicalTilePosition}");
        }
    }

    private void TrySwapIfAdjacentIsSpace(int adjacentLogicalPos)
    {
        if (Game_H.correct == 1) return;

        if (this.logicalTilePosition < 1 || this.logicalTilePosition > 15 || // 改為15
            adjacentLogicalPos < 1 || adjacentLogicalPos > 15) // 改為15
        {
            return;
        }

        int currentPoIndex = this.logicalTilePosition - 1;
        int adjacentPoIndex = adjacentLogicalPos - 1;

        if (Game_H.po[adjacentPoIndex] == 46) // 空格的邏輯值為46
        {
            int temp = Game_H.po[currentPoIndex];
            Game_H.po[currentPoIndex] = Game_H.po[adjacentPoIndex];
            Game_H.po[adjacentPoIndex] = temp;

            Game_H.count++;
            GameObject txtCountObj = GameObject.Find("txt_count");
            if (txtCountObj != null)
            {
                Text countText = txtCountObj.GetComponent<Text>();
                if (countText != null) countText.text = Game_H.count.ToString();
            }
        }
    }

    // 點擊方法擴展為15個，命名為 click_hX
    // 3x5 佈局
    // 1  2  3  4  5
    // 6  7  8  9  10
    // 11 12 13 14 15
    public void click_h1() { if (this.logicalTilePosition != 1) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(6); }
    public void click_h2() { if (this.logicalTilePosition != 2) return; TrySwapIfAdjacentIsSpace(1); TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(7); }
    public void click_h3() { if (this.logicalTilePosition != 3) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(4); TrySwapIfAdjacentIsSpace(8); }
    public void click_h4() { if (this.logicalTilePosition != 4) return; TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(5); TrySwapIfAdjacentIsSpace(9); }
    public void click_h5() { if (this.logicalTilePosition != 5) return; TrySwapIfAdjacentIsSpace(4); TrySwapIfAdjacentIsSpace(10); }
    public void click_h6() { if (this.logicalTilePosition != 6) return; TrySwapIfAdjacentIsSpace(1); TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(11); }
    public void click_h7() { if (this.logicalTilePosition != 7) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(6); TrySwapIfAdjacentIsSpace(8); TrySwapIfAdjacentIsSpace(12); }
    public void click_h8() { if (this.logicalTilePosition != 8) return; TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(9); TrySwapIfAdjacentIsSpace(13); }
    public void click_h9() { if (this.logicalTilePosition != 9) return; TrySwapIfAdjacentIsSpace(4); TrySwapIfAdjacentIsSpace(8); TrySwapIfAdjacentIsSpace(10); TrySwapIfAdjacentIsSpace(14); }
    public void click_h10() { if (this.logicalTilePosition != 10) return; TrySwapIfAdjacentIsSpace(5); TrySwapIfAdjacentIsSpace(9); TrySwapIfAdjacentIsSpace(15); }
    public void click_h11() { if (this.logicalTilePosition != 11) return; TrySwapIfAdjacentIsSpace(6); TrySwapIfAdjacentIsSpace(12); }
    public void click_h12() { if (this.logicalTilePosition != 12) return; TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(11); TrySwapIfAdjacentIsSpace(13); }
    public void click_h13() { if (this.logicalTilePosition != 13) return; TrySwapIfAdjacentIsSpace(8); TrySwapIfAdjacentIsSpace(12); TrySwapIfAdjacentIsSpace(14); }
    public void click_h14() { if (this.logicalTilePosition != 14) return; TrySwapIfAdjacentIsSpace(9); TrySwapIfAdjacentIsSpace(13); TrySwapIfAdjacentIsSpace(15); }
    public void click_h15() { if (this.logicalTilePosition != 15) return; TrySwapIfAdjacentIsSpace(10); TrySwapIfAdjacentIsSpace(14); }
}