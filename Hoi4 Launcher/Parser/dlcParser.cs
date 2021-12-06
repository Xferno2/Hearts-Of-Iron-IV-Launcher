using Hoi4_Launcher.Model;
using Hoi4_Launcher.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Launcher.Parser
{
    public class dlcParser
    {
        public bool is3rdParty;
        public dlcParser() { 

        }
        public dlcModel[] GetDLCs()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "dlc");
            List<dlcModel> dlcs = new List<dlcModel>();
            foreach (var dir in Directory.GetDirectories(path))
            {
                try
                {
                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    var dlcFullPath = dInfo.GetFilesByExtensions(".dlc").First().FullName;
                    var dlc = new dlcModel();
                    var x = File.ReadLines(dlcFullPath);
                    dlc.name = x.First().Split('"')[1].Replace('"', ' ');
                    dlc.path = x.ElementAt(1).Split('=')[1].Replace('"', ' ').Replace(" ", "").Split('.').First() + ".dlc";
                    var party = x.ElementAt(x.Count() - 2).Split('=')[1].Replace(" ", "");
                    if (party.Contains("music"))
                        party = x.ElementAt(x.Count() - 3).Split('=')[1].Replace(" ", "");
                    if (party == "yes")
                    { dlc._3rdparty = true; is3rdParty = true; }
                    else { dlc._3rdparty = false; }
                    dlcs.Add(dlc);
                }
                catch (Exception ex)
                {
                }
            }
            return dlcs.ToArray();
        }
    }
}
