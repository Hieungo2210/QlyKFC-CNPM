using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection connect()
        {

            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbQLNH_KFC;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connetionString);
            return conn;
        }

    }
    public class TaiKhoanDAL
    {
        SqlConnectionData sql = new SqlConnectionData();
    }
}