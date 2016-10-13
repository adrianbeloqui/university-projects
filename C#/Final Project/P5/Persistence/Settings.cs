using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Settings
    {
        public static void ApplySettings(ArrayList data)
        {
            FileManager.WriteText("settings.conf", data);
        }

        public static ArrayList ReadSettings()
        {
            return FileManager.ReadText("settings.conf");
        }
    }
}
