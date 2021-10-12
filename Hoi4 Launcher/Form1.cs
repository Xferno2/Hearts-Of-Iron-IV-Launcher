using Hoi4_Launcher.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using Hoi4_Launcher.Utility;
using System.Drawing.Imaging;

namespace Hoi4_Launcher
{
    public partial class Form1 : MetroSet_UI.Forms.MetroSetForm
    {
        private static string ParadoxFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Paradox Interactive");
        private static string Hoi4_Doc = Path.Combine(ParadoxFolder, "Hearts of Iron IV");
        private static string Hoi4_Enb_Mods = Path.Combine(Hoi4_Doc, "dlc_load.json");
        private static string Hoi4_Mods = Path.Combine(Hoi4_Doc, "mod");
        private static dlcModel[] dis_dlc = null;

        private static List<newModInfo> globalMods;

        private static LHSettings gameSettings = new LHSettings();
        private string args;

        Timer updateUI = new Timer(100);

        static launchSettings data = new launchSettings();

        internal DataTable modsTable = new DataTable();
        internal DataTable imEmpty = new DataTable();

        public Util utilityClass = new Util();

        public Form1(string[] args)
        {
            foreach (var arg in args)
            {
                this.args += arg + " ";
            }
            InitializeComponent();
            var steamLink = new SteamLink { Dock = DockStyle.Fill, TopLevel = false };
            panel2.Controls.Add(steamLink) ;
            steamLink.Show();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
             //   cp.Style &= ~~0x02000000; // Turn off WS_CLIPCHILDREN
                return cp;
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            modsTable.Columns.Add("IMG", typeof(Image));
            modsTable.Columns.Add("ENABLE", typeof(bool));
            modsTable.Columns.Add("NAME", typeof(string));
            modsTable.Columns.Add("MESSAGE", typeof(bool));
            list_mods.DataSource = modsTable;
            list_mods.Columns[0].Width = 75;
            list_mods.Columns[1].Width = 20;
            list_mods.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            list_mods.Sort(list_mods.Columns["NAME"], ListSortDirection.Ascending);
            list_mods.RowTemplate.Height = 75;
            list_mods.Columns["MESSAGE"].Visible = false;
            imEmpty.Columns.Add("ph1", typeof(Nullable));
            imEmpty.Columns.Add("ph2", typeof(Nullable));
            imEmpty.Columns.Add("NAME", typeof(string));
            imEmpty.Rows.Add(null, null, "Nothing here huh");


            //Release Candidate disable settings
            //Remove this when Finished
            //Settings settingsForm = new Settings();
            //settingsForm.TopLevel = false;
            //settingsForm.AutoScroll = true;
            //settingsForm.Dock = DockStyle.Fill;
            //panel1.Controls.Add(settingsForm);
            //settingsForm.Show();


            //panel1.AutoScroll = true;


            categoriesBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Logger("Application arguments: " + (String.IsNullOrEmpty(args) ? "null" : args));
            this.DoubleBuffered = true;
            Util.enableDoubleBuff(tabControl1);
            Util.enableDoubleBuff(tabPage1);
            dis_dlc = GetDLCs();
            load();
            updateUI.Elapsed += updateUI_DoWork;
            updateUI.Start();
        }

        private void load()
        {
            //Load Mods
            var items = load_items();
            globalMods = load_mods_info();
            generateCategories();
            int enabled_mods = 0;
            foreach (var mod in globalMods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegestryMod)) { enabled = true; enabled_mods++; }
                modsTable.Rows.Add(mod.picture, enabled, mod.displayName, false);

            }
            updateModsCount(enabled_mods, globalMods.Count);

            //Load DLC
            foreach (var dlc in dis_dlc)
            {
                bool enabled = true;
                if (items.disabled_dlcs.Contains(dlc.path)) { enabled = false; }
                list_dlc.Items.Add(dlc.name, enabled);
            }
            //Load LHSetthings
            string data = File.ReadAllText(@"launcher-settings.json");
            gameSettings = JsonConvert.DeserializeObject<LHSettings>(data);
            label_version.Text += " " + gameSettings.version;
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
                //   if (mod.gameRegestryMod == "mod/ugc_1395409185.mod")
                //   {
                //        Debugger.Break();
                //   }
                var modFiles = File.ReadAllLines(file.FullName);
                var modFileWhole = File.ReadAllText(file.FullName);
                foreach (var modFile in modFiles) {
                    if (modFile.Contains("name=")) {
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
                    //            mod.picture = Util.ResizeImage(Util.parseImage(mod.dirPath, modFile.Split('=')[1].Replace("\"", "")), 75, 75);
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
                        var tagsNotFormated = removeBrackets(searchInText, "tags={", "}", false);
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
                                if (!isItemInList)
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
                    if (party == "yes")
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
        List<string> enabled_mods = new List<string>();
        private void UserControl11_Click(object sender, EventArgs e)
        {
            checkForMods();
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

        private string removeBrackets(string text, string from, string to, bool tolast = true) {
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
                return text;
            }
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
                //   if (list_mods.DataSource != modsTable)
                //   { list_mods.DataSource = modsTable; }
                updateModsCount(enabled_mods.Count, globalMods.Count);
                updateCategories();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                checkFor3rdParty();
            }
        }

        public void checkBox() {
            if (list_mods.DataSource != imEmpty)
            {
                if ((bool)list_mods.SelectedRows[0].Cells["ENABLE"].Value == false)
                {
                    list_mods.SelectedRows[0].Cells["ENABLE"].Value = true;
                }
                else
                {
                    list_mods.SelectedRows[0].Cells["ENABLE"].Value = false;
                }
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
        Dictionary<DataTable, string> generatedTables = new Dictionary<DataTable, string>();
        private void generateCategories()
        {
            foreach (var category in categoriesBox.Items)
            {
                DataTable currentCategory = new DataTable();
                currentCategory.Columns.Add("IMG", typeof(Image));
                currentCategory.Columns.Add("ENABLE", typeof(bool));
                currentCategory.Columns.Add("NAME", typeof(string));
                currentCategory.Columns.Add("MESSAGE", typeof(bool));
                foreach (var mod in globalMods)
                {
                    foreach (var tag in mod.tags)
                    {
                        if (tag.ToLower() == category.ToString().ToLower())
                        {
                            if (enabled_mods.Contains(mod.gameRegestryMod))
                            {
                                currentCategory.Rows.Add(mod.picture, true, mod.displayName, false);
                            }
                            else
                            {
                                currentCategory.Rows.Add(mod.picture, false, mod.displayName, false);
                            }
                        }
                    }
                }
                generatedTables.Add(currentCategory, category.ToString());
            }
        }
        DataTable lastTable;
        private void updateRowsFilter(string text, DataTable table)
        {
            if (lastTable == null)
            {
                 lastTable = (list_mods.DataSource as DataTable);
            }
            else {
                if (lastTable.DefaultView.Count == 0 )
                {
                    if (list_mods.DataSource != imEmpty)
                        list_mods.DataSource = imEmpty;
                    lastTable.DefaultView.RowFilter = string.Format("NAME LIKE '{0}%'", text);

                }
                else
                {
                    list_mods.DataSource = table;
                    list_mods.Columns["MESSAGE"].Visible = false;
                    lastTable = (list_mods.DataSource as DataTable);
                    (list_mods.DataSource as DataTable).DefaultView.RowFilter = string.Format("NAME LIKE '{0}%'", text);
                }

            }

        }

        private void updateCategories()
        {
            checkForMods();
            if (categoriesBox.Text !=null && !String.IsNullOrEmpty(categoriesBox.Text) && !String.IsNullOrWhiteSpace(categoriesBox.Text) && !categoriesBox.DroppedDown)
            {
                for (int i = 0; i <= categoriesBox.Items.Count; i++)
                {
                    if (categoriesBox.SelectedItem.ToString() == categoriesBox.Items.IndexOf(i).ToString())
                    {
                        categoriesBox.SelectedItem = categoriesBox.Items.IndexOf(i);
                    }
                }
            }
            if (categoriesBox.SelectedItem == null || String.IsNullOrEmpty(categoriesBox.SelectedItem.ToString()) || String.IsNullOrWhiteSpace(categoriesBox.SelectedItem.ToString()))
            {
                if (modsTable.Rows.Count <= globalMods.Count)
                {
                    if (lastTable != modsTable)
                    {
                        lastTable = modsTable;
                    }
                    updateRowsFilter(textBox2.Text, modsTable);
                }
            }
            else
            {
                foreach (var category in generatedTables) {
                    if (category.Value == categoriesBox.SelectedItem.ToString())
                    {if (lastTable != category.Key) {
                            lastTable = category.Key;
                        }
                        updateRowsFilter(textBox2.Text, category.Key);
                    }
                }
            }

        }
        public void checkForMods() {
            foreach (var mod in globalMods)
            {
                foreach (DataGridViewRow row in list_mods.Rows)
                {if (list_mods.DataSource != imEmpty)
                    {
                        if (Convert.ToBoolean(row.Cells[1].Value) && Convert.ToString(row.Cells[2].Value) == mod.displayName)
                        {
                            if (mod.displayName != null && !enabled_mods.Contains(mod.gameRegestryMod))
                            {
                                Logger("Checking: " + mod.displayName);
                                enabled_mods.Add(mod.gameRegestryMod);
                            }

                        }
                        else if (!Convert.ToBoolean(row.Cells[1].Value) && Convert.ToString(row.Cells[2].Value) == mod.displayName)
                        {
                            if (mod.displayName != null && enabled_mods.Contains(mod.gameRegestryMod))
                            {
                                Logger("Unchecking: " + mod.displayName);
                                enabled_mods.Remove(mod.gameRegestryMod);
                            }
                        }
                    }
                }
            }
        }

        public void Logger(string log)
        {
            this.textBox1.InvokeEx(tx => tx.Text += "[" + DateTime.Now + "] " + log + System.Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger("I'm clear button and I've been clicked");
            //categoriesBox.DroppedDown = false;
            textBox2.Text = "";
            categoriesBox.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in list_mods.Rows)
            {
                if (Convert.ToBoolean(row.Cells[1].Value)) {
                    row.Cells[1].Value = false;
                }
            }
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBox();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void label_mods_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(categoriesBox.Text))
            {
                updateRowsFilter(textBox2.Text, modsTable);
            }
            else {
                updateRowsFilter(textBox2.Text, generatedTables.First(x => x.Value.Equals(categoriesBox.Text)).Key);
            }
        }

        private void list_mods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userControl12_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
