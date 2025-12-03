using System.Drawing;
using System.Windows.Forms;

namespace SODV2202_Final
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // =============================
            // FORM SETTINGS
            // =============================
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 600);
            this.Name = "Form1";
            this.Text = "Password Generator Tool";
            this.StartPosition = FormStartPosition.CenterScreen;

            // =============================
            // MAIN TAB CONTROL
            // =============================
            tabControlMain = new TabControl();
            tabControlMain.Location = new Point(10, 10);
            tabControlMain.Size = new Size(880, 580);

            tabPagePassword = new TabPage("Password Generator");
            tabPageUsers = new TabPage("Users");
            tabPageHistory = new TabPage("Password History");
            tabPageFilters = new TabPage("Filters");

            tabControlMain.Controls.Add(tabPagePassword);
            tabControlMain.Controls.Add(tabPageUsers);
            tabControlMain.Controls.Add(tabPageHistory);
            tabControlMain.Controls.Add(tabPageFilters);

            // =========================================================
            // TAB 1 — PASSWORD GENERATOR UI
            // =========================================================

            lblPassword = new Label();
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 20);
            lblPassword.Text = "Generated Password";

            txtPassword = new TextBox();
            txtPassword.Location = new Point(20, 50);
            txtPassword.Size = new Size(350, 27);

            btnGenerate = new Button();
            btnGenerate.Location = new Point(20, 90);
            btnGenerate.Size = new Size(120, 30);
            btnGenerate.Text = "Generate";
            btnGenerate.Click += btnGenerate_Click_1;

            numericUpDownLength = new NumericUpDown();
            numericUpDownLength.Location = new Point(160, 92);
            numericUpDownLength.Maximum = 30;
            numericUpDownLength.Size = new Size(100, 27);

            checkBoxUppercase = new CheckBox();
            checkBoxUppercase.Text = "Uppercase";
            checkBoxUppercase.Location = new Point(20, 140);

            checkBoxNumbers = new CheckBox();
            checkBoxNumbers.Text = "Numbers";
            checkBoxNumbers.Location = new Point(20, 170);

            checkBoxSymbols = new CheckBox();
            checkBoxSymbols.Text = "Symbols";
            checkBoxSymbols.Location = new Point(20, 200);

            lblStrength = new Label();
            lblStrength.Location = new Point(20, 240);
            lblStrength.AutoSize = true;
            lblStrength.Text = "Strength:";

            progressBarStrength = new ProgressBar();
            progressBarStrength.Location = new Point(20, 265);
            progressBarStrength.Size = new Size(350, 25);

            buttonCopy = new Button();
            buttonCopy.Location = new Point(20, 305);
            buttonCopy.Size = new Size(100, 30);
            buttonCopy.Text = "Copy";
            buttonCopy.Click += buttonCopy_Click;

            comboBoxTheme = new ComboBox();
            comboBoxTheme.Location = new Point(20, 345);
            comboBoxTheme.Size = new Size(150, 28);
            comboBoxTheme.Items.AddRange(new string[] { "Light", "Dark" });
            comboBoxTheme.SelectedIndexChanged += comboBoxTheme_SelectedIndexChanged;

            numericUpDownTimeout = new NumericUpDown();
            numericUpDownTimeout.Location = new Point(20, 385);
            numericUpDownTimeout.Maximum = 60;
            numericUpDownTimeout.Size = new Size(100, 27);

            buttonSavePrefs = new Button();
            buttonSavePrefs.Location = new Point(20, 425);
            buttonSavePrefs.Size = new Size(150, 30);
            buttonSavePrefs.Text = "Save Preferences";
            buttonSavePrefs.Click += buttonSavePrefs_Click;

            buttonLoadPrefs = new Button();
            buttonLoadPrefs.Location = new Point(20, 465);
            buttonLoadPrefs.Size = new Size(150, 30);
            buttonLoadPrefs.Text = "Load Preferences";
            buttonLoadPrefs.Click += buttonLoadPrefs_Click;

            listHistory = new ListBox();
            listHistory.Location = new Point(420, 50);
            listHistory.Size = new Size(430, 440);

            // Add controls to Password tab
            tabPagePassword.Controls.Add(lblPassword);
            tabPagePassword.Controls.Add(txtPassword);
            tabPagePassword.Controls.Add(btnGenerate);
            tabPagePassword.Controls.Add(numericUpDownLength);
            tabPagePassword.Controls.Add(checkBoxUppercase);
            tabPagePassword.Controls.Add(checkBoxNumbers);
            tabPagePassword.Controls.Add(checkBoxSymbols);
            tabPagePassword.Controls.Add(lblStrength);
            tabPagePassword.Controls.Add(progressBarStrength);
            tabPagePassword.Controls.Add(buttonCopy);
            tabPagePassword.Controls.Add(comboBoxTheme);
            tabPagePassword.Controls.Add(numericUpDownTimeout);
            tabPagePassword.Controls.Add(buttonSavePrefs);
            tabPagePassword.Controls.Add(buttonLoadPrefs);
            tabPagePassword.Controls.Add(listHistory);

            // =========================================================
            // TAB 2 — USERS GRID
            // =========================================================

            dataGridUsers = new DataGridView();
            dataGridUsers.Location = new Point(10, 10);
            dataGridUsers.Size = new Size(840, 520);
            dataGridUsers.ReadOnly = true;
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;
            dataGridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabPageUsers.Controls.Add(dataGridUsers);

            // =========================================================
            // TAB 3 — PASSWORD HISTORY GRID
            // =========================================================

            dataGridPasswords = new DataGridView();
            dataGridPasswords.Location = new Point(10, 10);
            dataGridPasswords.Size = new Size(840, 520);
            dataGridPasswords.ReadOnly = true;
            dataGridPasswords.AllowUserToAddRows = false;
            dataGridPasswords.AllowUserToDeleteRows = false;
            dataGridPasswords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabPageHistory.Controls.Add(dataGridPasswords);

            // =========================================================
            // TAB 4 — FILTERS
            // =========================================================

            lblFilterField = new Label();
            lblFilterField.Location = new Point(20, 20);
            lblFilterField.AutoSize = true;
            lblFilterField.Text = "Field:";

            comboFilterField = new ComboBox();
            comboFilterField.Location = new Point(20, 50);
            comboFilterField.Size = new Size(200, 28);
            comboFilterField.Items.AddRange(new string[] {
                "Name", "Email", "Age",
                "Strength", "Length",
                "ContainsUppercase", "ContainsNumbers", "ContainsSymbols"
            });

            lblFilterOp = new Label();
            lblFilterOp.Location = new Point(250, 20);
            lblFilterOp.AutoSize = true;
            lblFilterOp.Text = "Operator:";

            comboFilterOp = new ComboBox();
            comboFilterOp.Location = new Point(250, 50);
            comboFilterOp.Size = new Size(150, 28);
            comboFilterOp.Items.AddRange(new string[] { "=", ">", "<", "Contains" });

            lblFilterValue = new Label();
            lblFilterValue.Location = new Point(420, 20);
            lblFilterValue.AutoSize = true;
            lblFilterValue.Text = "Value:";

            txtFilterValue = new TextBox();
            txtFilterValue.Location = new Point(420, 50);
            txtFilterValue.Size = new Size(200, 27);

            btnApplyFilter = new Button();
            btnApplyFilter.Location = new Point(20, 100);
            btnApplyFilter.Size = new Size(150, 30);
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.Click += btnApplyFilter_Click;

            btnResetFilter = new Button();
            btnResetFilter.Location = new Point(200, 100);
            btnResetFilter.Size = new Size(150, 30);
            btnResetFilter.Text = "Reset Filter";
            btnResetFilter.Click += btnResetFilter_Click;

            tabPageFilters.Controls.Add(lblFilterField);
            tabPageFilters.Controls.Add(comboFilterField);
            tabPageFilters.Controls.Add(lblFilterOp);
            tabPageFilters.Controls.Add(comboFilterOp);
            tabPageFilters.Controls.Add(lblFilterValue);
            tabPageFilters.Controls.Add(txtFilterValue);
            tabPageFilters.Controls.Add(btnApplyFilter);
            tabPageFilters.Controls.Add(btnResetFilter);

            // =============================
            // ADD TO FORM
            // =============================
            Controls.Add(tabControlMain);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPagePassword;
        private TabPage tabPageUsers;
        private TabPage tabPageHistory;
        private TabPage tabPageFilters;

        // TAB 1 Controls
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnGenerate;
        private NumericUpDown numericUpDownLength;
        private CheckBox checkBoxUppercase;
        private CheckBox checkBoxNumbers;
        private CheckBox checkBoxSymbols;
        private Label lblStrength;
        private ProgressBar progressBarStrength;
        private Button buttonCopy;
        private ListBox listHistory;
        private ComboBox comboBoxTheme;
        private NumericUpDown numericUpDownTimeout;
        private Button buttonSavePrefs;
        private Button buttonLoadPrefs;

        // TAB 2 + TAB 3
        private DataGridView dataGridUsers;
        private DataGridView dataGridPasswords;

        // TAB 4 Filters
        private Label lblFilterField;
        private ComboBox comboFilterField;
        private Label lblFilterOp;
        private ComboBox comboFilterOp;
        private Label lblFilterValue;
        private TextBox txtFilterValue;
        private Button btnApplyFilter;
        private Button btnResetFilter;
    }
}
