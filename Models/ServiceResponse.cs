using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class ServiceResponse<T>
    {
        public string acctId { get; set; }
        public string username { get; set; }
        public float Balance { get; set; }
        public string Currency { get; set; }
    }
}