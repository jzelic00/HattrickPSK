using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK.Messages
{
    public class ForgottenPasswordMailMessageBody : IForgotenPasswordBodyMessage
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