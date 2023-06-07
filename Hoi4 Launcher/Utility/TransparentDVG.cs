using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hoi4_Launcher.Utility;

namespace Hoi4_Launcher.Utility
{
    class TransparentDVG : DataGridView
    {
        private DataGridView dataGridView1;

        public Image CellBackgroundImage { get; set; }
        private Image[] CellBackgroundImageDevided { get; set; }

        public TransparentDVG() {
            this.BorderStyle = BorderStyle.None;
            InitializeComponent();
        }


        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
        //    base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.PaintBackground(graphics, clipBounds, gridBounds);
            Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);

            Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
            if (this.Parent.BackgroundImage != null)
            {
                Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);
            }
            else {
                Graphics.FromImage(b).DrawImage(this.Parent.Parent.Parent.BackgroundImage, Parent.Parent.Parent.ClientRectangle);
            }

            graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
            SetCellsTransparent();
        }


        public void SetCellsTransparent()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;

            foreach (DataGridViewColumn col in this.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Transparent;
                col.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // TransparentDVG
            // 
            this.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.Graphics.DrawImage(Hoi4_Launcher.Properties.Resources.button_Mod, e.RowBounds);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawImage(Hoi4_Launcher.Properties.Resources.button_Mod, e.RowBounds);
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.CellBackgroundImageDevided == null)
            {
                if (CellBackgroundImage != null)
                {
                    List<Rectangle> rectagles = new List<Rectangle>();
                    foreach (DataGridViewColumn column in this.dataGridView1.Columns.Cast<DataGridViewColumn>())
                    {
                        if (rectagles.Count != 0)
                        {
                            //TO DO
                            rectagles.Add(new Rectangle(new Point(rectagles.Last().X + column.Width, 0), new Size(column.Width, this.dataGridView1.RowTemplate.Height)));
                        }
                        else
                        {
                            rectagles.Add(new Rectangle(new Point(0, 0), new Size(column.Width, this.dataGridView1.RowTemplate.Height)));
                        }
                    }
                    CellBackgroundImageDevided = resizeImageForCell(CellBackgroundImage, rectagles.ToArray());
                }
                if (e.RowIndex != -1 && this.CellBackgroundImage != null)
                {
                    if ((e.PaintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
                    {
                        e.Graphics.DrawImage(CellBackgroundImageDevided[e.ColumnIndex], e.CellBounds);
                    }
                    if (!e.Handled)
                    {
                        e.Handled = true;
                        e.PaintContent(e.CellBounds);
                    }
                }
            }
        }

        private Image[] resizeImageForCell(Image image, params Rectangle[] rectangles) {
            List<Image> imageList = new List<Image>();
            foreach (var rectangle in rectangles) {
                var bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(image, 0, 0, rectangle, GraphicsUnit.Pixel);
                    imageList.Add(bitmap);
                }
            }
            return imageList.ToArray();
        }
    }
}
