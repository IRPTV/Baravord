namespace Baravord.UI
{
    partial class Sender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sender));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.label39 = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblActDate = new System.Windows.Forms.Label();
            this.LblRcvDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblSendDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblSendDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LblRcvDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LblActDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LblTitle);
            this.groupBox1.Controls.Add(this.pbSend);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Font = new System.Drawing.Font("B Homa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(647, 182);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات برنامه";
            // 
            // pbSend
            // 
            this.pbSend.Image = ((System.Drawing.Image)(resources.GetObject("pbSend.Image")));
            this.pbSend.Location = new System.Drawing.Point(6, 135);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(39, 41);
            this.pbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSend.TabIndex = 88;
            this.pbSend.TabStop = false;
            this.pbSend.Click += new System.EventHandler(this.pbSend_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(557, 27);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 23);
            this.label39.TabIndex = 6;
            this.label39.Text = "عنوان برنامه:";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Location = new System.Drawing.Point(473, 27);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(66, 23);
            this.LblTitle.TabIndex = 89;
            this.LblTitle.Text = "عنوان شبکه:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 90;
            this.label1.Text = "تاریخ مصوبه:";
            // 
            // LblActDate
            // 
            this.LblActDate.AutoSize = true;
            this.LblActDate.Location = new System.Drawing.Point(454, 65);
            this.LblActDate.Name = "LblActDate";
            this.LblActDate.Size = new System.Drawing.Size(94, 23);
            this.LblActDate.TabIndex = 91;
            this.LblActDate.Text = "تاریخ ایجاد مصوبه:";
            // 
            // LblRcvDate
            // 
            this.LblRcvDate.AutoSize = true;
            this.LblRcvDate.Location = new System.Drawing.Point(110, 65);
            this.LblRcvDate.Name = "LblRcvDate";
            this.LblRcvDate.Size = new System.Drawing.Size(94, 23);
            this.LblRcvDate.TabIndex = 93;
            this.LblRcvDate.Text = "تاریخ ایجاد مصوبه:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 92;
            this.label3.Text = "تاریخ  دریافت مصوبه:";
            // 
            // LblSendDate
            // 
            this.LblSendDate.AutoSize = true;
            this.LblSendDate.Location = new System.Drawing.Point(110, 98);
            this.LblSendDate.Name = "LblSendDate";
            this.LblSendDate.Size = new System.Drawing.Size(94, 23);
            this.LblSendDate.TabIndex = 95;
            this.LblSendDate.Text = "تاریخ ایجاد مصوبه:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 94;
            this.label4.Text = "تاریخ  ارسال مصوبه:";
            // 
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 203);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sender";
            this.Text = "ارسال به واحد دیگر";
            this.Load += new System.EventHandler(this.Sender_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblActDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblRcvDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblSendDate;
        private System.Windows.Forms.Label label4;
    }
}