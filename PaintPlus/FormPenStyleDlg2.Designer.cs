namespace PaintPlus
{
    partial class FormPenStyleDlg2
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPenSize = new System.Windows.Forms.ComboBox();
            this.pictPenStyle = new System.Windows.Forms.PictureBox();
            this.pictPenStyleBackColor = new System.Windows.Forms.PictureBox();
            this.pictPenStyleForeColor = new System.Windows.Forms.PictureBox();
            this.cmbHemmSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyleBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyleForeColor)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(129, 239);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(210, 239);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 30;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Back Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fore Color";
            // 
            // cmbPenSize
            // 
            this.cmbPenSize.FormattingEnabled = true;
            this.cmbPenSize.Items.AddRange(new object[] {
            ""});
            this.cmbPenSize.Location = new System.Drawing.Point(19, 153);
            this.cmbPenSize.Name = "cmbPenSize";
            this.cmbPenSize.Size = new System.Drawing.Size(121, 21);
            this.cmbPenSize.TabIndex = 33;
            this.cmbPenSize.SelectedIndexChanged += new System.EventHandler(this.cmbPenSize_SelectedIndexChanged);
            // 
            // pictPenStyle
            // 
            this.pictPenStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictPenStyle.Location = new System.Drawing.Point(17, 15);
            this.pictPenStyle.Name = "pictPenStyle";
            this.pictPenStyle.Size = new System.Drawing.Size(97, 93);
            this.pictPenStyle.TabIndex = 32;
            this.pictPenStyle.TabStop = false;
            // 
            // pictPenStyleBackColor
            // 
            this.pictPenStyleBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictPenStyleBackColor.Location = new System.Drawing.Point(238, 194);
            this.pictPenStyleBackColor.Name = "pictPenStyleBackColor";
            this.pictPenStyleBackColor.Size = new System.Drawing.Size(39, 25);
            this.pictPenStyleBackColor.TabIndex = 27;
            this.pictPenStyleBackColor.TabStop = false;
            this.pictPenStyleBackColor.Click += new System.EventHandler(this.pictPenStyleBackColor_Click);
            // 
            // pictPenStyleForeColor
            // 
            this.pictPenStyleForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictPenStyleForeColor.Location = new System.Drawing.Point(99, 194);
            this.pictPenStyleForeColor.Name = "pictPenStyleForeColor";
            this.pictPenStyleForeColor.Size = new System.Drawing.Size(39, 25);
            this.pictPenStyleForeColor.TabIndex = 26;
            this.pictPenStyleForeColor.TabStop = false;
            this.pictPenStyleForeColor.Click += new System.EventHandler(this.pictPenStyleForeColor_Click);
            // 
            // cmbHemmSize
            // 
            this.cmbHemmSize.FormattingEnabled = true;
            this.cmbHemmSize.Location = new System.Drawing.Point(156, 153);
            this.cmbHemmSize.Name = "cmbHemmSize";
            this.cmbHemmSize.Size = new System.Drawing.Size(121, 21);
            this.cmbHemmSize.TabIndex = 34;
            this.cmbHemmSize.SelectedIndexChanged += new System.EventHandler(this.cmbHemmSize_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Hemm";
            // 
            // FormPenStyleDlg2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHemmSize);
            this.Controls.Add(this.cmbPenSize);
            this.Controls.Add(this.pictPenStyle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictPenStyleBackColor);
            this.Controls.Add(this.pictPenStyleForeColor);
            this.Name = "FormPenStyleDlg2";
            this.Text = "FormPenStyleDlg2";
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyleBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPenStyleForeColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictPenStyleBackColor;
        private System.Windows.Forms.PictureBox pictPenStyleForeColor;
        private System.Windows.Forms.PictureBox pictPenStyle;
        private System.Windows.Forms.ComboBox cmbPenSize;
        private System.Windows.Forms.ComboBox cmbHemmSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}