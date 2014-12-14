using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Baravord.TOOLS
{
    class DataBaseTools
    {
        public DataBaseTools()
        {

        }

        public static  SqlConnection CreateSqlConnection()
        {
            SqlConnection SqlCon = new SqlConnection("Data Source=192.168.100.73;Initial Catalog=Baravord1;User Id=bar;Password=bar;");
            return SqlCon;
            
        }
    }
}
