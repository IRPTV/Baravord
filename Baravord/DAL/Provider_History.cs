using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class Provider_HistoryDal
    {
        //public bool Insert_Program_CopyRight(Program_CopyRightObj InObj, ProgramObj ProgObjInput)
        //{
        //    try
        //    {
        //        SqlConnection Con = DataBaseTools.CreateSqlConnection();
        //        Con.Open();

        //        SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_COPYRIGHT", Con);
        //        Cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        Cmd.Parameters.Clear();
        //        Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
        //        Cmd.Parameters.AddWithValue("@Title", InObj.Title);
        //        Cmd.Parameters.AddWithValue("@VALUE", InObj.ValuePercent);
        //        Cmd.ExecuteScalar();

        //        Con.Close();
        //    }
        //    catch (Exception exp)
        //    {
        //        System.Windows.Forms.MessageBox.Show(exp.Message);
        //        return false;
        //    }
        //    return true;

        //}

        public List<Provider_HistoryObj> Select_Provider_History(ProviderObj Provider)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Provider_History";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Provider_Id", Provider.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<Provider_HistoryObj> Lst = new List<Provider_HistoryObj>();
          

            while (SqlRd.Read())
            {
                Provider_HistoryObj Obj = new Provider_HistoryObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.BUILD_DATETIME = SqlRd["BUILD_DATETIME"].ToString();
                Obj.CHANNELS = SqlRd["CHANNELS"].ToString();
                Obj.LEVEL = SqlRd["LEVEL"].ToString();
                Obj.PLAY_DATETIME = SqlRd["PLAY_DATETIME"].ToString();
                Obj.PROVIDER_ID = int.Parse(SqlRd["PROVIDER_ID"].ToString());
                Obj.ROLE = SqlRd["ROLE"].ToString();
                Obj.SESSION = SqlRd["SESSION"].ToString();
                Obj.SESSION_TIME = SqlRd["SESSION_TIME"].ToString();
                Obj.STRUCTURE = SqlRd["STRUCTURE"].ToString();
                Obj.Subject = SqlRd["Subject"].ToString();
                Obj.Title = SqlRd["Title"].ToString();

                Lst.Add(Obj);
            }
            Con.Close();
            return Lst;
        }


        public Provider_HistoryObj Select_Current_Provider_History(int HistoryId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Provider_History";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Id", HistoryId);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            Provider_HistoryObj Obj = new Provider_HistoryObj();
            while (SqlRd.Read())
            {           
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.BUILD_DATETIME = SqlRd["BUILD_DATETIME"].ToString();
                Obj.CHANNELS = SqlRd["CHANNELS"].ToString();
                Obj.LEVEL = SqlRd["LEVEL"].ToString();
                Obj.PLAY_DATETIME = SqlRd["PLAY_DATETIME"].ToString();
                Obj.PROVIDER_ID = int.Parse(SqlRd["PROVIDER_ID"].ToString());
                Obj.ROLE = SqlRd["ROLE"].ToString();
                Obj.SESSION = SqlRd["SESSION"].ToString();
                Obj.SESSION_TIME = SqlRd["SESSION_TIME"].ToString();
                Obj.STRUCTURE = SqlRd["STRUCTURE"].ToString();
                Obj.Subject = SqlRd["Subject"].ToString();
                Obj.Title = SqlRd["Title"].ToString();
                
            }
            Con.Close();
            return Obj;
        }




        public bool Insert_Provider_History(Provider_HistoryObj HistoryObject)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Provider_History";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            //SelectCmd.Parameters.AddWithValue("@Id", HistoryId);
            SelectCmd.Parameters.AddWithValue("@BUILD_DATETIME", HistoryObject.BUILD_DATETIME);
            SelectCmd.Parameters.AddWithValue("@CHANNELS", HistoryObject.CHANNELS);
            SelectCmd.Parameters.AddWithValue("@PLAY_DATETIME", HistoryObject.PLAY_DATETIME);
            SelectCmd.Parameters.AddWithValue("@LEVEL", HistoryObject.LEVEL);
            SelectCmd.Parameters.AddWithValue("@PROVIDER_ID", HistoryObject.PROVIDER_ID);
            SelectCmd.Parameters.AddWithValue("@ROLE", HistoryObject.ROLE);
            SelectCmd.Parameters.AddWithValue("@SESSION", HistoryObject.SESSION);
            SelectCmd.Parameters.AddWithValue("@SESSION_TIME", HistoryObject.SESSION_TIME);
            SelectCmd.Parameters.AddWithValue("@STRUCTURE", HistoryObject.STRUCTURE);
            SelectCmd.Parameters.AddWithValue("@Subject", HistoryObject.Subject);
            SelectCmd.Parameters.AddWithValue("@Title", HistoryObject.Title);

            SelectCmd.ExecuteNonQuery();

            Con.Close();
            return true;
        }

        public bool Update_Provider_History(Provider_HistoryObj HistoryObject)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Update_Provider_History";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            //SelectCmd.Parameters.AddWithValue("@Id", HistoryId);
            SelectCmd.Parameters.AddWithValue("@BUILD_DATETIME", HistoryObject.BUILD_DATETIME);
            SelectCmd.Parameters.AddWithValue("@CHANNELS", HistoryObject.CHANNELS);
            SelectCmd.Parameters.AddWithValue("@PLAY_DATETIME", HistoryObject.PLAY_DATETIME);
            SelectCmd.Parameters.AddWithValue("@LEVEL", HistoryObject.LEVEL);
            SelectCmd.Parameters.AddWithValue("@PROVIDER_ID", HistoryObject.PROVIDER_ID);
            SelectCmd.Parameters.AddWithValue("@ROLE", HistoryObject.ROLE);
            SelectCmd.Parameters.AddWithValue("@SESSION", HistoryObject.SESSION);
            SelectCmd.Parameters.AddWithValue("@SESSION_TIME", HistoryObject.SESSION_TIME);
            SelectCmd.Parameters.AddWithValue("@STRUCTURE", HistoryObject.STRUCTURE);
            SelectCmd.Parameters.AddWithValue("@Subject", HistoryObject.Subject);
            SelectCmd.Parameters.AddWithValue("@Title", HistoryObject.Title);
            SelectCmd.Parameters.AddWithValue("@id", HistoryObject.Id);

            SelectCmd.ExecuteNonQuery();

            Con.Close();
            return true;
        }

        public bool Delete_Provider_History(int Provider_Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete PROVIDERS_HISTORY where Provider_Id=" + Provider_Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }

    }
}
