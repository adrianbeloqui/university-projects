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

    //GameOfLifeForm
    //spring 2015
    //j.l. lehman
    //demonstrates dynamic array of buttons with events
    //demonstrates use of data/logic class to implement
    //  Conway's Game of Life
    //demonstrates use of imagelist
    //demonstrates use of timer
    //

    public partial class GameOfLifeForm : Form
    {
        //global variables 
        GridButton[,] grid; //two dimensional array of buttons for GUI
        GameOfLife myGame; //instance of data/life class
        Timer myTimer;
        ImageList myImages;

        GameOfLifeSettings ms;

        public GameOfLifeForm()
        {
            InitializeComponent();

            //setup imagelist
            myImages = new ImageList();
            myImages.Images.Add(
                Image.FromFile("background.PNG"));
            myImages.Images.Add(
                Image.FromFile("person.PNG"));

            //read settings
            ms = new GameOfLifeSettings();

            //dynamically create a grid of buttons
            //grid = new GridButton[20, 25];
            grid = new GridButton[ms.Rows, ms.Cols];
            //MessageBox.Show(ms.Rows + ", " + ms.Cols);

            int xPos = 25;
            int yPos = 25;

            EventHandler myButtonClick = new EventHandler(Button_Click);

            for (int r = 0; r <= grid.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    grid[r, c] = new GridButton(r, c);
                    grid[r, c].Location = new System.Drawing.Point(xPos, yPos);
                    xPos += 22;
                    grid[r, c].Name = "button" + r + "-" + c;
                    grid[r, c].Text = " ";
                    grid[r, c].Size = new System.Drawing.Size(20, 20);
                    grid[r, c].ImageList = myImages;
                    grid[r, c].Click += myButtonClick; //adds event handler

                    this.Controls.Add(grid[r, c]);                    

                }//for c
                yPos += 22;
                xPos = 25;
            }//for r

            //game of life instance for data/life logic
            myGame = new GameOfLife(20, 25);

            //update GUI
            updateGUI();

            //setup timer
            myTimer = new Timer();
            myTimer.Interval = ms.TimerValue;

            myTimer.Tick += new EventHandler(myTimerEvent);

        }//constructor

        private void Button_Click(object sender, EventArgs e)
        {
            GridButton myButton = (GridButton)sender;

            //MessageBox.Show( myButton.row + ", " + myButton.col );
            myGame.toggle(myButton.row, myButton.col);

            //update buttons
            updateGUI();
    
        }//Button_Click


        //private method to update buttons
        private void updateGUI()
        {
            for (int r = 0; r <= grid.GetUpperBound(0); r++)
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    if (myGame.getBoardValue(r, c) == 1)
                    {
                        //grid[r, c].Text = "X";
                        //grid[r, c].BackColor = Color.Black;
                        //grid[r, c].ImageIndex = 1;
                        grid[r, c].BackColor = Color.Black;
                    }
                    else
                    {
                        //grid[r, c].Text = " ";
                        //grid[r, c].BackColor = Color.GhostWhite;
                        //grid[r, c].ImageIndex = 0;
                        grid[r, c].BackColor = Color.GhostWhite;
                    }
                }
        }//updateGUI

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            myGame.nextGeneration();
            updateGUI();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGame.clear();
            updateGUI();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGame.clear();
            updateGUI();
        }

        private void randomWorldToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            myGame.genesis(.3);
            updateGUI();
        }

        private void autoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Start();
        }

        private void myTimerEvent(object sender, EventArgs e)
        {
            myGame.nextGeneration();
            updateGUI();
        }

        private void autoStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            myGame.genesis(.25);
            updateGUI();
        
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            myGame.genesis(.50);
            updateGUI();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            myGame.genesis(.75);
            updateGUI();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameOfLifeSettingsForm sf = new GameOfLifeSettingsForm(ms);   
            sf.ShowDialog();

            ms.BoardChanged = false;

            if (ms.BoardChanged == true)
            {
                newBoard();
            }

            myTimer.Interval = ms.TimerValue;
        }



        private void newBoard()
        {
            //remove old
            for (int r = 0; r <= grid.GetUpperBound(0); r++)
              for (int c = 0; c <= grid.GetUpperBound(1); c++)
                    this.Controls.Remove(grid[r, c]);
            
            //add new
            grid = new GridButton[ms.Rows, ms.Cols];

            int xPos = 25;
            int yPos = 25;

            EventHandler myButtonClick = new EventHandler(Button_Click);

            for (int r = 0; r <= grid.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= grid.GetUpperBound(1); c++)
                {
                    grid[r, c] = new GridButton(r, c);
                    grid[r, c].Location = new System.Drawing.Point(xPos, yPos);
                    xPos += 22;
                    grid[r, c].Name = "button" + r + "-" + c;
                    grid[r, c].Text = " ";
                    grid[r, c].Size = new System.Drawing.Size(20, 20);
                    grid[r, c].ImageList = myImages;
                    grid[r, c].Click += myButtonClick; //adds event handler

                    this.Controls.Add(grid[r, c]);

                }//for c
                yPos += 22;
                xPos = 25;
            }//for r

            //game of life instance for data/life logic
            myGame = new GameOfLife(20, 25);

            //update GUI
            updateGUI();

        }//newBoard

    }//class

}//namespace
