using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace RestServer.Models
{
   
    public class Table 
    {
        public int resrvId { get; set;}

        public int contactNo { get; set; }

        public int tableNo { get; set; }

        public int pcount { get; set; }

        public String rdate { get; set; }

        public String stime { get; set; }

        public String etime { get; set; }

    }
}