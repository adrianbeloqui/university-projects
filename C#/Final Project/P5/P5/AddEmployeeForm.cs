using System;
using System.Collections.Generic;
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
    public partial class AddEmployeeForm : Form
    {
        private Administration administration;
        public AddEmployeeForm(ref Administration administration)
        {
            InitializeComponent();
            this.administration = administration;
        }

        private void createNewEmployeeButton_Click(object sender, EventArgs e)
        {

            if (newEmployeeSSNTextBox.Text != "")
            {
                int cedula;
                bool siSePuede = int.TryParse(newEmployeeSSNTextBox.Text.ToString(), out cedula);
                if (siSePuede == true)
                {

                    bool noExiste = true;
                    foreach (Entities.People.Employee emp in administration.Employees)
                    {
                        if (emp.Ssn == cedula)
                        {
                            noExiste = false;
                        }
                    }
                    if (noExiste == true)
                    {
                        if (newEmployeePositionComboBox.SelectedItem.ToString() == "Driver") 
                        {
                            Entities.People.Employee chofer = new Entities.People.Driver(newEmployeeNameTextBox.Text, newEmployeeLastNameTextBox.Text, cedula, newEmployeeNationalityTextBox.Text, newEmployeeSexComboBox.SelectedItem.ToString(), newEmployeeBirthDateDateTimePicker.Value, newEmployeePositionComboBox.SelectedItem.ToString());
                            MessageBox.Show("The new driver was created!", "Done", MessageBoxButtons.OK);
                            administration.AddEmployee(chofer);
                        }
                        if (newEmployeePositionComboBox.SelectedItem.ToString() == "Administrator")
                        {
                            Entities.People.Employee administrativo = new Entities.People.Administrator(newEmployeeNameTextBox.Text, newEmployeeLastNameTextBox.Text, cedula, newEmployeeNationalityTextBox.Text, newEmployeeSexComboBox.SelectedItem.ToString(), newEmployeeBirthDateDateTimePicker.Value, newEmployeePositionComboBox.SelectedItem.ToString());
                            MessageBox.Show("The new administrator was created!", "Done", MessageBoxButtons.OK);
                            administration.AddEmployee(administrativo);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An employee with this SSN was already created");
                    }
                }
                else
                {
                    MessageBox.Show("What you entered for the SSN is not a number");
                }
            }
            else
            {
                MessageBox.Show("The SSN field cannot be empty");
            }
        }

    }
}
