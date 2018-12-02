using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickPSK.Models
{
    public class Event
    {
        public int EventID { get; set; }
       
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Tip1 { get; set; }
        public decimal Tip2 { get; set; }
        public decimal TipX { get; set; }

        public IList<Contain> Contain { get; set; }

        
    }
}