using SODV2202_Final.Data;
using SODV2202_Final.Logic;
using SODV2202_Final.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SODV2202_Final
{
    public partial class Form1 : Form
    {
        private readonly PasswordGenerator _generator = new();
        private readonly PasswordStrengthChecker _checker = new();
        private readonly UserPreferences _prefs = new();
        private readonly ClipboardManager _clipboard = new();

        // FULL DATASETS
        private List<User> _allUsers = new();
        private List<PasswordHistory> _allPasswords = new();

        public Form1()
        {
            InitializeComponent();

            // Hook Form Load event
            this.Load += Form1_Load;

            // Initialize database & load initial data
            Database.Initialize();
        }

        // ============================================================
        // LOAD USERS INTO TAB 2
        // ============================================================
        private void LoadUsers()
        {
            _allUsers = Database.GetUsers();
            dataGridUsers.DataSource = _allUsers.ToList();
        }

        // ============================================================
        // LOAD PASSWORD HISTORY INTO TAB 3
        // ============================================================
        private void LoadPasswordHistory()
        {
            _allPasswords = Database.GetPasswordHistory();
            dataGridPasswords.DataSource = _allPasswords.ToList();
        }

        // ============================================================
        // GENERATE PASSWORD
        // ============================================================
        private async void btnGenerate_Click_1(object sender, EventArgs e)
        {
            _generator.Length = (int)numericUpDownLength.Value;
            _generator.IncludeUppercase = checkBoxUppercase.Checked;
            _generator.IncludeNumbers = checkBoxNumbers.Checked;
            _generator.IncludeSymbols = checkBoxSymbols.Checked;

            string password = await _generator.GeneratePasswordAsync();
            txtPassword.Text = password;

            string strength = _checker.Evaluate(password);
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

            // save to UI listbox
            listHistory.Items.Add(password);

            // save to DB
            var record = new PasswordHistory
            {
                UserId = 1,
                PasswordValue = password,
                Strength = strength,
                Length = password.Length,
                ContainsUppercase = password.Any(char.IsUpper) ? 1 : 0,
                ContainsNumbers = password.Any(char.IsDigit) ? 1 : 0,
                ContainsSymbols = password.Any(c => "!@#$%^&*()-_=+[]{}|;:,.<>?".Contains(c)) ? 1 : 0,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            Database.SavePassword(record);
            LoadPasswordHistory();
        }

        // ============================================================
        // COPY PASSWORD TO CLIPBOARD
        // ============================================================
        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                await _clipboard.CopyToClipboardAsync(txtPassword.Text, autoClearSeconds: 10);
                MessageBox.Show("Copied! Clipboard will clear in 10 seconds.");
            }
        }

        // ============================================================
        // THEME SWITCHER
        // ============================================================
        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTheme.SelectedItem?.ToString() == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }
        }

        // ============================================================
        // SAVE PREFERENCES
        // ============================================================
        private void buttonSavePrefs_Click(object sender, EventArgs e)
        {
            _prefs.PasswordLength = (int)numericUpDownLength.Value;
            _prefs.IncludeUppercase = checkBoxUppercase.Checked;
            _prefs.IncludeNumbers = checkBoxNumbers.Checked;
            _prefs.IncludeSymbols = checkBoxSymbols.Checked;
            _prefs.Theme = comboBoxTheme.SelectedItem?.ToString() ?? "Light";

            _prefs.Save();
            MessageBox.Show("Preferences saved.");
        }

        // ============================================================
        // LOAD PREFERENCES
        // ============================================================
        private void buttonLoadPrefs_Click(object sender, EventArgs e)
        {
            _prefs.Load();

            numericUpDownLength.Value = _prefs.PasswordLength;
            checkBoxUppercase.Checked = _prefs.IncludeUppercase;
            checkBoxNumbers.Checked = _prefs.IncludeNumbers;
            checkBoxSymbols.Checked = _prefs.IncludeSymbols;
            comboBoxTheme.SelectedItem = _prefs.Theme;

            MessageBox.Show("Preferences loaded.");
        }

        // ============================================================
        // APPLY FILTER
        // ============================================================
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (comboFilterField.SelectedIndex < 0 || comboFilterOp.SelectedIndex < 0)
            {
                MessageBox.Show("Select filter field and operator.");
                return;
            }

            string field = comboFilterField.SelectedItem.ToString();
            string op = comboFilterOp.SelectedItem.ToString();
            string value = txtFilterValue.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("Enter filter value.");
                return;
            }

            // USER FILTERS
            if (field == "Name" || field == "Email" || field == "Age")
            {
                var filtered = FilterEngine.FilterUsers(_allUsers, field, op, value);
                dataGridUsers.DataSource = filtered;
            }

            // PASSWORD FILTERS
            if (field == "Strength" ||
                field == "Length" ||
                field == "ContainsUppercase" ||
                field == "ContainsNumbers" ||
                field == "ContainsSymbols")
            {
                var filtered = FilterEngine.FilterPasswords(_allPasswords, field, op, value);
                dataGridPasswords.DataSource = filtered;
            }
        }

        // ============================================================
        // RESET FILTER
        // ============================================================
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            comboFilterField.SelectedIndex = -1;
            comboFilterOp.SelectedIndex = -1;

            dataGridUsers.DataSource = _allUsers;
            dataGridPasswords.DataSource = _allPasswords;
        }

        // ============================================================
        // FORM LOAD — FINAL INITIALIZATION
        // ============================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadPasswordHistory();

            // Load preferences
            _prefs.Load();

            numericUpDownLength.Value = _prefs.PasswordLength;
            checkBoxUppercase.Checked = _prefs.IncludeUppercase;
            checkBoxNumbers.Checked = _prefs.IncludeNumbers;
            checkBoxSymbols.Checked = _prefs.IncludeSymbols;
            comboBoxTheme.SelectedItem = _prefs.Theme;

            // Default filter dropdowns
            comboFilterField.SelectedIndex = 0;
            comboFilterOp.SelectedIndex = 0;
        }
    }
}
