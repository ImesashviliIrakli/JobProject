using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class Wallet
    {
        public string acctId { get; set; }
        public decimal balance { get; set; }
        public string currency { get; set; }
    }
}