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
    public class AddTicketServices
    {
        private readonly IDataAccess dataAccess;
        Ticket newTicket=new Ticket();
        decimal betAmountConverted;
        public AddTicketServices(int userId,IDataAccess _db)
        {
            dataAccess = _db;
            newTicket.User = dataAccess.findUserByID(userId);           
        }
      
        public bool checkBalance(string betAmount)
        {
            if (decimal.TryParse(betAmount, out betAmountConverted))
                return newTicket.User.Balance > betAmountConverted;

            return false;         
        }

        public bool MakeTransaction(ICollection<TicketEvent> choosenEvents, string totalOdds, bool bonus5, bool bonus10)
        {
            using (var dbContextTransaction = dataAccess.Transaction())
            {
                newTicket.Bonus10 = bonus10;
                newTicket.Bonus5 = bonus5;
                newTicket.PaymentTime = DateTime.Now;
                newTicket.BetAmount = betAmountConverted;
                newTicket.Odds = decimal.Parse(totalOdds,CultureInfo.InvariantCulture);
                newTicket.User.Balance -= betAmountConverted;

                dataAccess.db.Ticket.Add(newTicket);

                foreach (TicketEvent choosenEvent in choosenEvents)
                    dataAccess.db.TicketEvent.Add(choosenEvent);

                dataAccess.saveChanges();

               dbContextTransaction.Commit();
           }
            return true;
        }
    }
}