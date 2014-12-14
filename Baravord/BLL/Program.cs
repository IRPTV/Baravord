using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class ProgramBll
    {
        public static ProgramObj Insert_Prgram(ProgramObj InputProgObject)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Insert_Prgram(InputProgObject);
        }

        public static bool Delete_Current_Program(ProgramObj InputProgramObject)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Delete_Current_Prgram(InputProgramObject);
        }

        public static bool Update_Program(ProgramObj InputProgramObject)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Update_Program(InputProgramObject);
        }
        public static ProgramObj Select_Program(ProgramObj InputProgramObject)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Select_Current_Prgram(InputProgramObject);
        }
        public static List<ProgramObj> Search_Prgrams(string FullQuery)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Search_Prgrams(FullQuery);
        }
        public static bool Delete_Prog_And_Details(int ProgramId)
        {
            ProgramDal Prog_Dal = new ProgramDal();

            return Prog_Dal.Delete_Prog_And_Details(ProgramId);
        }

    }
}
