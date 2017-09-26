using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Program_RoleDal
    {
        public bool Insert_Program_Role(Program_RoleObj RoleInput, ProgramObj PrgInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_ROLE", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();

                Cmd.Parameters.AddWithValue("@ROLE_ID", RoleInput.Role_Id);
                Cmd.Parameters.AddWithValue("@COUNT", RoleInput.Count);
                Cmd.Parameters.AddWithValue("@TIME", RoleInput.Time);
                Cmd.Parameters.AddWithValue("@PRICE_UNIT", RoleInput.Price_Unit);
                Cmd.Parameters.AddWithValue("@PROGRAM_ID", PrgInput.Id);
                Cmd.Parameters.AddWithValue("@Description", RoleInput.Description);
                Cmd.Parameters.AddWithValue("@unit", RoleInput.Unit);

                Cmd.ExecuteScalar();

                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;
        }

        public List<Program_RoleObj> Select_All_Program_Roles(ProgramObj Prg)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Program_All_Roles";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
            SelectCmd.Parameters.AddWithValue("Program_Id", Prg.Id);


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<Program_RoleObj> Stracuture = new List<Program_RoleObj>();

            while (SqlRd.Read())
            {
                Program_RoleObj Obj = new Program_RoleObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Role_Id = int.Parse(SqlRd["Role_ID"].ToString());
                Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                Obj.Count = int.Parse(SqlRd["Count"].ToString());
                Obj.Price_Unit = SqlRd["Price_Unit"].ToString();
                Obj.Description = SqlRd["Description"].ToString();
                Obj.Time = SqlRd["Time"].ToString();
                Obj.Unit = int.Parse(SqlRd["unit"].ToString());
                Stracuture.Add(Obj);
            }
            Con.Close();
            return Stracuture;
        }

        public bool Delete_Current_Program_Role(int Id)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Delete_Current_PROGRAM_ROLE", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();

                Cmd.Parameters.AddWithValue("@ID", Id);

                Cmd.ExecuteScalar();

                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;
        }

        public Program_RoleObj Select_Current_Program_Roles(int RoleId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Program_Roles";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
            SelectCmd.Parameters.AddWithValue("RoleId", RoleId);


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            Program_RoleObj Role = new Program_RoleObj();

            while (SqlRd.Read())
            {
                Role.Id = int.Parse(SqlRd["Id"].ToString());
                Role.Role_Id = int.Parse(SqlRd["Role_ID"].ToString());
                Role.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                Role.Count = int.Parse(SqlRd["Count"].ToString());
                Role.Price_Unit = SqlRd["Price_Unit"].ToString();
                Role.Description = SqlRd["Description"].ToString();
                Role.Time = SqlRd["Time"].ToString();
                Role.Unit = int.Parse(SqlRd["unit"].ToString());
            }
            Con.Close();
            return Role;
        }
        public bool Update_Current_Program_Role(Program_RoleObj InObj)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_Program_Role", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;


                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@ROLE_ID", InObj.Role_Id);
                Cmd.Parameters.AddWithValue("@COUNT", InObj.Count);
                Cmd.Parameters.AddWithValue("@TIME", InObj.Time);
                Cmd.Parameters.AddWithValue("@PRICE_UNIT", InObj.Price_Unit);
                Cmd.Parameters.AddWithValue("@Description", InObj.Description);
                Cmd.Parameters.AddWithValue("@Id", InObj.Id);
                Cmd.Parameters.AddWithValue("@Unit", InObj.Unit);
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

        public List<string[]> Select_RoleById(int RoleId)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAM_Role where Role_Id=" + RoleId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["PROGRAM_ID"].ToString();
                Str[1] = SqlRd["Role_Id"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }



    }
}
