using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Baravord.BLL;
using Baravord.OBJECTS;
using Baravord.Properties;
using Baravord.TOOLS;
using System.Text.RegularExpressions;

namespace Baravord.UI
{
    public partial class Shora : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();
        int _Dep = 1;

        public Shora(int ProgramId, int Dep)
        {
            _ProgramGlobalObject.Id = ProgramId;
            _Dep = Dep;
            InitializeComponent();
        }
        private void Shora_Load(object sender, EventArgs e)
        {
          

            #region FillData
            //FillCmb Channel
            ChannelFill();

            //Fill Check list Box Levels
            LevelFill();

            //Fill Check list Box Subjects
            SubjectFill();

            //Fill Ckeck List Box Structures
            StructureFill();

            //Fill Static Combo Box
            StaticValueFill();

            //Fill Combo Box Roles and Costs
           // RoleFill();

            //Fill Combo Box Payment Methods
            PaymentFill();

            //Fill Notification to Check List Box
            NotifyFill();

            //Fill Languages to Combo Box
            LanguageFill();

            //Fill Providers to Combo Box
            ProviderFill();

            //Fill Department into  the ComboBox
            DepsFill();


            TargetFill();
            #endregion

            #region FillDataForProgram
            if (_ProgramGlobalObject.Id.Equals(0))
            {
                toolStripLblProgramTitle.Text = "ورود اطلاعات مصوبه برنامه جدید";

                //Insert New Programme And Save ID
                ProgramObj RetProgObject = ProgramBll.Insert_Prgram(_ProgramGlobalObject);
                _ProgramGlobalObject = RetProgObject;
                _ProgramGlobalObject.Datetime_Edit =GetDate.GetDateTime();
                _ProgramGlobalObject.Datetime_Finance = GetDate.GetDateTime();
                _ProgramGlobalObject.Datetime_Publish = GetDate.GetDateTime();
                _ProgramGlobalObject.Datetime_Tarh = GetDate.GetDateTime();
             //   txtDatetime_Tarh.Text = DateConversion.GD2JD(GetDate.GetDateTime());

                BtnPrintDep.Visible = false;
            }
            else
            {
                UpdateObjectFromDataBase();
                UpdateFormByObject();

                if (_ProgramGlobalObject.BackProgId == 0)
                {
                    BtnPrintDep.Visible = false;
                }

                // SetBaravordNumber();
                SetStructure();
                SetLevels();
                SetSubjects();
                SetNotify();
                SetRoleGirdView();
                SetLocationGirdView();
                SetCopyRightGirdView();
                SetPaymentGirdView();
                SetProvider();
                SetDept();
                SetTargets();

            }

            if (_Dep == 1)
            {
                txtBaravordNumber.Enabled = false;
            }

            #endregion
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
            UpdateFormByObjectPl();

        }
        public void TargetFill()
        {
            List<TargetObj> Tar_Lst = TargetBll.Select_All_Targets();

            ChkBxLstTarget.Items.Clear();

            foreach (TargetObj item in Tar_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                ChkBxLstTarget.Items.Add(Lst);
            }
        }
        protected void SetDept()
        {

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

        public void LevelFill()
        {
            LevelBll Level_Bll = new LevelBll();
            List<LevelObj> Lev_Lst = Level_Bll.Select_All_Level();

            CmbLevels.Items.Clear();

            foreach (LevelObj item in Lev_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbLevels.Items.Add(Lst);
            }

            CmbLevels.SelectedIndex = 0;
        }

        public void SubjectFill()
        {
            SubjectBll Subject_Bll = new SubjectBll();
            List<SubjectObj> Sub_Lst = Subject_Bll.Select_All_Subject();

            ChkBxLstSubject.Items.Clear();

            foreach (SubjectObj item in Sub_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                ChkBxLstSubject.Items.Add(Lst);
            }
        }

        public void ProviderFill()
        {

            CmbProvider.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CmbProvider.AutoCompleteSource = AutoCompleteSource.ListItems;


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


        public void StructureFill()
        {
            StructureBll Structure_Bll = new StructureBll();
            List<StructureObj> Struct_Lst = Structure_Bll.Select_All_Struct();

            CmbStructures.Items.Clear();

            foreach (StructureObj item in Struct_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbStructures.Items.Add(Lst);
            }
            CmbStructures.SelectedIndex = 0;
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

        public void StaticValueFill()
        {
            //Music Combo Box
            NewListItem Music_Lst = new NewListItem();
            Music_Lst.Text = "خرید رایت";
            Music_Lst.Value = "1";
           // CmbMusic.Items.Add(Music_Lst);
          //  CmbMusic.SelectedIndex = 0;

            NewListItem Music_Lst2 = new NewListItem();
            Music_Lst2.Text = "تولیدی";
            Music_Lst2.Value = "2";
          //  CmbMusic.Items.Add(Music_Lst2);

            //Archive Combo Box
            NewListItem Archive_Lst = new NewListItem();
            Archive_Lst.Text = "دارد";
            Archive_Lst.Value = "1";
         //   CmbHasArchive.Items.Add(Archive_Lst);
         //   CmbHasArchive.SelectedIndex = 0;

            NewListItem Archive_Lst2 = new NewListItem();
            Archive_Lst2.Text = "ندارد";
            Archive_Lst2.Value = "0";
           // CmbHasArchive.Items.Add(Archive_Lst2);

            //Visa Combo Box          
            NewListItem Visa_Lst = new NewListItem();
            Visa_Lst.Text = "به عهده تهیه کننده";
            Visa_Lst.Value = "1";
          //  CmbVisa.Items.Add(Visa_Lst);


            NewListItem Visa_Lst2 = new NewListItem();
            Visa_Lst2.Text = "به عهده شبکه";
            Visa_Lst2.Value = "2";
            //CmbVisa.Items.Add(Visa_Lst2);

            NewListItem Visa_Lst3 = new NewListItem();
            Visa_Lst3.Text = "-----------";
            Visa_Lst3.Value = "3";
            //CmbVisa.Items.Add(Visa_Lst3);
            //CmbVisa.SelectedIndex = 2;



        }

        //public void RoleFill()
        //{


        //    //CmbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    //CmbRole.AutoCompleteSource = AutoCompleteSource.ListItems;



        //    RoleBll Rol_Bll = new RoleBll();
        //    List<RoleObj> Rl_Lst = Rol_Bll.Select_All_Role();

        //    CmbRole.Items.Clear();

        //    foreach (RoleObj item in Rl_Lst)
        //    {
        //        NewListItem Lst = new NewListItem();
        //        Lst.Text = item.Title;
        //        Lst.Value = item.Id;

        //        CmbRole.Items.Add(Lst);
        //    }
        //    CmbRole.SelectedIndex = 0;
        //}

        public void PaymentFill()
        {
            //PaymentBll Py_Bll = new PaymentBll();
            //List<PaymentObj> Py_Lst = Py_Bll.Select_All_Payment();

            //CmbPayment.Items.Clear();

            //foreach (PaymentObj item in Py_Lst)
            //{
            //    NewListItem Lst = new NewListItem();
            //    Lst.Text = item.Title;
            //    Lst.Value = item.Id;

            //    CmbPayment.Items.Add(Lst);
            //}
            //CmbPayment.SelectedIndex = 0;
        }

        public void NotifyFill()
        {
            NotifyBll Not_Bll = new NotifyBll();
            List<NotifyObj> Notify_Lst = Not_Bll.Select_All_Notify(1);

            ChkLstNotify.Items.Clear();

            foreach (NotifyObj item in Notify_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                ChkLstNotify.Items.Add(Lst);
            }

            NotifyBll Not_Bll2 = new NotifyBll();
            List<NotifyObj> Notify_Lst2 = Not_Bll2.Select_All_Notify(2);

            ChkLstNotify2.Items.Clear();

            foreach (NotifyObj item in Notify_Lst2)
            {
                NewListItem Lst2 = new NewListItem();
                Lst2.Text = item.Title;
                Lst2.Value = item.Id;

                ChkLstNotify2.Items.Add(Lst2);
            }


            // ChkLstNotify.SelectedIndex = 0;
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            //If Temp Inserted Data Not updated delete temp record
            CancelInsertTemp();

            //If tem data updated cancel save for next times
        }

        private void CancelInsertTemp()
        {
            if (
                _ProgramGlobalObject.LanguageId == 0 &&
                 _ProgramGlobalObject.ChannelId == 0 &&
                _ProgramGlobalObject.Provider_Id == 0 &&
                _ProgramGlobalObject.Session == 0 &&
                _ProgramGlobalObject.Title_Farsi == "" &&
                _ProgramGlobalObject.Title_2 == ""
                )
            {
                //Delete Temp Record By Id
                if (ProgramBll.Delete_Current_Program(_ProgramGlobalObject))
                {
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
            else
            {

            }
        }

        private void Shora_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelInsertTemp();
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            //Update Record In DB
            if (TotalPercent() > 100)
            {
                MessageBox.Show("جمع درصد ساخت بیش از 100 درصد است");
            }
            else
            {
                bool NoError = UpdateObjectForDataBase();
                if (NoError)
                {
                    ProgramBll.Update_Program(_ProgramGlobalObject);

                    //Insert And Update  Structure for current program
                    SaveStructure();


                    //Insert And Update  Structure for current program
                    SaveLevels();


                    //Insert And Update  Structure for current program
                    SaveSubjects();


                    //Insert And Update  Notify for current program
                    SaveNotify();



                    SaveTarget();




                    //Update form title for program Title
                    toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;



                    //Set Golbal Programe in Main Form
                    GlobalObjectTools.SetGlobalProgramObject(_ProgramGlobalObject);

                    MessageBoxEx.Show("با موفقیت ذخیره شد", "برآورد", 500);
                }
                else
                {

                }
            }


        }
        private void SaveTarget()
        {
            List<TargetObj> tarLst = new List<TargetObj>();
            for (int i = 0; i < ChkBxLstTarget.Items.Count; i++)
            {
                if (ChkBxLstTarget.GetItemChecked(i))
                {
                    TargetObj LvlObj = new TargetObj();
                    LvlObj.Id = int.Parse(((NewListItem)ChkBxLstTarget.Items[i]).Value.ToString());
                    tarLst.Add(LvlObj);
                }
            }
            TargetBll.Insert_Program_Target(tarLst, _ProgramGlobalObject);
        }

        private void SetTargets()
        {
            List<TargetObj> TargLst = TargetBll.Select_All_Program_Target(_ProgramGlobalObject);
            int Count = 0;
            for (int i = 0; i < ChkBxLstTarget.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)ChkBxLstTarget.Items[i];

                foreach (TargetObj item in TargLst)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                    {
                        ChkBxLstTarget.SetItemCheckState(i, CheckState.Checked);
                        Count++;
                    }
                }
            }
            groupBox12.Text = "هدف " + "( " + Count.ToString() + " مورد )";
        }

        private bool UpdateObjectForDataBase()
        {
            if (ValidateForm().Length < 5)
            {


                ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);

                _ProgramGlobalObject.Title_Farsi = TxtTitle_Farsi.Text;
                _ProgramGlobalObject.Title_2 = TxtTitle_2.Text;

                //_ProgramGlobalObject.Act_DateTime = DateConversion.JD2GD(NudYear.Value.ToString("0000") + "/"
                //    + NudMonth.Value.ToString("00") + "/"
                //    + NudDay.Value.ToString("00"));

                _ProgramGlobalObject.Baravord_Number = Obj.Baravord_Number;
                _ProgramGlobalObject.LanguageId = int.Parse(((NewListItem)cmbLanguage.SelectedItem).Value.ToString());
              //  _ProgramGlobalObject.Latest_Delivery = int.Parse(NudLatest_Delivery.Value.ToString());
                _ProgramGlobalObject.Percent_Archive = float.Parse(NudArchive.Value.ToString());
                _ProgramGlobalObject.Percent_Dubbed = float.Parse(NudDubbed.Value.ToString());
                _ProgramGlobalObject.Percent_Live = float.Parse(NudLivePercent.Value.ToString());
                _ProgramGlobalObject.Percent_New = float.Parse(NudNew.Value.ToString());
                _ProgramGlobalObject.Session = int.Parse(NudSession.Value.ToString());
                _ProgramGlobalObject.ChannelId = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
                _ProgramGlobalObject.Provider_Id = int.Parse(((NewListItem)CmbProvider.SelectedItem).Value.ToString());
              //  _ProgramGlobalObject.Price_Minute = TxtPriceMinute.Text.Replace(",", "").Trim();
                _ProgramGlobalObject.Description = Obj.Description;
                _ProgramGlobalObject.Director_Name = txtDirector.Text;
                _ProgramGlobalObject.Writer_Name = txtWriter.Text;
                _ProgramGlobalObject.Session_Time = NudHour.Value.ToString("00") + ":" + NudMinute.Value.ToString("00") + ":" + NudSecond.Value.ToString("00");
                _ProgramGlobalObject.Writer_Name = Obj.Writer_Name;
                _ProgramGlobalObject.Notify = txtNotify.Text;
                _ProgramGlobalObject.Dep = _Dep;
                _ProgramGlobalObject.SendDate = Obj.SendDate;
                _ProgramGlobalObject.BackProgId = Obj.BackProgId;
                _ProgramGlobalObject.RcvDate = Obj.RcvDate;


                try
                {
                   // _ProgramGlobalObject.Datetime_Tarh = DateConversion.JD2GD(txtDatetime_Tarh.Text);
                }
                catch
                {
                    MessageBox.Show("لطفا تاریخ ثبت طرح را به صورت 1390/01/01  وارد کنید");
                    _ProgramGlobalObject.Datetime_Tarh = DateConversion.JD2GD("1390/01/01");
                }



                _ProgramGlobalObject.Baravord_Number = txtBaravordNumber.Text.Trim();

               // _ProgramGlobalObject.TarhNumber = txtTarhNumber.Text.Trim();


                //Archive Buy
                //if (((NewListItem)CmbHasArchive.SelectedItem).Value.ToString() == "1")
                //{
                //    _ProgramGlobalObject.ArchiveBuy = true;
                //}
                //else
                //{
                //    _ProgramGlobalObject.ArchiveBuy = false;
                //}



                //Depart
                try
                {
                    _ProgramGlobalObject.Depart = int.Parse(((NewListItem)cmbDep.SelectedItem).Value.ToString());
                }
                catch
                {
                    _ProgramGlobalObject.Depart = 0;
                    MessageBox.Show("واحد مدیریتی انتخاب نشده است");
                }



                //2014-08-10

                _ProgramGlobalObject.Datetime_Edit = DateConversion.JD2GD(txtEditDatetime.Text);

             //   _ProgramGlobalObject.Datetime_Finance = DateConversion.JD2GD(txtFinanceDatetime.Text);

                _ProgramGlobalObject.Datetime_Publish = DateConversion.JD2GD(txtPublish.Text);

                _ProgramGlobalObject.Act_DateTime = DateConversion.JD2GD(txtShoraDatetime.Text);

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




                //Visa By Provider

             //   _ProgramGlobalObject.VisaByProvider = ((NewListItem)CmbVisa.SelectedItem).Value.ToString();


              //  _ProgramGlobalObject.Music = int.Parse(((NewListItem)CmbMusic.SelectedItem).Value.ToString());
                return true;
            }
            else
            {
                MessageBox.Show(ValidateForm(), "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }
        protected bool CheckDate(string Txt)
        {
            if (Txt.Trim().Length == 10)
            {
                try
                {
                    DateConversion.JD2GD(Txt);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                 return false;
            }
          
        }

        private void UpdateObjectFromDataBase()
        {
            ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);
            _ProgramGlobalObject = Obj;
        }

        private void UpdateFormByObject()
        {
            TxtTitle_Farsi.Text = _ProgramGlobalObject.Title_Farsi;
            TxtTitle_2.Text = _ProgramGlobalObject.Title_2;
            //TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(_ProgramGlobalObject.Price_Minute)).Replace(".000", "");
            txtBaravordNumber.Text = _ProgramGlobalObject.Baravord_Number;

            string[] TimeCodes = ToolsFunctions.SplitTimeCode(_ProgramGlobalObject.Session_Time);
            NudSecond.Value = decimal.Parse(TimeCodes[2].ToString());
            NudMinute.Value = decimal.Parse(TimeCodes[1].ToString());
            NudHour.Value = decimal.Parse(TimeCodes[0].ToString());

          //  NudLatest_Delivery.Value = decimal.Parse(_ProgramGlobalObject.Latest_Delivery.ToString());

            NudSession.Value = decimal.Parse(_ProgramGlobalObject.Session.ToString());

            NudNew.Value = decimal.Parse(_ProgramGlobalObject.Percent_New.ToString());
            NudArchive.Value = decimal.Parse(_ProgramGlobalObject.Percent_Archive.ToString());
            NudDubbed.Value = decimal.Parse(_ProgramGlobalObject.Percent_Dubbed.ToString());
            NudLivePercent.Value = decimal.Parse(_ProgramGlobalObject.Percent_Live.ToString());

           // NudDay.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[2]);
           // NudMonth.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[1]);
          //  NudYear.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[0]);

            toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;

            txtNotify.Text = _ProgramGlobalObject.Notify;

          //  txtTarhNumber.Text = _ProgramGlobalObject.TarhNumber;


          //  txtDatetime_Tarh.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Tarh);



            txtDirector.Text = _ProgramGlobalObject.Director_Name;
            txtWriter.Text = _ProgramGlobalObject.Writer_Name;
            //Set Music Cobo Items
            //for (int i = 0; i < CmbMusic.Items.Count; i++)
            //{
            //    NewListItem Ch = (NewListItem)CmbMusic.Items[i];

            //    if (Ch.Value.ToString() == _ProgramGlobalObject.Music.ToString())
            //    {
            //        CmbMusic.SelectedIndex = i;
            //    }
            //}

            //Set Language Cobo Items
            for (int i = 0; i < cmbLanguage.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)cmbLanguage.Items[i];

                if (Ch.Value.ToString() == _ProgramGlobalObject.LanguageId.ToString())
                {
                    cmbLanguage.SelectedIndex = i;
                }
            }

            //Set Visa Combo Items     
            //for (int i = 0; i < CmbVisa.Items.Count; i++)
            //{
            //    NewListItem Ch = (NewListItem)CmbVisa.Items[i];

            //    if (Ch.Value.ToString() == _ProgramGlobalObject.VisaByProvider)
            //    {
            //        CmbVisa.SelectedIndex = i;
            //    }
            //}

            //Set Archive Combo Items

            string ValueArchive = "0";
            if (_ProgramGlobalObject.ArchiveBuy)
            {
                ValueArchive = "1";
            }

            //for (int i = 0; i < CmbHasArchive.Items.Count; i++)
            //{
            //    NewListItem Ch = (NewListItem)CmbHasArchive.Items[i];

            //    if (Ch.Value.ToString() == ValueArchive)
            //    {
            //        CmbHasArchive.SelectedIndex = i;
            //    }
            //}

            //Set CmbCHANNEL Items
            for (int i = 0; i < CmbChannel.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)CmbChannel.Items[i];

                if (Ch.Value.ToString() == _ProgramGlobalObject.ChannelId.ToString())
                {
                    CmbChannel.SelectedIndex = i;
                }
            }



            for (int i = 0; i < cmbDep.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)cmbDep.Items[i];

                if (LstChk.Value.ToString() == _ProgramGlobalObject.Depart.ToString())
                {
                    cmbDep.SelectedIndex = i;
                }
            }
        }

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SetBaravordNumber();

            //Fill Deps
            DepsFill();

        }

        //private void SetBaravordNumber()
        //{
        //    NewListItem Selected = (NewListItem)CmbChannel.SelectedItem;
        //    lblBaravordNumber.Text =
        //        ToolsFunctions.GenerateBaravordCode(NudYear.Value.ToString(),
        //        int.Parse(Selected.Value.ToString()));
        //}

        private void NudYear_ValueChanged(object sender, EventArgs e)
        {
            //  SetBaravordNumber();
        }

        private void SetStructure()
        {
            List<StructureObj> StructOnj = StructureBll.Select_Program_Structs(_ProgramGlobalObject);

            for (int i = 0; i < CmbStructures.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)CmbStructures.Items[i];

                foreach (StructureObj item in StructOnj)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                        CmbStructures.SelectedIndex = i;
                }
            }
        }

        private void SetProvider()
        {
            for (int i = 0; i < CmbProvider.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)CmbProvider.Items[i];

                if (LstChk.Value.ToString() == _ProgramGlobalObject.Provider_Id.ToString())
                {
                    CmbProvider.SelectedIndex = i;
                }
            }
        }

        private void SaveStructure()
        {
            List<StructureObj> StructLst = new List<StructureObj>();

            StructureObj StrObj = new StructureObj();
            StrObj.Id = int.Parse(((NewListItem)CmbStructures.SelectedItem).Value.ToString());
            StructLst.Add(StrObj);

            StructureBll.Insert_Program_Struct(StructLst, _ProgramGlobalObject);
        }

        private void SaveLevels()
        {
            List<LevelObj> LvlLst = new List<LevelObj>();

            LevelObj LvlObj = new LevelObj();
            LvlObj.Id = int.Parse(((NewListItem)CmbLevels.SelectedItem).Value.ToString());
            LvlLst.Add(LvlObj);

            LevelBll.Insert_Program_Level(LvlLst, _ProgramGlobalObject);
        }

        private void SetLevels()
        {
            List<LevelObj> LvlLst = LevelBll.Select_All_Program_Levels(_ProgramGlobalObject);

            for (int i = 0; i < CmbLevels.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)CmbLevels.Items[i];

                foreach (LevelObj item in LvlLst)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                        CmbLevels.SelectedIndex = i;
                }
            }
        }

        private void SaveSubjects()
        {
            List<SubjectObj> SubjLst = new List<SubjectObj>();
            for (int i = 0; i < ChkBxLstSubject.Items.Count; i++)
            {
                if (ChkBxLstSubject.GetItemChecked(i))
                {
                    SubjectObj SubObj = new SubjectObj();
                    SubObj.Id = int.Parse(((NewListItem)ChkBxLstSubject.Items[i]).Value.ToString());
                    SubjLst.Add(SubObj);
                }
            }
            SubjectBll.Insert_Program_Subject(SubjLst, _ProgramGlobalObject);
        }

        private void SetSubjects()
        {
            List<SubjectObj> LvlLst = SubjectBll.Select_Program_Subject(_ProgramGlobalObject);
            int Count = 0;

            for (int i = 0; i < ChkBxLstSubject.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)ChkBxLstSubject.Items[i];

                foreach (SubjectObj item in LvlLst)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                    {
                        ChkBxLstSubject.SetItemCheckState(i, CheckState.Checked);
                        Count++;
                    }
                }
            }


            groupBox8.Text = "موضوع " + "( " + Count.ToString() + " مورد )";
        }

        private void SaveNotify()
        {
            NotifyBll.Delete_Program_All_Notify(_ProgramGlobalObject);
            List<NotifyObj> NotifyLst = new List<NotifyObj>();
            for (int i = 0; i < ChkLstNotify.Items.Count; i++)
            {
                if (ChkLstNotify.GetItemChecked(i))
                {
                    NotifyObj SubObj = new NotifyObj();
                    SubObj.Id = int.Parse(((NewListItem)ChkLstNotify.Items[i]).Value.ToString());
                    NotifyLst.Add(SubObj);
                }
            }

            for (int i = 0; i < ChkLstNotify2.Items.Count; i++)
            {
                if (ChkLstNotify2.GetItemChecked(i))
                {
                    NotifyObj SubObj = new NotifyObj();
                    SubObj.Id = int.Parse(((NewListItem)ChkLstNotify2.Items[i]).Value.ToString());
                    NotifyLst.Add(SubObj);
                }
            }
            NotifyBll.Insert_Program_Notify(NotifyLst, _ProgramGlobalObject);
        }

        private void SetNotify()
        {
            List<NotifyObj> NotifyLst = NotifyBll.Select_Program_Notify(_ProgramGlobalObject);
            int Count = 0;
            for (int i = 0; i < ChkLstNotify.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)ChkLstNotify.Items[i];

                foreach (NotifyObj item in NotifyLst)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                    {
                        ChkLstNotify.SetItemCheckState(i, CheckState.Checked);
                        Count++;
                    }
                }
            }
            groupBox3.Text = "توجه " + "( " + Count.ToString() + " مورد )";
            Count = 0;

            for (int i = 0; i < ChkLstNotify2.Items.Count; i++)
            {
                NewListItem LstChk = (NewListItem)ChkLstNotify2.Items[i];

                foreach (NotifyObj item in NotifyLst)
                {
                    if (LstChk.Value.ToString() == item.Id.ToString())
                    {
                        ChkLstNotify2.SetItemCheckState(i, CheckState.Checked);
                        Count++;
                    }
                }
            }
            groupBox9.Text = "توضیحات " + "( " + Count.ToString() + " مورد )";
        }

        public void AddRole()
        {
            //try
            //{
            //    NewListItem Lst = (NewListItem)CmbRole.SelectedItem;

            //    Program_RoleObj Obj = new Program_RoleObj();
            //    Obj.Role_Id = int.Parse(Lst.Value.ToString());
            //    Obj.Price_Unit = "0";
            //    Obj.Id = 1;
            //    Obj.Time = "1";
            //    Obj.Count = 1;
            //    Obj.Unit = 1;
            //    Obj.Description = "";



            //    Program_RoleBll.Insert_Program_Role(Obj, _ProgramGlobalObject);
            //    SetRoleGirdView();
            //}
            //catch
            //{

            //    MessageBox.Show("این کد در سیستم موجود نیست به مدیر سیستم اطلاع دهید");
            //}

        }

        private void pbAddRole_Click(object sender, EventArgs e)
        {
            AddRole();
        }

        private void SetRoleGirdView()
        {
            //DataTable DTable = new DataTable();

            //DataColumn col1 = new DataColumn("ID");
            //DataColumn col2 = new DataColumn("عنوان");

            //DTable.Columns.Add(col1);
            //DTable.Columns.Add(col2);

            //List<Program_RoleObj> Prg_Role_Lst = Program_RoleBll.Select_Program_All_Roles(_ProgramGlobalObject);


            //foreach (Program_RoleObj item in Prg_Role_Lst)
            //{
            //    DataRow row = DTable.NewRow();
            //    row[col1] = item.Id;
            //    RoleObj RlObj = new RoleObj();
            //    RlObj.Id = item.Role_Id;
            //    row[col2] = RoleBll.Select_Current_Role(RlObj).Title;
            //    DTable.Rows.Add(row);
            //}

            //dgvRoles.DataSource = DTable;
            //dgvRoles.Columns[0].Width = 60;
            //dgvRoles.Columns[1].Width = 390;





        }

        private void pbAddLocation_Click(object sender, EventArgs e)
        {
            AddLocation();

        }

        private void AddLocation()
        {
            //if (TxtLocationName.Text.Trim().Length > 2)
            //{
            //    Program_LocationObj Location = new Program_LocationObj();
            //    Location.DURATION = int.Parse(NudLocationTime.Value.ToString());
            //    Location.Program_Id = _ProgramGlobalObject.Id;
            //    Location.TITLE = TxtLocationName.Text.Trim();

            //    Program_LocationBll.Insert_Program_Location(Location, _ProgramGlobalObject);

            //    SetLocationGirdView();

            //    TxtLocationName.Text = "";
            //}
            //else
            //{
            //    MessageBox.Show("عنوان لوکیشن حد اقل باید سه کاراکتر باشد");
            //}
        }

        private void SetLocationGirdView()
        {
            //DataTable DTable = new DataTable();

            //DataColumn col1 = new DataColumn("ID");
            //DataColumn col2 = new DataColumn("لوکیشن");
            //DataColumn col3 = new DataColumn("زمان");

            //DTable.Columns.Add(col1);
            //DTable.Columns.Add(col2);
            //DTable.Columns.Add(col3);

            //List<Program_LocationObj> Prg_Role_Lst = Program_LocationBll.Select_Program_Location(_ProgramGlobalObject);

            //int Days = 0;


            //foreach (Program_LocationObj item in Prg_Role_Lst)
            //{
            //    DataRow row = DTable.NewRow();
            //    row[col1] = item.ID;
            //    row[col2] = item.TITLE;
            //    row[col3] = item.DURATION + " روز ";
            //    DTable.Rows.Add(row);

            //    Days += item.DURATION;
            //}

            //dgvLocation.DataSource = DTable;
            //dgvLocation.Columns[0].Width = 40;
            //dgvLocation.Columns[1].Width = 350;
            //dgvLocation.Columns[2].Width = 60;


            //lblTotatDays.Text = "مجموع: " + Days + " روز ";
        }

        private void pbAddRight_Click(object sender, EventArgs e)
        {
            AddCopyRight();
        }

        private void AddCopyRight()
        {
            //if (txtRightTitle.Text.Trim().Length > 2)
            //{
            //    Program_CopyRightObj Right = new Program_CopyRightObj();
            //    Right.Title = txtRightTitle.Text;
            //    Right.Program_Id = _ProgramGlobalObject.Id;
            //    Right.ValuePercent = int.Parse(NudRightPercent.Value.ToString());

            //    int Percent = 0;
            //    bool Exist = false;
            //    List<Program_CopyRightObj> Prg_Role_Lst = Program_CopyRightBll.Select_Program_CopyRight(_ProgramGlobalObject);

            //    foreach (Program_CopyRightObj item in Prg_Role_Lst)
            //    {
            //        Percent += item.ValuePercent;
            //        if (Right.Title == item.Title)
            //        {
            //            MessageBox.Show("عنوان تکراری برای مالکیت وارد شده است", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //    }
            //    if (Percent + int.Parse(NudRightPercent.Value.ToString()) <= 100)
            //    {


            //        Program_CopyRightBll.Insert_Program_CopyRight(Right, _ProgramGlobalObject);

            //        SetCopyRightGirdView();
            //        txtRightTitle.Text = "";
            //    }
            //    else
            //    {
            //        MessageBox.Show("جمع کل از صد درصد بیشتر می شود", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("عنوان مشارکت باید حداقل سه کاراکتر باشد");
            //}
        }

        private void SetCopyRightGirdView()
        {
            //DataTable DTable = new DataTable();

            //DataColumn col1 = new DataColumn("ID");
            //DataColumn col2 = new DataColumn("عنوان");
            //DataColumn col3 = new DataColumn("درصد");

            //DTable.Columns.Add(col1);
            //DTable.Columns.Add(col2);
            //DTable.Columns.Add(col3);

            //List<Program_CopyRightObj> Prg_Role_Lst = Program_CopyRightBll.Select_Program_CopyRight(_ProgramGlobalObject);

            //int Percent = 0;

            //foreach (Program_CopyRightObj item in Prg_Role_Lst)
            //{
            //    DataRow row = DTable.NewRow();
            //    row[col1] = item.ID;
            //    row[col2] = item.Title;
            //    row[col3] = " % " + item.ValuePercent;
            //    DTable.Rows.Add(row);
            //    Percent += item.ValuePercent;
            //}

            //dgvCopyRight.DataSource = DTable;
            //dgvCopyRight.Columns[0].Width = 40;
            //dgvCopyRight.Columns[1].Width = 350;
            //dgvCopyRight.Columns[2].Width = 60;

            //lblPercent.Text = "مجموع : " + Percent.ToString() + "  درصد ";
        }

        private void AddPayment()
        {



            //Program_PaymentObj Payment = new Program_PaymentObj();
            //NewListItem Lst = (NewListItem)CmbPayment.SelectedItem;

            //Payment.Payment_Id = int.Parse(Lst.Value.ToString());
            //Payment.Program_Id = _ProgramGlobalObject.Id;
            //Payment.Sort = int.Parse(NudPaymentSort.Value.ToString());


            //List<Program_PaymentObj> Prg_Role_Lst = Program_PaymentBll.Select_Program_Payment(_ProgramGlobalObject);

            //bool Exist = false;
            //foreach (Program_PaymentObj item in Prg_Role_Lst)
            //{
            //    if (item.Sort == Payment.Sort || item.Payment_Id == Payment.Payment_Id)
            //    {
            //        Exist = true;
            //    }
            //}


            //if (!Exist)
            //{

            //    Program_PaymentBll.Insert_Program_Payment(Payment, _ProgramGlobalObject);
            //    SetPaymentGirdView();
            //}
            //else
            //{
            //    MessageBox.Show("مرحله پرداخت یا اولویت تکراری است");
            //}
        }

        private void pbAddPayment_Click(object sender, EventArgs e)
        {
            AddPayment();
            SetPaymentGirdView();
        }

        private void SetPaymentGirdView()
        {
            //DataTable DTable = new DataTable();

            //DataColumn col1 = new DataColumn("ID");
            //DataColumn col2 = new DataColumn("عنوان");
            //DataColumn col3 = new DataColumn("ترتیب");

            //DTable.Columns.Add(col1);
            //DTable.Columns.Add(col2);
            //DTable.Columns.Add(col3);

            //List<Program_PaymentObj> Prg_Role_Lst = Program_PaymentBll.Select_Program_Payment(_ProgramGlobalObject);

            //foreach (Program_PaymentObj item in Prg_Role_Lst)
            //{
            //    DataRow row = DTable.NewRow();
            //    row[col1] = item.Id;
            //    row[col2] = PaymentBll.Select_Current_Payment(item.Payment_Id).Title;
            //    row[col3] = item.Sort;
            //    DTable.Rows.Add(row);
            //}

            //dgvPayment.DataSource = DTable;
            //dgvPayment.Columns[0].Width = 40;
            //dgvPayment.Columns[1].Width = 350;
            //dgvPayment.Columns[2].Width = 60;
        }

        private void pbDeleteRole_Click(object sender, EventArgs e)
        {
            //if (dgvRoles.SelectedRows.Count > 0)
            //{
            //    Program_RoleBll.Delete_Current_Program_Role(int.Parse(dgvRoles.SelectedRows[0].Cells[0].Value.ToString()));
            //    MessageBoxEx.Show(dgvRoles.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            //}
            //SetRoleGirdView();
        }

        private void pbDeleteLocation_Click(object sender, EventArgs e)
        {
            //if (dgvLocation.SelectedRows.Count > 0)
            //{
            //    Program_LocationBll.Delete_Current_Program_Location(int.Parse(dgvLocation.SelectedRows[0].Cells[0].Value.ToString()));
            //    MessageBoxEx.Show(dgvLocation.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            //}
            //SetLocationGirdView();
        }

        private void pbDeleteCopyRight_Click(object sender, EventArgs e)
        {
            //if (dgvCopyRight.SelectedRows.Count > 0)
            //{
            //    Program_CopyRightBll.Delete_Current_Program_CopyRight(int.Parse(dgvCopyRight.SelectedRows[0].Cells[0].Value.ToString()));
            //    MessageBoxEx.Show(dgvCopyRight.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            //}
            //SetCopyRightGirdView();
        }

        private void pbDeletePayment_Click(object sender, EventArgs e)
        {
            //if (dgvPayment.SelectedRows.Count > 0)
            //{
            //    Program_PaymentBll.Delete_Current_Program_Payment(int.Parse(dgvPayment.SelectedRows[0].Cells[0].Value.ToString()));
            //    MessageBoxEx.Show(dgvPayment.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            //}
            //SetPaymentGirdView();
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.Id, "PrintProgram");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();

            //System.Diagnostics.Process.Start("iexplore",
            //    System.Configuration.ConfigurationSettings.AppSettings["WebServerAddress"] + "PrintProgram" + ".aspx?Program_Id=" + _ProgramGlobalObject.Id);
        }

        private void txtBaravordNumber_TextChanged(object sender, EventArgs e)
        {
            string text = txtBaravordNumber.Text;
            bool hasDigit = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (hasDigit)
            {
                errorProvider1.SetError(txtBaravordNumber, "لطفا فقط عدد وارد نمایید");
                txtBaravordNumber.BackColor = Color.LightPink;
            }
            else
            {
                errorProvider1.Clear();
                txtBaravordNumber.BackColor = Color.White;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLblProgramTitle_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkLstNotify2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkBoxLstStructure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChLstBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkBxLstSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CmbSigner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NudLocationTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void NudPaymentSort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvCopyRight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void NudRightPercent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRightTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void CmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void TxtPriceMinute_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void NudLatest_Delivery_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void TxtLocationName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void CmbVisa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void CmbMusic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void CmbHasArchive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkLstNotify_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void NudDubbed_ValueChanged(object sender, EventArgs e)
        {
            LblTotalPercent.Text = "جمع درصد:" + TotalPercent().ToString();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void NudLivePercent_ValueChanged(object sender, EventArgs e)
        {
            LblTotalPercent.Text = "جمع درصد:" + TotalPercent().ToString();
        }

        private void NudMonth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NudArchive_ValueChanged(object sender, EventArgs e)
        {
            LblTotalPercent.Text = "جمع درصد:" + TotalPercent().ToString();
        }

        private void NudDay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NudNew_ValueChanged(object sender, EventArgs e)
        {
            LblTotalPercent.Text = "جمع درصد:" + TotalPercent().ToString();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void NudSecond_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NudMinute_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NudHour_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NudSession_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtTitle_Farsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblBaravordNumber_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void CmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtTitle_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NudHour_Enter(object sender, EventArgs e)
        {

        }

        private void Shora_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Shora_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show("Test");
        }

        private void CmbProvider_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void pbAddProvider_Click(object sender, EventArgs e)
        {
            bool Exist = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Providers")
                {
                    f.WindowState = FormWindowState.Normal;
                    Exist = true;
                }
            }
            if (!Exist)
            {
                Providers Lvl = new Providers();
                Lvl.MdiParent = this.MdiParent;
                Lvl.Show();
            }
        }

        private void pbRefreshProvider_Click(object sender, EventArgs e)
        {
            ProviderFill();
        }

        private void TxtPriceMinute_KeyUp(object sender, KeyEventArgs e)
        {
            //int Count = TxtPriceMinute.Text.Length;
            //string Str = "";            
            //TxtPriceMinute.Mask = Str;
        }

        private void BtnPrintDep_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.BackProgId, "PrintProgram");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }
        protected float TotalPercent()
        {
            float Percent = 0;
            try
            {
                Percent += float.Parse(NudArchive.Value.ToString());
                Percent += float.Parse(NudDubbed.Value.ToString());
                Percent += float.Parse(NudLivePercent.Value.ToString());
                Percent += float.Parse(NudNew.Value.ToString());
            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.Message);
            }

            return Percent;
        }

        protected string ValidateForm()
        {
            StringBuilder Str = new StringBuilder();
            //Title Farsi
            if (TxtTitle_Farsi.Text.Trim().Length < 3)
            {
                Str.Append("عنوان فارسی باید حداقل سه کاراکتر باشد");
                Str.Append("\n");
            }

            //Provider
            if (CmbProvider.SelectedIndex < 0)
            {
                Str.Append("تهیه کننده انتخاب نشده است");
                Str.Append("\n");
            }

            //txtPriceMinute
            //if (TxtPriceMinute.Text.Trim().Length > 0)
            //{
            //    try
            //    {
            //        double Price = double.Parse(TxtPriceMinute.Text.Trim());
            //    }
            //    catch
            //    {
            //        Str.Append("فقط عدد در رقم مصوب دقیقه ای وارد نمایید");
            //        Str.Append("\n");
            //    }

            //}
            //else
            //{
            //    Str.Append("  رقم مصوب دقیقه ای را وارد نمایید");
            //    Str.Append("\n");
            //}


            //TxtBaravord
            if (_Dep == 2)
            {
                if (txtBaravordNumber.Text.Trim().Length > 0)
                {
                    try
                    {
                        double Price = double.Parse(txtBaravordNumber.Text.Trim());
                    }
                    catch
                    {
                        Str.Append("فقط عدد درشماره برآورد  وارد نمایید");
                        Str.Append("\n");
                    }

                }
                else
                {
                    Str.Append("  شماره برآورد را وارد نمایید");
                    Str.Append("\n");
                }
            }


            //2014-08-10
            if (!CheckDate(txtEditDatetime.Text))
            {
                Str.Append("  تاریخ اصلاح چک شود");
                Str.Append("\n");
            }

            //if (!CheckDate(txtFinanceDatetime.Text))
            //{
            //    Str.Append("  تاریخ مالی چک شود");
            //    Str.Append("\n");
            //}


            if (!CheckDate(txtPublish.Text))
            {
                Str.Append("  تاریخ صدور چک شود");
                Str.Append("\n");
            }

            if (!CheckDate(txtShoraDatetime.Text))
            {

                Str.Append("  تاریخ تصویب چک شود");
                Str.Append("\n");
            }


            return Str.ToString();
        }

        private void TxtPriceMinute_MouseLeave(object sender, EventArgs e)
        {
            //TxtPriceMinute.Text = TxtPriceMinute.Text.Replace(",", "");
            //try
            //{

            //    if (TxtPriceMinute.Text.Trim().Length > 2)
            //    {
            //        TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(TxtPriceMinute.Text.Replace(','.ToString(), ""))).Replace(".000", "");
            //    }

            //}
            //catch (Exception exp)
            //{

            //    // MessageBox.Show(exp.Message);
            //    MessageBox.Show("عدد وارد شده در قیمت را چک کنید");

            //}
        }

        private void TxtPriceMinute_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    TxtPriceMinute.Text = TxtPriceMinute.Text + "000";
            //    TxtPriceMinute.Text = TxtPriceMinute.Text.Replace(",", "");
            //    try
            //    {
            //        if (TxtPriceMinute.Text.Trim().Length > 2)
            //        {
            //            TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(TxtPriceMinute.Text.Replace(','.ToString(), ""))).Replace(".000", "");
            //        }
            //        TxtPriceMinute.SelectionStart = TxtPriceMinute.Text.Length;
            //    }
            //    catch (Exception exp)
            //    {

            //        MessageBox.Show("عدد وارد شده در قیمت را چک کنید");
            //    }
            //}
            //else
            //{
            //    TxtPriceMinute.Text = TxtPriceMinute.Text.Replace(",", "");
            //    try
            //    {
            //        if (TxtPriceMinute.Text.Trim().Length > 2)
            //        {
            //            TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(TxtPriceMinute.Text.Replace(','.ToString(), ""))).Replace(".000", "");
            //        }
            //        TxtPriceMinute.SelectionStart = TxtPriceMinute.Text.Length;
            //    }
            //    catch (Exception exp)
            //    {

            //        // MessageBox.Show(exp.Message);
            //        MessageBox.Show("عدد وارد شده در  قیمت را چک کنید");

            //    }
            //}
        }

        private void CmbRole_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (CmbRole.SelectedIndex == CmbRole.Items.Count - 1)
            //    {
            //        CmbRole.SelectedIndex = 0;
            //    }

            //}
        }

        private void CmbProvider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (CmbProvider.SelectedIndex == CmbProvider.Items.Count - 1)
                {
                    CmbProvider.SelectedIndex = 0;
                }
            }
        }

        private void NudSecond_Enter(object sender, EventArgs e)
        {
            NudSecond.Select(0, NudSecond.Text.Length);
        }

        private void NudMinute_Enter(object sender, EventArgs e)
        {
            NudMinute.Select(0, NudMinute.Text.Length);
        }

        private void NudMinute_MouseClick(object sender, MouseEventArgs e)
        {
            NudMinute.Select(0, NudMinute.Text.Length);
        }

        private void NudSecond_MouseClick(object sender, MouseEventArgs e)
        {
            NudSecond.Select(0, NudSecond.Text.Length);
        }

        private void NudLivePercent_Enter(object sender, EventArgs e)
        {
            NudLivePercent.Select(0, NudSecond.Text.Length);
        }

        private void NudLivePercent_MouseClick(object sender, MouseEventArgs e)
        {
            NudLivePercent.Select(0, NudLivePercent.Text.Length);
        }

        private void NudArchive_MouseClick(object sender, MouseEventArgs e)
        {
            NudArchive.Select(0, NudArchive.Text.Length);
        }

        private void NudArchive_Enter(object sender, EventArgs e)
        {
            NudArchive.Select(0, NudArchive.Text.Length);
        }

        private void NudNew_MouseClick(object sender, MouseEventArgs e)
        {
            NudNew.Select(0, NudNew.Text.Length);
        }

        private void NudNew_Enter(object sender, EventArgs e)
        {
            NudNew.Select(0, NudNew.Text.Length);
        }

        private void NudDubbed_MouseClick(object sender, MouseEventArgs e)
        {
            NudDubbed.Select(0, NudDubbed.Text.Length);
        }

        private void NudDubbed_Enter(object sender, EventArgs e)
        {
            NudDubbed.Select(0, NudDubbed.Text.Length);
        }

        private void NudSession_MouseClick(object sender, MouseEventArgs e)
        {
            NudSession.Select(0, NudSession.Text.Length);
        }

        private void NudSession_Enter(object sender, EventArgs e)
        {
            NudSession.Select(0, NudSession.Text.Length);
        }

        private void NudDay_MouseClick(object sender, MouseEventArgs e)
        {
           // NudDay.Select(0, NudDay.Text.Length);
        }

        private void NudDay_Enter(object sender, EventArgs e)
        {
           // NudDay.Select(0, NudDay.Text.Length);
        }

        private void NudMonth_MouseClick(object sender, MouseEventArgs e)
        {
           // NudMonth.Select(0, NudMonth.Text.Length);
        }

        private void NudMonth_Enter(object sender, EventArgs e)
        {
           // NudMonth.Select(0, NudMonth.Text.Length);
        }

        private void NudYear_Enter(object sender, EventArgs e)
        {
           // NudYear.Select(0, NudYear.Text.Length);
        }

        private void NudYear_MouseClick(object sender, MouseEventArgs e)
        {
          //  NudYear.Select(0, NudYear.Text.Length);

        }

        private void NudLocationTime_MouseClick(object sender, MouseEventArgs e)
        {
           // NudLocationTime.Select(0, NudLocationTime.Text.Length);
        }

        private void NudLocationTime_Enter(object sender, EventArgs e)
        {
          //  NudLocationTime.Select(0, NudLocationTime.Text.Length);
        }

        private void NudLatest_Delivery_MouseClick(object sender, MouseEventArgs e)
        {
           // NudLatest_Delivery.Select(0, NudLatest_Delivery.Text.Length);
        }

        private void NudLatest_Delivery_Enter(object sender, EventArgs e)
        {
          //  NudLatest_Delivery.Select(0, NudLatest_Delivery.Text.Length);
        }

        private void NudRightPercent_MouseClick(object sender, MouseEventArgs e)
        {
           // NudRightPercent.Select(0, NudRightPercent.Text.Length);
        }

        private void NudRightPercent_Enter(object sender, EventArgs e)
        {
          //  NudRightPercent.Select(0, NudRightPercent.Text.Length);
        }

        private void NudPaymentSort_Enter(object sender, EventArgs e)
        {
           // NudPaymentSort.Select(0, NudPaymentSort.Text.Length);
        }

        private void NudPaymentSort_MouseClick(object sender, MouseEventArgs e)
        {
           // NudPaymentSort.Select(0, NudPaymentSort.Text.Length);
        }

        private void CmbPayment_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (CmbPayment.SelectedIndex == CmbPayment.Items.Count - 1)
            //    {
            //        CmbPayment.SelectedIndex = 0;
            //    }
            //}
        }

        //private void UpdateObjectFromDataBasePl()
        //{
        //    ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);
        //    _ProgramGlobalObject = Obj;
        //}

        private void UpdateFormByObjectPl()
        {
            if (_ProgramGlobalObject.Id > 0)
            {
                txtEditDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Edit);
              //  txtFinanceDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Finance);
                txtPublish.Text = DateConversion.GD2JD(_ProgramGlobalObject.Datetime_Publish);
                txtShoraDatetime.Text = DateConversion.GD2JD(_ProgramGlobalObject.Act_DateTime);
                toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;
            }
            else
            {
                txtEditDatetime.Text = DateConversion.GD2JD(GetDate.GetDateTime());
             //   txtFinanceDatetime.Text = DateConversion.GD2JD(GetDate.GetDateTime());
                txtPublish.Text = DateConversion.GD2JD(GetDate.GetDateTime());
                txtShoraDatetime.Text = DateConversion.GD2JD(GetDate.GetDateTime());
            }


            try
            {
                chkIsCheckedOut.Checked = _ProgramGlobalObject.IsCheckedOut;
            }
            catch
            {

            }



            if (_ProgramGlobalObject.Program_Kind == "1")
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendToBacks("Form2");
            Form2 Frm = new Form2(_ProgramGlobalObject.Id, "Printcost");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SendToBacks("Form2");
            Form2 Frm = new Form2(_ProgramGlobalObject.Id, "Printcostinfo");
            Frm.TopMost = true;
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
            Frm.BringToFront();
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
    }
}