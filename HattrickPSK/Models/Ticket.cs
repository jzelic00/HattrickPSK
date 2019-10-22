using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
             
      
        public int UserID { get; set; }

        public User User { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal BetAmount { get; set; }

        public bool Bonus5 { get; set; }

       
        public bool Bonus10 { get; set; }
        public decimal Odds { get; set; }

        
        public virtual  IList<TicketEvent> TicketEvent{ get; set; }

    }
}