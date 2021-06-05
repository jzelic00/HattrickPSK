using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.Services;
using HattrickPSK.DataAcces;
using HattrickPSK.Messages;

using System.Web.Security;


namespace HattrickPSK.Controllers
{
    public class LoginController : Controller
    {
        IDataAccess dataAccess;
        ForgottenPassworErrordMessages forgottenPassworErrorMessages;
        ILoginErrorMessagess loginErrorMessagess;
        SendMail sendMail;
        
        public LoginController(IDataAccess _db,ILoginErrorMessagess _loginErrorMessagess)
        {
            dataAccess = _db;
            loginErrorMessagess = _loginErrorMessagess;
        }

        // GET: Login
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            User currentUser = dataAccess.UserAutentification(user);

            if (currentUser == null)
            {
                Response.Write(loginErrorMessagess.LoginDataWrong());
                return View();
            }
          
            FormsAuthentication.SetAuthCookie(user.Username,false);           
            Session["UserID"] = Convert.ToInt32(currentUser.UserID);
           
            return RedirectToAction("Index", "Home");
        }

        #region Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        #endregion

        #region ForgottenPassword
        public ActionResult ForgottenPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgottenPassword(User user)
        {
            User currentUser = dataAccess.findUserByEmail(user.Email);
            forgottenPassworErrorMessages = new ForgottenPassworErrordMessages();
            if (currentUser == null)
            {
                Response.Write(forgottenPassworErrorMessages.ForgottenPasswordWrongMail());
                return View();                
            }

            sendMail = new SendMail();
            if (sendMail.Send(new FormMailMesage(currentUser, new ForgottenPasswordMailMessageBody()), new SmtpConnection()) != "")            
                Response.Write(forgottenPassworErrorMessages.MailSendingError());
            
            return RedirectToAction("Index", "Login");          
        }
        #endregion
    }
}