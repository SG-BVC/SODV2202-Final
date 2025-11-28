namespace SODV2202_Final
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPassword = new Label();
            btnGenerate = new Button();
            numericUpDownLength = new NumericUpDown();
            checkBoxUppercase = new CheckBox();
            checkBoxNumbers = new CheckBox();
            checkBoxSymbols = new CheckBox();
            lblStrength = new Label();
            progressBarStrength = new ProgressBar();
            buttonCopy = new Button();
            listHistory = new ListBox();
            comboBoxTheme = new ComboBox();
            numericUpDownTimeout = new NumericUpDown();
            buttonSavePrefs = new Button();
            buttonLoadPrefs = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).BeginInit();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 9);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(143, 20);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Generated Password";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 32);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(94, 29);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click_1;
            // 
            // numericUpDownLength
            // 
            numericUpDownLength.Location = new Point(112, 32);
            numericUpDownLength.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDownLength.Name = "numericUpDownLength";
            numericUpDownLength.Size = new Size(150, 27);
            numericUpDownLength.TabIndex = 2;
            // 
            // checkBoxUppercase
            // 
            checkBoxUppercase.AutoSize = true;
            checkBoxUppercase.Location = new Point(282, 8);
            checkBoxUppercase.Name = "checkBoxUppercase";
            checkBoxUppercase.Size = new Size(101, 24);
            checkBoxUppercase.TabIndex = 3;
            checkBoxUppercase.Text = "Uppercase";
            checkBoxUppercase.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumbers
            // 
            checkBoxNumbers.AutoSize = true;
            checkBoxNumbers.Location = new Point(282, 35);
            checkBoxNumbers.Name = "checkBoxNumbers";
            checkBoxNumbers.Size = new Size(91, 24);
            checkBoxNumbers.TabIndex = 4;
            checkBoxNumbers.Text = "Numbers";
            checkBoxNumbers.UseVisualStyleBackColor = true;
            // 
            // checkBoxSymbols
            // 
            checkBoxSymbols.AutoSize = true;
            checkBoxSymbols.Location = new Point(282, 62);
            checkBoxSymbols.Name = "checkBoxSymbols";
            checkBoxSymbols.Size = new Size(87, 24);
            checkBoxSymbols.TabIndex = 5;
            checkBoxSymbols.Text = "Symbols";
            checkBoxSymbols.UseVisualStyleBackColor = true;
            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Location = new Point(417, 9);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(50, 20);
            lblStrength.TabIndex = 6;
            lblStrength.Text = "label1";
            // 
            // progressBarStrength
            // 
            progressBarStrength.Location = new Point(417, 32);
            progressBarStrength.Name = "progressBarStrength";
            progressBarStrength.Size = new Size(371, 29);
            progressBarStrength.TabIndex = 7;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(417, 67);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(94, 29);
            buttonCopy.TabIndex = 8;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // listHistory
            // 
            listHistory.FormattingEnabled = true;
            listHistory.Location = new Point(417, 102);
            listHistory.Name = "listHistory";
            listHistory.Size = new Size(371, 344);
            listHistory.TabIndex = 9;
            // 
            // comboBoxTheme
            // 
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.Location = new Point(12, 67);
            comboBoxTheme.Name = "comboBoxTheme";
            comboBoxTheme.Size = new Size(151, 28);
            comboBoxTheme.TabIndex = 10;
            comboBoxTheme.Items.Add("Light");
            comboBoxTheme.Items.Add("Dark");
            comboBoxTheme.SelectedIndexChanged += comboBoxTheme_SelectedIndexChanged;
            // 
            // numericUpDownTimeout
            // 
            numericUpDownTimeout.Location = new Point(12, 102);
            numericUpDownTimeout.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownTimeout.Name = "numericUpDownTimeout";
            numericUpDownTimeout.Size = new Size(53, 27);
            numericUpDownTimeout.TabIndex = 11;
            // 
            // buttonSavePrefs
            // 
            buttonSavePrefs.Location = new Point(12, 409);
            buttonSavePrefs.Name = "buttonSavePrefs";
            buttonSavePrefs.Size = new Size(143, 29);
            buttonSavePrefs.TabIndex = 12;
            buttonSavePrefs.Text = "Save Preferences";
            buttonSavePrefs.UseVisualStyleBackColor = true;
            buttonSavePrefs.Click += buttonSavePrefs_Click;
            // 
            // buttonLoadPrefs
            // 
            buttonLoadPrefs.Location = new Point(12, 374);
            buttonLoadPrefs.Name = "buttonLoadPrefs";
            buttonLoadPrefs.Size = new Size(143, 29);
            buttonLoadPrefs.TabIndex = 13;
            buttonLoadPrefs.Text = "Load Preferences";
            buttonLoadPrefs.UseVisualStyleBackColor = true;
            buttonLoadPrefs.Click += buttonLoadPrefs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLoadPrefs);
            Controls.Add(buttonSavePrefs);
            Controls.Add(numericUpDownTimeout);
            Controls.Add(comboBoxTheme);
            Controls.Add(listHistory);
            Controls.Add(buttonCopy);
            Controls.Add(progressBarStrength);
            Controls.Add(lblStrength);
            Controls.Add(checkBoxSymbols);
            Controls.Add(checkBoxNumbers);
            Controls.Add(checkBoxUppercase);
            Controls.Add(numericUpDownLength);
            Controls.Add(btnGenerate);
            Controls.Add(lblPassword);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
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
    }
}
