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
    public partial class Shenasname : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();

        public Shenasname(int ProgramId)
        {
            _ProgramGlobalObject.Id = ProgramId;
            InitializeComponent();
        }

        private void Shenasname_Load(object sender, EventArgs e)
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

           

            //Fill Combo Box Roles and Costs
            RoleFill();


           

            //Fill Notification to Check List Box
            NotifyFill();

            //Fill Languages to Combo Box
            LanguageFill();

            //Fill Providers to Combo Box
            ProviderFill();


            TargetFill();

            PlanStepFill();



            #endregion

            #region FillDataForProgram
            if (_ProgramGlobalObject.Id.Equals(0))
            {
                toolStripLblProgramTitle.Text = "ورود اطلاعات مصوبه برنامه جدید";

                //Insert New Programme And Save ID
                ProgramObj RetProgObject = ProgramBll.Insert_Prgram(_ProgramGlobalObject);
                _ProgramGlobalObject = RetProgObject;

                BtnPrintDep.Visible = false;

            }
            else
            {
                UpdateObjectFromDataBase();
                UpdateFormByObject();

                SetBaravordNumber();
                SetStructure();
                SetLevels();
                SetSubjects();
                SetNotify();
                SetRoleGirdView();
                SetLocationGirdView();
                SetCopyRightGirdView();
                SetTargets();
                SetdgvSessionView();
                SetOutIran();
                SetProvider();



                if (_ProgramGlobalObject.BackProgId == 0)
                {
                    BtnPrintDep.Visible = false;
                }


            }
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

        private void SetProvider()
        {
          
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
           
        }

        public void PlanStepFill()
        {
            List<PlanStepObj> Pln_Lst = PlanStepBll.Select_All_PlanStep();

            cmbPlanStep.Items.Clear();

            foreach (PlanStepObj item in Pln_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;
                cmbPlanStep.Items.Add(Lst);
            }
            cmbPlanStep.SelectedIndex = 0;
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
            if (TotalPercent() > 100)
            {
                MessageBox.Show("جمع درصد ساخت بیش از 100 درصد است");
            }
            else
            {
                if (ValidateForm().Length < 5)
                {
                    //Update Record In DB
                    UpdateObjectForDataBase();
                    ProgramBll.Update_Program(_ProgramGlobalObject);


                    //Insert And Update  Structure for current program
                    SaveStructure();


                    //Insert And Update  Structure for current program
                    SaveLevels();


                    //Insert And Update  Structure for current program
                    SaveSubjects();


                    //Insert And Update  Notify for current program
                    SaveNotify();


                    //Update form title for program Title
                    toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;


                    SaveTarget();

                    SaveOutIran();


                    //Set Golbal Programe in Main Form
                    GlobalObjectTools.SetGlobalProgramObject(_ProgramGlobalObject);

                    MessageBoxEx.Show("با موفقیت ذخیره شد", "برآورد", 500);
                }
                else
                {
                    MessageBox.Show(ValidateForm(), "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void UpdateObjectForDataBase()
        {

            ProgramObj Obj = ProgramBll.Select_Program(_ProgramGlobalObject);

            _ProgramGlobalObject = Obj;

            _ProgramGlobalObject.Title_Farsi = TxtTitle_Farsi.Text;
            _ProgramGlobalObject.Title_2 = TxtTitle_2.Text;

            _ProgramGlobalObject.Latest_Delivery = int.Parse(NudLatest_Delivery.Value.ToString());
            _ProgramGlobalObject.Percent_Archive = float.Parse(NudArchive.Value.ToString());
            _ProgramGlobalObject.Percent_Dubbed = float.Parse(NudDubbed.Value.ToString());
            _ProgramGlobalObject.Percent_Live = float.Parse(NudLivePercent.Value.ToString());
            _ProgramGlobalObject.Percent_New = float.Parse(NudNew.Value.ToString());
            _ProgramGlobalObject.Session = int.Parse(NudSession.Value.ToString());
            _ProgramGlobalObject.ChannelId = int.Parse(((NewListItem)CmbChannel.SelectedItem).Value.ToString());
            _ProgramGlobalObject.Provider_Id = int.Parse(((NewListItem)CmbProvider.SelectedItem).Value.ToString());
          
            _ProgramGlobalObject.Session_Time = NudHour.Value.ToString("00") + ":" + NudMinute.Value.ToString("00") + ":" + NudSecond.Value.ToString("00");

            _ProgramGlobalObject.Director_Name = txtDirector.Text;
            _ProgramGlobalObject.Writer_Name = txtWriter.Text;
            _ProgramGlobalObject.Description = txtDescription.Text;

            _ProgramGlobalObject.Viewers = txtViewers.Text;
            _ProgramGlobalObject.PlanStep = int.Parse(((NewListItem)cmbPlanStep.SelectedItem).Value.ToString());



            _ProgramGlobalObject.Price_Minute = TxtPriceMinute.Text.Replace(",", "").Trim();
          
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
            TxtTitle_2.Text = _ProgramGlobalObject.Title_2;
            TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(_ProgramGlobalObject.Price_Minute)).Replace(".000", "");
            txtWriter.Text = _ProgramGlobalObject.Writer_Name;
            txtDirector.Text = _ProgramGlobalObject.Director_Name;

            string[] TimeCodes = ToolsFunctions.SplitTimeCode(_ProgramGlobalObject.Session_Time);
            NudSecond.Value = decimal.Parse(TimeCodes[2].ToString());
            NudMinute.Value = decimal.Parse(TimeCodes[1].ToString());
            NudHour.Value = decimal.Parse(TimeCodes[0].ToString());

            NudLatest_Delivery.Value = decimal.Parse(_ProgramGlobalObject.Latest_Delivery.ToString());

            NudSession.Value = decimal.Parse(_ProgramGlobalObject.Session.ToString());

            cmbSession.Items.Clear();
            for (int i = 0; i < NudSession.Value; i++)
            {
                NewListItem Ses = new NewListItem();
                Ses.Text = (i+1).ToString();
                Ses.Value = i+1;

                cmbSession.Items.Add(Ses);
            }

            if (cmbSession.Items.Count > 0)
            {
                cmbSession.SelectedIndex = 0;
            }


            txtDescription.Text = _ProgramGlobalObject.Description;

            NudNew.Value = decimal.Parse(_ProgramGlobalObject.Percent_New.ToString());
            NudArchive.Value = decimal.Parse(_ProgramGlobalObject.Percent_Archive.ToString());
            NudDubbed.Value = decimal.Parse(_ProgramGlobalObject.Percent_Dubbed.ToString());
            NudLivePercent.Value = decimal.Parse(_ProgramGlobalObject.Percent_Live.ToString());

           // NudDay.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[2]);
           // NudMonth.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[1]);
          //  NudYear.Value = decimal.Parse(ToolsFunctions.CovertSplitDateToShamsi(_ProgramGlobalObject.Act_DateTime)[0]);

            toolStripLblProgramTitle.Text = _ProgramGlobalObject.Title_Farsi;
            txtViewers.Text = _ProgramGlobalObject.Viewers;

            ///Set PLAN STEP Cobo Items
            for (int i = 0; i < cmbPlanStep.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)cmbPlanStep.Items[i];

                if (Ch.Value.ToString() == _ProgramGlobalObject.PlanStep.ToString())
                {
                    cmbPlanStep.SelectedIndex = i;
                }
            }


            //Set Language Cobo Items
            for (int i = 0; i < cmbLanguage.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)cmbLanguage.Items[i];

                if (Ch.Value.ToString() == _ProgramGlobalObject.LanguageId.ToString())
                {
                    cmbLanguage.SelectedIndex = i;
                }
            }


            //





            //Set CmbCHANNEL Items
            for (int i = 0; i < CmbChannel.Items.Count; i++)
            {
                NewListItem Ch = (NewListItem)CmbChannel.Items[i];

                if (Ch.Value.ToString() == _ProgramGlobalObject.ChannelId.ToString())
                {
                    CmbChannel.SelectedIndex = i;
                }

            }


            for (int i = 0; i < CmbProvider.Items.Count; i++)
            {

                NewListItem LstChk = (NewListItem)CmbProvider.Items[i];

                if (LstChk.Value.ToString() == _ProgramGlobalObject.Provider_Id.ToString())
                {
                    CmbProvider.SelectedIndex = i;
                }
            }

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

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBaravordNumber();
        }

        private void SetBaravordNumber()
        {
            //NewListItem Selected = (NewListItem)CmbChannel.SelectedItem;
            //lblBaravordNumber.Text =
            //    ToolsFunctions.GenerateBaravordCode(NudYear.Value.ToString(),
            //    int.Parse(Selected.Value.ToString()));
        }

        private void NudYear_ValueChanged(object sender, EventArgs e)
        {
            SetBaravordNumber();
        }

        private void SetStructure()
        {
           
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
            groupBox4.Text = "هدف " + "( " + Count.ToString() + " مورد )";
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

            groupBox2.Text = "موضوع " + "( " + Count.ToString() + " مورد )";
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

            groupBox6.Text = "توجه " + "( " + Count.ToString() + " مورد )";
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
            groupBox17.Text = "توضیحات " + "( " + Count.ToString() + " مورد )";
        }      

        private void pbAddLocation_Click(object sender, EventArgs e)
        {
            AddLocation();

        }

        private void AddLocation()
        {
            if (TxtLocationName.Text.Trim().Length > 2)
            {
                Program_LocationObj Location = new Program_LocationObj();
                Location.DURATION = int.Parse(NudLocationTime.Value.ToString());
                Location.Program_Id = _ProgramGlobalObject.Id;
                Location.TITLE = TxtLocationName.Text.Trim();

                Program_LocationBll.Insert_Program_Location(Location, _ProgramGlobalObject);

                SetLocationGirdView();
                TxtLocationName.Text = "";
            }
            else
            {
                MessageBox.Show("عنوان لوکیشن باید حداقل سه کاراکتر باشد");
            }
        }

        private void SetLocationGirdView()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("لوکیشن");
            DataColumn col3 = new DataColumn("زمان");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);

            List<Program_LocationObj> Prg_Role_Lst = Program_LocationBll.Select_Program_Location(_ProgramGlobalObject);

            int Days = 0;


            foreach (Program_LocationObj item in Prg_Role_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.TITLE;
                row[col3] = item.DURATION + " روز ";
                DTable.Rows.Add(row);

                Days += item.DURATION;
            }

            dgvLocation.DataSource = DTable;
            dgvLocation.Columns[0].Width = 40;
            dgvLocation.Columns[1].Width = 350;
            dgvLocation.Columns[2].Width = 60;


            lblTotatDays.Text = "مجموع: " + Days + " روز ";
        }

        private void pbAddRight_Click(object sender, EventArgs e)
        {
            AddCopyRight();
        }

        private void AddCopyRight()
        {
            if (txtRightTitle.Text.Trim().Length >2)
            {
                Program_CopyRightObj Right = new Program_CopyRightObj();
                Right.Title = txtRightTitle.Text;
                Right.Program_Id = _ProgramGlobalObject.Id;
                Right.ValuePercent = int.Parse(NudRightPercent.Value.ToString());

                int Percent = 0;
                bool Exist = false;
                List<Program_CopyRightObj> Prg_Role_Lst = Program_CopyRightBll.Select_Program_CopyRight(_ProgramGlobalObject);

                foreach (Program_CopyRightObj item in Prg_Role_Lst)
                {
                    Percent += item.ValuePercent;
                    if (Right.Title == item.Title)
                    {
                        MessageBox.Show("عنوان تکراری برای مالکیت وارد شده است", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                if (Percent + int.Parse(NudRightPercent.Value.ToString()) <= 100)
                {


                    Program_CopyRightBll.Insert_Program_CopyRight(Right, _ProgramGlobalObject);

                    SetCopyRightGirdView();
                    txtRightTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("جمع کل از صد درصد بیشتر می شود", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("عنوان مشارکت باید حداقل سه کاراکتر باشد");
            }
        }

        private void SetCopyRightGirdView()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("عنوان");
            DataColumn col3 = new DataColumn("درصد");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);

            List<Program_CopyRightObj> Prg_Role_Lst = Program_CopyRightBll.Select_Program_CopyRight(_ProgramGlobalObject);

            int Percent = 0;

            foreach (Program_CopyRightObj item in Prg_Role_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.Title;
                row[col3] = " % " + item.ValuePercent;
                DTable.Rows.Add(row);
                Percent += item.ValuePercent;
            }

            dgvCopyRight.DataSource = DTable;
            dgvCopyRight.Columns[0].Width = 40;
            dgvCopyRight.Columns[1].Width = 350;
            dgvCopyRight.Columns[2].Width = 60;

            lblPercent.Text = "مجموع : " + Percent.ToString() + "  درصد ";
        }                 

        private void pbDeleteLocation_Click(object sender, EventArgs e)
        {
            if (dgvLocation.SelectedRows.Count > 0)
            {
                Program_LocationBll.Delete_Current_Program_Location(int.Parse(dgvLocation.SelectedRows[0].Cells[0].Value.ToString()));
              //  MessageBoxEx.Show(dgvLocation.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            }
            SetLocationGirdView();
        }

        private void pbDeleteCopyRight_Click(object sender, EventArgs e)
        {
            if (dgvCopyRight.SelectedRows.Count > 0)
            {
                Program_CopyRightBll.Delete_Current_Program_CopyRight(int.Parse(dgvCopyRight.SelectedRows[0].Cells[0].Value.ToString()));
               // MessageBoxEx.Show(dgvCopyRight.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            }
            SetCopyRightGirdView();
        }

        public void AddRole()
        {
           


            try
            {
                NewListItem Lst = (NewListItem)CmbRole.SelectedItem;

                Program_RoleObj Obj = new Program_RoleObj();
                Obj.Role_Id = int.Parse(Lst.Value.ToString());
                Obj.Price_Unit = "0";
                Obj.Id = 1;
                Obj.Time = "1";
                Obj.Count = 1;
                Obj.Unit = 1;
                Obj.Description = "";



                Program_RoleBll.Insert_Program_Role(Obj, _ProgramGlobalObject);
                SetRoleGirdView();
            }
            catch
            {

                MessageBox.Show("این کد در سیستم موجود نیست به مدیر سیستم اطلاع دهید");
            }
        }

        private void pbAddRole_Click(object sender, EventArgs e)
        {
            AddRole();
        }

        private void SetRoleGirdView()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("عنوان");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);

            List<Program_RoleObj> Prg_Role_Lst = Program_RoleBll.Select_Program_All_Roles(_ProgramGlobalObject);

            foreach (Program_RoleObj item in Prg_Role_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;
                RoleObj RlObj = new RoleObj();
                RlObj.Id = item.Role_Id;
                row[col2] = RoleBll.Select_Current_Role(RlObj).Title;
                DTable.Rows.Add(row);
            }

            dgvRoles.DataSource = DTable;
            dgvRoles.Columns[0].Width = 60;
            dgvRoles.Columns[1].Width = 370;
        }

        private void rbTolidi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTolidi.Checked)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void rbLiveRec_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLiveRec.Checked)
            {
                tabControl1.SelectedIndex = 2;
            }
        }

        private void rbLive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLive.Checked)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: rbTolidi.Checked = true;
                    break;

                case 1: rbLive.Checked = true;
                    break;

                case 2: rbLiveRec.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            if (txtSessionTitle.Text.Trim().Length > 2)
            {
                Program_SessionObj S_Obj = new Program_SessionObj();
                S_Obj.Description_Content = txtDescription_Content.Text;
                S_Obj.Description_Structure = txtDescription_Structure.Text;
                S_Obj.Program_Id = _ProgramGlobalObject.Id;
                S_Obj.SessionNum = int.Parse(((NewListItem)cmbSession.SelectedItem).Value.ToString());
                S_Obj.Title = txtSessionTitle.Text;



                bool Exist = false;
                List<Program_SessionObj> Prg_Session_Lst = Program_SessionBll.Select_Program_Session(_ProgramGlobalObject);

                foreach (Program_SessionObj item in Prg_Session_Lst)
                {
                    if (item.SessionNum == S_Obj.SessionNum)
                    {
                        Exist = true;
                    }

                }
                if (!Exist)
                {
                    Program_SessionBll.Insert_Program_Session(S_Obj);

                    SetdgvSessionView();



                    txtSessionTitle.Text = "";
                    txtDescription_Content.Text = "";
                    txtDescription_Structure.Text = "";
                }
                else
                {
                    MessageBox.Show("این قسمت تکراری است");
                }
            }
            else
            {
                MessageBox.Show("عنوان قسمت انتخاب شده باید حداقل سه کاراکتر باشد");
            }
        }

        private void pbDeleteSession_Click(object sender, EventArgs e)
        {
            if (dgvSession.SelectedRows.Count > 0)
            {
                Program_SessionBll.Delete_Current_Program_Session(int.Parse(dgvSession.SelectedRows[0].Cells[0].Value.ToString()));
                //MessageBoxEx.Show(dgvSession.SelectedRows[0].Cells[2].Value.ToString() + " حذف شد", "حذف توضیح قسمت", 500);
            }
            SetdgvSessionView();
        }
        private void SetdgvSessionView()
        {
            DataTable DTable = new DataTable();


            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("قسمت");
            DataColumn col3 = new DataColumn("عنوان");
            DataColumn col4 = new DataColumn("محتوا");
            DataColumn col5 = new DataColumn("ساختار");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);


            List<Program_SessionObj> Prg_Session_Lst = Program_SessionBll.Select_Program_Session(_ProgramGlobalObject);

            foreach (Program_SessionObj item in Prg_Session_Lst)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.Id;
                row[col2] = item.SessionNum;
                row[col3] =item.Title;
                row[col4] =item.Description_Content;
                row[col5] = item.Description_Structure;
                DTable.Rows.Add(row);
            }

            dgvSession.DataSource = DTable;
            dgvSession.Columns[0].Width = 60;
            dgvSession.Columns[1].Width = 60;            
        }
     
       

        private void pbDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                Program_RoleBll.Delete_Current_Program_Role(int.Parse(dgvRoles.SelectedRows[0].Cells[0].Value.ToString()));
                MessageBoxEx.Show(dgvRoles.SelectedRows[0].Cells[1].Value.ToString() + " حذف شد", "حذف عوامل", 500);
            }
            SetRoleGirdView();
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.Id, "PrintShenasname");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }
        protected void SaveOutIran()
        {
            //OutIran
            OutIranObj OIran = new OutIranObj();
           
            OIran.Phone_Number = txtPhone.Text;
            OIran.CellPhone_number = txtCell.Text;
            OIran.Fax_Number = txtFax.Text;
            OIran.Group_Address = txtGroup_Address.Text;
            OIran.Language = (radioButton11.Checked) ? true : false;
            OIran.Office = (radioButton13.Checked) ? true : false;
            OIran.Reporter_Credential = (radioButton17.Checked) ? true : false;
            OIran.Sponser = (radioButton15.Checked) ? true : false;
            OIran.Visa_IsHave = (radioButton4.Checked) ? true : false;
            OIran.Visa_Expire = txtVisaExpire.Text;
            OIran.Program_Id = _ProgramGlobalObject.Id;
            OIran.Visa_CanGet = (radioButton9.Checked) ? true : false;
            if (radioButton11.Checked || radioButton13.Checked || radioButton17.Checked || radioButton15.Checked ||
                radioButton4.Checked || radioButton9.Checked)
            {

                OutIranBll.Insert_OutIran(OIran);
            }
            else
            {
                OutIranBll.Delete_OutIran(_ProgramGlobalObject.Id);
            }
        }
        protected void SetOutIran()
        {
            OutIranObj Obj=  OutIranBll.Select_OutIran(_ProgramGlobalObject);

            txtPhone.Text = Obj.Phone_Number;
            txtCell.Text = Obj.CellPhone_number;
            txtFax.Text = Obj.Fax_Number;
            txtGroup_Address.Text = Obj.Group_Address;

            if (Obj.Language)
            {
                radioButton11.Checked = true;
            }
            else
            {
                radioButton10.Checked = true;
            }

            if (Obj.Office)
            {
                radioButton13.Checked = true;
            }
            else
            {
                radioButton12.Checked = true;
            }



            if (Obj.Reporter_Credential)
            {
                radioButton17.Checked = true;
            }
            else
            {
                radioButton16.Checked = true;
            }


            if (Obj.Sponser)
            {
                radioButton15.Checked = true;
            }
            else
            {
                radioButton14.Checked = true;
            }

            if (Obj.Visa_IsHave)
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton5.Checked = true;
            }

            if (Obj.Visa_CanGet)
            {
                radioButton9.Checked = true;
            }
            else
            {
                radioButton8.Checked = true;
            }



            txtVisaExpire.Text = Obj.Visa_Expire;

        }

        private void BtnPrintDep_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2(_ProgramGlobalObject.BackProgId, "PrintShenasname");
            Frm.MdiParent = this.MdiParent;
            Frm.Show();
        }

        private void NudDubbed_ValueChanged(object sender, EventArgs e)
        {
            LblTotalPercent.Text = "جمع درصد:" + TotalPercent().ToString();
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

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dgvCopyRight_DoubleClick(object sender, EventArgs e)
        {
          

        }

        private void dgvSession_DoubleClick(object sender, EventArgs e)
        {
            pbAddSession.Visible = false;
            pbUpdateSession.Visible = true;
            Program_SessionObj Obj =
              Program_SessionBll.Select_Current_Session(
              int.Parse(dgvSession.SelectedRows[0].Cells[0].Value.ToString()));


            txtSessionTitle.Text = Obj.Title;
            txtDescription_Content.Text = Obj.Description_Content;
            txtDescription_Structure.Text = Obj.Description_Structure;

            for (int i = 0; i < cmbSession.Items.Count; i++)
            {
                NewListItem Lst = (NewListItem)cmbSession.Items[i];
                if (Lst.Text == Obj.SessionNum.ToString())
                {
                    cmbSession.SelectedIndex = i;
                }
            }
        }

        private void pbUpdateSession_Click(object sender, EventArgs e)
        {

            Program_SessionObj S_Obj = new Program_SessionObj();
            S_Obj.Description_Content = txtDescription_Content.Text;
            S_Obj.Description_Structure = txtDescription_Structure.Text;
            S_Obj.Program_Id = _ProgramGlobalObject.Id;
            S_Obj.SessionNum = int.Parse(((NewListItem)cmbSession.SelectedItem).Value.ToString());
            S_Obj.Title = txtSessionTitle.Text;
            S_Obj.Id = int.Parse(dgvSession.SelectedRows[0].Cells[0].Value.ToString());

            Program_SessionBll.Update_PROGRAM_Session(S_Obj);
            SetdgvSessionView();

            pbAddSession.Visible = true;
            pbUpdateSession.Visible = false;
            txtSessionTitle.Text = "";
            txtDescription_Content.Text = "";
            txtDescription_Structure.Text = "";
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
            if (TxtPriceMinute.Text.Trim().Length > 0)
            {
                try
                {
                    double Price = double.Parse(TxtPriceMinute.Text.Trim());
                }
                catch
                {
                    Str.Append("فقط عدد در رقم مصوب دقیقه ای وارد نمایید");
                    Str.Append("\n");
                }

            }
            else
            {
                Str.Append("  رقم مصوب دقیقه ای را وارد نمایید");
                Str.Append("\n");
            }


           




            return Str.ToString();
        }

        private void TxtPriceMinute_MouseLeave(object sender, EventArgs e)
        {
            TxtPriceMinute.Text = TxtPriceMinute.Text.Replace(",", "");
            try
            {

                if (TxtPriceMinute.Text.Trim().Length > 2)
                {
                    TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(TxtPriceMinute.Text.Replace(','.ToString(), ""))).Replace(".000", "");
                }

            }
            catch (Exception exp)
            {

                // MessageBox.Show(exp.Message);
                MessageBox.Show("عدد وارد شده در حق الزحمه را چک کنید");

            }
        }

        private void TxtPriceMinute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                TxtPriceMinute.Text = TxtPriceMinute.Text + "000";
                TxtPriceMinute.Text = TxtPriceMinute.Text.Replace(",", "");
                try
                {

                    if (TxtPriceMinute.Text.Trim().Length > 2)
                    {
                        TxtPriceMinute.Text = string.Format("{0:n3}", double.Parse(TxtPriceMinute.Text.Replace(','.ToString(), ""))).Replace(".000", "");
                    }

                }
                catch (Exception exp)
                {

                    MessageBox.Show("عدد وارد شده در حق الزحمه را چک کنید");
                }
            }
        }

        private void CmbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (CmbRole.SelectedIndex == CmbRole.Items.Count - 1)
                {
                    CmbRole.SelectedIndex = 0;
                }
               
            }

            
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

        private void NudSecond_MouseClick(object sender, MouseEventArgs e)
        {
            NudSecond.Select(0, NudSecond.Text.Length);
        }

        private void NudMinute_MouseClick(object sender, MouseEventArgs e)
        {
            NudMinute.Select(0, NudMinute.Text.Length);
        }

        private void NudHour_MouseClick(object sender, MouseEventArgs e)
        {
            NudHour.Select(0, NudHour.Text.Length);
        }

        private void NudSecond_Enter(object sender, EventArgs e)
        {
            NudSecond.Select(0, NudSecond.Text.Length);
        }

        private void NudMinute_Enter(object sender, EventArgs e)
        {
            NudMinute.Select(0, NudMinute.Text.Length);
        }

        private void NudHour_Enter(object sender, EventArgs e)
        {
            NudHour.Select(0, NudHour.Text.Length);
        }

        private void NudSession_Enter(object sender, EventArgs e)
        {
            NudSession.Select(0, NudHour.Text.Length);
        }

        private void NudSession_MouseClick(object sender, MouseEventArgs e)
        {
            NudSession.Select(0, NudHour.Text.Length);
        }

        private void NudLivePercent_MouseClick(object sender, MouseEventArgs e)
        {
            NudLivePercent.Select(0, NudLivePercent.Text.Length);
        }

        private void NudLivePercent_Enter(object sender, EventArgs e)
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

        private void NudNew_Enter(object sender, EventArgs e)
        {
            NudNew.Select(0, NudNew.Text.Length);
        }

        private void NudNew_MouseClick(object sender, MouseEventArgs e)
        {
            NudNew.Select(0, NudNew.Text.Length);
        }

        private void NudDubbed_Enter(object sender, EventArgs e)
        {
            NudDubbed.Select(0, NudDubbed.Text.Length);
        }

        private void NudDubbed_MouseClick(object sender, MouseEventArgs e)
        {
            NudDubbed.Select(0, NudDubbed.Text.Length);
        }

        private void NudRightPercent_MouseClick(object sender, MouseEventArgs e)
        {
            NudRightPercent.Select(0, NudRightPercent.Text.Length);
        }

        private void NudRightPercent_Enter(object sender, EventArgs e)
        {
            NudRightPercent.Select(0, NudRightPercent.Text.Length);
        }

        private void NudLocationTime_MouseClick(object sender, MouseEventArgs e)
        {
            NudLocationTime.Select(0, NudLocationTime.Text.Length);
        }

        private void NudLocationTime_Enter(object sender, EventArgs e)
        {
            NudLocationTime.Select(0, NudLocationTime.Text.Length);
        }

        private void NudLatest_Delivery_MouseClick(object sender, MouseEventArgs e)
        {
            NudLatest_Delivery.Select(0, NudLatest_Delivery.Text.Length);
        }

        private void NudLatest_Delivery_Enter(object sender, EventArgs e)
        {
            NudLatest_Delivery.Select(0, NudLatest_Delivery.Text.Length);
        }
       
    }
}