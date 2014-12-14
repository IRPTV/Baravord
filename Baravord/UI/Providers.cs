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
    public partial class Providers : Form
    {
        public Providers()
        {
            InitializeComponent();
        }

        private void Providers_Load(object sender, EventArgs e)
        {
             FetchProviders();
             //txtBirthDay.Text= DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime().AddYears(-30));
             //txtBulidDate.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
             //txtPlayDate.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
        }

        protected void FetchProviders()
        {

            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col3 = new DataColumn("نام");
            DataColumn col2 = new DataColumn(" نام خانوادگی");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);

            List<ProviderObj> Sub_Lst = ProvidersBll.Select_All_Providers();

            foreach (ProviderObj item in Sub_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;

                row[col2] = item.LASTNAME;
                row[col3] = item.Name;

                DTable.Rows.Add(row);
            }

            dgvProviders.DataSource = DTable;
            dgvProviders.Columns[0].Width = 30;
            dgvProviders.Columns[1].Width = 100;
            dgvProviders.Columns[2].Width = 100;

        }
        protected void FetchProviders(string ConditionQuery)
        {

            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col3 = new DataColumn("نام");
            DataColumn col2 = new DataColumn(" نام خانوادگی");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);

            List<ProviderObj> Sub_Lst = ProvidersBll.Search_Providers(ConditionQuery);

            foreach (ProviderObj item in Sub_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;

                row[col2] = item.LASTNAME;
                row[col3] = item.Name;

                DTable.Rows.Add(row);
            }

            dgvProviders.DataSource = DTable;
            dgvProviders.Columns[0].Width = 60;
            dgvProviders.Columns[1].Width = 100;
            dgvProviders.Columns[2].Width = 100;

        }

        private void BtnSelectAllProviders_Click(object sender, EventArgs e)
        {
            FetchProviders();
        }

        private void BtnSeach_Click(object sender, EventArgs e)
        {
            string Query = "";
            if (txtName.Text.Trim().Length > 0)
            {
                Query += "and Name like N'%" + txtName.Text.Trim() + "%'";
            }
            if (txtLastName.Text.Trim().Length > 0)
            {
                Query += "and LastName like N'%" + txtLastName.Text.Trim() + "%'";
            }

            if (txtName.Text.Trim().Length > 0 || txtLastName.Text.Trim().Length > 0)
            {
               // MessageBox.Show(" where " + Query.Remove(0, 3));
                FetchProviders(" where " + Query.Remove(0, 3));
            }
            else
            {
                // dgvProviders.Rows.Clear();
            }
        }

        private void dgvProviders_DoubleClick(object sender, EventArgs e)
        {
            string ConditionQuery = " where id= " + int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString());
            List<ProviderObj> Sub_Lst = ProvidersBll.Search_Providers(ConditionQuery);

            if (Sub_Lst.Count > 0)
            {
                txtNames.Text = Sub_Lst[0].Name;
                txtLastNames.Text = Sub_Lst[0].LASTNAME;
                txtFatherName.Text = Sub_Lst[0].FATHER_NAME;
                txtBirthDay.Text = Sub_Lst[0].BIRTHDATE;

                txtBirthPlace.Text = Sub_Lst[0].BIRTHPLACE;
                TxtShenasname.Text = Sub_Lst[0].SHENASNAME;
                TxtMelliCode.Text = Sub_Lst[0].MELLICODE;
                TxtNationality.Text = Sub_Lst[0].NATIONALITY;
                txtStudyLevel.Text = Sub_Lst[0].STUDYLEVEL;
                txtStudyCourse.Text = Sub_Lst[0].STYDUCOURCE;
                txtJob.Text = Sub_Lst[0].JOB;
                txtJobTitle.Text = Sub_Lst[0].JOBTITLE;
                txtIribEmployee.Text = Sub_Lst[0].IRIBEMPLOEE;
                txtPersonalMobile.Text = Sub_Lst[0].PERSONALMOBILE;
                txtHomeAddress.Text = Sub_Lst[0].HOMEADDRESS;
                txtHomeTellphone.Text = Sub_Lst[0].PERSONALTELL;
                txtFax.Text = Sub_Lst[0].PERSONALFAX;

                txtPersonalEmail.Text = Sub_Lst[0].PERSONALEMAIL;
                txtCompany.Text = Sub_Lst[0].COMPANY;
                txtCompanyArea.Text = Sub_Lst[0].COMPANYAREA;
                txtCompanyAddress.Text = Sub_Lst[0].COMPANYADDRESS;
                txtCompanyTell.Text = Sub_Lst[0].COMPANYTELL;
                txtCompanyFax.Text = Sub_Lst[0].COMPANYFAX;
                txtCompanyEmail.Text = Sub_Lst[0].COMPANYEMAIL;

                //Fetch History
                BindDgvHistory(Sub_Lst[0]);



            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            txtNames.Text = "";
            txtLastNames.Text = "";
            txtFatherName.Text = "";
            txtBirthDay.Text = "";
            txtBirthPlace.Text = "";
            TxtShenasname.Text = "";
            TxtMelliCode.Text = "";
            TxtNationality.Text = "";
            txtStudyLevel.Text = "";
            txtStudyCourse.Text = "";
            txtJob.Text = "";
            txtJobTitle.Text = "";
            txtIribEmployee.Text = "";
            txtPersonalMobile.Text = "";
            txtHomeAddress.Text = "";
            txtHomeTellphone.Text = "";
            txtFax.Text = "";
            txtPersonalEmail.Text = "";
            txtCompany.Text = "";
            txtCompanyArea.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyTell.Text = "";
            txtCompanyFax.Text = "";
            txtCompanyEmail.Text = "";

            dgvProviders.ClearSelection();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProviderObj Obj = new ProviderObj();

            Obj.Name = txtNames.Text;
            Obj.LASTNAME = txtLastNames.Text;
            Obj.FATHER_NAME = txtFatherName.Text;
            Obj.BIRTHDATE = txtBirthDay.Text;
            Obj.BIRTHPLACE = txtBirthPlace.Text;
            Obj.SHENASNAME = TxtShenasname.Text;
            Obj.MELLICODE = TxtMelliCode.Text;
            Obj.NATIONALITY = TxtNationality.Text;
            Obj.STUDYLEVEL = txtStudyLevel.Text;
            Obj.STYDUCOURCE = txtStudyCourse.Text;
            Obj.JOB = txtJob.Text;
            Obj.JOBTITLE = txtJobTitle.Text;
            Obj.IRIBEMPLOEE = txtIribEmployee.Text;
            Obj.PERSONALMOBILE = txtPersonalMobile.Text;
            Obj.HOMEADDRESS = txtHomeAddress.Text;
            Obj.PERSONALTELL = txtHomeTellphone.Text;
            Obj.PERSONALFAX = txtFax.Text;
            Obj.PERSONALEMAIL = txtPersonalEmail.Text;
            Obj.COMPANY = txtCompany.Text;
            Obj.COMPANYAREA = txtCompanyArea.Text;
            Obj.COMPANYADDRESS = txtCompanyAddress.Text;
            Obj.COMPANYTELL = txtCompanyTell.Text;
            Obj.COMPANYFAX = txtCompanyFax.Text;
            Obj.COMPANYEMAIL = txtCompanyEmail.Text;

            if (dgvProviders.SelectedRows.Count == 1)
            {
                Obj.Id = int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString());
                ProvidersBll.Update_Provider(Obj);
            }
            else
            {
                ProvidersBll.Insert_Provider(Obj);
            }

            BtnNew_Click(new object(), new EventArgs());
            FetchProviders();

        }
        private List<Provider_HistoryObj> FetchHistoryProvider(ProviderObj Prvd)
        {
            return Provider_HistoryBll.Select_Provider_History(Prvd);
        }

        private void BindDgvHistory(ProviderObj Obj)
        {
            List<Provider_HistoryObj> His_Lst = FetchHistoryProvider(Obj);

            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col3 = new DataColumn("عنوان");
            DataColumn col2 = new DataColumn("تاریخ تولید");
            DataColumn col4 = new DataColumn("تاریخ پخش");


            DTable.Columns.Add(col1);

            DTable.Columns.Add(col3);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col4);


            foreach (Provider_HistoryObj item in His_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;

                row[col3] = item.Title;
                row[col2] = item.BUILD_DATETIME;
                row[col4] = item.PLAY_DATETIME;

                DTable.Rows.Add(row);
            }

            dgvProviderHistory.DataSource = DTable;
            dgvProviderHistory.Columns[0].Width = 30;
            dgvProviderHistory.Columns[1].Width = 150;
            dgvProviderHistory.Columns[2].Width = 120;
            dgvProviderHistory.Columns[2].Width = 120;
        }

        private void dgvProviderHistory_Click(object sender, EventArgs e)
        {

            Provider_HistoryObj Obj = Provider_HistoryBll.Select_Current_Provider_History(
                 int.Parse(dgvProviderHistory.SelectedRows[0].Cells[0].Value.ToString()));

            txtTitle.Text = Obj.Title;
            txtSubject.Text = Obj.Subject;
            txtStructure.Text = Obj.STRUCTURE;
            txtChannel.Text = Obj.CHANNELS;
            txtBulidDate.Text = Obj.BUILD_DATETIME;
            txtPlayDate.Text = Obj.PLAY_DATETIME;
            txtSession.Text = Obj.SESSION;
            txtSessionTime.Text = Obj.SESSION_TIME;
            txtLevel.Text = Obj.LEVEL;
            txtRole.Text = Obj.ROLE;

        }

        private void btnNewHistory_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtSubject.Text = "";
            txtStructure.Text = "";
            txtChannel.Text = "";
            txtBulidDate.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            txtPlayDate.Text = DateConversion.GD2JD(Baravord.TOOLS.GetDate.GetDateTime());
            txtSession.Text = "";
            txtSessionTime.Text = "";
            txtLevel.Text = "";
            txtRole.Text = "";

            dgvProviderHistory.ClearSelection();
        }

        private void btnSaveHistory_Click(object sender, EventArgs e)
        {
            Provider_HistoryObj Obj = new Provider_HistoryObj();

            string ConditionQuery = " where id= " + int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString());
            List<ProviderObj> Sub_Lst = ProvidersBll.Search_Providers(ConditionQuery);



            Obj.Title = txtTitle.Text;
            Obj.Subject = txtSubject.Text;
            Obj.STRUCTURE = txtStructure.Text;
            txtChannel.Text = Obj.CHANNELS = txtChannel.Text;
            Obj.BUILD_DATETIME = txtBulidDate.Text;
            Obj.PLAY_DATETIME = txtPlayDate.Text;
            Obj.SESSION = txtSession.Text;
            Obj.SESSION_TIME = txtSessionTime.Text;
            Obj.LEVEL = txtLevel.Text;
            Obj.ROLE = txtRole.Text;
            Obj.PROVIDER_ID = Sub_Lst[0].Id;

            if (dgvProviderHistory.SelectedRows.Count == 1)
            {
                Obj.Id = int.Parse(dgvProviderHistory.SelectedRows[0].Cells[0].Value.ToString());
                Provider_HistoryBll.Update_Provider_History(Obj);
            }
            else
            {
                Provider_HistoryBll.Insert_Provider_History(Obj);
            }


            btnNewHistory_Click(new object(), new EventArgs());

         

            if (Sub_Lst.Count > 0)
            {

                BindDgvHistory(Sub_Lst[0]);
            }

        }

        private void dgvProviderHistory_DoubleClick(object sender, EventArgs e)
        {
            Provider_HistoryObj Obj = Provider_HistoryBll.Select_Current_Provider_History(
                int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString()));

            txtTitle.Text = Obj.Title;
            txtSubject.Text = Obj.Subject;
            txtStructure.Text = Obj.STRUCTURE;
            txtChannel.Text = Obj.CHANNELS;
            txtBulidDate.Text = Obj.BUILD_DATETIME;
            txtPlayDate.Text = Obj.PLAY_DATETIME;
            txtSession.Text = Obj.SESSION;
            txtSessionTime.Text = Obj.SESSION_TIME;
            txtLevel.Text = Obj.LEVEL;
            txtRole.Text = Obj.ROLE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا تهیه کننده  انتخاب شده حذف گردد؟", "حذف",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<string[]> Lst =
                    ProvidersBll.Select_ProviderById(int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString()));


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
                    Provider_HistoryBll.Delete_Provider_History(int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString()));
                    ProvidersBll.Delete_Provider(int.Parse(dgvProviders.SelectedRows[0].Cells[0].Value.ToString()));
                    FetchProviders();
                }
            }
        }
    }
}
