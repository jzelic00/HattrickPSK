using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HattrickPSK.Models;


namespace HattrickPSK.DataAcces
{
    public class DAL : DataAccesInterface
    {
        
        public DatabaseContext db = new DatabaseContext();

        public User findUserByID(int userId)
        {          
            return db.User.Where(p=>p.UserID==userId).SingleOrDefault();
        }
        public User UserAutentification(User user)
        {          
            return db.User.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).First();
        }

        public IList<Event> GetEvent()
        {
            return db.Event.ToList();

        }     

        public IList<Ticket> getTicket(int userId)
        {
            return db.Ticket.ToList().FindAll(p=>p.UserID==userId);
        }
        public User findUserByEmail(string email)
        {
            return db.User.Where(a => a.Email.Equals(email)).FirstOrDefault();
        }


    }

    
}