using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P6
{
    public partial class mainForm : Form
    {
        GridButton[,] grid;
        Minesweeper myGame;
        private int currentSize;
        private int timer;

        public int getTimer
        {
            get { return timer; }
        }

        public mainForm()
        {
            InitializeComponent();
            currentSize = 9;
            newGame(9, 9);
            checkStatus();
        }

        public void timerReset()
        {
            timer = 0;
        }

        public void timerSumSecond()
        {
            timer += 1;
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            timerSumSecond();
            timerLabel.Text = getTimer.ToString();
        }

        public int countMines()
        {
            string mines = myGame.toStringMines();
            int count = 0;
            foreach (char c in mines)
                if (c == '9') count++;
            return count;
        }

        public void checkStatus()
        {
            string status = myGame.getStatus();
            if (status == "play")
            {
                statusButton.BackgroundImage = P6.Properties.Resources.status_play;
                statusButton.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if(status == "lose")
            {
                statusButton.BackgroundImage = P6.Properties.Resources.status_loss;
                statusButton.BackgroundImageLayout = ImageLayout.Stretch;
                mainTimer.Stop();
                timerReset();
            }
            else if (status == "win")
            {
                statusButton.BackgroundImage = P6.Properties.Resources.status_win;
                statusButton.BackgroundImageLayout = ImageLayout.Stretch;
                mainTimer.Stop();
                timerReset();
            }
        }

        private void updateGUI()
        {
            for (int r = 0; r <= grid.GetUpperBound(0); r++)
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    string a = myGame.getBoard(r, c);
                    if (myGame.getBoard(r,c) == "F")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.flag;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else if (a == "?")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.question_mark;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "*")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.bomb;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "!")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.wrong_bomb;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "1")
                    {
                        //int[,] gridTiles = myGame.getTiles();
                        //if (gridTiles[r,c] == 0)
                        grid[r, c].BackgroundImage = P6.Properties.Resources.one;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "2")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.two;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "3")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.three;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == "-")
                    {
                        grid[r, c].BackgroundImage = P6.Properties.Resources.incorrect_bomb;
                        grid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (a == " ")
                    {
                        grid[r, c].BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        grid[r, c].BackgroundImage = null;
                        grid[r, c].Text = " ";
                        grid[r, c].BackColor = Color.GhostWhite;
                    }
                }
        }//updateGUI

        private void Button_Click(object sender, MouseEventArgs e)
        {
            GridButton myButton = (GridButton)sender;
            if (e.Button == MouseButtons.Left)
            {
                myGame.openTile(myButton.row, myButton.col);
            }
            if (e.Button == MouseButtons.Right)
            {
                myGame.markTile(myButton.row, myButton.col);
            }
            
            updateGUI();
            checkStatus();

        }//Button_Click

        private void newGame(int x, int y) 
        {
            //dynamically create a grid of buttons
            grid = new GridButton[x, y];
            int xPos = 50;
            int yPos = 75;

            for (int r = 0; r <= grid.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    grid[r, c] = new GridButton(r, c);
                    grid[r, c].Location = new System.Drawing.Point(xPos, yPos);
                    xPos += 28;
                    grid[r, c].Name = "button" + r + "-" + c;
                    grid[r, c].Text = " ";
                    grid[r, c].Size = new System.Drawing.Size(30, 30);
                    grid[r, c].MouseDown += Button_Click;
                    this.Controls.Add(grid[r, c]);

                }//for c
                yPos += 28;
                xPos = 50;
            }//for r

            //game of life instance for data/life logic
            myGame = new Minesweeper(x, y);

            //update GUI
            updateGUI();
            checkStatus();
            totalMinesLabel.Text = countMines().ToString();
            mainTimer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cleanGame()
        {
            for (int r = 0; r <= grid.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    this.Controls.Remove(grid[r, c]);

                }//for c
            }//for r
         }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanGame();
            currentSize = 12;
            newGame(12, 12);
            checkStatus();
        }

        private void x50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanGame();
            currentSize = 12;
            newGame(18, 18);
            checkStatus();
        }

        private void x100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanGame();
            currentSize = 22;
            newGame(22, 22);
            checkStatus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cleanGame();
            currentSize = 9;
            newGame(9, 9);
            checkStatus();
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            timerReset();
            cleanGame();
            newGame(currentSize, currentSize);
            checkStatus();
            
        }



    }
}
