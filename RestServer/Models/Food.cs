using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace RestServer.Models
{
   
    public class Food 
    {
        public int foodId   { get; set;}

        public String foodName { get; set; }

        public int foodPrice { get; set; }

        

    }
}