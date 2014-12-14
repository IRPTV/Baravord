using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baravord.BLL;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.UI
{
    public partial class Targets : Form
    {
        public Targets()
        {
            InitializeComponent();
        }

        private void Targets_Load(object sender, EventArgs e)
        {
            TargetFill();
        }
        public void TargetFill()
        {
            List<TargetObj> Tar_Lst = TargetBll.Select_All_Targets();

            CmbTarget.Items.Clear();

            foreach (TargetObj item in Tar_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbTarget.Items.Add(Lst);
            }
            CmbTarget.SelectedIndex = 0;
        }
        private void CmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            TargetObj Obj = new TargetObj();
            Obj.Id = int.Parse(((NewListItem)CmbTarget.SelectedItem).Value.ToString());


            Obj = TargetBll.Select_Current_Target(Obj);


            txtTitle.Text = Obj.Title;
            nudSort.Value = Obj.Sort;
            
            pictureBox1.Visible = false;
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtTitle.Text = "";
            nudSort.Value = 1;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert
            TargetObj Obj = new TargetObj();
            Obj.Title = txtTitle.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());

           

            if (txtTitle.Text.Length > 2)
            {
                TargetBll.Insert_Target_Base(Obj);

                pictureBox1.Visible = false;
                TargetFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update
            TargetObj Obj = new TargetObj();
            Obj.Title = txtTitle.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());
            Obj.Id = int.Parse(((NewListItem)CmbTarget.SelectedItem).Value.ToString());

         



            if (txtTitle.Text.Length > 2)
            {
                TargetBll.Update_Target_Base(Obj);
                TargetFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا مورد انتخاب شده حذف گردد؟", "حذف",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<string[]> Lst =
                    TargetBll.Select_TargetById(int.Parse(((NewListItem)CmbTarget.SelectedItem).Value.ToString()));

                if (Lst.Count > 0)
                {
                    string Str = "";
                    string Dep = "";
                    foreach (string[] item in Lst)
                    {
                        List<ProgramObj> Lst_Prog =
                   ProgramBll.Search_Prgrams("Select * From program  where  Id=" + item[0].ToString());
                        foreach (ProgramObj item2 in Lst_Prog)
                        {
                            Dep = (item2.Dep == 1) ? "    واحد تولید    " : "      واحد اطلاعات و برنامه ریزی     ";
                            Str += item2.Title_Farsi + " " + Dep + "\n";
                        }
                    }
                    MessageBox.Show("   در برنامه های زیر استفاده شده است  " + " \n" + Str);
                }
                else
                {
                    TargetBll.Delete_Target(int.Parse(((NewListItem)CmbTarget.SelectedItem).Value.ToString()));
                    TargetFill();
                }
            }
        }
    }
}
