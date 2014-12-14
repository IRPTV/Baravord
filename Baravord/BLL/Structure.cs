using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;


namespace Baravord.BLL
{
    class StructureBll
    {
        public List<StructureObj> Select_All_Struct()
        {
            StructureDal Str_Dal = new StructureDal();
            List<StructureObj> Struc_Lst = Str_Dal.Select_All_Structs();
            return Struc_Lst;
        }
        public static bool Insert_Program_Struct(List<StructureObj> InLstStructs,ProgramObj ProgObj)
        {
             StructureDal Str_Dal = new StructureDal();
             return Str_Dal.Insert_Program_Structs(InLstStructs, ProgObj);
        }
        public static List<StructureObj> Select_Program_Structs(ProgramObj ProgObj)
        {
            StructureDal Str_Dal = new StructureDal();
            return Str_Dal.Select_Program_Structs(ProgObj);
        }
        public static StructureObj Select_Current_Struct(int StrcId)
        {
            StructureDal Str_Dal = new StructureDal();
            return Str_Dal.Select_Current_Struct(StrcId);
        }
        public static bool UPDATE_STRUCTURE(StructureObj Strc)
        {
            StructureDal Str_Dal = new StructureDal();
            return Str_Dal.UPDATE_STRUCTURE(Strc);
        }
        public static bool INSERT_STRUCTURE(StructureObj Strc)
        {
            StructureDal Str_Dal = new StructureDal();
            return Str_Dal.INSERT_STRUCTURE(Strc);
        }
    }
}
