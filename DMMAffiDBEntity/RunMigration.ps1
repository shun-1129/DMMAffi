# 呼び出したいスクリプトのパスを指定
.\DBMigration.ps1

# 60秒待機するか、キー入力があるまで待機する
$timeout = 60
$start = Get-Date

# 60秒カウント開始
Write-Host "60秒間待機します。キー入力で終了できます..."

while ($true) {
    $elapsed = (Get-Date) - $start
    if ($elapsed.TotalSeconds -ge $timeout) {
        Write-Host "60秒経過しました。ターミナルを終了します。"
        break
    }
    
    # キー入力があれば終了
    if ($Host.UI.RawUI.KeyAvailable) {
        $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
        Write-Host "キーが入力されました。ターミナルを終了します。"
        break
    }
    
    Start-Sleep -Seconds 1
}