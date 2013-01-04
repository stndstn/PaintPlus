namespace PaintPlus
{
    partial class FormMain
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripStatus = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitBtnDevice = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.btnFreeDraw = new System.Windows.Forms.ToolStripButton();
            this.btnLineDraw = new System.Windows.Forms.ToolStripButton();
            this.btnRectDraw = new System.Windows.Forms.ToolStripButton();
            this.btnFillRect = new System.Windows.Forms.ToolStripButton();
            this.btnFillFlood = new System.Windows.Forms.ToolStripButton();
            this.btnCopyRect = new System.Windows.Forms.ToolStripButton();
            this.btnStringDraw = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripStatus.SuspendLayout();
            this.toolStripTools.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(292, 266);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStripStatus);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(268, 239);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStripTools);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(292, 288);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitBtnDevice,
            this.toolStripLabel1});
            this.toolStripStatus.Location = new System.Drawing.Point(3, 0);
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(122, 25);
            this.toolStripStatus.TabIndex = 1;
            // 
            // toolStripSplitBtnDevice
            // 
            this.toolStripSplitBtnDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitBtnDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitBtnDevice.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripSplitBtnDevice.Name = "toolStripSplitBtnDevice";
            this.toolStripSplitBtnDevice.Size = new System.Drawing.Size(16, 17);
            this.toolStripSplitBtnDevice.ButtonClick += new System.EventHandler(this.toolStripSplitBtnDevice_ButtonClick);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripTools
            // 
            this.toolStripTools.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFreeDraw,
            this.btnLineDraw,
            this.btnRectDraw,
            this.btnFillRect,
            this.btnFillFlood,
            this.btnCopyRect,
            this.btnStringDraw});
            this.toolStripTools.Location = new System.Drawing.Point(0, 3);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(24, 172);
            this.toolStripTools.TabIndex = 0;
            this.toolStripTools.Text = "toolStrip2";
            // 
            // btnFreeDraw
            // 
            this.btnFreeDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFreeDraw.Image = global::PaintPlus.Properties.Resources.freedraw;
            this.btnFreeDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFreeDraw.Name = "btnFreeDraw";
            this.btnFreeDraw.Size = new System.Drawing.Size(22, 20);
            this.btnFreeDraw.Text = "FreeDraw";
            this.btnFreeDraw.Click += new System.EventHandler(this.btnFreeDraw_Click);
            // 
            // btnLineDraw
            // 
            this.btnLineDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLineDraw.Image = global::PaintPlus.Properties.Resources.linedraw;
            this.btnLineDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLineDraw.Name = "btnLineDraw";
            this.btnLineDraw.Size = new System.Drawing.Size(22, 20);
            this.btnLineDraw.Text = "LineDraw";
            this.btnLineDraw.Click += new System.EventHandler(this.btnLineDraw_Click);
            // 
            // btnRectDraw
            // 
            this.btnRectDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectDraw.Image = global::PaintPlus.Properties.Resources.rectdraw;
            this.btnRectDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectDraw.Name = "btnRectDraw";
            this.btnRectDraw.Size = new System.Drawing.Size(22, 20);
            this.btnRectDraw.Text = "toolStripButton1";
            this.btnRectDraw.Click += new System.EventHandler(this.btnRectDraw_Click);
            // 
            // btnFillRect
            // 
            this.btnFillRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFillRect.Image = global::PaintPlus.Properties.Resources.fillrect;
            this.btnFillRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillRect.Name = "btnFillRect";
            this.btnFillRect.Size = new System.Drawing.Size(22, 20);
            this.btnFillRect.Text = "toolStripButton1";
            this.btnFillRect.Click += new System.EventHandler(this.btnFillRect_Click);
            // 
            // btnFillFlood
            // 
            this.btnFillFlood.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFillFlood.Image = global::PaintPlus.Properties.Resources.fillflood;
            this.btnFillFlood.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillFlood.Name = "btnFillFlood";
            this.btnFillFlood.Size = new System.Drawing.Size(22, 20);
            this.btnFillFlood.Text = "toolStripButton1";
            this.btnFillFlood.Click += new System.EventHandler(this.btnFillFlood_Click);
            // 
            // btnCopyRect
            // 
            this.btnCopyRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyRect.Image = global::PaintPlus.Properties.Resources.copyrect;
            this.btnCopyRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyRect.Name = "btnCopyRect";
            this.btnCopyRect.Size = new System.Drawing.Size(22, 20);
            this.btnCopyRect.Text = "toolStripButton1";
            this.btnCopyRect.Click += new System.EventHandler(this.btnCopyRect_Click);
            // 
            // btnStringDraw
            // 
            this.btnStringDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStringDraw.Image = global::PaintPlus.Properties.Resources.drawstring;
            this.btnStringDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStringDraw.Name = "btnStringDraw";
            this.btnStringDraw.Size = new System.Drawing.Size(22, 20);
            this.btnStringDraw.Text = "toolStripButton1";
            this.btnStringDraw.Click += new System.EventHandler(this.btnStringDraw_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 288);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "PaintPlus";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripStatus.ResumeLayout(false);
            this.toolStripStatus.PerformLayout();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripStatus;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitBtnDevice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton btnFreeDraw;
        private System.Windows.Forms.ToolStripButton btnLineDraw;
        private System.Windows.Forms.ToolStripButton btnRectDraw;
        private System.Windows.Forms.ToolStripButton btnFillRect;
        private System.Windows.Forms.ToolStripButton btnFillFlood;
        private System.Windows.Forms.ToolStripButton btnCopyRect;
        private System.Windows.Forms.ToolStripButton btnStringDraw;


    }
}

