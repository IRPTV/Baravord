using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Baravord.TOOLS
{
    class GetDate
    {
        public static DateTime GetDateTime()
        {
            SqlConnection Con = DataBaseTools.CreateSqlConnection();
            Con.Open();

            string Cmd = "select GETDATE()";
            SqlCommand SelectCmd = new SqlCommand(Cmd, Con);

            DateTime Dt = DateTime.Parse(SelectCmd.ExecuteScalar().ToString());
            
            Con.Close();
            return Dt;           
        }
    }
}
