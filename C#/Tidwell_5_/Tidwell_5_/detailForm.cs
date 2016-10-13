using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tidwell_5_
{
    public partial class detailForm : Form
    {
        int item;
        VehiclesList vehiclesList;

        public detailForm(int i , VehiclesList vehiclesList)
        {
            InitializeComponent();
            item = i;
            this.vehiclesList = vehiclesList;

            this.Text += vehiclesList.get(i).Brand + " " + vehiclesList.get(i).Model;

            brandTextBox.Text = vehiclesList.get(i).Brand;
            modelTextBox.Text = vehiclesList.get(i).Model;
            plateTextBox.Text = vehiclesList.get(i).PlateNumber;
            typeTextBox.Text = vehiclesList.get(i).Type;
        }

        public detailForm(VehiclesList vehiclesList)
        {
            InitializeComponent();
            this.Text = "New Vehicle";
            deleteButton.Visible = false;
            item = -1;
            this.vehiclesList = vehiclesList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (item >= 0)
            {
                vehiclesList.get(item).Brand = brandTextBox.Text;
                vehiclesList.get(item).Model = modelTextBox.Text;
                vehiclesList.get(item).PlateNumber = plateTextBox.Text;
                vehiclesList.get(item).Type = typeTextBox.Text;

                this.Dispose();
            }
            else
            {
                vehiclesList.add(new Vehicle(brandTextBox.Text, modelTextBox.Text, plateTextBox.Text, typeTextBox.Text));
                this.Dispose();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Vehicle removeVehicle = vehiclesList.get(item);
            vehiclesList.remove(removeVehicle);
            this.Dispose();
        }
    }
}
