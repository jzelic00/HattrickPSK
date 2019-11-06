using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;
namespace HattrickPSK.Controllers
{    
    public class WalletController : Controller
    {

        DAL dataAcces = new DAL();
        // GET: Wallet
        public ActionResult Wallet()
        {
            return View();
        }
             
        [HttpGet]     
        public JsonResult GetTicket()
        {                              
           return Json(dataAcces.getTicket(Convert.ToInt32(Session["UserID"])),JsonRequestBehavior.AllowGet);                              
        }     
    }
}