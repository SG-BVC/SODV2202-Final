Write-Host "----- SODV2202 Password Generator Database Setup -----" -ForegroundColor Cyan

# REMOVE OLD DATABASE IF EXISTS
if (Test-Path "passwordDB.sqlite") {
    Write-Host "Existing database found. Removing..." -ForegroundColor Yellow
    Remove-Item "passwordDB.sqlite"
}

# CREATE NEW EMPTY DATABASE FILE
Write-Host "Creating new SQLite database file..." -ForegroundColor Green
sqlite3 passwordDB.sqlite ".databases"

# APPLY SCHEMA (TABLE CREATION)
Write-Host "Applying schema (CreateDatabase.sql)..." -ForegroundColor Green
sqlite3 passwordDB.sqlite < CreateDatabase.sql

# INSERT SAMPLE USERS
Write-Host "Inserting 200 sample international users..." -ForegroundColor Green
sqlite3 passwordDB.sqlite < InsertSampleUsers.sql

# VERIFY INSTALLATION
Write-Host "Verifying Users table entry count..." -ForegroundColor Cyan
sqlite3 passwordDB.sqlite "SELECT COUNT(*) AS TotalUsers FROM Users;"

Write-Host "Verifying PasswordHistory table exists..." -ForegroundColor Cyan
sqlite3 passwordDB.sqlite "SELECT name FROM sqlite_master WHERE type='table';"

Write-Host "----- Database Setup Complete -----" -ForegroundColor Green
