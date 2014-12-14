namespace Baravord.UI
{
    partial class Sign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbChannel = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbDep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NudSecond = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.dgvSigns = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigns)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSigns);
            this.groupBox2.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(367, 248);
            this.groupBox2.TabIndex = 1009;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست امضا های صفحه انتخاب شده";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbSave);
            this.groupBox1.Controls.Add(this.pbDelete);
            this.groupBox1.Controls.Add(this.pbAdd);
            this.groupBox1.Controls.Add(this.NudSecond);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbChannel);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(365, 167);
            this.groupBox1.TabIndex = 1008;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مدیریت امضا ها";
            // 
            // CmbChannel
            // 
            this.CmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbChannel.FormattingEnabled = true;
            this.CmbChannel.Location = new System.Drawing.Point(6, 30);
            this.CmbChannel.Name = "CmbChannel";
            this.CmbChannel.Size = new System.Drawing.Size(287, 32);
            this.CmbChannel.TabIndex = 4;
            this.CmbChannel.SelectedIndexChanged += new System.EventHandler(this.CmbChannel_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(302, 33);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(40, 24);
            this.label39.TabIndex = 1000;
            this.label39.Text = "شبکه:";
            // 
            // cmbDep
            // 
            this.cmbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDep.FormattingEnabled = true;
            this.cmbDep.Location = new System.Drawing.Point(6, 68);
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Size = new System.Drawing.Size(287, 32);
            this.cmbDep.TabIndex = 1011;
            this.cmbDep.SelectedIndexChanged += new System.EventHandler(this.cmbDep_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 1012;
            this.label1.Text = "مدیریت:";
            // 
            // NudSecond
            // 
            this.NudSecond.Location = new System.Drawing.Point(233, 106);
            this.NudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NudSecond.Name = "NudSecond";
            this.NudSecond.Size = new System.Drawing.Size(60, 31);
            this.NudSecond.TabIndex = 1013;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 1014;
            this.label5.Text = "ترتیب:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbDelete
            // 
            this.pbDelete.Image = global::Baravord.Properties.Resources.Delete;
            this.pbDelete.Location = new System.Drawing.Point(42, 125);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(30, 30);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 1016;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // pbSave
            // 
            this.pbSave.Image = global::Baravord.Properties.Resources.document_save;
            this.pbSave.Location = new System.Drawing.Point(6, 125);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(30, 30);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 1018;
            this.pbSave.TabStop = false;
            this.pbSave.Visible = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(203, 106);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(24, 24);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 1015;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // dgvSigns
            // 
            this.dgvSigns.AllowUserToAddRows = false;
            this.dgvSigns.AllowUserToDeleteRows = false;
            this.dgvSigns.AllowUserToResizeColumns = false;
            this.dgvSigns.AllowUserToResizeRows = false;
            this.dgvSigns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSigns.Location = new System.Drawing.Point(3, 27);
            this.dgvSigns.Name = "dgvSigns";
            this.dgvSigns.ReadOnly = true;
            this.dgvSigns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigns.Size = new System.Drawing.Size(361, 218);
            this.dgvSigns.TabIndex = 80;
            this.dgvSigns.DoubleClick += new System.EventHandler(this.dgvSigns_DoubleClick);
            // 
            // Sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Sign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign";
            this.Load += new System.EventHandler(this.Sign_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmbChannel;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cmbDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudSecond;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.DataGridView dgvSigns;
    }
}