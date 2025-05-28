# Unity 拼圖遊戲專案

這是一個使用 Unity 開發的拼圖遊戲，支援多種難度模式，包含完整的遊戲流程從玩家輸入到遊戲結算。

## 專案結構

```
Class_20250319/
├── Assets/                          # Unity 資源目錄
│   ├── Resources/                   # 遊戲資源文件
│   │   ├── 1.png - 9.png          # 簡單模式 (3x3) 拼圖圖片
│   │   ├── 11.png - 22.png        # 中等模式 (3x4) 拼圖圖片
│   │   └── Mid/                    # 中等模式相關資源
│   ├── Scenes/                      # Unity 場景文件
│   │   ├── Player-input.unity      # 玩家輸入姓名場景
│   │   ├── Main.unity              # 主選單場景
│   │   ├── DifficultySelect.unity  # 難度選擇場景
│   │   ├── Puzzl-Easy.unity        # 簡單模式遊戲場景 (3x3)
│   │   ├── Puzzl-Medium.unity      # 中等模式遊戲場景 (3x4)
│   │   └── Scoring.unity           # 遊戲結算場景
│   └── Scripts/                     # 遊戲腳本
│       ├── global.cs               # 全域變數管理（遊戲狀態、拼圖陣列等）
│       ├── Switch.cs               # 場景切換控制器
│       ├── Game.cs                 # 簡單模式遊戲邏輯（拼圖移動、檢查完成）
│       ├── Game_M.cs               # 中等模式遊戲邏輯（拼圖移動、檢查完成）
│       ├── Btn.cs                  # 簡單模式按鈕控制（開始、關閉、Done）
│       ├── Btn_M.cs                # 中等模式按鈕控制（開始、關閉、Done）
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

## 遊戲流程

1. **玩家輸入** (`Player-input.unity`)
   - 玩家輸入姓名
   - 點擊「開始遊戲」進入難度選擇

2. **難度選擇** (`DifficultySelect.unity`)
   - 選擇簡單模式（3x3 拼圖）
   - 選擇中等模式（3x4 拼圖）

3. **遊戲進行** (`Puzzl-Easy.unity` / `Puzzl-Medium.unity`)
   - 點擊「開始遊戲」打亂拼圖
   - 點擊拼圖塊進行移動
   - 完成拼圖後自動顯示完成面板
   - 可使用「Done」按鈕快速完成（測試用）

4. **遊戲結算** (`Scoring.unity`)
   - 顯示玩家姓名、移動步數、遊戲難度
   - 可選擇「再來一局」、「選擇難度」或「返回主選單」

## 核心系統

### 全域狀態管理 (`global.cs`)
- `po[]`: 簡單模式拼圖陣列（1-9，9為空格）
- `correct`: 遊戲完成狀態（0=未完成，1=已完成）
- `count`: 當前移動步數
- `lastMoveCount`: 上一局的移動步數
- `lastDifficulty`: 上一局的難度

### 中等模式狀態 (`Game_M.cs`)
- `po[]`: 中等模式拼圖陣列（11-22，22為空格）
- `correct`: 中等模式完成狀態
- `count`: 中等模式移動步數

### 完成管理系統 (`CompletionManager.cs`)
- 統一管理遊戲完成面板的顯示/隱藏
- 智能檢測拼圖完成狀態
- 處理場景切換時的狀態同步

## 開發特色

1. **模組化設計**：簡單和中等模式使用獨立的腳本，便於擴展
2. **狀態同步**：使用全域變數確保場景間的狀態一致性
3. **智能狀態管理**：自動處理場景切換時的狀態重置
4. **Memory Bank**：完整記錄開發決策和進度

## 建置需求

- Unity 2021.3 或更高版本
- 支援 2D 遊戲開發

## 如何執行

1. 使用 Unity Hub 開啟專案
2. 在 Unity 編輯器中開啟 `Player-input` 場景
3. 點擊播放按鈕開始遊戲

## 版本控制

本專案使用 Git 進行版本控制，`.gitignore` 已配置為忽略 Unity 自動生成的文件。

## 授權

此專案為教學用途開發。