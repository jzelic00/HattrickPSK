using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Messages.MessageInterfaces;


namespace HattrickPSK.Messages
{
    public class TransactionErrorMessagess : ITransactionErrorMessagess
    {
        public string TransactionErrorMessage()
        {          
                return "<script>alert('Pogreska pri obradi transakcije, pokusajte ponovno kasnije')</script>";
            
        }
    }
}