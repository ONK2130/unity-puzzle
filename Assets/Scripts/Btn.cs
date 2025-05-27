using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public GameObject wp;    // 遊戲視窗物件
    public GameObject txt_count;    // 顯示計數的文字物件
    //int[] po = new int[9];
    public GameObject[] img = new GameObject[9];    // 存儲九宮格圖片的陣列 (主要用於 GameOpen 中的隨機化邏輯參考)
    // public Game gameController; // 不再需要此引用
    // public GameObject completionPanel; // REMOVED: 由 CompletionManager 處理

    // REMOVED: Start() 方法，因為 completionPanel 的初始隱藏由 CompletionManager 處理
    // void Start()
    // {
    //     // ...
    // }

    public void GameOpen()    // 開始遊戲的方法
    {
        global.correct = 0; // 確保遊戲開始時不是完成狀態

        // 嘗試找到 CompletionManager 並隱藏其面板
        CompletionManager cm = FindObjectOfType<CompletionManager>();
        if (cm != null)
        {
            cm.HideCompletionPanel();
        }
        else
        {
            Debug.LogWarning("Btn.cs (GameOpen): CompletionManager not found in scene. Cannot hide completion panel.");
        }

        wp.SetActive(true);    // 顯示遊戲視窗
        global.count = 0;  // 重置計數器
        txt_count.GetComponent<Text>().text = "0";  // 更新計數器顯示
        global.po[0] = UnityEngine.Random.Range(1, 9);    // 隨機生成第一個數字
        global.po[8] = 9;    // 最後一格設定為9（空白格） (假設9代表空格)
        for (int i = 1; i < 8; i++)    // 生成其餘數字的迴圈
        {
            int repeat;
            do    // 確保生成的數字不重複
            {
                repeat = 0;
                global.po[i] = UnityEngine.Random.Range(1, 9);    // 隨機生成數字
                for (int j = 0; j < i; j++)    // 檢查是否與之前生成的數字重複
                    if (global.po[i] == global.po[j])
                        repeat = 1;
            } while (repeat == 1);
        }
        // 移除了直接設定 img[i].sprite 的程式碼
        // for (int i = 0; i < 8; i++)
        // {
        //     // string file = global.po[i].ToString();
        //     // img[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(file); // 由 Game.cs 的 UpdateVisualState 處理
        // }
        // img[8].GetComponent<Image>().sprite = null; // 由 Game.cs 的 UpdateVisualState 處理

        // 視覺更新將由每個 Game.cs 實例的 UpdateVisualState() 根據 global.po 和 global.correct 的新狀態自動處理。
    }

    public void GameClose()    // 關閉遊戲的方法
    {
        wp.SetActive(false);    // 隱藏遊戲視窗
    }

    public void GameDone()    // 一鍵完成拼圖的方法
    {
        // 直接設定 global.po 為已解決的順序 (1 到 9)
        for (int i = 0; i < 9; i++)
        {
            global.po[i] = i + 1;
        }

        // 設定遊戲為完成狀態
        global.correct = 1;

        // 注意：此處不修改 global.count，也不直接更新UI圖片。
        // UI圖片的更新將依賴每個 Game.cs 實例在其 Update 方法中偵測到 global.po 和 global.correct 的變化。
    }

    // REMOVED: Update() 方法，因為 completionPanel 的顯示邏輯已移至 CompletionManager.cs
    // void Update()
    // {
    //     // ...
    // }
}