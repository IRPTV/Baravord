using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class TargetDal
    {
        public List<TargetObj> Select_All_Targets()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();        
            Con.Open();

            string Cmd = "Select * from Targets Order by Sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<TargetObj> Targ = new List<TargetObj>();

            while (SqlRd.Read())
            {
                TargetObj Obj = new TargetObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Targ.Add(Obj);
            }
            Con.Close();
            return Targ;
        }
        public bool Insert_Program_Target(List<TargetObj> InLst, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand CmdDel = new SqlCommand("Delete_Program_All_Targets", Con);
                CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
                CmdDel.Parameters.Clear();
                CmdDel.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                CmdDel.ExecuteScalar();

                foreach (TargetObj item in InLst)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_Target", Con);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                    Cmd.Parameters.AddWithValue("@Target_ID", item.Id);
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
        public List<TargetObj> Select_All_Program_Target(ProgramObj Prog)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_All_Program_Target";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Program_Id", Prog.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<TargetObj> Targets = new List<TargetObj>();

            while (SqlRd.Read())
            {
                TargetObj Obj = new TargetObj();
                Obj.Id = int.Parse(SqlRd["Target_Id"].ToString());               
                Targets.Add(Obj);
            }
            Con.Close();
            return Targets;
        }

        public TargetObj Select_Current_Target(TargetObj Targ)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Target";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Id", Targ.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            TargetObj Obj = new TargetObj();

            while (SqlRd.Read())
            {               
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();              
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());              
            }
            Con.Close();
            return Obj;
        }

         public bool Update_Target_Base(TargetObj Targ)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Target_Base", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Targ.Title);
                Cmd.Parameters.AddWithValue("@SORT", Targ.Sort);
                Cmd.Parameters.AddWithValue("@Id", Targ.Id);

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

         public bool Insert_Target_Base(TargetObj Targ)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Target_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Title", Targ.Title);
            SelectCmd.Parameters.AddWithValue("@Sort", Targ.Sort);            

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }

         public List<string[]> Select_TargetById(int Target_Id)
         {

             List<string[]> Lst = new List<string[]>();
             SqlConnection Con = DataBaseTools.CreateSqlConnection();
             Con.Open();

             string Cmd = "Select * From PROGRAM_Subject where Subject_Id=" + Target_Id.ToString();
             SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
             SelectCmd.CommandType = System.Data.CommandType.Text;


             SqlDataReader SqlRd = SelectCmd.ExecuteReader();

             while (SqlRd.Read())
             {
                 string[] Str = new string[2];
                 Str[0] = SqlRd["PROGRAM_ID"].ToString();
                 Str[1] = SqlRd["Target_Id"].ToString();
                 Lst.Add(Str);
             }
             Con.Close();
             return Lst;
         }

         public bool Delete_Target(int Target_Id)
         {
             SqlConnection Con = DataBaseTools.CreateSqlConnection();
             Con.Open();
             string Cmd = "Delete Targets where Id=" + Target_Id.ToString();
             SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
             SelectCmd.CommandType = System.Data.CommandType.Text;
             SelectCmd.ExecuteNonQuery();
             Con.Close();
             return true;
         }
             
    }
}
