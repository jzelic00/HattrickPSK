using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Models;
using HattrickPSK.DataAcces;

namespace HattrickPSK.Services
{
    public class AddBalanceService : balanceValuesConst
    {
        DAL dataAccess = new DAL();
        User currentUser = new User();
        public bool MakeBalanceTransaction(decimal amount,int userId)
        {
            if (amount < MIN_VALUE || amount > MAX_VALUE)
                return false;

            using (var dbContextTransaction = dataAccess.db.Database.BeginTransaction())
                {
                    currentUser = dataAccess.findUserByID(userId);
                    currentUser.Balance += amount;                 
                    dataAccess.db.SaveChanges();
                    dbContextTransaction.Commit();                  
                }
           return true;                      
        }        
    }
}