using UnityEngine;

public class CompletionManager : MonoBehaviour
{
    public GameObject completionPanelGameObject; // 在 Inspector 中指派您的完成 Panel

    void Start()
    {
        // 確保開始時 Panel 是隱藏的
        if (completionPanelGameObject != null)
        {
            completionPanelGameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("CompletionManager: completionPanelGameObject is not assigned in the Inspector!");
        }
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
                Debug.Log("CompletionManager: Game is correct (global.correct == 1), showing completion panel.");
                completionPanelGameObject.SetActive(true);
            }
        }
        else // 如果遊戲未完成 (global.correct != 1)
        {
            if (completionPanelGameObject.activeSelf)
            {
                // Debug.Log("CompletionManager: Game is NOT correct, hiding completion panel.");
                // 通常，重新開始遊戲的邏輯 (例如 Btn.cs 中的 GameOpen) 會負責隱藏它。
                // 但如果需要在此處也強制隱藏，可以取消註解下一行。
                // completionPanelGameObject.SetActive(false);
            }
        }

        // 為了追蹤 global.correct 的狀態，可以每隔一段時間輸出一次
        if (Time.frameCount % 120 == 0) // 每隔約2秒檢查一次 (120幀假設遊戲運行在60FPS左右)
        {
            Debug.Log("CompletionManager Update: current global.correct = " + global.correct);
        }
    }

    // 這個方法可以被 Btn.cs 中的 GameOpen() 調用，以確保重置時 Panel 被隱藏
    public void HideCompletionPanel()
    {
        if (completionPanelGameObject != null && completionPanelGameObject.activeSelf)
        {
            Debug.Log("CompletionManager: HideCompletionPanel called, hiding panel.");
            completionPanelGameObject.SetActive(false);
        }
    }
}