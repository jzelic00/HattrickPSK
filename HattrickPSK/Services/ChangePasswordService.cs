using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.DataAcces;
using HattrickPSK.Models;

namespace HattrickPSK.Services
{
    public class ChangePasswordService:IChangePasswordService
    {
        private readonly IDataAccess dataAccess;
        public User currentUser { get; set; }
        public ChangePasswordService(IDataAccess _db)
        {
            dataAccess = _db;
        }
        public bool ChangePasswordTransaction(string oldPassword, string newPassword, int userId)
        {
            currentUser = dataAccess.findUserByID(userId);

            if (currentUser.Password.Equals(oldPassword))           
                using (var dbContextTransaction = dataAccess.Transaction())
                {
                    currentUser.Password = newPassword;
                    dataAccess.saveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }                         
            return false;
        }     
    }
}