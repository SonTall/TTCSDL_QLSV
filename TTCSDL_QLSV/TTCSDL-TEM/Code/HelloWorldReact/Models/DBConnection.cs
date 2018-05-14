using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace HelloWorldReact.Models
{
    public class DBConnection
    {
        string con;
        public DBConnection()
        {
            con = ConfigurationManager.ConnectionStrings["TTCSDL"].ConnectionString;
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(con);
        }
    }
}