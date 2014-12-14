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
    public partial class Planning : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();
        public Planning(int ProgramId)
        {
            _ProgramGlobalObject.Id = ProgramId;
            InitializeComponent();
        }

        private void Planning_Load(object sender, EventArgs e)
        {
            //Set values to Check list box           
            NewListItem Program_Kind = new NewListItem();
            Program_Kind.Text = "زنده";
            Program_Kind.Value = "1";
            cmbProgramKind.Items.Add(Program_Kind);
            cmbProgramKind.SelectedIndex = 0;



            Program_Kind = new NewListItem();
            Program_Kind.Text = "تولیدی";
            Program_Kind.Value = "2";
            cmbProgramKind.Items.Add(Program_Kind);


            //add item to program kind
            NewListItem CheckedOutItm = new NewListItem();
            CheckedOutItm.Text = "دقیقه ای";
            CheckedOutItm.Value = "1";
            cmbCheckOutKind.Items.Add(CheckedOutItm);
            cmbCheckOutKind.SelectedIndex = 0;


            CheckedOutItm = new NewListItem();
            CheckedOutItm.Text = "کدی";
            CheckedOutItm.Value = "2";
            cmbCheckOutKind.Items.Add(CheckedOutItm);


            CheckedOutItm = new NewListItem();
            CheckedOutItm.Text = "گلوبال";
            CheckedOutItm.Value = "3";
            cmbCheckOutKind.Items.Add(CheckedOutItm);


            UpdateObjectFromDataBase();
            UpdateFormByObject();

        }
        private void UpdateObjectFromDataBase()
        {
            ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);
            _ProgramGlobalObject = Obj;
        }

        private void UpdateFormByObject()
        {
            txtEditDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Edit);
            txtFinanceDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Finance);
            txtPublish.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Publish);
            txtShoraDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Act_DateTime);
            toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;


            try
            {
                chkIsCheckedOut.Checked = _ProgramGlobalObject.IsCheckedOut;
            }
            catch
            {

            }


          
                if (_ProgramGlobalObject.Program_Kind =="1")
                {
                    cmbProgramKind.SetItemChecked(0, true);
                }
                if (_ProgramGlobalObject.Program_Kind == "2")
                {
                    cmbProgramKind.SetItemChecked(1, true);
                }
                if (_ProgramGlobalObject.Program_Kind == "3")
                {
                    cmbProgramKind.SetItemChecked(0, true);
                    cmbProgramKind.SetItemChecked(1, true);
                }
           


            for (int i = 0; i < cmbCheckOutKind.Items.Count; i++)
            {
                if (_ProgramGlobalObject.Checkout_Kind == ((NewListItem)cmbCheckOutKind.Items[i]).Value.ToString())
                {
                    cmbCheckOutKind.SelectedIndex = i;
                }
            }



        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {

            ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);
            _ProgramGlobalObject = Obj;
            bool AllowSave = true;

            try
            {
                if (DateConversion.JD2GD(txtEditDatetime.Text) >= DateConversion.JD2GD("1390/01/01"))
                {
                    _ProgramGlobalObject.Datetime_Edit = DateConversion.JD2GD(txtEditDatetime.Text);
                }
                else
                {
                    AllowSave = false;
                    MessageBox.Show("تاریخ اصلاح چک شود");
                }

                if (DateConversion.JD2GD(txtFinanceDatetime.Text) >= DateConversion.JD2GD("1390/01/01"))
                {
                    _ProgramGlobalObject.Datetime_Finance = DateConversion.JD2GD(txtFinanceDatetime.Text);
                }
                else
                {
                    AllowSave = false;
                    MessageBox.Show("تاریخ مالی چک شود");
                }


                if (DateConversion.JD2GD(txtPublish.Text) >= DateConversion.JD2GD("1390/01/01"))
                {
                    _ProgramGlobalObject.Datetime_Publish = DateConversion.JD2GD(txtPublish.Text);
                }
                else
                {
                    AllowSave = false;
                    MessageBox.Show("تاریخ صدور چک شود");
                }

                if (DateConversion.JD2GD(txtShoraDatetime.Text) >= DateConversion.JD2GD("1390/01/01"))
                {
                    _ProgramGlobalObject.Act_DateTime = DateConversion.JD2GD(txtShoraDatetime.Text);
                }
                else
                {
                    AllowSave = false;
                    MessageBox.Show("تاریخ تصویب چک شود");
                }




                if (AllowSave)
                {

                    _ProgramGlobalObject.IsCheckedOut = chkIsCheckedOut.Checked;

                    string SelectedValue = "0";

                    for (int i = 0; i < cmbProgramKind.Items.Count; i++)
                    {
                        if (cmbProgramKind.GetItemChecked(i))
                        {
                            SelectedValue = (int.Parse(((NewListItem)cmbProgramKind.Items[i]).Value.ToString()) +
                                int.Parse(SelectedValue)).ToString();
                        }
                    }

                    _ProgramGlobalObject.Program_Kind = SelectedValue;
                    _ProgramGlobalObject.Checkout_Kind = ((NewListItem)cmbCheckOutKind.SelectedItem).Value.ToString();

                    ProgramBll.Update_Program(_ProgramGlobalObject);

                    MessageBox.Show("با موفقیت ذخیره شد");
                }
                else
                {
                    MessageBox.Show("ذخیره نشد لطفا ایرادات را اصلاح کنید");
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
         

           

        }

        private void txtFinanceDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();

                txtFinanceDatetime.Text = DateConversion.GD2JD(DateTime.Parse(Ta.SelectDate()[0]["dt"].ToString()));
            }
        }

        private void txtEditDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();

                txtEditDatetime.Text = DateConversion.GD2JD(DateTime.Parse(Ta.SelectDate()[0]["dt"].ToString()));
            }
        }

        private void txtShoraDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();

                txtShoraDatetime.Text = DateConversion.GD2JD(DateTime.Parse(Ta.SelectDate()[0]["dt"].ToString()));
            }
        }

        private void txtPublish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();

                txtPublish.Text = DateConversion.GD2JD(DateTime.Parse(Ta.SelectDate()[0]["dt"].ToString()));
            }
        }

    }
}
