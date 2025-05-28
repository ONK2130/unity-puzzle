# 🧩 滑塊拼圖 Unity 遊戲 (Sliding Puzzle Unity Game)

這是一個使用 Unity 引擎開發的經典滑塊拼圖遊戲，支援多種尺寸。

## 🚀 專案簡介 (Project Overview)

本專案旨在重現一個互動式的滑塊拼圖體驗。玩家需要將打亂的數字拼圖塊，透過與空格交換位置的方式，恢復到數字的正確順序。遊戲支援多種難度級別 (例如 3x3、3x4 等)，每個級別對應不同數量的拼圖塊。當拼圖完成後，代表空格的拼圖塊將會顯示其對應的圖片 (如果設計如此)，標誌著遊戲的成功。遊戲過程中會記錄玩家的移動步數。

(This project aims to recreate an interactive sliding puzzle experience. Players need to rearrange the scrambled numbered tiles by swapping them with an empty space to restore the correct numerical order. The game supports multiple difficulty levels (e.g., 3x3, 3x4, etc.), each corresponding to a different number of tiles. Upon successful completion, the tile representing the empty space will display its corresponding image (if designed to do so), marking the end of the game. The player's moves are counted throughout the game.)

---

## 🎮 遊戲玩法說明 (Gameplay Instructions)

1.  **開始遊戲 (Start Game):**
    *   遊戲流程可能從主選單開始，引導玩家輸入名稱，然後選擇難度，最後進入對應的遊戲畫面，呈現一個特定大小的網格 (例如簡單模式為 3x3)。
    *   (The game flow may start from a main menu, guiding the player to enter their name, then select a difficulty, and finally enter the corresponding game screen, presenting a grid of a specific size (e.g., 3x3 for Easy mode).)
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
    *   雙擊開啟主選單場景檔案 (預期為 `Assets/Scenes/MainMenuScene.unity`)。如果主選單尚未建立，則可能從 `Assets/Scenes/player-input.unity` (玩家輸入姓名) 或 `Assets/Scenes/DifficultySelect.unity` (難度選擇) 開始，具體取決於您目前的起始場景。
    *   (Double-click to open the main menu scene file (expected to be `Assets/Scenes/MainMenuScene.unity`). If the main menu is not yet created, you might start from `Assets/Scenes/player-input.unity` (player name input) or `Assets/Scenes/DifficultySelect.unity` (difficulty selection), depending on your current starting scene.)
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
        *   隱藏完成面板：嘗試找到 `CompletionManager` 並調用其 `HideCompletionPanel()` 方法，確保遊戲開始時完成提示是隱藏的。
        *   (Hides completion panel: Tries to find `CompletionManager` and calls its `HideCompletionPanel()` method to ensure the completion prompt is hidden at game start.)
        *   注意：拼圖塊的視覺更新現在由各個 `Game.cs` 實例根據 `global.po` 的狀態自行處理。
        *   (Note: The visual update of puzzle tiles is now handled by individual `Game.cs` instances based on the state of `global.po`.)
    *   `public void GameClose()`:
        *   關閉遊戲：設定遊戲視窗物件 `wp` 為不可見 (`wp.SetActive(false)`)。
        *   (Closes the game: Sets the game window GameObject `wp` to be invisible (`wp.SetActive(false)`).)
    *   `public void GameDone()`:
        *   一鍵完成遊戲 (測試用)：將 `global.po` 陣列設置為已解決的順序 (1 到 9)。
        *   (Instantly completes the game (for testing): Sets the `global.po` array to the solved order (1 to 9).)
        *   設定遊戲狀態為完成：將 `global.correct` 設為 1。
        *   (Sets game state to completed: Sets `global.correct` to 1.)
        *   注意：此方法不修改移動次數 (`global.count`)，拼圖塊的視覺更新依賴 `Game.cs` 實例。
        *   (Note: This method does not modify the move count (`global.count`); visual updates of tiles rely on `Game.cs` instances.)
*   **主要變數 (Key Variables):**
    *   `public GameObject wp;`: 連結到 Unity 中的遊戲主視窗 Panel/GameObject。
    *   (`public GameObject wp;`: Linked to the main game window Panel/GameObject in Unity.)
    *   `public GameObject txt_count;`: 連結到顯示移動次數的 UI Text 元件。
    *   (`public GameObject txt_count;`: Linked to the UI Text component displaying the move count.)
    *   `public GameObject[] img = new GameObject[9];`: 連結到九宮格中 8 個拼圖塊和 1 個空白格的 UI Image 元件 (索引 0 到 8)。
    *   (`public GameObject[] img = new GameObject[9];`: Linked to the UI Image components for the 8 puzzle tiles and 1 empty slot in the grid (indices 0 to 8).)

### 3. `Assets/Scripts/Game.cs`

*   **用途 (Purpose):** 此腳本附加到代表**每一個**拼圖塊的 GameObject 上。它負責該拼圖塊的視覺更新、處理點擊事件以嘗試移動，並與 `global` 狀態互動。
*   (This script is attached to **each** GameObject representing a puzzle tile. It's responsible for the visual updates of that tile, handling click events to attempt moves, and interacting with the `global` state.)
*   **主要方法 (Key Methods):**
    *   `void Start()`:
        *   獲取附加到的 GameObject 上的 `Image` 組件。
        *   (Gets the `Image` component on the GameObject it's attached to.)
        *   呼叫 `UpdateVisualState()` 進行初始視覺設定。
        *   (Calls `UpdateVisualState()` for initial visual setup.)
    *   `void Update()`:
        *   每幀根據 `global.po` 陣列重新計算當前拼圖是否完成，並更新 `global.correct` 狀態。
        *   (Recalculates every frame if the current puzzle is solved based on the `global.po` array and updates the `global.correct` state.)
        *   呼叫 `UpdateVisualState()` 以確保拼圖塊的視覺與當前狀態一致。
        *   (Calls `UpdateVisualState()` to ensure the tile's visual is consistent with the current state.)
    *   `void UpdateVisualState()`:
        *   根據 `global.correct` 的狀態和 `global.po[logicalTilePosition - 1]` 的值來決定如何顯示此拼圖塊。
        *   (Determines how to display this tile based on the state of `global.correct` and the value of `global.po[logicalTilePosition - 1]`.)
        *   如果遊戲完成 (`global.correct == 1`)，則顯示其在 `global.po` 中對應的數字圖片。
        *   (If the game is complete (`global.correct == 1`), it displays its corresponding number image from `global.po`.)
        *   如果遊戲進行中，且此位置在 `global.po` 中代表的是空格 (數字 9)，則將 `Image` 組件的 `sprite` 設為 `null` 並禁用 `Image` (使其不可見)。
        *   (If the game is in progress and this position in `global.po` represents the empty space (number 9), it sets the `Image` component's `sprite` to `null` and disables the `Image` (making it invisible).)
        *   否則 (遊戲進行中且不是空格)，則顯示其在 `global.po` 中對應的數字圖片。
        *   (Otherwise (game in progress and not an empty space), it displays its corresponding number image from `global.po`.)
    *   `private void TrySwapIfAdjacentIsSpace(int adjacentLogicalPos)`:
        *   當一個拼圖塊被點擊時，其對應的 `clickX()` 方法會調用此方法來嘗試與指定的相鄰邏輯位置交換。
        *   (When a tile is clicked, its corresponding `clickX()` method calls this to attempt a swap with a specified adjacent logical position.)
        *   首先檢查遊戲是否已完成 (`global.correct == 1`)；如果是，則不允許任何移動。
        *   (First checks if the game is already completed (`global.correct == 1`); if so, no moves are allowed.)
        *   檢查指定的相鄰位置在 `global.po` 中是否為空格 (數字 9)。
        *   (Checks if the specified adjacent position in `global.po` is the empty space (number 9).)
        *   如果是空格，則交換 `global.po` 中當前塊與相鄰空格的值，並增加 `global.count`。
        *   (If it's an empty space, swaps the values of the current tile and the adjacent empty space in `global.po`, and increments `global.count`.)
    *   `public void click1()` 至 `public void click9()`:
        *   這些方法分別由 Unity Editor 中設定的 UI Button (附加在每個拼圖塊 GameObject 上) 的 `OnClick` 事件調用。
        *   (These methods are called by the `OnClick` event of UI Buttons (attached to each puzzle tile GameObject) set up in the Unity Editor.)
        *   每個 `clickX()` 方法會根據其固定的邏輯位置 (`logicalTilePosition`)，調用 `TrySwapIfAdjacentIsSpace()` 來嘗試與其所有可能的相鄰位置交換。例如，`click1()` 會嘗試與位置 2 和位置 4 交換。
        *   (Each `clickX()` method, based on its fixed logical position (`logicalTilePosition`), calls `TrySwapIfAdjacentIsSpace()` to attempt swaps with all its possible adjacent positions. For example, `click1()` will try to swap with position 2 and position 4.)
*   **主要變數 (Key Variables):**
    *   `public int logicalTilePosition;`: 在 Unity Editor 中為每個拼圖塊 GameObject 上的 `Game.cs` 實例設定此值 (1 到 9)，代表該塊在九宮格中的邏輯位置。
    *   (`public int logicalTilePosition;`: This value (1 to 9) is set in the Unity Editor for each `Game.cs` instance on a puzzle tile GameObject, representing its logical position in the 3x3 grid.)
    *   `private Image _imageComponent;`: 腳本在 `Start()` 中獲取的對自身 GameObject 上 `Image` 組件的引用。
    *   (`private Image _imageComponent;`: A reference to the `Image` component on its own GameObject, obtained by the script in `Start()`.)

### 4. `Assets/Scripts/CompletionManager.cs`

*   **用途 (Purpose):** 專門負責管理遊戲完成時彈出的提示面板 (`CompletionPanel`) 的顯示與隱藏邏輯。
*   (Dedicated to managing the display and hiding logic of the completion prompt panel (`CompletionPanel`) that appears when the game is finished.)
*   **主要方法 (Key Methods):**
    *   `void Start()`: 初始化時確保完成面板是隱藏的。
    *   (`void Start()`: Ensures the completion panel is hidden upon initialization.)
    *   `void Update()`: 每幀檢查 `global.correct` 的狀態。如果 `global.correct == 1` (遊戲完成)，則顯示完成面板；否則隱藏面板。
    *   (`void Update()`: Checks the state of `global.correct` every frame. If `global.correct == 1` (game completed), it shows the completion panel; otherwise, it hides the panel.)
    *   `public void HideCompletionPanel()`: 一個公開的方法，允許其他腳本 (例如 `Btn.cs` 在遊戲開始時) 強制隱藏完成面板。
    *   (`public void HideCompletionPanel()`: A public method allowing other scripts (e.g., `Btn.cs` at game start) to forcibly hide the completion panel.)
*   **主要變數 (Key Variables):**
    *   `public GameObject completionPanelGameObject;`: 在 Unity Editor 中連結到代表遊戲完成提示的 UI Panel GameObject。
    *   (`public GameObject completionPanelGameObject;`: Linked in the Unity Editor to the UI Panel GameObject representing the game completion prompt.)

### 5. `Assets/Scripts/Switch.cs`

*   **用途 (Purpose):** 處理不同遊戲場景之間的切換，以及在特定場景 (如 "player-input") 中處理玩家資料的輸入與儲存。
*   (Handles transitions between different game scenes and, in specific scenes like "player-input", manages player data input and storage.)
*   **主要方法 (Key Methods):**
    *   `public void scenes1()`: 切換到名為 "player-input" 的場景。
    *   (`public void scenes1()`: Switches to the scene named "player-input".)
    *   `public void SaveNameAndLoadDifficultySelect()`:
        *   從連結的 `nameInputField` 讀取玩家輸入的姓名。
        *   (Reads the player's entered name from the linked `nameInputField`.)
        *   使用 `PlayerPrefs.SetString("PlayerName", playerName)` 將姓名儲存起來。
        *   (Saves the name using `PlayerPrefs.SetString("PlayerName", playerName)`.)
        *   載入名為 "DifficultySelect" 的場景。
        *   (Loads the scene named "DifficultySelect".)
    *   `public void LoadEasyGame()`: 載入名為 "Puzzl-Easy" 的場景。
    *   (`public void LoadEasyGame()`: Loads the scene named "Puzzl-Easy".)
    *   `public void LoadMediumGame()`: 載入名為 "Puzzl-Medium" 的場景。
    *   (`public void LoadMediumGame()`: Loads the scene named "Puzzl-Medium".)
    *   `public void LoadHardGame()`: 載入名為 "Puzzl-Hard" 的場景。
    *   (`public void LoadHardGame()`: Loads the scene named "Puzzl-Hard".)
    *   `public void GoToPlayerInput()`: 從 "DifficultySelect" 場景返回到 "player-input" 場景。
    *   (`public void GoToPlayerInput()`: Returns from the "DifficultySelect" scene to the "player-input" scene.)
*   **主要變數 (Key Variables):**
    *   `public InputField nameInputField;`: 在 Unity Editor 中連結到 "player-input" 場景中的 UI InputField (Legacy) 元件，用於玩家輸入姓名。
    *   (`public InputField nameInputField;`: Linked in the Unity Editor to the UI InputField (Legacy) component in the "player-input" scene for player name entry.)

### 6. `Assets/Scripts/Btn_M.cs` (中等難度按鈕邏輯)

*   **用途 (Purpose):** 控制中等難度 (3x4, 12塊拼圖) 遊戲的開始、結束及「一鍵完成」流程，並負責初始化中等難度的遊戲板狀態。
*   (Controls the start, end, and "Done" flow for the Medium difficulty (3x4, 12-tile puzzle) game, and is responsible for initializing the Medium difficulty game board state.)
*   **主要方法 (Key Methods):**
    *   `public void GameOpen()`:
        *   啟動遊戲：設定遊戲視窗物件 `wp` 為可見。
        *   (Activates the game: Sets the game window GameObject `wp` to be visible.)
        *   初始化狀態：重置 `Game_M.correct` 為 0，`Game_M.count` 為 0，並更新 UI 顯示。同時設定 `global.correct = 0` 以便 `CompletionManager` 正確隱藏完成面板。
        *   (Initializes state: Resets `Game_M.correct` to 0, `Game_M.count` to 0, and updates the UI display. Also sets `global.correct = 0` so `CompletionManager` correctly hides the completion panel.)
        *   隨機佈局 (3x4)：隨機生成 11 到 21 的數字排列到 `Game_M.po` 陣列的前 11 個位置。第 12 個位置 (`Game_M.po[11]`) 固定為 22 (代表空格)。
        *   (Random layout (3x4): Randomly generates a permutation of numbers 11 to 21 for the first 11 positions of the `Game_M.po` array. The 12th position (`Game_M.po[11]`) is fixed to 22 (representing the empty space).)
        *   隱藏完成面板：嘗試找到 `CompletionManager` 並調用其 `HideCompletionPanel()` 方法。
        *   (Hides completion panel: Tries to find `CompletionManager` and calls its `HideCompletionPanel()` method.)
        *   重新啟用 `Game_M` 實例：查找所有 `Game_M` 腳本實例並將其 `enabled` 設為 `true`，確保它們在遊戲重新開始時能更新視覺。
        *   (Re-enables `Game_M` instances: Finds all `Game_M` script instances and sets their `enabled` to `true` to ensure they update visually when the game restarts.)
    *   `public void GameClose()`: 關閉遊戲視窗。
    *   (Closes the game window.)
    *   `public void GameDone()`:
        *   一鍵完成遊戲 (中等難度)：將 `Game_M.po` 陣列設置為已解決的順序 (11 到 22)。
        *   (Instantly completes the Medium difficulty game: Sets the `Game_M.po` array to the solved order (11 to 22).)
        *   設定遊戲狀態為完成：將 `Game_M.correct` 和 `global.correct` 設為 1。
        *   (Sets game state to completed: Sets `Game_M.correct` and `global.correct` to 1.)
*   **主要變數 (Key Variables):**
    *   `public GameObject wp;`: 連結到中等難度遊戲主視窗 Panel/GameObject。
    *   (`public GameObject wp;`: Linked to the Medium difficulty main game window Panel/GameObject.)
    *   `public GameObject txt_count;`: 連結到顯示移動次數的 UI Text 元件。
    *   (`public GameObject txt_count;`: Linked to the UI Text component displaying the move count.)

### 7. `Assets/Scripts/Game_M.cs` (中等難度遊戲邏輯)

*   **用途 (Purpose):** 此腳本附加到代表中等難度 (3x4) **每一個**拼圖塊的 GameObject 上。它負責該拼圖塊的視覺更新、處理點擊事件以嘗試移動，並與 `Game_M` 的靜態狀態變數互動。
*   (This script is attached to **each** GameObject representing a Medium difficulty (3x4) puzzle tile. It's responsible for the visual updates of that tile, handling click events to attempt moves, and interacting with `Game_M`'s static state variables.)
*   **主要靜態變數 (Key Static Variables, managed by `Btn_M.cs`):**
    *   `public static int[] po = new int[12];`: 儲存 3x4 拼圖盤面狀態 (11-21 為圖塊，22 為空格)。
    *   (`public static int[] po = new int[12];`: Stores the 3x4 puzzle board state (11-21 for tiles, 22 for empty space).)
    *   `public static int count = 0;`: 移動次數。
    *   (`public static int count = 0;`: Move count.)
    *   `public static int correct = 0;`: 遊戲是否完成的標記。
    *   (`public static int correct = 0;`: Flag indicating if the game is completed.)
*   **主要方法 (Key Methods):**
    *   `void Start()`: 獲取 `Image` 組件並進行初始視覺更新。
    *   (Gets the `Image` component and performs initial visual update.)
    *   `void Update()`:
        *   每幀檢查拼圖是否完成 (11-22 的順序)，並更新 `Game_M.correct` 和 `global.correct` 狀態。
        *   (Recalculates every frame if the puzzle is solved (order 11-22) and updates `Game_M.correct` and `global.correct` states.)
        *   如果遊戲完成，則在下一幀禁用此腳本以停止更新。
        *   (If the game is completed, disables this script on the next frame to stop updates.)
        *   呼叫 `UpdateVisualState()`。
        *   (Calls `UpdateVisualState()`.)
    *   `void UpdateVisualState()`:
        *   根據 `Game_M.correct` 和 `Game_M.po[logicalTilePosition - 1]` 的值更新拼圖塊的 Sprite。
        *   (Updates the tile's Sprite based on `Game_M.correct` and `Game_M.po[logicalTilePosition - 1]`.)
        *   如果遊戲完成，顯示對應數字的圖片 (11-22)。
        *   (If game is complete, displays the corresponding number image (11-22).)
        *   如果遊戲進行中，空格 (值為22) 則隱藏，其他則顯示對應數字圖片 (11-21)。
        *   (If game is in progress, the empty space (value 22) is hidden, others display corresponding number images (11-21).)
    *   `private void TrySwapIfAdjacentIsSpace(int adjacentLogicalPos)`: 嘗試與相鄰的空格交換。
    *   (Attempts to swap with an adjacent empty space.)
    *   `public void click_m1()` 至 `public void click_m12()`: 處理各拼圖塊的點擊事件，調用 `TrySwapIfAdjacentIsSpace`。
    *   (Handle click events for each tile, calling `TrySwapIfAdjacentIsSpace`.)
*   **主要變數 (Key Variables):**
    *   `public int logicalTilePosition;`: 在 Unity Editor 中設定 (1 到 12)，代表該塊在 3x4 拼圖中的邏輯位置。
    *   (`public int logicalTilePosition;`: Set in Unity Editor (1 to 12), representing its logical position in the 3x4 grid.)

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
    *   玩家將能夠輸入自己的名稱，用於後續的結果顯示與排行榜。 (目前已實現玩家名稱的輸入與使用 `PlayerPrefs` 儲存的功能於 `Switch.cs`。)
    *   (Players will be able to enter their names for display in results and on the leaderboard. (Currently, the functionality for player name input and storage using `PlayerPrefs` has been implemented in `Switch.cs`.))
5.  **結果頁面 (Results Page):**
    *   遊戲結束後，將顯示一個結果頁面，包含玩家名稱、所選難度、移動步數及花費時間。
    *   (After the game ends, a results page will be displayed, including player name, selected difficulty, move count, and time taken.)
6.  **排行榜 (Leaderboard):**
    *   將新增排行榜功能，顯示前十名玩家的成績 (依難度區分或綜合排行待定)。
    *   (A leaderboard feature will be added to display the top ten players' scores (to be decided if separated by difficulty or combined).)
7.  **一鍵完成測試按鈕 (Done Button for Testing):**
    *   在遊戲畫面中提供一個「完成 (Done)」按鈕，點擊後可立即將拼圖設為完成狀態，方便測試遊戲完成後的邏輯。 (此功能已實現於 `Btn.cs` 的 `GameDone()` 方法。)
    *   (Provide a "Done" button on the game screen that, when clicked, will instantly set the puzzle to its completed state, facilitating testing of post-completion logic. (This feature has been implemented in the `GameDone()` method of `Btn.cs`.))
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