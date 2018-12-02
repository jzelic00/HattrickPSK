using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    public class AllTicket {
        public int TicketID { get; set; }

        public decimal BetAmount { get; set; }

        public decimal Odds { get; set; }

        public decimal Profit { get; set; }

        public int Bonus { get; set; }

        public string PaymentTime { get; set; }

        public List<String> Choosen { get; set; }
        public List<Event> Events { get; set; }
    }

    public class WalletController : Controller
    {

        private DatabaseContext dbConnection = new DatabaseContext();
        // GET: Wallet
        public ActionResult Wallet()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTicket()
        {
            List<Ticket> allTicket = dbConnection.Ticket.ToList();
            List<Contain> allContain = dbConnection.Contain.ToList();
            List<Event> allEvents = dbConnection.Event.ToList();
            List<AllTicket> NewTicket = new List<AllTicket>();
          
            Event newEvent = new Event();         
            int i = 0;

            foreach (Ticket t in allTicket)
            {
                NewTicket.Add(new AllTicket()
                {
                    TicketID = t.TicketID,
                    Odds = t.Odds,
                    BetAmount = t.BetAmount,
                    Bonus = t.Bonus,
                    Profit = t.Profit,
                    PaymentTime = t.PaymentTime.ToString("dd.MM.yyyy HH:mm"),
                    Choosen = new List<String>(),
                    Events = new List<Event>()
                });

                foreach (Contain c in allContain.Where(x => x.TicketID == t.TicketID))
                {
                    newEvent = allEvents.Find(u => u.EventID == c.EventID);
                    NewTicket[i].Events.Add(new Event()
                    {
                        EventID = newEvent.EventID,
                        Name = newEvent.Name,
                        Type = newEvent.Type
                    });

                    NewTicket[i].Choosen.Add(c.Chosen);

                    
                }
                i++;
            }         

            return Json(NewTicket, JsonRequestBehavior.AllowGet); 
        }

    }
}