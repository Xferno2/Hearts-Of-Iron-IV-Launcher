namespace Hoi4_Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.userControl11 = new ImgButton.UserControl1();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new Hoi4_Launcher.Utility.CustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.list_dlc = new Hoi4_Launcher.Utility.TransparentCLB();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.userControl13 = new ImgButton.UserControl1();
            this.userControl12 = new ImgButton.UserControl1();
            this.list_mods = new Hoi4_Launcher.Utility.TransparentDVG();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.categoriesBox = new System.Windows.Forms.ComboBox();
            this.label_category = new System.Windows.Forms.Label();
            this.label_mods = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list_mods)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_version
            // 
            this.label_version.ForeColor = System.Drawing.Color.Gray;
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(48, 18);
            this.label_version.Text = "Version:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_version});
            this.statusStrip1.Location = new System.Drawing.Point(12, 568);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(978, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // userControl11
            // 
            this.userControl11._3rdParty = false;
            this.userControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userControl11.BackColor = System.Drawing.Color.Transparent;
            this.userControl11.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.play;
            this.userControl11.BackgroundIMG = global::Hoi4_Launcher.Properties.Resources.play;
            this.userControl11.ClickIMG = global::Hoi4_Launcher.Properties.Resources.play_click;
            this.userControl11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControl11.fontLabel = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControl11.HoverIMG = global::Hoi4_Launcher.Properties.Resources.play_hover;
            this.userControl11.Location = new System.Drawing.Point(576, 518);
            this.userControl11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(411, 79);
            this.userControl11.TabIndex = 4;
            this.userControl11.Text = "PLAY";
            this.userControl11.Click += new System.EventHandler(this.UserControl11_Click);
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(894, 8);
            this.metroSetControlBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.metroSetControlBox1.MaximizeBox = false;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = false;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetControlBox1.StyleManager = null;
            this.metroSetControlBox1.TabIndex = 5;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLight";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.degrade2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(427, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 63);
            this.panel2.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12.75F);
            this.tabControl1.Location = new System.Drawing.Point(434, 32);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 411);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Location = new System.Drawing.Point(0, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(544, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "News";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage2.Controls.Add(this.list_dlc);
            this.tabPage2.Location = new System.Drawing.Point(0, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(544, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DLC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // list_dlc
            // 
            this.list_dlc.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.list_dlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_dlc.FormattingEnabled = true;
            this.list_dlc.Location = new System.Drawing.Point(2, 3);
            this.list_dlc.Name = "list_dlc";
            this.list_dlc.Size = new System.Drawing.Size(540, 378);
            this.list_dlc.TabIndex = 0;
            this.list_dlc.SelectedIndexChanged += new System.EventHandler(this.list_dlc_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.userControl13);
            this.tabPage3.Controls.Add(this.userControl12);
            this.tabPage3.Controls.Add(this.list_mods);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.categoriesBox);
            this.tabPage3.Controls.Add(this.label_category);
            this.tabPage3.Controls.Add(this.label_mods);
            this.tabPage3.Location = new System.Drawing.Point(0, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(544, 384);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mods";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControl13
            // 
            this.userControl13._3rdParty = false;
            this.userControl13.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControl13.BackgroundIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl13.ClickIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControl13.fontLabel = new System.Drawing.Font("Calibri", 8.25F);
            this.userControl13.HoverIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl13.Location = new System.Drawing.Point(309, 43);
            this.userControl13.Name = "userControl13";
            this.userControl13.Size = new System.Drawing.Size(84, 29);
            this.userControl13.TabIndex = 13;
            this.userControl13.Text = "Deselect All";
            this.userControl13.Click += new System.EventHandler(this.button2_Click);
            // 
            // userControl12
            // 
            this.userControl12._3rdParty = false;
            this.userControl12.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControl12.BackgroundIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl12.ClickIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControl12.fontLabel = new System.Drawing.Font("Calibri", 8.25F);
            this.userControl12.HoverIMG = global::Hoi4_Launcher.Properties.Resources.button;
            this.userControl12.Location = new System.Drawing.Point(309, 10);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(84, 29);
            this.userControl12.TabIndex = 6;
            this.userControl12.Text = "Clear";
            this.userControl12.Click += new System.EventHandler(this.button1_Click);
            // 
            // list_mods
            // 
            this.list_mods.AllowUserToAddRows = false;
            this.list_mods.AllowUserToDeleteRows = false;
            this.list_mods.AllowUserToResizeColumns = false;
            this.list_mods.AllowUserToResizeRows = false;
            this.list_mods.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.list_mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_mods.CellBackgroundImage = null;
            this.list_mods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.list_mods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.list_mods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.list_mods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_mods.ColumnHeadersVisible = false;
            this.list_mods.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_mods.EnableHeadersVisualStyles = false;
            this.list_mods.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.list_mods.Location = new System.Drawing.Point(0, 87);
            this.list_mods.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.list_mods.MultiSelect = false;
            this.list_mods.Name = "list_mods";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.list_mods.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.list_mods.RowHeadersVisible = false;
            this.list_mods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.list_mods.Size = new System.Drawing.Size(544, 297);
            this.list_mods.TabIndex = 9;
            this.list_mods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            this.list_mods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.list_mods_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search Mod:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 43);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(234, 28);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // categoriesBox
            // 
            this.categoriesBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.categoriesBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoriesBox.FormattingEnabled = true;
            this.categoriesBox.Location = new System.Drawing.Point(70, 10);
            this.categoriesBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.categoriesBox.Name = "categoriesBox";
            this.categoriesBox.Size = new System.Drawing.Size(234, 29);
            this.categoriesBox.Sorted = true;
            this.categoriesBox.TabIndex = 12;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_category.ForeColor = System.Drawing.Color.White;
            this.label_category.Location = new System.Drawing.Point(2, 19);
            this.label_category.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(52, 13);
            this.label_category.TabIndex = 2;
            this.label_category.Text = "Category:";
            // 
            // label_mods
            // 
            this.label_mods.AutoSize = true;
            this.label_mods.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mods.ForeColor = System.Drawing.Color.White;
            this.label_mods.Location = new System.Drawing.Point(398, 19);
            this.label_mods.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_mods.Name = "label_mods";
            this.label_mods.Size = new System.Drawing.Size(49, 19);
            this.label_mods.TabIndex = 1;
            this.label_mods.Text = "Mods:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Location = new System.Drawing.Point(0, 27);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage4.Size = new System.Drawing.Size(544, 384);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 378);
            this.panel1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Location = new System.Drawing.Point(0, 27);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Size = new System.Drawing.Size(544, 384);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Log";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(2, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(540, 378);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            this.AllowResize = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageTransparency = 1F;
            this.ClientSize = new System.Drawing.Size(1002, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.DropShadowEffect = false;
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.ShowLeftRect = false;
            this.ShowTitle = false;
            this.SmallRectThickness = 1;
            this.Text = "HEARTS OF IRON IV LAUNCHER";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroLight";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list_mods)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private ImgButton.UserControl1 userControl13;
        private ImgButton.UserControl1 userControl12;
        private Utility.TransparentDVG list_mods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox categoriesBox;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Label label_mods;
        private System.Windows.Forms.TabPage tabPage2;
        private Utility.TransparentCLB list_dlc;
        private System.Windows.Forms.TabPage tabPage1;
        private Utility.CustomTabControl tabControl1;
        private System.Windows.Forms.ToolStripStatusLabel label_version;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ImgButton.UserControl1 userControl11;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}

