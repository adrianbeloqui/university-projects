using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Adrian Beloqui
 2/16/2015
 P4 OOP Arrays Random 2048
 
 This class covers the logic of the game 2048.
 There are no returning strings besides the Board. 
 For example, to know what each value means for the Status
 of the game, it should be check in the requierements of the 
 exercise and do the coding needed to show stings instead of numbers
 in the user interface.
 */


namespace P4_2048
{
    class game2048
    {
        private int status;
        private int points;
        private int[,] board;
        private Random rn;
        private int seed;

        #region Properties
        public int Points
        {
            get { return points; }
        }

        public int Status
        {
            get { return status; }
        }
        #endregion

        #region Constructors
        public game2048()
        {
            rn = new Random();
            reset();
        }
        public game2048(int iSeed)
        {
            seed = iSeed;
            reset();
        }
        #endregion

        public void reset()
        {
            //reset status
            status = 0; //play
            points = 0;

            //reset board
            board = new int[4,4];

            //place x2 values           
            rn = new Random();

            //For test purposes          
            //rn = new Random(seed);

            board[rn.Next(4),rn.Next(4)] = 2;
            int newX = rn.Next(4), newY = rn.Next(4);
            bool isEqual = true;
            while (isEqual)
            {
                if (board[newX, newY] != 2)
                {
                    isEqual = false;
                    board[newX, newY] = 4;
                }
            }
        }

        public void move(int direction) 
        {
            Boolean bAdd = false;

            switch (direction)
            {
                case 2: //left
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (board[i,k] == 0)
                                {
                                    continue;
                                }
                                else if (board[i,k] == board[i,j])
                                {
                                    board[i,j] *= 2;
                                    points += board[i,j];
                                    board[i,k] = 0;
                                    bAdd = true;
                                    break;
                                }
                                else
                                {
                                    if (board[i,j] == 0 && board[i,k] != 0)
                                    {
                                        board[i,j] = board[i,k];
                                        board[i,k] = 0;
                                        j--;
                                        bAdd = true;
                                        break;
                                    }
                                    else if (board[i,j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 1: //down
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 3; i >= 0; i--)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (board[k,j] == 0)
                                {
                                    continue;
                                }
                                else if (board[k,j] == board[i,j])
                                {
                                    board[i,j] *= 2;
                                    points += board[i,j];
                                    board[k,j] = 0;
                                    bAdd = true;
                                    break;
                                }
                                else
                                {
                                    if (board[i,j] == 0 && board[k,j] != 0)
                                    {
                                        board[i,j] = board[k,j];
                                        board[k,j] = 0;
                                        i++;
                                        bAdd = true;
                                        break;
                                    }
                                    else if (board[i,j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3: //right
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 3; j >= 0; j--)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (board[i,k] == 0)
                                {
                                    continue;
                                }
                                else if (board[i,k] == board[i,j])
                                {
                                    board[i,j] *= 2;
                                    points += board[i,j];
                                    board[i,k] = 0;
                                    bAdd = true;
                                    break;
                                }
                                else
                                {
                                    if (board[i,j] == 0 && board[i,k] != 0)
                                    {
                                        board[i,j] = board[i,k];
                                        board[i,k] = 0;
                                        j++;
                                        bAdd = true;
                                        break;
                                    }
                                    else if (board[i,j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 0: //up
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int k = i + 1; k < 4; k++)
                            {
                                if (board[k,j] == 0)
                                {
                                    continue;
                                }
                                else if (board[k,j] == board[i,j])
                                {
                                    board[i,j] *= 2;
                                    points += board[i,j];
                                    board[k,j] = 0;
                                    bAdd = true;
                                    break;
                                }
                                else
                                {
                                    if (board[i,j] == 0 && board[k,j] != 0)
                                    {
                                        board[i,j] = board[k,j];
                                        board[k,j] = 0;
                                        i--;
                                        bAdd = true;
                                        break;
                                    }
                                    else if (board[i,j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }

            if (bAdd)
            {
                this.DrawNewNumber(this.SetNewNumber());
            }

            checkGameOver();
            checkVictory();
        }

        public int getValue(int row, int col)
        {
            int value;
            value = board[row, col];
            return value;
        }

        public override string ToString()
        {
            string result = "";

            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    result += string.Format("{0,5}  ", board[r,c]);
                }
                result += "\n";
            }

            return result;
        }

        #region Helper Methods

        private int SetNewNumber()
        {
            int result;
            Random rNewNumber = new Random();
            result = rNewNumber.Next(1,11);
            if (result == 4) { return result; }
            else { return 2; }
        }

        private void DrawNewNumber(int addNum)
        {
            bool spotOcupied = true;
            while (spotOcupied)
            {
                int nX = rn.Next(0, 4);
                int nY = rn.Next(0, 4);

                if (getValue(nX,nY) == 0)
                {
                    spotOcupied = false;
                    board[nX, nY] = addNum;
                }
            }
        }

        public void checkGameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i - 1 >= 0)
                    {
                        if (board[i - 1,j] == board[i,j])
                        {
                            return;
                        }
                    }

                    if (i + 1 < 4)
                    {
                        if (board[i + 1,j] == board[i,j])
                        {
                            return;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (board[i,j - 1] == board[i,j])
                        {
                            return;
                        }
                    }

                    if (j + 1 < 4)
                    {
                        if (board[i,j + 1] == board[i,j])
                        {
                            return;
                        }
                    }

                    if (board[i,j] == 0)
                    {
                        return;
                    }
                }
            }

            status = 2;
        }

        public void checkVictory()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 2048)
                    {
                        status = 1;
                    }
                }
            }
        }

        #endregion

    }
}
