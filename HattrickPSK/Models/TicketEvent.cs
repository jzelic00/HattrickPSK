using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class TicketEvent
    {
    
      
        [Key, Column(Order = 2)]
        public int EventID { get; set; }

        [Key, Column(Order = 1)]
        public int TicketID { get; set; }
     

        public string Tip { get; set; }

    
        [NotMapped]
        public virtual Ticket Ticket { get; set; }
        public virtual Event Event { get; set; }

       
    }
}