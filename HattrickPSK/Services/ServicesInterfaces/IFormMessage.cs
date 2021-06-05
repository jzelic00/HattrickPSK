using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Services
{
    public interface IFormMessage
    {
        MailMessage createMail { get; set; }
        void FormMail();
        
    }
}
