using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Messages
{
    public interface IBalanceErrorMessagess
    {
        string InsufficientlyBalance();
        string WronglyEnteredAmount(decimal minAmount, decimal maxAmount);
    }
}
