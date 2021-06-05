using HattrickPSK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Services
{
    public interface IRegistrationService
    {
        int RegistrationMethod(User newUser);
    }
}
