using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;


namespace Baravord.DAL
{
    class NotifyDal
    {
        public List<NotifyObj> Select_All_Notify(int kind)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();        
            Con.Open();

            string Cmd = "Select * from Notify where kind="+kind.ToString()+" Order by sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<NotifyObj> NotifyLst = new List<NotifyObj>();

            while (SqlRd.Read())
            {
                NotifyObj Obj = new NotifyObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());                

                NotifyLst.Add(Obj);
            }
            Con.Close();
            return NotifyLst;
        }
        public void Delete_All_Program_Notify( ProgramObj ProgObjInput)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            SqlCommand CmdDel = new SqlCommand("Delete_Program_All_Notify", Con);
            CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
            CmdDel.Parameters.Clear();
            CmdDel.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
            CmdDel.ExecuteScalar();
        }
        public bool Insert_Program_Notify(List<NotifyObj> InLst, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                foreach (NotifyObj item in InLst)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_Notify", Con);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                    Cmd.Parameters.AddWithValue("@Notify_ID", item.Id);
                    Cmd.ExecuteScalar();
                }
                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true; 

        }
        public List<NotifyObj> Select_Program_Notify(ProgramObj ProgObjInput)
        {
            SqlConnection Con = new SqlConnection();
            NotifyObj Obj = new NotifyObj();
            List<NotifyObj> NotifyLst = new List<NotifyObj>();
            try
            {
                Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand SelectCmd = new SqlCommand("Select_Program_Notify", Con);
                SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SelectCmd.Parameters.AddWithValue("@Program_Id", ProgObjInput.Id);                

                SqlDataReader SqlRd = SelectCmd.ExecuteReader();
                while (SqlRd.Read())
                {
                    Obj = new NotifyObj();
                    Obj.Id = int.Parse(SqlRd["Notify_ID"].ToString());
                    NotifyLst.Add(Obj);
                }
                Con.Close();
            }
            catch (Exception Exp)
            {
                Con.Close();
                System.Windows.Forms.MessageBox.Show(Exp.Message); ;
            }


            return NotifyLst;
        }

        public NotifyObj Select_Current_Notify(int NotifyId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Notify";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Id", NotifyId);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            NotifyObj Level = new NotifyObj();

            while (SqlRd.Read())
            {

                Level.Id = int.Parse(SqlRd["Id"].ToString());
                Level.Title = SqlRd["Title"].ToString();
                Level.Sort = int.Parse(SqlRd["Sort"].ToString());

            }
            Con.Close();
            return Level;
        }
        public bool Update_Current_Notify(NotifyObj Not)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_Notify", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Not.Title);
                Cmd.Parameters.AddWithValue("@SORT", Not.Sort);
                Cmd.Parameters.AddWithValue("@Id", Not.Id);

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
        public bool Insert_Notify_Base(NotifyObj Not)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Notify_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Title", Not.Title);
            SelectCmd.Parameters.AddWithValue("@Sort", Not.Sort);
            SelectCmd.Parameters.AddWithValue("@Kind", Not.Kind);


            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }

        public List<string[]> Select_NotifiesById(int NotifyId)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAME_NOTIFY where NOTIFY_Id=" + NotifyId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["PROGRAM_ID"].ToString();
                Str[1] = SqlRd["NOTIFY_Id"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }

        public bool Delete_Notify(int NotifyId)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete notify where Id=" + NotifyId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }



    }
}
