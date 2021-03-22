using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels.Transfer
{
    public class TransferResponse
    {
        public string TransferId { get; set; }
        public int MerchantTxId { get; set; }
        public string MerchantCode { get; set; }
        public string AcctId { get; set; }
        public decimal Balance { get; set; }
        public string Msg { get; set; }
        public int Code { get; set; }
        public string SerialNo {  get; set; }
    }
}