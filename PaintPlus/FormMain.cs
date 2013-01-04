using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaintPlus
{
    public partial class FormMain : Form
    {
        public enum OPERATION
        {
            NONE, DRAWING,
            SEL_GRAD_PT_ST, SEL_GRAD_PT_EN,
            PASTE_IMG_SELECTED, PASTE_IMG_DRAG,
            COPY_IMG_SEL_ST, COPY_IMG_DRAG, COPY_IMG_SELECTED,
            SET_TEXT_POS, EDIT_TEXT
        };
        private OPERATION operation = OPERATION.NONE;
        private Point ptGradStart;
        private Point ptGradEnd;
        private DrawMethod drawmethod;
        private FreeDraw freedraw;
        private LineDraw linedraw;
        private RectDraw rectdraw;
        private FloodFill floodfill;
        private RectFill rectfill;
        private StringDraw stringdraw;
        private SelectRectToCopy copyrect;
/*
        private ListViewItem itemFreeDraw = new ListViewItem("drawfree");
        private ListViewItem itemLineDraw = new ListViewItem("drawline");
        private ListViewItem itemRectDraw = new ListViewItem("drawrect");
        private ListViewItem itemFillFlood = new ListViewItem("fillflood");
        private ListViewItem itemFillRect = new ListViewItem("fillrect");
        private ListViewItem itemStringDraw = new ListViewItem("drawstring");
        private ListViewItem itemCopyRect = new ListViewItem("copy rect");
 */

        private Bitmap  bmp;
        private string  source_file_name = "";
        private Panel canvas;

        private ToolStripDropDown dropdown = new ToolStripDropDown();
        private ToolStripButton btnSolidBrush = new ToolStripButton("Solid");
        private ToolStripButton btnHatchBrush = new ToolStripButton("Hatch");
        private ToolStripButton btnTextureBrush = new ToolStripButton("Texture");
        private ToolStripButton btnLinearGradientBrush = new ToolStripButton("LinearGradient");

        private Bitmap bmpPaste = null;
        Pen penRim = new Pen(Color.Pink, 4);

        private ToolStripButton btnSelected = null;

        public FormMain()
        {
            InitializeComponent();

            //Drawing Field
            canvas = new Panel();
            canvas.Size = new Size(640, 480);
            this.toolStripContainer1.ContentPanel.Controls.Add(canvas);
            canvas.Dock = DockStyle.None;
            canvas.Visible = true;
            canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_OnMouseDown);
            canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_OnMouseUp);
            canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_OnMouseMove);
            canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_OnPaint);

            Graphics gCanvas = canvas.CreateGraphics();
            bmp = new Bitmap(canvas.Size.Width, canvas.Size.Height, gCanvas);
            gCanvas.Dispose();

            // Paint canvas white
            Graphics gBmp = Graphics.FromImage(bmp);
            gBmp.FillRectangle(new SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height);
            gBmp.Dispose();

            freedraw = new FreeDraw();
            linedraw = new LineDraw();
            rectdraw = new RectDraw();
            floodfill = new FloodFill();
            rectfill = new RectFill();
            copyrect = new SelectRectToCopy();
            stringdraw = new StringDraw();

            saveFileDialog1.Filter = "Bitmap(*.bmp)|*.BMP|JPEG(*.JPG)|*.JPG|GIF(*.GIF)|*.GIF|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
        
            openFileDialog1.Filter = "Bitmap(*.bmp)|*.BMP";
            openFileDialog1.FilterIndex = 1;

            toolStripSplitBtnDevice.BackColor = Color.Empty;
            toolStripSplitBtnDevice.ToolTipText = "";
            toolStripSplitBtnDevice.DropDown = dropdown;
            toolStripSplitBtnDevice.Image = DrawMethod.DeviceImage;
            toolStripLabel1.Text = "描画するツールを選択してください。";

            btnSolidBrush.Click += new EventHandler(DeviceDropDown_OnSolidBrushButtonClick);
            btnHatchBrush.Click += new EventHandler(DeviceDropDown_OnHatchBrushButtonClick);
            btnTextureBrush.Click += new EventHandler(DeviceDropDown_OnTextureBrushButtonClick);
            btnLinearGradientBrush.Click += new EventHandler(DeviceDropDown_OnLinearGradientBrushButtonClick);
        }

        public void DeviceDropDown_OnSolidBrushButtonClick(object sender, EventArgs e) 
        {
            ToolStripButton senderButton = (ToolStripButton)sender;
            toolStripSplitBtnDevice.ToolTipText = btnSolidBrush.Text;
            DrawMethod.BrushType = DrawMethod.BRUSH_TYPE.SOLID;
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();
        }
        public void DeviceDropDown_OnHatchBrushButtonClick(object sender, EventArgs e) 
        {
            ToolStripButton senderButton = (ToolStripButton)sender;
            toolStripSplitBtnDevice.ToolTipText = btnHatchBrush.Text;
            DrawMethod.BrushType = DrawMethod.BRUSH_TYPE.HATCH;
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();
        }
        public void DeviceDropDown_OnTextureBrushButtonClick(object sender, EventArgs e) 
        {
            ToolStripButton senderButton = (ToolStripButton)sender;
            toolStripSplitBtnDevice.ToolTipText = btnTextureBrush.Text;
            DrawMethod.BrushType = DrawMethod.BRUSH_TYPE.TEXTURE;
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();
        }
        public void DeviceDropDown_OnLinearGradientBrushButtonClick(object sender, EventArgs e) 
        {
            ToolStripButton senderButton = (ToolStripButton)sender;
            toolStripSplitBtnDevice.ToolTipText = btnLinearGradientBrush.Text;
            DrawMethod.BrushType = DrawMethod.BRUSH_TYPE.LINEAR_GRADIENT;
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();
        }

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e) 
        {
            if (drawmethod != null)
            {
                if (operation == OPERATION.COPY_IMG_SEL_ST)
                {
                    operation = OPERATION.PASTE_IMG_DRAG;
                    drawmethod.OnMouseMove(sender, e, bmp);
                }
                else if (operation == OPERATION.PASTE_IMG_SELECTED)
                {
                    // Do Nothing
                }
                else
                {
                    drawmethod.OnMouseMove(sender, e, bmp);
                }
            }
        }
        private void Canvas_OnMouseDown(object sender, MouseEventArgs e) 
        {
            if (drawmethod != null)
            {
                if (operation == OPERATION.PASTE_IMG_SELECTED)
                {
                    DragPastedImage dragimage = (DragPastedImage)drawmethod;
                    // もしイメージの上だったら
                    if (dragimage.isMouseOnTheImage(new Point(e.X, e.Y)))
                    {
                        toolStripLabel1.Text = "イメージをドラッグして移動します。";
                        operation = OPERATION.PASTE_IMG_DRAG;
                        dragimage.OnMouseDown(sender, e, bmp);
                    }
                    else
                    // そうでなければ、ドラッグの選択をやめる
                    {
                        // イメージを本体に描画する
                        dragimage.UpdateImage(sender, bmp);
                        // 選択をやめる
                        operation = OPERATION.NONE;
                        drawmethod = null;
                        return;
                    }
                }
                else
                {
                    drawmethod.OnMouseDown(sender, e, bmp);
                }
            }
        }
        private void Canvas_OnMouseUp(object sender, MouseEventArgs e) 
        {
            if (drawmethod != null)
            {
                if (operation == OPERATION.DRAWING)
                {
                    if(drawmethod.GetDrawDeviceType() == DrawMethod.DEVICE_TYPE.BRUSH)
                    {
                        if(DrawMethod.BrushType == DrawMethod.BRUSH_TYPE.LINEAR_GRADIENT)
                        {
                            Color cs = Color.Empty;
                            Color ce = Color.Empty;
                            toolStripLabel1.Text = "グラデーションの開始色を選択してください。";
                            if(colorDialog1.ShowDialog() != DialogResult.OK) return;
                            cs = colorDialog1.Color;
                            toolStripLabel1.Text = "グラデーションの終了色を選択してください。";
                            if(colorDialog1.ShowDialog() != DialogResult.OK) return;
                            ce = colorDialog1.Color;
                            DrawMethod.SetGradientColors(cs, ce);
                            DrawMethod.UpdateDevice();
                            toolStripLabel1.Text = "グラデーションの開始点を選択してください。";
                            operation = OPERATION.SEL_GRAD_PT_ST;
                        }
                    }
                    drawmethod.OnMouseUp(sender, e, bmp);
                }
                else if(operation == OPERATION.SEL_GRAD_PT_ST)
                {
                    this.ptGradStart = new Point(e.X, e.Y);
                    toolStripLabel1.Text = "グラデーションの終了点を選択してください。";
                    operation = OPERATION.SEL_GRAD_PT_EN;
                }
                else if(operation == OPERATION.SEL_GRAD_PT_EN)
                {
                    this.ptGradEnd = new Point(e.X, e.Y);
                    DrawMethod.SetGradientLine(this.ptGradStart, this.ptGradEnd);
                    DrawMethod.UpdateDevice();
                    drawmethod.UpdateImage(sender, bmp);
                    toolStripLabel1.Text = "マウスをドラッグして描画します。";
                    operation = OPERATION.DRAWING;
                }
                else if(operation == OPERATION.PASTE_IMG_SELECTED)
                {
                    // ドラッグしない
                    drawmethod.OnMouseUp(sender, e, bmp);
                    operation = OPERATION.NONE;
                    toolStripLabel1.Text = "描画するツールを選択してください。";
                    drawmethod = null;
                }
                else if(operation == OPERATION.PASTE_IMG_DRAG)
                {
                    // ドラッグ完了
                    drawmethod.OnMouseUp(sender, e, bmp);
                    operation = OPERATION.NONE;
                    toolStripLabel1.Text = "描画するツールを選択してください。";
                    drawmethod = null;
                }
                else if(operation == OPERATION.COPY_IMG_DRAG)
                {
                    // 選択完了
                    drawmethod.OnMouseUp(sender, e, bmp);
                    operation = OPERATION.COPY_IMG_SELECTED;
                    toolStripLabel1.Text = "メニューからコピーを選択してください。";
                }
            }
        }
        private void Canvas_OnPaint(object sender, PaintEventArgs e) 
        {
            Control c = (Control)sender;
            Graphics g = c.CreateGraphics();
            g.DrawImage(bmp, 0, 0);
            if (operation == OPERATION.PASTE_IMG_SELECTED && bmpPaste != null)
            {
                g.DrawImage(bmpPaste, new Point(0, 0));
                g.DrawRectangle(penRim, new Rectangle(new Point(0, 0), bmpPaste.Size));
            }
            g.Dispose();
        }

        private void toolStripSplitBtnDevice_ButtonClick(object sender, EventArgs e)
        {
            if (drawmethod == null) return;
            if (DrawMethod.BrushType == DrawMethod.BRUSH_TYPE.SOLID)
            {
                if (drawmethod.GetDrawDeviceType() == DrawMethod.DEVICE_TYPE.PEN)
                {
                    FormPenStyleDlg2 penStyledlg = new FormPenStyleDlg2();
                    penStyledlg.InitData(DrawMethod.DrawColor, DrawMethod.BackColor, DrawMethod.PenWidth, DrawMethod.HemmWidth, DrawMethod.PenType);
                    if (penStyledlg.ShowDialog() != DialogResult.OK) return;
                    DrawMethod.PenType = penStyledlg.PenType;
                    DrawMethod.PenWidth = penStyledlg.PenWidth;
                    DrawMethod.HemmWidth = penStyledlg.HemmWidth;
                    DrawMethod.DrawColor = penStyledlg.PenForeColor;
                    DrawMethod.BackColor = penStyledlg.PenBackColor;
                }
                else
                {
                    DialogResult result = colorDialog1.ShowDialog();
                    if (result != DialogResult.OK) return;
                    DrawMethod.DrawColor = colorDialog1.Color;
                }
            }
            else if (DrawMethod.BrushType == DrawMethod.BRUSH_TYPE.HATCH)
            {
                Color fc = Color.Empty;
                Color bc = Color.Empty;

                toolStripLabel1.Text = "パターンの色を選択してください。";
                if (colorDialog1.ShowDialog() != DialogResult.OK) return;
                fc = colorDialog1.Color;
                
                toolStripLabel1.Text = "背景色を選択してください。";
                if (colorDialog1.ShowDialog() != DialogResult.OK) return;
                bc = colorDialog1.Color;

                toolStripLabel1.Text = "パターンを選択してください。";
                FormHatchStyleDlg dlg = new FormHatchStyleDlg();
                if (dlg.ShowDialog() != DialogResult.OK) return;
                DrawMethod.SetHatchStyleColor(dlg.Style, fc, bc);
                toolStripLabel1.Text = "";

                if (drawmethod.GetDrawDeviceType() == DrawMethod.DEVICE_TYPE.PEN)
                {
                    FormPenStyleDlg2 penStyledlg = new FormPenStyleDlg2();
                    penStyledlg.InitData(DrawMethod.DrawColor, DrawMethod.BackColor, DrawMethod.PenWidth, DrawMethod.HemmWidth, DrawMethod.PenType);
                    if (penStyledlg.ShowDialog() != DialogResult.OK) return;
                    DrawMethod.PenType = penStyledlg.PenType;
                    DrawMethod.PenWidth = penStyledlg.PenWidth;
                    DrawMethod.HemmWidth = penStyledlg.HemmWidth;
                    DrawMethod.DrawColor = penStyledlg.PenForeColor;
                    DrawMethod.BackColor = penStyledlg.PenBackColor;
                }
            }
            else if (DrawMethod.BrushType == DrawMethod.BRUSH_TYPE.TEXTURE)
            {
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Image texture = Image.FromFile(openFileDialog1.FileName);
                    DrawMethod.SetTextureImage(texture);
                }
                if (drawmethod.GetDrawDeviceType() == DrawMethod.DEVICE_TYPE.PEN)
                {
                    FormPenStyleDlg2 penStyledlg = new FormPenStyleDlg2();
                    penStyledlg.InitData(DrawMethod.DrawColor, DrawMethod.BackColor, DrawMethod.PenWidth, DrawMethod.HemmWidth, DrawMethod.PenType);
                    if (penStyledlg.ShowDialog() != DialogResult.OK) return;
                    DrawMethod.PenType = penStyledlg.PenType;
                    DrawMethod.PenWidth = penStyledlg.PenWidth;
                    DrawMethod.HemmWidth = penStyledlg.HemmWidth;
                    DrawMethod.DrawColor = penStyledlg.PenForeColor;
                    DrawMethod.BackColor = penStyledlg.PenBackColor;
                }
            }

            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();
        }

        private void btnFreeDraw_Click(object sender, EventArgs e)
        {
            operation = OPERATION.DRAWING;
            toolStripLabel1.Text = "マウスをドラッグして描画します。";
            drawmethod = freedraw;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnLineDraw_Click(object sender, EventArgs e)
        {
            operation = OPERATION.DRAWING;
            toolStripLabel1.Text = "マウスをドラッグして描画します。";
            drawmethod = linedraw;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnRectDraw_Click(object sender, EventArgs e)
        {
            operation = OPERATION.DRAWING;
            toolStripLabel1.Text = "マウスをドラッグして描画します。";
            drawmethod = rectdraw;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnFillRect_Click(object sender, EventArgs e)
        {
            operation = OPERATION.DRAWING;
            toolStripLabel1.Text = "マウスをドラッグして描画します。";
            drawmethod = rectfill;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnFillFlood_Click(object sender, EventArgs e)
        {
            operation = OPERATION.DRAWING;
            toolStripLabel1.Text = "マウスをドラッグして描画します。";
            drawmethod = floodfill;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnCopyRect_Click(object sender, EventArgs e)
        {
            operation = OPERATION.COPY_IMG_SEL_ST;
            toolStripLabel1.Text = "マウスをドラッグして選択します。";
            drawmethod = copyrect;
            dropdown.Items.Clear();
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }

        private void btnStringDraw_Click(object sender, EventArgs e)
        {
            operation = OPERATION.SET_TEXT_POS;
            toolStripLabel1.Text = "文字を書く位置をクリックしてください。";
            drawmethod = stringdraw;
            dropdown.Items.Clear();
            dropdown.Items.Add(btnSolidBrush);
            dropdown.Items.Add(btnHatchBrush);
            dropdown.Items.Add(btnTextureBrush);
            dropdown.Items.Add(btnLinearGradientBrush);
            toolStripSplitBtnDevice.ToolTipText = drawmethod.GetDrawDeviceName();
            DrawMethod.UpdateDevice();
            toolStripSplitBtnDevice.Invalidate();

            ToolStripButton btn = (ToolStripButton)sender;
            if (btnSelected != null) btnSelected.Checked = false;
            btnSelected = btn;
            btnSelected.Checked = true;
        }
    }
}