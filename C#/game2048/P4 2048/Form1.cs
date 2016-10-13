using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_2048
{
    public partial class mainForm : Form
    {
        game2048 myGame;

        public mainForm()
        {
            InitializeComponent();
            myGame = new game2048(); //create instance
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            myGame.reset();
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            myGame.move(0);
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            myGame.move(1);
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            myGame.move(3);
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            myGame.move(2);
            SetValues(myGame);
            gameLabel.Text = myGame.ToString();
        }

        private void SetValues(game2048 myGame) 
        {
            statusLabel.Text = myGame.Status.ToString();
            pointsTextBox.Text = myGame.Points.ToString();
        }

    }
}
