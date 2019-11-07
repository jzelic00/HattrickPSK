using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickPSK.Messages
{
    public class BodyMessages : IMessage
    {        
        public string ForgotenPasswordMessage(string username, string password)
        {
            return "Username: " + username + "\nPassword: " + password;
        }

        public string ForgotenPasswordSubject()
        {
            return "Welcome to HatrickPSK";
        }       
    } 
}