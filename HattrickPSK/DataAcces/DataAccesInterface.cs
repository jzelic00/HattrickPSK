using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickPSK.Models;

namespace HattrickPSK.DataAcces
{
    interface DataAccesInterface
    {
        IList<User> getAllUsers();
        User UserAutentification(User user);
        IList<Event> GetEvent();
        IList<Ticket> getTicket(int userId);          
        User findUserByID(int userId);
        User findUserByEmail(string email);      
    }
}