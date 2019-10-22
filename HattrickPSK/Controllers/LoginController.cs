using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            //searching for user in database and creating his seesion
            using (DatabaseContext db = new DatabaseContext())
            {
                var tmp = db.User.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (tmp != null)
                {
                    Session["UserID"] = tmp.UserID;
                   
                    return RedirectToAction("Index","Home");
                }
                else
                    Response.Write("<script>alert('Pogrešno uneseni podaci, pokušajte ponovno')</script>");

                return View();
            }
        }

        //user logut
        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


       
        public ActionResult ForgottenPassword()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ForgottenPassword(User user)
        {
            
            using (DatabaseContext db = new DatabaseContext())
            {
                //looking if there is user with that email in database
                var tmp = db.User.Where(a => a.Email.Equals(user.Email)).FirstOrDefault();

                //sending mail with password to user
                if (tmp != null)
                {
                    try
                    {
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.To.Add(user.Email);
                        mailMessage.From = new MailAddress("hattrickpsk@outlook.com");

                        mailMessage.Subject = "Welcome to HattrickPSK";
                        mailMessage.Body = "Username: " + tmp.Username + "\nPassword:  " + tmp.Password;

                        SmtpClient smtpClient = new SmtpClient("smtp.live.com", 587)
                        {
                            EnableSsl = true,

                            Credentials = new System.Net.NetworkCredential("hattrickpsk@outlook.com", "Grf55psf")
                        };
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                        return View();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Unesena email adresa nepostoji, pokušajte ponovno')</script>");
                    return View();
                }

            }
         

            //redirecting user to login page

            return RedirectToAction("Index", "Login");

        }
    }
}