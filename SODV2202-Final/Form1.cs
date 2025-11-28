using System.Windows.Forms;

namespace SODV2202_Final
{
    public partial class Form1 : Form
    {
        private PasswordGenerator _generator = new PasswordGenerator();
        private PasswordStrengthChecker _strengthChecker = new PasswordStrengthChecker();
        private ClipboardManager _clipboard = new ClipboardManager();
        private PasswordStorage _storage = new PasswordStorage();
        private UserPreferences _preferences = new UserPreferences();

        public Form1()
        {
            InitializeComponent();
            _storage.LoadPasswords();
            listHistory.Items.AddRange(_storage.Passwords.ToArray());

            numericUpDownLength.Value = _generator.Length;
            checkBoxUppercase.Checked = _generator.IncludeUppercase;
            checkBoxNumbers.Checked = _generator.IncludeNumbers;
            checkBoxSymbols.Checked = _generator.IncludeSymbols;
        }

        private async void generatePassword()
        {
            // update generator settings
            _generator.Length = (int)numericUpDownLength.Value;
            _generator.IncludeUppercase = checkBoxUppercase.Checked;
            _generator.IncludeNumbers = checkBoxNumbers.Checked;
            _generator.IncludeSymbols = checkBoxSymbols.Checked;

            // generate password
            string password = await _generator.GeneratePasswordAsync();
            lblPassword.Text = password;

            // calculate strength
            string strength = _strengthChecker.EvaluateStrength(password);
            UpdateStrengthBar(strength);

            // save to history
            _storage.SavePassword(password);
            listHistory.Items.Add(password);
        }

        private async void copyToClipboard()
        {
            if (string.IsNullOrEmpty(lblPassword.Text))
            {
                return;
            }
            await _clipboard.CopyToClipboardAsync(lblPassword.Text, 30);
            MessageBox.Show("Password copied to clipboard! It will clear in 10 seconds.", "Copied");
        }

        private void UpdateStrengthBar(string strength)
        {
            switch (strength)
            {
                case "Very Weak": progressBarStrength.Value = 20; progressBarStrength.ForeColor = System.Drawing.Color.Red; break;
                case "Weak": progressBarStrength.Value = 40; progressBarStrength.ForeColor = System.Drawing.Color.OrangeRed; break;
                case "Moderate": progressBarStrength.Value = 60; progressBarStrength.ForeColor = System.Drawing.Color.Orange; break;
                case "Strong": progressBarStrength.Value = 80; progressBarStrength.ForeColor = System.Drawing.Color.YellowGreen; break;
                case "Very Strong": progressBarStrength.Value = 100; progressBarStrength.ForeColor = System.Drawing.Color.Green; break;
            }
        }

        private void LoadPreferences()
        {
            _preferences.LoadSettings();

            numericUpDownLength.Value = _generator.Length = _preferences.Length;
            checkBoxUppercase.Checked = _generator.IncludeUppercase = _preferences.IncludeUppercase;
            checkBoxNumbers.Checked = _generator.IncludeNumbers = _preferences.IncludeNumbers;
            checkBoxSymbols.Checked = _generator.IncludeSymbols = _preferences.IncludeSymbols;

            if (_preferences.Theme == "Dark")
                ApplyDarkTheme();
            else
                ApplyLightTheme();
        }

        private void SavePreferences()
        {
            _preferences.Length = (int)numericUpDownLength.Value;
            _preferences.IncludeUppercase = checkBoxUppercase.Checked;
            _preferences.IncludeNumbers = checkBoxNumbers.Checked;
            _preferences.IncludeSymbols = checkBoxSymbols.Checked;
            _preferences.SaveSettings();
            MessageBox.Show("Preferences saved!", "Saved");
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            foreach (Control ctrl in this.Controls)
                ctrl.ForeColor = System.Drawing.Color.Black;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = System.Drawing.Color.White;
            foreach (Control ctrl in this.Controls)
                ctrl.ForeColor = System.Drawing.Color.Black;
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            generatePassword();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            copyToClipboard();
        }

        private void buttonLoadPrefs_Click(object sender, EventArgs e)
        {
            LoadPreferences();
        }

        private void buttonSavePrefs_Click(object sender, EventArgs e)
        {
            SavePreferences();
        }
        
        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTheme.SelectedItem == null) return;

            string selectedTheme = comboBoxTheme.SelectedItem.ToString();
            _preferences.Theme = selectedTheme;

            if (selectedTheme == "Dark")
                ApplyDarkTheme();
            else
                ApplyLightTheme();
        }

    }
}
