using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class DepsBll
    {
        public static List<DepsObj> Select_All_DepsByChannelId(int ChannelId)
        {
            DepsDal Dep_Dal = new DepsDal();
            return Dep_Dal.Select_All_DepsByChannelId(ChannelId);
        }
        public static bool Insert_Deps_Base(DepsObj Obj)
        {
            DepsDal Dep_Dal = new DepsDal();
            return Dep_Dal.Insert_Deps_Base(Obj);
        }
         public static bool Delete_Deps(int DepId)
        {
            DepsDal Dep_Dal = new DepsDal();
            return Dep_Dal.Delete_Deps(DepId);
        }
         public static DepsObj Select_Current_Deps(int Id)
         {
             DepsDal Dep_Dal = new DepsDal();
             return Dep_Dal.Select_Current_Deps(Id);
         }
         public static bool Update_Current_Deps(DepsObj Obj)
        {
            DepsDal Dep_Dal = new DepsDal();
            return Dep_Dal.Update_Current_Deps(Obj);
        }
    }
}
