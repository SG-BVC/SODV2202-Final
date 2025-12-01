using System.Text.RegularExpressions;

namespace SODV2202_Final
{
    public class PasswordStrengthChecker
    {
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
    }
}
