using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
       
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Tip1 { get; set; }
        public decimal Tip2 { get; set; }
        public decimal TipX { get; set; }

        
        [NotMapped]
        public virtual IList<TicketEvent> TicketEvent { get; set; }

        
    }
}