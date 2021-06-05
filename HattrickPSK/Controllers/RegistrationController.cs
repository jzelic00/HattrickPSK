using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.DataAcces;
using HattrickPSK.Models;
using HattrickPSK.Services;

namespace HattrickPSK.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IDataAccess dataAccess;
        IRegistrationService userRegistration;
        public RegistrationController(IDataAccess _db,IRegistrationService _registrationService)
        {
            dataAccess = _db;
            userRegistration = _registrationService;
        }
        // POST: Registration
        public ActionResult Index()
        {
            return View();
        }
       
        //saving new user data in database
        [HttpPost]
        public JsonResult SaveUser(User newUser)      
        {      
            return Json(userRegistration.RegistrationMethod(newUser), JsonRequestBehavior.AllowGet);            
        }
    }
}