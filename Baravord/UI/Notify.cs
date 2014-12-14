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
using Baravord.Properties;
using Baravord.TOOLS;


namespace Baravord.UI
{
    public partial class Notify : Form
    {
        int _Kind = 1;
        public Notify(int Kind)
        {
            InitializeComponent();
            _Kind = Kind;
        }

        private void Notify_Load(object sender, EventArgs e)
        {
            NotifyFill(_Kind);
        }
        public void NotifyFill(int Kind)
        {
            if (Kind == 1)
            {
                NotifyBll Not_Bll = new NotifyBll();
                List<NotifyObj> Notify_Lst = Not_Bll.Select_All_Notify(1);

                CmbNotify.Items.Clear();

                foreach (NotifyObj item in Notify_Lst)
                {
                    NewListItem Lst = new NewListItem();
                    Lst.Text = item.Title;
                    Lst.Value = item.Id;

                    CmbNotify.Items.Add(Lst);
                }
                this.Text = "مدیریت توجه";

            }
            if (Kind == 2)
            {
                NotifyBll Not_Bll2 = new NotifyBll();
                List<NotifyObj> Notify_Lst2 = Not_Bll2.Select_All_Notify(2);

                CmbNotify.Items.Clear();

                foreach (NotifyObj item in Notify_Lst2)
                {
                    NewListItem Lst2 = new NewListItem();
                    Lst2.Text = item.Title;
                    Lst2.Value = item.Id;

                    CmbNotify.Items.Add(Lst2);
                }

                this.Text = "مدیریت توضیحات";

            }


            CmbNotify.SelectedIndex = 0;
        }

        private void CmbNotify_SelectedIndexChanged(object sender, EventArgs e)
        {


          NotifyObj Obj=   
              NotifyBll.Select_Current_Notify(int.Parse(((NewListItem)CmbNotify.SelectedItem).Value.ToString()));

          richTextBox1.Text = Obj.Title;
          nudSort.Value = Obj.Sort;

        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            richTextBox1.Text = "";
            nudSort.Value = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert New Object

            NotifyObj Obj = new NotifyObj();
            Obj.Title = richTextBox1.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());
            Obj.Kind=_Kind;

            if (richTextBox1.Text.Length > 2)
            {

                NotifyBll.Insert_Notify_Base(Obj);

                NotifyFill(_Kind);

                pictureBox1.Visible = false;
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update Current Object

            NotifyObj Obj = new NotifyObj();
            Obj.Title = richTextBox1.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());
            Obj.Kind = _Kind;

            Obj.Id = int.Parse(((NewListItem)CmbNotify.SelectedItem).Value.ToString());

            if (richTextBox1.Text.Length > 2)
            {
                NotifyBll.Update_Current_Notify(Obj);


                NotifyFill(_Kind);
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
                    NotifyBll.Select_NotifiesById(int.Parse(((NewListItem)CmbNotify.SelectedItem).Value.ToString()));


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
                    NotifyBll.Delete_Notify(int.Parse(((NewListItem)CmbNotify.SelectedItem).Value.ToString()));
                    NotifyFill(_Kind);
                }
            }
        }
    }
}
