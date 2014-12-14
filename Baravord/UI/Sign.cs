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
    public partial class Sign : Form
    {

        string _PageTitle="";
        string _Caption = "";  
        public Sign(string PageTitle,String Caption)
        {
            _PageTitle = PageTitle;
            _Caption = Caption;
            InitializeComponent();
        }

        private void Sign_Load(object sender, EventArgs e)
        {
            ChannelFill();
            this.Text = _Caption;
            
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
            FillSign();
        }
        public void DepsFill()
        {
            cmbDep.Items.Clear();
            List<DepsObj> Deps_Lst =
                DepsBll.Select_All_DepsByChannelId(int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString()));

            foreach (DepsObj item in Deps_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                cmbDep.Items.Add(Lst);
            }

            NewListItem Lst2 = new NewListItem();
            Lst2.Text ="مدیر واحد مربوطه *** ";
            Lst2.Value = "-1";
            cmbDep.Items.Add(Lst2);


            NewListItem Lst3 = new NewListItem();
            Lst3.Text = "تهیه کننده *** ";
            Lst3.Value = "0";
            cmbDep.Items.Add(Lst3);


            if (cmbDep.Items.Count > 0)
            {
                cmbDep.SelectedIndex = 0;
            }

        }

        private void cmbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void FillSign()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("مدیریت");
            DataColumn col3 = new DataColumn("ترتیب");
         
            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);




            SignObj Obj = new SignObj();
            Obj.ChannelID = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
            Obj.PageTitle = _PageTitle;

            List<SignObj> SignLst = SignBll.Select_All_SignByChannelId(Obj);




            foreach (SignObj item in SignLst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;
                if (item.RoleId == -1)
                {
                    row[col2] = "مدیر واحد مربوطه *** ";
                }
                else
                {
                    if (item.RoleId == 0)
                    {
                        row[col2] = "تهیه کننده *** ";
                    }
                    else
                    {
                        row[col2] = DepsBll.Select_Current_Deps(item.RoleId).Title;
                    }
                }                
                row[col3] = item.Sort;
                DTable.Rows.Add(row);

            
            }

            dgvSigns.DataSource = DTable;
            dgvSigns.Columns[0].Width = 40;
            dgvSigns.Columns[1].Width = 200;
            dgvSigns.Columns[2].Width = 60;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {

            SignObj Obj = new SignObj();
            Obj.ChannelID = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
            Obj.PageTitle = _PageTitle;
            Obj.Sort = int.Parse(NudSecond.Value.ToString());
            Obj.RoleId = int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString());
            SignBll.Insert_Sign_Base(Obj);


            FillSign();
        }

        private void dgvSigns_DoubleClick(object sender, EventArgs e)
        {
            //int.Parse(dgvRoles.SelectedRows[i].Cells[0].Value.ToString()));
           SignObj Obj=  SignBll.Select_Current_Sign(int.Parse(dgvSigns.SelectedRows[0].Cells[0].Value.ToString()));

           for (int i = 0; i < cmbDep.Items.Count; i++)
           {

               NewListItem LstChk = (NewListItem)cmbDep.Items[i];

               if (LstChk.Value.ToString() == Obj.RoleId.ToString())
               {
                   cmbDep.SelectedIndex = i;
               }
           }

           NudSecond.Value = decimal.Parse(Obj.Sort.ToString());
           pbSave.Visible = true;
           pbAdd.Visible = false;
           dgvSigns.Enabled = false;


        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            if (dgvSigns.SelectedRows.Count > 0)
            {
                DialogResult Rslt = MessageBox.Show("آیا مدیریت انتخاب شده حذف گردد؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rslt == DialogResult.Yes)
                {
                    SignBll.Delete_Sign(int.Parse(dgvSigns.SelectedRows[0].Cells[0].Value.ToString()));
                    FillSign();
                }
            }

        }

        private void pbSave_Click(object sender, EventArgs e)
        {

            SignObj Obj = new SignObj();
            Obj.ChannelID = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
            Obj.PageTitle = _PageTitle;
            Obj.Sort = int.Parse(NudSecond.Value.ToString());
            Obj.RoleId = int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString());
            Obj.Id = int.Parse(dgvSigns.SelectedRows[0].Cells[0].Value.ToString());
           SignBll.Update_Current_Sign(Obj);



            pbSave.Visible = false;
            pbAdd.Visible = true;
            dgvSigns.Enabled = true;
            FillSign();
        }
    }
}
