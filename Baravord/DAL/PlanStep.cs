using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class PlanStepDal
    {

        public List<PlanStepObj> Select_All_PlanStep()
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from Steps Order by title";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            List<PlanStepObj> Plan = new List<PlanStepObj>();

            while (SqlRd.Read())
            {
                PlanStepObj Obj = new PlanStepObj();
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
                Plan.Add(Obj);
            }
            Con.Close();
            return Plan;
        }

        public PlanStepObj Select_Current_PlanStep(int Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * from steps where id=" + Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            SqlDataReader SqlRd = SelectCmd.ExecuteReader();


            PlanStepObj Obj = new PlanStepObj();

            while (SqlRd.Read())
            {
                Obj.Id = int.Parse(SqlRd["Id"].ToString());
                Obj.Title = SqlRd["Title"].ToString();
            }

            Con.Close();
            return Obj;
        }
        public bool Update_Current_PlanStep(PlanStepObj Pym)
        {

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Current_PlanStep", Con);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Clear();


                Cmd.Parameters.AddWithValue("@TITLE", Pym.Title);
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
        public bool Insert_Step_Base(PlanStepObj Pym)
        {

            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Insert_Step_Base";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.StoredProcedure;

            SelectCmd.Parameters.AddWithValue("@Title", Pym.Title);

            SelectCmd.ExecuteScalar();


            Con.Close();

            return true;
        }

        public List<string[]> Select_PlanStepById(int PlanStep_Id)
        {

            List<string[]> Lst = new List<string[]>();
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "Select * From PROGRAM where PlanStep=" + PlanStep_Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;


            SqlDataReader SqlRd = SelectCmd.ExecuteReader();

            while (SqlRd.Read())
            {
                string[] Str = new string[2];
                Str[0] = SqlRd["ID"].ToString();
                Str[1] = SqlRd["PlanStep"].ToString();
                Lst.Add(Str);
            }
            Con.Close();
            return Lst;
        }

        public bool Delete_PlanStep(int PlanStep_Id)
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();
            string Cmd = "Delete Steps where Id=" + PlanStep_Id.ToString();
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);
            SelectCmd.CommandType = System.Data.CommandType.Text;
            SelectCmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }


    }

}

