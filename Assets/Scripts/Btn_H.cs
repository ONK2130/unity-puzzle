// Assets/Scripts/Btn_H.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_H : MonoBehaviour // 困難難度的按鈕邏輯控制類別
{
    public GameObject wp;    // 遊戲視窗物件 (Puzzl-Hard場景中的父物件)
    public GameObject txt_count;    // 顯示計數的文字物件 (Puzzl-Hard場景中的計數文字)

    public void GameOpen()    // 開始遊戲的方法
    {
        CompletionManager cm = FindObjectOfType<CompletionManager>();
        if (cm != null)
        {
            Debug.Log($"Btn_H.cs GameOpen: Calling HideCompletionPanel. Frame: {Time.frameCount}");
            cm.HideCompletionPanel();
        }
        else
        {
            Debug.LogWarning($"Btn_H.cs GameOpen: CompletionManager not found in scene. Frame: {Time.frameCount}");
        }

        if (wp == null)
        {
            Debug.LogError("Btn_H.cs: 'wp' (Puzzle Window Parent) is not assigned in the Inspector!");
            return;
        }

        wp.SetActive(true);

        // 困難模式 (3x5, 15塊) 的初始化邏輯
        Game_H.correct = 0;
        global.correct = 0; // 同步設定 global.correct 以便 CompletionManager 隱藏面板
        Debug.Log($"Btn_H.cs GameOpen: Game_H.correct set to 0, global.correct set to 0. Frame: {Time.frameCount}");
        Game_H.count = 0;
        global.lastMoveCount = 0; // 重置上一局的移動次數
        global.lastDifficulty = "Hard"; // 設定當前難度為困難

        // 改進的空值檢查
        if (txt_count != null)
        {
            Text textComponent = txt_count.GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.text = "0";
            }
            else
            {
                Debug.LogWarning("Btn_H.cs GameOpen: txt_count does not have a Text component!");
            }
        }
        else
        {
            Debug.LogWarning("Btn_H.cs GameOpen: txt_count is not assigned! Please assign it in the Inspector.");
        }

        // 初始化 Game_H.po 陣列 (3x5, 15塊) - 數字範圍 31-46，46為空格
        List<int> numbersToShuffle = new List<int>();
        for (int k = 31; k <= 45; k++) // 數字 31 到 45
        {
            numbersToShuffle.Add(k);
        }

        // 打亂 numbersToShuffle 列表
        for (int k = 0; k < numbersToShuffle.Count - 1; k++)
        {
            int randomIndex = Random.Range(k, numbersToShuffle.Count);
            int temp = numbersToShuffle[k];
            numbersToShuffle[k] = numbersToShuffle[randomIndex];
            numbersToShuffle[randomIndex] = temp;
        }

        // 將打亂後的數字填入 Game_H.po
        if (Game_H.po == null || Game_H.po.Length != 15)
        {
            Game_H.po = new int[15]; // 確保陣列已初始化且大小正確
        }
        for (int k = 0; k < 14; k++) // 填入前14個位置 (索引0-13)
        {
            Game_H.po[k] = numbersToShuffle[k];
        }
        Game_H.po[14] = 46; // 第15個位置 (索引14) 是空格 (邏輯值為46)

        Debug.Log("[Btn_H.cs] GameOpen (Hard): Game_H.po AFTER shuffle: " + string.Join(", ", Game_H.po));

        // 重新啟用所有 Game_H 腳本實例，以便它們可以更新視覺
        Game_H[] gameTiles = FindObjectsOfType<Game_H>();
        foreach (Game_H tile in gameTiles)
        {
            if (!tile.enabled)
            {
                tile.enabled = true; // 重新啟用腳本
            }
        }
        Debug.Log($"[Btn_H.cs] GameOpen (Hard): Re-enabled {gameTiles.Length} Game_H instances.");
        // 視覺更新將由 Game_H.cs 實例的 UpdateVisualState() 自動處理。
    }

    public void GameClose()    // 關閉遊戲的方法
    {
        if (wp == null) { Debug.LogError("Btn_H.cs: 'wp' (Puzzle Window Parent) is not assigned in the Inspector!"); return; }
        wp.SetActive(false);
    }

    public void GameDone()    // 一鍵完成拼圖的方法
    {
        // 直接操作 Game_H 的靜態變數
        for (int i = 0; i < 15; i++) // 迭代15次
        {
            Game_H.po[i] = i + 31; // po[0]=31, po[1]=32, ..., po[14]=45 (空格的最終位置)
        }
        Game_H.correct = 1;
        global.correct = 1; // 同步設定 global.correct 以觸發 CompletionManager
        global.lastMoveCount = Game_H.count; // 記錄本局移動次數
        // UI 更新將由 Game_H.cs 實例的 UpdateVisualState() 自動處理
        Debug.Log("[Btn_H.cs] GameDone (Hard): Game_H.po set to solved state: " + string.Join(", ", Game_H.po) + "; global.correct set to 1; lastMoveCount set to " + global.lastMoveCount);
    }
}