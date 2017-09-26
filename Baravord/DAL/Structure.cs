using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;
namespace Baravord.DAL
{
    class StructureDal
    {
        public List<StructureObj> Select_All_Structs()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from structure Order by Sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<StructureObj> Stracuture = new List<StructureObj>();

            while (SqlRd.Read())
            {
                StructureObj Obj = new StructureObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Stracuture.Add(Obj);
            }
            Con.Close();
            return Stracuture;
        }
        public bool Insert_Program_Structs(List<StructureObj> InLst, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand CmdDel = new SqlCommand("Delete_Program_All_Struct", Con);
                CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
                CmdDel.Parameters.Clear();
                CmdDel.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                CmdDel.ExecuteScalar();

                foreach (StructureObj item in InLst)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_STRUCTURES", Con);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("@PROGRAME_ID", ProgObjInput.Id);
                    Cmd.Parameters.AddWithValue("@STRUCT_ID", item.Id);
                    Cmd.ExecuteScalar();
                }
                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true; ;

        }
        public List<StructureObj> Select_Program_Structs(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            StructureObj Obj = new StructureObj();
            List<StructureObj> Stracuture = new List<StructureObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Structs", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new StructureObj();
                    Obj.Id = int.Parse(SqlRd["STRUCT_ID"].ToString());
                    Stracuture.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }

          
            return Stracuture;
        }
        public StructureObj Select_Current_Struct(int StrcId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from structure where id="+StrcId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            StructureObj Stracuture = new StructureObj();

            while (SqlRd.Read())
            {
              
                Stracuture.Id = int.Parse(SqlRd["Id"].ToString());
                Stracuture.Title = SqlRd["Title"].ToString();
                Stracuture.Sort = int.Parse(SqlRd["Sort"].ToString());               
            }
            Con.Close();
            return Stracuture;
        }
        public bool UPDATE_STRUCTURE(StructureObj Strc)
        {

            SqlConnection Con = new SqlConnection();
            StructureObj Obj = new StructureObj();
            List<StructureObj> Stracuture = new List<StructureObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("UPDATE_STRUCTURE", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@ID", Strc.Id);
                SelectCmd.Parameters.AddWithValue("@TITLE", Strc.Title);
                SelectCmd.Parameters.AddWithValue("@SORT", Strc.Sort);

               SelectCmd.ExecuteNonQuery();
            
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message);
                return false;
            }


            return true;
        }
        public bool INSERT_STRUCTURE(StructureObj Strc)
        {

            SqlConnection Con = new SqlConnection();
            StructureObj Obj = new StructureObj();
            List<StructureObj> Stracuture = new List<StructureObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("INSERT_STRUCTURE", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;                
                SelectCmd.Parameters.AddWithValue("@TITLE", Strc.Title);
                SelectCmd.Parameters.AddWithValue("@SORT", Strc.Sort);

                SelectCmd.ExecuteNonQuery();

                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message);
                return false;
            }


            return true;
        }

    }
}
