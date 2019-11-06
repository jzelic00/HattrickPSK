using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using HattrickPSK.Controllers;
using HattrickPSK.Models;
using HattrickPSK.Messages;

namespace HattrickPSK.Services
{
    //ovdje da se samo formira poruka i napravit da moze slat sve i svasta
    public class MailMesage
    {      
        public MailMessage createMail = new MailMessage();
        protected IMessage messageBody;
        public MailMesage(User currentUser,IMessage messageBody)
        {
            this.messageBody = messageBody;
            createMail.To.Add(currentUser.Email);
            createMail.From = new MailAddress("hattrickpsk@outlook.com");
            createMail.Subject = messageBody.ForgotenPasswordSubject();
            createMail.Body = messageBody.ForgotenPasswordMessage(currentUser.Username,currentUser.Password);
        }
    }   
}