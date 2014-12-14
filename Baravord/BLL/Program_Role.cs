using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class Program_RoleBll
    {
        public static void Insert_Program_Role(Program_RoleObj InRoleObj, ProgramObj PrgObj)
        {
            Program_RoleDal Rol_Dal = new Program_RoleDal();
            Rol_Dal.Insert_Program_Role(InRoleObj, PrgObj);
        }
        public static List<Program_RoleObj> Select_Program_All_Roles(ProgramObj Prg)
        {
            Program_RoleDal Rol_Dal = new Program_RoleDal();
            return Rol_Dal.Select_All_Program_Roles(Prg);
        }
        public static bool Delete_Current_Program_Role(int Id)
        {
            Program_RoleDal Rol_Dal=new Program_RoleDal();
            return Rol_Dal.Delete_Current_Program_Role(Id);
        }
        public static Program_RoleObj Select_Current_Program_Roles(int RoleId)
        {
             Program_RoleDal Rol_Dal=new Program_RoleDal();
             return Rol_Dal.Select_Current_Program_Roles(RoleId);
        }
        public static bool Update_Current_Program_Role(Program_RoleObj InObj)
        {
            Program_RoleDal Rol_Dal=new Program_RoleDal();
            return Rol_Dal.Update_Current_Program_Role(InObj);
        }

        public static List<string[]> Select_RoleById(int RoleId)
        {
             Program_RoleDal Rol_Dal=new Program_RoleDal();
             return Rol_Dal.Select_RoleById(RoleId);
        }

       
    }
}
