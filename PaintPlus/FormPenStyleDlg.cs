using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaintPlus
{
    public partial class FormPenStyleDlg : Form
    {
        private System.Windows.Forms.ColorDialog colorDialog1 = new ColorDialog();
        private Color foreColor = Color.Black;
        private Color backColor = Color.White;
        private int penWidth = 3;
        private DrawMethod.PEN_TYPE penType = DrawMethod.PEN_TYPE.NOMAL;

        public Color PenForeColor
        {
            get{  return foreColor;}
        }
        public Color PenBackColor
        {
            get { return backColor; }
        }
        public int PenWidth
        {
            get { return penWidth; }
        }
        public DrawMethod.PEN_TYPE PenType
        {
            get { return penType; }
        }

        public FormPenStyleDlg()
        {
            InitializeComponent();
        }

        public void InitData(Color penForeColor, Color penBackColor, int width, DrawMethod.PEN_TYPE type)
        {
            foreColor = penForeColor;
            backColor = penBackColor;
            penWidth = width;
            penType = type;

            InitPenImages();

            switch(penType)
            {
                case DrawMethod.PEN_TYPE.NOMAL:
                    switch (penWidth)
                    {
                        case 3:
                            radioButtonPenSize1.Select();
                            break;
                        case 5:
                            radioButtonPenSize2.Select();
                            break;
                        case 7:
                            radioButtonPenSize3.Select();
                            break;
                        case 9:
                            radioButtonPenSize4.Select();
                            break;
                        case 11:
                            radioButtonPenSize5.Select();
                            break;
                    }
                    break;
                case DrawMethod.PEN_TYPE.HEMMED:
                    switch (penWidth)
                    {
                        case 3:
                            radioButtonHummPenSize1.Select();
                            break;
                        case 5:
                            radioButtonHummPenSize2.Select();
                            break;
                        case 7:
                            radioButtonHummPenSize3.Select();
                            break;
                        case 9:
                            radioButtonHummPenSize4.Select();
                            break;
                        case 11:
                            radioButtonHummPenSize5.Select();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void InitPenImages()
        {
            Pen pen = new Pen(foreColor, 3);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Bitmap image1 = new Bitmap(pictPenStyleNorm1.Width, pictPenStyleNorm1.Height);
            Point pt1 = new Point(pictPenStyleNorm1.Width / 2 - 5, pictPenStyleNorm1.Height / 2 - 5);
            Point pt2 = new Point(pictPenStyleNorm1.Width / 2 + 5, pictPenStyleNorm1.Height / 2 + 5);
            Graphics g = Graphics.FromImage(image1);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleNorm1.Width, pictPenStyleNorm1.Height));
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleNorm1.Image = image1;

            pen.Width = 5;
            Bitmap image2 = new Bitmap(pictPenStyleNorm2.Width, pictPenStyleNorm2.Height);
            g = Graphics.FromImage(image2);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleNorm2.Width, pictPenStyleNorm2.Height));
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleNorm2.Image = image2;

            pen.Width = 7;
            Bitmap image3 = new Bitmap(pictPenStyleNorm3.Width, pictPenStyleNorm3.Height);
            g = Graphics.FromImage(image3);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleNorm3.Width, pictPenStyleNorm3.Height));
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleNorm3.Image = image3;

            pen.Width = 9;
            Bitmap image4 = new Bitmap(pictPenStyleNorm4.Width, pictPenStyleNorm4.Height);
            g = Graphics.FromImage(image4);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleNorm4.Width, pictPenStyleNorm4.Height));
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleNorm4.Image = image4;

            pen.Width = 11;
            Bitmap image5 = new Bitmap(pictPenStyleNorm5.Width, pictPenStyleNorm5.Height);
            g = Graphics.FromImage(image5);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleNorm5.Width, pictPenStyleNorm5.Height));
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleNorm5.Image = image5;

            Pen pen2 = new Pen(backColor, 5);
            pen2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen2.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Width = 3;
            Bitmap image6 = new Bitmap(pictPenStyleHemm1.Width, pictPenStyleHemm1.Height);
            g = Graphics.FromImage(image6);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleHemm1.Width, pictPenStyleHemm1.Height));
            g.DrawLine(pen2, pt1, pt2);
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleHemm1.Image = image6;

            pen.Width = 5;
            pen2.Width = 7;
            Bitmap image7 = new Bitmap(pictPenStyleHemm2.Width, pictPenStyleHemm2.Height);
            g = Graphics.FromImage(image7);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleHemm2.Width, pictPenStyleHemm2.Height));
            g.DrawLine(pen2, pt1, pt2);
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleHemm2.Image = image7;

            pen.Width = 7;
            pen2.Width = 9;
            Bitmap image8 = new Bitmap(pictPenStyleHemm3.Width, pictPenStyleHemm3.Height);
            g = Graphics.FromImage(image8);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleHemm3.Width, pictPenStyleHemm3.Height));
            g.DrawLine(pen2, pt1, pt2);
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleHemm3.Image = image8;

            pen.Width = 9;
            pen2.Width = 11;
            Bitmap image9 = new Bitmap(pictPenStyleHemm4.Width, pictPenStyleHemm4.Height);
            g = Graphics.FromImage(image9);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleHemm4.Width, pictPenStyleHemm4.Height));
            g.DrawLine(pen2, pt1, pt2);
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleHemm4.Image = image9;

            pen.Width = 11;
            pen2.Width = 13;
            Bitmap image10 = new Bitmap(pictPenStyleHemm5.Width, pictPenStyleHemm5.Height);
            g = Graphics.FromImage(image10);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictPenStyleHemm5.Width, pictPenStyleHemm5.Height));
            g.DrawLine(pen2, pt1, pt2);
            g.DrawLine(pen, pt1, pt2);
            g.Dispose();
            pictPenStyleHemm5.Image = image10;

            Bitmap image11 = new Bitmap(pictPenStyleForeColor.Width, pictPenStyleForeColor.Height);
            g = Graphics.FromImage(image11);
            g.FillRectangle(new SolidBrush(pen.Color), new Rectangle(0, 0, pictPenStyleForeColor.Width, pictPenStyleForeColor.Height));
            g.Dispose();
            pictPenStyleForeColor.Image = image11;

            Bitmap image12 = new Bitmap(pictPenStyleBackColor.Width, pictPenStyleBackColor.Height);
            g = Graphics.FromImage(image12);
            g.FillRectangle(new SolidBrush(pen2.Color), new Rectangle(0, 0, pictPenStyleBackColor.Width, pictPenStyleBackColor.Height));
            g.Dispose();
            pictPenStyleBackColor.Image = image12;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (radioButtonPenSize1.Checked) { 
                penWidth = 3;
                penType = DrawMethod.PEN_TYPE.NOMAL;
            }
            else if (radioButtonPenSize2.Checked) { 
                penWidth = 5;
                penType = DrawMethod.PEN_TYPE.NOMAL;
            }
            else if (radioButtonPenSize3.Checked) { 
                penWidth = 7;
                penType = DrawMethod.PEN_TYPE.NOMAL;
            }
            else if (radioButtonPenSize4.Checked) { 
                penWidth = 9;
                penType = DrawMethod.PEN_TYPE.NOMAL;
            }
            else if (radioButtonPenSize5.Checked) { 
                penWidth = 11;
                penType = DrawMethod.PEN_TYPE.NOMAL;
            }
            else if (radioButtonHummPenSize1.Checked) { 
                penWidth = 3;
                penType = DrawMethod.PEN_TYPE.HEMMED;
            }
            else if (radioButtonHummPenSize2.Checked) { 
                penWidth = 5;
                penType = DrawMethod.PEN_TYPE.HEMMED;
            }
            else if (
                radioButtonHummPenSize3.Checked) { 
                penWidth = 7; 
            }
            else if (radioButtonHummPenSize4.Checked) {
                penType = DrawMethod.PEN_TYPE.HEMMED;
                penWidth = 9;
            }
            else if (radioButtonHummPenSize5.Checked) {
                penType = DrawMethod.PEN_TYPE.HEMMED;
                penWidth = 11;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void pictPenStyleForeColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            foreColor = colorDialog1.Color;
            InitPenImages();
        }

        private void pictPenStyleBackColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            backColor = colorDialog1.Color;
            InitPenImages();
        }

    }
}
