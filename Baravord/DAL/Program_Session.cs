using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Program_SessionDal
    {
        public bool Insert_Program_Session(Program_SessionObj InObj)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_Session", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@PROGRAM_ID", InObj.Program_Id);
                Cmd.Parameters.AddWithValue("@Title", InObj.Title);
                Cmd.Parameters.AddWithValue("@Description_Content", InObj.Description_Content);
                Cmd.Parameters.AddWithValue("@Description_Structure", InObj.Description_Structure);
                Cmd.Parameters.AddWithValue("@SessionNum", InObj.SessionNum);
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
        public List<Program_SessionObj> Select_Program_Session(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            Program_SessionObj Obj = new Program_SessionObj();
            List<Program_SessionObj> SessionLst = new List<Program_SessionObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Session", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new Program_SessionObj();
                    Obj.Id = int.Parse(SqlRd["ID"].ToString());
                    Obj.Description_Content = SqlRd["Description_Content"].ToString();
                    Obj.Description_Structure = SqlRd["Description_Structure"].ToString();
                    Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                    Obj.SessionNum = int.Parse(SqlRd["SessionNum"].ToString());
                    Obj.Title = SqlRd["Title"].ToString();
                    SessionLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return SessionLst;
        }

        public bool Delete_Current_Program_Session(int Id)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program_Session", Con);
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



        public Program_SessionObj Select_Current_Session(int SessionId)
        {
            SqlConnection Con = new SqlConnection();
            Program_SessionObj Obj = new Program_SessionObj();
           
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("select * from program_session where id= " + SessionId.ToString(), Con);
                SelectCmd.CommandType = System.Data.CommandType.Text;
              //  SelectCmd.Parameters.AddWithValue("@Program_Id", SessionId);
                Obj = new Program_SessionObj();
                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                   
                    Obj.Id = int.Parse(SqlRd["ID"].ToString());
                    Obj.Description_Content = SqlRd["Description_Content"].ToString();
                    Obj.Description_Structure = SqlRd["Description_Structure"].ToString();
                    Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                    Obj.SessionNum = int.Parse(SqlRd["SessionNum"].ToString());
                    Obj.Title = SqlRd["Title"].ToString();
                    
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return Obj;
        }


        public bool Update_PROGRAM_Session(Program_SessionObj InObj)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Update_PROGRAM_Session", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@PROGRAM_ID", InObj.Program_Id);
                Cmd.Parameters.AddWithValue("@Title", InObj.Title);
                Cmd.Parameters.AddWithValue("@Description_Content", InObj.Description_Content);
                Cmd.Parameters.AddWithValue("@Description_Structure", InObj.Description_Structure);
                Cmd.Parameters.AddWithValue("@SessionNum", InObj.SessionNum);
                Cmd.Parameters.AddWithValue("@SessionId", InObj.Id);
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

    }

}
