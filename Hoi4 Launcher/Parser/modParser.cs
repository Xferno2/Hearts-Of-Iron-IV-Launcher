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
    public class modParser
    {
        public static List<string> comboBoxCategories = new List<string>();
        public modParser() {
        }

        public static List<newModInfo> load_mods_info(string path)
        {
            string[] stringSeparators = new string[] { "\n\t", "\n\r", Environment.NewLine };
            List<newModInfo> mods = new List<newModInfo>();
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.mod");
            foreach (FileInfo file in Files)
            {
                var mod = new newModInfo();
                mod.gameRegestryMod = "mod/" + file.Name;
                //   if (mod.gameRegestryMod == "mod/ugc_1395409185.mod")
                //   {
                //        Debugger.Break();
                //   }
                var modFiles = File.ReadAllLines(file.FullName);
                var modFileWhole = File.ReadAllText(file.FullName);
                foreach (var modFile in modFiles)
                {

                    if (modFile.Contains("name="))
                    {
                        mod.displayName = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("archive="))
                    {
                        mod.dirPath = modFile.Split('=')[1].Replace("\"", "");
                        mod.isPath = false;
                    }
                    if (modFile.Contains("path="))
                    {
                        mod.dirPath = modFile.Split('=')[1].Replace("\"", "");
                        mod.isPath = true;
                    }
                    if (modFile.Contains("supported_version="))
                    {
                        mod.supported_version = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("remote_file_id="))
                    {
                        mod.remote_fileid = modFile.Split('=')[1].Replace("\"", "");
                    }
                    //if (modFile.Contains("picture="))
                    //{
                    //    if (mod.dirPath != null)
                    //    {
                    //        if (mod.isPath)
                    //        {
                    //            mod.picture = Util.ResizeImage(Util.parseImage(mod.dirPath, ""), 75, 75);
                    //        }
                    //        else if (!mod.isPath)
                    //        {
                    //            mod.picture = Util.ResizeImage(Util.parseImage(mod.dirPath, modFile.Split('=')[1].Replace("\"", "")), 75, 75);
                    //        }
                    //    }
                    //}
                    if (modFile.Contains("tags={"))
                    {
                        List<string> tagsList = new List<string>();
                        string[] titleSeparators = new string[] { "tags={" };
                        string searchInText = "tags={" + modFileWhole.Split(titleSeparators, StringSplitOptions.None)[1];
                        var tagsNotFormated = Util.removeBrackets(searchInText, "tags={", "}", false);
                        var tagsFormated = tagsNotFormated.Split(stringSeparators, StringSplitOptions.None);
                        foreach (var tag in tagsFormated)
                        {
                            if (tag != "")
                            {
                                var currentTag = Util.removeBrackets(tag, "\"", "\"");
                                tagsList.Add(currentTag);
                                bool isItemInList = false;
                                foreach (var listItem in comboBoxCategories)
                                {
                                    if (listItem.ToString().ToLower() == currentTag.ToLower())
                                    {
                                        isItemInList = true;
                                    }
                                }
                                if (!isItemInList)
                                    comboBoxCategories.Add(currentTag);
                            }
                        }
                        mod.tags = tagsList;
                    }
                }
                mods.Add(mod);
            }
            return mods;
        }
    }
}
