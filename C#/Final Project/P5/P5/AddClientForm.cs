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
    public partial class AddClientForm : Form
    {
        private Administration administration;
        public AddClientForm(ref Administration administration)
        {
            InitializeComponent();
            this.administration = administration;
        }

        private void createNewClientButton_Click(object sender, EventArgs e)
        {
            if (newClientSSNTextBox.Text != "")
            {
                int cedula;
                bool sePuede = int.TryParse(newClientSSNTextBox.Text.ToString(), out cedula);
                if (sePuede == true)
                {

                    bool noExiste = true;
                    foreach (Entities.People.Person p in administration.Clients)
                    {
                        if (p.Ssn == cedula)
                        {
                            noExiste = false;
                        }
                    }
                    if (noExiste == true)
                    {
                        DateTime fechNac = birthDateDateTimePicker.Value;
                        Entities.People.Person cliente = new Entities.People.Client(newClientNameTextBox.Text, newClientLastNameTextBox.Text, cedula, newClientNationalityTextBox.Text, newClientSexComboBox.SelectedItem.ToString(), fechNac);
                        MessageBox.Show("The new client was created!", "Congratulations!", MessageBoxButtons.OK);
                        administration.AddClient(cliente);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A client with this SSN was already created");
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
