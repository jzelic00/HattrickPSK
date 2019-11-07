using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.Services;

namespace HattrickPSK.Controllers
{
    public class RegistrationController : Controller
    {       
        // POST: Registration
        public ActionResult Index()
        {
            return View();
        }
       
        //saving new user data in database
        [HttpPost]
        public JsonResult SaveUser(User newUser)      
        {
            RegistrationService userRegistration = new RegistrationService();
            
            return Json(userRegistration.RegistrationMethod(newUser), JsonRequestBehavior.AllowGet);            
        }
    }
}