using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement; // 確保引入場景管理命名空間
using UnityEngine.UI; // 引入UI命名空間以使用Image和Text等組件

public class Switch : MonoBehaviour
{
    // 公開變數，用於在 Unity Editor 中連結 InputField (Legacy)
    public InputField nameInputField;

    public void scenes1()
    {
        // 切換到player-input場景
        SceneManager.LoadScene("Player-input");
    }

    // 新方法：儲存玩家姓名並載入選擇難度場景
    public void SaveNameAndLoadDifficultySelect()
    {
        if (nameInputField != null && !string.IsNullOrEmpty(nameInputField.text))
        {
            string playerName = nameInputField.text;
            PlayerPrefs.SetString("PlayerName", playerName); // 使用 "PlayerName" 作為鍵來儲存姓名
            PlayerPrefs.Save(); // 確保 PlayerPrefs 立即寫入磁碟
            Debug.Log("Player name saved: " + playerName);

            // 載入選擇難度的場景
            SceneManager.LoadScene("DifficultySelect");
        }
        else
        {
            Debug.LogWarning("Name InputField is not assigned in the Inspector or the name is empty.");
            // 您可以在此處添加一些UI提示，告知玩家需要輸入姓名
        }
    }

    // --- 方法用於 DifficultySelect 場景中的按鈕 ---

    public void LoadEasyGame()
    {
        // Easy 模式不需要特別的全域設定，其狀態由 Game.cs 和 Btn.cs 內部處理
        PlayerPrefs.SetString("SelectedDifficulty", "Easy");
        PlayerPrefs.Save();
        global.lastDifficulty = "簡單"; // 設定全域難度記錄
        SceneManager.LoadScene("Puzzl-Easy");
    }

    public void LoadMediumGame()
    {
        // 當載入 Puzzl-Medium 場景後，該場景內的 Btn_Medium.GameOpen() 應被調用以初始化 Game_Medium 的狀態
        PlayerPrefs.SetString("SelectedDifficulty", "Medium");
        PlayerPrefs.Save();
        global.lastDifficulty = "中等"; // 設定全域難度記錄
        SceneManager.LoadScene("Puzzl-Medium");
    }

    public void LoadHardGame()
    {
        PlayerPrefs.SetString("SelectedDifficulty", "Hard");
        PlayerPrefs.Save();
        global.lastDifficulty = "困難"; // 設定全域難度記錄
        SceneManager.LoadScene("Puzzl-Hard");
    }

    // 返回玩家輸入場景的方法
    public void GoToPlayerInput()
    {
        SceneManager.LoadScene("Player-input");
    }

    public void GameScoring()
    {
        SceneManager.LoadScene("Scoring");
    }

    public void ExitMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }
}



// 您可以在此處添加一個靜態方法，用於在遊戲的其他地方讀取已儲存的姓名
// 例如：public static string GetSavedPlayerName()
// {
//     return PlayerPrefs.GetString("PlayerName", "Player"); // 如果沒有儲存姓名，則返回預設值 "Player"
// }

