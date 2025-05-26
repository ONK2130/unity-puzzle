# System Patterns *Optional* (系統模式 *可選*)

This file documents recurring patterns and standards used in the project.
It is optional, but recommended to be updated as the project evolves.
(此檔案記錄專案中使用的重複模式和標準。它是可選的，但建議隨著專案的發展而更新。)
2025-05-26 16:20:12 - Log of updates made. (更新日誌。)

*

## Coding Patterns (編碼模式)

*   [2025-05-26 16:21:38] - 使用 C# 進行 Unity 腳本編寫。
*   (Using C# for Unity scripting.)
*   [2025-05-26 16:21:38] - 透過 `public GameObject` 變數在 Unity Editor 中連結 UI 物件。
*   (Linking UI objects in Unity Editor via `public GameObject` variables.)
*   [2025-05-26 16:21:38] - 使用靜態類別 `global` ([`Assets/Scripts/global.cs`](Assets/Scripts/global.cs:1)) 管理全域狀態。
*   (Using a static class `global` ([`Assets/Scripts/global.cs`](Assets/Scripts/global.cs:1)) to manage global state.)

## Architectural Patterns (架構模式)

*   [2025-05-26 16:21:38] - 基本的 Model-View-Controller (MVC) 概念：
    *   Model: [`global.cs`](Assets/Scripts/global.cs:1) (數據), 未來可能包含玩家資料、排行榜資料。
    *   (Model: [`global.cs`](Assets/Scripts/global.cs:1) (data), may include player data, leaderboard data in the future.)
    *   View: Unity UI 元素 (由 `img` 和 `txt_count` 等變數代表, 以及各場景的 UI)。
    *   (View: Unity UI elements (represented by variables like `img` and `txt_count`, and UI for each scene).)
    *   Controller: [`Game.cs`](Assets/Scripts/Game.cs:1) 和 [`Btn.cs`](Assets/Scripts/Btn.cs:1) (邏輯處理), 未來會增加更多控制器腳本管理不同場景和功能。
    *   (Controller: [`Game.cs`](Assets/Scripts/Game.cs:1) and [`Btn.cs`](Assets/Scripts/Btn.cs:1) (logic handling), more controller scripts will be added to manage different scenes and features.)
*   [2025-05-26 16:40:25] - **場景管理 (Scene Management):** 使用 Unity 的 `SceneManager.LoadScene()` 進行場景切換。
*   (Using Unity's `SceneManager.LoadScene()` for scene transitions.)
*   [2025-05-26 16:40:25] - **資料持久化 (Data Persistence) (潛在):**
    *   玩家名稱和排行榜資料可能使用 `PlayerPrefs` (適用於簡單的本機儲存) 或 JSON/XML 檔案儲存。
    *   (Player name and leaderboard data might use `PlayerPrefs` (for simple local storage) or JSON/XML file storage.)
    *   更複雜的排行榜系統未來可能考慮使用伺服器端儲存。
    *   (More complex leaderboard systems might consider server-side storage in the future.)

## Testing Patterns (測試模式)

*   [2025-05-26 16:21:38] - 目前未定義明確的測試模式。
*   (No specific testing patterns defined at the moment.)
*   [2025-05-26 16:40:25] - 新增功能後，需要針對每個場景的互動、資料傳遞、計時準確性、排行榜更新等進行手動測試。
*   (After adding new features, manual testing will be required for each scene's interaction, data passing, timer accuracy, leaderboard updates, etc.)