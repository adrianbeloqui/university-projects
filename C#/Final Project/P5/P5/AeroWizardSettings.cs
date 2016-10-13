using System;
using System.Collections;
using System.Windows.Forms;
using Entities;

namespace P5
{
    public partial class AeroWizardSettings : Form
    {
        private Settings settings;

        public AeroWizardSettings(ref Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            defaultAdminUsernameLabel.Visible = false;
            defaultAdminUsernameTextBox.Visible = false;
            defaultAdminPasswordLabel.Visible = false;
            defaultAdminPasswordTextBox.Visible = false;
        }

        private void mainWizardControl_Finished(object sender, EventArgs e)
        {
            settings.Tutorial = enableInitialStartupWizardCheckBox.Checked;
            settings.LoadFiles = loadDataStartUpCheckBox.Checked;
            settings.AutomaticSave = saveDataExitCheckBox.Checked;
            settings.AllUsersLogin = allUsersRadioButton.Checked;
            settings.OnlyAdminLogin = onlyAdminRadioButton.Checked;
            settings.AllowAdminsCreation = allowAdminCreationCheckBox.Checked;
            if (defaultAdminComboBox.SelectedItem == "Yes")
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
            settingsData.Add(settings.Tutorial.ToString());
            settingsData.Add(settings.LoadFiles.ToString());
            settingsData.Add(settings.AutomaticSave.ToString());
            settingsData.Add(settings.AllUsersLogin.ToString());
            settingsData.Add(settings.OnlyAdminLogin.ToString());
            settingsData.Add(settings.AllowAdminsCreation.ToString());
            settingsData.Add(settings.BasicUserAdmin.ToString());
            settingsData.Add(settings.BasicUserAdminName.ToString());
            settingsData.Add(settings.BasicUserAdminPassword.ToString());

            Logic.Intermediary.ApplySettings(settingsData);

            this.Close();
        }

        private void defaultAdminComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (defaultAdminComboBox.SelectedItem == "Yes")
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
    }
}
