using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class RoleDal
    {

        public List<RoleObj> Select_All_Role()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Role Order by title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<RoleObj> Roles = new List<RoleObj>();

            while (SqlRd.Read())
            {
                RoleObj Obj = new RoleObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Roles.Add(Obj);
            }
            Con.Close();
            return Roles;
        }

        public List<RoleObj> Search_Roles(string Condition)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Role " + Condition + "Order by title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<RoleObj> Roles = new List<RoleObj>();

            while (SqlRd.Read())
            {
                RoleObj Obj = new RoleObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Roles.Add(Obj);
            }
            Con.Close();
            return Roles;
        }


        public RoleObj Select_Current_Role(RoleObj Role)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Role";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Role_Id", Role.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            RoleObj Obj = new RoleObj();

            while (SqlRd.Read())
            {               
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Description= SqlRd["Description"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());              
            }
            Con.Close();
            return Obj;
        }


         public bool Update_Current_Role(RoleObj Rol)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_Role", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Rol.Title);
                Cmd.Parameters.AddWithValue("@SORT", Rol.Sort);
                Cmd.Parameters.AddWithValue("@Id", Rol.Id);
                Cmd.Parameters.AddWithValue("@description", Rol.Description);

                Cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;
        }
         public bool Insert_Role_Base(RoleObj Rol)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Role_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            SelectCmd.Parameters.AddWithValue("@Title", Rol.Title);
            SelectCmd.Parameters.AddWithValue("@Sort", Rol.Sort);
            SelectCmd.Parameters.AddWithValue("@Description", Rol.Description);

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }

       
         public bool Delete_Role(int RoleId)
         {
             SqlConnection Con = DataBaseTools.CreateSqlConnection();
             Con.Open();
             string Cmd = "Delete role where Id=" + RoleId.ToString();
             SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
             SelectCmd.CommandType = System.Data.CommandType.Text;
             SelectCmd.ExecuteNonQuery();
             Con.Close();
             return true;
         }
            
       
    }
}
