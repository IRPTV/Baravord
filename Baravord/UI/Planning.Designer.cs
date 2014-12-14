namespace Baravord.UI
{
    partial class Planning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planning));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLblProgramTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProgramKind = new System.Windows.Forms.CheckedListBox();
            this.chkIsCheckedOut = new System.Windows.Forms.CheckBox();
            this.cmbCheckOutKind = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.txtShoraDatetime = new System.Windows.Forms.TextBox();
            this.txtEditDatetime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFinanceDatetime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(217)))), ((int)(((byte)(219)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripBtnSave,
            this.toolStripSeparator1,
            this.toolStripLblProgramTitle,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(678, 37);
            this.toolStrip1.TabIndex = 1001;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(34, 34);
            this.toolStripBtnSave.Text = "ذخیره اطلاعات";
            this.toolStripBtnSave.Click += new System.EventHandler(this.toolStripBtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLblProgramTitle
            // 
            this.toolStripLblProgramTitle.Font = new System.Drawing.Font("B Traffic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolStripLblProgramTitle.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLblProgramTitle.Name = "toolStripLblProgramTitle";
            this.toolStripLblProgramTitle.Size = new System.Drawing.Size(77, 34);
            this.toolStripLblProgramTitle.Text = "عنوان برنامه";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbProgramKind);
            this.groupBox1.Controls.Add(this.chkIsCheckedOut);
            this.groupBox1.Controls.Add(this.cmbCheckOutKind);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPublish);
            this.groupBox1.Controls.Add(this.txtShoraDatetime);
            this.groupBox1.Controls.Add(this.txtEditDatetime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFinanceDatetime);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(668, 254);
            this.groupBox1.TabIndex = 1002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "واحد اطلاعات برنامه ریزی";
            // 
            // cmbProgramKind
            // 
            this.cmbProgramKind.FormattingEnabled = true;
            this.cmbProgramKind.Location = new System.Drawing.Point(363, 127);
            this.cmbProgramKind.Name = "cmbProgramKind";
            this.cmbProgramKind.Size = new System.Drawing.Size(158, 82);
            this.cmbProgramKind.TabIndex = 1012;
            // 
            // chkIsCheckedOut
            // 
            this.chkIsCheckedOut.AutoSize = true;
            this.chkIsCheckedOut.Location = new System.Drawing.Point(237, 215);
            this.chkIsCheckedOut.Name = "chkIsCheckedOut";
            this.chkIsCheckedOut.Size = new System.Drawing.Size(425, 28);
            this.chkIsCheckedOut.TabIndex = 1011;
            this.chkIsCheckedOut.Text = "برآورد صادر شده است( پرینت نهایی برآورد در واحد تولید قابل دیدن است)";
            this.chkIsCheckedOut.UseVisualStyleBackColor = true;
            // 
            // cmbCheckOutKind
            // 
            this.cmbCheckOutKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckOutKind.FormattingEnabled = true;
            this.cmbCheckOutKind.Location = new System.Drawing.Point(29, 125);
            this.cmbCheckOutKind.Name = "cmbCheckOutKind";
            this.cmbCheckOutKind.Size = new System.Drawing.Size(158, 32);
            this.cmbCheckOutKind.TabIndex = 1010;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(193, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 1009;
            this.label5.Text = "نوع تسویه حساب:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(527, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 1007;
            this.label4.Text = "نوع برنامه:";
            // 
            // txtPublish
            // 
            this.txtPublish.Font = new System.Drawing.Font("B Traffic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPublish.Location = new System.Drawing.Point(29, 78);
            this.txtPublish.Name = "txtPublish";
            this.txtPublish.Size = new System.Drawing.Size(158, 41);
            this.txtPublish.TabIndex = 1006;
            this.txtPublish.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPublish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPublish_KeyDown);
            // 
            // txtShoraDatetime
            // 
            this.txtShoraDatetime.Font = new System.Drawing.Font("B Traffic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtShoraDatetime.Location = new System.Drawing.Point(29, 30);
            this.txtShoraDatetime.Name = "txtShoraDatetime";
            this.txtShoraDatetime.Size = new System.Drawing.Size(158, 41);
            this.txtShoraDatetime.TabIndex = 1005;
            this.txtShoraDatetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShoraDatetime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShoraDatetime_KeyDown);
            // 
            // txtEditDatetime
            // 
            this.txtEditDatetime.Font = new System.Drawing.Font("B Traffic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEditDatetime.Location = new System.Drawing.Point(363, 78);
            this.txtEditDatetime.Name = "txtEditDatetime";
            this.txtEditDatetime.Size = new System.Drawing.Size(158, 41);
            this.txtEditDatetime.TabIndex = 1004;
            this.txtEditDatetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditDatetime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditDatetime_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(191, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 1003;
            this.label3.Text = "تاریخ صدور برآورد:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(193, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 1002;
            this.label2.Text = "تاریخ تصویب برآورد:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(522, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 1001;
            this.label1.Text = "تاریخ آخرین اصلاحیه:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFinanceDatetime
            // 
            this.txtFinanceDatetime.Font = new System.Drawing.Font("B Traffic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFinanceDatetime.Location = new System.Drawing.Point(363, 30);
            this.txtFinanceDatetime.Name = "txtFinanceDatetime";
            this.txtFinanceDatetime.Size = new System.Drawing.Size(158, 41);
            this.txtFinanceDatetime.TabIndex = 5;
            this.txtFinanceDatetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinanceDatetime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinanceDatetime_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(527, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 24);
            this.label11.TabIndex = 1000;
            this.label11.Text = "تاریخ ارسال به مالی:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 24);
            this.label6.TabIndex = 1013;
            this.label6.Text = "با کلید F3 در تاریخ ، تاریخ روز اعمال میشود";
            // 
            // Planning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Planning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "واحد اطلاعات برنامه ریزی";
            this.Load += new System.EventHandler(this.Planning_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLblProgramTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFinanceDatetime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPublish;
        private System.Windows.Forms.TextBox txtShoraDatetime;
        private System.Windows.Forms.TextBox txtEditDatetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCheckOutKind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsCheckedOut;
        private System.Windows.Forms.CheckedListBox cmbProgramKind;
        private System.Windows.Forms.Label label6;
    }
}