param (
    [string]$MigrationName = ""
)

# 入力受付
while ( [string]::IsNullOrEmpty($MigrationName) )
{
    $MigrationName = Read-Host "マイグレーション名を入力してください（例: DBMigration_Ver0.0.1）"
}

# マイグレーションの追加
Write-Host "`n[1/3] dotnet ef migrations add $migrationName を実行中..." -ForegroundColor Cyan
$addProcess = Start-Process "dotnet" -ArgumentList "ef migrations add $migrationName" -NoNewWindow -Wait -PassThru

if ($addProcess.ExitCode -ne 0) {
    Write-Host "? マイグレーションの追加に失敗しました。" -ForegroundColor Red
    exit $addProcess.ExitCode
}

Write-Host "? マイグレーションの追加に成功しました。" -ForegroundColor Green

# データベース更新
Write-Host "`n[2/3] dotnet ef database update を実行中..." -ForegroundColor Cyan
$updateProcess = Start-Process "dotnet" -ArgumentList "ef database update" -NoNewWindow -Wait -PassThru

if ($updateProcess.ExitCode -ne 0) {
    Write-Host "? データベースの更新に失敗しました。" -ForegroundColor Red
    exit $updateProcess.ExitCode
}

Write-Host "? データベースの更新に成功しました。" -ForegroundColor Green

# 既存のマイグレーション一覧から直前のマイグレーション名を取得
Write-Host "`n[3/3] 差分 SQL を出力中..." -ForegroundColor Cyan

# dotnet ef migrations list 実行＆タイムスタンプを除いた名前だけ抽出
$migrations = dotnet ef migrations list

# ログ行をスキップし、マイグレーション名を抽出
$migrationList = $migrations -split "`n" |
    Where-Object { $_ -match "^\s*\d{14}_.+" } |  # 14桁のタイムスタンプ + アンダースコア にマッチ
    ForEach-Object {
        ($_ -replace "^\*", "").Trim() -replace "^\d{14}_", ""
    }

# 入力との比較
$currentIndex = $migrationList.IndexOf($migrationName.Trim())

if ($currentIndex -eq -1) {
    Write-Host "? 現在のマイグレーションが一覧に見つかりません。" -ForegroundColor Red
    Write-Host "? 入力されたマイグレーション名: '$migrationName'" -ForegroundColor Yellow
    Write-Host "? 検出されたマイグレーション一覧: $($migrationList -join ', ')" -ForegroundColor Yellow
    exit 1
}

# 直前のマイグレーションを取得（なければベース）
$previousMigration = if ($currentIndex -gt 0) { $migrationList[$currentIndex - 1] } else { "0" }

# 出力フォルダ作成
$outputDir = ".\MigrationSQL"
if (!(Test-Path $outputDir)) {
    New-Item -Path $outputDir -ItemType Directory | Out-Null
}

# SQL 出力パス作成
$sqlFilePath = Join-Path $outputDir ("DB_Migration_Ver." + ($migrationName -replace "DBMigration_Ver", "") + ".sql")

# スクリプト作成
$scriptArgs = "ef migrations script $previousMigration $migrationName -o $sqlFilePath"
$scriptProcess = Start-Process "dotnet" -ArgumentList $scriptArgs -NoNewWindow -Wait -PassThru

if ($scriptProcess.ExitCode -eq 0) {
    Write-Host "? 差分 SQL を $sqlFilePath に出力しました。" -ForegroundColor Green
} else {
    Write-Host "? 差分 SQL の出力に失敗しました。" -ForegroundColor Red
    exit $scriptProcess.ExitCode
}
