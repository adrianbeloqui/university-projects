using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GameOfLife.cs
//spring 2015
//j.l. lehman
//OOP class implements game of life data/logic
//code ported from Java code developed spring 2014
//

namespace GridOfButtons
{
    class GameOfLife
    {

        // data
        int[,] world; // declare world as a two dimensional array

        // methods - constructors

        // default constructor
        public GameOfLife()
        {
            world = new int[10, 10]; // create array & allocate space

        }// gameOfLife constructor

        // alternate constructor
        public GameOfLife(int numRows, int numCols)
        {
            world = new int[numRows, numCols]; // create array & allocate space

        }// gameOfLife constructor

        public int getNumRows()
        {
            return world.Length;
        }

        public int getNumColumns()
        {
            return world.GetUpperBound(1) + 1;
        }

        public void displayBoardDebug()
        {

            for (int r = 0; r <= world.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= world.GetUpperBound(1); c++)
                {
                    Console.Out.Write(world[r, c]);
                }
                Console.Out.WriteLine();
            }

        }

        public void setBoardPos(int r, int c, int v)
        {
            if (validSpot(r, c) == true)
                world[r, c] = v;
        }

        private bool validSpot(int r, int c)
        {

            bool result = true;

            if (r < 0 || r > world.GetUpperBound(0))
                result = false;
            else if (c < 0 || c > world.GetUpperBound(1))
                result = false;

            return result;
        }

        public void displayBoard()
        {

            for (int r = 0; r <= world.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= world.GetUpperBound(1); c++)
                {
                    if (world[r, c] == 0)
                        Console.Out.Write(" ");
                    else
                        Console.Out.Write("X");
                }
                Console.Out.WriteLine();
            }

        }

        public void nextGeneration()
        {

            // create a temp array to store next generation
            // all values in temp are zero by default
            int[,] temp = new int[world.GetUpperBound(0) + 1, world.GetUpperBound(1) + 1];

            for (int r = 0; r <= world.GetUpperBound(0); r++)
                for (int c = 0; c < world.GetUpperBound(1); c++)
                {
                    switch (world[r, c])
                    {
                        case 0:
                            if (neighborCount(r, c) == 3)
                                temp[r, c] = 1;
                            break;

                        case 1:
                            if (neighborCount(r, c) <= 1 || neighborCount(r, c) >= 4)
                                temp[r, c] = 0;
                            else
                                temp[r, c] = 1;
                            break;

                    }// switch

                }// for c

            // copy temp to world
            for (int r = 0; r <= world.GetUpperBound(0); r++)
                for (int c = 0; c <= world.GetUpperBound(1); c++)
                    world[r, c] = temp[r, c];

        }// nextGeneration

        private int neighborCount(int r, int c)
        {

            int count = 0;

            // // top left
            // if (validSpot(r - 1, c - 1))
            // if (world[r - 1][c - 1] == 1)
            // count++;
            //
            // // top middle
            // if (validSpot(r - 1, c))
            // if (world[r - 1][c] == 1)
            // count++;
            //
            // // top right
            // if (validSpot(r - 1, c + 1))
            // if (world[r - 1][c + 1] == 1)
            // count++;
            //
            // // middle left
            // if (validSpot(r, c - 1))
            // if (world[r][c - 1] == 1)
            // count++;
            //
            // // middle right
            // if (validSpot(r, c + 1))
            // if (world[r][c + 1] == 1)
            // count++;
            //
            // // bottom left
            // if (validSpot(r + 1, c - 1))
            // if (world[r + 1][c - 1] == 1)
            // count++;
            //
            // // bottom middle
            // if (validSpot(r + 1, c))
            // if (world[r + 1][c] == 1)
            // count++;
            //
            // // bottom right
            // if (validSpot(r + 1, c + 1))
            // if (world[r + 1][c + 1] == 1)
            // count++;

            // *** could simplify with this approach, elminates the 2nd if
            // *** still have 8 if statements
            // top left
            // if (validSpot(r - 1, c - 1))
            // count += world
            //[r - 1][c - 1];

            // top left

            count = 0;

            int[] rows = { r - 1, r - 1, r - 1, r, r, r + 1, r + 1, r + 1 };
            int[] cols = { c - 1, c, c + 1, c - 1, c + 1, c - 1, c, c + 1 };

            for (int x = 0; x <= rows.GetUpperBound(0); x++)
            {
                if (validSpot(rows[x], cols[x]))
                    count = count + world[rows[x], cols[x]];
            }

            return count;
        }

        // methods
        public void genesis(double percent)
        {
            //clear world
            for (int r = 0; r <= world.GetUpperBound(0); r++)
                for (int c = 0; c <= world.GetUpperBound(1); c++)
                    world[r, c] = 0;

            //set random 1's
            int number = (int)(percent * (world.GetUpperBound(0) + 1) * (world.GetUpperBound(1) + 1));
            //System.out.println( number );

            Random rn = new Random();

            int x = 0;
            while (x < number)
            {

                int rr = rn.Next(0, world.GetUpperBound(0)); //0 to less than world.length
                int rc = rn.Next(0, world.GetUpperBound(1)); //0 to less than world[0].length

                if (world[rr, rc] != 1)
                {
                    world[rr, rc] = 1;
                    x++;
                }

            }//while

        }

        public int getBoardValue(int r, int c)
        {
            if (validSpot(r, c))
                return world[r, c];
            else
                return -1;
        }

        public void clear()
        {
            //clear world
            for (int r = 0; r <= world.GetUpperBound(0); r++)
                for (int c = 0; c <= world.GetUpperBound(1); c++)
                    world[r, c] = 0;
        }

        public void toggle(int r, int c)
        {
            if (this.getBoardValue(r, c) == 0)
                this.setBoardPos(r, c, 1);
            else
                this.setBoardPos(r, c, 0);

        }//class
    }//namespace
}