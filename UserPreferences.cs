using System.IO;
using System.Text.Json;

namespace SODV2202_Final
{
    public class UserPreferences
    {
        public int Length { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }
        public string Theme { get; set; } = "Light";

        private string FilePath => "userprefs.json";

        public void SaveSettings()
        {
            var data = JsonSerializer.Serialize(this);
            File.WriteAllText(FilePath, data);
        }

        public void LoadSettings()
        {
            if (!File.Exists(FilePath)) return;

            var data = File.ReadAllText(FilePath);
            var prefs = JsonSerializer.Deserialize<UserPreferences>(data);

            if (prefs == null) return;

            Length = prefs.Length;
            IncludeUppercase = prefs.IncludeUppercase;
            IncludeNumbers = prefs.IncludeNumbers;
            IncludeSymbols = prefs.IncludeSymbols;
            Theme = prefs.Theme;
        }
    }
}
