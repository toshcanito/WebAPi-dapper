using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace webAPI
{
    public static class ConnectionFactory
    {
        public static DbConnection GetConnection(string dbsp) 
        {
            switch (dbsp) 
            {
                case "sql":
                    return new SqlConnection(ConfigurationManager.ConnectionStrings[dbsp].ConnectionString);
                default:
                    return null;
            }
        }
    }
}