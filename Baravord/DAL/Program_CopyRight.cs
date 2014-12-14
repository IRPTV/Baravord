using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Program_CopyRightDal
    {
        public bool Insert_Program_CopyRight(Program_CopyRightObj InObj, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_COPYRIGHT", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                Cmd.Parameters.AddWithValue("@Title", InObj.Title);
                Cmd.Parameters.AddWithValue("@VALUE", InObj.ValuePercent);
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







        public List<Program_CopyRightObj> Select_Program_CopyRight(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            Program_CopyRightObj Obj = new Program_CopyRightObj();
            List<Program_CopyRightObj> RightLst = new List<Program_CopyRightObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_CopyRight", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new Program_CopyRightObj();
                    Obj.ID = int.Parse(SqlRd["ID"].ToString());
                    Obj.ValuePercent = int.Parse(SqlRd["Value"].ToString());
                    Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                    Obj.Title = SqlRd["Title"].ToString();
                    RightLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return RightLst;
        }
        public bool Delete_Current_Program_CopyRight(int Id)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program_CopyRight", Con);
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

    }
}
