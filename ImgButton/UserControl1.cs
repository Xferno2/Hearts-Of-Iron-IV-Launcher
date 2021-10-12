using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgButton
{
    public partial class UserControl1 : UserControl
    {
        [Category("Custom")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public UserControl1()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            label1.Click += this.UserControl1_Click;
         //   base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseHover += new System.EventHandler(UserControl1_Hover);
            pictureBox1.MouseHover += new System.EventHandler(UserControl1_Hover);
            label1.MouseHover += new System.EventHandler(UserControl1_Hover);

            this.MouseLeave += new System.EventHandler(UserControl1_Leave);

            this.Click += new System.EventHandler(UserControl1_Click);
            pictureBox1.Click += new System.EventHandler(UserControl1_Click);
            label1.Click += new System.EventHandler(UserControl1_Click);
            this.BackgroundImage = BackgroundIMG;
        }
        private void UserControl1_Hover(object sender, EventArgs e)
        {
            this.BackgroundImage = HoverIMG;
        }
        private void UserControl1_Leave(object sender, EventArgs e)
        {
            this.BackgroundImage = BackgroundIMG;
        }
        private void UserControl1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = ClickIMG;
        }

        public bool _3rdParty {
            get { return pictureBox1.Visible; }
            set { pictureBox1.Visible = value; }
        }
        public Font fontLabel
        {
            get { return label1.Font; }
            set { label1.Font = value; }
        }
        public Image BackgroundIMG {
            get; set;
        }
        public Image ClickIMG {
            get; set;
        }
        public Image HoverIMG {
            get; set;
        }


        private void label_Hover(object sender, EventArgs e)
        {
            this.BackgroundImage = HoverIMG;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = BackgroundIMG;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = ClickIMG;
        }
        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }
    }
}
