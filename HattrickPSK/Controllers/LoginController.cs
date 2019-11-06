﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;
using HattrickPSK.Services;
using HattrickPSK.DataAcces;
using HattrickPSK.Messages;

namespace HattrickPSK.Controllers
{
    public class LoginController : Controller
    {
        ResponseMessages responseMessage = new ResponseMessages();
        DAL dataAcces = new DAL();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            User currentUser = dataAcces.UserAutentification(user);
                if (currentUser !=null)
                {
                    Session["UserID"] = Convert.ToInt32(currentUser.UserID);                  
                    return RedirectToAction("Index","Home");
                }
                else
                    Response.Write(responseMessage.LoginDataWrong());
                return View();           
        }

        //user logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
       
        public ActionResult ForgottenPassword()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ForgottenPassword(User user)
        {
            User currentUser = dataAcces.findUserByEmail(user.Email);
            if (currentUser != null)
            {
                SendMail sendMail = new SendMail();               
                if (sendMail.Send(new MailMesage(currentUser, new BodyMessages()), new SmtpConnection()) != "")
                {
                    Response.Write(responseMessage.MailSendingError());
                }
            }             
            else
            {
                Response.Write(responseMessage.ForgotenPasswordWrongMail());
                return View();
            }
            return RedirectToAction("Index", "Login");          
        }
    }
}