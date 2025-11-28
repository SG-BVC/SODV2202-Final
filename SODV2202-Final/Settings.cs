using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SODV2202_Final
{
    public class ClipboardManager
    {
        public async Task CopyToClipboardAsync(string text, int clearAfterSeconds = 10)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Clipboard.SetText(text);

            // Auto clear timeout
            await Task.Delay(clearAfterSeconds * 1000);

            if (Clipboard.GetText() == text)
            {
                Clipboard.Clear();
            }
        }
    }

    public class UserPreferences
    {
        public string Theme { get; set; } = "Light";
        public int Timeout { get; set; } = 300; // seconds
        public int Length { get; set; } = 30;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = true;

        private readonly string _filePath = "preferences.json";

        public void SaveSettings()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(_filePath, json);
        }

        public void LoadSettings()
        {
            if (!File.Exists(_filePath)) return;

            string json = File.ReadAllText(_filePath);
            var prefs = JsonSerializer.Deserialize<UserPreferences>(json);
            if (prefs != null)
            {
                Theme = prefs.Theme;
                Timeout = prefs.Timeout;
                Length = prefs.Length;
                IncludeUppercase = prefs.IncludeUppercase;
                IncludeNumbers = prefs.IncludeNumbers;
                IncludeSymbols = prefs.IncludeSymbols;
            }
        }
    }

}
