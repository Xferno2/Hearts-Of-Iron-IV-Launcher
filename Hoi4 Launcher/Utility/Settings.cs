
using Gecko;
using Hoi4_Launcher.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoi4_Launcher.Utility
{
    public partial class Settings : Form
    {
    public Settings()
        {
            InitializeComponent();

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            if (Properties.Settings.Default.generateDescriptor)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox1.Text = Properties.Settings.Default.startArguments;
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


        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.generateDescriptor = true;
            }
            else
            {
                Properties.Settings.Default.generateDescriptor = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startArguments = textBox1.Text;
        }
    }
}
