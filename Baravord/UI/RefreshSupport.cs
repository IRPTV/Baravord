using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baravord.BLL;
using Baravord.MyDBTableAdapters;
using Baravord.OBJECTS;

namespace Baravord.UI
{
    public partial class RefreshSupport : Form
    {
        int _BarID = 0;
        public RefreshSupport(int BarId)
        {
            _BarID = BarId;
            InitializeComponent();
        }

        private void RefreshSupport_Load(object sender, EventArgs e)
        {

            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_Current_Support(_BarID);

            txtBaravord_Number.Text = Sp_Dt[0]["BARAVORD_NUMBER"].ToString();
            textBox1.Text = DateConversion.GD2JD((Baravord.TOOLS.GetDate.GetDateTime()));
            FillRoleGrid();




        }

        protected void FillRoleGrid()
        {
            SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
            MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_Support_Details(_BarID);


            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("کد فعالیت");

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "درصد تغییرات";
            col5.Name = "Change";

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "ماه";
            col6.Name = "Months";


            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "شیفت";
            col7.Name = "Shifts";





            DataColumn col9 = new DataColumn("ردیف");
            DataColumn col10 = new DataColumn("ترتیب");



            DTable.Columns.Add(col9);
            DTable.Columns.Add(col10);
            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);




            for (int i = 0; i < Sp_Dt.Rows.Count; i++)
            {
                DataRow row = DTable.NewRow();
                row[col10] = Sp_Dt[i]["SORT"];
                row[col1] = Sp_Dt[i]["ID"];


                RoleObj RlObj = new RoleObj();
                RlObj.Id = int.Parse(Sp_Dt[i]["ROLE_ID"].ToString());
                row[col2] = RoleBll.Select_Current_Role(RlObj).Title;




                row[col9] = (i + 1).ToString();
                DTable.Rows.Add(row);

            }



            dgvRoles.DataSource = DTable;
            dgvRoles.Columns.Add(col5);
            dgvRoles.Columns.Add(col7);
            dgvRoles.Columns.Add(col6);



            dgvRoles.Columns[0].Width = 40;
            dgvRoles.Columns[1].Width = 40;

            dgvRoles.Columns[2].Visible = false;
            dgvRoles.Columns[2].Width = 40;



            dgvRoles.Columns[3].Width = 200;
            dgvRoles.Columns[4].Width = 100;
            dgvRoles.Columns[5].Width = 50;
            dgvRoles.Columns[6].Width = 50;

        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (txtBaravord_Number.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا شماره برآورد را وارد نمایید");
            }
            else
            {
                if (txtPercent.Text.Trim().Length == 0)
                {
                    MessageBox.Show("لطفا درصد  را وارد نمایید");
                }
                else
                {


                    //We can check here if B N is unic or not

                    SUPPORTTableAdapter Sp_Ta = new SUPPORTTableAdapter();
                    MyDB.SUPPORTDataTable Sp_Dt = Sp_Ta.Select_Current_Support(_BarID);


                    //Copy Master Support
                    int NewBId = 0;
                    try
                    {
                        NewBId = int.Parse(Sp_Ta.Insert_Support(Sp_Dt[0]["Title"].ToString(),
                       txtBaravord_Number.Text.Trim(),
                       DateTime.Parse(Sp_Dt[0]["DATETIME_PUBLISH"].ToString()),
                       "",
                      textBox1.Text,
                       int.Parse(Sp_Dt[0]["Dep_ID"].ToString()),
                        Sp_Dt[0]["DESCPRIPTION"].ToString(),
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

                        //try
                        //{
                        Sp_Dt = Sp_Ta.Select_Support_Details(_BarID);

                        for (int i = 0; i < Sp_Dt.Rows.Count; i++)
                        {

                            double Pric_Unit = double.Parse(Sp_Dt[i]["PRICE_UNIT"].ToString());
                            float NewMonth = float.Parse(Sp_Dt[i]["MONTH"].ToString());
                            float NewShift = float.Parse(Sp_Dt[i]["SHIFT"].ToString());


                            if (textBox2.Text.Trim().Length > 0)
                            {
                                NewMonth = float.Parse(textBox2.Text.Trim());
                            }

                            if (textBox3.Text.Trim().Length > 0)
                            {
                                NewShift = float.Parse(textBox3.Text.Trim());
                            }




                            for (int j = 0; j < dgvRoles.Rows.Count; j++)
                            {
                                if (dgvRoles.Rows[j].Cells["ID"].Value.ToString() == Sp_Dt[i]["ID"].ToString())
                                {
                                    #region ChangeUnit
                                    string Change = "";
                                    try
                                    {
                                        Change = dgvRoles.Rows[j].Cells["Change"].Value.ToString().Trim();
                                        if (Change.Contains("-"))
                                        {
                                            Change = "-" + Change.Replace("-", "");
                                        }
                                        if (Change.Contains("+"))
                                        {
                                            Change = "+" + Change.Replace("+", "");
                                        }
                                    }
                                    catch
                                    {

                                        Change = "";
                                    }


                                    if (Change.Length > 0)
                                    {
                                        if (float.Parse(Change) > 0)
                                        {
                                            Pric_Unit += (Pric_Unit / 100) * double.Parse(Change);
                                        }
                                        else
                                        {
                                            Pric_Unit -= (Pric_Unit / 100) * double.Parse(Change.Replace("-", ""));
                                        }
                                    }
                                    else
                                    {
                                        if (float.Parse(txtPercent.Text.Trim()) > 0)
                                        {
                                            Pric_Unit += (Pric_Unit / 100) * double.Parse(txtPercent.Text.Trim());
                                        }
                                        else
                                        {
                                            Pric_Unit -= (Pric_Unit / 100) * double.Parse(txtPercent.Text.Trim().Replace("-", ""));
                                        }
                                    }
                                    #endregion

                                    try
                                    {
                                        NewMonth = float.Parse(dgvRoles.Rows[j].Cells["Months"].Value.ToString().Trim());
                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {
                                        NewShift = float.Parse(dgvRoles.Rows[j].Cells["Shifts"].Value.ToString().Trim());
                                    }
                                    catch
                                    {

                                    }

                                }
                            }
                            Sp_Ta.Insert_Sopport_Details(
                                                  NewBId,
                                                  int.Parse(Sp_Dt[i]["ROLE_ID"].ToString()),
                                                  Sp_Dt[i]["UNIT"].ToString(),
                                                  float.Parse(Sp_Dt[i]["COUNT"].ToString()),
                                                 Pric_Unit.ToString(),
                                                 NewShift,
                                                 NewMonth,
                                                  Sp_Dt[i]["DESCPRIPTION"].ToString()
                                                  , int.Parse(Sp_Dt[i]["sort"].ToString()));
                        }

                        MessageBox.Show("برآورد با موفقیت تمدید شد");
                        this.Close();
                        // }
                        //catch (Exception Er)
                        //{
                        //    MessageBox.Show(Er.Message);
                        //    throw;
                        //}



                    }
                }

            }
        }
    }
}
