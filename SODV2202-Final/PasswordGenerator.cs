using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SODV2202_Final
{
    public class PasswordGenerator
    {
        public int Length { get; set; } = 30;
        public bool IncludeSymbols { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;

        private readonly Random _random = new Random();

        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        public async Task<string> GeneratePasswordAsync()
        {
            return await Task.Run(() => GeneratePassword());
        }

        private string GeneratePassword()
        {
            StringBuilder charPool = new StringBuilder(Lowercase);

            if (IncludeUppercase)
            {
                charPool.Append(Uppercase);
            }
            if (IncludeNumbers)
            {
                charPool.Append(Numbers);
            }
            if (IncludeSymbols)
            {
                charPool.Append(Symbols);
            }

            if (charPool.Length == 0)
            {
                throw new InvalidOperationException("At least one character type must be selected.");
            }

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                int index = _random.Next(charPool.Length);
                password.Append(charPool[index]);
            }

            return password.ToString();
        }
    }

    public class PasswordStrengthChecker
    {
        public string EvaluateStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Very Weak";

            int score = 0;

            if (password.Length >= 8)
            {
                score++;
            }
            if (password.Length >= 16)
            {
                score++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"\d"))
            {
                score++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]"))
            {
                score++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                score++;
            }

            return score switch
            {
                0 or 1 => "Very Weak",
                2 => "Weak",
                3 => "Moderate",
                4 => "Strong",
                5 => "Very Strong",
                _ => "Unknown"
            };
        }
    }

    public class PasswordStorage
    {
        private readonly string _filePath = "passwords.json";

        public List<string> Passwords { get; private set; } = new List<string>();

        public void SavePassword(string password)
        {
            Passwords.Add(password);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(Passwords));
        }

        public void LoadPasswords()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }

            string json = File.ReadAllText(_filePath);
            Passwords = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        }
    }
}
