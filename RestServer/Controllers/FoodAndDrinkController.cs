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
    public class FoodAndDrinkController : ApiController
    {
               
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


        [Route("api/loadfood")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ArrayList loadfood()
        {
            FoodAndDrinkPercistance pp = new FoodAndDrinkPercistance();
            return pp.loadFood();
        }


        [Route("api/loaddrink")]
       
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ArrayList loaddrink()
        {
            FoodAndDrinkPercistance pp = new FoodAndDrinkPercistance();
            return pp.loadDrink();
        }
       
        [Route("api/getdrink/{drinkId:int}")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Drink loadDrinkDetails(int drinkId)
        {
            FoodAndDrinkPercistance pp = new FoodAndDrinkPercistance();
            Drink cc = pp.loadDrinkDetails(drinkId);
            return cc;
        }

        [Route("api/getfood/{foodId:int}")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Food loadFoodDetails(int foodId)
        {
            FoodAndDrinkPercistance pp = new FoodAndDrinkPercistance();
            Food cc = pp.loadFoodDetails(foodId);
            return cc;
        }
    }
}
