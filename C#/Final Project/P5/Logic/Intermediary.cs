using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;

namespace Logic
{
    public class Intermediary
    {
        public static void ReadBinary(string filename) 
        {
            FileManager.ReadBinary(filename);
        }

        public static void WriteBinary(string filename)
        {
            FileManager.WriteBinary(filename);
        }

        public static void WriteText(string filename)
        {
            //FileManager.WriteText(filename);
        }

        public static void ReadText(string filename)
        {
        //    FileManager.ReadText(filename);
        }

        public static void ApplySettings(ArrayList data)
        {
            Settings.ApplySettings(data);
        }

        public static ArrayList ReadSettings()
        {
            return Settings.ReadSettings();
        }
    }
}
