using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;

namespace HattrickPSK.Services
{
    public class RegistrationService
    {
        DAL dataAccess = new DAL();
        IList<User> allUsers;
        public int RegistrationMethod(User newUser)
        {
            allUsers = dataAccess.getAllUsers();

            foreach (User user in allUsers)
                if (newUser.Email == user.Email)
                    return 2;
                else if (newUser.Username == user.Username)
                    return 1;

            dataAccess.db.User.Add(newUser);
            dataAccess.db.SaveChanges();

            return 0;
            }
    }
}