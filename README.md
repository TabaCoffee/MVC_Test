# MVC_Test
MVC實作

主要為記帳功能，支援新增消費以及檢視歷史紀錄。

直接編譯即可。

View:
1. Index: 選擇要新增還是檢視資料
2. Record: 顯示新增資料表格
3. Display: 顯示歷史紀錄

Controller:
1. Index: 首頁，無須傳送資料
2. Record: 僅傳送表格示範文字
3. New: 透過ADO.Net存取SQLite來新增資料，並轉回首頁
4. Display: 透過ADO.Net存取SQLite來顯示資料
