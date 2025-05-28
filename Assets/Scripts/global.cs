using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class global    // 全域靜態類別，用於存儲遊戲中的共用變數
{
    public static string name;    // 儲存玩家名稱
    public static int count;    // 儲存遊戲中的移動次數
    public static int[] po = new int[9];    // 儲存九宮格中的數字排列（0-8位置）
    public static int correct;    // 儲存正確排列的數量，用於判斷遊戲是否完成

    // 用於結算畫面的變數
    public static int lastMoveCount;      // 儲存上一局遊戲的移動步數
    public static string lastDifficulty;  // 儲存上一局遊戲的難度 ("簡單", "中等", "困難")

    // 移除或保持註解之前為通用化或中等難度添加的變數
    // public static List<int> po_medium = new List<int>();
    // public static int count_medium;
    // public static int correct_medium;
    // public static readonly int TOTAL_TILES_MEDIUM = 12;
    // public static readonly int EMPTY_TILE_VALUE_MEDIUM = 12;
    // public static readonly string IMAGE_PREFIX_MEDIUM = "A";
    // public static readonly string IMAGE_SUFFIX_MEDIUM = ".jpg";
    // public static readonly int NUM_COLS_MEDIUM = 4;
    // public static readonly int NUM_ROWS_MEDIUM = 3;

    // public enum GameDifficultyMode
    // {
    //     None,
    //     Easy,
    //     Medium,
    //     Hard
    // }
    // public static GameDifficultyMode currentMode = GameDifficultyMode.None;
}
