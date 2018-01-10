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
    [System.Web.Script.Services.ScriptService]
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ArrayList Get()
        {
            CustomerPercistance pp = new CustomerPercistance();
            return pp.getCustomer();
        }

        // GET: api/Customer/5
        [HttpGet]              
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Customer Get(long id)
        {
            CustomerPercistance pp = new CustomerPercistance();
            Customer Customer = pp.getCustomer(id);
            return Customer;
        }

        // POST: api/Customer
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            bool recordExisted = false;
            CustomerPercistance pp = new CustomerPercistance();
            recordExisted= pp.saveCustomer(value);
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

        // PUT: api/Customer/5
        [HttpPut]
        public HttpResponseMessage Put(long id, [FromBody]Customer value)
        {
            CustomerPercistance pp = new CustomerPercistance();
            bool recordExisted = false;
            recordExisted = pp.updateCustomer(id,value);
            HttpResponseMessage response;

            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);

            }
            return response;

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public HttpResponseMessage Delete(long id)
        {
            CustomerPercistance pp = new CustomerPercistance();
            bool recordExisted=false;
            recordExisted = pp.deleteCustomer(id);
            HttpResponseMessage response;

            if (recordExisted)
            {
                response= Request.CreateResponse(HttpStatusCode.NoContent);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);

            }
            return response;
        }

        [Route("api/login")]
        [HttpPost]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HttpResponseMessage checkLogin([FromBody]Customer value)
        {
            bool recordExisted = false;
            HttpResponseMessage response;
            CustomerPercistance pp = new CustomerPercistance();
            recordExisted= pp.checkLogin(value.contactNo,value.password);
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);

            }
            return response;
        }


    }
   
}
