using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Launcher.Model
{
    public class newModInfo
    {
        public string displayName { get; set; }
        public string gameRegestryMod { get; set; }

        public List<string> tags { get; set; }
        public string supported_version { get; set; }
        public string remote_fileid { get; set; }
        public string dirPath { get; set; }
        public bool isPath { get; set; }
        public Image picture { get; set; }

        public bool isSupported_Version(string version) {
            string[] gameVersion = version.Split('.');
            if (supported_version != null) {
                string[] modVersion = supported_version.Split('.');
                int itteration = 0;
                if (modVersion.Length > gameVersion.Length) { itteration = gameVersion.Length; } else { itteration = modVersion.Length; }
                for (int i = 0; i < itteration; i++)
                {
                    if (modVersion[i] == "*") {return true;}
                    else if (Convert.ToInt32(modVersion[i]) < Convert.ToInt32(gameVersion[i])) {return false;}
                    else if (Convert.ToInt32(modVersion[i]) > Convert.ToInt32(gameVersion[i])) {return false;}
                }
                return true;
            }
            else { return true; }
        }
    }
}
