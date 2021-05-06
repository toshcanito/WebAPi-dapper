using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace webAPI.Controllers
{
    public class BaseController : ApiController
    {
        private string _dbsp = string.Empty;

        public BaseController(string dbsp)
        {
            _dbsp = dbsp;
        }

        protected List<T> GetMultiple<T>(string query, object parameters = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Invalid query string for GetMultiple");
            }
            using (var con = ConnectionFactory.GetConnection(_dbsp))
            {
                con.Open();
                List<T> res = con.Query<T>(query, parameters).ToList();
                return res;
            }
        }

        protected T GetSingle<T>(string query, object parameters = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Invalid query string for GetSingle");
            }
            using (var con = ConnectionFactory.GetConnection(_dbsp))
            {
                con.Open();
                T res = con.QueryFirstOrDefault<T>(query, parameters);
                return res;
            }
        }

        protected bool Excecute(string query, object parameters = null, bool isSP = false)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Invalid query string for Excecute");
            }
            using (var con = ConnectionFactory.GetConnection(_dbsp))
            {
                var res = con.Execute(query, parameters,
                    commandType: (isSP) ? CommandType.StoredProcedure : CommandType.Text) > 0;

                return res;
            }
        }
    }
}
