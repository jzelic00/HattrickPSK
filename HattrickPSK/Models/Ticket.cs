using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Profit { get; set; }
        public int Bonus { get; set; }
        public decimal Odds { get; set; }

        public IList<Contain> Contain { get; set; }
      
    }
}