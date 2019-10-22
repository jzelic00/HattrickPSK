using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    public class RegistrationController : Controller
    {
        // POST: Registration
        public ActionResult Index()
        {
            return View();
        }

        private DatabaseContext dbConnection = new DatabaseContext();

        //saving new user data in database
        [HttpPost]
        public JsonResult SaveUser(User newUser)      
        {
            int state = 0;
            
            List<User> ListOfUsers = dbConnection.User.ToList();

            //searching database if  there is already user with same username or email
            foreach (User user in ListOfUsers)
            {
                if (newUser.Email == user.Email)
                {
                    state = 2;
                    return Json(state, JsonRequestBehavior.AllowGet);
                }
                else if (newUser.Username == user.Username)
                {
                    state = 1;
                    return Json(state, JsonRequestBehavior.AllowGet);
                }
                

            }
                         
             dbConnection.User.Add(newUser);
             dbConnection.SaveChanges();
                
                   
            return Json(state, JsonRequestBehavior.AllowGet);
        }
    }
}