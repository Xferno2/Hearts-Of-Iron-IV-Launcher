using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Launcher.Model
{
    public class modInfo
    {
        public string gameRegistryId { get; set; }
        public string source { get; set; }
        public string steamId { get; set; }
        public string displayName { get; set; }
        public List<string> tags { get; set; }
        public string requiredVersion { get; set; }
        public string archivePath { get; set; }
        public string dirPath { get; set; }
        public string status { get; set; }
        public string id { get; set; }
    }
}
