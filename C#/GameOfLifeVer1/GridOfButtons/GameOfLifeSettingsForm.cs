using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridOfButtons
{
    public partial class GameOfLifeSettingsForm : Form
    {
        GameOfLifeSettings ms;

        public GameOfLifeSettingsForm(GameOfLifeSettings s)
        {
            InitializeComponent();

            ms = s;

            rowTextBox.Text = ms.Rows.ToString();
            colTextBox.Text = ms.Cols.ToString();
            timerTextBox.Text = ms.TimerValue.ToString();


        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ms.Rows = int.Parse(rowTextBox.Text);
            ms.Cols = int.Parse(colTextBox.Text);
            ms.TimerValue = int.Parse(timerTextBox.Text);

            ms.save();
            this.Dispose();
        }

    }//class
}//namespace
