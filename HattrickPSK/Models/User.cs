using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HattrickPSK.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        
        public string Email { get; set; }
       
        public virtual IList<UserRole> UserRole { get; set; }
        public virtual IList<Ticket> Ticket {get;set;}
        
    }
}