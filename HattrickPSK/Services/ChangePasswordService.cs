using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.DataAcces;
using HattrickPSK.Models;

namespace HattrickPSK.Services
{
    public class ChangePasswordService
    {
        DAL dataAccess = new DAL();
        User currentUser = new User();
        public bool ChangePasswordTransaction(string oldPassword, string newPassword, int userId)
        {
            currentUser = dataAccess.findUserByID(userId);

            if (currentUser.Password.Equals(oldPassword))           
                using (var dbContextTransaction = dataAccess.db.Database.BeginTransaction())
                {
                    currentUser.Password = newPassword;
                    dataAccess.db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }                         
            return false;
        }
       
    }
}