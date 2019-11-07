using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Services;

namespace HattrickPSK.Services
{
    public class SendMail
    {
        public string Send(MailMesage mail, SmtpConnection smtp)
        {
            try
            {
                if (smtp.TryConnect())
                    smtp.smtp.Send(mail.createMail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";             
        }
    }
}