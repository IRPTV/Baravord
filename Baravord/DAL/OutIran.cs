using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class OutIranDal
    {
        public bool Insert_OutIran(OutIranObj InObj)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand CmdDel = new SqlCommand("OutIran_DeleteByField", Con);
                CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
                CmdDel.Parameters.Clear();
                CmdDel.Parameters.AddWithValue("@FieldName", "PROGRAM_ID");
                CmdDel.Parameters.AddWithValue("@Value", InObj.Program_Id);

                CmdDel.ExecuteScalar();


                SqlCommand Cmd = new SqlCommand("OutIran_Insert", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();

                Cmd.Parameters.AddWithValue("@PROGRAM_ID", InObj.Program_Id);
                Cmd.Parameters.AddWithValue("@CellPhone_number", InObj.CellPhone_number);
                Cmd.Parameters.AddWithValue("@Visa_IsHave", InObj.Visa_IsHave);
                Cmd.Parameters.AddWithValue("@Fax_Number", InObj.Fax_Number);
                Cmd.Parameters.AddWithValue("@Group_Address", InObj.Group_Address);
                Cmd.Parameters.AddWithValue("@Language", InObj.Language);
                Cmd.Parameters.AddWithValue("@Office", InObj.Office);
                Cmd.Parameters.AddWithValue("@Phone_Number", InObj.Phone_Number);
                Cmd.Parameters.AddWithValue("@Reporter_Credential", InObj.Reporter_Credential);
                Cmd.Parameters.AddWithValue("@Sponser", InObj.Sponser);
                Cmd.Parameters.AddWithValue("@Visa_Expire", InObj.Visa_Expire);
                Cmd.Parameters.AddWithValue("@Visa_CanGet", InObj.Visa_CanGet);

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

        public OutIranObj Select_OutIran(ProgramObj Obj)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from OutIran where Program_Id=" + Obj.Id;
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            OutIranObj RetValue = new OutIranObj();

            while (SqlRd.Read())
            {

                RetValue.Id = int.Parse(SqlRd["Id"].ToString());
                RetValue.CellPhone_number = SqlRd["CellPhone_number"].ToString();
                RetValue.Fax_Number = SqlRd["Fax_Number"].ToString();
                RetValue.Group_Address = SqlRd["Group_Address"].ToString();
                RetValue.Language = bool.Parse(SqlRd["Language"].ToString());
                RetValue.Office = bool.Parse(SqlRd["Office"].ToString());
                RetValue.Phone_Number = SqlRd["Phone_Number"].ToString();
                RetValue.Program_Id = int.Parse(SqlRd["Program_Id"].ToString());
                RetValue.Reporter_Credential = bool.Parse(SqlRd["Reporter_Credential"].ToString());
                RetValue.Sponser = bool.Parse(SqlRd["Sponser"].ToString());
                RetValue.Visa_CanGet = bool.Parse(SqlRd["Visa_CanGet"].ToString());
                RetValue.Visa_Expire = SqlRd["Visa_Expire"].ToString();
                RetValue.Visa_IsHave = bool.Parse(SqlRd["Visa_IsHave"].ToString());

            }
            Con.Close();
            return RetValue;
        }

        public void Delete_OutIran(int Program_Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "delete  OutIran where Program_Id=" + Program_Id;
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.ExecuteNonQuery();
            Con.Close();

        }
    }
}
