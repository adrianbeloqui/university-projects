using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                            "Here there is going to be a new form " +
                            "that allows to load all the data needed " + 
                            "for the program to work so the user do " +
                            "not lose all the data once it closes " + 
                            "the application.", "In development stage...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                            "This function will allow to save all " +
                            "the data from all the forms into separated " +
                            "files in order to be able to open them in " +
                            "the future and not lose all the data of " +
                            "the application.", "In development stage...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                            "This function will allow the user " +
                            "to create a new client for the company.", "In development stage...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                            "This function will allow the user " +
                            "to create a new employee for the " +
                            "company.", "In development stage...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                           "This function will allow the user " +
                           "to create a new vehicle for the " +
                           "company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void createDrivingClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                           "This function will allow the user " +
                           "to create a new driving class for the " +
                           "company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void seeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                           "This function will allow the user " +
                           "to see all the current adminstrators " +
                           "in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void createAdminstratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to add a new adminstrator to " +
                           "the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void searchClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                           "This function will allow the user " +
                           "to list all the clients and search " +
                           "for a sepecific client of the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void importToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                          "This function will allow the user " +
                          "to import a list of clients to the " +
                          "program from a .txt file.", "In development stage...", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void exportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                          "This function will allow the user " +
                          "to export all the clients of the " +
                          "company to a .txt file.", "In development stage...", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void allEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the current employees " +
                           "in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void dirversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the current employees " +
                           "that are drivers in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void inactiveDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the inactive dirvers " +
                           "that are inactive for any reason " +
                           "in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void possibleDirversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to track all the drivers that are " +
                           "interested in working in the company", "In development stage...", 
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void listAllVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the vehicles that " +
                           "are in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +
                          "This function will allow the user " +
                          "to import a list of vehicles to the " +
                          "program from a .txt file.", "In development stage...", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                          "This function will allow the user " +
                          "to export all the vehicles of the " +
                          "company to a .txt file.", "In development stage...", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the driving classes (- 50) that " +
                           "are happening in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void classes50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " + 
                           "This function will allow the user " +
                           "to see all the driving classes (+ 50) that " +
                           "are happening in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void classesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function to be added: " +  
                           "This function will allow the user " +
                           "to see all the driving classes that " +
                           "finished in the company.", "In development stage...", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }
    }
}
