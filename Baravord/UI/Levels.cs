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
    public partial class Levels : Form
    {
        public Levels()
        {
            InitializeComponent();
        }

        private void Levels_Load(object sender, EventArgs e)
        {
            LevelFill();
        }
        public void LevelFill()
        {
            LevelBll Level_Bll = new LevelBll();
            List<LevelObj> Lev_Lst = Level_Bll.Select_All_Level();

            CmbLevel.Items.Clear();

            foreach (LevelObj item in Lev_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbLevel.Items.Add(Lst);
            }

            CmbLevel.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //Insert New  Level

            LevelObj Lvl = new LevelObj ();
            Lvl.Title=txtTitle.Text;
            Lvl.Sort=int.Parse(nudSort.Value.ToString());


            pictureBox5.Visible = true;
            pictureBox2.Visible = true;



            if (txtTitle.Text.Length > 2)
            {

                LevelBll.Insert_Level_INLVL(Lvl);


                pictureBox1.Visible = false;
                LevelFill();

            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }

           

        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pbAddSession.Visible = false;
            pictureBox2.Visible = false;
            txtTitle.Text = "";
            nudSort.Value = 1;
            pictureBox5.Visible = false;
        }

        private void CmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Current
            pictureBox1.Visible = false;

            NewListItem Lst= (NewListItem) CmbLevel.SelectedItem;

            LevelObj Lvl = LevelBll.Select_Current_Level(int.Parse(Lst.Value.ToString()));


            txtTitle.Text = Lvl.Title;
            nudSort.Value = Lvl.Sort;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update

            LevelObj Lvl = new LevelObj();
            Lvl.Title = txtTitle.Text;
            Lvl.Sort = int.Parse(nudSort.Value.ToString());


            NewListItem Lst = (NewListItem)CmbLevel.SelectedItem;
            Lvl.Id = int.Parse(Lst.Value.ToString());

            if (txtTitle.Text.Length > 2)
            {

                LevelBll.Update_Current_Level(Lvl);

                LevelFill();
                pictureBox2.Visible = false;
                pbAddSession.Visible = true;
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا طبقه انتخاب شده حذف گردد؟", "حذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<string[]> Lst =
                    LevelBll.Select_Levels(int.Parse(((NewListItem)CmbLevel.SelectedItem).Value.ToString()));


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
                    MessageBox.Show("  این طبقه در برنامه های زیر استفاده شده است  " + " \n" + Str);
                }
                else
                {
                    LevelBll.Delete_Level(int.Parse(((NewListItem)CmbLevel.SelectedItem).Value.ToString()));
                    LevelFill();
                }
            }
        }
    }
}
