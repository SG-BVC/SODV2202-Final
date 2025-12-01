namespace SODV2202_Final
{
    public partial class Form1 : Form
    {
        private readonly PasswordGenerator _generator = new();
        private readonly PasswordStrengthChecker _checker = new();
        private readonly PasswordStorage _storage = new();
        private readonly UserPreferences _prefs = new();
        private readonly ClipboardManager _clipboard = new();


        private async void btnGenerate_Click_1(object sender, EventArgs e)
        {
            _generator.Length = (int)numericUpDownLength.Value;
            _generator.IncludeUppercase = checkBoxUppercase.Checked;
            _generator.IncludeNumbers = checkBoxNumbers.Checked;
            _generator.IncludeSymbols = checkBoxSymbols.Checked;

            string password = await _generator.GeneratePasswordAsync();
            txtPassword.Text = password;

            string strength = _checker.EvaluateStrength(password);
            lblStrength.Text = strength;

            progressBarStrength.Value = strength switch
            {
                "Very Weak" => 20,
                "Weak" => 40,
                "Moderate" => 60,
                "Strong" => 80,
                "Very Strong" => 100,
                _ => 0
            };

            _storage.SavePassword(password);
            listHistory.Items.Add(password);
        }


        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                await _clipboard.CopyToClipboardAsync(txtPassword.Text, autoClearSeconds: 10);
                MessageBox.Show("Copied! Clipboard will clear automatically.");
            }
        }


        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTheme.SelectedItem?.ToString() == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                ForeColor = Color.Black;
            }
        }


        private void buttonSavePrefs_Click(object sender, EventArgs e)
        {
            _prefs.Length = (int)numericUpDownLength.Value;
            _prefs.IncludeUppercase = checkBoxUppercase.Checked;
            _prefs.IncludeNumbers = checkBoxNumbers.Checked;
            _prefs.IncludeSymbols = checkBoxSymbols.Checked;
            _prefs.Theme = comboBoxTheme.SelectedItem?.ToString() ?? "Light";

            _prefs.SaveSettings();

            MessageBox.Show("Preferences saved.");
        }


        private void buttonLoadPrefs_Click(object sender, EventArgs e)
        {
            _prefs.LoadSettings();

            numericUpDownLength.Value = _prefs.Length;
            checkBoxUppercase.Checked = _prefs.IncludeUppercase;
            checkBoxNumbers.Checked = _prefs.IncludeNumbers;
            checkBoxSymbols.Checked = _prefs.IncludeSymbols;

            comboBoxTheme.SelectedItem = _prefs.Theme;

            MessageBox.Show("Preferences loaded.");
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
