using Hoi4_Launcher.Model;
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

namespace Hoi4_Launcher
{
    public partial class Form1 : Form
    {
        private static string ParadoxFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Paradox Interactive");
        private static string Hoi4_Doc = Path.Combine(ParadoxFolder, "Hearts of Iron IV");
        private static string Hoi4_Enb_Mods = Path.Combine(Hoi4_Doc, "dlc_load.json");
        private static string Hoi4_Mods = Path.Combine(Hoi4_Doc, "mods_registry.json");

        ThreadStart threadStart;
        Thread myUpdatedThread;

        static loadItems data = new loadItems();
        public Form1()
        {
            InitializeComponent();
            loadMods();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public loadItems load_items()
        {
            loadItems obj;

            string data = File.ReadAllText(Hoi4_Enb_Mods);
            obj = JsonConvert.DeserializeObject<loadItems>(data);
            return obj;
        }

        public modInfo[] load_mods_info() {

            string data = File.ReadAllText(Hoi4_Mods);
            JObject mods = JObject.Parse(data);

            // get JSON result objects into a list
            IList<JToken> results = mods.Children().Children().ToList();

            // serialize JSON results into .NET objects
            IList<modInfo> modsList = new List<modInfo>();

            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                modInfo mod = result.ToObject<modInfo>();
                modsList.Add(mod);
            }
            return modsList.ToArray();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void loadMods() {
            var items = load_items();
            var mods = load_mods_info();
            int enabled_mods = 0;
            foreach (var mod in mods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegistryId)) { enabled = true; enabled_mods++; }
                list_mods.Items.Add(mod.displayName, enabled);
            }
            label_mods.Text = "Mods: " + enabled_mods + "/" + mods.Length;
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_play_Click(object sender, EventArgs e)
        {
            var mods = load_mods_info();
            var enabled_mods = new List<string>();
            foreach (var mod in mods)
            {
                if (list_mods.CheckedItems.Contains(mod.displayName))
                {
                    if (mod.gameRegistryId != null)
                    enabled_mods.Add(mod.gameRegistryId);
                }
            }
            var config = load_items();
            config.enabled_mods = enabled_mods;
            SerializeConfig(config);
            Process.Start(@"hoi4.exe");
            Application.Exit();
        }

        public void SerializeConfig(object x)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            File.WriteAllText(Hoi4_Enb_Mods, JsonConvert.SerializeObject(x, Formatting.Indented, settings));
        }
    }

}
