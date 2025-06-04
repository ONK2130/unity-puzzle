using UnityEngine;

public class CompletionManager : MonoBehaviour
{
    public GameObject completionPanelGameObject; // 在 Inspector 中指派您的完成 Panel

    void Start()
    {
        if (completionPanelGameObject == null)
        {
            Debug.LogError("CompletionManager: completionPanelGameObject is not assigned in the Inspector!");
            return;
        }

        // 檢查是否是從其他場景（如 Scoring）返回的情況
        // 如果 global.correct == 1 且拼圖已經是完成狀態，這可能是剛完成遊戲
        // 但如果是從 Scoring 返回，我們應該隱藏面板
        if (global.correct == 1)
        {
            // 檢查拼圖是否真的處於完成狀態
            bool isPuzzleComplete = CheckIfPuzzleIsComplete();

            if (isPuzzleComplete)
            {
                Debug.Log("CompletionManager Start: Puzzle is complete and global.correct == 1. Showing panel.");
                completionPanelGameObject.SetActive(true);
            }
            else
            {
                Debug.Log("CompletionManager Start: global.correct == 1 but puzzle is not complete. Hiding panel and resetting global.correct.");
                completionPanelGameObject.SetActive(false);
                global.correct = 0; // 重置狀態
            }
        }
        else
        {
            // 確保開始時 Panel 是隱藏的
            completionPanelGameObject.SetActive(false);
        }
    }

    // 檢查拼圖是否真的完成
    private bool CheckIfPuzzleIsComplete()
    {
        // 檢查當前場景來決定使用哪個邏輯
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (currentScene == "Puzzl-Easy")
        {
            // Easy 模式：檢查 global.po
            for (int i = 0; i < 9; i++)
            {
                if (global.po[i] != i + 1)
                {
                    return false;
                }
            }
            return true;
        }
        else if (currentScene == "Puzzl-Medium")
        {
            // Medium 模式：檢查 Game_M.po
            if (Game_M.po == null || Game_M.po.Length != 12)
            {
                return false;
            }

            for (int i = 0; i < 12; i++)
            {
                if (Game_M.po[i] != i + 11)
                {
                    return false;
                }
            }
            return true;
        }
        else if (currentScene == "Puzzl-Hard")
        {
            // Hard 模式：檢查 Game_H.po
            if (Game_H.po == null || Game_H.po.Length != 15)
            {
                return false;
            }

            for (int i = 0; i < 15; i++)
            {
                if (Game_H.po[i] != i + 31)
                {
                    return false;
                }
            }
            return true;
        }

        return false;
    }

    void Update()
    {
        if (completionPanelGameObject == null)
        {
            // 如果沒有指派，則不執行後續邏輯，並在 Start 中已報錯
            return;
        }

        // 檢查遊戲是否完成
        if (global.correct == 1)
        {
            if (!completionPanelGameObject.activeSelf)
            {
                Debug.Log($"CompletionManager Update: global.correct is 1. Panel was inactive. Setting panel active. Frame: {Time.frameCount}");
                completionPanelGameObject.SetActive(true);
            }
        }
        else // 如果遊戲未完成 (global.correct != 1)
        {
            if (completionPanelGameObject.activeSelf)
            {
                Debug.Log($"CompletionManager Update: global.correct is {global.correct}. Panel was active. Setting panel inactive. Frame: {Time.frameCount}");
                completionPanelGameObject.SetActive(false);
            }
        }

        // 為了追蹤 global.correct 的狀態，可以每幀都輸出一次，或者在狀態變化時輸出
        // 移除或保留這個定期日誌，上面的日誌會在狀態改變時輸出
        // if (Time.frameCount % 120 == 0)
        // {
        //     Debug.Log("CompletionManager Update: current global.correct = " + global.correct);
        // }
    }

    // 這個方法可以被 Btn.cs 中的 GameOpen() 調用，以確保重置時 Panel 被隱藏
    public void HideCompletionPanel()
    {
        if (completionPanelGameObject != null) // 即使面板不是activeSelf，也嘗試設定，確保狀態一致
        {
            if (completionPanelGameObject.activeSelf)
            {
                Debug.Log($"CompletionManager: HideCompletionPanel called. Panel was active. Setting panel inactive. Frame: {Time.frameCount}");
                completionPanelGameObject.SetActive(false);
            }
            else
            {
                // 如果 HideCompletionPanel 被調用時面板已經是 inactive，也記錄一下
                // Debug.Log($"CompletionManager: HideCompletionPanel called. Panel was already inactive. Frame: {Time.frameCount}");
                // 確保它確實是 false
                completionPanelGameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("CompletionManager: HideCompletionPanel called, but completionPanelGameObject is null!");
        }
    }

    // GameScoring() 方法已移至 Switch.cs 以統一管理場景跳轉
    // public void GameScoring()
    // {
    //     // Debug.Log("CompletionManager: GameScoring called, loading Scoring scene.");
    //     // UnityEngine.SceneManagement.SceneManager.LoadScene("Scoring");
    // }
}