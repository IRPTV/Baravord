using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baravord.OBJECTS;
using Baravord.UI;
using Baravord.BLL;
using Baravord.TOOLS;

namespace Baravord
{
    public partial class Form1 : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();

        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemShora_Click(object sender, EventArgs e)
        {


            SendToBacks("Shora");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Shora")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    Exist = true;
                }
            }
            if (!Exist)
            {

                NewListItem Lst = (NewListItem)cmbUserRole.SelectedItem;
                Shora Shr = new Shora(_ProgramGlobalObject.Id, int.Parse(Lst.Value.ToString()));
                Shr.MdiParent = this;
                Shr.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower() == "farsi"
                    || InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower() == "persian")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }

            _ProgramGlobalObject.Id = 0;


            //NewListItem Provider = new NewListItem();
            //Provider.Text = "تهیه کننده";
            //Provider.Value = "1";
            //cmbUserRole.Items.Add(Provider);

            NewListItem Tolid = new NewListItem();
            Tolid.Text = "واحد تولید";
            Tolid.Value = "1";
            cmbUserRole.Items.Add(Tolid);


            NewListItem Planning = new NewListItem();
            Planning.Text = "واحد اطلاعات  برنامه ریزی";
            Planning.Value = "2";
            cmbUserRole.Items.Add(Planning);

            cmbUserRole.SelectedIndex = 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackgroundImage = Properties.Resources.BG;
                    break;
                }
            }
            base.OnLoad(e);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Check For Close Confirm
            Application.Exit();
        }

        private void ToolStripMenuItemShenasname_Click(object sender, EventArgs e)
        {
            SendToBacks("Shenasname");
            if (_ProgramGlobalObject.Id != 0)
            {
                bool Exist = false;
                FormCollection fc = Application.OpenForms;
                foreach (Form f in fc)
                {
                    if (f.Name == "Shenasname")
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.TopMost = true;
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    Shenasname Shr = new Shenasname(_ProgramGlobalObject.Id);
                    Shr.MdiParent = this;
                    Shr.TopMost = true;
                    Shr.Show();
                }
            }
            else
            {
                MessageBox.Show("ابتدا برآورد را انتخاب کنید یا از قسمت ثبت مصوبه آنرا ثبت کنید");
            }
        }

        private void ToolStripMenuItemConversation_Click(object sender, EventArgs e)
        {
            if (_ProgramGlobalObject.Id != 0)
            {
                SendToBacks("CostCoversation");
                bool Exist = false;
                FormCollection fc = Application.OpenForms;
                foreach (Form f in fc)
                {
                    if (f.Name == "CostCoversation")
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.TopMost = true;
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    CostCoversation Shr = new CostCoversation(_ProgramGlobalObject.Id);
                    Shr.TopMost = true;
                    Shr.MdiParent = this;
                    Shr.Show();
                }
            }
            else
            {
                MessageBox.Show("ابتدا برآورد را انتخاب کنید یا از قسمت ثبت مصوبه آنرا ثبت کنید");
            }
        }

        public void GetGlobalProgram(int Id)
        {
            _ProgramGlobalObject.Id = Id;
            _ProgramGlobalObject = ProgramBll.Select_Program(_ProgramGlobalObject);
            toolStripLblTitle.Text = _ProgramGlobalObject.Title_Farsi;
            if (Id == 0)
            {
                btnDelProg.Visible = false;
            }
            else
            {
                btnDelProg.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendToBacks("ProgramSearch");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "ProgramSearch")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                NewListItem Lst = (NewListItem)cmbUserRole.SelectedItem;
                ProgramSearch Search = new ProgramSearch(int.Parse(Lst.Value.ToString()));
                Search.MdiParent = this;
                Search.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _ProgramGlobalObject = new ProgramObj();
            toolStripLblTitle.Text = "برنامه ای انتخاب نشده است";

        }

        private void شبکههاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Channels");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Channels")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.TopMost = true;
                    f.BringToFront();
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Channels Search = new Channels();
                Search.MdiParent = this;
                Search.TopMost = true;
                Search.BringToFront();
                Search.Show();
            }
        }

        private void ساختارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Structure");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Structure")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Structure Search = new Structure();
                Search.MdiParent = this;
                Search.TopMost = true;
                Search.Show();
            }
        }

        private void زبانهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Language");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Language")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Language Search = new Language();
                Search.MdiParent = this;
                Search.TopMost = true;
                Search.Show();
            }
        }

        private void طبقهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Levels");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Levels")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Levels Lvl = new Levels();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void پرینتمصوبهنهاییToolStripMenuItem_Click(object sender, EventArgs e)
        {



            if (_ProgramGlobalObject.Id != 0)
            {
                SendToBacks("Printcost");
                Form2 Frm = new Form2(_ProgramGlobalObject.Id, "Printcost");
                Frm.TopMost = true;
                Frm.MdiParent = this;
                Frm.Show();
            }
            else
            {
                MessageBox.Show("ابتدا برآورد را از قسمت جستجو انتخاب کنید ");
            }

        }

        private void توضیحاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Notify");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Notify")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            //if (!Exist)
            {
                Notify Lvl = new Notify(2);
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void توجهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Notify");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Notify")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.TopMost = true;
                    f.BringToFront();
                    Exist = true;
                }
            }
            //if (!Exist)
            {
                Notify Lvl = new Notify(1);
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void پرداختهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Payments");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Payments")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Payments Lvl = new Payments();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void کدعواملوهزینهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Roles");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Roles")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Roles Lvl = new Roles();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void مراحلطرحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("PlanSteps");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "PlanSteps")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                PlanSteps Lvl = new PlanSteps();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void هدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Targets");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Targets")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Targets Lvl = new Targets();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void موضوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Subjects");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Subjects")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.TopMost = true;
                    f.BringToFront();
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Subjects Lvl = new Subjects();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void پرینتمشخصاتوسوابقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("PrintProvider");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "PrintProvider")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                PrintProvider Lvl = new PrintProvider();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void مدیریتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Providers");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Providers")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Providers Lvl = new Providers();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void ارسالبهاطلاعاتوبرنامهریزیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ProgramGlobalObject.Id != 0)
            {

                SendToBacks("Sender");
                bool Exist = false;
                FormCollection fc = Application.OpenForms;
                foreach (Form f in fc)
                {
                    if (f.Name == "Sender")
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.TopMost = true;
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    Sender Lvl = new Sender(2, _ProgramGlobalObject.Id);
                    Lvl.MdiParent = this;
                    Lvl.TopMost = true;
                    Lvl.Show();
                }
            }
            else
            {
                MessageBox.Show("ابتدا برآورد را انتخاب کنید یا از قسمت ثبت مصوبه آنرا ثبت کنید");
            }
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ProgramGlobalObject = new ProgramObj();
            toolStripLblTitle.Text = "برنامه ای انتخاب نشده است";

            //if (((NewListItem)cmbUserRole.SelectedItem).Value.ToString() == "1")
            //{
            //    Barnamerizi.Visible = false;
            //}
            //else
            //{
            //    Barnamerizi.Visible = true;

            //}

        }

        private void btnDelProg_Click(object sender, EventArgs e)
        {
            DialogResult Dlgrs = MessageBox.Show("آیا مطمئن هستید که می خواهید این برنامه را حذف کنید", "حذف برنامه",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Dlgrs == System.Windows.Forms.DialogResult.Yes)
            {
                ProgramBll.Delete_Prog_And_Details(_ProgramGlobalObject.Id);
                _ProgramGlobalObject = new ProgramObj();
                toolStripLblTitle.Text = "برنامه ای انتخاب نشده است";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا از برنامه خارج می شوید", "خروج از برنامه",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            //else
            //{

            //    FormCollection fc = Application.OpenForms;
            //    foreach (Form f in fc)
            //    {
            //        if (f.Name == "Shora" && f.Name != "From1")
            //        {
            //            f.Close();
            //        }
            //    }
            //    Application.Exit();


            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendToBacks("Deps");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Deps")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Deps Lvl = new Deps();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void مصوبهنهاییتولیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Sign");
            Sign Lvl = new Sign("Cost", "مدیریت امضا های مصوبه نهایی");
            Lvl.MdiParent = this;
            Lvl.TopMost = true;
            Lvl.Show();
            Lvl.BringToFront();

        }

        private void شناسنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Sign");
            Sign Lvl = new Sign("Shenasname", "مدیریت امضا های شناسنامه");
            Lvl.MdiParent = this;
            Lvl.TopMost = true;
            Lvl.Show();
            Lvl.BringToFront();
        }

        private void برآوردهزینهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Sign");
            Sign Lvl = new Sign("Cost2", "مدیریت امضا های برآورد هزینه");
            Lvl.MdiParent = this;
            Lvl.TopMost = true;
            Lvl.Show();
            Lvl.BringToFront();
        }

        private void مصوبهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Sign");
            Sign Lvl = new Sign("Shora", "مدیریت امضا های مصوبه شورا");
            Lvl.MdiParent = this;
            Lvl.TopMost = true;
            Lvl.Show();
            Lvl.BringToFront();
        }

        private void Barnamerizi_Click(object sender, EventArgs e)
        {
            SendToBacks("Planning");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Planning")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Planning Lvl = new Planning(_ProgramGlobalObject.Id);
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void جستجوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendToBacks("Support");
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Support")
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.TopMost = true;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Support Lvl = new Support();
                Lvl.MdiParent = this;
                Lvl.TopMost = true;
                Lvl.Show();
            }
        }

        private void برآوردپشتیبانیToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendToBacks("Sign");
            Sign Lvl = new Sign("Support", "مدیریت امضا های برآورد پشتیبانی");
            Lvl.MdiParent = this;
            Lvl.TopMost = true;
            Lvl.Show();
            Lvl.BringToFront();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                جستجوToolStripMenuItem_Click(new object(), new EventArgs());
            }
        }

        private void مصوبهنهاییجهتاطلاعToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_ProgramGlobalObject.Id != 0)
            {
                SendToBacks("Form2");
                Form2 Frm = new Form2(_ProgramGlobalObject.Id, "Printcostinfo");
                Frm.TopMost = true;
                Frm.MdiParent = this;
                Frm.Show();
                Frm.BringToFront();
            }
            else
            {
                MessageBox.Show("ابتدا برآورد را از قسمت جستجو انتخاب کنید ");
            }
        }

        protected void SendToBacks(string FormName)
        {
            FormCollection fc2 = Application.OpenForms;
            foreach (Form f in fc2)
            {
                if (f.Name.ToLower() != "form1" && f.Name.ToLower() != FormName.ToLower())
                {
                    // f.WindowState = FormWindowState.Normal;
                    f.SendToBack();
                }

            }
        }

        private void تهیهنسخهپشتیبانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baravord.DAL.ProgramDal d = new DAL.ProgramDal();
            d.GenerateBackUp();
            MessageBox.Show("لطفا نام فایل پشتیبان و محل ذخیره سازی آنرا مشخص نمایید");
            saveFileDialog1.ShowDialog();
        }


        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                System.IO.File.Copy("\\\\192.168.100.73\\baravord\\Baravord_BackUp.BAK", saveFileDialog1.FileName + ".Bak");
                System.IO.File.Delete("\\\\192.168.100.73\\baravord\\Baravord_BackUp.BAK");
                MessageBox.Show(  "   فایل با موفقیت ذخیره شد    "+saveFileDialog1.FileName + ".Bak");
            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.Message);
            }
          
        }
    }
}
