using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class DepsDal
    {
        public List<DepsObj> Select_All_DepsByChannelId(int ChannelId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Deps where ChannelId="+ChannelId.ToString()+" Order by title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<DepsObj> DepsLst = new List<DepsObj>();

            while (SqlRd.Read())
            {
                DepsObj Obj = new DepsObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.ChannelId = int.Parse(SqlRd["ChannelId"].ToString());
                


                DepsLst.Add(Obj);
            }
            Con.Close();
            return DepsLst;


        }
        public DepsObj Select_Current_Deps(int Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Deps where id=" + Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            DepsObj Obj = new DepsObj();

            while (SqlRd.Read())
            {
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();                
            }

            Con.Close();
            return Obj;
        }
        public bool Update_Current_Deps(DepsObj Obj)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update Deps set Title=N'"+Obj.Title+"' where id="+Obj.Id.ToString(), Con);
                Cmd.CommandType = System.Data.CommandType.Text;
                
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
        public bool Insert_Deps_Base(DepsObj Obj)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert into Deps (Title,ChannelId) values (N'"+Obj.Title+"' ,"+Obj.ChannelId.ToString()+" )";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;          
            SelectCmd.ExecuteScalar();
            Con.Close();
            return true;
        }

     

        public bool Delete_Deps(int DepId)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete Deps where Id=" + DepId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
            
    }
}
