using System.Text.RegularExpressions;

namespace SODV2202_Final
{
    public class PasswordStrengthChecker
    {
        // -----------------------------
        // MAIN METHOD used by Form1.cs
        // -----------------------------
        public string Evaluate(string password)
        {
            return EvaluateStrength(password);
        }

        // -----------------------------
        // Logic preserved
        // -----------------------------
        public string EvaluateStrength(string password)
        {
            if (string.IsNullOrEmpty(password)) return "Very Weak";

            int score = 0;

            if (password.Length >= 8) score++;
            if (Regex.IsMatch(password, "[A-Z]")) score++;
            if (Regex.IsMatch(password, "[0-9]")) score++;
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) score++;

            return score switch
            {
                0 => "Very Weak",
                1 => "Weak",
                2 => "Moderate",
                3 => "Strong",
                _ => "Very Strong"
            };
        }

        // ---------------------------------------------------
        // EXTRA: Used for DB password history saving + filter
        // ---------------------------------------------------
        public PasswordStrengthDetails ComputeDetails(string password)
        {
            return new PasswordStrengthDetails
            {
                Length = password.Length,
                ContainsUppercase = Regex.IsMatch(password, "[A-Z]"),
                ContainsNumbers = Regex.IsMatch(password, "[0-9]"),
                ContainsSymbols = Regex.IsMatch(password, "[^a-zA-Z0-9]")
            };
        }
    }

    // Helper class used for filtering and DB
    public class PasswordStrengthDetails
    {
        public int Length { get; set; }
        public bool ContainsUppercase { get; set; }
        public bool ContainsNumbers { get; set; }
        public bool ContainsSymbols { get; set; }
    }
}
