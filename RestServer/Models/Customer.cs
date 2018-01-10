using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace RestServer.Models
{
   
    public class Customer 
    {
        public int contactNo { get; set; }

        public String firstName { get; set; }

        public String lastName { get; set; }       

        public String email { get; set; }

        public String address { get; set; }

        public String password { get; set; }

    }
}