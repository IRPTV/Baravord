using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class NotifyBll
    {
        public List<NotifyObj> Select_All_Notify(int Kind)
        {
            NotifyDal Not_Dal = new NotifyDal();
            List<NotifyObj> Notify_Lst = Not_Dal.Select_All_Notify(Kind);
            return Notify_Lst;
        }
        public static bool Insert_Program_Notify(List<NotifyObj> InLstNotify, ProgramObj ProgObj)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Insert_Program_Notify(InLstNotify, ProgObj);
        }
        public static List<NotifyObj> Select_Program_Notify(ProgramObj ProgObj)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Select_Program_Notify(ProgObj);
        }
        public static void Delete_Program_All_Notify(ProgramObj Prg)
        {
            NotifyDal Not_Dal = new NotifyDal();
            Not_Dal.Delete_All_Program_Notify(Prg);
        }



        public static NotifyObj Select_Current_Notify(int NotifyId)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Select_Current_Notify(NotifyId);
        }

        public static bool Insert_Notify_Base(NotifyObj Not)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Insert_Notify_Base(Not);
        }
        public static bool Update_Current_Notify(NotifyObj Not)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Update_Current_Notify(Not);
        }
        public static List<string[]> Select_NotifiesById(int NotifyId)
        {
            NotifyDal Not_Dal = new NotifyDal();
            return Not_Dal.Select_NotifiesById(NotifyId);
        }
        public static bool Delete_Notify(int NotifyId)
        {
             NotifyDal Not_Dal = new NotifyDal();
             return Not_Dal.Delete_Notify(NotifyId);
        }
    }
}
