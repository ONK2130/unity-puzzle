// Assets/Scripts/Game_M.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_M : MonoBehaviour    // 類名更改
{
    public int logicalTilePosition; // 在 Unity Editor 中為每個拼圖塊設定 (1-12)

    private Image _imageComponent;

    // Game_M 類的靜態變數，由 Btn_M.cs 初始化和管理
    public static int[] po = new int[12]; // 適應12塊
    public static int count = 0;
    public static int correct = 0;


    void Start()
    {
        _imageComponent = GetComponent<Image>();
        if (_imageComponent == null)
        {
            Debug.LogError($"Game_M.cs is attached to GameObject '{this.gameObject.name}' which does not have an Image component.");
        }
        UpdateVisualState();
    }

    void Update()
    {
        if (Game_M.po == null || Game_M.po.Length != 12) return;

        int currentCorrectCheck = 1;
        for (int i = 0; i < 12; i++) // 改為12
        {
            // 期望順序 11, 12, ..., 22 (22代表空格的最終位置)
            if (Game_M.po[i] != i + 11)
            {
                currentCorrectCheck = 0;
                break;
            }
        }

        if (Game_M.correct != currentCorrectCheck)
        {
            Game_M.correct = currentCorrectCheck;
            global.correct = currentCorrectCheck; // 同步設定 global.correct
            if (Game_M.correct == 1)
            {
                Debug.Log($"[Game_M.cs] Game Solved! Final state: " + string.Join(", ", Game_M.po) + "; global.correct set to " + global.correct);
                // CompletionManager 的 Update() 方法會自動檢測 global.correct 並顯示面板
            }
        }

        if (Game_M.correct == 1 && !this.enabled && this.gameObject.activeInHierarchy)
        {
        }
        else
        {
            UpdateVisualState();
        }

        if (Game_M.correct == 1 && this.enabled)
        {
            StartCoroutine(DisableUpdateNextFrame());
        }
    }

    IEnumerator DisableUpdateNextFrame()
    {
        yield return null;
        if (Game_M.correct == 1) this.enabled = false;
    }

    void UpdateVisualState()
    {
        if (_imageComponent == null) return;
        if (logicalTilePosition < 1 || logicalTilePosition > 12) // 改為12
        {
            return;
        }
        if (Game_M.po == null || Game_M.po.Length != 12) return;

        int imageNumber = Game_M.po[logicalTilePosition - 1];
        string imageNameInProgress; // 與 Game.cs 保持一致

        if (Game_M.correct == 1) // 遊戲已完成
        {
            // 圖片名稱直接是數字 11-22
            imageNameInProgress = imageNumber.ToString();
            _imageComponent.sprite = Resources.Load<Sprite>(imageNameInProgress);
            _imageComponent.enabled = true; // 確保圖片可見
        }
        else // 遊戲進行中
        {
            if (imageNumber == 22) // 如果當前塊的邏輯值是22 (代表空格)
            {
                _imageComponent.sprite = null;
                _imageComponent.enabled = false; // 隱藏空格塊
            }
            else // 非空格塊 (邏輯值為11-21)
            {
                imageNameInProgress = imageNumber.ToString();
                _imageComponent.sprite = Resources.Load<Sprite>(imageNameInProgress);
                _imageComponent.enabled = true; // 確保圖片可見
            }
        }
        if (_imageComponent.enabled && _imageComponent.sprite == null && !(Game_M.correct == 0 && imageNumber == 22))
        {
            // Debug.LogWarning($"[Game_M.cs] UpdateVisualState on '{this.gameObject.name}': Failed to load sprite for imageNumber '{imageNumber}'. LogicalPos: {logicalTilePosition}");
        }
    }

    private void TrySwapIfAdjacentIsSpace(int adjacentLogicalPos)
    {
        if (Game_M.correct == 1) return;

        if (this.logicalTilePosition < 1 || this.logicalTilePosition > 12 || // 改為12
            adjacentLogicalPos < 1 || adjacentLogicalPos > 12) // 改為12
        {
            return;
        }

        int currentPoIndex = this.logicalTilePosition - 1;
        int adjacentPoIndex = adjacentLogicalPos - 1;

        if (Game_M.po[adjacentPoIndex] == 22) // 空格的邏輯值為22
        {
            int temp = Game_M.po[currentPoIndex];
            Game_M.po[currentPoIndex] = Game_M.po[adjacentPoIndex];
            Game_M.po[adjacentPoIndex] = temp;

            Game_M.count++;
            GameObject txtCountObj = GameObject.Find("txt_count");
            if (txtCountObj != null)
            {
                Text countText = txtCountObj.GetComponent<Text>();
                if (countText != null) countText.text = Game_M.count.ToString();
            }
        }
    }

    // 點擊方法擴展為12個，命名為 click_mX
    // 3x4 佈局
    // 1  2  3  4
    // 5  6  7  8
    // 9 10 11 12
    public void click_m1() { if (this.logicalTilePosition != 1) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(5); }
    public void click_m2() { if (this.logicalTilePosition != 2) return; TrySwapIfAdjacentIsSpace(1); TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(6); }
    public void click_m3() { if (this.logicalTilePosition != 3) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(4); TrySwapIfAdjacentIsSpace(7); }
    public void click_m4() { if (this.logicalTilePosition != 4) return; TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(8); }
    public void click_m5() { if (this.logicalTilePosition != 5) return; TrySwapIfAdjacentIsSpace(1); TrySwapIfAdjacentIsSpace(6); TrySwapIfAdjacentIsSpace(9); }
    public void click_m6() { if (this.logicalTilePosition != 6) return; TrySwapIfAdjacentIsSpace(2); TrySwapIfAdjacentIsSpace(5); TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(10); }
    public void click_m7() { if (this.logicalTilePosition != 7) return; TrySwapIfAdjacentIsSpace(3); TrySwapIfAdjacentIsSpace(6); TrySwapIfAdjacentIsSpace(8); TrySwapIfAdjacentIsSpace(11); }
    public void click_m8() { if (this.logicalTilePosition != 8) return; TrySwapIfAdjacentIsSpace(4); TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(12); }
    public void click_m9() { if (this.logicalTilePosition != 9) return; TrySwapIfAdjacentIsSpace(5); TrySwapIfAdjacentIsSpace(10); }
    public void click_m10() { if (this.logicalTilePosition != 10) return; TrySwapIfAdjacentIsSpace(6); TrySwapIfAdjacentIsSpace(9); TrySwapIfAdjacentIsSpace(11); }
    public void click_m11() { if (this.logicalTilePosition != 11) return; TrySwapIfAdjacentIsSpace(7); TrySwapIfAdjacentIsSpace(10); TrySwapIfAdjacentIsSpace(12); }
    public void click_m12() { if (this.logicalTilePosition != 12) return; TrySwapIfAdjacentIsSpace(8); TrySwapIfAdjacentIsSpace(11); }
}