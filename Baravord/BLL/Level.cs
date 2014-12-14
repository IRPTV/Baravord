using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.BLL
{
    class LevelBll
    {
        public List<LevelObj> Select_All_Level()
        {
            LevelDal Ch_Dal = new  LevelDal();
            List<LevelObj> Level_Lst = Ch_Dal.Select_All_Level();
            return Level_Lst;
        }

        public static bool Insert_Program_Level(List<LevelObj> LstLevels,ProgramObj Prg)
        {
            LevelDal Ch_Dal = new LevelDal();
            return Ch_Dal.Insert_Program_Level(LstLevels, Prg);
        }
        public static List<LevelObj> Select_All_Program_Levels(ProgramObj Prg)
        {
            LevelDal Ch_Dal = new LevelDal();
            return Ch_Dal.Select_All_Program_Levels(Prg);

        }
        public static LevelObj Select_Current_Level(int LvlId)
        {
             LevelDal Ch_Dal = new LevelDal();
             return Ch_Dal.Select_Current_Level(LvlId);
        }
        public static bool Update_Current_Level(LevelObj Lvl)
        {
             LevelDal Ch_Dal = new LevelDal();
             return Ch_Dal.Update_Current_Level(Lvl);
        }
        public static bool Insert_Level_INLVL(LevelObj Lvl)
        {
             LevelDal Ch_Dal = new LevelDal();
             return Ch_Dal.Insert_Level_INLVL(Lvl);
        }
        public static List<string[]> Select_Levels(int LvlId)
        {
             LevelDal Ch_Dal = new LevelDal();
             return Ch_Dal.Select_Levels(LvlId);
        }
        public static bool Delete_Level(int LvlId)
        {
            LevelDal Ch_Dal = new LevelDal();
            return Ch_Dal.Delete_Level(LvlId);
        }


    }
}
