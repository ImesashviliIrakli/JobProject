using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels.GetBalance
{
    public class GetBalanceResponse
    {
        public Wallet acctInfo { get; set; }
        public string merchantCode { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public string serialNo { get; set; }
    }
}