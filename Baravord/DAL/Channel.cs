using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;



namespace Baravord.DAL
{
    class ChannelDAl
    {
        public List<ChannelObj> Select_All_Channels()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();        
            Con.Open();

            string Cmd="Select * from Channels Order by sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<ChannelObj> ChannelLst = new List<ChannelObj>();

            while (SqlRd.Read())
            {
                ChannelObj Obj=new ChannelObj ();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title =SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Obj.LogoUrl = SqlRd["LogoUrl"].ToString();

                ChannelLst.Add(Obj);
            }
            Con.Close();
            return ChannelLst;
        }
        public ChannelObj Select_Current_Channel(int ChannelId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Channels where id="+ChannelId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();
            ChannelObj Obj = new ChannelObj();
           

            while (SqlRd.Read())
            {
           
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Obj.LogoUrl = SqlRd["LogoUrl"].ToString();
                Obj.Number = SqlRd["Number"].ToString();              
            }
            Con.Close();
            return Obj;
        }
        public bool UPDATE_CURRENT_CHANNEL(ChannelObj Chn)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("UPDATE_CURRENT_CHANNEL", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Chn.Title);
                Cmd.Parameters.AddWithValue("@SORT", Chn.Sort);
                Cmd.Parameters.AddWithValue("@LOGOURL", Chn.LogoUrl);
                Cmd.Parameters.AddWithValue("@NUMBER", Chn.Number);
                Cmd.Parameters.AddWithValue("@ID", Chn.Id);             

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
        public bool INSERT_CHANNEL(ChannelObj Chn)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("INSERT_CHANNEL", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Chn.Title);
                Cmd.Parameters.AddWithValue("@SORT", Chn.Sort);
                Cmd.Parameters.AddWithValue("@LOGOURL", Chn.LogoUrl);
                Cmd.Parameters.AddWithValue("@NUMBER", Chn.Number);
            
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
    }

}
