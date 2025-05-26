# Decision Log (決策日誌)

This file records architectural and implementation decisions using a list format.
(此檔案以列表格式記錄架構和實作決策。)
2025-05-26 16:20:07 - Log of updates made. (更新日誌。)

*

## Decision (決策)

*   [2025-05-26 16:21:30] - 專案初始化階段，採用現有的程式碼結構。
*   (Project initialization phase, adopting the existing code structure.)
*   [2025-05-26 16:40:09] - 決定擴展遊戲功能，加入多難度、圖片自訂、計時、玩家資料輸入、結果頁面及排行榜。
*   (Decision to expand game features to include multi-difficulty, image customization, timer, player data input, results page, and leaderboard.)

## Rationale (基本原理)

*   [2025-05-26 16:21:30] - 基於使用者提供的初始程式碼進行開發。
*   (Development based on the initial code provided by the user.)
*   [2025-05-26 16:40:09] - 提升遊戲的豐富度和可玩性，增加使用者參與度和挑戰性。
*   (Enhance the richness and replayability of the game, increase user engagement and challenge.)
*   [2025-05-26 16:44:07] - 新增「一鍵完成」按鈕是為了方便開發者測試遊戲完成邏輯，確保遊戲流程的正確性，同時避免影響正常遊戲的計分。
*   (Adding a "Done" button is to facilitate developer testing of game completion logic, ensure the correctness of the game flow, and avoid affecting normal game scoring.)

## Implementation Details (實作細節)

*   [2025-05-26 16:21:30] - 程式碼檔案包括 [`Game.cs`](Assets/Scripts/Game.cs:1) (主要邏輯), [`Btn.cs`](Assets/Scripts/Btn.cs:1) (遊戲控制), [`global.cs`](Assets/Scripts/global.cs:1) (全域變數)。
*   (Code files include [`Game.cs`](Assets/Scripts/Game.cs:1) (main logic), [`Btn.cs`](Assets/Scripts/Btn.cs:1) (game control), [`global.cs`](Assets/Scripts/global.cs:1) (global variables).)
*   [2025-05-26 16:40:09] - 新增場景流程：主選單 -> 輸入資料 -> 選擇難度 -> 遊戲畫面 -> 結果頁面 -> 排行榜。
*   (New scene flow: Main Menu -> Enter Data -> Select Difficulty -> Game Screen -> Results Page -> Leaderboard.)
*   [2025-05-26 16:40:09] - 需要為每個新場景建立對應的 Unity Scene 檔案及 UI 元素 (Buttons, Text, Panels)。
*   (Need to create corresponding Unity Scene files and UI elements (Buttons, Text, Panels) for each new scene.)
*   [2025-05-26 16:40:09] - 現有腳本需要修改以適應新的遊戲狀態和資料管理。可能需要引入新的腳本來處理特定功能，如計時器、排行榜資料儲存/讀取。
*   (Existing scripts will need modification to accommodate new game states and data management. New scripts might be introduced for specific functionalities like timer, leaderboard data storage/retrieval.)
*   [2025-05-26 16:44:07] - 「一鍵完成」按鈕將存在於遊戲畫面場景中。點擊後，它會直接將拼圖設置為完成狀態，並觸發遊戲完成的相關邏輯，但不記錄分數或更新排行榜。
*   (The "Done" button will exist in the game screen scene. Upon clicking, it will directly set the puzzle to the completed state and trigger game completion logic, but will not record scores or update the leaderboard.)
*   [2025-05-26 16:51:06] - **決策 (Decision):** 由於 Architect 模式的檔案編輯限制 (僅限 .md 檔案)，實作 "Done" 按鈕的 C# 程式碼修改需要在 "Code" 模式下進行。
*   ([2025-05-26 16:51:06] - **Decision:** Due to Architect mode's file editing restrictions (only .md files), C# code modifications for implementing the "Done" button need to be performed in "Code" mode.)
*   [2025-05-26 16:51:06] - **理由 (Rationale):** Architect 模式專注於高階規劃和文件記錄，不具備直接修改專案程式碼的權限。
*   ([2025-05-26 16:51:06] - **Rationale:** Architect mode focuses on high-level planning and documentation and does not have permissions to directly modify project code.)
*   [2025-05-26 16:51:06] - **實作細節 (Implementation Details):** Architect 模式將準備好詳細的程式碼修改方案，然後建議使用者切換到 "Code" 模式，由該模式的 AI 助理執行實際的程式碼變更。
*   ([2025-05-26 16:51:06] - **Implementation Details:** Architect mode will prepare a detailed code modification plan, and then recommend the user switch to "Code" mode for the AI assistant in that mode to perform the actual code changes.)
*   [2025-05-26 17:57:56] - **決策 (Decision):** 針對使用者回饋的「重新開始遊戲第九格未移除/洗牌」及「缺少遊戲完成提示」問題，將修改 [`Btn.cs`](Assets/Scripts/Btn.cs:1)。
*   ([2025-05-26 17:57:56] - **Decision:** Address user feedback regarding "ninth tile not removed/shuffled on restart" and "missing game completion prompt" by modifying [`Btn.cs`](Assets/Scripts/Btn.cs:1).)
*   [2025-05-26 17:57:56] - **理由 (Rationale):**
    *   `GameOpen()` 在 `Btn.cs` 中負責遊戲初始化，應確保正確設定全域狀態 (`global.po`, `global.correct`)，並依賴 `Game.cs` 的 `UpdateVisualState()` 更新視覺，避免直接操作 `Sprite`。
    *   遊戲完成提示屬於UI交互，適合放在 `Btn.cs` (作為主要的UI互動腳本之一) 或專門的UI管理器中處理。
*   ([2025-05-26 17:57:56] - **Rationale:**
    *   `GameOpen()` in `Btn.cs` is responsible for game initialization and should ensure correct setup of global state (`global.po`, `global.correct`), relying on `Game.cs`'s `UpdateVisualState()` for visual updates, avoiding direct `Sprite` manipulation.
    *   The game completion prompt is a UI interaction, suitable for handling in `Btn.cs` (as one of the main UI interaction scripts) or a dedicated UI manager.)
*   [2025-05-26 17:57:56] - **實作細節 (Implementation Details):**
    *   **`GameOpen()` 修改：** 確保設定 `global.correct = 0;`，移除直接的 `Sprite` 設定程式碼。
    *   **完成提示：** 在 `Btn.cs` 中新增對 UI Panel 的引用 (`completionPanel`)，並在 `Update()` 中根據 `global.correct` 控制其顯隱。在 `GameOpen()` 中確保其初始隱藏。
*   ([2025-05-26 17:57:56] - **Implementation Details:**
    *   **`GameOpen()` Modification:** Ensure `global.correct = 0;` is set, and remove direct `Sprite` setting code.
    *   **Completion Prompt:** Add a reference to a UI Panel (`completionPanel`) in `Btn.cs` and control its visibility in `Update()` based on `global.correct`. Ensure it's initially hidden in `GameOpen()`.)