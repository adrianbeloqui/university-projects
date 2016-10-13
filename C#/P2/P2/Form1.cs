using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

///Adrian Beloqui
///P2 Loops
///02/3/2015
///This program calculates all the possible ways of change that can be made for any amount entered. 
///This program uses the most common types of loops: for, foreach, while and while/do. It has a separate
///method that creates a list accordingly to the pennies entered in the GUI so the foreach loop type can
///be done. It also has a method that is in charge of filling the listbox, this method was done to avoid
///writing the same instructions in one method due to some conditions introduced in the code to improve the users
///experience.
///

namespace P2
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        static List<int> CreateListOfPennies(int penniesEntered)
        {
            List<int> Pennies = new List<int>();
            for (int i = 0; i <= penniesEntered; i++)
            {
                Pennies.Add(i);
            }
            return Pennies;
        }  

        private void clearButton_Click(object sender, EventArgs e)
        {
            mainListBox.Items.Clear();
            maximumTextBox.Text = "";
            totalLabel.Text = "";
        }

        private void FillListBox(int penniesEntered, int totalOptions)
        {
            List<int> PenniesList = CreateListOfPennies(penniesEntered);
            for (int ones = 0; ones <= (int)penniesEntered / 100; ones++)
            {
                for (int helves = 0; helves <= (int)penniesEntered / 50; helves++)
                {
                    for (int quarter = 0; quarter <= (int)penniesEntered / 25; quarter++)
                    {
                        int dine = 0;
                        while (dine <= (int)penniesEntered / 10)
                        {
                            int nickel = 0;
                            do
                            {
                                foreach (int penny in PenniesList)
                                {
                                    if (ones * 100 + helves * 50 + quarter * 25 + dine * 10 + nickel * 5 + penny == penniesEntered)
                                    {
                                        totalOptions += 1;
                                        mainListBox.Items.Add(string.Format("{0}: ones:{1} halves:{2} quarters:{3} dines:{4} nickels:{5} pennies:{6}", totalOptions, ones, helves, quarter, dine, nickel, penny));
                                    }
                                }
                                nickel++;
                            }
                            while (nickel <= (int)penniesEntered / 5);
                            dine++;
                        }
                    }
                }
            }
            totalLabel.Text = totalOptions.ToString();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            mainListBox.Items.Clear();
            int totalOptions = 0;
            int penniesEntered = 0;
            if (maximumTextBox.Text.ToString() != "")
            {
                if (int.TryParse(maximumTextBox.Text, out penniesEntered))
                {
                    if (penniesEntered > 100)
                    {
                        DialogResult result = MessageBox.Show("The amount you entered is greater than 100 so it can take a few minutes to process your result.", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            FillListBox(penniesEntered,totalOptions);
                        }

                    }
                    if (penniesEntered <= 100)
                    {
                        FillListBox(penniesEntered, totalOptions);
                    }
                }
                else
                {
                    MessageBox.Show("Only numbers are accepted!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You are missing some data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}