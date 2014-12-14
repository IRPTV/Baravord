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
    public partial class Deps : Form
    {
        public Deps()
        {
            InitializeComponent();
        }

        private void Deps_Load(object sender, EventArgs e)
        {
            ChannelFill();
        }
        public void DepsFill()
        {
            cmbDep.Items.Clear();
           List<DepsObj> Deps_Lst=
               DepsBll.Select_All_DepsByChannelId(int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString()));

           foreach (DepsObj item in Deps_Lst)
           {
               NewListItem Lst = new NewListItem();
               Lst.Text = item.Title;
               Lst.Value = item.Id;

               cmbDep.Items.Add(Lst);
           }

           if (Deps_Lst.Count > 0)
           {
               cmbDep.SelectedIndex = 0;
           }

        }

        public void ChannelFill()
        {
            ChannelBll Chennels_Bll = new ChannelBll();
            List<ChannelObj> Ch_Lst = Chennels_Bll.Select_All_Channel();
            CmbChannel.Items.Clear();

            foreach (ChannelObj item in Ch_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbChannel.Items.Add(Lst);
            }
            CmbChannel.SelectedIndex = 0;
        }

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepsFill();
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim().Length > 2)
            {
                DepsObj Obj = new DepsObj();
                Obj.Title = txtTitle.Text.Trim();
                Obj.ChannelId = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
                DepsBll.Insert_Deps_Base(Obj);
                DepsFill();
                txtTitle.Text = "";
            }
            else
            {
                MessageBox.Show("عنوان مدیریت حداقل باید سه حرف باشد");
            }
            
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            DialogResult Rslt = MessageBox.Show("آیا مدیریت انتخاب شده حذف گردد؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Rslt == DialogResult.Yes)
            { 
                //Check If Deps Used in Sign



                //Check if Deps Used in Program Master Data (Depart)
                List<ProgramObj> Lst_Prog =
                 ProgramBll.Search_Prgrams("Select * From program  where  Depart=" +
                 ((NewListItem)cmbDep.SelectedItem).Value.ToString());


                if (Lst_Prog.Count > 0)
                {
                    string Str = "";
                    string Dep = "";
                    foreach (ProgramObj item in Lst_Prog)
                    {
                        Dep = (item.Dep == 1) ? "    واحد تولید    " : "      واحد اطلاعات و برنامه ریزی     ";
                        Str += item.Title_Farsi + " " + Dep + "\n";
                    }
                    MessageBox.Show("  این مدیریت  در برنامه های زیر استفاده شده است  " + " \n" + Str);
                }
                else
                {
                    DepsBll.Delete_Deps(int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString()));
                    DepsFill();
                }
               
            }

        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            pbSave.Visible = true;
            pbAdd.Visible = false;

            DepsObj Obj = DepsBll.Select_Current_Deps(int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString()));
            txtTitle.Text = Obj.Title;
        }

        private void pbSave_Click(object sender, EventArgs e)
        {           
            DepsObj Obj = new DepsObj();
            Obj.Title = txtTitle.Text.Trim();
            Obj.ChannelId = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
            Obj.Id = int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString());

            DepsBll.Update_Current_Deps(Obj);
            pbSave.Visible = false;
            pbAdd.Visible = true;
            txtTitle.Text = "";
            DepsFill();
        }
    }
}
