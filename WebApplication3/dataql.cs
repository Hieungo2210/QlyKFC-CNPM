using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class dataql
    {
        public static SqlConnection connect()
        {
            string cnstr = @"Data Source=TRANHAU-PC;Initial Catalog=dbQLNH_KFC;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cnstr);
            return conn;
        }
    }
}