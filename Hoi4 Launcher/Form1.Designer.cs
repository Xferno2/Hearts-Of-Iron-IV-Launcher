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
            this.button_play = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_category = new System.Windows.Forms.Label();
            this.label_mods = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.label_version = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.list_mods = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(722, 538);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(199, 45);
            this.button_play.TabIndex = 0;
            this.button_play.Text = "PLAY";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.Button_play_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(330, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(583, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "News";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(583, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DLC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.list_mods);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label_category);
            this.tabPage3.Controls.Add(this.label_mods);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(583, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mods";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(61, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(410, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Location = new System.Drawing.Point(3, 12);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(52, 13);
            this.label_category.TabIndex = 2;
            this.label_category.Text = "Category:";
            // 
            // label_mods
            // 
            this.label_mods.AutoSize = true;
            this.label_mods.Location = new System.Drawing.Point(477, 13);
            this.label_mods.Name = "label_mods";
            this.label_mods.Size = new System.Drawing.Size(36, 13);
            this.label_mods.TabIndex = 1;
            this.label_mods.Text = "Mods:";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(583, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(583, 443);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Console";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(577, 437);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(12, 570);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(42, 13);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "Version";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // list_mods
            // 
            this.list_mods.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_mods.FormattingEnabled = true;
            this.list_mods.Location = new System.Drawing.Point(0, 34);
            this.list_mods.Name = "list_mods";
            this.list_mods.Size = new System.Drawing.Size(583, 409);
            this.list_mods.Sorted = true;
            this.list_mods.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 608);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_play);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_mods;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.CheckedListBox list_mods;
    }
}

