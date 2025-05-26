using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class global    // 全域靜態類別，用於存儲遊戲中的共用變數
{
    public static string name;    // 儲存玩家名稱
    public static int count;    // 儲存遊戲中的移動次數
    public static int[] po = new int[9];    // 儲存九宮格中的數字排列（0-8位置）
    public static int correct;    // 儲存正確排列的數量，用於判斷遊戲是否完成


}
