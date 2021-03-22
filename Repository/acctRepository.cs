using Dapper;
using JobProject.JsonModels;
using JobProject.JsonModels.GetBalance;
using JobProject.JsonModels.Transfer;
using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobProject.Repository
{
    public class acctRepository
    {

        //authorize request
        public Wallet AuthorizeRequest(authorizeRequest request)
        {

            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            using (var con = new SqlConnection(connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("acctId", request.acctId);
                var execute = con.Query<Wallet>("authorizeRequest", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return execute;
            }



        }
        //end of authorize request

        //get balance
        public Wallet GetBalanceRequest(GetBalanceRequest request)
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            using (var con = new SqlConnection(connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("acctId", request.AcctId);
                var execute = con.Query<Wallet>("authorizeRequest", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return execute;
            }
        }
        //end of get balance


        //transfer

        //type1
        public int Bet(TransferRequest request)
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            using (var con = new SqlConnection(connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("transferId", request.TransferId);
                param.Add("acctId", request.AcctId);
                param.Add("currency", request.Currency);
                param.Add("amount", request.Amount);
                param.Add("type", request.Type);
                param.Add("channel", request.Channel);
                param.Add("ticketId", request.TicketId);
                param.Add("referenceId", request.ReferenceId);
                param.Add("refTicketIds", request.RefTicketIds);
                param.Add("gameCode", request.GameCode);
                param.Add("CurrentBalance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
                param.Add("MerchantTxId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var execute = con.Execute("Bet", param, commandType: CommandType.StoredProcedure);

                int returnValue = param.Get<int>("ReturnValue");

                decimal currentBalance = param.Get<decimal>("CurrentBalance");
                request.CurrentBalance = currentBalance;

                int merchantTxId = param.Get<int>("MerchantTxId");
                request.MerchantTxId = merchantTxId;

                return returnValue;
            }

        }
        //end of type1

        //type4
        public int Payout(TransferRequest request)
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            using (var con = new SqlConnection(connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("transferId", request.TransferId);
                param.Add("acctId", request.AcctId);
                param.Add("currency", request.Currency);
                param.Add("amount", request.Amount);
                param.Add("type", request.Type);
                param.Add("channel", request.Channel);
                param.Add("ticketId", request.TicketId);
                param.Add("referenceId", request.ReferenceId);
                param.Add("refTicketIds", request.RefTicketIds);
                param.Add("gameCode", request.GameCode);
                param.Add("CurrentBalance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
                param.Add("MerchantTxId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var execute = con.Execute("Payout", param, commandType: CommandType.StoredProcedure);

                decimal currentBalance = param.Get<decimal>("CurrentBalance");
                request.CurrentBalance = currentBalance;

                int merchantTxId = param.Get<int>("MerchantTxId");
                request.MerchantTxId = merchantTxId;

                int returnValue = param.Get<int>("ReturnValue");

                return returnValue;
            }

        }
        //end of type4

        //type 2
        public int Cancel(TransferRequest request)
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            using (var con = new SqlConnection(connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("transferId", request.TransferId);
                param.Add("acctId", request.AcctId);
                param.Add("currency", request.Currency);
                param.Add("amount", request.Amount);
                param.Add("type", request.Type);
                param.Add("channel", request.Channel);
                param.Add("ticketId", request.TicketId);
                param.Add("referenceId", request.ReferenceId);
                param.Add("refTicketIds", request.RefTicketIds);
                param.Add("gameCode", request.GameCode);
                param.Add("CurrentBalance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
                param.Add("MerchantTxId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var execute = con.Execute("Cancel", param, commandType: CommandType.StoredProcedure);

                decimal currentBalance = param.Get<decimal>("CurrentBalance");
                request.CurrentBalance = currentBalance;

                int merchantTxId = param.Get<int>("MerchantTxId");
                request.MerchantTxId = merchantTxId;

                int returnValue = param.Get<int>("ReturnValue");

                return returnValue;
            }
            //end of type 2

            //end of transfer

        }
    }
}