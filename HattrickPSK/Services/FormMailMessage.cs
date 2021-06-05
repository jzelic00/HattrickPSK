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
    public class FormMailMesage:IFormMessage
    {
        public MailMessage createMail { get; set; }
        private IForgotenPasswordBodyMessage messageBody;
        User currentUser;
        public FormMailMesage(User _currentUser,IForgotenPasswordBodyMessage _messageBody)
        {
            createMail = new MailMessage();
            messageBody = _messageBody;
            currentUser = _currentUser;
        }
        
        public void FormMail()
        {
            createMail.To.Add(currentUser.Email);
            createMail.From = new MailAddress("hattrickpsk@outlook.com");
            createMail.Subject = messageBody.ForgotenPasswordSubject();
            createMail.Body = messageBody.ForgotenPasswordMessage(currentUser.Username, currentUser.Password);
        }

        
    }   
}