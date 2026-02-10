using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentalRoom.DataAccess
{
    public static class DbHelper
    {
        private static readonly string _connection = ConfigurationManager.ConnectionStrings["RentalRoom"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connection);
        }
    }
}