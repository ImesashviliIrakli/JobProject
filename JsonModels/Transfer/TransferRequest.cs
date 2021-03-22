using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.JsonModels.Transfer
{
    public class TransferRequest
    {
        public string TransferId { get; set; }
        public string AcctId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }
        public string Channel { get; set; }
        public string GameCode { get; set; }
        public string MerchantCode { get; set; }
        public string TicketId { get; set; }
        public string ReferenceId { get; set; }
        public SpecialGame SpecialGame { get; set; }
        public string RefTicketIds { get; set; }
        public string SerialNo { get; set; }
        public decimal CurrentBalance { get; set; }
        public int MerchantTxId { get; set; }
    }
}