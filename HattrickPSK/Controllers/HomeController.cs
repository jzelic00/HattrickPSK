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
    

    public class HomeController : Controller
    {


       
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

          

                return Json(events, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult TicketRecive(ICollection<TicketEvent> choosenEvents, string totalOdds, bool bonus5,bool bonus10, string betAmount)
        {
           
            using (var dbConnection = new DatabaseContext())
            {
                

               Ticket newTicket = new Ticket();

                newTicket.UserID = Convert.ToInt32(Session["UserID"]);
                newTicket.User = dbConnection.User.Find(newTicket.UserID);
                newTicket.BetAmount = decimal.Parse(betAmount, CultureInfo.InvariantCulture);

                if (newTicket.User.Balance < newTicket.BetAmount)
                {
                    string error = "Nedovoljan iznos na racunu, izvršite nadoplatu na /Account/addBalance"; 
                    
                    return Json(error,JsonRequestBehavior.AllowGet);
                }

                newTicket.User.Balance -= newTicket.BetAmount;

                newTicket.Bonus5 = bonus5;
                newTicket.Bonus10 = bonus10;
                
                
                newTicket.Odds = decimal.Parse(totalOdds, CultureInfo.InvariantCulture);
                newTicket.PaymentTime = DateTime.Now;
               

                dbConnection.Ticket.Add(newTicket);

                foreach (TicketEvent choosenEvent in choosenEvents)
                {
                    
                    dbConnection.TicketEvent.Add(choosenEvent);

                }

                
                dbConnection.SaveChanges();

                return Json(JsonRequestBehavior.AllowGet);
            }
        }
    }
}
