using Hoi4_Launcher.Model;
using Hoi4_Launcher.Utility;
using Hoi4_Launcher.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Hoi4_Launcher
{
    public partial class Form1 : Form
    {
        private static string ParadoxFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Paradox Interactive");
        private static string Hoi4_Doc = Path.Combine(ParadoxFolder, "Hearts of Iron IV");
        private static string Hoi4_Enb_Mods = Path.Combine(Hoi4_Doc, "dlc_load.json");
        private static string Hoi4_Mods = Path.Combine(Hoi4_Doc, "mod");
        private static dlcModel[] dis_dlc = null;
        private static int modsCount;

        private static LHSettings gameSettings = new LHSettings();
        private string args;

        Timer updateUI = new Timer(100);

        static launchSettings data = new launchSettings();
        public Form1(string[] args)
        {
            foreach (var arg in args)
            {
                this.args += arg + " "; 
            }
            InitializeComponent();
        }

        public launchSettings load_items()
        {
            launchSettings obj;

            string data = File.ReadAllText(Hoi4_Enb_Mods);
            obj = JsonConvert.DeserializeObject<launchSettings>(data);
            return obj;
        }

        public List<newModInfo> load_mods_info() {
            string[] stringSeparators = new string[] { "\n\t" };
            List<newModInfo> mods = new List<newModInfo>();
            DirectoryInfo d = new DirectoryInfo(Hoi4_Mods);
            FileInfo[] Files = d.GetFiles("*.mod");
            foreach (FileInfo file in Files)
            {
                var mod = new newModInfo();
                mod.gameRegestryMod = "mod/" + file.Name;
                //if (mod.gameRegestryMod == "mod/ugc_1368243403.mod")
                //{
                //    Debugger.Break();
                //}
                var modFiles = File.ReadAllLines(file.FullName);
                var modFileWhole = File.ReadAllText(file.FullName);
                foreach (var modFile in modFiles) {
                    if (modFile.Contains("name=")) {
                        mod.displayName = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("supported_version="))
                    {
                        mod.supported_version = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("remote_file_id="))
                    {
                        mod.remote_fileid = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("tags={"))
                    {
                        List<string> tagsList = new List<string>();
                        var tagsNotFormated = removeBrackets(modFileWhole, "tags={", "}",false);
                        var tagsFormated = tagsNotFormated.Split(stringSeparators, StringSplitOptions.None);
                        foreach (var tag in tagsFormated) {
                            if (tag != "")
                            { var currentTag = removeBrackets(tag, "\"", "\"");
                                tagsList.Add(currentTag);
                                bool isItemInList = false;
                                foreach (var listItem in categoriesBox.Items) {
                                    if (listItem.ToString().ToLower() == currentTag.ToLower()) {
                                        isItemInList = true;
                                    }
                                }
                                if(!isItemInList)
                                    categoriesBox.Items.Add(currentTag);
                            }
                        }
                        mod.tags = tagsList;
                    }
                }
                mods.Add(mod);
            }
            return mods;
        }

        private void load() {
            //Load Mods
            var items = load_items();
            var mods = load_mods_info();
            int enabled_mods = 0;
            foreach (var mod in mods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegestryMod)) { enabled = true; enabled_mods++; }
                list_mods.Items.Add(mod.displayName, enabled);
            }
            modsCount = mods.Count;
            updateModsCount(enabled_mods, modsCount);

            //Load DLC
            foreach (var dlc in dis_dlc) {
                bool enabled = true;
                if (items.disabled_dlcs.Contains(dlc.path)) { enabled = false; }
                list_dlc.Items.Add(dlc.name,enabled);
            }
            //Load LHSetthings
            string data = File.ReadAllText(@"launcher-settings.json");
            gameSettings = JsonConvert.DeserializeObject<LHSettings>(data);
            label_version.Text += " " + gameSettings.version;
        }

        public void SerializeConfig(object x)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            File.WriteAllText(Hoi4_Enb_Mods, JsonConvert.SerializeObject(x, Formatting.Indented, settings));
        }

        public dlcModel[] GetDLCs() {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "dlc");
            List<dlcModel> dlcs = new List<dlcModel>();
                foreach (var dir in Directory.GetDirectories(path)) {
                try
                {
                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    var dlcFullPath = dInfo.GetFilesByExtensions(".dlc").First().FullName;
                    var dlc = new dlcModel();
                    var x = File.ReadLines(dlcFullPath);
                    dlc.name = x.First().Split('"')[1].Replace('"', ' ');
                    dlc.path = x.ElementAt(1).Split('"')[1].Replace('"', ' ').Split('.').First() + ".dlc";
                    var party = x.ElementAt(x.Count() - 2).Split('=')[1].Replace(" ", "");
                    if ( party == "yes")
                    { dlc._3rdparty = true; userControl11._3rdParty = true; }
                    else { dlc._3rdparty = false; }
                    dlcs.Add(dlc);
                }
            catch (Exception ex)
            {
            }
        }
            return dlcs.ToArray();
        }

        private void UserControl11_Click(object sender, EventArgs e)
        {
            var mods = load_mods_info();
            var enabled_mods = new List<string>();
            foreach (var mod in mods)
            {
                if (list_mods.CheckedItems.Contains(mod.displayName))
                {
                    if (mod.displayName != null)
                        enabled_mods.Add(mod.gameRegestryMod);
                }
            }
            var disabled_dlc = new List<string>();
            foreach (var dlc in list_dlc.Items)
            {
                if (!list_dlc.CheckedItems.Contains(dlc))
                {
                    foreach (var disdlc in dis_dlc)
                    {
                        if (disdlc.name == dlc.ToString()) { disabled_dlc.Add(disdlc.path); }
                    }
                }
            }
            var config = load_items();
            config.enabled_mods = enabled_mods;
            config.disabled_dlcs = disabled_dlc;
            SerializeConfig(config);
            Process.Start(@"hoi4.exe", args);
            Application.Exit();
        }

        private string removeBrackets(string text, string from, string to , bool tolast =true) {
            int pFrom = text.IndexOf(from) + from.Length;
            int pTo = 0;
            if (tolast)
            {
                pTo = text.LastIndexOf(to);
            }
            else {
                pTo = text.IndexOf(to);
            }
            try {
                return text.Substring(pFrom, pTo - pFrom);
            } catch (Exception ex) {
                return "";
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Logger("Application arguments: " +( String.IsNullOrEmpty(args) ? "null" : args));
            this.DoubleBuffered = true;
            Utility.Utility.enableDoubleBuff(tabControl1);
            Utility.Utility.enableDoubleBuff(tabPage1);
            dis_dlc = GetDLCs();
            load();
            updateUI.Elapsed += updateUI_DoWork;
            updateUI.Start();
        }

        private void updateUI_DoWork(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.InvokeEx(x => updateUIinvokable());
            }
            catch (Exception ex) { }
        }

        private void updateModsCount(int count, int maxCount) {
            label_mods.Text = "Mods: " + count + "/" + maxCount;
        }

     private void updateUIinvokable()
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                updateModsCount(list_mods.CheckedItems.Count, modsCount);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                checkFor3rdParty();
            }
        }
        private void checkFor3rdParty()
        {
            bool is3rdParty = false;
            foreach (var dlc in dis_dlc)
            {
                if (dlc._3rdparty && list_dlc.CheckedItems.Contains(dlc.name))
                {
                    is3rdParty = true;
                    break;
                }
                else
                    is3rdParty = false;
            }
            userControl11._3rdParty = is3rdParty;
        }
        public void Logger(string log)
        {
            this.textBox1.InvokeEx(tx => tx.Text += "[" + DateTime.Now + "] " + log + System.Environment.NewLine);
        }
    }
}
    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }
