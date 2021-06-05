using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK.Messages
{
    public class LoginErrorMessages : ILoginErrorMessagess
    {       
            public string LoginDataWrong()
            {
                return "<script>alert('Pogrešno uneseni podaci, pokušajte ponovno')</script>";
            }
        
    }
}