namespace P5
{
    partial class AeroWizardSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AeroWizardSettings));
            this.mainWizardControl = new AeroWizard.WizardControl();
            this.initialStartUpWizardPage = new AeroWizard.WizardPage();
            this.initalStartUpLabel = new System.Windows.Forms.Label();
            this.enableInitialStartupWizardCheckBox = new System.Windows.Forms.CheckBox();
            this.dataManagementWizardPage = new AeroWizard.WizardPage();
            this.dataManagementLabel = new System.Windows.Forms.Label();
            this.loadDataStartUpCheckBox = new System.Windows.Forms.CheckBox();
            this.saveDataExitCheckBox = new System.Windows.Forms.CheckBox();
            this.usersLoginWizardPage = new AeroWizard.WizardPage();
            this.usersLoginLabel = new System.Windows.Forms.Label();
            this.onlyAdminRadioButton = new System.Windows.Forms.RadioButton();
            this.allUsersRadioButton = new System.Windows.Forms.RadioButton();
            this.administratorConfigWizardPage = new AeroWizard.WizardPage();
            this.admiConfigLabel = new System.Windows.Forms.Label();
            this.allowAdminCreationCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultAdminComboBox = new System.Windows.Forms.ComboBox();
            this.defaultAdminPasswordTextBox = new System.Windows.Forms.TextBox();
            this.defaultAdminUsernameTextBox = new System.Windows.Forms.TextBox();
            this.defaultAdminPasswordLabel = new System.Windows.Forms.Label();
            this.defaultAdminUsernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainWizardControl)).BeginInit();
            this.initialStartUpWizardPage.SuspendLayout();
            this.dataManagementWizardPage.SuspendLayout();
            this.usersLoginWizardPage.SuspendLayout();
            this.administratorConfigWizardPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWizardControl
            // 
            this.mainWizardControl.Location = new System.Drawing.Point(0, 0);
            this.mainWizardControl.Name = "mainWizardControl";
            this.mainWizardControl.Pages.Add(this.initialStartUpWizardPage);
            this.mainWizardControl.Pages.Add(this.dataManagementWizardPage);
            this.mainWizardControl.Pages.Add(this.usersLoginWizardPage);
            this.mainWizardControl.Pages.Add(this.administratorConfigWizardPage);
            this.mainWizardControl.Size = new System.Drawing.Size(574, 415);
            this.mainWizardControl.TabIndex = 0;
            this.mainWizardControl.Title = "Main Configuration";
            this.mainWizardControl.Finished += new System.EventHandler(this.mainWizardControl_Finished);
            // 
            // initialStartUpWizardPage
            // 
            this.initialStartUpWizardPage.Controls.Add(this.enableInitialStartupWizardCheckBox);
            this.initialStartUpWizardPage.Controls.Add(this.initalStartUpLabel);
            this.initialStartUpWizardPage.Name = "initialStartUpWizardPage";
            this.initialStartUpWizardPage.Size = new System.Drawing.Size(527, 262);
            this.initialStartUpWizardPage.TabIndex = 0;
            this.initialStartUpWizardPage.Text = "Initial Startup";
            // 
            // initalStartUpLabel
            // 
            this.initalStartUpLabel.AutoSize = true;
            this.initalStartUpLabel.Location = new System.Drawing.Point(3, 33);
            this.initalStartUpLabel.Name = "initalStartUpLabel";
            this.initalStartUpLabel.Size = new System.Drawing.Size(516, 45);
            this.initalStartUpLabel.TabIndex = 0;
            this.initalStartUpLabel.Text = resources.GetString("initalStartUpLabel.Text");
            // 
            // enableInitialStartupWizardCheckBox
            // 
            this.enableInitialStartupWizardCheckBox.AutoSize = true;
            this.enableInitialStartupWizardCheckBox.Location = new System.Drawing.Point(6, 101);
            this.enableInitialStartupWizardCheckBox.Name = "enableInitialStartupWizardCheckBox";
            this.enableInitialStartupWizardCheckBox.Size = new System.Drawing.Size(179, 19);
            this.enableInitialStartupWizardCheckBox.TabIndex = 1;
            this.enableInitialStartupWizardCheckBox.Text = "Enable startup tutorial wizard";
            this.enableInitialStartupWizardCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataManagementWizardPage
            // 
            this.dataManagementWizardPage.Controls.Add(this.saveDataExitCheckBox);
            this.dataManagementWizardPage.Controls.Add(this.loadDataStartUpCheckBox);
            this.dataManagementWizardPage.Controls.Add(this.dataManagementLabel);
            this.dataManagementWizardPage.Name = "dataManagementWizardPage";
            this.dataManagementWizardPage.Size = new System.Drawing.Size(527, 262);
            this.dataManagementWizardPage.TabIndex = 1;
            this.dataManagementWizardPage.Text = "Data Management";
            // 
            // dataManagementLabel
            // 
            this.dataManagementLabel.AutoSize = true;
            this.dataManagementLabel.Location = new System.Drawing.Point(5, 25);
            this.dataManagementLabel.Name = "dataManagementLabel";
            this.dataManagementLabel.Size = new System.Drawing.Size(504, 75);
            this.dataManagementLabel.TabIndex = 0;
            this.dataManagementLabel.Text = resources.GetString("dataManagementLabel.Text");
            // 
            // loadDataStartUpCheckBox
            // 
            this.loadDataStartUpCheckBox.AutoSize = true;
            this.loadDataStartUpCheckBox.Location = new System.Drawing.Point(8, 125);
            this.loadDataStartUpCheckBox.Name = "loadDataStartUpCheckBox";
            this.loadDataStartUpCheckBox.Size = new System.Drawing.Size(205, 19);
            this.loadDataStartUpCheckBox.TabIndex = 1;
            this.loadDataStartUpCheckBox.Text = "Automatically load data at startup";
            this.loadDataStartUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveDataExitCheckBox
            // 
            this.saveDataExitCheckBox.AutoSize = true;
            this.saveDataExitCheckBox.Location = new System.Drawing.Point(8, 151);
            this.saveDataExitCheckBox.Name = "saveDataExitCheckBox";
            this.saveDataExitCheckBox.Size = new System.Drawing.Size(327, 19);
            this.saveDataExitCheckBox.TabIndex = 2;
            this.saveDataExitCheckBox.Text = "Automatically save all the data when the application exits";
            this.saveDataExitCheckBox.UseVisualStyleBackColor = true;
            // 
            // usersLoginWizardPage
            // 
            this.usersLoginWizardPage.Controls.Add(this.allUsersRadioButton);
            this.usersLoginWizardPage.Controls.Add(this.onlyAdminRadioButton);
            this.usersLoginWizardPage.Controls.Add(this.usersLoginLabel);
            this.usersLoginWizardPage.Name = "usersLoginWizardPage";
            this.usersLoginWizardPage.Size = new System.Drawing.Size(527, 262);
            this.usersLoginWizardPage.TabIndex = 2;
            this.usersLoginWizardPage.Text = "Users Login";
            // 
            // usersLoginLabel
            // 
            this.usersLoginLabel.AutoSize = true;
            this.usersLoginLabel.Location = new System.Drawing.Point(14, 29);
            this.usersLoginLabel.Name = "usersLoginLabel";
            this.usersLoginLabel.Size = new System.Drawing.Size(465, 30);
            this.usersLoginLabel.TabIndex = 0;
            this.usersLoginLabel.Text = "By selecting one of this options it will allow only the administrator to login an" +
    "d use the \r\napplication or all the users registered untill the moment of login.";
            // 
            // onlyAdminRadioButton
            // 
            this.onlyAdminRadioButton.AutoSize = true;
            this.onlyAdminRadioButton.Location = new System.Drawing.Point(17, 88);
            this.onlyAdminRadioButton.Name = "onlyAdminRadioButton";
            this.onlyAdminRadioButton.Size = new System.Drawing.Size(154, 19);
            this.onlyAdminRadioButton.TabIndex = 1;
            this.onlyAdminRadioButton.TabStop = true;
            this.onlyAdminRadioButton.Text = "Only administrator login";
            this.onlyAdminRadioButton.UseVisualStyleBackColor = true;
            // 
            // allUsersRadioButton
            // 
            this.allUsersRadioButton.AutoSize = true;
            this.allUsersRadioButton.Location = new System.Drawing.Point(17, 125);
            this.allUsersRadioButton.Name = "allUsersRadioButton";
            this.allUsersRadioButton.Size = new System.Drawing.Size(99, 19);
            this.allUsersRadioButton.TabIndex = 2;
            this.allUsersRadioButton.TabStop = true;
            this.allUsersRadioButton.Text = "All users login";
            this.allUsersRadioButton.UseVisualStyleBackColor = true;
            // 
            // administratorConfigWizardPage
            // 
            this.administratorConfigWizardPage.Controls.Add(this.defaultAdminPasswordTextBox);
            this.administratorConfigWizardPage.Controls.Add(this.defaultAdminUsernameTextBox);
            this.administratorConfigWizardPage.Controls.Add(this.defaultAdminPasswordLabel);
            this.administratorConfigWizardPage.Controls.Add(this.defaultAdminUsernameLabel);
            this.administratorConfigWizardPage.Controls.Add(this.defaultAdminComboBox);
            this.administratorConfigWizardPage.Controls.Add(this.label1);
            this.administratorConfigWizardPage.Controls.Add(this.allowAdminCreationCheckBox);
            this.administratorConfigWizardPage.Controls.Add(this.admiConfigLabel);
            this.administratorConfigWizardPage.Name = "administratorConfigWizardPage";
            this.administratorConfigWizardPage.Size = new System.Drawing.Size(527, 262);
            this.administratorConfigWizardPage.TabIndex = 3;
            this.administratorConfigWizardPage.Text = "Administrator Configuration";
            // 
            // admiConfigLabel
            // 
            this.admiConfigLabel.AutoSize = true;
            this.admiConfigLabel.Location = new System.Drawing.Point(12, 28);
            this.admiConfigLabel.Name = "admiConfigLabel";
            this.admiConfigLabel.Size = new System.Drawing.Size(479, 45);
            this.admiConfigLabel.TabIndex = 0;
            this.admiConfigLabel.Text = resources.GetString("admiConfigLabel.Text");
            // 
            // allowAdminCreationCheckBox
            // 
            this.allowAdminCreationCheckBox.AutoSize = true;
            this.allowAdminCreationCheckBox.Location = new System.Drawing.Point(15, 93);
            this.allowAdminCreationCheckBox.Name = "allowAdminCreationCheckBox";
            this.allowAdminCreationCheckBox.Size = new System.Drawing.Size(181, 19);
            this.allowAdminCreationCheckBox.TabIndex = 1;
            this.allowAdminCreationCheckBox.Text = "Allow administrators creation";
            this.allowAdminCreationCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enable default administrator:";
            // 
            // defaultAdminComboBox
            // 
            this.defaultAdminComboBox.FormattingEnabled = true;
            this.defaultAdminComboBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.defaultAdminComboBox.Location = new System.Drawing.Point(180, 132);
            this.defaultAdminComboBox.Name = "defaultAdminComboBox";
            this.defaultAdminComboBox.Size = new System.Drawing.Size(93, 23);
            this.defaultAdminComboBox.TabIndex = 3;
            this.defaultAdminComboBox.SelectedIndexChanged += new System.EventHandler(this.defaultAdminComboBox_SelectedIndexChanged);
            // 
            // defaultAdminPasswordTextBox
            // 
            this.defaultAdminPasswordTextBox.Location = new System.Drawing.Point(120, 212);
            this.defaultAdminPasswordTextBox.Name = "defaultAdminPasswordTextBox";
            this.defaultAdminPasswordTextBox.PasswordChar = '*';
            this.defaultAdminPasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.defaultAdminPasswordTextBox.TabIndex = 11;
            this.defaultAdminPasswordTextBox.Text = "admin";
            // 
            // defaultAdminUsernameTextBox
            // 
            this.defaultAdminUsernameTextBox.Location = new System.Drawing.Point(120, 176);
            this.defaultAdminUsernameTextBox.Name = "defaultAdminUsernameTextBox";
            this.defaultAdminUsernameTextBox.Size = new System.Drawing.Size(100, 23);
            this.defaultAdminUsernameTextBox.TabIndex = 10;
            this.defaultAdminUsernameTextBox.Text = "admin";
            // 
            // defaultAdminPasswordLabel
            // 
            this.defaultAdminPasswordLabel.AutoSize = true;
            this.defaultAdminPasswordLabel.Location = new System.Drawing.Point(15, 215);
            this.defaultAdminPasswordLabel.Name = "defaultAdminPasswordLabel";
            this.defaultAdminPasswordLabel.Size = new System.Drawing.Size(99, 15);
            this.defaultAdminPasswordLabel.TabIndex = 9;
            this.defaultAdminPasswordLabel.Text = "Admin password:";
            // 
            // defaultAdminUsernameLabel
            // 
            this.defaultAdminUsernameLabel.AutoSize = true;
            this.defaultAdminUsernameLabel.Location = new System.Drawing.Point(15, 179);
            this.defaultAdminUsernameLabel.Name = "defaultAdminUsernameLabel";
            this.defaultAdminUsernameLabel.Size = new System.Drawing.Size(101, 15);
            this.defaultAdminUsernameLabel.TabIndex = 8;
            this.defaultAdminUsernameLabel.Text = "Admin username:";
            // 
            // AeroWizardSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 415);
            this.Controls.Add(this.mainWizardControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AeroWizardSettings";
            ((System.ComponentModel.ISupportInitialize)(this.mainWizardControl)).EndInit();
            this.initialStartUpWizardPage.ResumeLayout(false);
            this.initialStartUpWizardPage.PerformLayout();
            this.dataManagementWizardPage.ResumeLayout(false);
            this.dataManagementWizardPage.PerformLayout();
            this.usersLoginWizardPage.ResumeLayout(false);
            this.usersLoginWizardPage.PerformLayout();
            this.administratorConfigWizardPage.ResumeLayout(false);
            this.administratorConfigWizardPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl mainWizardControl;
        private AeroWizard.WizardPage initialStartUpWizardPage;
        private System.Windows.Forms.CheckBox enableInitialStartupWizardCheckBox;
        private System.Windows.Forms.Label initalStartUpLabel;
        private AeroWizard.WizardPage dataManagementWizardPage;
        private System.Windows.Forms.Label dataManagementLabel;
        private System.Windows.Forms.CheckBox saveDataExitCheckBox;
        private System.Windows.Forms.CheckBox loadDataStartUpCheckBox;
        private AeroWizard.WizardPage usersLoginWizardPage;
        private System.Windows.Forms.RadioButton allUsersRadioButton;
        private System.Windows.Forms.RadioButton onlyAdminRadioButton;
        private System.Windows.Forms.Label usersLoginLabel;
        private AeroWizard.WizardPage administratorConfigWizardPage;
        private System.Windows.Forms.CheckBox allowAdminCreationCheckBox;
        private System.Windows.Forms.Label admiConfigLabel;
        private System.Windows.Forms.ComboBox defaultAdminComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox defaultAdminPasswordTextBox;
        private System.Windows.Forms.TextBox defaultAdminUsernameTextBox;
        private System.Windows.Forms.Label defaultAdminPasswordLabel;
        private System.Windows.Forms.Label defaultAdminUsernameLabel;
    }
}