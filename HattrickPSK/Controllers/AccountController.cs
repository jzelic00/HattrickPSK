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
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly IDataAccess dataAccess;
        IAddBalanceService addBalance;
        IChangePasswordService changePassword;
        IBalanceErrorMessagess balanceErrorMessagess;
        IChangePasswordErrorMessages changePasswordErrorMessages;

        public AccountController(IDataAccess _db,IChangePasswordService _changePasswordService,IAddBalanceService _addBalanceService)
        {
            dataAccess = _db;            
            addBalance = _addBalanceService;
            changePassword = _changePasswordService;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(dataAccess.findUserByID(Convert.ToInt32(Session["UserID"])));
        }

        #region AddBalance
        public ActionResult AddBalance()
        {
            return View();
        }

        //adding more balance to account
        [HttpPost]
        public ActionResult AddBalance(decimal amount)
        {
           if(addBalance.MakeBalanceTransaction(amount, Convert.ToInt32(Session["UserID"])))
                return RedirectToAction("Index");

            balanceErrorMessagess = new BalanceErrorMessages();
            Response.Write(balanceErrorMessagess.WronglyEnteredAmount(balanceValuesConst.MIN_VALUE,balanceValuesConst.MAX_VALUE));
            return View();           
        }
        #endregion

        #region ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string oldPassword, string newPassword)
        {
            
            if(changePassword.ChangePasswordTransaction(oldPassword,newPassword, Convert.ToInt32(Session["UserID"])))
                return RedirectToAction("Index");

            changePasswordErrorMessages = new ChangePasswordErrorMessages();
            Response.Write(changePasswordErrorMessages.WrongOldPassword());
            return View();          
        }
        #endregion
    }
}