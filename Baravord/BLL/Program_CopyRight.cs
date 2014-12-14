using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;
namespace Baravord.BLL
{
    class Program_CopyRightBll
    {
        public static bool Insert_Program_CopyRight(Program_CopyRightObj RightObj, ProgramObj Prog)
        {
            Program_CopyRightDal Right_Dal = new Program_CopyRightDal();

            return Right_Dal.Insert_Program_CopyRight(RightObj, Prog);
        }

        public static List<Program_CopyRightObj> Select_Program_CopyRight(ProgramObj ProgObjInput)
        {
             Program_CopyRightDal Right_Dal = new Program_CopyRightDal();

             return Right_Dal.Select_Program_CopyRight(ProgObjInput);
        }
        public static bool Delete_Current_Program_CopyRight(int Id)
        {
            Program_CopyRightDal Right_Dal = new Program_CopyRightDal();

            return Right_Dal.Delete_Current_Program_CopyRight(Id);
        }
    }
}
