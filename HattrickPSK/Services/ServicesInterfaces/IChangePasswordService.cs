using HattrickPSK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickPSK.Services
{
    public interface IChangePasswordService
    {
        User currentUser { get; set; }
        bool ChangePasswordTransaction(string oldPassword, string newPassword, int userId);
    }
}
