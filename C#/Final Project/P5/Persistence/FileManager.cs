using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Persistence
{
    public class FileManager
    {
        public static void WriteText(string path, ArrayList data)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (string line in data)
            {
                writer.WriteLine(line);
            }

            //writer.WriteLine("Homer, CS111, 55.0");
            //writer.WriteLine("Marge, CS435, 98.5");
            //writer.WriteLine("Bart, CS111, 75.0");
            //writer.WriteLine("Lisa, CS111, 100.0");
            //writer.WriteLine("Lisa, CS435, 100.0");
            //writer.WriteLine("Lisa, CS235, 100.0");
            //writer.WriteLine("Maggie, CS111, 88.0");


            writer.Close();

            //Console.WriteLine("Text File Written");
        }

        public static void WriteBinary(string path)
        {
            FileStream fs;
            BinaryWriter bw;
            StreamWriter writer = new StreamWriter(path);
            writer.Close();
            fs = new FileStream(path, FileMode.Open);
            bw = new BinaryWriter(fs);

            bw.Write(String.Format("## Database of current customers:"));
            bw.Write("");
            bw.Write(String.Format("## ID, Name, Lastname, SSN, Nationality, Birthdate:"));
            bw.Write("");

            // Loop through the numbers from 1 to 5 and write records
            for (int i = 0; i <= 5; i++)
            {
                bw.Write(String.Format("{0}, Customer{0}Name, Customer{0}Lastname, Customer{0}SSN, Customer{0}Nationality, Customer{0}Sex, Customer{0}Birthdate", i));
            }


            bw.Close();
            fs.Close();

            Console.WriteLine("Binary File Written");
        }

        public static ArrayList ReadText(string path)
        {
            StreamReader reader = new StreamReader(path);
            ArrayList temp = new ArrayList();
            ArrayList output = new ArrayList();
            while (reader.Peek() > -1)
            {
                temp.Add(reader.ReadLine());

            }
            reader.Close();
            int lenght = temp.Count;
            for (int i = 0; i < lenght ; i++)
            {
                string str = temp[i].ToString();
                if (temp[i].ToString() != "")
                {
                    if (str.Contains("##") == false)
                    {
                        output.Add(temp[i]);
                    }
                }
            }
            return output;
        }

        public static void ReadBinary(string path)
        {
            FileStream fs;
            BinaryReader br;

            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);

            while (br.PeekChar() != -1)
            {
                string temp = br.ReadString();
                if (temp.ToString().StartsWith("#") || (temp.ToString() == ""))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(temp);
                }
            }

            br.Close();
            fs.Close();
        }
    }
}
