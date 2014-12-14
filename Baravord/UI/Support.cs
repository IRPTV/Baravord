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
using Baravord.MyDBTableAdapters;

namespace Baravord.UI
{
    public partial class Support : Form
    {
        public Support()
        {
            InitializeComponent();
        }

        int _Id = 0;
        private void Support_Load(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }


            cmbUnit.Items.Clear();

            //Unit Combo Box
            NewListItem Unit_Lst = new NewListItem();
            Unit_Lst.Text = "برنامه";
            Unit_Lst.Value = "1";
            cmbUnit.Items.Add(Unit_Lst);
            cmbUnit.SelectedIndex = 0;

            NewListItem Music_Lst2 = new NewListItem();
            Music_Lst2.Text = "درکل";
            Music_Lst2.Value = "2";
            cmbUnit.Items.Add(Music_Lst2);


            NewListItem Unit_Lst3 = new NewListItem();
            Unit_Lst3.Text = "دقیقه";
            Unit_Lst3.Value = "3";
            cmbUnit.Items.Add(Unit_Lst3);


            NewListItem Unit_Lst4 = new NewListItem();
            Unit_Lst4.Text = "ثانیه";
            Unit_Lst4.Value = "4";
            cmbUnit.Items.Add(Unit_Lst4);

            NewListItem Unit_Lst5 = new NewListItem();
            Unit_Lst5.Text = "جلسه";
            Unit_Lst5.Value = "5";
            cmbUnit.Items.Add(Unit_Lst5);



            NewListItem Unit_Lst6 = new NewListItem();
            Unit_Lst6.Text = "نفر روز";
            Unit_Lst6.Value = "6";
            cmbUnit.Items.Add(Unit_Lst6);


            NewListItem Unit_Lst7 = new NewListItem();
            Unit_Lst7.Text = "نفر ماه";
            Unit_Lst7.Value = "7";
            cmbUnit.Items.Add(Unit_Lst7);


            NewListItem Unit_Lst8 = new NewListItem();
            Unit_Lst8.Text = "کار";
            Unit_Lst8.Value = "8";
            cmbUnit.Items.Add(Unit_Lst8);


            NewListItem Unit_Lst9 = new NewListItem();
            Unit_Lst9.Text = "ساعت";
            Unit_Lst9.Value = "9";
            cmbUnit.Items.Add(Unit_Lst9);

            NewListItem Unit_Lst10 = new NewListItem();
            Unit_Lst10.Text = "مقاله";
            Unit_Lst10.Value = "10";
            cmbUnit.Items.Add(Unit_Lst10);

            NewListItem Unit_Lst11 = new NewListItem();
            Unit_Lst11.Text = "صفحه";
            Unit_Lst11.Value = "11";
            cmbUnit.Items.Add(Unit_Lst11);


            ChannelFill();
            RoleFill();
            txtDatePublishFrom.Text = DateConversion.GD2JD(DateTime.Now).Split('/')[0].ToString() + "/01/01";
            txtDatePublishTo.Text = DateConversion.GD2JD(DateTime.Now);
        }

        public void RoleFill()
        {

            CmbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CmbRole.AutoCompleteSource = AutoCompleteSource.ListItems;



            RoleBll Rol_Bll = new RoleBll();
            List<RoleObj> Rl_Lst = Rol_Bll.Select_All_Role();

            CmbRole.Items.Clear();

            NewListItem Lst = new NewListItem();
            Lst.Text = "";
            Lst.Value = "0";
            CmbRole.Items.Add(Lst);

            foreach (RoleObj item in Rl_Lst)
            {
                Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbRole.Items.Add(Lst);
            }
            CmbRole.SelectedIndex = 0;
        }

        public void ChannelFill()
        {
            CmbChannel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CmbChannel.AutoCompleteSource = AutoCompleteSource.ListItems;


            ChannelBll Chennels_Bll = new ChannelBll();
            List<ChannelObj> Ch_Lst = Chennels_Bll.Select_All_Channel();
            CmbChannel.Items.Clear();
            CmbChannel1.Items.Clear();


            NewListItem Lst = new NewListItem();
            Lst.Text = "";
            Lst.Value = "0";

            CmbChannel.Items.Add(Lst);
            CmbChannel1.Items.Add(Lst);

            foreach (ChannelObj item in Ch_Lst)
            {
                Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbChannel.Items.Add(Lst);
                CmbChannel1.Items.Add(Lst);
            }
            CmbChannel.SelectedIndex = 0;
            CmbChannel1.SelectedIndex = 0;
        }
        public void DepsFill()
        {

            cmbDep.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDep.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbDep.Items.Clear();

            List<DepsObj> Deps_Lst =
                DepsBll.Select_All_DepsByChannelId(int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString()));
            NewListItem Lst = new NewListItem();
            Lst.Text = "";
            Lst.Value = "0";
            cmbDep.Items.Add(Lst);

            foreach (DepsObj item in Deps_Lst)
            {

                Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                cmbDep.Items.Add(Lst);

            }
            cmbDep.SelectedIndex = 0;


        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim().Length > 5)
            {
                if (txtPublishDate.Text.Trim().Length == 10)
                {

                    if (_Id == 0)
                    {


                      


                        //if (txtTitle.Text.Trim().Length > 1)
                        //{
                        if (txtPublishDate.Text.Trim().Length == 10)
                        {
                            try
                            {

                                try
                                {
                                    DateConversion.JD2GD(txtPublishDate.Text.Trim());
                                }
                                catch (Exception Er)
                                {

                                    MessageBox.Show("لطفا تاریخ صدور برآورد را به صورت " + DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime()) + " وارد نمایید" + "\n" + Er.Message);
                                    txtPublishDate.Focus();
                                    txtPublishDate.SelectionLength = txtPublishDate.Text.Length;
                                }
                                if (CmbChannel.SelectedIndex != 0)
                                {
                                    if (cmbDep.SelectedIndex != 0)
                                    {
                                        SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                                        _Id = int.Parse(Sp_Ta.Insert_Support(txtTitle.Text,
                                            txtNumber.Text,
                                           DateConversion.JD2GD(txtPublishDate.Text.Trim()),
                                           txtDateFinance.Text,
                                           txtDateEdit.Text,
                                           int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString()),
                                           txtDesc.Text,
                                           textBox4.Text,
                                           checkBox1.Checked,
                                            int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString()),
                                            false).ToString());

                                        MessageBox.Show("اطلاعات ذخیره شد می توانید کد های آنرا وارد نمایید");
                                        groupBox2.Enabled = true;
                                        numericUpDownSort.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("واحد را انتخاب کنید");
                                        cmbDep.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("شبکه را انتخاب کنید");
                                    CmbChannel.Focus();

                                }

                            }
                            catch (Exception Exp)
                            {
                                MessageBox.Show(Exp.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("لطفا تاریخ صدور برآورد را به صورت " + DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime()) + " وارد نمایید");
                            txtPublishDate.Focus();
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("لطفا عنوان برآورد را وارد نمایید");
                        //}

                    }
                    else
                    {
                        //Update Existing Record
                        try
                        {

                            try
                            {
                                DateConversion.JD2GD(txtPublishDate.Text.Trim());
                            }
                            catch (Exception Er)
                            {

                                MessageBox.Show("لطفا تاریخ صدور برآورد را به صورت 1392/01/01 وارد نمایید" + "\n" + Er.Message);
                                txtPublishDate.Focus();
                            }


                            if (CmbChannel.SelectedIndex != 0)
                            {
                                if (cmbDep.SelectedIndex != 0)
                                {
                                    if (txtDateEdit.Text.Trim().Length == 10)
                                    {
                                        try
                                        {
                                            DateConversion.JD2GD(txtDateEdit.Text.Trim());
                                        }
                                        catch
                                        {
                                            MessageBox.Show("لطفا تاریخ اصلاحیه را به صورت 1392/01/01 یا بزنید" + "\n" + "Or F3");
                                            txtDateEdit.Focus();
                                        }



                                        SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                                        Sp_Ta.Update_Support(txtTitle.Text,
                                            txtNumber.Text,
                                           DateConversion.JD2GD(txtPublishDate.Text.Trim()),
                                           txtDateFinance.Text,
                                           txtDateEdit.Text,
                                           int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString()),
                                           txtDesc.Text,
                                           textBox4.Text,
                                           checkBox1.Checked,
                                            int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString()),
                                            false
                                            , _Id);


                                        MessageBox.Show("اطلاعات با موفقیت به روز شد");
                                      //  numericUpDownSort.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("لطفا تاریخ اصلاحیه را به صورت 1392/01/01 یا بزنید" + "\n" + "Or F3");
                                        txtDateEdit.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("واحد را انتخاب کنید");
                                    cmbDep.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("شبکه را انتخاب کنید");
                                CmbChannel.Focus();

                            }

                        }
                        catch (Exception Exp)
                        {
                            MessageBox.Show(Exp.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لطفا تاریخ صدور برآورد را به صورت 1392/01/01 وارد نمایید");
                    txtPublishDate.Focus();
                }

            }
            else
            {
                MessageBox.Show("لطفا شماره برآورد را وارد نمایید");
                txtNumber.Focus();
            }
        }

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepsFill();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void FillGrid()
        {

            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_All();

            StringBuilder Str = new StringBuilder();

            if (checkBox2.Checked)
            {
                Str.Append(" Title like N'%" + textBox12.Text.Trim() + "%' and ");
            }
            if (checkBox5.Checked)
            {
                Str.Append(" BARAVORD_NUMBER=N'" + textBox11.Text.Trim() + "' and ");
            }

            if (checkBox4.Checked)
            {
                Str.Append(" CHANNEL_ID=" + ((NewListItem)CmbChannel1.SelectedItem).Value.ToString() + "  and ");
            }

            if (checkBox6.Checked)
            {
                Str.Append(" DEP_ID=" + ((NewListItem)cmbDep1.SelectedItem).Value.ToString() + "  and ");

            }
            if (checkBox3.Checked)
            {
                try
                {
                    Str.Append("  DATETIME_PUBLISH between  convert(datetime, '" + DateConversion.JD2GD(txtDatePublishFrom.Text).ToShortDateString() + "', 101) " +
                   "   and " + "convert(datetime, '" + DateConversion.JD2GD(txtDatePublishTo.Text).AddMinutes(1439).ToShortDateString() + "', 101)  and ");
                }
                catch
                {
                    MessageBox.Show("لطفا تاریخ صدور برآورد را به صورت " + DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime()) + " وارد نمایید" + "\n");

                }

            }

            if (checkBox2.Checked || checkBox5.Checked || checkBox4.Checked || checkBox6.Checked || checkBox3.Checked)
            {
                Sp_Dt = Sp_Ta.Search_Support(" where " + Str.Remove(Str.Length - 4, 4).ToString() + " and deleted=0");

            }
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("عنوان برآورد");
            DataColumn col3 = new DataColumn("شماره برآورد");
            DataColumn col4 = new DataColumn("تاریخ صدور");
            DataColumn col5 = new DataColumn("تاریخ مالی");
            DataColumn col6 = new DataColumn("تاریخ اصلاح");
            DataColumn col7 = new DataColumn("شبکه");
            DataColumn col8 = new DataColumn("واحد");


            DataGridViewCheckBoxColumn col9 = new DataGridViewCheckBoxColumn();

            {
                col9.HeaderText = "ترکیب";
                col9.Name = "Merge";
            }

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col8);

            List<int> Cancels = new List<int>();

            for (int i = 0; i < Sp_Dt.Rows.Count; i++)
            {
                DataRow row = DTable.NewRow();

                row[col1] = Sp_Dt[i]["ID"];
                row[col2] = Sp_Dt[i]["Title"];
                row[col3] = Sp_Dt[i]["BARAVORD_NUMBER"];
                row[col4] = DateConversion.GD2JD(DateTime.Parse(Sp_Dt[i]["DATETIME_PUBLISH"].ToString()));
                row[col5] = Sp_Dt[i]["DATETIME_FINANCE"];
                row[col6] = Sp_Dt[i]["DATETIME_EDIT"];
                row[col7] = ChannelBll.Select_Current_Channel(int.Parse(Sp_Dt[i]["CHANNEL_ID"].ToString())).Title;
                row[col8] = DepsBll.Select_Current_Deps(int.Parse(Sp_Dt[i]["DEP_ID"].ToString())).Title;
                DTable.Rows.Add(row);
                if (bool.Parse(Sp_Dt[i]["cancel"].ToString()) == true)
                {
                    Cancels.Add(int.Parse(Sp_Dt[i]["ID"].ToString()));


                }
            }
            dgvSearchResult.Columns.Clear();
            dgvSearchResult.DataSource = DTable;


            dgvSearchResult.Columns["ID"].Width = 40;
            dgvSearchResult.Columns["عنوان برآورد"].Width = 180;
            dgvSearchResult.Columns["شماره برآورد"].Width = 100;
            dgvSearchResult.Columns["تاریخ صدور"].Width = 90;
            dgvSearchResult.Columns["تاریخ مالی"].Width = 90;
            dgvSearchResult.Columns["تاریخ اصلاح"].Width = 90;
            dgvSearchResult.Columns["شبکه"].Width = 150;
            dgvSearchResult.Columns["واحد"].Width = 140;

            dgvSearchResult.Columns.Add(col9);
            dgvSearchResult.Columns["Merge"].Width = 45;


            for (int i = 0; i < dgvSearchResult.RowCount; i++)
            {
                dgvSearchResult.Rows[i].Cells["Merge"].Value = false;

                for (int j = 0; j < Cancels.Count; j++)
                {
                    if (dgvSearchResult.Rows[i].Cells["ID"].Value.ToString() == Cancels[j].ToString())
                    {
                        for (int p = 0; p < 9; p++)
                        {
                            dgvSearchResult.Rows[i].Cells[p].Style.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }
        protected void LoadSupportData()
        {


            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_Current_Support(_Id);

            txtTitle.Text = Sp_Dt[0]["Title"].ToString();
            txtNumber.Text = Sp_Dt[0]["BARAVORD_NUMBER"].ToString();
            txtPublishDate.Text = DateConversion.GD2JD(DateTime.Parse(Sp_Dt[0]["DATETIME_PUBLISH"].ToString()));
            txtDateFinance.Text = Sp_Dt[0]["DATETIME_FINANCE"].ToString();
            txtDateEdit.Text = Sp_Dt[0]["DATETIME_EDIT"].ToString();
            textBox4.Text = Sp_Dt[0]["DATETIME_CANCEL"].ToString();
            checkBox1.Checked = bool.Parse(Sp_Dt[0]["CANCEL"].ToString());
            txtDesc.Text = Sp_Dt[0]["DESCPRIPTION"].ToString();
            FillRoleGrid();

            for (int i = 0; i < CmbChannel.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)CmbChannel.Items[i];

                if (Ch.Value.ToString() == Sp_Dt[0]["CHANNEL_ID"].ToString())
                {
                    CmbChannel.SelectedIndex = i;
                }
            }

            for (int i = 0; i < cmbDep.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)cmbDep.Items[i];

                if (Ch.Value.ToString() == Sp_Dt[0]["DEP_ID"].ToString())
                {
                    cmbDep.SelectedIndex = i;
                }
            }

            if (bool.Parse(Sp_Dt[0]["CANCEL"].ToString()))
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }

            txtTitle.Focus();

        }

        private void dgvSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _Id = int.Parse(dgvSearchResult.SelectedRows[0].Cells[0].Value.ToString());
            tabControl1.SelectedIndex = 1;
            LoadSupportData();
            groupBox2.Enabled = true;
        }

        private void pbAddRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnit.Text.Replace(",", "").Length > 1 && int.Parse(txtShift.Text.Trim())
               > 0 && float.Parse(txtMonth.Text.Trim()) > 0)
                {
                    SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();

                    MyDB.SUPPORTDataTable Check =
                        Sp_Ta.Check_Role_Exist(_Id, int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()));
                    if (Check.Rows.Count == 0)
                    {

                        Sp_Ta.Insert_Sopport_Details(_Id,
                            int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()),
                            ((NewListItem)cmbUnit.SelectedItem).Value.ToString(),
                            float.Parse(numericUpDown1.Value.ToString()),
                            txtUnit.Text.Replace(",", ""),
                            float.Parse(txtShift.Text.Trim()),
                            float.Parse(txtMonth.Text.Trim()),
                            txtRoleDesc.Text,
                           int.Parse(numericUpDownSort.Value.ToString()));
                        MessageBox.Show("آیتم با موفقیت اضافه شد");
                        FillRoleGrid();


                        numericUpDownSort.Value += 4;
                    }
                    else
                    {
                        MessageBox.Show("کد فعالیت مورد نظر تکراری میباشد");
                        CmbRole.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("لطفا ارزش واحد و تعداد شیفت و ماه را چک نمایید");
                }
            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.Message);
            }

        }

        protected void FillRoleGrid()
        {
            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_Support_Details(_Id);


            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("کد فعالیت");
            DataColumn col3 = new DataColumn("واحد");
            DataColumn col4 = new DataColumn("تعداد");
            DataColumn col5 = new DataColumn("ارزش واحد");
            DataColumn col6 = new DataColumn("شیفت");
            DataColumn col7 = new DataColumn("ماه");
            DataColumn col8 = new DataColumn("شرح کد");
            DataColumn col9 = new DataColumn("ردیف");
            DataColumn col10 = new DataColumn("ترتیب");
            DataColumn col11 = new DataColumn("ارزش کل");


            DTable.Columns.Add(col9);
            DTable.Columns.Add(col10);
            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col11);
            DTable.Columns.Add(col8);


            for (int i = 0; i < Sp_Dt.Rows.Count; i++)
            {
                DataRow row = DTable.NewRow();
                row[col10] = Sp_Dt[i]["SORT"];
                row[col1] = Sp_Dt[i]["ID"];
                row[col11] = string.Format("{0:n3}", double.Parse(Calculation.RowCostSupport(
                    int.Parse(Sp_Dt[i]["UNIT"].ToString()),
                    float.Parse(Sp_Dt[i]["COUNT"].ToString()),
                    double.Parse(Sp_Dt[i]["PRICE_UNIT"].ToString()),
                    float.Parse(Sp_Dt[i]["shift"].ToString()),
                    float.Parse(Sp_Dt[i]["month"].ToString())))).Replace(".000", "");

                RoleObj RlObj = new RoleObj();
                RlObj.Id = int.Parse(Sp_Dt[i]["ROLE_ID"].ToString());
                row[col2] = RoleBll.Select_Current_Role(RlObj).Title;


                string UnitTitle = "";
                switch (int.Parse(Sp_Dt[i]["UNIT"].ToString()))
                {
                    case 1:
                        UnitTitle = "برنامه";
                        break;
                    case 2:
                        UnitTitle = "در کل";
                        break;
                    case 3:
                        UnitTitle = "دقیقه";
                        break;
                    case 4:
                        UnitTitle = "ثانیه";
                        break;

                    case 5:
                        UnitTitle = "جلسه";
                        break;

                    case 6:
                        UnitTitle = "نفر روز";
                        break;

                    case 7:
                        UnitTitle = "نفر ماه";
                        break;

                    case 8:
                        UnitTitle = "کار";
                        break;
                    case 9:
                        UnitTitle = "ساعت";
                        break;
                    case 10:
                        UnitTitle = "مقاله";
                        break;
                    case 11:
                        UnitTitle = "صفحه";
                        break;

                    default:
                        break;
                }

                row[col3] = UnitTitle;

                row[col4] = Sp_Dt[i]["COUNT"];
                row[col5] = string.Format("{0:n3}", double.Parse(Sp_Dt[i]["PRICE_UNIT"].ToString())).Replace(".000", "");
                row[col6] = Sp_Dt[i]["SHIFT"];
                row[col7] = Sp_Dt[i]["MONTH"].ToString().Replace(".00", "");
                row[col8] = Sp_Dt[i]["DESCPRIPTION"];

                row[col9] = (i + 1).ToString();
                DTable.Rows.Add(row);

            }


            dgvRoles.DataSource = DTable;
            dgvRoles.Columns[0].Width = 40;
            dgvRoles.Columns[1].Width = 40;

            dgvRoles.Columns[2].Visible = false;
            dgvRoles.Columns[2].Width = 40;



            dgvRoles.Columns[3].Width = 200;
            dgvRoles.Columns[4].Width = 100;
            dgvRoles.Columns[5].Width = 50;
            dgvRoles.Columns[6].Width = 120;
            dgvRoles.Columns[7].Width = 50;
            dgvRoles.Columns[8].Width = 50;
            dgvRoles.Columns[9].Width = 150;
            dgvRoles.Columns[10].Width = 120;




            //Calculate  Total
            double TotalUnit = 0;
            double TotalCount = 0;
            double TotalShift = 0;
            float TotalMonth = 0;
            double TotalTotal = 0;

            for (int i = 0; i < dgvRoles.Rows.Count; i++)
            {
                TotalUnit += double.Parse(dgvRoles.Rows[i].Cells["ارزش واحد"].Value.ToString().Replace(",", ""));
                label23.Text = string.Format("{0:n3}", TotalUnit).Replace(".000", "");

                TotalCount += double.Parse(dgvRoles.Rows[i].Cells["تعداد"].Value.ToString());
                label22.Text = TotalCount.ToString();


                TotalShift += double.Parse(dgvRoles.Rows[i].Cells["شیفت"].Value.ToString());
                label24.Text = TotalShift.ToString();

                TotalMonth += float.Parse(dgvRoles.Rows[i].Cells["ماه"].Value.ToString());
                label25.Text = TotalMonth.ToString().Replace(".00", "");


                TotalTotal += double.Parse(dgvRoles.Rows[i].Cells["ارزش کل"].Value.ToString().Replace(",", ""));
                label27.Text = string.Format("{0:n3}", TotalTotal).Replace(".000", "");


            }
            label21.Text = dgvRoles.Rows.Count.ToString();

        }

        private void txtUnit_MouseEnter(object sender, EventArgs e)
        {
            if (txtUnit.Text.Trim().Replace(",", "").Length > 3)
            {
                txtUnit.Text = txtUnit.Text.Replace(",", "");
                try
                {
                    string[] Txt = txtUnit.Text.Trim().Split('.');
                    if (Txt.Length == 2)
                    {
                        txtUnit.Text = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                            + "." + Txt[1];
                    }
                    else
                    {
                        if (Txt.Length == 1)
                        {
                            txtUnit.Text = string.Format("{0:n3}", Int64.Parse(txtUnit.Text.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                        }
                    }


                    txtUnit.SelectionStart = txtUnit.Text.Trim().Length;

                }
                catch (Exception exp)
                {

                    // MessageBox.Show(exp.Message);
                    MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);
                    txtUnit.Focus();

                }
            }
        }

        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            //txtUnit.Text = txtUnit.Text.Remove(txtUnit.SelectionStart, txtUnit.SelectionLength);
            //txtUnit.SelectionStart = txtUnit.Text.Trim().Length;

            if (e.KeyCode == Keys.F3)
            {

                txtUnit.Text = txtUnit.Text + "000";
                txtUnit.Text = txtUnit.Text.Replace(",", "");
                try
                {
                    string[] Txt = txtUnit.Text.Trim().Split('.');
                    if (Txt.Length == 2)
                    {
                        txtUnit.Text = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                            + "." + Txt[1];
                    }
                    else
                    {
                        if (Txt.Length == 1)
                        {
                            txtUnit.Text = string.Format("{0:n3}", Int64.Parse(txtUnit.Text.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                        }
                    }
                    txtUnit.SelectionStart = txtUnit.Text.Trim().Length;

                }
                catch (Exception exp)
                {

                    MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);
                    txtUnit.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtShift.Focus();
                }
                else
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                    {
                        txtUnit.Text = txtUnit.Text.Replace(",", "");
                        try
                        {
                            if (txtUnit.Text.Trim().Length > 3)
                            {
                                string[] Txt = txtUnit.Text.Trim().Split('.');
                                if (Txt.Length == 2)
                                {
                                    txtUnit.Text = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                                        + "." + Txt[1];
                                }
                                else
                                {
                                    if (Txt.Length == 1)
                                    {
                                        txtUnit.Text = string.Format("{0:n3}", Int64.Parse(txtUnit.Text.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                                    }
                                }
                                txtUnit.SelectionStart = txtUnit.Text.Trim().Length;

                            }

                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);
                            txtUnit.Focus();
                        }
                    }
                    else
                    {
                        try
                        {
                            txtUnit.Text.Remove(txtUnit.SelectionStart);
                        }
                        catch
                        {
                        }

                    }
                }
            }
        }

        private void dgvRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseClick();
        }
        protected void MouseClick()
        {
            if (dgvRoles.SelectedRows.Count == 1)
            {
                int Index = dgvRoles.SelectedRows[0].Index;
                SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                MyDB.SUPPORTDataTable Sp_Dt =
                    Sp_Ta.Select_Current_Support_Details(int.Parse((dgvRoles.SelectedRows[0].Cells["Id"].Value.ToString())));

                txtRoleDesc.Text = Sp_Dt[0]["DESCPRIPTION"].ToString();
                txtShift.Text = Sp_Dt[0]["SHIFT"].ToString();
                txtUnit.Text = Sp_Dt[0]["PRICE_UNIT"].ToString();
                txtMonth.Text = Sp_Dt[0]["MONTH"].ToString().Replace(".00", "");
                numericUpDown1.Value = decimal.Parse(Sp_Dt[0]["COUNT"].ToString());
                numericUpDownSort.Value = decimal.Parse(Sp_Dt[0]["SORT"].ToString());

                for (int i = 0; i < CmbRole.Items.Count; i++)
                {
                    NewListItem Ch = (NewListItem)CmbRole.Items[i];

                    if (Ch.Value.ToString() == Sp_Dt[0]["ROLE_ID"].ToString())
                    {
                        CmbRole.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cmbUnit.Items.Count; i++)
                {
                    NewListItem Ch = (NewListItem)cmbUnit.Items[i];

                    if (Ch.Value.ToString() == Sp_Dt[0]["UNIT"].ToString())
                    {
                        cmbUnit.SelectedIndex = i;
                    }
                }

                dgvRoles.Enabled = false;
                pictureBox2.Visible = true;
                pbAddRight.Visible = false;
                pictureBox1.Visible = true;
                pictureBox6.Visible = true;


                numericUpDownSort.Focus();


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //try
            //{
            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Check =
                  Sp_Ta.Check_Role_Exist(_Id, int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()));

            if (Check.Rows.Count == 0)
            {
                Sp_Ta.Update_Support_Details(
                                int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()),
                                ((NewListItem)cmbUnit.SelectedItem).Value.ToString(),
                                float.Parse(numericUpDown1.Value.ToString()),
                                txtUnit.Text.Replace(",", ""),
                                float.Parse(txtShift.Text),
                                float.Parse(txtMonth.Text),
                                txtRoleDesc.Text,
                                  int.Parse(numericUpDownSort.Value.ToString()),
                               int.Parse(dgvRoles.SelectedRows[0].Cells["ID"].Value.ToString()));
                MessageBox.Show("ویرایش با موفقیت انجام شد");

                FillRoleGrid();
                txtRoleDesc.Text = "";
                txtShift.Text = "";
                txtMonth.Text = "";
                txtUnit.Text = "";
                txtShift.Text = "";
                dgvRoles.Enabled = true;
                pictureBox2.Visible = false;
                pbAddRight.Visible = true;
                pictureBox1.Visible = false;
                pictureBox6.Visible = false;
            }
            else
            {
                if (Check[0]["ID"].ToString() == dgvRoles.SelectedRows[0].Cells["ID"].Value.ToString())
                {
                    Sp_Ta.Update_Support_Details(
                               int.Parse(((NewListItem)CmbRole.SelectedItem).Value.ToString()),
                               ((NewListItem)cmbUnit.SelectedItem).Value.ToString(),
                               float.Parse(numericUpDown1.Value.ToString()),
                               txtUnit.Text.Replace(",", ""),
                               float.Parse(txtShift.Text),
                               float.Parse(txtMonth.Text),
                               txtRoleDesc.Text,
                                 int.Parse(numericUpDownSort.Value.ToString()),
                              int.Parse(dgvRoles.SelectedRows[0].Cells["ID"].Value.ToString()));
                    MessageBox.Show("ویرایش با موفقیت انجام شد");

                    FillRoleGrid();
                    txtRoleDesc.Text = "";
                    txtShift.Text = "";
                    txtMonth.Text = "";
                    txtUnit.Text = "";
                    txtShift.Text = "";
                    dgvRoles.Enabled = true;
                    pictureBox2.Visible = false;
                    pbAddRight.Visible = true;
                    pictureBox1.Visible = false;
                    pictureBox6.Visible = false;
                }
                else
                {
                    MessageBox.Show("کد فعالیت تکراری است");
                    CmbRole.Focus();
                }
            }
            //}
            //catch (Exception exp)
            //{

            //    MessageBox.Show("لطفا اطلاعات کد مورد نظر را بررسی نمایید" + "\n" + exp.Message);
            //}


        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _Id = 0;
            txtTitle.Text = "";
            txtNumber.Text = "";
            txtPublishDate.Text = "";
            txtDateFinance.Text = "";
            txtDateEdit.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            txtDesc.Text = "";
            groupBox2.Enabled = false;
            FillRoleGrid();
            txtRoleDesc.Text = "";
            txtShift.Text = "";
            txtMonth.Text = "";
            txtUnit.Text = "";
            txtShift.Text = "";
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_Id, "PrintSupport");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void CmbChannel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDep1.Items.Clear();
            List<DepsObj> Deps_Lst =
                DepsBll.Select_All_DepsByChannelId(int.Parse(((NewListItem)CmbChannel1.SelectedItem).Value.ToString()));
            foreach (DepsObj item in Deps_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;
                cmbDep1.Items.Add(Lst);
            }
            if (Deps_Lst.Count > 0)
            {
                cmbDep1.SelectedIndex = 0;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_Id != 0)
            {
                bool Exist = false;
                FormCollection fc = Application.OpenForms;
                foreach (Form f in fc)
                {
                    if (f.Name == "RefreshSupport")
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    RefreshSupport R_Sp = new RefreshSupport(_Id);
                    R_Sp.MdiParent = this.MdiParent;
                    R_Sp.TopMost = true;
                    R_Sp.Show();
                }
                else
                {
                    MessageBox.Show("ابتدا پنجره تمدید برآورد را ببندید");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //delete
            DialogResult Dl =
                MessageBox.Show("آیا سطر انتخاب شده حذف گردد؟", "حذف کد", MessageBoxButtons.YesNo);
            if (Dl == System.Windows.Forms.DialogResult.Yes)
            {

                SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                Sp_Ta.Delete_Support_Details(
                               int.Parse((dgvRoles.SelectedRows[0].Cells["ID"].Value.ToString())));
                MessageBoxEx.Show(dgvRoles.SelectedRows[0].Cells[3].Value.ToString() + " حذف شد", "حذف عوامل", 1000);
                FillRoleGrid();
            }
            txtRoleDesc.Text = "";
            txtShift.Text = "";
            txtMonth.Text = "";
            txtUnit.Text = "";
            txtShift.Text = "";
            dgvRoles.Enabled = true;
            pictureBox2.Visible = false;
            pbAddRight.Visible = true;
            pictureBox1.Visible = false;
            pictureBox6.Visible = false;
        }


        private void dgvSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (bool.Parse(dgvSearchResult.SelectedRows[0].Cells["Merge"].Value.ToString()).Equals(false))
                {
                    dgvSearchResult.SelectedRows[0].Cells["Merge"].Value = true;
                }
                else
                {
                    dgvSearchResult.SelectedRows[0].Cells["Merge"].Value = false;
                }
            }
            else
            {

            }
        }
        private void dgvSearchResult_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string Ids = "";
            int SelectedCount = 0;

            for (int p = 0; p < dgvSearchResult.Rows.Count; p++)
            {
                if (bool.Parse(dgvSearchResult.Rows[p].Cells["Merge"].Value.ToString()).Equals(true))
                {
                    Ids += dgvSearchResult.Rows[p].Cells[0].Value.ToString() + " , ";
                    SelectedCount++;
                }
            }

            if (SelectedCount > 1)
            {

                if (txtNewTitle.Text.Trim().Length > 0)
                {
                    if (txtNewNumber.Text.Trim().Length > 0)
                    {
                        Ids = Ids.Remove(Ids.Length - 2, 2);

                        SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                        MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Search_Support(" where id in ( " + Ids + " ) ");


                        //Copy Master Support
                        int NewBId = 0;
                        try
                        {
                            NewBId = int.Parse(Sp_Ta.Insert_Support(txtNewTitle.Text.Trim(),
                           txtNewNumber.Text.Trim(),
                           Baravord.TOOLS.GetDate.GetDateTime(),
                           "",
                           DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime()),
                           int.Parse(Sp_Dt[0]["Dep_ID"].ToString()),
                            "",
                            "",
                            false,
                            int.Parse(Sp_Dt[0]["CHANNEL_ID"].ToString()), false).ToString());
                        }
                        catch (Exception Exp)
                        {
                            MessageBox.Show(Exp.Message);
                            throw;
                        }


                        //After Inserted Master Data INSERT Details(Codes)
                        if (NewBId != 0)
                        {

                            for (int j = 0; j < Sp_Dt.Rows.Count; j++)
                            {


                                MyDB.SUPPORTDataTable Sp_Dt2 = Sp_Ta.Select_Support_Details(int.Parse(Sp_Dt[j]["ID"].ToString()));

                                for (int i = 0; i < Sp_Dt2.Rows.Count; i++)
                                {

                                    double Pric_Unit = double.Parse(Sp_Dt2[i]["PRICE_UNIT"].ToString());
                                    Pric_Unit += (Pric_Unit / 100) * double.Parse("0");


                                    Sp_Ta.Insert_Sopport_Details(
                                                          NewBId,
                                                          int.Parse(Sp_Dt2[i]["ROLE_ID"].ToString()),
                                                          Sp_Dt2[i]["UNIT"].ToString(),
                                                          int.Parse(Sp_Dt2[i]["COUNT"].ToString()),
                                                         Pric_Unit.ToString(),
                                                          int.Parse(Sp_Dt2[i]["SHIFT"].ToString()),
                                                          float.Parse(Sp_Dt2[i]["MONTH"].ToString()),
                                                          Sp_Dt2[i]["DESCPRIPTION"].ToString(),
                                                          int.Parse(Sp_Dt2[i]["SORT"].ToString()));

                                }
                            }
                        }

                        MessageBox.Show("موارد انتخاب شده با موفقیت ترکیب و آیتم جدید ساخته شد");
                        FillGrid();
                    }
                    else
                    {
                        MessageBox.Show("شماره برآورد ترکیبی جدید را وارد نمایید");
                    }
                }
                else
                {
                    MessageBox.Show("عنوان برآورد ترکیبی جدید را وارد نمایید");
                }
            }
            else
            {
                MessageBox.Show("حد اقل دو برآورد برای ترکیب باید انتخاب شده باشند");
            }
        }

        private void numericUpDownSort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CmbRole.Focus();
            }
        }

        private void CmbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("لطفا کد عامل را انتخاب نمایید");
                    CmbRole.Focus();
                }
                else
                {
                    cmbUnit.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                RoleFill();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numericUpDown1.Focus();
            }
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnit.Focus();
            }
        }

        private void txtShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMonth.Focus();
            }
        }

        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoleDesc.Focus();
            }
        }

        private void txtRoleDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pbAddRight.Visible)
                {
                    pbAddRight_Click(new object(), new EventArgs());
                    numericUpDownSort.Focus();
                }
                else
                {
                    if (pictureBox2.Visible)
                    {
                        pictureBox2_Click(new object(), new EventArgs());
                        dgvRoles.Focus();
                    }
                }
            }
        }

        private void dgvRoles_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                MouseClick();


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            cmbUnit.SelectedIndex = 0;
            txtMonth.Text = "";
            txtShift.Text = "";
            txtRoleDesc.Text = "";
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult DlgRslt = MessageBox.Show("آیا مطمئنید که می خواهید برآورد را حذف نمایید؟", "هشدار حذف برآورد", MessageBoxButtons.YesNo);
            if (DlgRslt == System.Windows.Forms.DialogResult.Yes)
            {
                int IdDel = int.Parse(dgvSearchResult.SelectedRows[0].Cells["ID"].Value.ToString());
                SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                Sp_Ta.Update_Support_Delete(IdDel);
                FillGrid();
            }
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            string Txt2 = txtUnit.Text.Trim();
            if (Txt2.Replace(",", "").Length > 3)
            {
                Txt2 = Txt2.Replace(",", "");
                try
                {
                    string[] Txt = Txt2.Trim().Split('.');
                    if (Txt.Length == 2)
                    {
                        Txt2 = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                            + "." + Txt[1];
                    }
                    else
                    {
                        if (Txt.Length == 1)
                        {
                            Txt2 = string.Format("{0:n3}", Int64.Parse(Txt2.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                        }
                    }
                    txtUnit.Text = Txt2;
                    txtUnit.SelectionStart = txtUnit.Text.Trim().Length;
                }
                catch (Exception exp)
                {
                    // MessageBox.Show(exp.Message);
                    MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);

                }
            }
        }


        private void numericUpDownSort_Enter(object sender, EventArgs e)
        {
            numericUpDownSort.Select(0, numericUpDownSort.Text.Length);
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }

        private void txtShift_Enter(object sender, EventArgs e)
        {
            txtShift.Select(0, txtShift.Text.Length);
        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            txtMonth.Select(0, txtMonth.Text.Length);
        }

        private void txtUnit_Enter(object sender, EventArgs e)
        {
            //txtUnit.Select(0, txtUnit.Text.Length);
            txtUnit.SelectionStart = txtUnit.Text.Trim().Length;
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    txtNumber.Focus();
                }
            }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    CmbChannel.Focus();
                }
            }
        }

        private void CmbChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    cmbDep.Focus();
                }
            }
        }

        private void cmbDep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    txtPublishDate.Focus();
                }
            }
        }

        private void txtPublishDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtDateEdit.Focus();
            }

            if (e.KeyCode == Keys.F3)
            {
                txtPublishDate.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            }


        }

        private void txtDateEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtDateFinance.Focus();
            }

            if (e.KeyCode == Keys.F3)
            {
                txtDateEdit.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            }
        }


        private void txtDateFinance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                checkBox1.Focus();
            }
            if (e.KeyCode == Keys.F3)
            {
                txtDateFinance.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    if (textBox4.Enabled == true)
                    {
                        textBox4.Focus();
                    }
                    else
                    {
                        toolStripBtnSave_Click(new object(), new EventArgs());
                    }
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                toolStripBtnSave_Click(new object(), new EventArgs());
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                toolStripBtnSave_Click(new object(), new EventArgs());

            }
            if (e.KeyCode == Keys.F3)
            {
                textBox4.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_Id, "PrintSupport2");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void pbAddRight_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtRoleDesc.Text = "";
            txtShift.Text = "";
            txtMonth.Text = "";
            txtUnit.Text = "";
            txtShift.Text = "";
            dgvRoles.Enabled = true;
            pictureBox2.Visible = false;
            pbAddRight.Visible = true;
            pictureBox1.Visible = false;
            pictureBox6.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            RoleFill();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ChannelFill();
        }

        private void txtDesc_Leave(object sender, EventArgs e)
        {
          
        }

        private void txtDesc_Enter(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDesc.AppendText("\r\n" + "اصلاحیه" + DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime()) + "  :  ");
            txtDesc.SelectionStart = txtDesc.Text.Length;
            txtDesc.ScrollToCaret();
            Application.DoEvents();
            txtDesc.Focus();
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&& e.KeyCode == Keys.S)
            {
                DialogResult Rs = MessageBox.Show("متن توضیحات ذخیره گردد؟", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rs == System.Windows.Forms.DialogResult.Yes)
                {
                    toolStripBtnSave_Click(new object(), new EventArgs());
                }
                else
                {

                }
            }
        }
    }
}