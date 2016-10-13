using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GrdButton.cs
//j.l. lehman
//spring 2015
//demonstrates inheritance to add functionality to Windows components
//GridButton adds row and column data to Button 
//  to allow user to determine which button generates an event
namespace P6
{
    class GridButton : Button 
    {
        public int row;
        public int col;

        public GridButton(int newR, int newC)
        {
            row = newR;
            col = newC;
        }

    }//class
}//namespace
