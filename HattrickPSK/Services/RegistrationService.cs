using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;

namespace HattrickPSK.Services
{
    public class RegistrationService :IRegistrationService
    {
        IList<User> allUsers;
        private readonly IDataAccess dataAccess;
        public RegistrationService(IDataAccess _db)
        {
            dataAccess = _db;
        }
        public int RegistrationMethod(User newUser)
        {
            allUsers = dataAccess.getAllUsers();

            foreach (User user in allUsers)
                if (newUser.Email == user.Email)
                    return 2;
                else if (newUser.Username == user.Username)
                    return 1;
           
            dataAccess.addUser(newUser);         
            dataAccess.saveChanges();

            return 0;
         }
    }
}