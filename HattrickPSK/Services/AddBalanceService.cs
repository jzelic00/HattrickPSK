using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;

namespace HattrickPSK.Services
{
    public class AddBalanceService:IAddBalanceService
    {
        IDataAccess dataAccess;
        public const decimal MIN_VALUE = 20;
        public const decimal MAX_VALUE = 1000;
        User currentUser;
        public AddBalanceService(IDataAccess _db)
        {
            dataAccess = _db;
        }
        public bool MakeBalanceTransaction(decimal amount,int userId)
        {
            if (amount < MIN_VALUE || amount > MAX_VALUE)
                return false;

            currentUser = new User();
            using (var dbContextTransaction = dataAccess.Transaction())
                {
                    currentUser = dataAccess.findUserByID(userId);
                    currentUser.Balance += amount;                 
                    dataAccess.saveChanges();
                    dbContextTransaction.Commit();                  
                }
           return true;                      
        }        
    }
}