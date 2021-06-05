using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;
using System.Web.Security;

namespace HattrickPSK.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private IDataAccess dataAccess;
        public WalletController(IDataAccess _db)
        {
            dataAccess = _db;
        }
        // GET: Wallet
        public ActionResult Wallet()
        {
            return View();
        }
             
        [HttpGet]     
        public JsonResult GetTicket()
        {           
            return Json(dataAccess.getTicket(Convert.ToInt32(Session["UserID"])),JsonRequestBehavior.AllowGet);                              
        }     
    }
}