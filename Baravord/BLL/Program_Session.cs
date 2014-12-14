using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class Program_SessionBll
    {
        public static bool Insert_Program_Session(Program_SessionObj InObj)
        {
            Program_SessionDal Session_Dal = new Program_SessionDal();
            return Session_Dal.Insert_Program_Session(InObj);
        }
        public static List<Program_SessionObj> Select_Program_Session(ProgramObj ProgObjInput)
        {
              Program_SessionDal Session_Dal = new Program_SessionDal();
              return Session_Dal.Select_Program_Session(ProgObjInput);
        }
        public static bool Delete_Current_Program_Session(int Id)
        {
            Program_SessionDal Session_Dal = new Program_SessionDal();
            return Session_Dal.Delete_Current_Program_Session(Id);
        }
        public static Program_SessionObj Select_Current_Session(int SessionId)
        {
             Program_SessionDal Session_Dal = new Program_SessionDal();
             return Session_Dal.Select_Current_Session(SessionId);
        }
        public static bool Update_PROGRAM_Session(Program_SessionObj InObj)
        {
             Program_SessionDal Session_Dal = new Program_SessionDal();
             return Session_Dal.Update_PROGRAM_Session(InObj);
        }
    }
}
