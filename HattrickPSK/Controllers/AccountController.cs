using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.DataAcces;
using HattrickPSK.Services;
using HattrickPSK.Messages;
using System;

namespace HattrickPSK.Controllers
{
    public class AccountController : Controller
    {
        DAL dataAcces = new DAL();
        ResponseMessages response = new ResponseMessages();

        // GET: Users
        public ActionResult Index()
        {
            return View(dataAcces.findUserByID(Convert.ToInt32(Session["UserID"])));
        }

        public ActionResult AddBalance()
        {
            return View();
        }

        //adding more balance to account
        [HttpPost]
        public ActionResult AddBalance(decimal amount)
        {
            AddBalanceService addBalance = new AddBalanceService();

            if(addBalance.MakeBalanceTransaction(amount, Convert.ToInt32(Session["UserID"])))
                return RedirectToAction("Index");

            Response.Write(response.WronglyEnteredAmount(balanceValuesConst.MIN_VALUE,balanceValuesConst.MAX_VALUE));
            return View();           
        }
       
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string oldPassword, string newPassword)
        {
            ChangePasswordService _changePassword = new ChangePasswordService();

            if(_changePassword.ChangePasswordTransaction(oldPassword,newPassword, Convert.ToInt32(Session["UserID"])))
                return RedirectToAction("Index");

            Response.Write(response.WrongOldPassword());
            return View();          
        }
    }
}