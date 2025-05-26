# Product Context (產品內容)

This file provides a high-level overview of the project and the expected product that will be created. Initially it is based upon projectBrief.md (if provided) and all other available project-related information in the working directory. This file is intended to be updated as the project evolves, and should be used to inform all other modes of the project's goals and context.
(此檔案提供專案的高階概觀以及預期創建的產品。它最初基於 projectBrief.md (如果提供) 以及工作目錄中所有其他可用的專案相關資訊。此檔案旨在隨著專案的發展而更新，並應用於通知所有其他模式專案的目標和內容。)
2025-05-26 16:19:46 - Log of updates made will be appended as footnotes to the end of this file. (更新日誌將附加到此文件末尾作為註腳。)

*

## Project Goal (專案目標)

*   開發一個具有多種難度、可自訂圖片、計時功能、結果顯示及排行榜的九宮格拼圖 Unity 遊戲。
*   (Develop a 3x3 sliding puzzle game in Unity with multiple difficulty levels, customizable images, a timer, results display, and a leaderboard.)

## Key Features (主要功能)

*   **核心玩法 (Core Gameplay):**
    *   遊戲開始時，移除拼圖中的一塊 (例如 3x3 中的第 9 塊)。
    *   (When the game starts, one tile is removed from the puzzle (e.g., the 9th tile in a 3x3 grid).)
    *   玩家透過點擊滑鼠移動拼圖。
    *   (Players move tiles by clicking the mouse.)
    *   當拼圖完成正確順序時，被移除的拼圖會重新出現，完成遊戲。
    *   (When the puzzle is solved in the correct order, the removed tile reappears, completing the game.)
*   **難度級別 (Difficulty Levels):**
    *   提供簡單 (目前 3x3)、中等、困難等不同難度。
    *   (Offer different difficulty levels: Easy (current 3x3), Medium, Hard.)
*   **圖片自訂 (Image Customization):**
    *   允許不同難度使用不同的預設圖片集。
    *   (Allow different default image sets for different difficulties.)
    *   (未來可能擴展為玩家自選圖片。)
    *   ((Future extension could allow player-selected images.))
*   **計分與計時 (Scoring and Timer):**
    *   記錄玩家的移動次數。
    *   (Counts the player's moves.)
    *   增加計時功能，記錄完成遊戲所需時間。
    *   (Add a timer function to record the time taken to complete the game.)
*   **玩家資料 (Player Data):**
    *   允許玩家輸入名稱，用於排行榜。
    *   (Allow players to enter their name for the leaderboard.)
*   **結果與排行 (Results and Leaderboard):**
    *   遊戲結束後顯示結果頁面 (移動步數、時間)。
    *   (Display a results page after game completion (moves, time).)
    *   提供排行榜功能，顯示前十名玩家的記錄。
    *   (Provide a leaderboard feature to display the top ten player records.)
*   **使用者介面 (User Interface):**
    *   清晰的場景流程：主選單 -> 輸入資料 -> 選擇難度 -> 遊戲畫面 -> 結果頁面 -> 排行榜。
    *   (Clear scene flow: Main Menu -> Enter Data -> Select Difficulty -> Game Screen -> Results Page -> Leaderboard.)
*   **測試輔助 (Testing Aid):**
    *   提供一個「一鍵完成 (Done)」按鈕，用於快速完成拼圖以測試遊戲完成邏輯，此操作不計入分數/排行榜。
    *   (Provide a "Done" button to instantly complete the puzzle for testing the game completion logic; this action will not be scored or recorded on the leaderboard.)

## Overall Architecture (整體架構)

*   使用 Unity 引擎開發。
*   (Developed using the Unity engine.)
*   **場景管理 (Scene Management):**
    *   主選單場景 (MainMenuScene)
    *   輸入資料場景 (EnterDataScene)
    *   遊戲難度選擇場景 (DifficultySelectScene)
    *   遊戲畫面場景 (GameScene_Easy, GameScene_Medium, GameScene_Hard - 根據難度可能需要不同場景或動態調整)
    *   (Game Screen Scene (GameScene_Easy, GameScene_Medium, GameScene_Hard - may require different scenes or dynamic adjustments based on difficulty))
    *   結果頁面場景 (ResultScene)
    *   排行榜場景 (LeaderboardScene)
*   **腳本結構 (Script Structure):**
    *   現有的 `Game.cs`, `Btn.cs`, `global.cs` 將作為基礎，並根據新功能進行擴展或重構。
    *   (Existing `Game.cs`, `Btn.cs`, `global.cs` will serve as a base and be extended or refactored for new features.)
    *   可能需要新的腳本來管理場景切換、資料持久化 (排行榜、玩家名稱)、計時器邏輯、不同難度的遊戲板生成等。
    *   (New scripts may be needed for scene transitions, data persistence (leaderboard, player name), timer logic, game board generation for different difficulties, etc.)
*   UI 物件 (如 `wp`、`txt_count` 及新增的按鈕、輸入框等) 用於 Unity 介面操作。
*   (UI objects (like `wp`, `txt_count`, and new buttons, input fields, etc.) are used for Unity interface manipulation.)