using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels
{
    public class authorizeResponse
    {
        public Wallet acctInfo { get; set; }
        public string merchantCode { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public string serialNo { get; set; }
    }
}