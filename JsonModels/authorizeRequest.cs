using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels
{
    public class authorizeRequest
    {
        public string acctId { get; set; }
        public string language { get; set; }
        public string merchantCode { get; set; }
        public string token { get; set; }
        public string serialNo { get; set; }
        

    }
}