using System;
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
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
            Database.SetInitializer(new HattrickPSKDBInitializer());
        }
       public DbSet<Contain> Contain { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }  
}