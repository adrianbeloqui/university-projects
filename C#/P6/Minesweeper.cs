using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Minesweepr.cs
//j.l. lehman
//spring 2015
//data/logic for minesweeper game
//code ported from VB implementation (which was ported from Java)
//see http://nifty.stanford.edu/2004/LehmanMinesweeper/
//
//note: code could use "clean up" of unused methods and data
//

namespace P6
{
    class Minesweeper
    {

        //***************************
        //*** data ******************
        //***************************

        private int[,] mines; //holds the mines and clues
        private int[,] tiles; //holds the tile status (0 open, 1 closed, 2 question, 3 bomb
        private string status; //holds game status "play", "win", "lose"
        //private int numMines; //holds number of mines for game
        //private int foundMines; //holds number of mines that are found

        //***************************
        //*** constructors **********
        //***************************

        public Minesweeper()
        {
            //create arrays - default size 8 x 8, 
            //place bombs, calcuate clues, 
            //init tiles, set game status
            initGame(8, 8);
        }

        //alternate constructor 
        public Minesweeper(int newRows, int newCols)
        {
            //create arrays - default size newRows x newCols, 
            //place bombs, calcuate clues, 
            //init tiles, set game status
            if (newRows < 1)
                newRows = 1;
            if (newCols < 1)
                newCols = 1;
            initGame(newRows, newCols);
        }

        
        //***************************
        //*** public Methods *******
        //***************************

        //returns the game status "play", "win", "lose"
        public string getStatus()
        {
            return status;
        }
        //returns the number of rows
        public int getRows()
        {
            return mines.GetUpperBound(0) + 1;
        }

        //returns the number of columns
        public int getCols()
        {
            return mines.GetUpperBound(1) + 1;
        }

        //mark tile with row, col, and tile type
        //public void markTile(int tempR, int tempC, int tempT)
        //{
        //    if (validIndex(tempR, tempC))
        //    {
        //        //process mark tile request
        //        switch (tempT)
        //        {
        //            case 0: //open
        //                //recursively open adjacent blanks
        //                if (mines[tempR, tempC] == 0)
        //                    openAdjacentBlanks(tempR, tempC);
        //                else
        //                {
        //                    //open tile
        //                    tiles[tempR, tempC] = 0;

        //                    //see if ( game over
        //                    if (mines[tempR, tempC] == 9)
        //                        status = "lose";
        //                    else
        //                        //check for game won - Win when all tiles uncovered except mines
        //                        if (gameWon())
        //                            status = "win";
        //                }
        //                break;

        //            case 1:
        //            case 2:
        //            case 3://flag, question, or re-cover
        //                //change to flag, question, or covered as long as it was not already open
        //                if (tiles[tempR, tempC] != 0)
        //                    tiles[tempR, tempC] = tempT;
        //                break;

        //            default:
        //                break;
        //            //error, ignore
        //        }//select

        //    }//if
        //}//markTile


        //mark tile with row, col, and tile type
        public void openTile(int tempR, int tempC)
        {
            if (validIndex(tempR, tempC) && status.Equals("play"))
            {

                //recursively open adjacent blanks
                if (mines[tempR, tempC] == 0)
                    openAdjacentBlanks(tempR, tempC);
                else
                {
                    //open tile
                    tiles[tempR, tempC] = 0;

                    //see if ( game over
                    if (mines[tempR, tempC] == 9)
                        status = "lose";
                    else
                        //check for game won - Win when all tiles uncovered except mines
                        if (gameWon())
                            status = "win";
                }

            }//if
        }//openTile

        //mark tile with row, col, and tile type
        public void markTile(int tempR, int tempC)
        {
            if (validIndex(tempR, tempC) && status.Equals("play"))
            {
                //change to flag, question, or covered as long as it was not already open
                if (tiles[tempR, tempC] != 0)
                {

                    //cycle through 2 flag, 3 question, or 1 re-cover
                    int curTile = tiles[tempR, tempC];
                    curTile++;

                    if (curTile == 4)
                        curTile = 1;

                    tiles[tempR, tempC] = curTile;
                }//if       
            }//if
        }//markTile


        //return mines array as string
        public string toStringMines()
        {
            string result = "";

            for (int r = 0; r <= mines.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= mines.GetUpperBound(1); c++)
                    result += mines[r, c];
                result += "\n";
            }

            return result;
        }

        //returns tiles as string
        public string toStringTiles()
        {
            string result = "";

            for (int r = 0; r <= mines.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= mines.GetUpperBound(1); c++)
                    result += tiles[r, c];

                result += "\n";
            }

            return result;
        }

        //returns board position as an integer    
        public string getBoard(int r, int c)
        {
            //note: toStringBoard is stored and individual board value is returned from this array
            string data = toStringBoard();

            //note: +3 accounts for number of columns plus 2 for vbcrlf
            int p = r * (mines.GetUpperBound(1)+2) + c;

            return data.Substring(p, 1); //get one character from p
        }

        //returns board as string
        public string toStringBoard()
        {
            string result = "";

            for (int r = 0; r <= mines.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= mines.GetUpperBound(1); c++)
                {
                    //update board based on status of game
                    //either "play", "won", or "lost"
                    if (status.Equals("play"))
                    {
                        switch (tiles[r, c])
                        {
                            case 0: //open - display mine contents ie. clue
                                if (mines[r, c] == 0)
                                    result += " ";
                                else
                                    result += mines[r, c];
                                break;

                            case 1: //close - display X
                                result += "X";
                                break;

                            case 2:                   //flag - display F
                                result += "F";
                                break;

                            case 3:
                                result += "?";       //question mark - display ?
                                break;

                            default:
                                break;
                            //error, ignore
                        }//switch
                    }//play
                    else
                        if (status.Equals("win"))
                        {
                            switch (tiles[r, c])
                            {
                                case 0: //open - display mine contents ie. clue
                                    if (mines[r, c] == 0)
                                        result += " ";
                                    else
                                        result += mines[r, c];
                                    break;

                                case 2:
                                    result += "F";       //correctly flagged mine
                                    break;

                                case 1:
                                case 3:               //show as mine if ( unopened or question
                                    result += "*";
                                    break;

                                default:
                                    break;
                                //error, ignore
                            }//switch
                        }//if win


                        else         //game lost
                            if (status.Equals("lose"))
                            {

                                switch (tiles[r, c])
                                {
                                    case 0:  //tile open
                                        if (mines[r, c] == 9) //mine that lost gaem
                                            result += "!";
                                        else
                                            if (mines[r, c] == 0) //blank or clue value
                                                result += " ";
                                            else
                                                result += mines[r, c];
                                        break;

                                    case 2: //tile flagged mine
                                        if (mines[r, c] == 9) //mine that was correctly flagged
                                            result += "F";
                                        else
                                            result += "-"; //mine that was flagged incorrectly
                                        break;

                                    case 1:
                                    case 3:   //tile closed or question
                                        if (mines[r, c] == 9)
                                            result += "*"; //unflagged mine
                                        else
                                            if (tiles[r, c] == 1)
                                                result += "X"; //stays closed
                                            else
                                                result += "?"; //stays question
                                        break;

                                    default:
                                        break;
                                    //error, ignore
                                }//switch

                            }//lost

                }//next c
                result += "\n";
            }//next r

            return result;

        }//toStringboard


        //***************************
        //*** Private Methods *******
        //***************************

        //set up game board
        private void initGame(int newRows, int newCols)
        {

            //allocate space for mines and tiles array
            if ((newRows >= 1 && newCols >= 1))
            {
                mines = new int[newRows, newCols];
                tiles = new int[newRows, newCols];

                //init tiles array
                resetTiles();

                //place mines
                placeMines();

                //update clues
                calculateClues();

                //set game status
                status = "play";
            }

        }

        //place 1//s in tiles array to init tiles
        private void resetTiles()
        {
            for (int r = 0; r <= mines.GetUpperBound(0); r++)
                for (int c = 0; c <= mines.GetUpperBound(0); c++)
                    tiles[r, c] = 1;
        }

        //place mines in mines array
        private void placeMines()
        {

            //random object for generating random rows and columns
            Random ro = new Random();

            int numMines = (this.getRows() * this.getCols()) / 10;

            if (numMines <= 0)         //make sure there is at least 1 mine
                numMines = 1;

            //place mines in array at random row and column positions
            int x = 0;
            while (x < numMines)
            {
                int nextR = ro.Next(this.getRows()); //get random row
                int nextC = ro.Next(this.getCols()); //get random column

                if (mines[nextR, nextC] != 9)
                {
                    mines[nextR, nextC] = 9;
                    x += 1;
                }

            }//while
        }//place mines

        //determine clue values for mines array
        private void calculateClues()
        {
            int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 }; //surrounding rows
            int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 }; //surrounding cols

            for (int r = 0; r <= mines.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= mines.GetUpperBound(1); c++)
                {
                    if (mines[r, c] == 9)
                    {
                        for (int z = 0; z <= 7; z++)
                        {
                            //check each neighbor by adding the x and y values to the current r and c positions
                            if (validIndex(r + x[z], c + y[z]))
                                if (mines[r + x[z], c + y[z]] != 9)
                                    mines[r + x[z], c + y[z]] += 1;

                        }//for z
                    }
                }//for c
            }//for r

        }//calculate clues

        //determines if an array position is valid ie. within the array
        private bool validIndex(int x, int y)
        {
            bool result = false;
            if (x >= 0 && x <= mines.GetUpperBound(0))
                if (y >= 0 && y <= mines.GetUpperBound(1))
                    result = true;
            return result;
        }

        //returns true if the game is won
        //game is won if all non-mine tiles are open
        private bool gameWon()
        {
            bool result = true;//assume true

            for (int r = 0; r < mines.GetUpperBound(0); r++)
                for (int c = 0; c < mines.GetUpperBound(0); c++)
                    //game is not finished if there are one or more 
                    //un-opened (tiles) that do not have mines under them
                    if (tiles[r, c] != 0 && mines[r, c] != 9)
                        result = false;

            return result;
        }//gameWon

        //recursive method to open tiles with blank areas
        private void openAdjacentBlanks(int r, int c)
        {
            if (validIndex(r, c)) //see if ( valid position in array
            {
                if (mines[r, c] == 0) //see if blank
                {
                    if (tiles[r, c] != 0) //change tile to open
                    {
                        tiles[r, c] = 0;
                        openAdjacentBlanks(r - 1, c); //left
                        openAdjacentBlanks(r + 1, c); //right
                        openAdjacentBlanks(r, c - 1); //up
                        openAdjacentBlanks(r, c + 1); //down
                        openAdjacentBlanks(r - 1, c - 1); //top left
                        openAdjacentBlanks(r - 1, c + 1); //top right
                        openAdjacentBlanks(r + 1, c - 1); //bottom left
                        openAdjacentBlanks(r + 1, c + 1); //bottom right
                    }
                }
                else
                    if (mines[r, c] >= 1 && mines[r, c] <= 8) //see if clue
                        tiles[r, c] = 0;//open tile

            }//if valid

        }//openAdjacentBlanks


    }//class Minesweeper
}
