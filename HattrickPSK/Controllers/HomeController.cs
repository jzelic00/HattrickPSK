using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.Models;

namespace HattrickPSK.Controllers
{
    public class NewTicket
    {
        public int EventID { get; set; }
  
        public string Tip { get; set; }
       
        
    }

    public class HomeController : Controller
    {


        //private DatabaseContext dbConnection = new DatabaseContext();
        public ActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public JsonResult GetEvents()
        {
            
            using (var dbConnection = new DatabaseContext())
            {

                
                List<Event> events = dbConnection.Event.ToList();

                //var reducedList = events.Select(e => new { e.EventID, e.Type, e.Name, e.TipX, e.Tip1, e.Tip2 }).ToList();
                
                return Json(events, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult TicketRecive(List<NewTicket> addTicket, string totalOdds, string bonus, string betAmount, string profit)
        {
            using (var dbConnection = new DatabaseContext())
            {
                List<Contain> newContain = new List<Contain>();


                Ticket newTicket = new Ticket
                {

                    Bonus = int.Parse(bonus),
                    PaymentTime = DateTime.Now,
                    Odds = Decimal.Parse(totalOdds, CultureInfo.InvariantCulture),

                    BetAmount = Decimal.Parse(betAmount, CultureInfo.InvariantCulture),
                    Profit = Decimal.Parse(profit, CultureInfo.InvariantCulture)
                };

                dbConnection.Ticket.Add(newTicket);

                foreach (NewTicket x in addTicket)
                {

                    dbConnection.Contain.Add(new Contain
                    {
                        EventID = x.EventID,
                        TicketID = newTicket.TicketID,
                        Chosen = x.Tip
                    });
                }

                dbConnection.SaveChanges();


                return Json(JsonRequestBehavior.AllowGet);
            }
        }
    }
}
