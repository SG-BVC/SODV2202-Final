-- Create Users table
CREATE TABLE IF NOT EXISTS Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Age INTEGER NOT NULL,
    CreatedAt TEXT NOT NULL
);

-- Create PasswordHistory table
CREATE TABLE IF NOT EXISTS PasswordHistory (
    PasswordId INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    PasswordValue TEXT NOT NULL,
    Strength TEXT NOT NULL,
    Length INTEGER NOT NULL,
    ContainsUppercase INTEGER NOT NULL,
    ContainsNumbers INTEGER NOT NULL,
    ContainsSymbols INTEGER NOT NULL,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY(UserId) REFERENCES Users(UserId)
);
