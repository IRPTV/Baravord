using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class OutIranBll
    {
        public static bool Insert_OutIran(OutIranObj InObj)
        {
            OutIranDal Iran_Dal = new OutIranDal();
            return Iran_Dal.Insert_OutIran(InObj);
        }
        public static OutIranObj Select_OutIran(ProgramObj Obj)
        {
            OutIranDal Iran_Dal = new OutIranDal();
            return Iran_Dal.Select_OutIran(Obj);
        }
        public static void Delete_OutIran(int Program_Id)
        {
            OutIranDal Iran_Dal = new OutIranDal();
            Iran_Dal.Delete_OutIran(Program_Id);
        }
    }
}
