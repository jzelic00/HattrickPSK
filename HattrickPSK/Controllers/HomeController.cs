using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;
using HattrickPSK.Services;
using HattrickPSK.Messages;

namespace HattrickPSK.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IDataAccess dataAccess;
        AddTicketServices newTicket;
        ITransactionErrorMessagess transactionErrorMessagess;
        IBalanceErrorMessagess balanceErrorMessagess;

        public HomeController(IDataAccess _db, IBalanceErrorMessagess _balanceErrorMessagess, ITransactionErrorMessagess _transactionErrorMessagess)
        {
            dataAccess = _db;
            balanceErrorMessagess= _balanceErrorMessagess;
            transactionErrorMessagess = _transactionErrorMessagess;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {          
            return Json(dataAccess.GetEvent(),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TicketRecive(ICollection<TicketEvent> choosenEvents, string totalOdds, bool bonus5, bool bonus10, string betAmount)
        {
            newTicket= new AddTicketServices(Convert.ToInt32(Session["UserID"]),dataAccess);
            
            if (newTicket.checkBalance(betAmount))            
                if (newTicket.MakeTransaction(choosenEvents, totalOdds, bonus5, bonus10))
                    return Json(JsonRequestBehavior.AllowGet);
                else
                    Response.Write(transactionErrorMessagess.TransactionErrorMessage());                    
                       
            Response.Write(balanceErrorMessagess.InsufficientlyBalance());

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
