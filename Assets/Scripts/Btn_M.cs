// Assets/Scripts/Btn_M.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_M : MonoBehaviour // 類名更改
{
    public GameObject wp;    // 遊戲視窗物件 (Puzzl-Medium場景中的父物件)
    public GameObject txt_count;    // 顯示計數的文字物件 (Puzzl-Medium場景中的計數文字)

    public void GameOpen()    // 開始遊戲的方法
    {
        CompletionManager cm = FindObjectOfType<CompletionManager>();
        if (cm != null)
        {
            cm.HideCompletionPanel();
        }
        else
        {
            Debug.LogWarning("Btn_M.cs (GameOpen): CompletionManager not found in scene.");
        }

        if (wp == null) { Debug.LogError("Btn_M.cs: 'wp' (Puzzle Window Parent) is not assigned in the Inspector!"); return; }
        if (txt_count == null) { Debug.LogError("Btn_M.cs: 'txt_count' (Count Text) is not assigned in the Inspector!"); return; }

        wp.SetActive(true);

        // 中等模式 (3x4, 12塊) 的初始化邏輯
        Game_M.correct = 0;
        global.correct = 0; // 同步設定 global.correct 以便 CompletionManager 隱藏面板
        Game_M.count = 0;
        if (txt_count != null && txt_count.GetComponent<Text>() != null)
        {
            txt_count.GetComponent<Text>().text = "0";
        }
        else
        {
            Debug.LogError("Btn_M.cs: txt_count is null or does not have a Text component!");
        }

        // 初始化 Game_M.po 陣列 (3x4, 12塊) - 數字範圍 11-22，22為空格
        List<int> numbersToShuffle = new List<int>();
        for (int k = 11; k <= 21; k++) // 數字 11 到 21
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

        // 將打亂後的數字填入 Game_M.po
        if (Game_M.po == null || Game_M.po.Length != 12)
        {
            Game_M.po = new int[12]; // 確保陣列已初始化且大小正確
        }
        for (int k = 0; k < 11; k++) // 填入前11個位置 (索引0-10)
        {
            Game_M.po[k] = numbersToShuffle[k];
        }
        Game_M.po[11] = 22; // 第12個位置 (索引11) 是空格 (邏輯值為22)

        Debug.Log("[Btn_M.cs] GameOpen (Medium): Game_M.po AFTER shuffle: " + string.Join(", ", Game_M.po));

        // 重新啟用所有 Game_M 腳本實例，以便它們可以更新視覺
        Game_M[] gameTiles = FindObjectsOfType<Game_M>();
        foreach (Game_M tile in gameTiles)
        {
            if (!tile.enabled)
            {
                tile.enabled = true; // 重新啟用腳本
            }
            // 主動調用一次 UpdateVisualState 以確保立即刷新，因為 Start 可能不會對已存在的對象再次觸發
            // 或者依賴它們各自的 Update 方法在下一幀刷新。
            // 為確保即時性，可以考慮直接調用，但要注意這可能導致 UpdateVisualState 被多次調用。
            // 更穩妥的方式是確保 Game_M 的 Start/Update 能處理好重新激活後的刷新。
            // 此處暫時不直接調用 UpdateVisualState，依賴 Game_M 實例的 Start/Update。
        }
        Debug.Log($"[Btn_M.cs] GameOpen (Medium): Re-enabled {gameTiles.Length} Game_M instances.");
        // 視覺更新將由 Game_M.cs 實例的 UpdateVisualState() 自動處理。
    }

    public void GameClose()    // 關閉遊戲的方法
    {
        if (wp == null) { Debug.LogError("Btn_M.cs: 'wp' (Puzzle Window Parent) is not assigned in the Inspector!"); return; }
        wp.SetActive(false);
    }

    public void GameDone()    // 一鍵完成拼圖的方法
    {
        // 直接操作 Game_M 的靜態變數
        for (int i = 0; i < 12; i++) // 迭代12次
        {
            Game_M.po[i] = i + 11; // po[0]=11, po[1]=12, ..., po[11]=22 (空格的最終位置)
        }
        Game_M.correct = 1;
        global.correct = 1; // 同步設定 global.correct 以觸發 CompletionManager
        // UI 更新將由 Game_M.cs 實例的 UpdateVisualState() 自動處理
        Debug.Log("[Btn_M.cs] GameDone (Medium): Game_M.po set to solved state: " + string.Join(", ", Game_M.po) + "; global.correct set to 1");

        // 由於 CompletionManager 會在 Update 中檢測 global.correct，以下尋找並調用 cm 的程式碼可以移除或保持註解
        /*
        CompletionManager cm = FindObjectOfType<CompletionManager>();
        if (cm != null)
        {
            // cm.ShowCompletionPanel(); // 不需要主動調用，CompletionManager 會自行處理
        }
        else
        {
            Debug.LogWarning("Btn_M.cs (GameDone): CompletionManager not found in scene.");
        }
        */
    }
}