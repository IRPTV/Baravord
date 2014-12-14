using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Program_PaymentDal
    {
        public bool Insert_Program_Payment(Program_PaymentObj InObj, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_Payment", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                Cmd.Parameters.AddWithValue("@Payment_Id", InObj.Payment_Id);
                Cmd.Parameters.AddWithValue("@Sort", InObj.Sort);
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

        public List<Program_PaymentObj> Select_Program_Payment(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            Program_PaymentObj Obj = new Program_PaymentObj();
            List<Program_PaymentObj> PaymentLst = new List<Program_PaymentObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Payment", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@ProgId", ProgObjInput.Id);

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new Program_PaymentObj();
                    Obj.Id = int.Parse(SqlRd["ID"].ToString());
                    Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                    Obj.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                    Obj.Payment_Id = int.Parse(SqlRd["Payment_Id"].ToString());
                    PaymentLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return PaymentLst;
        }
        public bool Delete_Current_Program_Payment(int Id)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program_Payment", Con);
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
