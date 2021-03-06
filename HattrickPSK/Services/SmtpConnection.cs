﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HattrickPSK.Services
{
    public class SmtpConnection: IMailProviderConnection,ISendProviderMail
    {
        public SmtpClient smtp = new SmtpClient("smtp.live.com", 587);

        public void SendMailWithProvider(MailMessage mailContent)
        {
            smtp.Send(mailContent);
        }

        public bool TryConnect()
        {
            if(smtp!=null)
            { 
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("hattrickpsk@outlook.com", "Grf55psf");
                return true;
            }
       
            return false;          
        }              
    }
}