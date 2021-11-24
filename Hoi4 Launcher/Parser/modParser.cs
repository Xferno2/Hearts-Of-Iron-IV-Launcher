using Hoi4_Launcher.Utility;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoi4_Launcher.Parser
{
    class modParser
    {
        public string modsFolder;
        public string[] mods;
        public bool isPathValid = false;
        public Exception exception;
        public modParser(string thisPath)
        {
            this.modsFolder = workshop(thisPath);
            try
            {
                mods = Directory.GetDirectories(modsFolder);
                this.isPathValid = true;
            }
            catch (Exception ex) {
            string message = "I couldn't find the path to the mods directory." + 
                    Environment.NewLine+
                    "Perhaps this is not a steam install?" +
                    Environment.NewLine + 
                    "Either way descriptor.mod is disabled. If you think this is an issue, open one on github."+
                    Environment.NewLine +
                    "More info in Log tab!";
            string title = "Something intresting happened";
            MessageBox.Show(message, title);
                Properties.Settings.Default.generateDescriptor = false;
                Properties.Settings.Default.Save();
                this.exception = ex;
            }
        }
        public string workshop(string path) => path.Split(new string[] { "steamapps" }, StringSplitOptions.None)[0] + "steamapps\\workshop\\content\\394360";

        public bool createDescriptorFile(string path, string savePath, string id)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            FileInfo zipFile;
            try
            {
                zipFile = dInfo.GetFilesByExtensions(new string[] { ".rar", ".zip", ".7z" }).First();
            }
            catch (Exception ex) {
                zipFile = null;
            }
            // We are going to check if descriptor.mod exists
            if (File.Exists(dInfo.FullName + "\\descriptor.mod"))
            {
                if (!File.Exists(savePath + "\\ugc_" + id + ".mod")){
                    var descriptorFile = editDescriptor(File.ReadAllText(dInfo.FullName + "\\descriptor.mod"), dInfo.FullName);
                    System.IO.File.WriteAllLines(savePath + "\\ugc_" + id + ".mod", descriptorFile);
                }
                return true;
            }
            else if (zipFile != null)
            {
                if (!File.Exists(savePath + "\\ugc_" + id + ".mod"))
                {
                    try
                    {
                        using (Stream stream = File.OpenRead(zipFile.FullName))
                        using (var reader = ReaderFactory.Open(stream))
                        {
                            while (reader.MoveToNextEntry())
                            {
                                if (!reader.Entry.IsDirectory && reader.Entry.Key == "descriptor.mod")
                                {
                                    reader.WriteEntryToFile(@"tempDescriptor.mod");
                                    var descriptorFile = editDescriptor(File.ReadAllText(@"tempDescriptor.mod"), zipFile.FullName);
                                    System.IO.File.WriteAllLines(savePath + "\\ugc_" + id + ".mod", descriptorFile);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
                if (File.Exists(@"tempDescriptor.mod"))
                {
                    File.Delete(@"tempDescriptor.mod");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // this rlly needs a rewrite
        private string[] editDescriptor(string descriptor, string path)
        {
            bool doesItContainPath = false;
            List<string> descriptorFile = new List<string>();
            foreach (var line in descriptor.Split(new string[] { Environment.NewLine, "\n\t", "\n\r", "\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                var currentLine = line;
                if (line.Split('=').First().ToLower() == "path")
                {
                    currentLine = "path=" + path;
                    doesItContainPath = true;

                }
                descriptorFile.Add(currentLine);
            }
            if (!doesItContainPath)
            {
                descriptorFile.Add("path=" + path);
            }
            return descriptorFile.ToArray();
        }
    }
}
