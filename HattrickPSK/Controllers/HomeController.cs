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

        DAL dataAcces = new DAL();
        ResponseMessages responseMessages = new ResponseMessages();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {          
            return Json(dataAcces.GetEvent(),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TicketRecive(ICollection<TicketEvent> choosenEvents, string totalOdds, bool bonus5, bool bonus10, string betAmount)
        {
            AddTicket newTicket = new AddTicket(Convert.ToInt32(Session["UserID"]));
            
            if (newTicket.checkBalance(betAmount))            
                if (newTicket.MakeTransaction(choosenEvents, totalOdds, bonus5, bonus10))
                    return Json(JsonRequestBehavior.AllowGet);
                else
                    Response.Write(responseMessages.TransactionErrorMessage());                    
                       
            Response.Write(responseMessages.InsufficientlyBalance());

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
