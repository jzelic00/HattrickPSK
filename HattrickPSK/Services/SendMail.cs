using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Services;

namespace HattrickPSK.Services
{
    public class SendMail
    {
        public string Send(FormMailMesage mail, SmtpConnection smtp)
        {
            try
            {
                if (smtp.TryConnect())
                {
                    mail.FormMail();
                    smtp.SendMailWithProvider(mail.createMail);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";             
        }
    }
}