using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public GameObject wp;    // 遊戲視窗物件
    public GameObject txt_count;    // 顯示計數的文字物件
    // public GameObject[] img = new GameObject[9]; // 不再需要此陣列，因為拼圖塊數量是動態的
    // public Game gameController; // 不再需要此引用
    // public GameObject completionPanel; // REMOVED: 由 CompletionManager 處理

    // REMOVED: Start() 方法，因為 completionPanel 的初始隱藏由 CompletionManager 處理
    // void Start()
    // {
    //     // ...
    // }

    public void GameOpen()    // 開始遊戲的方法
    {
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

        // 恢復為僅處理 Easy 模式 (3x3) 的邏輯
        global.correct = 0;
        global.count = 0;
        txt_count.GetComponent<Text>().text = "0";

        // Easy 模式 (3x3, 9塊) 的初始化邏輯 - 使用 Fisher-Yates shuffle
        List<int> numbersToShuffle = new List<int>();
        for (int k = 1; k <= 8; k++) // 數字 1 到 8
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

        // 將打亂後的數字填入 global.po
        for (int k = 0; k < 8; k++) // 填入前8個位置
        {
            global.po[k] = numbersToShuffle[k];
        }
        global.po[8] = 9; // 第9個位置是空格

        Debug.Log("[Btn.cs] GameOpen (Easy): global.po AFTER shuffle: " + string.Join(", ", global.po));

        // 視覺更新將由 Game.cs 實例的 UpdateVisualState() 自動處理。
    }

    public void GameClose()    // 關閉遊戲的方法
    {
        wp.SetActive(false);    // 隱藏遊戲視窗
    }

    public void GameDone()    // 一鍵完成拼圖的方法
    {
        // 恢復為僅處理 Easy 模式 (3x3) 的邏輯
        for (int i = 0; i < 9; i++)
        {
            global.po[i] = i + 1; // po[8] 會是 9 (空格)
        }
        global.correct = 1;
        // UI 更新由 Game.cs 處理
    }

    // REMOVED: Update() 方法
    // void Update()
    // {
    //     // ...
    // }
}