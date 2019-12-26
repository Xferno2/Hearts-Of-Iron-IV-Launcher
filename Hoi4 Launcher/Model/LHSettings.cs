using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Launcher.Model
{
    public class LHSettings
    {
        public string browserDlcUrl { get; set; }
        public string browserModUrl { get; set; }
        public string distPlatform { get; set; }
        public List<string> exeArgs { get; set; }
        public string exePath { get; set; }
        public List<string> gameCachePaths { get; set; }
        public string gameDataPath { get; set; }
        public string gameEngine { get; set; }
        public string gameId { get; set; }
        public string ingameSettingsLayoutPath { get; set; }
        public string rawVersion { get; set; }
        public string themeFile { get; set; }
        public string version { get; set; }
    }
}
