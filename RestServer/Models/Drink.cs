using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace RestServer.Models
{
   
    public class Drink 
    {
        public int drinkId   { get; set;}

        public String drinkName { get; set; }

        public int drinkPrice { get; set; }

        

    }
}