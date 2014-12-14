using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;


namespace Baravord.BLL
{
    class RoleBll
    {
        public List<RoleObj> Select_All_Role()
        {
            RoleDal Role_Dal = new RoleDal();
            List<RoleObj> Rl_Lst = Role_Dal.Select_All_Role();
            return Rl_Lst;
        }

        public List<RoleObj> Search_Roles(string Condition)
        {
            RoleDal Role_Dal = new RoleDal();
            List<RoleObj> Rl_Lst = Role_Dal.Search_Roles(Condition);
            return Rl_Lst;
        }
        public static RoleObj Select_Current_Role(RoleObj Role)
        {
            RoleDal Role_Dal = new RoleDal();
            return Role_Dal.Select_Current_Role(Role);
        }
        public static bool Update_Current_Role(RoleObj Rol)
        {
              RoleDal Role_Dal = new RoleDal();
              return Role_Dal.Update_Current_Role(Rol);
        }

        public static bool Insert_Role_Base(RoleObj Rol)
        {
            RoleDal Role_Dal = new RoleDal();
            return Role_Dal.Insert_Role_Base(Rol);
        }

        public static bool Delete_Role(int RoleId)
        {
             RoleDal Role_Dal = new RoleDal();
             return Role_Dal.Delete_Role(RoleId);
        }
    }
}
