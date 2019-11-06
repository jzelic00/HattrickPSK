using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickPSK.Messages
{
    public class ResponseMessages : IResponseErrorMessages
    {
        public string ForgotenPasswordWrongMail()
        {
            return "<script>alert('Unesena email adresa nepostoji, pokušajte ponovno')</script>";
        }

        public string InsufficientlyBalance()
        {
            return "<script>alert('Nedovoljan iznos na racunu, izvrsite nadoplatu na Account/AddBalance')</script>";
        }

        public string LoginDataWrong()
        {
            return "<script>alert('Pogrešno uneseni podaci, pokušajte ponovno')</script>";
        }

        public string MailSendingError()
        {
            return "<script>alert('Error in mail sending, please try again later')</script>";
        }

        public string TransactionErrorMessage()
        {
            return "<script>alert('Pogreska pri obradi transakcije, pokusajte ponovno kasnije')</script>";
        }
    }
}