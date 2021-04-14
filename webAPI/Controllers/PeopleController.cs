using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class PeopleController : BaseController
    {
        private string tableName = "people";
        public PeopleController() : base("sql") { }

        [HttpGet]
        [Route("api/people/")]
        public IHttpActionResult Get()
        {
            try
            {
                List<Person> result = GetMultiple<Person>("select * from " + tableName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/people/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Person result = GetSingle<Person>("select * from " + tableName + " where id = @ID",
                    new { ID = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Person person) 
        {
            try
            {

            }
            catch (Exception ex) 
            {
                return InternalServerError(ex);
            }
        }
    }
}
