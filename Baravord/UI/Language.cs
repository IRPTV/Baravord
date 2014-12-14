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
    public partial class Language : Form
    {
        public Language()
        {
            InitializeComponent();
        }

        private void Language_Load(object sender, EventArgs e)
        {
            LanguageFill();
        }

        public void LanguageFill()
        {

            List<LanguageObj> Lan_Lst = LanguageBll.Select_All_Languages();
            cmbLanguage.Items.Clear();

            foreach (LanguageObj item in Lan_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                cmbLanguage.Items.Add(Lst);
            }
            cmbLanguage.SelectedIndex = 0;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
              NewListItem Lst = (NewListItem)cmbLanguage.SelectedItem;
              int LangId = int.Parse(Lst.Value.ToString());

              LanguageObj Obj = LanguageBll.Select_Current_Language(LangId);

              txtTitle.Text = Obj.Title;

              pictureBox1.Visible = false;

            
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add New Language
            pictureBox1.Visible = false;

            LanguageObj Obj = new LanguageObj();
            Obj.Title = txtTitle.Text.Trim();

            if (txtTitle.Text.Length > 2)
            {

                LanguageBll.INSERT_LANGUAGE(Obj);
                LanguageFill();

            }
            else
            {
                MessageBox.Show("عنوان زبان باید حداقل سه کاراکتر باشد");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NewListItem Lst = (NewListItem)cmbLanguage.SelectedItem;
            int LangId = int.Parse(Lst.Value.ToString());

            LanguageObj Obj = new LanguageObj();
            Obj.Title = txtTitle.Text.Trim();
            Obj.Id = LangId;



            if (txtTitle.Text.Length > 2)
            {

                LanguageBll.UPDATE_LANGUAGE(Obj);

                LanguageFill();

            }
            else
            {
                MessageBox.Show("عنوان زبان باید حداقل سه کاراکتر باشد");
            }
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا زبان انتخاب شده حذف گردد؟", "حذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<ProgramObj> Lst_Prog =
                    ProgramBll.Search_Prgrams("Select * From program  where  Language_Id=" +
                    ((NewListItem)cmbLanguage.SelectedItem).Value.ToString());


                if (Lst_Prog.Count > 0)
                {
                    string Str = "";
                    string Dep = "";
                    foreach (ProgramObj item in Lst_Prog)
                    {
                        Dep = (item.Dep == 1) ? "    واحد تولید    " : "      واحد اطلاعات و برنامه ریزی     ";
                        Str += item.Title_Farsi + " " + Dep + "\n";
                    }
                    MessageBox.Show("  این زبان در برنامه های زیر استفاده شده است  " + " \n" + Str);
                }
                else
                {
                    LanguageBll.Delete_LANGUAGE(((NewListItem)cmbLanguage.SelectedItem).Value.ToString());
                    LanguageFill();
                }

            }
            
        }     

    }
}
