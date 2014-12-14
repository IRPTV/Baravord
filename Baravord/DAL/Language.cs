using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class LanguageDal
    {
        public List<LanguageObj> Select_All_Language()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Languages Order by Title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<LanguageObj> LanguageLst = new List<LanguageObj>();

            while (SqlRd.Read())
            {
                LanguageObj Obj = new LanguageObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();

                LanguageLst.Add(Obj);
            }
            Con.Close();
            return LanguageLst;
        }
        public LanguageObj Select_Current_Language(int LanguageId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Languages where id=" + LanguageId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();
            LanguageObj Obj = new LanguageObj();
            while (SqlRd.Read())
            {

                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();


            }
            Con.Close();
            return Obj;
        }
        public bool INSERT_LANGUAGE(LanguageObj Lang)
        {

            SqlConnection Con = new SqlConnection();
            StructureObj Obj = new StructureObj();
            List<StructureObj> Stracuture = new List<StructureObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("INSERT_LANGUAGE", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@TITLE", Lang.Title);


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

        public bool UPDATE_LANGUAGE(LanguageObj Lang)
        {

            SqlConnection Con = new SqlConnection();
            StructureObj Obj = new StructureObj();
            List<StructureObj> Stracuture = new List<StructureObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("UPDATE_LANGUAGE", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@TITLE", Lang.Title);
                SelectCmd.Parameters.AddWithValue("@ID", Lang.Id);


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

        public bool Delete_LANGUAGE(string LangId)
        {

            SqlConnection Con = new SqlConnection();                       
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("delete  Languages where Id=" + LangId, Con);
                SelectCmd.CommandType = System.Data.CommandType.Text;                
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
