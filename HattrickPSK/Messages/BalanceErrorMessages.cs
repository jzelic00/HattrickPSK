using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK.Messages
{
    public class BalanceErrorMessages : IBalanceErrorMessagess
    {
        public string InsufficientlyBalance()
        {
            return "<script>alert('Nedovoljan iznos na racunu, izvrsite nadoplatu na Account/AddBalance')</script>";
        }

        public string WronglyEnteredAmount(decimal min, decimal max)
        {
            return "<script>alert('Pogresno unesen iznos (max. " + max + " min. " + min + " )')</script>";
        }
    }
}