using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class PaymentDal
    {
        public List<PaymentObj> Select_All_Payment()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();        
            Con.Open();

            string Cmd = "Select * from Payment Order by sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<PaymentObj> PaymentLst = new List<PaymentObj>();

            while (SqlRd.Read())
            {
                PaymentObj Obj = new PaymentObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
               

                PaymentLst.Add(Obj);
            }
            Con.Close();
            return PaymentLst;


        }
        public PaymentObj Select_Current_Payment(int Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Payment where id="+Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

          
            PaymentObj Obj = new PaymentObj();

            while (SqlRd.Read())
            {

               
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
            }
           
            Con.Close();
            return Obj;
        }
        public bool Update_Current_Payment(PaymentObj Pym)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_Payment", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Pym.Title);
                Cmd.Parameters.AddWithValue("@SORT", Pym.Sort);
                Cmd.Parameters.AddWithValue("@Id", Pym.Id);

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
        public bool Insert_Payment_Base(PaymentObj Pym)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Payment_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            SelectCmd.Parameters.AddWithValue("@Title", Pym.Title);
            SelectCmd.Parameters.AddWithValue("@Sort", Pym.Sort);

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }

        public List<string[]> Select_PaymentById(int PaymentId)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAM_payment where Payment_Id=" + PaymentId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["PROGRAM_ID"].ToString();
                Str[1] = SqlRd["Payment_Id"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }

        public bool Delete_Payment(int PaymentId)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete payment where Id=" + PaymentId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
            

    }
}
