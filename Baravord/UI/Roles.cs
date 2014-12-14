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
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            RoleFill();

        }
        public void RoleFill()
        {
            CmbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CmbRole.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (textBox1.Text.Trim().Length > 0)
            {
                CmbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CmbRole.AutoCompleteSource = AutoCompleteSource.ListItems;


                RoleBll Rol_Bll = new RoleBll();
                List<RoleObj> Rl_Lst = Rol_Bll.Search_Roles(" where  title like N'%" + textBox1.Text.Trim() + "%' ");
                CmbRole.Items.Clear();

                foreach (RoleObj item in Rl_Lst)
                {
                    NewListItem Lst = new NewListItem();
                    Lst.Text = item.Title;
                    Lst.Value = item.Id;

                    CmbRole.Items.Add(Lst);
                }
                CmbRole.SelectedIndex = 0;
            }
            else
            {

                RoleBll Rol_Bll = new RoleBll();
                List<RoleObj> Rl_Lst = Rol_Bll.Select_All_Role();
                CmbRole.Items.Clear();

                foreach (RoleObj item in Rl_Lst)
                {
                    NewListItem Lst = new NewListItem();
                    Lst.Text = item.Title;
                    Lst.Value = item.Id;

                    CmbRole.Items.Add(Lst);
                }
                CmbRole.SelectedIndex = 0;
            }
        }

        private void CmbStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoleObj Obj = new RoleObj();

            Obj.Id = int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString());

            Obj=RoleBll.Select_Current_Role(Obj);

            txtTitle.Text = Obj.Title;
            richTextBox1.Text = Obj.Description;
            nudSort.Value = Obj.Sort;           

            pictureBox1.Visible = false;
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            txtTitle.Text = "";
            nudSort.Value = 1;
            pictureBox1.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update
            RoleObj Obj = new RoleObj();
            Obj.Title = txtTitle.Text;
            Obj.Description = richTextBox1.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());
            Obj.Id = int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString());
          

            if (txtTitle.Text.Length > 2)
            {
                RoleBll.Update_Current_Role(Obj);

                RoleFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert New Role And Cost Code
            RoleObj Obj = new RoleObj();
            Obj.Title = txtTitle.Text.Trim();
            Obj.Description = richTextBox1.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());

            if (txtTitle.Text.Length > 2)
            {
                RoleBll Rol_Bll = new RoleBll();
                List<RoleObj> Rl_Lst = Rol_Bll.Select_All_Role();
                bool Exist = false;

                foreach (RoleObj item in Rl_Lst)
                {
                    if (item.Title.Trim() == txtTitle.Text.Trim())
                        Exist = true;
                }

                if (!Exist)
                {
                    RoleBll.Insert_Role_Base(Obj);

                    RoleFill();
                    pictureBox1.Visible = false;
                }
                else
                {
                    MessageBox.Show("این عنوان قبلا ثبت شده است");
                }
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
                    Program_RoleBll.Select_RoleById(int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()));

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
                    RoleBll.Delete_Role(int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()));
                    RoleFill();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
                RoleFill();
         
        }
    }
}
