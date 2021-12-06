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
            //Dictionary<string, bool> version_checks = new Dictionary<string, bool>();
            string[] gameVersion = version.Split('.');
            if (supported_version != null) {
                string[] modVersion = supported_version.Split('.');
                for (int i = 0; i <= modVersion.Length; i++)
                {
                    //if (modVersion[i] == "*")
                    //{
                    //    version_checks.Add(modVersion[i], true);
                    //}
                    //else if (Convert.ToInt32(modVersion[i]) >= Convert.ToInt32(gameVersion[i]))
                    //{
                    //    version_checks.Add(modVersion[i], true);
                    //}
                    //else {
                    //    version_checks.Add(modVersion[i], false);
                    //}
                    if (modVersion[i] == "*")
                    {
                        return true;
                    }
                    else if (Convert.ToInt32(modVersion[i]) < Convert.ToInt32(gameVersion[i])) {
                        return false;
                    }
                    else if (Convert.ToInt32(modVersion[i]) > Convert.ToInt32(gameVersion[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            else { return true; }
        }
    }
}
