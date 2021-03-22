using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels.GetBalance
{
    public class GetBalanceRequest
    {
        public string AcctId { get; set; }
        public string MerchantCode { get; set; }
        public string SerialNo { get; set; }
        public string GameCode { get; set; }
    }
}