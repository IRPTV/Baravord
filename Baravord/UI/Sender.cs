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

namespace Baravord.UI
{
    public partial class Sender : Form
    {
        int _Dest;
        ProgramObj _ProgramGlobalObject = new ProgramObj();
        public Sender(int Dest, int ProgramId)
        {
            _Dest = Dest;
            _ProgramGlobalObject.Id = ProgramId;
            InitializeComponent();
        }

        private void Sender_Load(object sender, EventArgs e)
        {
            switch (_Dest)
            {
                case 2:
                    this.Text = "ارسال به واحد اطلاعات و برنامه ریزی";
                    break;
                default:
                    break;
            }

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
            LblTitle.Text = _ProgramGlobalObject.Title_Farsi;
            LblActDate.Text = DateConversion.GD2JD(_ProgramGlobalObject.Act_DateTime) + " " +
                    _ProgramGlobalObject.Act_DateTime.Hour.ToString() + ":" +
                    _ProgramGlobalObject.Act_DateTime.Minute.ToString();
            LblRcvDate.Text = DateConversion.GD2JD(_ProgramGlobalObject.RcvDate) + " " +
                    _ProgramGlobalObject.RcvDate.Hour.ToString() + ":" +
                    _ProgramGlobalObject.RcvDate.Minute.ToString();


            List<ProgramObj> ProgLst = ProgramBll.Search_Prgrams("Select * From program where dep=" +
                  _Dest.ToString() + " and BackProgId=" + _ProgramGlobalObject.Id + " ");

            if (ProgLst.Count > 0)
            {
                LblSendDate.Text = DateConversion.GD2JD(_ProgramGlobalObject.SendDate) + " " +
                    _ProgramGlobalObject.SendDate.Hour.ToString() + ":" +
                    _ProgramGlobalObject.SendDate.Minute.ToString();
            }
            else
            {
                LblSendDate.Text = " این برنامه تا کنون ارسال نشده است";
            }
        }

        private void pbSend_Click(object sender, EventArgs e)
        {
            List<ProgramObj> ProgLst = ProgramBll.Search_Prgrams("Select * From program where dep=" +
                   _Dest.ToString() + " and BackProgId=" + _ProgramGlobalObject.Id + " ");


            if (ProgLst.Count > 0)
            {
                MessageBox.Show("این برنامه قبلا در تاریخ " + DateConversion.GD2JD(ProgLst[0].SendDate) + " ارسال شده است ");

            }
            else
            {
                ProgramObj ObjUpdate = new ProgramObj();
                ObjUpdate = _ProgramGlobalObject;
                ObjUpdate.SendDate = Baravord.TOOLS.GetDate.GetDateTime();
                ProgramBll.Update_Program(ObjUpdate);

                ProgramObj Obj22 = new ProgramObj();
                Obj22 = _ProgramGlobalObject;
                Obj22.RcvDate = Baravord.TOOLS.GetDate.GetDateTime();
                Obj22.SendDate = Baravord.TOOLS.GetDate.GetDateTime();
                Obj22.Dep = _Dest;
                Obj22.BackProgId = _ProgramGlobalObject.Id;
                ProgramObj RetProgObject = ProgramBll.Insert_Prgram(Obj22);




                //Copy Details:

                //Copy Right
                List<Program_CopyRightObj> Right_Lst =
                    Program_CopyRightBll.Select_Program_CopyRight(_ProgramGlobalObject);

                foreach (Program_CopyRightObj item in Right_Lst)
                {
                    item.Program_Id = RetProgObject.Id;
                    Program_CopyRightBll.Insert_Program_CopyRight(item, RetProgObject);
                }

                //Level
                List<LevelObj> Level_Lst =
                    LevelBll.Select_All_Program_Levels(_ProgramGlobalObject);
                LevelBll.Insert_Program_Level(Level_Lst, RetProgObject);

                //Location

                List<Program_LocationObj> Location_Lst =
                    Program_LocationBll.Select_Program_Location(_ProgramGlobalObject);

                foreach (Program_LocationObj item in Location_Lst)
                {
                    item.Program_Id = RetProgObject.Id;
                    Program_LocationBll.Insert_Program_Location(item, RetProgObject);
                }



                //Payment
                List<Program_PaymentObj> Payment_Lst =
                    Program_PaymentBll.Select_Program_Payment(_ProgramGlobalObject);
                foreach (Program_PaymentObj item in Payment_Lst)
                {
                    item.Program_Id = RetProgObject.Id;
                    Program_PaymentBll.Insert_Program_Payment(item, RetProgObject);
                }

                //Role
                List<Program_RoleObj> Role_Lst =
                     Program_RoleBll.Select_Program_All_Roles(_ProgramGlobalObject);
                foreach (Program_RoleObj item in Role_Lst)
                {
                    item.Program_Id = RetProgObject.Id;
                    Program_RoleBll.Insert_Program_Role(item, RetProgObject);
                }


                //Session
                List<Program_SessionObj> Session_Lst =
                     Program_SessionBll.Select_Program_Session(_ProgramGlobalObject);
                foreach (Program_SessionObj item in Session_Lst)
                {
                    item.Program_Id = RetProgObject.Id;
                    Program_SessionBll.Insert_Program_Session(item);
                }


                //Session
                List<StructureObj> Struct_Lst =
                     StructureBll.Select_Program_Structs(_ProgramGlobalObject);
                StructureBll.Insert_Program_Struct(Struct_Lst, RetProgObject);


                //Target
                List<TargetObj> Target_Lst =
                     TargetBll.Select_All_Program_Target(_ProgramGlobalObject);
                TargetBll.Insert_Program_Target(Target_Lst, RetProgObject);

                //Notify
                List<NotifyObj> Notify_Lst =
                    NotifyBll.Select_Program_Notify(_ProgramGlobalObject);

                NotifyBll.Insert_Program_Notify(Notify_Lst, RetProgObject);

                //
                try
                {
                    OutIranObj OutIran =
                   OutIranBll.Select_OutIran(_ProgramGlobalObject);

                    if (OutIran.Id>2)
                    {
                        OutIran.Program_Id = RetProgObject.Id;
                        OutIranBll.Insert_OutIran(OutIran);
                    }
                }
                catch
                {
                    
                  
                }
               


                 //Subject
                List<SubjectObj> Subject_Lst =
                    SubjectBll.Select_Program_Subject(_ProgramGlobalObject);

                SubjectBll.Insert_Program_Subject(Subject_Lst, RetProgObject);
            }
            UpdateObjectFromDataBase();
            UpdateFormByObject();

        }

    }
}
