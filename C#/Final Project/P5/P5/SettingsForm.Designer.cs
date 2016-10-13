namespace P5
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manageDataGroupBox = new System.Windows.Forms.GroupBox();
            this.loadFilesLabel = new System.Windows.Forms.Label();
            this.automaticSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.loadFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.administratorGroupBox = new System.Windows.Forms.GroupBox();
            this.allowAdminsCreationCheckBox = new System.Windows.Forms.CheckBox();
            this.allowAdminsCreationLabel = new System.Windows.Forms.Label();
            this.defaultAdminPasswordTextBox = new System.Windows.Forms.TextBox();
            this.defaultAdminUsernameTextBox = new System.Windows.Forms.TextBox();
            this.defaultAdminPasswordLabel = new System.Windows.Forms.Label();
            this.defaultAdminUsernameLabel = new System.Windows.Forms.Label();
            this.allowDefaultAdminComboBox = new System.Windows.Forms.ComboBox();
            this.allowDefaultAdminLabel = new System.Windows.Forms.Label();
            this.loginUsersGroupBox = new System.Windows.Forms.GroupBox();
            this.onlyAdminRadioButton = new System.Windows.Forms.RadioButton();
            this.allUsersRadioButton = new System.Windows.Forms.RadioButton();
            this.onlyAdminLabel = new System.Windows.Forms.Label();
            this.allUsersLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.manageDataGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.administratorGroupBox.SuspendLayout();
            this.loginUsersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manageDataGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manageDataGroupBox
            // 
            this.manageDataGroupBox.Controls.Add(this.loadFilesLabel);
            this.manageDataGroupBox.Controls.Add(this.automaticSaveCheckBox);
            this.manageDataGroupBox.Controls.Add(this.loadFilesCheckBox);
            this.manageDataGroupBox.Controls.Add(this.label1);
            this.manageDataGroupBox.Location = new System.Drawing.Point(6, 29);
            this.manageDataGroupBox.Name = "manageDataGroupBox";
            this.manageDataGroupBox.Size = new System.Drawing.Size(263, 100);
            this.manageDataGroupBox.TabIndex = 4;
            this.manageDataGroupBox.TabStop = false;
            this.manageDataGroupBox.Text = "Manage Data";
            // 
            // loadFilesLabel
            // 
            this.loadFilesLabel.AutoSize = true;
            this.loadFilesLabel.Location = new System.Drawing.Point(26, 29);
            this.loadFilesLabel.Name = "loadFilesLabel";
            this.loadFilesLabel.Size = new System.Drawing.Size(93, 13);
            this.loadFilesLabel.TabIndex = 0;
            this.loadFilesLabel.Text = "Load data at start:";
            // 
            // automaticSaveCheckBox
            // 
            this.automaticSaveCheckBox.AutoSize = true;
            this.automaticSaveCheckBox.Location = new System.Drawing.Point(163, 64);
            this.automaticSaveCheckBox.Name = "automaticSaveCheckBox";
            this.automaticSaveCheckBox.Size = new System.Drawing.Size(15, 14);
            this.automaticSaveCheckBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.automaticSaveCheckBox, "Automatically save the information of the program to the database.");
            this.automaticSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadFilesCheckBox
            // 
            this.loadFilesCheckBox.AutoSize = true;
            this.loadFilesCheckBox.Location = new System.Drawing.Point(125, 29);
            this.loadFilesCheckBox.Name = "loadFilesCheckBox";
            this.loadFilesCheckBox.Size = new System.Drawing.Size(15, 14);
            this.loadFilesCheckBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.loadFilesCheckBox, "Automatically load the data from the database when the program starts.");
            this.loadFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Automatic save when exit:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.administratorGroupBox);
            this.tabPage2.Controls.Add(this.loginUsersGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // administratorGroupBox
            // 
            this.administratorGroupBox.Controls.Add(this.allowAdminsCreationCheckBox);
            this.administratorGroupBox.Controls.Add(this.allowAdminsCreationLabel);
            this.administratorGroupBox.Controls.Add(this.defaultAdminPasswordTextBox);
            this.administratorGroupBox.Controls.Add(this.defaultAdminUsernameTextBox);
            this.administratorGroupBox.Controls.Add(this.defaultAdminPasswordLabel);
            this.administratorGroupBox.Controls.Add(this.defaultAdminUsernameLabel);
            this.administratorGroupBox.Controls.Add(this.allowDefaultAdminComboBox);
            this.administratorGroupBox.Controls.Add(this.allowDefaultAdminLabel);
            this.administratorGroupBox.Location = new System.Drawing.Point(6, 100);
            this.administratorGroupBox.Name = "administratorGroupBox";
            this.administratorGroupBox.Size = new System.Drawing.Size(263, 177);
            this.administratorGroupBox.TabIndex = 1;
            this.administratorGroupBox.TabStop = false;
            this.administratorGroupBox.Text = "Administrator";
            // 
            // allowAdminsCreationCheckBox
            // 
            this.allowAdminsCreationCheckBox.AutoSize = true;
            this.allowAdminsCreationCheckBox.Location = new System.Drawing.Point(129, 30);
            this.allowAdminsCreationCheckBox.Name = "allowAdminsCreationCheckBox";
            this.allowAdminsCreationCheckBox.Size = new System.Drawing.Size(15, 14);
            this.allowAdminsCreationCheckBox.TabIndex = 4;
            this.allowAdminsCreationCheckBox.UseVisualStyleBackColor = true;
            // 
            // allowAdminsCreationLabel
            // 
            this.allowAdminsCreationLabel.AutoSize = true;
            this.allowAdminsCreationLabel.Location = new System.Drawing.Point(11, 30);
            this.allowAdminsCreationLabel.Name = "allowAdminsCreationLabel";
            this.allowAdminsCreationLabel.Size = new System.Drawing.Size(112, 13);
            this.allowAdminsCreationLabel.TabIndex = 6;
            this.allowAdminsCreationLabel.Text = "Allow admins creation:";
            // 
            // defaultAdminPasswordTextBox
            // 
            this.defaultAdminPasswordTextBox.Location = new System.Drawing.Point(104, 132);
            this.defaultAdminPasswordTextBox.Name = "defaultAdminPasswordTextBox";
            this.defaultAdminPasswordTextBox.PasswordChar = '*';
            this.defaultAdminPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.defaultAdminPasswordTextBox.TabIndex = 7;
            this.defaultAdminPasswordTextBox.Text = "admin";
            // 
            // defaultAdminUsernameTextBox
            // 
            this.defaultAdminUsernameTextBox.Location = new System.Drawing.Point(105, 96);
            this.defaultAdminUsernameTextBox.Name = "defaultAdminUsernameTextBox";
            this.defaultAdminUsernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.defaultAdminUsernameTextBox.TabIndex = 6;
            this.defaultAdminUsernameTextBox.Text = "admin";
            // 
            // defaultAdminPasswordLabel
            // 
            this.defaultAdminPasswordLabel.AutoSize = true;
            this.defaultAdminPasswordLabel.Location = new System.Drawing.Point(11, 135);
            this.defaultAdminPasswordLabel.Name = "defaultAdminPasswordLabel";
            this.defaultAdminPasswordLabel.Size = new System.Drawing.Size(87, 13);
            this.defaultAdminPasswordLabel.TabIndex = 3;
            this.defaultAdminPasswordLabel.Text = "Admin password:";
            // 
            // defaultAdminUsernameLabel
            // 
            this.defaultAdminUsernameLabel.AutoSize = true;
            this.defaultAdminUsernameLabel.Location = new System.Drawing.Point(11, 99);
            this.defaultAdminUsernameLabel.Name = "defaultAdminUsernameLabel";
            this.defaultAdminUsernameLabel.Size = new System.Drawing.Size(88, 13);
            this.defaultAdminUsernameLabel.TabIndex = 2;
            this.defaultAdminUsernameLabel.Text = "Admin username:";
            // 
            // allowDefaultAdminComboBox
            // 
            this.allowDefaultAdminComboBox.FormattingEnabled = true;
            this.allowDefaultAdminComboBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.allowDefaultAdminComboBox.Location = new System.Drawing.Point(118, 59);
            this.allowDefaultAdminComboBox.Name = "allowDefaultAdminComboBox";
            this.allowDefaultAdminComboBox.Size = new System.Drawing.Size(66, 21);
            this.allowDefaultAdminComboBox.TabIndex = 5;
            this.allowDefaultAdminComboBox.SelectedIndexChanged += new System.EventHandler(this.allowDefaultAdminComboBox_SelectedIndexChanged);
            // 
            // allowDefaultAdminLabel
            // 
            this.allowDefaultAdminLabel.AutoSize = true;
            this.allowDefaultAdminLabel.Location = new System.Drawing.Point(11, 62);
            this.allowDefaultAdminLabel.Name = "allowDefaultAdminLabel";
            this.allowDefaultAdminLabel.Size = new System.Drawing.Size(101, 13);
            this.allowDefaultAdminLabel.TabIndex = 0;
            this.allowDefaultAdminLabel.Text = "Allow default admin:";
            // 
            // loginUsersGroupBox
            // 
            this.loginUsersGroupBox.Controls.Add(this.onlyAdminRadioButton);
            this.loginUsersGroupBox.Controls.Add(this.allUsersRadioButton);
            this.loginUsersGroupBox.Controls.Add(this.onlyAdminLabel);
            this.loginUsersGroupBox.Controls.Add(this.allUsersLabel);
            this.loginUsersGroupBox.Location = new System.Drawing.Point(6, 17);
            this.loginUsersGroupBox.Name = "loginUsersGroupBox";
            this.loginUsersGroupBox.Size = new System.Drawing.Size(263, 76);
            this.loginUsersGroupBox.TabIndex = 0;
            this.loginUsersGroupBox.TabStop = false;
            this.loginUsersGroupBox.Text = "Login";
            // 
            // onlyAdminRadioButton
            // 
            this.onlyAdminRadioButton.AutoSize = true;
            this.onlyAdminRadioButton.Location = new System.Drawing.Point(76, 51);
            this.onlyAdminRadioButton.Name = "onlyAdminRadioButton";
            this.onlyAdminRadioButton.Size = new System.Drawing.Size(14, 13);
            this.onlyAdminRadioButton.TabIndex = 3;
            this.onlyAdminRadioButton.TabStop = true;
            this.onlyAdminRadioButton.UseVisualStyleBackColor = true;
            // 
            // allUsersRadioButton
            // 
            this.allUsersRadioButton.AutoSize = true;
            this.allUsersRadioButton.Location = new System.Drawing.Point(76, 22);
            this.allUsersRadioButton.Name = "allUsersRadioButton";
            this.allUsersRadioButton.Size = new System.Drawing.Size(14, 13);
            this.allUsersRadioButton.TabIndex = 2;
            this.allUsersRadioButton.TabStop = true;
            this.allUsersRadioButton.UseVisualStyleBackColor = true;
            // 
            // onlyAdminLabel
            // 
            this.onlyAdminLabel.AutoSize = true;
            this.onlyAdminLabel.Location = new System.Drawing.Point(7, 50);
            this.onlyAdminLabel.Name = "onlyAdminLabel";
            this.onlyAdminLabel.Size = new System.Drawing.Size(62, 13);
            this.onlyAdminLabel.TabIndex = 1;
            this.onlyAdminLabel.Text = "Only admin:";
            // 
            // allUsersLabel
            // 
            this.allUsersLabel.AutoSize = true;
            this.allUsersLabel.Location = new System.Drawing.Point(20, 21);
            this.allUsersLabel.Name = "allUsersLabel";
            this.allUsersLabel.Size = new System.Drawing.Size(49, 13);
            this.allUsersLabel.TabIndex = 0;
            this.allUsersLabel.Text = "All users:";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(209, 327);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(86, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply && Exit";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 327);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 362);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.manageDataGroupBox.ResumeLayout(false);
            this.manageDataGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.administratorGroupBox.ResumeLayout(false);
            this.administratorGroupBox.PerformLayout();
            this.loginUsersGroupBox.ResumeLayout(false);
            this.loginUsersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox loadFilesCheckBox;
        private System.Windows.Forms.Label loadFilesLabel;
        private System.Windows.Forms.CheckBox automaticSaveCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox loginUsersGroupBox;
        private System.Windows.Forms.RadioButton onlyAdminRadioButton;
        private System.Windows.Forms.RadioButton allUsersRadioButton;
        private System.Windows.Forms.Label onlyAdminLabel;
        private System.Windows.Forms.Label allUsersLabel;
        private System.Windows.Forms.GroupBox administratorGroupBox;
        private System.Windows.Forms.ComboBox allowDefaultAdminComboBox;
        private System.Windows.Forms.Label allowDefaultAdminLabel;
        private System.Windows.Forms.GroupBox manageDataGroupBox;
        private System.Windows.Forms.TextBox defaultAdminPasswordTextBox;
        private System.Windows.Forms.TextBox defaultAdminUsernameTextBox;
        private System.Windows.Forms.Label defaultAdminPasswordLabel;
        private System.Windows.Forms.Label defaultAdminUsernameLabel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox allowAdminsCreationCheckBox;
        private System.Windows.Forms.Label allowAdminsCreationLabel;
    }
}