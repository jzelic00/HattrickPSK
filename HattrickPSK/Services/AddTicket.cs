using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.DataAcces;
using HattrickPSK.Models;
using System.Web.Mvc;
using System.Globalization;

namespace HattrickPSK.Services
{
    public class AddTicket
    {
        DAL dataAccess = new DAL();
        Ticket newTicket = new Ticket();
        decimal betAmountConverted;
        public AddTicket(int userId)
        {
            newTicket.User = dataAccess.findUserByID(userId);           
        }

        //mozda ovo u novu klasu spremit
        public bool checkBalance(string betAmount)
        {           
            if (decimal.TryParse(betAmount, out betAmountConverted))
                if (newTicket.User.Balance < betAmountConverted)
                    return false;           
                else
                    return true;
            return false;
        }

        public bool MakeTransaction(ICollection<TicketEvent> choosenEvents, string totalOdds, bool bonus5, bool bonus10)
        {        
            using (var dbContextTransaction = dataAccess.db.Database.BeginTransaction())
            {
                newTicket.Bonus10 = bonus10;
                newTicket.Bonus5 = bonus5;
                newTicket.PaymentTime = DateTime.Now;
                newTicket.Odds = decimal.Parse(totalOdds,CultureInfo.InvariantCulture);
                newTicket.User.Balance -= betAmountConverted;
                dataAccess.db.Ticket.Add(newTicket);
                
                foreach (TicketEvent choosenEvent in choosenEvents)
                    dataAccess.db.TicketEvent.Add(choosenEvent);
                    
                dataAccess.db.SaveChanges();

                dbContextTransaction.Commit();              
            }
            return true;
        }
    }
}