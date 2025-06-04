using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using TMPro; // 如果使用 TextMeshPro，取消註解此行並替換 Text 為 TextMeshProUGUI

public class ScoringSceneManager : MonoBehaviour
{
    // 簡單難度的UI元素
    [Header("簡單難度UI")]
    public Text easyDifficultyText;        // 簡單難度的難度文字
    public Text easyPlayerNameText;        // 簡單難度的玩家名稱文字
    public Text easyMoveCountText;         // 簡單難度的移動步數文字

    // 中等難度的UI元素
    [Header("中等難度UI")]
    public Text mediumDifficultyText;      // 中等難度的難度文字
    public Text mediumPlayerNameText;      // 中等難度的玩家名稱文字
    public Text mediumMoveCountText;       // 中等難度的移動步數文字

    // 困難難度的UI元素
    [Header("困難難度UI")]
    public Text hardDifficultyText;        // 困難難度的難度文字
    public Text hardPlayerNameText;        // 困難難度的玩家名稱文字
    public Text hardMoveCountText;         // 困難難度的移動步數文字

    void Start()
    {
        // 更新最近一次遊戲的紀錄
        UpdateLastGameRecord();

        // 顯示各難度的遊戲紀錄
        DisplayEasyRecord();
        DisplayMediumRecord();
        DisplayHardRecord();
    }

    // 根據最近一次遊戲的難度更新相應的紀錄
    private void UpdateLastGameRecord()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "玩家");

        if (!string.IsNullOrEmpty(global.lastDifficulty))
        {
            if (global.lastDifficulty == "簡單")
            {
                global.hasPlayedEasy = true;
                global.easyPlayerName = playerName;
                global.easyMoveCount = global.lastMoveCount;
            }
            else if (global.lastDifficulty == "中等")
            {
                global.hasPlayedMedium = true;
                global.mediumPlayerName = playerName;
                global.mediumMoveCount = global.lastMoveCount;
            }
            else if (global.lastDifficulty == "困難")
            {
                global.hasPlayedHard = true;
                global.hardPlayerName = playerName;
                global.hardMoveCount = global.lastMoveCount;
            }
        }
    }

    // 顯示簡單難度的遊戲紀錄
    private void DisplayEasyRecord()
    {
        if (easyDifficultyText != null)
        {
            easyDifficultyText.gameObject.SetActive(global.hasPlayedEasy);
            if (global.hasPlayedEasy) easyDifficultyText.text = "簡單";
        }

        if (easyPlayerNameText != null)
        {
            easyPlayerNameText.gameObject.SetActive(global.hasPlayedEasy);
            if (global.hasPlayedEasy) easyPlayerNameText.text = global.easyPlayerName;
        }

        if (easyMoveCountText != null)
        {
            easyMoveCountText.gameObject.SetActive(global.hasPlayedEasy);
            if (global.hasPlayedEasy) easyMoveCountText.text = global.easyMoveCount.ToString();
        }
    }

    // 顯示中等難度的遊戲紀錄
    private void DisplayMediumRecord()
    {
        if (mediumDifficultyText != null)
        {
            mediumDifficultyText.gameObject.SetActive(global.hasPlayedMedium);
            if (global.hasPlayedMedium) mediumDifficultyText.text = "中等";
        }

        if (mediumPlayerNameText != null)
        {
            mediumPlayerNameText.gameObject.SetActive(global.hasPlayedMedium);
            if (global.hasPlayedMedium) mediumPlayerNameText.text = global.mediumPlayerName;
        }

        if (mediumMoveCountText != null)
        {
            mediumMoveCountText.gameObject.SetActive(global.hasPlayedMedium);
            if (global.hasPlayedMedium) mediumMoveCountText.text = global.mediumMoveCount.ToString();
        }
    }

    // 顯示困難難度的遊戲紀錄
    private void DisplayHardRecord()
    {
        if (hardDifficultyText != null)
        {
            hardDifficultyText.gameObject.SetActive(global.hasPlayedHard);
            if (global.hasPlayedHard) hardDifficultyText.text = "困難";
        }

        if (hardPlayerNameText != null)
        {
            hardPlayerNameText.gameObject.SetActive(global.hasPlayedHard);
            if (global.hasPlayedHard) hardPlayerNameText.text = global.hardPlayerName;
        }

        if (hardMoveCountText != null)
        {
            hardMoveCountText.gameObject.SetActive(global.hasPlayedHard);
            if (global.hasPlayedHard) hardMoveCountText.text = global.hardMoveCount.ToString();
        }
    }

    // --- 按鈕事件處理方法 ---

    // 「再來一局」或「選擇難度」按鈕的功能
    public void PlayAgainOrSelectDifficulty()
    {
        global.correct = 0; // 重設遊戲完成狀態
        // 重置拼圖狀態，避免返回遊戲場景時被判定為已完成
        ResetPuzzleState();
        Debug.Log($"ScoringSceneManager: PlayAgainOrSelectDifficulty called. global.correct set to {global.correct}. Puzzle state reset. Loading DifficultySelect scene. Frame: {Time.frameCount}");
        // 通常跳轉到難度選擇畫面
        SceneManager.LoadScene("DifficultySelect");
    }

    // 「返回主選單」按鈕的功能
    public void GoToMainMenu()
    {
        global.correct = 0; // 重設遊戲完成狀態
        // 重置拼圖狀態，避免返回遊戲場景時被判定為已完成
        ResetPuzzleState();
        Debug.Log($"ScoringSceneManager: GoToMainMenu called. global.correct set to {global.correct}. Puzzle state reset. Loading Main scene. Frame: {Time.frameCount}");
        // 假設您的主選單場景名為 "MainMenuScene"
        // 如果您的起始場景是 "Player-input"，則可以改為載入該場景
        SceneManager.LoadScene("Main"); // 或者 "MainMenuScene", "Player-input"
    }

    // 如果您有單獨的「再來一局」按鈕，並且希望重玩相同難度
    public void ReplaySameDifficulty()
    {
        global.correct = 0; // 重設遊戲完成狀態
        // 重置拼圖狀態，避免返回遊戲場景時被判定為已完成
        ResetPuzzleState();
        Debug.Log($"ScoringSceneManager: ReplaySameDifficulty called. global.correct set to {global.correct}. Puzzle state reset. Frame: {Time.frameCount}");
        if (!string.IsNullOrEmpty(global.lastDifficulty))
        {
            if (global.lastDifficulty == "簡單")
            {
                SceneManager.LoadScene("Puzzl-Easy");
            }
            else if (global.lastDifficulty == "中等")
            {
                SceneManager.LoadScene("Puzzl-Medium");
            }
            else if (global.lastDifficulty == "困難")
            {
                SceneManager.LoadScene("Puzzl-Hard");
            }
            else
            {
                Debug.LogWarning("ScoringSceneManager: Unknown lastDifficulty to replay: " + global.lastDifficulty + ". Returning to DifficultySelect.");
                SceneManager.LoadScene("DifficultySelect");
            }
        }
        else
        {
            Debug.LogWarning("ScoringSceneManager: lastDifficulty not set. Returning to DifficultySelect.");
            SceneManager.LoadScene("DifficultySelect");
        }
    }

    // 重置拼圖狀態，確保不會被判定為已完成
    private void ResetPuzzleState()
    {
        // 重置 Easy 模式的拼圖狀態
        // 設置一個明顯不是完成狀態的配置
        global.po[0] = 9; // 將空格放在第一個位置
        for (int i = 1; i < 9; i++)
        {
            global.po[i] = i; // 其他按順序排列，但因為空格在錯誤位置，所以不是完成狀態
        }

        // 重置 Medium 模式的拼圖狀態
        if (Game_M.po != null && Game_M.po.Length >= 12)
        {
            Game_M.po[0] = 22; // 將空格放在第一個位置
            for (int i = 1; i < 12; i++)
            {
                Game_M.po[i] = i + 10; // 其他按順序排列
            }
        }

        // 重置 Hard 模式的拼圖狀態
        if (Game_H.po != null && Game_H.po.Length >= 15)
        {
            Game_H.po[0] = 46; // 將空格放在第一個位置
            for (int i = 1; i < 15; i++)
            {
                Game_H.po[i] = i + 30; // 其他按順序排列
            }
        }

        Debug.Log($"ScoringSceneManager: ResetPuzzleState - Easy po[0]={global.po[0]}, Medium po[0]={(Game_M.po != null && Game_M.po.Length > 0 ? Game_M.po[0].ToString() : "null")}, Hard po[0]={(Game_H.po != null && Game_H.po.Length > 0 ? Game_H.po[0].ToString() : "null")}");
    }
}