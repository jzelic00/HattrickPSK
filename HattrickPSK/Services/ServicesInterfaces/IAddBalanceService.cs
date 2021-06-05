using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Services
{
    public interface IAddBalanceService
    {
        bool MakeBalanceTransaction(decimal amount, int userId);
    }
}
