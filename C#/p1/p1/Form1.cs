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
///P1 Form IO
///01/29/2015
///This program calculates the miles walked according to the number of steps taken and the stride length. 
///It calculates the miles by multiplying the number of steps times the stride length and then converting
///the value into meters. Then, it is converted from meters into miles accordintly to the convertion of 
///1 meter = 0.000621371192 miles.This program also verifies that the text input in the text box is a 
///real number and doesn't contain any letters. In the other hand, it does accept numbers separated 
///by comma and dot like 10,000,000.00. This program also allows the user to commit mistakes entering 
///the data and then continuing using it with any code error by showing messsages when an error is 
///found and by clicking OK it will allow the user to correct the error and continuing using the application
///


namespace p1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            stepsTextBox.Text = "10000";
            inchesTextBox.Text = "29";
            milesTextBox.Text = "0";
            messageTextBox.Text = "";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            float steps = 0;
            float stride = 0;
            float inchToMeters = 0.0254f;
            float meterToMile = 0.000621371192f;
            float miles = 0;
            if (stepsTextBox.Text.ToString() != "" && inchesTextBox.Text.ToString() != "")
            {
                if (float.TryParse(stepsTextBox.Text, out steps) && float.TryParse(inchesTextBox.Text, out stride))
                {
                    float totalInchesInMeters = (steps * stride) * inchToMeters;
                    miles = totalInchesInMeters * meterToMile;
                    //milesTextBox.Text = miles.ToString();
                    milesTextBox.Text = String.Format("{0:#.##}", miles);
                    if (steps < 10000.0f) 
                    {
                        messageTextBox.Text = String.Format("You neet {0:#.##} more steps to reach 10,000", (10000.0f - steps));
                    }
                    else if(steps > 10000.0f)
                    {
                        messageTextBox.Text = String.Format("You walked {0:.##} setps over 10,000", (steps - 10000.0f));
                    }
                    else
                    {
                        messageTextBox.Text = "You walked exactly 10,000 steps";
                    }
                }
                else
                {
                    MessageBox.Show("Only numbers are accepted!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                MessageBox.Show("You are missing some data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
        }
    }
}
