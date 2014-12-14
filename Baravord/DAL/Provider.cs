using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;
using Microsoft.ReportingServices.DataProcessing;

namespace Baravord.DAL
{
    class ProviderDal
    {
        public List<ProviderObj> Select_All_Providers()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            SqlCommand Cmd = new SqlCommand("Select_All_Providers", Con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader SqlRd = Cmd.ExecuteReader();


            List<ProviderObj> ProviderLst = new List<ProviderObj>();

            while (SqlRd.Read())
            {
                ProviderObj Obj = new ProviderObj();

                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.BIRTHDATE = SqlRd["BIRTHDATE"].ToString();
                Obj.BIRTHPLACE = SqlRd["BIRTHPLACE"].ToString();
                Obj.COMPANY = SqlRd["COMPANY"].ToString();
                Obj.COMPANYADDRESS = SqlRd["COMPANYADDRESS"].ToString();
                Obj.COMPANYAREA = SqlRd["COMPANYAREA"].ToString();
                Obj.COMPANYEMAIL = SqlRd["COMPANYEMAIL"].ToString();
                Obj.COMPANYFAX = SqlRd["COMPANYFAX"].ToString();
                Obj.COMPANYTELL = SqlRd["COMPANYTELL"].ToString();
                Obj.FATHER_NAME = SqlRd["FATHER_NAME"].ToString();
                Obj.HOMEADDRESS = SqlRd["HOMEADDRESS"].ToString();
                Obj.IRIBEMPLOEE = SqlRd["IRIBEMPLOEE"].ToString();
                Obj.JOB = SqlRd["JOB"].ToString();
                Obj.JOBTITLE = SqlRd["JOBTITLE"].ToString();
                Obj.LASTNAME = SqlRd["LASTNAME"].ToString();
                Obj.MELLICODE = SqlRd["MELLICODE"].ToString();
                Obj.Name = SqlRd["Name"].ToString();
                Obj.NATIONALITY = SqlRd["NATIONALITY"].ToString();
                Obj.PERSONALEMAIL = SqlRd["PERSONALEMAIL"].ToString();
                Obj.PERSONALFAX = SqlRd["PERSONALFAX"].ToString();
                Obj.PERSONALMOBILE = SqlRd["PERSONALMOBILE"].ToString();
                Obj.PERSONALTELL = SqlRd["PERSONALTELL"].ToString();
                Obj.SHENASNAME = SqlRd["SHENASNAME"].ToString();
                Obj.STUDYLEVEL = SqlRd["STUDYLEVEL"].ToString();
                Obj.STYDUCOURCE = SqlRd["STYDUCOURCE"].ToString();

                ProviderLst.Add(Obj);
            }
            Con.Close();
            return ProviderLst;
        }


        public List<ProviderObj> Search_Providers(string ConditionQuery)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            SqlCommand Cmd = new SqlCommand("Search_Providers", Con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ConditionQuery", ConditionQuery);
            SqlDataReader SqlRd = Cmd.ExecuteReader();


            List<ProviderObj> ProviderLst = new List<ProviderObj>();

            while (SqlRd.Read())
            {
                ProviderObj Obj = new ProviderObj();

                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.BIRTHDATE = SqlRd["BIRTHDATE"].ToString();
                Obj.BIRTHPLACE = SqlRd["BIRTHPLACE"].ToString();
                Obj.COMPANY = SqlRd["COMPANY"].ToString();
                Obj.COMPANYADDRESS = SqlRd["COMPANYADDRESS"].ToString();
                Obj.COMPANYAREA = SqlRd["COMPANYAREA"].ToString();
                Obj.COMPANYEMAIL = SqlRd["COMPANYEMAIL"].ToString();
                Obj.COMPANYFAX = SqlRd["COMPANYFAX"].ToString();
                Obj.COMPANYTELL = SqlRd["COMPANYTELL"].ToString();
                Obj.FATHER_NAME = SqlRd["FATHER_NAME"].ToString();
                Obj.HOMEADDRESS = SqlRd["HOMEADDRESS"].ToString();
                Obj.IRIBEMPLOEE = SqlRd["IRIBEMPLOEE"].ToString();
                Obj.JOB = SqlRd["JOB"].ToString();
                Obj.JOBTITLE = SqlRd["JOBTITLE"].ToString();
                Obj.LASTNAME = SqlRd["LASTNAME"].ToString();
                Obj.MELLICODE = SqlRd["MELLICODE"].ToString();
                Obj.Name = SqlRd["Name"].ToString();
                Obj.NATIONALITY = SqlRd["NATIONALITY"].ToString();
                Obj.PERSONALEMAIL = SqlRd["PERSONALEMAIL"].ToString();
                Obj.PERSONALFAX = SqlRd["PERSONALFAX"].ToString();
                Obj.PERSONALMOBILE = SqlRd["PERSONALMOBILE"].ToString();
                Obj.PERSONALTELL = SqlRd["PERSONALTELL"].ToString();
                Obj.SHENASNAME = SqlRd["SHENASNAME"].ToString();
                Obj.STUDYLEVEL = SqlRd["STUDYLEVEL"].ToString();
                Obj.STYDUCOURCE = SqlRd["STYDUCOURCE"].ToString();

                ProviderLst.Add(Obj);
            }
            Con.Close();
            return ProviderLst;
        }

        public bool Update_Provider(ProviderObj Obj)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            SqlCommand Cmd = new SqlCommand("Update_Provider", Con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@BIRTHDATE", Obj.BIRTHDATE);
            Cmd.Parameters.AddWithValue("@BIRTHPLACE", Obj.BIRTHPLACE);
            Cmd.Parameters.AddWithValue("@COMPANY", Obj.COMPANY);
            Cmd.Parameters.AddWithValue("@COMPANYADDRESS", Obj.COMPANYADDRESS);
            Cmd.Parameters.AddWithValue("@COMPANYAREA", Obj.COMPANYAREA);
            Cmd.Parameters.AddWithValue("@COMPANYEMAIL", Obj.COMPANYEMAIL);
            Cmd.Parameters.AddWithValue("@COMPANYFAX", Obj.COMPANYFAX);
            Cmd.Parameters.AddWithValue("@COMPANYTELL", Obj.COMPANYTELL);
            Cmd.Parameters.AddWithValue("@FATHER_NAME", Obj.FATHER_NAME);
            Cmd.Parameters.AddWithValue("@HOMEADDRESS", Obj.HOMEADDRESS);
            Cmd.Parameters.AddWithValue("@IRIBEMPLOEE", Obj.IRIBEMPLOEE);
            Cmd.Parameters.AddWithValue("@JOB", Obj.JOB);
            Cmd.Parameters.AddWithValue("@JOBTITLE", Obj.JOBTITLE);
            Cmd.Parameters.AddWithValue("@LASTNAME", Obj.LASTNAME);
            Cmd.Parameters.AddWithValue("@MELLICODE", Obj.MELLICODE);
            Cmd.Parameters.AddWithValue("@NAME", Obj.Name);
            Cmd.Parameters.AddWithValue("@NATIONALITY", Obj.NATIONALITY);
            Cmd.Parameters.AddWithValue("@PERSONALEMAIL", Obj.PERSONALEMAIL);
            Cmd.Parameters.AddWithValue("@PERSONALFAX", Obj.PERSONALFAX);
            Cmd.Parameters.AddWithValue("@PERSONALMOBILE", Obj.PERSONALMOBILE);
            Cmd.Parameters.AddWithValue("@PERSONALTELL", Obj.PERSONALTELL);
            Cmd.Parameters.AddWithValue("@SHENASNAME", Obj.SHENASNAME);
            Cmd.Parameters.AddWithValue("@STUDYLEVEL", Obj.STUDYLEVEL);
            Cmd.Parameters.AddWithValue("@STYDUCOURCE", Obj.STYDUCOURCE);
            Cmd.Parameters.AddWithValue("@Id", Obj.Id);

            Cmd.ExecuteNonQuery();

            Con.Close();
            return true;
        }

        public bool Insert_Provider(ProviderObj Obj)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            SqlCommand Cmd = new SqlCommand("Insert_Provider", Con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@BIRTHDATE", Obj.BIRTHDATE);
            Cmd.Parameters.AddWithValue("@BIRTHPLACE", Obj.BIRTHPLACE);
            Cmd.Parameters.AddWithValue("@COMPANY", Obj.COMPANY);
            Cmd.Parameters.AddWithValue("@COMPANYADDRESS", Obj.COMPANYADDRESS);
            Cmd.Parameters.AddWithValue("@COMPANYAREA", Obj.COMPANYAREA);
            Cmd.Parameters.AddWithValue("@COMPANYEMAIL", Obj.COMPANYEMAIL);
            Cmd.Parameters.AddWithValue("@COMPANYFAX", Obj.COMPANYFAX);
            Cmd.Parameters.AddWithValue("@COMPANYTELL", Obj.COMPANYTELL);
            Cmd.Parameters.AddWithValue("@FATHER_NAME", Obj.FATHER_NAME);
            Cmd.Parameters.AddWithValue("@HOMEADDRESS", Obj.HOMEADDRESS);
            Cmd.Parameters.AddWithValue("@IRIBEMPLOEE", Obj.IRIBEMPLOEE);
            Cmd.Parameters.AddWithValue("@JOB", Obj.JOB);
            Cmd.Parameters.AddWithValue("@JOBTITLE", Obj.JOBTITLE);
            Cmd.Parameters.AddWithValue("@LASTNAME", Obj.LASTNAME);
            Cmd.Parameters.AddWithValue("@MELLICODE", Obj.MELLICODE);
            Cmd.Parameters.AddWithValue("@NAME", Obj.Name);
            Cmd.Parameters.AddWithValue("@NATIONALITY", Obj.NATIONALITY);
            Cmd.Parameters.AddWithValue("@PERSONALEMAIL", Obj.PERSONALEMAIL);
            Cmd.Parameters.AddWithValue("@PERSONALFAX", Obj.PERSONALFAX);
            Cmd.Parameters.AddWithValue("@PERSONALMOBILE", Obj.PERSONALMOBILE);
            Cmd.Parameters.AddWithValue("@PERSONALTELL", Obj.PERSONALTELL);
            Cmd.Parameters.AddWithValue("@SHENASNAME", Obj.SHENASNAME);
            Cmd.Parameters.AddWithValue("@STUDYLEVEL", Obj.STUDYLEVEL);
            Cmd.Parameters.AddWithValue("@STYDUCOURCE", Obj.STYDUCOURCE);
            

            Cmd.ExecuteNonQuery();

            Con.Close();
            return true;
        }


        public List<string[]> Select_ProviderById(int Provider_Id)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAM where Provider_Id=" + Provider_Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["ID"].ToString();
                Str[1] = SqlRd["Provider_Id"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }

        public bool Delete_Provider(int Provider_Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete providers where Id=" + Provider_Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }

    }
}
