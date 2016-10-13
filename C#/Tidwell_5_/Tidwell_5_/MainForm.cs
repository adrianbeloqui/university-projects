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
    public partial class mainForm : Form
    {
        int count;
        private VehiclesList vehiclesList;

        public mainForm()
        {
            InitializeComponent();
            initialData();
        }

        public void initialData()
        {
            vehiclesList = new VehiclesList();
            vehiclesList.add(new Vehicle("Mercedes Benz", "Class A 200", "560-IWG", "Car"));
            vehiclesList.add(new Vehicle("Ferrari", "488 GTB", "UQH-95A", "Car"));
            vehiclesList.add(new Vehicle("Kawasaki", "Ninja", "VIC-560", "Motorcycle"));

            int id = 0;
            for (int i = 0; i < vehiclesList.Count; i++)
            { 
                mainListBox.Items.Add(vehiclesList.get(i).PlateNumber + " - " + vehiclesList.get(i).Brand + " " + vehiclesList.get(i).Model);
                vehiclesList.get(i).Id = id;
                id++;
            }
        }

        public void updateListBox()
        {
            mainListBox.Items.Clear();

            int id = 0;
            for (int i = 0; i < vehiclesList.Count; i++)
            {
                mainListBox.Items.Add(vehiclesList.get(i).PlateNumber + " - " + vehiclesList.get(i).Brand + " " + vehiclesList.get(i).Model);
                vehiclesList.get(i).Id = id;
                id++;
            }

        }

        private void ascButton_Click(object sender, EventArgs e)
        {
            vehiclesList.sortAsc();
            updateListBox();
        }

        private void descButton_Click(object sender, EventArgs e)
        {
            vehiclesList.sortDesc();
            updateListBox();
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = mainListBox.SelectedIndex;

            detailForm temp = new detailForm(i, vehiclesList);
            temp.ShowDialog();

            updateListBox();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            detailForm newItem = new detailForm(vehiclesList);
            newItem.ShowDialog();
            updateListBox();
        }
    }
}
