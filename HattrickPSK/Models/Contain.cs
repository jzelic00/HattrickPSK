using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class Contain
    {


        public Event Event { get; set; }
        public Ticket Ticket { get; set; }

        [Key, Column(Order = 1)]
        public int EventID { get; set; }

        [Key, Column(Order = 2)]
        public int TicketID { get; set; }

        public string Chosen { get; set; }



    }
}