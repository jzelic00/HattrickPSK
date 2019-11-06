using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Messages
{
    public interface IResponseErrorMessages
    {
        string ForgotenPasswordWrongMail();
        string LoginDataWrong();
        string MailSendingError();
        string TransactionErrorMessage();
        string InsufficientlyBalance();
    }
}
