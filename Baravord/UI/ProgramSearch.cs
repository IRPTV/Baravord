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
    public partial class ProgramSearch : Form
    {
        int _Dep = 1;
        public ProgramSearch(int Dep)
        {
            _Dep = Dep;
            InitializeComponent();
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

            if (Deps_Lst.Count > 0)
            {
                cmbDep.SelectedIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgramObj PrObj = new ProgramObj();
            PrObj.Id = int.Parse(dgvResult.SelectedRows[0].Cells[0].Value.ToString());
            GlobalObjectTools.SetGlobalProgramObject(PrObj);
            //this.WindowState = FormWindowState.Minimized;
            //this.Close();
        }

        private void ProgramSearch_Load(object sender, EventArgs e)
        {
           // btnSearch_Click(new object(), new EventArgs());
            #region FillData
            //FillCmb Channel
            ChannelFill();

            //Fill Languages to Combo Box
            LanguageFill();

            //Fill Providers to Combo Box
            ProviderFill();
            DepsFill();

            #endregion
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


        public void ProviderFill()
        {
            List<ProviderObj> Sub_Lst = ProvidersBll.Select_All_Providers();

            CmbProvider.Items.Clear();

            foreach (ProviderObj item in Sub_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.LASTNAME + " - " + item.Name;
                Lst.Value = item.Id;
                CmbProvider.Items.Add(Lst);
            }
            CmbProvider.SelectedIndex = 0;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder Query = new StringBuilder();

            //CHECK HERE FOR EVERY FIELD
            if (chkTitleFarsi.Checked)
            {
                Query.Append("and Title_Farsi like N'%"+txtTileFarsi.Text.Trim()+"%' ");
            }

            if (chkTitle2.Checked)
            {
                Query.Append("and Title_2 like N'%" + txtTitle2.Text.Trim() + "%' ");
            }

            if (chkDirector.Checked)
            {
                Query.Append("and Director_Name like N'%" + txtDirector.Text.Trim() + "%' ");
            }

            if (chkBaravordNumber.Checked)
            {
                Query.Append("and Baravord_Number like N'%" + txtBaravordNumber.Text.Trim() + "%' ");
            }

            if (chkChannel.Checked)
            {
                Query.Append("and ChannelId =" + ((NewListItem)CmbChannel.SelectedItem).Value.ToString() + " ");
            }
            if (chkProvider.Checked)
            {
                Query.Append("and Provider_Id =" + ((NewListItem)CmbProvider.SelectedItem).Value.ToString() + " ");
            }
            if (chkLanguage.Checked)
            {
                Query.Append("and Language_Id =" + ((NewListItem)cmbLanguage.SelectedItem).Value.ToString() + " ");
            }

            if (ChkDep.Checked)
            {
                Query.Append("and depart =" + ((NewListItem)cmbDep.SelectedItem).Value.ToString() + " ");
            }

            Query.Append("and Dep =" +_Dep+ " ");

            if (chkBaravordNumber.Checked || chkDatetime.Checked
              || chkDirector.Checked || chkLanguage.Checked ||
              chkProvider.Checked || chkTitle2.Checked
              || chkTitleFarsi.Checked|| chkChannel.Checked)
            {
              //  MessageBox.Show("Select * From program " +" where "+ Query.ToString().Remove(0,3)+ "ORDER BY Act_DateTime DESC");
                //EXECUTE QUERY HERE
                FillResultGrid(ProgramBll.Search_Prgrams("Select * From program " + " where " + Query.ToString().Remove(0, 3) + "ORDER BY Baravord_Number Desc , Datetime_Publish , Datetime_edit "));
                //richTextBox1.Text = "Select * From program " + Query.ToString().Remove(0, 3) + "ORDER BY Act_DateTime DESC";
            }
            else
            {              
                //EXECUTE QUERY HERE
                FillResultGrid(ProgramBll.Search_Prgrams("Select * From program where dep=" + _Dep.ToString() + "ORDER BY Baravord_Number Desc , Datetime_Publish , Datetime_edit "));
            }
        }

        private void FillResultGrid(List<ProgramObj> InObj)
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("عنوان فارسی");
            DataColumn col4 = new DataColumn("عنوان زبان اصلی");
            DataColumn col3 = new DataColumn("شماره برآورد");
            DataColumn col6 = new DataColumn("تاریخ صدور");
            DataColumn col7 = new DataColumn("تاریخ اصلاح");
            DataColumn col5 = new DataColumn("شبکه");
            DataColumn col8 = new DataColumn("پدیدآور");
           
            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col8);
        
         


            foreach (ProgramObj item in InObj)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;
                row[col2] = item.Title_Farsi;
                row[col4] = item.Title_2;
                //row[col3] = ToolsFunctions.GenerateBaravordCode(
                //DateConversion.GD2JD(item.Act_DateTime),
                //item.ChannelId)+ item.Baravord_Number;

                row[col3] = item.Baravord_Number;

                row[col6] = DateConversion.GD2JD(item.Datetime_Publish);

                if (DateConversion.GD2JD(item.Datetime_Publish) == DateConversion.GD2JD(item.Datetime_Edit))
                {
                    row[col7] = "";
                }
                else
                {

                    row[col7] = DateConversion.GD2JD(item.Datetime_Edit);
                }
               // System.Configuration.ConfigurationSettings.AppSettings["ImageAddress"]
                //Bitmap Bmp=new Bitmap (@"f:\projects\baravordweb\baravordweb\images\" +
                //    ChannelBll.Select_Current_Channel(item.ChannelId).LogoUrl + ".jpg");

               // row.ItemArray.SetValue(Bmp, 4);
                // row.ItemArray.SetValue(Bmp, 4);
                row[col5] = ChannelBll.Select_Current_Channel(item.ChannelId).Title;
                List<ProviderObj> Lst = BLL.ProvidersBll.Search_Providers(" where  id="+item.Provider_Id);
                if(Lst.Count>0)
                {
                    row[col8] = Lst[0].LASTNAME + "-" + Lst[0].Name;
                }
                else
                {
                     row[col8] ="";
                }
                DTable.Rows.Add(row);
            }

            dgvResult.DataSource = DTable;
            dgvResult.Columns[0].Visible = false;
            //dgvResult.Columns[0].Width = 40;
            //dgvResult.Columns[1].Width = 200;
            //dgvResult.Columns[2].Width = 150;
            //dgvResult.Columns[3].Width = 120;
            //dgvResult.Columns[4].Width = 120;
            //dgvResult.Columns[5].Width = 120;
            //dgvResult.Columns[6].Width = 100;
        }



        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                button1_Click(new object(), new EventArgs());
            }
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                ProgramObj PrObj = new ProgramObj();
                PrObj.Id = int.Parse(dgvResult.SelectedRows[0].Cells[0].Value.ToString());
                DAL.ProgramDal PDl = new DAL.ProgramDal();
                PrObj = PDl.Select_Current_Prgram(PrObj);
                PrObj.Datetime_Edit = DateTime.Now;
                ProgramObj PrObjNew = PDl.Insert_Prgram(PrObj);

               //Live


                //level:
               DAL.LevelDal Lvl = new DAL.LevelDal();
               List<LevelObj> LvlLst= Lvl.Select_All_Program_Levels(PrObj);
               Lvl.Insert_Program_Level(LvlLst, PrObjNew);

                

               //Location:
               DAL.Program_LocationDal Loc = new DAL.Program_LocationDal();
               List<Program_LocationObj> LocLst = Loc.Select_Program_Location(PrObj);
               foreach (Program_LocationObj item in LocLst)
               {
                   Loc.Insert_Program_Location(item, PrObjNew);
               }


               //Payments:
               DAL.Program_PaymentDal Pay = new DAL.Program_PaymentDal();
               List<Program_PaymentObj> PayLst = Pay.Select_Program_Payment(PrObj);
               foreach (Program_PaymentObj item in PayLst)
               {
                   Pay.Insert_Program_Payment(item, PrObjNew);
               }


               //Role:
               DAL.Program_RoleDal Rol= new DAL.Program_RoleDal();
               List<Program_RoleObj> RolLst = Rol.Select_All_Program_Roles(PrObj);
               foreach (Program_RoleObj item in RolLst)
               {
                   Rol.Insert_Program_Role(item, PrObjNew);
               }

               //Session:
               DAL.Program_SessionDal Ses = new DAL.Program_SessionDal();
               List<Program_SessionObj> SesLst = Ses.Select_Program_Session(PrObj);
               foreach (Program_SessionObj item in SesLst)
               {
                   item.Program_Id = PrObjNew.Id;
                   Ses.Insert_Program_Session(item);
               }

               //Structure:
               DAL.StructureDal Struct = new DAL.StructureDal();
               List<StructureObj> StructLst = Struct.Select_Program_Structs(PrObj);
               Struct.Insert_Program_Structs(StructLst, PrObjNew);

               //Target:
               DAL.TargetDal Targ = new DAL.TargetDal();
               List<TargetObj> TargLst = Targ.Select_All_Program_Target(PrObj);
               Targ.Insert_Program_Target(TargLst, PrObjNew);

               //Target:
               DAL.NotifyDal Notf = new DAL.NotifyDal();
               List<NotifyObj> NotfLst = Notf.Select_Program_Notify(PrObj);
               Notf.Insert_Program_Notify(NotfLst, PrObjNew);

              
               
               

               btnSearch_Click(new object(), new EventArgs());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                SendToBacks("Printcost");
                Form2 Frm = new Form2(int.Parse(dgvResult.SelectedRows[0].Cells[0].Value.ToString()), "Printcost");
                Frm.TopMost = true;
                Frm.MdiParent = this.MdiParent;
                Frm.Show();
            }
            else
            {
                MessageBox.Show("ردیفی انتخاب نشده است","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepsFill();
        }
    }
}