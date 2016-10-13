using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace P5
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        mainForm mainForm;
        loginForm loginForm;

        public SettingsForm(ref Settings settings, ref mainForm main, ref loginForm login)
        {
            InitializeComponent();
            defaultAdminUsernameLabel.Visible = false;
            defaultAdminUsernameTextBox.Visible = false;
            defaultAdminPasswordLabel.Visible = false;
            defaultAdminPasswordTextBox.Visible = false;
            this.mainForm = main;
            this.loginForm = login;
            //ApplyButton.Select();
            CloseButton.Select();
            this.settings = settings;
            LoadDataToElements();
        }

        private void LoadDataToElements()
        {
            loadFilesCheckBox.Checked = settings.LoadFiles;
            automaticSaveCheckBox.Checked = settings.AutomaticSave;
            allUsersRadioButton.Checked = settings.AllUsersLogin;
            onlyAdminRadioButton.Checked = settings.OnlyAdminLogin;
            allowAdminsCreationCheckBox.Checked = settings.AllowAdminsCreation;
            if (settings.BasicUserAdmin == true)
            {
                allowDefaultAdminComboBox.SelectedItem = "Yes";
                
            }
            else
            {
                allowDefaultAdminComboBox.SelectedItem = "No";
            }
            defaultAdminUsernameTextBox.Text = settings.BasicUserAdminName;
            defaultAdminPasswordTextBox.Text = settings.BasicUserAdminPassword;
        }

        private void allowDefaultAdminComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowDefaultAdminComboBox.SelectedItem == "Yes")
            {
                defaultAdminUsernameLabel.Visible = true;
                defaultAdminUsernameTextBox.Visible = true;
                defaultAdminPasswordLabel.Visible = true;
                defaultAdminPasswordTextBox.Visible = true;
            }
            else
            {
                defaultAdminUsernameLabel.Visible = false;
                defaultAdminUsernameTextBox.Visible = false;
                defaultAdminPasswordLabel.Visible = false;
                defaultAdminPasswordTextBox.Visible = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            settings.LoadFiles = loadFilesCheckBox.Checked;
            settings.AutomaticSave = automaticSaveCheckBox.Checked;
            settings.AllUsersLogin = allUsersRadioButton.Checked;
            settings.OnlyAdminLogin = onlyAdminRadioButton.Checked;
            settings.AllowAdminsCreation = allowAdminsCreationCheckBox.Checked;
            if (allowDefaultAdminComboBox.SelectedItem == "Yes")
            {
                settings.BasicUserAdmin = true;
            }
            else
            {
                settings.BasicUserAdmin = false;
            }
            settings.BasicUserAdminName = defaultAdminUsernameTextBox.Text;
            settings.BasicUserAdminPassword = defaultAdminPasswordTextBox.Text;

            ArrayList settingsData = new ArrayList();
            settingsData.Add(settings.LoadFiles.ToString());
            settingsData.Add(settings.AutomaticSave.ToString());
            settingsData.Add(settings.AllUsersLogin.ToString());
            settingsData.Add(settings.OnlyAdminLogin.ToString());
            settingsData.Add(settings.AllowAdminsCreation.ToString());
            settingsData.Add(settings.BasicUserAdmin.ToString());
            settingsData.Add(settings.BasicUserAdminName.ToString());
            settingsData.Add(settings.BasicUserAdminPassword.ToString());

            Logic.Intermediary.ApplySettings(settingsData);

            this.Dispose();
            mainForm.Dispose();
            loginForm.Visible = true;

        }

    }
}
