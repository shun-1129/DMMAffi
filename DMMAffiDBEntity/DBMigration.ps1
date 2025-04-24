param (
    [string]$MigrationName = ""
)

# ���͎�t
while ( [string]::IsNullOrEmpty($MigrationName) )
{
    $MigrationName = Read-Host "�}�C�O���[�V����������͂��Ă��������i��: DBMigration_Ver0.0.1�j"
}

# �}�C�O���[�V�����̒ǉ�
Write-Host "`n[1/3] dotnet ef migrations add $migrationName �����s��..." -ForegroundColor Cyan
$addProcess = Start-Process "dotnet" -ArgumentList "ef migrations add $migrationName" -NoNewWindow -Wait -PassThru

if ($addProcess.ExitCode -ne 0) {
    Write-Host "? �}�C�O���[�V�����̒ǉ��Ɏ��s���܂����B" -ForegroundColor Red
    exit $addProcess.ExitCode
}

Write-Host "? �}�C�O���[�V�����̒ǉ��ɐ������܂����B" -ForegroundColor Green

# �f�[�^�x�[�X�X�V
Write-Host "`n[2/3] dotnet ef database update �����s��..." -ForegroundColor Cyan
$updateProcess = Start-Process "dotnet" -ArgumentList "ef database update" -NoNewWindow -Wait -PassThru

if ($updateProcess.ExitCode -ne 0) {
    Write-Host "? �f�[�^�x�[�X�̍X�V�Ɏ��s���܂����B" -ForegroundColor Red
    exit $updateProcess.ExitCode
}

Write-Host "? �f�[�^�x�[�X�̍X�V�ɐ������܂����B" -ForegroundColor Green

# �����̃}�C�O���[�V�����ꗗ���璼�O�̃}�C�O���[�V���������擾
Write-Host "`n[3/3] ���� SQL ���o�͒�..." -ForegroundColor Cyan

# dotnet ef migrations list ���s���^�C���X�^���v�����������O�������o
$migrations = dotnet ef migrations list

# ���O�s���X�L�b�v���A�}�C�O���[�V�������𒊏o
$migrationList = $migrations -split "`n" |
    Where-Object { $_ -match "^\s*\d{14}_.+" } |  # 14���̃^�C���X�^���v + �A���_�[�X�R�A �Ƀ}�b�`
    ForEach-Object {
        ($_ -replace "^\*", "").Trim() -replace "^\d{14}_", ""
    }

# ���͂Ƃ̔�r
$currentIndex = $migrationList.IndexOf($migrationName.Trim())

if ($currentIndex -eq -1) {
    Write-Host "? ���݂̃}�C�O���[�V�������ꗗ�Ɍ�����܂���B" -ForegroundColor Red
    Write-Host "? ���͂��ꂽ�}�C�O���[�V������: '$migrationName'" -ForegroundColor Yellow
    Write-Host "? ���o���ꂽ�}�C�O���[�V�����ꗗ: $($migrationList -join ', ')" -ForegroundColor Yellow
    exit 1
}

# ���O�̃}�C�O���[�V�������擾�i�Ȃ���΃x�[�X�j
$previousMigration = if ($currentIndex -gt 0) { $migrationList[$currentIndex - 1] } else { "0" }

# �o�̓t�H���_�쐬
$outputDir = ".\MigrationSQL"
if (!(Test-Path $outputDir)) {
    New-Item -Path $outputDir -ItemType Directory | Out-Null
}

# SQL �o�̓p�X�쐬
$sqlFilePath = Join-Path $outputDir ("DB_Migration_Ver." + ($migrationName -replace "DBMigration_Ver", "") + ".sql")

# �X�N���v�g�쐬
$scriptArgs = "ef migrations script $previousMigration $migrationName -o $sqlFilePath"
$scriptProcess = Start-Process "dotnet" -ArgumentList $scriptArgs -NoNewWindow -Wait -PassThru

if ($scriptProcess.ExitCode -eq 0) {
    Write-Host "? ���� SQL �� $sqlFilePath �ɏo�͂��܂����B" -ForegroundColor Green
} else {
    Write-Host "? ���� SQL �̏o�͂Ɏ��s���܂����B" -ForegroundColor Red
    exit $scriptProcess.ExitCode
}
