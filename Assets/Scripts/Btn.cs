using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public GameObject wp;    // 遊戲視窗物件
    public GameObject txt_count;    // 顯示計數的文字物件
    //int[] po = new int[9];
    public GameObject[] img = new GameObject[9];    // 存儲九宮格圖片的陣列
    // public Game gameController; // 不再需要此引用

    public void GameOpen()    // 開始遊戲的方法
    {
        wp.SetActive(true);    // 顯示遊戲視窗
        global.count = 0;  // 重置計數器
        txt_count.GetComponent<Text>().text = "0";  // 更新計數器顯示
        global.po[0] = UnityEngine.Random.Range(1, 9);    // 隨機生成第一個數字
        global.po[8] = 9;    // 最後一格設定為9（空白格）
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
        for (int i = 0; i < 8; i++)    // 載入對應的圖片
        {
            string file = global.po[i].ToString();    // 將數字轉換為字串作為檔案名
            img[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(file);    // 載入對應的圖片資源
        }
        img[8].GetComponent<Image>().sprite = null;    // 最後一格設為空白
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
}