# �Ăяo�������X�N���v�g�̃p�X���w��
.\DBMigration.ps1

# 60�b�ҋ@���邩�A�L�[���͂�����܂őҋ@����
$timeout = 60
$start = Get-Date

# 60�b�J�E���g�J�n
Write-Host "60�b�ԑҋ@���܂��B�L�[���͂ŏI���ł��܂�..."

while ($true) {
    $elapsed = (Get-Date) - $start
    if ($elapsed.TotalSeconds -ge $timeout) {
        Write-Host "60�b�o�߂��܂����B�^�[�~�i�����I�����܂��B"
        break
    }
    
    # �L�[���͂�����ΏI��
    if ($Host.UI.RawUI.KeyAvailable) {
        $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
        Write-Host "�L�[�����͂���܂����B�^�[�~�i�����I�����܂��B"
        break
    }
    
    Start-Sleep -Seconds 1
}