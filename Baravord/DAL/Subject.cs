using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;


namespace Baravord.DAL
{
    class SubjectDal
    {
        public List<SubjectObj> Select_All_Subject()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();        
            Con.Open();

            string Cmd = "Select * from subject Order by title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<SubjectObj> Subject = new List<SubjectObj>();

            while (SqlRd.Read())
            {
                SubjectObj Obj = new SubjectObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();              
                Subject.Add(Obj);
            }
            Con.Close();
            return Subject;
        }
        public bool Insert_Program_Subjects(List<SubjectObj> InLst, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand CmdDel = new SqlCommand("Delete_Program_All_Subject", Con);
                CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
                CmdDel.Parameters.Clear();
                CmdDel.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                CmdDel.ExecuteScalar();

                foreach (SubjectObj item in InLst)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_Subjects", Con);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                    Cmd.Parameters.AddWithValue("@Subject_ID", item.Id);
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
        public List<SubjectObj> Select_Program_Subjects(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            SubjectObj Obj = new SubjectObj();
            List<SubjectObj> SubjectLst = new List<SubjectObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Subject", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new SubjectObj();
                    Obj.Id = int.Parse(SqlRd["Subject_ID"].ToString());
                    SubjectLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return SubjectLst;
        }









        public SubjectObj Select_Current_Subject_Base(SubjectObj Sub)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Subject_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Id", Sub.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            SubjectObj Obj = new SubjectObj();

            while (SqlRd.Read())
            {               
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();                                
            }
            Con.Close();
            return Obj;
        }


         public bool Update_Subject_Base(SubjectObj Sub)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Subject_Base", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Sub.Title);
                Cmd.Parameters.AddWithValue("@Id", Sub.Id);    

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
         public bool Insert_Subject_Base(SubjectObj Sub)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Subject_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            SelectCmd.Parameters.AddWithValue("@Title", Sub.Title);            
            

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }


         public List<string[]> Select_SubjectById(int Subject_Id)
         {

             List<string[]> Lst = new List<string[]>();
             SqlConnection Con = DataBaseTools.CreateSqlConnection();
             Con.Open();

             string Cmd = "Select * From PROGRAM_Subject where Subject_Id=" + Subject_Id.ToString();
             SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
             SelectCmd.CommandType = System.Data.CommandType.Text;


             SqlDataReader SqlRd = SelectCmd.ExecuteReader();

             while (SqlRd.Read())
             {
                 string[] Str = new string[2];
                 Str[0] = SqlRd["PROGRAM_ID"].ToString();
                 Str[1] = SqlRd["Subject_Id"].ToString();
                 Lst.Add(Str);
             }
             Con.Close();
             return Lst;
         }

         public bool Delete_Subject(int Subject_Id)
         {
             SqlConnection Con = DataBaseTools.CreateSqlConnection();
             Con.Open();
             string Cmd = "Delete subject where Id=" + Subject_Id.ToString();
             SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
             SelectCmd.CommandType = System.Data.CommandType.Text;
             SelectCmd.ExecuteNonQuery();
             Con.Close();
             return true;
         }
      
    }
}
