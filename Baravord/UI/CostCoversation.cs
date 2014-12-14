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
    public partial class CostCoversation : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();

        public CostCoversation(int ProgramId)
        {
            _ProgramGlobalObject.Id = ProgramId;
            InitializeComponent();
        }

        public void StaticValueFill()
        {
            comboBox1.Items.Clear();

            //Unit Combo Box
            NewListItem Unit_Lst = new NewListItem();
            Unit_Lst.Text = "برنامه";
            Unit_Lst.Value = "1";
            comboBox1.Items.Add(Unit_Lst);
            comboBox1.SelectedIndex = 0;

            NewListItem Music_Lst2 = new NewListItem();
            Music_Lst2.Text = "درکل";
            Music_Lst2.Value = "2";
            comboBox1.Items.Add(Music_Lst2);


            NewListItem Unit_Lst3 = new NewListItem();
            Unit_Lst3.Text = "دقیقه";
            Unit_Lst3.Value = "3";
            comboBox1.Items.Add(Unit_Lst3);


            NewListItem Unit_Lst4 = new NewListItem();
            Unit_Lst4.Text = "ثانیه";
            Unit_Lst4.Value = "4";
            comboBox1.Items.Add(Unit_Lst4);

            NewListItem Unit_Lst5 = new NewListItem();
            Unit_Lst5.Text = "جلسه";
            Unit_Lst5.Value = "5";
            comboBox1.Items.Add(Unit_Lst5);



            NewListItem Unit_Lst6 = new NewListItem();
            Unit_Lst6.Text = "نفر روز";
            Unit_Lst6.Value = "6";
            comboBox1.Items.Add(Unit_Lst6);



        }
        private void CostCoversation_Load(object sender, EventArgs e)
        {
            #region FillData          

            //Fill Combo Box Roles and Costs
            RoleFill();

         
            //Fill Unit for Kind of Payment (Total,Per Session)......
            StaticValueFill();
       

            #endregion

            #region FillDataForProgram
            if (_ProgramGlobalObject.Id.Equals(0))
            {
                //toolStripLblProgramTitle.Text = "ورود اطلاعات مصوبه برنامه جدید";

                ////Insert New Programme And Save ID
                //ProgramObj RetProgObject = ProgramBll.Insert_Prgram(_ProgramGlobalObject);
                //_ProgramGlobalObject = RetProgObject;
               BtnPrintDep.Visible = false;
            }
            else
            {
                UpdateObjectFromDataBase();
                if (_ProgramGlobalObject.BackProgId == 0)
                {
                    BtnPrintDep.Visible = false;
                }

                toolStripLabel1.Text = _ProgramGlobalObject.Title_Farsi + "              تعداد قسمت:    " + _ProgramGlobalObject.Session + "              مدت هر قسمت:    " + _ProgramGlobalObject.Session_Time;
               // label6.Text = string.Format("{0:n3}", double.Parse(_ProgramGlobalObject.Price_Minute)).Replace(".000", "") + " ریال ";




                SetRoleGirdView();        
            }
            #endregion
        }
        private void UpdateObjectFromDataBase()
        {
            ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);
            _ProgramGlobalObject = Obj;
        }
        public void RoleFill()
        {
            CmbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CmbRole.AutoCompleteSource = AutoCompleteSource.ListItems;


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
        private void SetRoleGirdView()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("عنوان");
            DataColumn col3 = new DataColumn("تعداد");
            //DataColumn col4 = new DataColumn("مدت");
            DataColumn col5 = new DataColumn("ارزش واحد");
            DataColumn col6 = new DataColumn("شرح کد");
            DataColumn col7 = new DataColumn("واحد");
            DataColumn col8 = new DataColumn("هربرنامه");
            DataColumn col9 = new DataColumn("ارزش کل");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col3);
           // DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col8);
            DTable.Columns.Add(col9);
            DTable.Columns.Add(col6);            

            List<Program_RoleObj> Prg_Role_Lst = Program_RoleBll.Select_Program_All_Roles(_ProgramGlobalObject);

            foreach (Program_RoleObj item in Prg_Role_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;
                RoleObj RlObj = new RoleObj();
                RlObj.Id = item.Role_Id;
                row[col2] = RoleBll.Select_Current_Role(RlObj).Title;

                //Barname


                string Barname = Calculation.RowCost(item.Unit, item.Count, double.Parse(item.Price_Unit),
                    _ProgramGlobalObject.Session, _ProgramGlobalObject.Session_Time)[0];

                if (Barname != "****")
                {
                    row[col8] = string.Format("{0:n3}", double.Parse(Barname)).Replace(".000", "");
                }
                else
                {
                    row[col8] = "****";
                }
                  

                //Arzeshe kol
                string Kol = Calculation.RowCost(item.Unit, item.Count, double.Parse(item.Price_Unit),
                   _ProgramGlobalObject.Session, _ProgramGlobalObject.Session_Time)[1];

                row[col9] = string.Format("{0:n3}", double.Parse(Kol)).Replace(".000", "");
                    



                row[col3] = item.Count;
               // row[col4] = item.Time;
                row[col5] = string.Format("{0:n3}", double.Parse(item.Price_Unit)).Replace(".000", ""); 
                row[col6] = item.Description;

                string UnitTitle = "";
                switch (item.Unit)
                {
                    case 1:
                        UnitTitle = "برنامه";
                        break;
                    case 2:
                        UnitTitle = "درکل";
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

                    default:
                        break;
                }

                row[col7] = UnitTitle;





                DTable.Rows.Add(row);
            }

            //DataColumn col1 = new DataColumn("ID");
            //DataColumn col2 = new DataColumn("عنوان");
            //DataColumn col3 = new DataColumn("تعداد");
            ////DataColumn col4 = new DataColumn("مدت");
            //DataColumn col5 = new DataColumn("ارزش واحد");
            //DataColumn col6 = new DataColumn("شرح کد");
            //DataColumn col7 = new DataColumn("واحد");
            //DataColumn col8 = new DataColumn("هربرنامه");
            //DataColumn col9 = new DataColumn("ارزش کل");

            //DTable.Columns.Add(col1);
            //DTable.Columns.Add(col2);
            //DTable.Columns.Add(col7);
            //DTable.Columns.Add(col3);
            //// DTable.Columns.Add(col4);
            //DTable.Columns.Add(col5);
            //DTable.Columns.Add(col8);
            //DTable.Columns.Add(col9);
            //DTable.Columns.Add(col6);            


            dgvRoles.DataSource = DTable;            
            dgvRoles.Columns[0].Width = 50;
            dgvRoles.Columns[1].Width = 150;
            dgvRoles.Columns[2].Width = 100;
            dgvRoles.Columns[3].Width = 50;
            dgvRoles.Columns[4].Width = 150;
            dgvRoles.Columns[5].Width = 150;
            dgvRoles.Columns[6].Width = 150;
            dgvRoles.Columns[7].Width = 350;
            //dgvRoles.Columns[8].Width = 100;

            //Calculate All Values(SUM)
          
            double Total = 0;
            for (int i = 0; i < dgvRoles.RowCount; i++)
            {
                string Value = dgvRoles[4, i].Value.ToString();
              

                try
                {
                    Total += double.Parse(Value.Replace(",",""));
                }
                catch
                {                    
                       
                }
            }

            label7.Text = string.Format("{0:n3}", Total).Replace(".000", "");


            Total = 0;
            for (int i = 0; i < dgvRoles.RowCount; i++)
            {
                string Value = dgvRoles[5, i].Value.ToString();


                try
                {
                    Total += double.Parse(Value.Replace(",", ""));
                }
                catch
                {

                }
            }

            label9.Text = string.Format("{0:n3}", Total).Replace(".000", "");



            Total = 0;
            for (int i = 0; i < dgvRoles.RowCount; i++)
            {
                string Value = dgvRoles[6, i].Value.ToString();


                try
                {
                    Total += double.Parse(Value.Replace(",", ""));
                }
                catch
                {

                }
            }

            label11.Text = string.Format("{0:n3}", Total).Replace(".000", "");


             string[] Time = _ProgramGlobalObject.Session_Time.Split(':');
            double Second = int.Parse(Time[0].Trim()) * 3600 + int.Parse(Time[1].Trim()) * 60 + int.Parse(Time[2].Trim());
            label13.Text = string.Format("{0:n3}", (((Total)/(_ProgramGlobalObject.Session*Second))*60)).Replace(".000", "")+" ریال "; 



        }

        

        public void AddRole()
        {
            try
            {
                NewListItem Lst = (NewListItem)CmbRole.SelectedItem;

                Program_RoleObj Obj = new Program_RoleObj();
                Obj.Role_Id = int.Parse(Lst.Value.ToString());
                Obj.Price_Unit = textBox3.Text.Replace(",", "");
                Obj.Id = 0;
                Obj.Time = "0";
                Obj.Count = int.Parse(numericUpDown1.Value.ToString());
                Obj.Description = textBox1.Text;


                StringBuilder Str=new StringBuilder ();
                //txtPriceMinute
                if (textBox3.Text.Replace(",", "").Trim().Length > 0)
                {
                    try
                    {
                        double Price = double.Parse(textBox3.Text.Trim().Replace(",",""));
                    }
                    catch
                    {
                        Str.Append("فقط عدد در حق الزحمه وارد نمایید");
                        Str.Append("\n");
                    }

                }
                else
                {
                    Str.Append("  رقم حق الزحمه را وارد نمایید");
                    Str.Append("\n");
                }
                if (Str.Length < 5)
                {

                    NewListItem Lst_Unit = (NewListItem)comboBox1.SelectedItem;
                    Obj.Unit = int.Parse(Lst_Unit.Value.ToString());
                    Program_RoleBll.Insert_Program_Role(Obj, _ProgramGlobalObject);
                    SetRoleGirdView();
                }
                else
                {
                    MessageBox.Show(Str.ToString(), "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {

                MessageBox.Show("این کد در سیستم موجود نیست به مدیر سیستم اطلاع دهید");
            }
        }

        private void pbAddRole_Click(object sender, EventArgs e)
        {
            AddRole();
            textBox1.Text = "";
            textBox3.Text = "";
        }
        private void pbDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvRoles.SelectedRows.Count; i++)
                {
                    Program_RoleBll.Delete_Current_Program_Role(int.Parse(dgvRoles.SelectedRows[i].Cells[0].Value.ToString()));
                    MessageBoxEx.Show(dgvRoles.SelectedRows[i].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
                }
                
            }
            SetRoleGirdView();
        }

        private void dgvRoles_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 1)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                Select_Current_Role();
                pbAddRole.Visible = false;

            }
            else
            {
                MessageBox.Show("لطفا برای ویرایش یک ردیف را انتخاب فرمایید");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dgvRoles.ClearSelection();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pbAddRole.Visible = true;

            textBox1.Text = "";
            textBox3.Text = "";
            


        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {

        }
        protected void Select_Current_Role()
        {
          Program_RoleObj RoleObj=  Program_RoleBll.Select_Current_Program_Roles(int.Parse(dgvRoles.SelectedRows[0].Cells[0].Value.ToString()));

          //Set Role Cobo Items
          for (int i = 0; i < CmbRole.Items.Count; i++)
          {
              NewListItem Ch = (NewListItem)CmbRole.Items[i];

              if (Ch.Value.ToString() == RoleObj.Role_Id.ToString())
              {
                  CmbRole.SelectedIndex = i;
              }
          }


          //Set Unit kind Cobo Items
          for (int i = 0; i < comboBox1.Items.Count; i++)
          {
              NewListItem Ch = (NewListItem)comboBox1.Items[i];

              if (Ch.Value.ToString() == RoleObj.Unit.ToString())
              {
                  comboBox1.SelectedIndex = i;
              }
          }


          textBox3.Text = RoleObj.Price_Unit;
          textBox1.Text = RoleObj.Description;
          numericUpDown1.Value = decimal.Parse(RoleObj.Count.ToString());
         // numericUpDown2.Value = decimal.Parse(RoleObj.Time.ToString());


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {


             Program_RoleObj Obj = new Program_RoleObj();

             NewListItem Lst = (NewListItem)CmbRole.SelectedItem;
            Obj.Role_Id = int.Parse(Lst.Value.ToString());
            Obj.Price_Unit = textBox3.Text.Replace(",","");           
            Obj.Time = "0";
            Obj.Count = int.Parse(numericUpDown1.Value.ToString());
            Obj.Id = int.Parse(dgvRoles.SelectedRows[0].Cells[0].Value.ToString());
            Obj.Description = textBox1.Text;

            NewListItem Unit = (NewListItem)comboBox1.SelectedItem;
            Obj.Unit = int.Parse(Unit.Value.ToString());





            StringBuilder Str = new StringBuilder();
            //txtPriceMinute
            if (textBox3.Text.Replace(",", "").Trim().Length > 0)
            {
                try
                {
                    double Price = double.Parse(textBox3.Text.Trim().Replace(",", ""));
                }
                catch
                {
                    Str.Append("فقط عدد در حق الزحمه وارد نمایید");
                    Str.Append("\n");
                }

            }
            else
            {
                Str.Append("  رقم حق الزحمه را وارد نمایید");
                Str.Append("\n");
            }
            if (Str.Length < 5)
            {

                Program_RoleBll.Update_Current_Program_Role(Obj);

                pictureBox2.Visible = false;
                pictureBox1.Visible = false;

                SetRoleGirdView();
            }
            else
            {
                MessageBox.Show(Str.ToString(), "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            }
            catch
            {

                MessageBox.Show("این کد در سیستم موجود نیست به مدیر سیستم اطلاع دهید");
            }
            pbAddRole.Visible = true;
            textBox1.Text = "";
            textBox3.Text = "";
            
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.Id, "PrintCost2");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void BtnPrintDep_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.BackProgId, "PrintCost2");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Text =  textBox3.Text = "";
            numericUpDown1.Value =  1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Replace(",", "");
            try
            {
                if (textBox3.Text.Trim().Length > 3)
                {
                    textBox3.Text = string.Format("{0:n3}", double.Parse(textBox3.Text.Replace(','.ToString(), ""))).Replace(".000", "");
                }
                textBox3.SelectionStart = textBox3.Text.Length;
            }
            catch (Exception exp)
            {

               // MessageBox.Show(exp.Message);
                MessageBox.Show("عدد وارد شده در حق الزحمه را چک کنید");

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {

                textBox3.Text = textBox3.Text + "000";
                textBox3.Text = textBox3.Text.Replace(",", "");
                try
                {
                    string[] Txt = textBox3.Text.Trim().Split('.');
                    if (Txt.Length == 2)
                    {
                        textBox3.Text = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                            + "." + Txt[1];
                    }
                    else
                    {
                        if (Txt.Length == 1)
                        {
                            textBox3.Text = string.Format("{0:n3}", Int64.Parse(textBox3.Text.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                        }
                    }
                    textBox3.SelectionStart = textBox3.Text.Trim().Length;

                }
                catch (Exception exp)
                {

                    MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);
                    textBox3.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBox1.Focus();
                }
                else
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                    {
                        textBox3.Text = textBox3.Text.Replace(",", "");
                        try
                        {
                            if (textBox3.Text.Trim().Length > 3)
                            {
                                string[] Txt = textBox3.Text.Trim().Split('.');
                                if (Txt.Length == 2)
                                {
                                    textBox3.Text = string.Format("{0:n3}", Int64.Parse(Txt[0].Trim().Replace(','.ToString(), ""))).Replace(".000", "")
                                        + "." + Txt[1];
                                }
                                else
                                {
                                    if (Txt.Length == 1)
                                    {
                                        textBox3.Text = string.Format("{0:n3}", Int64.Parse(textBox3.Text.Trim().Replace(','.ToString(), ""))).Replace(".000", "");
                                    }
                                }
                                textBox3.SelectionStart = textBox3.Text.Trim().Length;

                            }

                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("عدد وارد شده در ارزش واحد را چک کنید" + "\n" + exp.Message);
                            textBox3.Focus();
                        }
                    }
                    else
                    {
                        try
                        {
                            textBox3.Text.Remove(textBox3.SelectionStart);
                        }
                        catch
                        {
                        }

                    }
                }
            }
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Replace(",", "");
            try
            {

                if (textBox3.Text.Trim().Length > 3)
                {
                    textBox3.Text = string.Format("{0:n3}", double.Parse(textBox3.Text.Replace(','.ToString(), ""))).Replace(".000", "");
                }
                textBox3.SelectionStart = textBox3.Text.Length;

            }
            catch (Exception exp)
            {

                // MessageBox.Show(exp.Message);
                MessageBox.Show("عدد وارد شده در حق الزحمه را چک کنید");

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Replace(",", "");
            try
            {

                if (textBox3.Text.Trim().Length > 3)
                {
                    textBox3.Text = string.Format("{0:n3}", double.Parse(textBox3.Text.Replace(','.ToString(), ""))).Replace(".000", "");
                }
                textBox3.SelectionStart = textBox3.Text.Length;

            }
            catch (Exception exp)
            {

                // MessageBox.Show(exp.Message);
                MessageBox.Show("عدد وارد شده در حق الزحمه را چک کنید");

            }
        }

        private void CmbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbRole.SelectedIndex == -1)
                {
                    MessageBox.Show("لطفا کد عامل را انتخاب نمایید");
                    CmbRole.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                RoleFill();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("لطفا واحد را انتخاب نمایید");
                    comboBox1.Focus();
                }
                else
                {
                    numericUpDown1.Focus();
                }
            }           
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {              
                    textBox3.Focus();              
            }   
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pbAddRole.Visible)
                {
                    pbAddRole_Click(new object(), new EventArgs());
                    CmbRole.Focus();
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
    }
}
