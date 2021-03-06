﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace HattrickPSK.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=HattrickDatabaseConnectionString")
        {           
            Database.SetInitializer(new HattrickPSKDBInitializer());
            Database.CommandTimeout = 180;           
        }
        
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<TicketEvent> TicketEvent { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }
    }  
}