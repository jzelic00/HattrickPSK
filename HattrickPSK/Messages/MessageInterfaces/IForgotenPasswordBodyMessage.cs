using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Messages
{
    public interface IForgotenPasswordBodyMessage
    {
        string ForgotenPasswordMessage(string username, string password);
        string ForgotenPasswordSubject();     
    }
}
