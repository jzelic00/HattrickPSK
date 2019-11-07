using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HattrickPSK.Models
{
    public class HattrickPSKDBInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        
            protected override void Seed(DatabaseContext context)
            {

            IList<Event> defaultEvents = new List<Event>
            {
                new Event() { Type = "Football", Name = "Hajduk - Dinamo", Tip1 = 1.10m, Tip2 = 1.60m, TipX = 3.10m },
                new Event() { Type = "Football", Name = "Barcelona - Real Madrid", Tip1 = 1.10m, Tip2 = 1.20m, TipX = 1.50m },
                new Event() { Type = "Basketball", Name = "LA Lakers - Miami Heat", Tip1 = 2.10m, Tip2 = 1.30m, TipX = 4.20m },
                new Event() { Type = "Box", Name = "Buster Douglas - Mike Tyson", Tip1 = 1.10m, Tip2 = 1.50m, TipX = 2.50m },
                new Event() { Type = "Football", Name = "PSG - Roma", Tip1 = 1.30m, Tip2 = 1.50m, TipX = 2.50m },
                new Event() { Type = "Basketball", Name = "Toronto Raptors - Boston Celtics", Tip1 = 2.10m, Tip2 = 1.20m, TipX = 5.25m },
                new Event() { Type = "Handball", Name = "PPD Zagreb - Montpellier", Tip1 = 1.50m, Tip2 = 1.20m, TipX = 4.15m },
                new Event() { Type = "Basketball", Name = "Chicago Bulls - Phoenix Suns", Tip1 = 1.80m, Tip2 = 2.60m, TipX = 6.10m },
                new Event() { Type = "Box", Name = "Mike Tyson - Foreman", Tip1 = 1.10m, Tip2 = 1.20m, TipX = 1.50m },
                new Event() { Type = "Tenis", Name = "Đokovic - Cilić", Tip1 = 1.20m, Tip2 = 1.60m, TipX = 4.35m }
            };

            User defaultUser = new User
            {
                Username="jzelic00",
                FirstName = "Josip",
                LastName = "Zelić",
                Password = "12345",
                Balance = 1000,
                Roles="User",
                Email = "jzelic00@fesb.hr"
            };

            User defaultAdmin = new User
            {
                Username = "dsaric00",
                FirstName = "Duje",
                LastName = "Šarić",
                Password = "12345",
                Balance = 1000,
                Roles="Admin",
                Email = "dsaric00@fesb.hr"
            };

            context.Event.AddRange(defaultEvents);
            context.User.Add(defaultUser);
            context.User.Add(defaultAdmin);
            base.Seed(context);
            }

        
        
    }
}