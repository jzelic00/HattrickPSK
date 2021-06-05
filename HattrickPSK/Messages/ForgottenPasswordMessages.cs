using HattrickPSK.Messages.MessageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickPSK.Messages
{
    public class ForgottenPassworErrordMessages : IMailErrorMessages, IWronglyEnteredMailErrorMessage
    {
        public string MailSendingError()
        {
            return "<script>alert('Error in mail sending, please try again later')</script>";
        }

        public string ForgottenPasswordWrongMail()
        {
            return "<script>alert('Unesena email adresa nepostoji, pokušajte ponovno')</script>";
        }
    }
}