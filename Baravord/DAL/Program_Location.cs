using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Program_LocationDal
    {
        public bool Insert_Program_Location(Program_LocationObj InObj, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();
             
                SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_LOCATION", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@PROGRAM_ID",ProgObjInput.Id);
                Cmd.Parameters.AddWithValue("@Title", InObj.TITLE);
                Cmd.Parameters.AddWithValue("@Duration", InObj.DURATION);                    
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
        public List<Program_LocationObj> Select_Program_Location(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            Program_LocationObj Obj = new Program_LocationObj();
            List<Program_LocationObj> LocationLst = new List<Program_LocationObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Location", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new Program_LocationObj();
                    Obj.ID = int.Parse(SqlRd["ID"].ToString());
                    Obj.DURATION = int.Parse(SqlRd["Duration"].ToString());
                    Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                    Obj.TITLE = SqlRd["Title"].ToString();
                    LocationLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return LocationLst;
        }

        public bool Delete_Current_Program_Location(int Id)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program_Location", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@ID",Id);             
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
