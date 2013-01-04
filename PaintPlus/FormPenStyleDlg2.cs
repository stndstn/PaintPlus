using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaintPlus
{
    public partial class FormPenStyleDlg2 : Form
    {
        private System.Windows.Forms.ColorDialog colorDialog1 = new ColorDialog();
        private Color foreColor = Color.Black;
        private Color backColor = Color.White;
        private int penWidth = 1;
        private int hemmWidth = 1;
        private DrawMethod.PEN_TYPE penType = DrawMethod.PEN_TYPE.NOMAL;
        string[] penWidthItems = {"3pt","5pt","7pt","9pt","11pt","15pt","19pt","25pt","29pt","39pt"};
        int[] penWidthValues = {3,5,7,9,11,15,19,25,29,39};
        string[] hemmWidthItems = { "None", "1pt", "3pt", "5pt", "7pt", "9pt" };
        int[] hemmWidthValues = { 0, 1, 3, 5, 7, 9 };


        //property
        public Color PenForeColor
        {
            get { return foreColor; }
        }
        public Color PenBackColor
        {
            get { return backColor; }
        }
        public int PenWidth
        {
            get { return penWidth; }
        }
        public int HemmWidth
        {
            get { return hemmWidth; }
        }
        public DrawMethod.PEN_TYPE PenType
        {
            get { return penType; }
        }


        public FormPenStyleDlg2()
        {
            InitializeComponent();
        }

        public void InitData(Color penForeColor, Color penBackColor, int width, int hemm, DrawMethod.PEN_TYPE type)
        {
            foreColor = penForeColor;
            backColor = penBackColor;
            penWidth = width;
            hemmWidth = hemm;
            penType = type;
            string itemPenWidth = String.Format("{0:d}pt", penWidth);
            string itemHemmWidth = (hemmWidth == 0) ? "None" : String.Format("{0:d}pt", hemmWidth);
            int idx = 0;

            cmbPenSize.Items.Clear();
            cmbPenSize.Items.AddRange(penWidthItems);
            cmbHemmSize.Items.Clear();
            cmbHemmSize.Items.AddRange(hemmWidthItems);
            UpdatePenImage();

            switch (penType)
            {
                case DrawMethod.PEN_TYPE.NOMAL:
                    idx = cmbPenSize.Items.IndexOf(itemPenWidth);
                    cmbPenSize.SelectedIndex = idx;
                    cmbHemmSize.SelectedIndex = 0;
                    break;
                case DrawMethod.PEN_TYPE.HEMMED:
                    idx = cmbPenSize.Items.IndexOf(itemPenWidth);
                    cmbPenSize.SelectedIndex = idx;
                    idx = cmbHemmSize.Items.IndexOf(itemHemmWidth);
                    cmbHemmSize.SelectedIndex = idx;
                    break;
                default:
                    break;
            }
        }
        private void UpdatePenImage()
        {
            Pen pen1 = new Pen(foreColor, PenWidth);
            pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Bitmap image1 = new Bitmap(pictPenStyle.Width, pictPenStyle.Height);
            Point pt1 = new Point(pictPenStyle.Width/3, pictPenStyle.Height/3);
            Point pt2 = new Point(pictPenStyle.Width*2/3 + 10, pictPenStyle.Height*2/3);
            Graphics g = Graphics.FromImage(image1);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyle.Width, pictPenStyle.Height));
            if (HemmWidth > 0)
            {
                Pen pen2 = new Pen(backColor, HemmWidth + PenWidth);
                pen2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen2.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawLine(pen2, pt1, pt2);
            }
            g.DrawLine(pen1, pt1, pt2);
            g.Dispose();
            pictPenStyle.Image = image1;

            Bitmap image2 = new Bitmap(pictPenStyleForeColor.Width, pictPenStyleForeColor.Height);
            g = Graphics.FromImage(image2);
            g.FillRectangle(new SolidBrush(foreColor), new Rectangle(0, 0, pictPenStyleForeColor.Width, pictPenStyleForeColor.Height));
            g.Dispose();
            pictPenStyleForeColor.Image = image2;

            if (hemmWidth == 0)
            {
                pictPenStyleBackColor.Enabled = false;
            }
            else
            {
                pictPenStyleBackColor.Enabled = true;
                Bitmap image3 = new Bitmap(pictPenStyleBackColor.Width, pictPenStyleBackColor.Height);
                g = Graphics.FromImage(image3);
                g.FillRectangle(new SolidBrush(backColor), new Rectangle(0, 0, pictPenStyleBackColor.Width, pictPenStyleBackColor.Height));
                g.Dispose();
                pictPenStyleBackColor.Image = image3;
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            penType = (hemmWidth == 0) ? DrawMethod.PEN_TYPE.NOMAL : DrawMethod.PEN_TYPE.HEMMED;
            
        }

        private void cmbPenSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxPenWidth = cmbPenSize.SelectedIndex;
            penWidth = penWidthValues[idxPenWidth];
            UpdatePenImage();
        }

        private void cmbHemmSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxHemmWidth = cmbHemmSize.SelectedIndex;
            hemmWidth = hemmWidthValues[idxHemmWidth];
            UpdatePenImage();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void pictPenStyleForeColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            foreColor = colorDialog1.Color;
            UpdatePenImage();
        }

        private void pictPenStyleBackColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            backColor = colorDialog1.Color;
            UpdatePenImage();
        }

    }
}
