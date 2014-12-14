using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class TargetBll
    {
        public static List<TargetObj> Select_All_Targets()
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Select_All_Targets();
        }
        public static bool Insert_Program_Target(List<TargetObj> InLst, ProgramObj ProgObjInput)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Insert_Program_Target(InLst, ProgObjInput);
        }
        public static List<TargetObj> Select_All_Program_Target(ProgramObj Prog)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Select_All_Program_Target(Prog);
        }
        public static TargetObj Select_Current_Target(TargetObj Targ)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Select_Current_Target(Targ);
        }
        public static bool Update_Target_Base(TargetObj Targ)
        {
             TargetDal Tar_Dal = new TargetDal();
             return Tar_Dal.Update_Target_Base(Targ);
        }
        public static bool Insert_Target_Base(TargetObj Targ)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Insert_Target_Base(Targ);
        }
        public static List<string[]> Select_TargetById(int Target_Id)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Select_TargetById(Target_Id);
        }
        public static bool Delete_Target(int Target_Id)
        {
            TargetDal Tar_Dal = new TargetDal();
            return Tar_Dal.Delete_Target(Target_Id);
        }
    }
}
