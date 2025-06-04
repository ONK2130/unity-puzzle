# 🧩 Unity 拼圖遊戲專案

<div align="center">

[![Unity](https://img.shields.io/badge/Unity-2021.3+-black?style=for-the-badge&logo=unity)](https://unity.com/)
[![License](https://img.shields.io/badge/License-Educational-blue?style=for-the-badge)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20macOS-green?style=for-the-badge)](https://github.com/ONK2130/unity-puzzle)

</div>


## 📖 專案簡介

這是一個使用 Unity 開發的互動式拼圖遊戲，提供多種難度選擇，從簡單的 3x3、中等的 3x4 到困難的 3x5 拼圖挑戰。遊戲包含完整的流程設計，從玩家登入到遊戲結算，提供流暢的遊戲體驗。

### ✨ 主要特色

- 🎮 **多難度模式** - 簡單 (3x3)、中等 (3x4) 和困難 (3x5) 難度選擇
- 👤 **個人化體驗** - 玩家姓名輸入與記錄
- 📊 **成績追蹤** - 移動步數計算與顯示
- 🏆 **完成獎勵** - 遊戲完成彈窗與結算畫面
- 🔄 **流暢切換** - 智能場景管理系統

## 📁 專案結構

```
Class_20250319/
├── Assets/                          # Unity 資源目錄
│   ├── Resources/                   # 遊戲資源文件
│   │   ├── 1.png - 9.png          # 簡單模式 (3x3) 拼圖圖片
│   │   ├── 11.png - 22.png        # 中等模式 (3x4) 拼圖圖片
│   │   ├── 31.jpg - 45.jpg        # 困難模式 (3x5) 拼圖圖片
│   │   └── Mid/                    # 中等模式相關資源
│   ├── Scenes/                      # Unity 場景文件
│   │   ├── Player-input.unity      # 玩家輸入姓名場景
│   │   ├── Main.unity              # 主選單場景
│   │   ├── DifficultySelect.unity  # 難度選擇場景
│   │   ├── Puzzl-Easy.unity        # 簡單模式遊戲場景 (3x3)
│   │   ├── Puzzl-Medium.unity      # 中等模式遊戲場景 (3x4)
│   │   ├── Puzzl-Hard.unity        # 困難模式遊戲場景 (3x5)
│   │   ├── Scoring.unity           # 遊戲結算場景
│   │   └── Info.unity              # 遊戲資訊場景
│   └── Scripts/                     # 遊戲腳本
│       ├── global.cs               # 全域變數管理（遊戲狀態、拼圖陣列等）
│       ├── Switch.cs               # 場景切換控制器
│       ├── Game.cs                 # 簡單模式遊戲邏輯（拼圖移動、檢查完成）
│       ├── Game_M.cs               # 中等模式遊戲邏輯（拼圖移動、檢查完成）
│       ├── Game_H.cs               # 困難模式遊戲邏輯（拼圖移動、檢查完成）
│       ├── Btn.cs                  # 簡單模式按鈕控制（開始、關閉、Done）
│       ├── Btn_M.cs                # 中等模式按鈕控制（開始、關閉、Done）
│       ├── Btn_H.cs                # 困難模式按鈕控制（開始、關閉、Done）
│       ├── CompletionManager.cs    # 遊戲完成狀態管理（統一處理完成面板顯示）
│       └── ScoringSceneManager.cs  # 結算場景管理（顯示分數、處理跳轉）
├── memory-bank/                     # 專案記憶庫（追蹤開發進度）
│   ├── productContext.md           # 產品概述和架構
│   ├── systemPatterns.md           # 系統設計模式
│   ├── activeContext.md            # 當前開發狀態
│   ├── decisionLog.md              # 重要決策記錄
│   └── progress.md                 # 開發進度追蹤
├── Library/                         # Unity 自動生成的庫文件（Git 忽略）
├── Logs/                           # Unity 日誌文件（Git 忽略）
├── Packages/                       # Unity 套件配置
├── ProjectSettings/                # Unity 專案設定
├── Temp/                           # Unity 臨時文件（Git 忽略）
├── UserSettings/                   # 用戶設定（Git 忽略）
├── .gitignore                      # Git 忽略文件配置
├── Assembly-CSharp.csproj          # C# 專案文件
└── README.md                       # 本文件
```

## 🎮 遊戲流程

### 1️⃣ 玩家輸入 (`Player-input.unity`)

- 玩家輸入姓名
- 點擊「開始遊戲」進入難度選擇

### 2️⃣ 難度選擇 (`DifficultySelect.unity`)

- 選擇簡單模式（3x3 拼圖）
- 選擇中等模式（3x4 拼圖）
- 選擇困難模式（3x5 拼圖）

### 3️⃣ 遊戲進行 (`Puzzl-Easy.unity` / `Puzzl-Medium.unity` / `Puzzl-Hard.unity`)

- 點擊「開始遊戲」打亂拼圖
- 點擊拼圖塊進行移動
- 完成拼圖後自動顯示完成面板
- 可使用「Done」按鈕快速完成（測試用）

### 4️⃣ 遊戲結算 (`Scoring.unity`)

- 顯示所有已玩過難度的玩家姓名、移動步數、遊戲難度
- 可選擇「再來一局」、「選擇難度」或「返回主選單」

## 🔧 核心系統

### 📌 全域狀態管理 (`global.cs`)

| 變數             | 說明                               |
| ---------------- | ---------------------------------- |
| `po[]`           | 簡單模式拼圖陣列（1-9，9 為空格）  |
| `correct`        | 遊戲完成狀態（0=未完成，1=已完成） |
| `count`          | 當前移動步數                       |
| `lastMoveCount`  | 上一局的移動步數                   |
| `lastDifficulty` | 上一局的難度                       |

### 📌 中等模式狀態 (`Game_M.cs`)

| 變數      | 說明                                 |
| --------- | ------------------------------------ |
| `po[]`    | 中等模式拼圖陣列（11-22，22 為空格） |
| `correct` | 中等模式完成狀態                     |
| `count`   | 中等模式移動步數                     |

### 📌 困難模式狀態 (`Game_H.cs`)

| 變數      | 說明                                 |
| --------- | ------------------------------------ |
| `po[]`    | 困難模式拼圖陣列（31-46，46 為空格） |
| `correct` | 困難模式完成狀態                     |
| `count`   | 困難模式移動步數                     |

### 📌 完成管理系統 (`CompletionManager.cs`)

- ✅ 統一管理遊戲完成面板的顯示/隱藏
- ✅ 智能檢測拼圖完成狀態
- ✅ 處理場景切換時的狀態同步

## 💡 開發特色

### 🏗️ 架構設計

- **模組化設計**：簡單、中等和困難模式使用獨立的腳本，便於擴展
- **狀態同步**：使用全域變數確保場景間的狀態一致性
- **智能狀態管理**：自動處理場景切換時的狀態重置

### 📝 開發管理

- **Memory Bank**：完整記錄開發決策和進度
- **版本控制**：使用 Git 進行版本管理
- **文檔完善**：詳細的程式碼註解和文檔

## 🚀 快速開始

### 系統需求

- Unity 2021.3 或更高版本
- 支援 2D 遊戲開發
- Windows 或 macOS 作業系統

### 安裝步驟

1. 克隆專案到本地
   ```bash
   git clone https://github.com/ONK2130/unity-puzzle.git
   ```
2. 使用 Unity Hub 開啟專案
3. 在 Unity 編輯器中開啟 `Player-input` 場景
4. 點擊播放按鈕開始遊戲

## 📊 技術細節

### 場景管理

- 使用 `SceneManager.LoadScene()` 進行場景切換
- 透過 `global.cs` 保持場景間的資料傳遞

### 拼圖邏輯

- Fisher-Yates 演算法實現拼圖打亂
- 檢查相鄰空格實現拼圖移動
- 即時檢測拼圖完成狀態
- 多難度拼圖大小支援（3x3、3x4、3x5）

### UI 系統

- 使用 Unity UI 系統建立介面
- 動態更新移動步數顯示
- 彈窗系統顯示遊戲完成
- 多難度分數同時顯示

## 🤝 貢獻指南

歡迎提交 Issue 或 Pull Request 來改進這個專案！

## 📄 授權

此專案為教學用途開發，僅供學習參考使用。

---

<div align="center">

**Made with ❤️ using Unity**

</div>
