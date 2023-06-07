//using Gecko;
//using Gecko.Events;
using Hoi4_Launcher.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Hoi4_Launcher.Utility
{
    public partial class SteamLink : Form
    {
        Form browserForm = new Form();
       // public GeckoWebBrowser browser = new GeckoWebBrowser { Dock = DockStyle.Fill };
        SteamHandler steam = new SteamHandler();
        Timer backgroundWorker = new Timer(1000);
        public SteamLink()
        {
            InitializeComponent();
            //Xpcom.Initialize("Firefox");
           // browserForm.Width = 500;
           // browserForm.Height = 500;
            //browser.Navigate(steam.steamLogin);
            //browserForm.Controls.Add(browser);
           // browserForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //browserForm.FormClosing += browser_Closing;
           // browser.DocumentCompleted += browserLoad_Complete;
            browserForm.Icon = Hoi4_Launcher.Properties.Resources.hoi4;
           // firstRun = true;
        }

        //private void browserLoad_Complete(object sender, GeckoDocumentCompletedEventArgs e)
        //{
        //    if (browser.Url.ToString() == steam.steamStore)
        //    {
        //        //steam.getUser(browser);
        //        //label1.Text = steam.userAndID[1];
        //        //label1.Visible = true;
        //        //userControl12.Visible = true;
        //        //browserForm.Show();
        //        //steam.getModsImages(browser);
        //    }
        //}

        private void browser_Closing(object sender, FormClosingEventArgs e)
        {
            browserForm.Hide();
            e.Cancel = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_click;
            browserForm.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_normal;
        }

        private void SteamLink_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            backgroundWorker.Elapsed += backgroundWorker1_DoWork;
            backgroundWorker.Start();

            // Release Candidate: disable steam button
            //Remove this when finish implementing steam support
            pictureBox1.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_disabled;
            toolTip1.Show("Steam support is not yet finished thus it is disabled.", this.pictureBox1);
            pictureBox1.Click -= pictureBox1_Click;
            pictureBox1.MouseEnter -= pictureBox1_MouseEnter;
            pictureBox1.MouseLeave -= pictureBox1_MouseLeave;
        }
        bool checkedAut = false;
        bool firstRun = false;
        private void backgroundWorker1_DoWork(object sender, EventArgs e)
        {
            //if (!firstRun)
            //{

            //}
            //if (!checkedAut)
            //{

            //    this.InvokeEx(x => x.steam.isAuthentificated = x.steam.checkIfAuthentificated(x.browser.Url.ToString()));
            //    if (steam.isAuthentificated)
            //    {
            //        //    this.InvokeEx(x => x.browserForm.Hide());
            //        pictureBox1.InvokeEx(pb => pb.Enabled = false);
            //        pictureBox1.InvokeEx(pb => pb.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_disabled);
            //        this.InvokeEx(x => x.label5.Text = "You are logged in");
            //        checkedAut = true;
            //    }
            //    else
            //    {
            //        pictureBox1.InvokeEx(pb => pb.Enabled = true);
            //        pictureBox1.InvokeEx(pb => pb.BackgroundImage = Hoi4_Launcher.Properties.Resources.steam_normal);
            //        this.InvokeEx(x => x.label5.Text = "You are not logged in");
            //        label1.InvokeEx(pb => pb.Visible = false);
            //        userControl12.InvokeEx(pb => pb.Visible = false);
            //    }
            //}
        }

        //private void userControl12_Click(object sender, EventArgs e)
        //{
        //    using (AutoJSContext context = new AutoJSContext(browser.Window)) {
        //        string result = "";
        //        context.EvaluateScript("Logout()", out result);
        //        if (result != "")
        //            browserForm.Hide();
        //        browser.DocumentCompleted += navigateToLogin_Complete;
        //    }
        //    checkedAut = false;
        //}

        //private void navigateToLogin_Complete(object sender, GeckoDocumentCompletedEventArgs e) {
        //    browser.Navigate(steam.steamLogin);
        //    browser.DocumentCompleted -= navigateToLogin_Complete;
        //}
        //private void navigateToLogin_LoginPage(object sender, GeckoDocumentCompletedEventArgs e)
        //{
        //    if (browser.Url.ToString() == steam.steamLogin) { 

        //    }
        //}
    }
}
