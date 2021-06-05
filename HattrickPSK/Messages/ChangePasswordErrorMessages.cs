using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK.Messages
{
    public class ChangePasswordErrorMessages : IChangePasswordErrorMessages
    {
        public string WrongOldPassword()
        {
            return "<script>alert('Pogresno unesena stara lozinka')</script>";
        }
    }
}
