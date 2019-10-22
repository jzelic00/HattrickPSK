using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext db = new DatabaseContext();
        

        // GET: Users
        public ActionResult Index()
        {
            return View(db.User.Find(Session["UserID"]));
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(Session["UserID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult AddBalance()
        {          
            return View();
        }

        //adding more balance to account
        [HttpPost]
        public ActionResult AddBalance(decimal amount)
        {
            

            if (amount < 0 || amount > 1000)
            {
                Response.Write("<script>alert('Pogresno unesen iznos (max. 1000 min. 1)')</script>");

                return View();
            }
            else
            {
                User user = db.User.Find(Session["UserID"]);
                user.Balance += amount;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
       
        //
        public ActionResult ChangePassword()
        {
           
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string oldPassword,string newPassword)
        {
            User user = db.User.Find(Session["UserID"]);

            if (user.Password.Equals(oldPassword))
            {
               
                user.Password = newPassword;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               
                Response.Write("<script>alert('Pogresno unesena stara lozinka')</script>");
                
                return View();
            }
               
           
        }

       
    }
}
