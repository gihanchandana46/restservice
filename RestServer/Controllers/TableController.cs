using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServer.Models;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Http.Results;
using System.Web.Http.Cors;

namespace RestServer.Controllers
{
    public class TableController : ApiController
    {
        // GET: api/Table
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Table/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Table
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Table value)
        {
            bool recordExisted = false;
            TablePercistance pp = new TablePercistance();
            recordExisted = pp.saveTable(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.Found);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.Created);

            }
            return response;

        }

        // PUT: api/Table/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Table/5
        public void Delete(int id)
        {
        }


        [Route("api/freetable")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ArrayList GetTableSts()
        {
            TablePercistance pp = new TablePercistance();
            return pp.freeTable();
        }
    }
}
