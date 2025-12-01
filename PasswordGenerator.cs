using System;
using System.Text;
using System.Threading.Tasks;

namespace SODV2202_Final
{
    public class PasswordGenerator
    {
        public int Length { get; set; } = 30;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = true;

        private readonly Random _random = new Random();

        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        // Asynchronous wrapper
        public Task<string> GeneratePasswordAsync()
        {
            return Task.Run(() => GeneratePassword());
        }

        private string GeneratePassword()
        {
            StringBuilder pool = new StringBuilder(Lowercase);

            if (IncludeUppercase) pool.Append(Uppercase);
            if (IncludeNumbers) pool.Append(Numbers);
            if (IncludeSymbols) pool.Append(Symbols);

            if (pool.Length == 0)
                throw new InvalidOperationException("No character set selected.");

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                int index = _random.Next(pool.Length);
                password.Append(pool[index]);
            }

            return password.ToString();
        }
    }
}
