using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Net4.DTO
{
    public class Connection
    {
        private static string stringConnection = @"Data Source=LAPTOP-VLT7V8GC\SQLEXPRESS;Initial Catalog=Net;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}

