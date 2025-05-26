# 🧩 九宮格拼圖 Unity 遊戲 (3x3 Sliding Puzzle Unity Game)

這是一個使用 Unity 引擎開發的經典九宮格滑塊拼圖遊戲。

## 🚀 專案簡介 (Project Overview)

本專案旨在重現一個互動式的九宮格拼圖體驗。玩家需要將打亂的 1 到 8 號拼圖塊，透過與空格交換位置的方式，恢復到數字的正確順序。當拼圖完成後，消失的第 9 塊拼圖將會歸位，標誌著遊戲的成功。遊戲過程中會記錄玩家的移動步數。

(This project aims to recreate an interactive 3x3 sliding puzzle experience. Players need to rearrange the scrambled tiles (numbered 1 to 8) by swapping them with an empty space to restore the correct numerical order. Upon successful completion, the missing 9th tile will reappear, marking the end of the game. The player's moves are counted throughout the game.)

---

## 🎮 遊戲玩法說明 (Gameplay Instructions)

1.  **開始遊戲 (Start Game):**
    *   點擊「開始遊戲」按鈕後，遊戲畫面會呈現一個 3x3 的網格。
    *   (After clicking the "Start Game" button, a 3x3 grid will be displayed.)
    *   其中 8 個格子會隨機填入 1 到 8 的圖片，剩下 1 個格子則為空白。
    *   (Eight of these cells will be randomly filled with images numbered 1 to 8, while one cell will remain empty.)

2.  **移動拼圖 (Moving Tiles):**
    *   玩家可以點擊與**空白格相鄰**的任一拼圖塊。
    *   (Players can click on any tile that is adjacent (horizontally or vertically) to the empty cell.)
    *   被點擊的拼圖塊將會與空白格交換位置。
    *   (The clicked tile will swap its position with the empty cell.)

3.  **遊戲目標 (Game Objective):**
    *   將拼圖塊依照數字 1 到 8 的順序，由左至右、由上至下排列整齊。
    *   (The objective is to arrange the tiles in numerical order from 1 to 8, from left to right, and top to bottom.)
    *   **完成狀態範例 (Example of Solved State):**
        ```
        [1] [2] [3]
        [4] [5] [6]
        [7] [8] [ ]  <- 遊戲完成時，[9] 會出現於此
        ```
    *   當所有拼圖塊排列正確時，第 9 塊拼圖會自動填入空白格，遊戲即告完成。
    *   (When all tiles are correctly arranged, the 9th tile will automatically fill the empty slot, and the game is completed.)

4.  **計數器 (Move Counter):**
    *   遊戲介面會即時顯示玩家所移動的步數。
    *   (The game interface will display the number of moves made by the player in real-time.)

---

## 🛠️ 如何開始/執行遊戲 (How to Start/Run the Game)

1.  **環境需求 (Environment Requirements):**
    *   Unity Hub
    *   Unity Editor (建議使用與專案建立時相容的版本)
    *   (Unity Hub and a compatible version of the Unity Editor are required.)

2.  **開啟專案 (Opening the Project):**
    *   啟動 Unity Hub。
    *   (Launch Unity Hub.)
    *   點擊「開啟」或「Add project from disk」，然後選擇此專案的根目錄。
    *   (Click "Open" or "Add project from disk" and select the root directory of this project.)

3.  **執行遊戲 (Running the Game):**
    *   在 Unity Editor 中，於「Project」視窗找到 `Assets/Scenes/` 目錄。
    *   (In the Unity Editor, locate the `Assets/Scenes/` directory in the "Project" window.)
    *   雙擊開啟主要的遊戲場景檔案 (例如 `Puzzle.unity` 或 `SampleScene.unity` - 請依專案實際情況確認)。
    *   (Double-click to open the main game scene file (e.g., `Puzzle.unity` or `SampleScene.unity` - please verify based on the actual project setup).)
    *   點擊 Unity Editor 頂部中央的「播放 (Play)」按鈕 (▶️) 即可開始遊戲。
    *   (Click the "Play" button (▶️) located at the top center of the Unity Editor to start the game.)

---

## ⚙️ 程式結構與主要腳本 (Code Structure and Main Scripts)

本專案主要由以下 C# 腳本構成，它們共同實現了遊戲的核心功能：

### 1. `Assets/Scripts/global.cs`

*   **用途 (Purpose):** 全域靜態類別，用於儲存整個遊戲過程中需要共享的數據。
*   (A global static class used to store data that needs to be shared throughout the game.)
*   **主要成員 (Key Members):**
    *   `public static int count;`: 記錄玩家的移動步數。
    *   (`public static int count;`: Tracks the player's move count.)
    *   `public static int[] po = new int[9];`: 長度為 9 的整數陣列，用於儲存九宮格中每個位置 (索引 0 到 8) 當前所代表的拼圖塊編號 (1 到 9，其中 9 通常代表空白塊或遊戲完成時的最後一塊)。
    *   (`public static int[] po = new int[9];`: An integer array of length 9, storing the tile number (1 to 9, where 9 often represents the empty slot or the final piece upon completion) for each position (index 0 to 8) in the grid.)
    *   `public static int correct;`: 標記拼圖是否已完成 (1 代表完成，0 代表未完成)。
    *   (`public static int correct;`: A flag indicating whether the puzzle is solved (1 for solved, 0 for unsolved).)

### 2. `Assets/Scripts/Btn.cs`

*   **用途 (Purpose):** 控制遊戲的開始與結束流程，以及遊戲板的初始化。
*   (Controls the game's start and end flow, as well as the initialization of the game board.)
*   **主要方法 (Key Methods):**
    *   `public void GameOpen()`:
        *   啟動遊戲：設定遊戲視窗物件 `wp` 為可見 (`wp.SetActive(true)`)。
        *   (Activates the game: Sets the game window GameObject `wp` to be visible (`wp.SetActive(true)`).)
        *   初始化狀態：重置移動計數器 `global.count` 為 0，並更新 UI 顯示。
        *   (Initializes state: Resets the move counter `global.count` to 0 and updates the UI display.)
        *   隨機佈局：隨機生成 1 到 8 的數字排列到 `global.po` 陣列的前 8 個位置，確保不重複。第 9 個位置 (`global.po[8]`) 固定為 9。
        *   (Random layout: Randomly generates a permutation of numbers 1 to 8 for the first 8 positions of the `global.po` array, ensuring no duplicates. The 9th position (`global.po[8]`) is fixed to 9.)
        *   載入圖片：根據 `global.po` 的順序，將對應編號的圖片資源 (例如 "1.png", "2.png") 指派給 `img` 陣列中的各個 UI Image 元件。`img[8]` (對應 `global.po[8]`, 即第 9 塊) 的圖片設為 `null`，形成空白格。
        *   (Loads images: Assigns image resources (e.g., "1.png", "2.png") to the UI Image components in the `img` array based on the order in `global.po`. The image for `img[8]` (corresponding to `global.po[8]`, the 9th tile) is set to `null` to create the empty slot.)
    *   `public void GameClose()`:
        *   關閉遊戲：設定遊戲視窗物件 `wp` 為不可見 (`wp.SetActive(false)`)。
        *   (Closes the game: Sets the game window GameObject `wp` to be invisible (`wp.SetActive(false)`).)
*   **主要變數 (Key Variables):**
    *   `public GameObject wp;`: 連結到 Unity 中的遊戲主視窗 Panel/GameObject。
    *   (`public GameObject wp;`: Linked to the main game window Panel/GameObject in Unity.)
    *   `public GameObject txt_count;`: 連結到顯示移動次數的 UI Text 元件。
    *   (`public GameObject txt_count;`: Linked to the UI Text component displaying the move count.)
    *   `public GameObject[] img = new GameObject[9];`: 連結到九宮格中 8 個拼圖塊和 1 個空白格的 UI Image 元件 (索引 0 到 8)。
    *   (`public GameObject[] img = new GameObject[9];`: Linked to the UI Image components for the 8 puzzle tiles and 1 empty slot in the grid (indices 0 to 8).)

### 3. `Assets/Scripts/Game.cs`

*   **用途 (Purpose):** 實現遊戲的核心互動邏輯，包括處理玩家點擊、移動拼圖、以及判斷遊戲是否完成。
*   (Implements the core interactive logic of the game, including handling player clicks, moving tiles, and determining if the game is won.)
*   **主要方法 (Key Methods):**
    *   `void Update()`:
        *   每幀檢查遊戲是否完成：遍歷 `global.po` 陣列，確認前 8 個位置是否依序為 1 到 8。
        *   (Checks for game completion every frame: Iterates through the `global.po` array to verify if the first 8 positions are sequentially 1 to 8.)
        *   若完成 (`global.correct == 1`)，則將第 9 塊拼圖的圖片 (`Resources.Load<Sprite>("9")`) 顯示在 `img[9]` (即原來的空白格) 上。
        *   (If completed (`global.correct == 1`), displays the image for the 9th tile (`Resources.Load<Sprite>("9")`) on `img[9]` (the original empty slot).)
    *   `public void click1()` 至 `public void click9()`:
        *   分別對應九宮格中 9 個位置的點擊事件。
        *   (Correspond to click events for the 9 positions in the grid, respectively.)
        *   每個 `clickX()` 方法的邏輯相似：
            1.  檢查被點擊位置的四周 (上、下、左、右，視情況而定) 是否為空白格 (即對應的 `img[Y].GetComponent<Image>().sprite == null`)。
            2.  (Each `clickX()` method has similar logic: 1. Checks if any adjacent cell (up, down, left, right, as applicable) is the empty slot (i.e., the corresponding `img[Y].GetComponent<Image>().sprite == null`).)
            3.  如果找到空白格，則交換被點擊拼圖塊與空白格的圖片 (`Sprite`)。
            4.  (If an empty slot is found, swaps the `Sprite` of the clicked tile and the empty slot.)
            5.  同時，更新 `global.po` 陣列中對應位置的數字，以反映拼圖塊的移動。
            6.  (Simultaneously, updates the numbers in the `global.po` array at the corresponding positions to reflect the tile movement.)
            7.  如果發生了有效的移動 (即被點擊的格子變為空白)，則 `global.count` 加 1，並更新 `txt_count` 的顯示。
            8.  (If a valid move occurred (i.e., the clicked cell becomes empty), increments `global.count` and updates the `txt_count` display.)
*   **主要變數 (Key Variables):**
    *   `public GameObject[] img = new GameObject[10];`: 連結到九宮格中 9 個拼圖塊位置的 UI Image 元件。注意這裡陣列長度為 10，`img[0]` 到 `img[8]` 對應九宮格的 9 個格子，而 `img[9]` 似乎特指用於顯示完成時的第 9 張圖 (與 `Btn.cs` 中的 `img` 陣列用途略有不同，需注意其在 `Update` 和 `clickX` 方法中的使用)。
    *   (`public GameObject[] img = new GameObject[10];`: Linked to UI Image components for the 9 tile positions in the grid. Note the array length is 10; `img[0]` to `img[8]` correspond to the 9 grid cells, while `img[9]` appears to specifically refer to the 9th image displayed upon completion (slightly different usage than the `img` array in `Btn.cs`, pay attention to its use in `Update` and `clickX` methods).)
    *   `public GameObject txt_count;`: 同 `Btn.cs`，連結到顯示移動次數的 UI Text 元件。
    *   (`public GameObject txt_count;`: Same as in `Btn.cs`, linked to the UI Text component displaying the move count.)

---

## 🚀 下一階段開發計畫 (Next Phase Development Plan)

為了提升遊戲的豐富度和可玩性，計畫加入以下新功能及場景流程：

(To enhance the game's richness and replayability, the following new features and scene flow are planned:)

### 🌟 主要新增功能 (Key New Features)

1.  **多難度級別 (Multiple Difficulty Levels):**
    *   除了現有的簡單模式 (3x3)，將新增中等 (例如 4x4) 和困難 (例如 5x5) 模式。
    *   (In addition to the existing Easy mode (3x3), Medium (e.g., 4x4) and Hard (e.g., 5x5) modes will be added.)
2.  **圖片自訂 (Image Customization):**
    *   不同難度將使用不同的預設圖片集。第一個難度 (簡單) 的圖片已備妥。
    *   (Different difficulty levels will use different default image sets. Images for the first difficulty (Easy) are ready.)
3.  **計時功能 (Timer Functionality):**
    *   遊戲中將加入計時器，記錄玩家完成拼圖所花費的時間。
    *   (A timer will be added to the game to record the time taken by the player to complete the puzzle.)
4.  **玩家資料輸入 (Player Data Input):**
    *   玩家將能夠輸入自己的名稱，用於後續的結果顯示與排行榜。
    *   (Players will be able to enter their names for display in results and on the leaderboard.)
5.  **結果頁面 (Results Page):**
    *   遊戲結束後，將顯示一個結果頁面，包含玩家名稱、所選難度、移動步數及花費時間。
    *   (After the game ends, a results page will be displayed, including player name, selected difficulty, move count, and time taken.)
6.  **排行榜 (Leaderboard):**
    *   將新增排行榜功能，顯示前十名玩家的成績 (依難度區分或綜合排行待定)。
    *   (A leaderboard feature will be added to display the top ten players' scores (to be decided if separated by difficulty or combined).)
7.  **一鍵完成測試按鈕 (Done Button for Testing):**
    *   在遊戲畫面中提供一個「完成 (Done)」按鈕，點擊後可立即將拼圖設為完成狀態，方便測試遊戲完成後的邏輯。
    *   (Provide a "Done" button on the game screen that, when clicked, will instantly set the puzzle to its completed state, facilitating testing of post-completion logic.)
    *   **重要:** 透過此按鈕完成遊戲將不會記錄時間或步數，也不會計入排行榜。
    *   (**Important:** Completing the game via this button will not record time or moves and will not be included in the leaderboard.)

### 🌊 預期場景流程 (Expected Scene Flow)

```mermaid
graph TD
    A[主選單 Scenes (MainMenuScene)] --> B{開始遊戲?};
    B -- 是 --> C[輸入資料 Scenes (EnterDataScene)];
    B -- 否 (遊戲說明) --> A;
    C --> D[遊戲難度選擇 Scenes (DifficultySelectScene)];
    D -- 簡單 --> E1[遊戲畫面 Scenes - 簡單 (GameScene_Easy)];
    D -- 中等 --> E2[遊戲畫面 Scenes - 中等 (GameScene_Medium)];
    D -- 困難 --> E3[遊戲畫面 Scenes - 困難 (GameScene_Hard)];
    E1 --> F[結果頁面 Scenes (ResultScene)];
    E2 --> F;
    E3 --> F;
    F -- 查看排行榜 --> G[排行榜 Scenes (LeaderboardScene)];
    F -- 回到主選單 --> A;
    G -- 回到主選單 --> A;
```

### 🧱 各場景 GameObject 規劃建議 (Suggested GameObject Planning per Scene)

#### A. 主選單場景 (MainMenuScene)
*   **Scene 名稱:** `MainMenuScene`
*   **主要 GameObjects:**
    *   `Canvas_MainMenu` (Canvas)
        *   `Text_GameTitle` (Text): 遊戲標題
        *   `Button_StartGame` (Button, Text): "開始遊戲" -> `EnterDataScene`
        *   `Button_Instructions` (Button, Text): "遊戲說明" -> 顯示 `Panel_Instructions`
        *   `Panel_Instructions` (Panel, Image) (預設隱藏)
            *   `Text_InstructionsContent` (Text): 遊戲說明內容
            *   `Button_CloseInstructions` (Button, Text): "關閉"
        *   `Button_ExitGame` (Button, Text) (可選): "離開遊戲" -> `Application.Quit()`

#### B. 輸入資料場景 (EnterDataScene)
*   **Scene 名稱:** `EnterDataScene`
*   **主要 GameObjects:**
    *   `Canvas_EnterData` (Canvas)
        *   `Text_Prompt` (Text): "請輸入您的玩家名稱"
        *   `InputField_PlayerName` (InputField, Text): 玩家名稱輸入框
        *   `Button_ConfirmName` (Button, Text): "確定" -> 儲存名稱, 載入 `DifficultySelectScene`
        *   `Button_BackToMain` (Button, Text) (可選): "返回主選單" -> `MainMenuScene`

#### C. 遊戲難度選擇場景 (DifficultySelectScene)
*   **Scene 名稱:** `DifficultySelectScene`
*   **主要 GameObjects:**
    *   `Canvas_DifficultySelect` (Canvas)
        *   `Text_Title` (Text): "選擇遊戲難度"
        *   `Button_Easy` (Button, Text): "簡單 (3x3)" -> 設定難度, 載入 `GameScene_Easy`
        *   `Button_Medium` (Button, Text): "中等 (例如 4x4)" -> 設定難度, 載入 `GameScene_Medium`
        *   `Button_Hard` (Button, Text): "困難 (例如 5x5)" -> 設定難度, 載入 `GameScene_Hard`
        *   `Button_Back` (Button, Text) (可選): "返回" -> `EnterDataScene`

#### D. 遊戲畫面場景 (GameScene_Easy / GameScene_Medium / GameScene_Hard)
*   **Scene 名稱:** `GameScene_Easy`, `GameScene_Medium`, `GameScene_Hard` (或可動態配置的 `GameScene`)
*   **主要 GameObjects (擴展現有):**
    *   `Canvas_Game` (Canvas)
        *   `Panel_GameBoard` (Panel): 容納拼圖格
            *   `Image_Tile_1` ... `Image_Tile_N` (Image/Button): 拼圖塊
        *   `Text_MoveCount` (Text): 移動步數
        *   `Text_Timer` (Text): **(新)** 遊戲時間
        *   `Button_Pause` (Button, Text) (可選): "暫停"
        *   `Panel_PauseMenu` (Panel, Image) (預設隱藏, 可選)
        *   `Button_DoneTest` (Button, Text) (可選, 開發/測試用): "一鍵完成" -> 觸發完成邏輯 (不計分)

#### E. 結果頁面 / 結束遊戲頁面場景 (ResultScene)
*   **Scene 名稱:** `ResultScene`
*   **主要 GameObjects:**
    *   `Canvas_Result` (Canvas)
        *   `Text_ResultTitle` (Text): "遊戲結束" / "恭喜完成！"
        *   `Text_PlayerNameDisplay` (Text): 顯示玩家名稱
        *   `Text_DifficultyDisplay` (Text): 顯示難度
        *   `Text_MovesDisplay` (Text): 顯示步數
        *   `Text_TimeDisplay` (Text): **(新)** 顯示時間
        *   `Button_ViewLeaderboard` (Button, Text): "查看排行榜" -> `LeaderboardScene`
        *   `Button_BackToMainMenu_Result` (Button, Text): "回到主選單" -> `MainMenuScene`

#### F. 排行榜場景 (LeaderboardScene)
*   **Scene 名稱:** `LeaderboardScene`
*   **主要 GameObjects:**
    *   `Canvas_Leaderboard` (Canvas)
        *   `Text_LeaderboardTitle` (Text): "排行榜"
        *   `Panel_LeaderboardEntries` (Panel, VerticalLayoutGroup 可選): 顯示排行榜條目
            *   (動態生成或 Prefab: `Panel_Entry_X` -> `Text_Rank`, `Text_PlayerName_Entry`, `Text_Moves_Entry`, `Text_Time_Entry`)
        *   `Button_BackToMainMenu_Leaderboard` (Button, Text): "回到主選單" -> `MainMenuScene`

---
## � 原有未來可能的擴展 (Original Potential Future Enhancements)

*   **多種難度:** 增加 4x4、5x5 等不同大小的拼圖。 (已納入下一階段計畫)
*   (Multiple difficulties: Add different puzzle sizes like 4x4, 5x5. (Now part of the next phase plan))
*   **自訂圖片:** 允許玩家上傳自己的圖片作為拼圖。 (下一階段計畫包含基礎，此為進階擴展)
*   (Custom images: Allow players to upload their own images for the puzzle. (Next phase includes basics, this is an advanced extension))
*   **計時功能:** 記錄完成拼圖所需的時間。 (已納入下一階段計畫)
*   (Timer function: Record the time taken to complete the puzzle. (Now part of the next phase plan))
*   **排行榜:** 記錄最快完成時間或最少步數。 (已納入下一階段計畫)
*   (Leaderboard: Record fastest completion times or fewest moves. (Now part of the next phase plan))
*   **音效與動畫:** 增加更豐富的用戶體驗。
*   (Sound effects and animations: Enhance the user experience.)