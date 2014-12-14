using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class SignDal
    {
        public List<SignObj> Select_All_SignByChannelId(SignObj SObj)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from  Sign where ChannelId=" + SObj.ChannelID.ToString() +
                " and PageTitle='"+SObj.PageTitle+"' Order by Sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<SignObj> DepsLst = new List<SignObj>();

            while (SqlRd.Read())
            {
                SignObj Obj = new SignObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.PageTitle = SqlRd["PageTitle"].ToString();
                Obj.ChannelID = int.Parse(SqlRd["ChannelId"].ToString());
                Obj.RoleId = int.Parse(SqlRd["RoleId"].ToString());
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());                

                DepsLst.Add(Obj);
            }
            Con.Close();
            return DepsLst;


        }

        public bool Insert_Sign_Base(SignObj Obj)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert into Sign (PageTitle,RoleId,Sort,ChannelId) values (N'" + Obj.PageTitle + "' , "
                + Obj.RoleId + " , " + Obj.Sort + " , " + Obj.ChannelID + ")";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteScalar();
            Con.Close();
            return true;
        }


        public SignObj Select_Current_Sign(int Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Sign where id=" + Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            SignObj Obj = new SignObj();

            while (SqlRd.Read())
            {
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.RoleId = int.Parse(SqlRd["RoleId"].ToString());
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
            }

            Con.Close();
            return Obj;
        }
        public bool Update_Current_Sign(SignObj Obj)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update Sign set RoleId=" + Obj.RoleId + " , Sort="+Obj.Sort+" where id=" + Obj.Id.ToString(), Con);
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
        public bool Delete_Sign(int SignId)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete Sign where Id=" + SignId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
    }
}
