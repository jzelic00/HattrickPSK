using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    
    public class WalletController : Controller
    {

        
        // GET: Wallet
        public ActionResult Wallet()
        {
            return View();
        }
        
      
        [HttpGet]     
        public JsonResult GetTicket()
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            var dbConnection = new DatabaseContext();
           
            List<Ticket> allTicket = dbConnection.Ticket.ToList().FindAll(p => p.UserID == userId);
                    
           return Json(allTicket,JsonRequestBehavior.AllowGet);
                               
        }
      

    }
}