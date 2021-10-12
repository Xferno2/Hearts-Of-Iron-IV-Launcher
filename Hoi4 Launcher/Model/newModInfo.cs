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
    }
}
