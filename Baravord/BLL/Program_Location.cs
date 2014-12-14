using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;
namespace Baravord.BLL
{
    class Program_LocationBll
    {
        public static bool Insert_Program_Location(Program_LocationObj Location, ProgramObj Prog)
        {
            Program_LocationDal Location_Dal = new Program_LocationDal();
            return Location_Dal.Insert_Program_Location(Location, Prog);
        }
        public static List<Program_LocationObj> Select_Program_Location(ProgramObj Prog)
        {
            Program_LocationDal Location_Dal = new Program_LocationDal();
            return Location_Dal.Select_Program_Location(Prog);
        }
        public static bool Delete_Current_Program_Location(int Id)
        {
              Program_LocationDal Location_Dal = new Program_LocationDal();
              return Location_Dal.Delete_Current_Program_Location(Id);
        }
    }
}
