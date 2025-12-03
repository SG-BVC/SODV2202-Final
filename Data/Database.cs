using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SODV2202_Final.Models;

namespace SODV2202_Final.Data
{
    public static class Database
    {
        private const string ConnectionString = "Data Source=passwordDB.sqlite;Version=3;";

        // Initialize database and tables
        public static void Initialize()
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                conn.Open();

                string sql = System.IO.File.ReadAllText("CreateDatabase.sql");
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database initialization error: " + ex.Message);
            }
        }

        // Insert user
        public static void InsertUser(User user)
        {
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            string query = @"INSERT INTO Users (Name, Email, Age, CreatedAt)
                             VALUES (@n, @e, @a, @c)";

            using SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@n", user.Name);
            cmd.Parameters.AddWithValue("@e", user.Email);
            cmd.Parameters.AddWithValue("@a", user.Age);
            cmd.Parameters.AddWithValue("@c", user.CreatedAt);
            cmd.ExecuteNonQuery();
        }

        // Fetch all users
        public static List<User> GetUsers()
        {
            List<User> list = new();

            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            string query = "SELECT * FROM Users ORDER BY UserId ASC";
            using SQLiteCommand cmd = new SQLiteCommand(query, conn);
            using SQLiteDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new User
                {
                    UserId = Convert.ToInt32(r["UserId"]),
                    Name = r["Name"].ToString(),
                    Email = r["Email"].ToString(),
                    Age = Convert.ToInt32(r["Age"]),
                    CreatedAt = r["CreatedAt"].ToString()
                });
            }

            return list;
        }

        // Save password to DB
        public static void SavePassword(PasswordHistory p)
        {
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            string query = @"
                INSERT INTO PasswordHistory 
                (UserId, PasswordValue, Strength, Length, ContainsUppercase, ContainsNumbers, ContainsSymbols, CreatedAt)
                VALUES 
                (@u, @p, @s, @l, @cu, @cn, @cs, @c)";

            using SQLiteCommand cmd = new SQLiteCommand(query, conn);

            cmd.Parameters.AddWithValue("@u", p.UserId);
            cmd.Parameters.AddWithValue("@p", p.PasswordValue);
            cmd.Parameters.AddWithValue("@s", p.Strength);
            cmd.Parameters.AddWithValue("@l", p.Length);
            cmd.Parameters.AddWithValue("@cu", p.ContainsUppercase);
            cmd.Parameters.AddWithValue("@cn", p.ContainsNumbers);
            cmd.Parameters.AddWithValue("@cs", p.ContainsSymbols);
            cmd.Parameters.AddWithValue("@c", p.CreatedAt);

            cmd.ExecuteNonQuery();
        }

        // Fetch all saved passwords
        public static List<PasswordHistory> GetPasswordHistory()
        {
            List<PasswordHistory> list = new();

            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            string query = "SELECT * FROM PasswordHistory ORDER BY PasswordId DESC";

            using SQLiteCommand cmd = new SQLiteCommand(query, conn);
            using SQLiteDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PasswordHistory
                {
                    PasswordId = Convert.ToInt32(r["PasswordId"]),
                    UserId = Convert.ToInt32(r["UserId"]),
                    PasswordValue = r["PasswordValue"].ToString(),
                    Strength = r["Strength"].ToString(),
                    Length = Convert.ToInt32(r["Length"]),
                    ContainsUppercase = Convert.ToInt32(r["ContainsUppercase"]),
                    ContainsNumbers = Convert.ToInt32(r["ContainsNumbers"]),
                    ContainsSymbols = Convert.ToInt32(r["ContainsSymbols"]),
                    CreatedAt = r["CreatedAt"].ToString()
                });
            }

            return list;
        }

        // ======================
        // REQUIRED BY Form1.cs
        // ======================

        // Alias for GetUsers()
        public static List<User> LoadAllUsers() => GetUsers();

        // Alias for GetPasswordHistory()
        public static List<PasswordHistory> LoadAllPasswords() => GetPasswordHistory();
    }
}
