using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace USOM.Helper
{
    public static class QueryRepository<T>
    {
        public static IList<T> GetList(string query)
        {
            IList<T> result = new List<T>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["USOMConnection"].ConnectionString))
            {
                result = connection.Query<T>(query).ToList();
            }

            return result;
        }

        public static T GetSingleData(string query)
        {
            T result;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["USOMConnection"].ConnectionString))
            {
                result = connection.Query<T>(query).FirstOrDefault();
            }

            return result;
        }
    }
}