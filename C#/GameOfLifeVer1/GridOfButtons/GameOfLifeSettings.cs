using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace GridOfButtons
{
    public class GameOfLifeSettings
    {
        int rows;
        int cols;
        int timerValue;

        bool boardChanged;

        public bool BoardChanged
        {
            get { return boardChanged; }
            set { boardChanged = value; }
        }



        public int TimerValue
        {
            get { return timerValue; }
            set { timerValue = value; }
        }

        public int Rows
        {
            get { return rows; }
            set {
                
                if (value != Rows)
                    BoardChanged = true;
               
                rows = value;
               
            }
        }
        
        public int Cols
        {
            get { return cols; }
            set {

                if (value != cols)
                    BoardChanged = true;

                cols = value;

            }
        }

        public GameOfLifeSettings()
        {
            this.open(); //get settings
            
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter("settings.txt");
            
            writer.WriteLine(Rows);
            writer.WriteLine(Cols);
            writer.WriteLine(TimerValue);

            writer.Close();
        }//save

        public void open()
        {

            StreamReader reader = new StreamReader("settings.txt");

            string line = reader.ReadLine();
            Rows = int.Parse(line);

            line = reader.ReadLine();
            Cols = int.Parse(line);

            line = reader.ReadLine();
            TimerValue = int.Parse(line);

            reader.Close();
        }//open


    }//class
}//namespace
