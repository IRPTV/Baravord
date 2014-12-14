using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class LevelDal
    {
        public List<LevelObj> Select_All_Level()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Level Order by Sort";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<LevelObj> Levels = new List<LevelObj>();

            while (SqlRd.Read())
            {
                LevelObj Obj = new LevelObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Obj.Sort = int.Parse(SqlRd["Sort"].ToString());
                Levels.Add(Obj);
            }
            Con.Close();
            return Levels;
        }
        public bool Insert_Program_Level(List<LevelObj> InLst, ProgramObj ProgObjInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand CmdDel = new SqlCommand("Delete_Program_All_Levels", Con);
                CmdDel.CommandType = System.Data.CommandType.StoredProcedure;
                CmdDel.Parameters.Clear();
                CmdDel.Parameters.AddWithValue("@PROGRAM_ID", ProgObjInput.Id);
                CmdDel.ExecuteScalar();

                foreach (LevelObj item in InLst)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_PROGRAM_LEVELS", Con);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("@PROGRAME_ID", ProgObjInput.Id);
                    Cmd.Parameters.AddWithValue("@LEVEL_ID", item.Id);
                    Cmd.ExecuteScalar();
                }
                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true; ;

        }
        public List<LevelObj> Select_All_Program_Levels(ProgramObj Prog)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_All_Program_Levels";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Program_Id", Prog.Id);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<LevelObj> Levels = new List<LevelObj>();

            while (SqlRd.Read())
            {
                LevelObj Obj = new LevelObj();
                Obj.Id = int.Parse(SqlRd["Level_Id"].ToString());
                Levels.Add(Obj);
            }
            Con.Close();
            return Levels;
        }
        public LevelObj Select_Current_Level(int LvlId)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select_Current_Level";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@LevelId", LvlId);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            LevelObj Level = new LevelObj();

            while (SqlRd.Read())
            {

                Level.Id = int.Parse(SqlRd["Id"].ToString());
                Level.Title = SqlRd["Title"].ToString();
                Level.Sort = int.Parse(SqlRd["Sort"].ToString());

            }
            Con.Close();
            return Level;
        }
        public bool Update_Current_Level(LevelObj Lvl)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_Level", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Lvl.Title);
                Cmd.Parameters.AddWithValue("@SORT", Lvl.Sort);
                Cmd.Parameters.AddWithValue("@LevelId", Lvl.Id);

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
        public bool Insert_Level_INLVL(LevelObj Lvl)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Level_INLVL";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Title", Lvl.Title);
            SelectCmd.Parameters.AddWithValue("@Sort", Lvl.Sort);

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }
        public List<string[]> Select_Levels(int LvlId)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAM_LEVEL where level_Id=" + LvlId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["PROGRAM_ID"].ToString();
                Str[1] = SqlRd["LEVEL_ID"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }

        public bool Delete_Level(int LvlId)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete LEVEL where Id=" + LvlId.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
    }
}
