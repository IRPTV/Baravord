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
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            SubjectFill();
        }
        public void SubjectFill()
        {
            SubjectBll Subject_Bll = new SubjectBll();
            List<SubjectObj> Sub_Lst = Subject_Bll.Select_All_Subject();

            CmbSubject.Items.Clear();

            foreach (SubjectObj item in Sub_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbSubject.Items.Add(Lst);
            }
            CmbSubject.SelectedIndex = 0;
        }

        private void CmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectObj Obj = new SubjectObj();
            Obj.Id = int.Parse(((NewListItem)CmbSubject.SelectedItem).Value.ToString());


            Obj = SubjectBll.Select_Current_Subject_Base(Obj);


            txtTitle.Text = Obj.Title;
            

            pictureBox1.Visible = false;
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtTitle.Text = "";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert
            SubjectObj Obj = new SubjectObj();
            Obj.Title = txtTitle.Text;


            SubjectBll.Insert_Subject_Base(Obj);

           
            if (txtTitle.Text.Length > 2)
            {
                pictureBox1.Visible = false;
                SubjectFill();

            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            //Update
            SubjectObj Obj = new SubjectObj();
            Obj.Title = txtTitle.Text;
            Obj.Id = int.Parse(((NewListItem)CmbSubject.SelectedItem).Value.ToString());

            if (txtTitle.Text.Length > 2)
            {

                SubjectBll.Update_Subject_Base(Obj);


                SubjectFill();


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
                    SubjectBll.Select_SubjectById(int.Parse(((NewListItem)CmbSubject.SelectedItem).Value.ToString()));

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
                    SubjectBll.Delete_Subject(int.Parse(((NewListItem)CmbSubject.SelectedItem).Value.ToString()));
                    SubjectFill();
                }
            }
        }

        
    }
}
