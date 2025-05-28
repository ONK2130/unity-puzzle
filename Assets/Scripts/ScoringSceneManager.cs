using UnityEngine;
using UnityEngine.UI; // 如果使用標準 UI Text
using UnityEngine.SceneManagement;
// using TMPro; // 如果使用 TextMeshPro，取消註解此行並替換 Text 為 TextMeshProUGUI

public class ScoringSceneManager : MonoBehaviour
{
    // 在 Inspector 中指派這些 UI Text 元件
    public Text playerNameText;    // 用於顯示玩家姓名的 Text UI
    public Text moveCountText;     // 用於顯示移動步數的 Text UI
    public Text difficultyText;    // 用於顯示難度的 Text UI

    // 如果使用 TextMeshPro，請將上面的 Text 替換為 TextMeshProUGUI，例如：
    // public TextMeshProUGUI playerNameText;
    // public TextMeshProUGUI moveCountText;
    // public TextMeshProUGUI difficultyText;

    void Start()
    {
        // 讀取並顯示玩家姓名
        if (playerNameText != null)
        {
            playerNameText.text = PlayerPrefs.GetString("PlayerName", "玩家");
        }
        else
        {
            Debug.LogError("ScoringSceneManager: playerNameText is not assigned in the Inspector!");
        }

        // 讀取並顯示移動步數
        if (moveCountText != null)
        {
            moveCountText.text = global.lastMoveCount.ToString();
        }
        else
        {
            Debug.LogError("ScoringSceneManager: moveCountText is not assigned in the Inspector!");
        }

        // 讀取並顯示難度
        if (difficultyText != null)
        {
            difficultyText.text = global.lastDifficulty;
            if (string.IsNullOrEmpty(global.lastDifficulty))
            {
                difficultyText.text = "未知"; // 如果沒有記錄難度，顯示未知
            }
        }
        else
        {
            Debug.LogError("ScoringSceneManager: difficultyText is not assigned in the Inspector!");
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
            // else if (global.lastDifficulty == "困難") // 未來擴展
            // {
            //     SceneManager.LoadScene("Puzzl-Hard");
            // }
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

        Debug.Log($"ScoringSceneManager: ResetPuzzleState - Easy po[0]={global.po[0]}, Medium po[0]={(Game_M.po != null && Game_M.po.Length > 0 ? Game_M.po[0].ToString() : "null")}");
    }
}