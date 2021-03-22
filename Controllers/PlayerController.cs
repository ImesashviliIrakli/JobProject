using JobProject.Models;
using JobProject.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using JobProject.Data;
using System.Threading.Tasks;
using JobProject.JsonModels;
using Newtonsoft.Json;
using JobProject.JsonModels.GetBalance;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using JobProject.JsonModels.Transfer;

namespace JobProject.Controllers
{
    public class PlayerController : Controller
    {


        public SqlConnection con;

        //connection
        private void connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
            con = new SqlConnection(connection);
        }
        //end of connection




        //authorize request
        [HttpPost]
        public ActionResult AuthorizeRequest()
        {
            authorizeRequest request = new authorizeRequest();
            acctRepository acctRepo = new acctRepository();
            authorizeResponse response = new authorizeResponse();

            //Input stream

            using (Stream stream = Request.InputStream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    request = JsonConvert.DeserializeObject<authorizeRequest>(reader.ReadToEnd());
                }
            }

            //end of Input stream

            var wallet = acctRepo.AuthorizeRequest(request);

            //validation
            if (wallet == null)
            {
                response.merchantCode = request.merchantCode;
                response.serialNo = request.serialNo;
                response.msg = "account not found";
                response.code = 50100;
                return Json(response);
            }

            response.acctInfo = wallet;
            response.merchantCode = request.merchantCode;
            response.serialNo = request.serialNo;
            response.msg = "success";
            response.code = 0;



            //end of validation

            return Json(response);



        }
        //end of authorize request

        //get balance request
        [HttpPost]
        public ActionResult GetBalanceRequest()
        {
            GetBalanceRequest getRequest = new GetBalanceRequest();
            acctRepository acctRepo = new acctRepository();
            GetBalanceResponse response = new GetBalanceResponse();

            //Input stream

            using (Stream stream = Request.InputStream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    getRequest = JsonConvert.DeserializeObject<GetBalanceRequest>(reader.ReadToEnd());

                }
            }

            //end of Input stream

            var balance = acctRepo.GetBalanceRequest(getRequest);

            //validation
            if (balance == null)
            {
                response.merchantCode = getRequest.MerchantCode;
                response.serialNo = getRequest.SerialNo;
                response.msg = "Account Not Found ";
                response.code = 50100;
                return Json(response);
            }

            response.acctInfo = balance;
            response.merchantCode = getRequest.MerchantCode;
            response.serialNo = getRequest.SerialNo;
            response.msg = "Success";
            response.code = 0;



            //end of validation

            return Json(response);



        }
        //end of get balance request

        //transfer request
        [HttpPost]
        public ActionResult Transfer()
        {
            TransferRequest request = new TransferRequest();
            acctRepository acctRepo = new acctRepository();
            TransferResponse response = new TransferResponse();

            using (Stream stream = Request.InputStream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    request = JsonConvert.DeserializeObject<TransferRequest>(reader.ReadToEnd());
                }
            }

            var repoResponse = new object();

            if (request.Type == 1)
            {
                repoResponse = acctRepo.Bet(request);
            }
            if (request.Type == 4)
            {
                repoResponse = acctRepo.Payout(request);
            }
            if (request.Type == 2)
            {
                repoResponse = acctRepo.Cancel(request);
            }

            if ((int)repoResponse == 50100)
            {
                response.Msg = "Account Not Found";
                response.Code = 50100;
                return Json(response);

            }

            if ((int)repoResponse == 5)
            {
                response.Msg = "TransferId can not be the same";
                response.Code = 5;
                return Json(response);
            }

            if ((int)repoResponse == 100)
            {
                response.Msg = "Not enough money in balance";
                response.Code = 100;
                return Json(response);
            }

            if ((int)repoResponse == 80)
            {
                response.Msg = "This transferid has already been canceled";
                response.Code = 80;
                return Json(response);
            }
            if ((int)repoResponse == 50)
            {
                response.Msg = "TransferId does not  Exists";
                response.Code = 50;
                return Json(response);
            }
            if ((int)repoResponse == 90)
            {
                response.Msg = "amount does not equal old amount";
                response.Code = 90;
                return Json(response);
            }
            if ((int)repoResponse == 33)
            {
                response.Msg = "Currency must match old transfer Currency";
                response.Code = 33;
                return Json(response);
            }
            if ((int)repoResponse == 45)
            {
                response.Msg = "type 4 can not be canceled nor changed at all";
                response.Code = 45;
                return Json(response);
            }
            if ((int)repoResponse == 22)
            {
                response.Msg = "Currency does not match";
                response.Code = 22;
                return Json(response);
            }


            response.TransferId = request.TransferId;
            response.MerchantTxId = request.MerchantTxId;
            response.AcctId = request.AcctId;
            response.Balance = request.CurrentBalance;
            response.MerchantCode = request.MerchantCode;
            response.Code = 0;
            response.Msg = "Success";
            response.SerialNo = request.SerialNo;



            return Json(response);

        }
        //end of transfer request



    }
}