using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PaintPlus
{
    public partial class FormHatchStyleDlg : Form
    {
        protected HatchStyle style = HatchStyle.Percent05;

        protected Bitmap[] images = new Bitmap[53];
        protected Bitmap review_image = null;
        protected Button[] hatch_image_btns = new Button[53];

        public HatchStyle Style
        {
            get { return style; }
        }

        public FormHatchStyleDlg()
        {
            InitializeComponent();
            InitHatchImages();
        }

        protected void InitHatchImages()
        {
            InitButtonArray();

            for (int ii = 0; ii < images.Length; ii++)
            {
                images[ii] = new Bitmap(32, 23);
                FillImageByHatch(images[ii], (HatchStyle)ii);
                hatch_image_btns[ii].Image = images[ii];
                hatch_image_btns[ii].Click += new EventHandler(OnHatchImageButtonsClick);
            }

            review_image = new Bitmap(pictureboxHatchPreview.Width, pictureboxHatchPreview.Height);
            pictureboxHatchPreview.Image = review_image;

        }

        protected void FillImageByHatch(Image img, HatchStyle s)
        {
            Graphics g = Graphics.FromImage(img);
            HatchBrush brush = new HatchBrush(s, Color.Black, Color.White);
            g.FillRectangle(brush, new Rectangle(0, 0, img.Width, img.Height));
            g.Dispose();
        }

        protected void OnHatchImageButtonsClick(object sender, EventArgs e)
        {
            for (int ii = 0; ii < images.Length; ii++)
            {
                if (hatch_image_btns[ii] == sender)
                {
                    style = (HatchStyle)ii;
                    FillImageByHatch(review_image, style);
                    pictureboxHatchPreview.Refresh();
                    label1.Text = style.ToString();
                    break;
                }

            }
        }

        protected void InitButtonArray()
        {
            hatch_image_btns[0] = button1;
            hatch_image_btns[1] = button2;
            hatch_image_btns[2] = button3;
            hatch_image_btns[3] = button4;
            hatch_image_btns[4] = button5;
            hatch_image_btns[5] = button6;
            hatch_image_btns[6] = button7;
            hatch_image_btns[7] = button8;
            hatch_image_btns[8] = button9;
            hatch_image_btns[9] = button10;
            hatch_image_btns[10] = button11;
            hatch_image_btns[11] = button12;
            hatch_image_btns[12] = button13;
            hatch_image_btns[13] = button14;
            hatch_image_btns[14] = button15;
            hatch_image_btns[15] = button16;
            hatch_image_btns[16] = button17;
            hatch_image_btns[17] = button18;
            hatch_image_btns[18] = button19;
            hatch_image_btns[19] = button20;
            hatch_image_btns[20] = button21;
            hatch_image_btns[21] = button22;
            hatch_image_btns[22] = button23;
            hatch_image_btns[23] = button24;
            hatch_image_btns[24] = button25;
            hatch_image_btns[25] = button26;
            hatch_image_btns[26] = button27;
            hatch_image_btns[27] = button28;
            hatch_image_btns[28] = button29;
            hatch_image_btns[29] = button30;
            hatch_image_btns[30] = button31;
            hatch_image_btns[31] = button32;
            hatch_image_btns[32] = button33;
            hatch_image_btns[33] = button34;
            hatch_image_btns[34] = button35;
            hatch_image_btns[35] = button36;
            hatch_image_btns[36] = button37;
            hatch_image_btns[37] = button38;
            hatch_image_btns[38] = button39;
            hatch_image_btns[39] = button40;
            hatch_image_btns[40] = button41;
            hatch_image_btns[41] = button42;
            hatch_image_btns[42] = button43;
            hatch_image_btns[43] = button44;
            hatch_image_btns[44] = button45;
            hatch_image_btns[45] = button46;
            hatch_image_btns[46] = button47;
            hatch_image_btns[47] = button48;
            hatch_image_btns[48] = button49;
            hatch_image_btns[49] = button50;
            hatch_image_btns[50] = button51;
            hatch_image_btns[51] = button52;
            hatch_image_btns[52] = button53;
        }
    }
}
