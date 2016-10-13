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
    public partial class AddVehicleForm : Form
    {
        private Administration administration;
        public AddVehicleForm(ref Administration administration)
        {
            InitializeComponent();
            this.administration = administration;
        }

        private void newVehicleCreateButton_Click(object sender, EventArgs e)
        {

            if (newVehicleBrandTextBox.Text != "" && newVehicleModelTextBox.Text != "" && newVehiclePlateNumberTextBox.Text != "" && newVehicleTypeComboBox.SelectedItem != null)
            {
                Entities.Vehicles.Vehicle vehi = new Entities.Vehicles.Car(newVehicleBrandTextBox.Text, newVehicleModelTextBox.Text, newVehiclePlateNumberTextBox.Text, newVehicleTypeComboBox.SelectedItem.ToString());
                administration.AddVehicle(vehi);
                MessageBox.Show("The new vehicle was created!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("All the fields should be completed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
