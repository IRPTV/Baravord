using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Baravord
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Escape))
            //{
            //    this.Close();
            //    this.Hide();
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower().Trim() == "plan" && textBox2.Text.ToLower().Trim() == "plan")
            {
                if (checkBox1.Checked)
                {
                    MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();
                    Ta.AutoLogin_Insert(Environment.MachineName);
                }
                Form1 Frm1 = new Form1();
                Frm1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(" نام کاربری و گذرواژه  را چک فرمایید");
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Dt = Ta.AutoLogin_Select_By_Name(Environment.MachineName);
            if (Dt.Rows.Count > 0)
            {
                DialogResult Res = MessageBox.Show("نام کاربری برای این سیستم ذخیره شده آیا حذف گردد؟",
                    "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == System.Windows.Forms.DialogResult.Yes)
                {
                    Ta.AutoLogin_Delete_By_Name(Environment.MachineName);
                }
                if (Res == System.Windows.Forms.DialogResult.No)
                {
                    this.Hide();
                    Form1 Frm1 = new Form1();
                    Frm1.Show();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pictureBox1_Click(new object(), new EventArgs());
            }
        }
    }
}
