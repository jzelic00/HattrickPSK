using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickPSK.Models;

namespace HattrickPSK.DataAcces
{
    public interface IDataAccess
    {
        DatabaseContext db { get; set; }
        IList<User> getAllUsers();
        User UserAutentification(User user);
        IList<Event> GetEvent();
        IList<Ticket> getTicket(int userId);          
        User findUserByID(int userId);
        User findUserByEmail(string email);
        User fingUserByUsername(string username);
        void addUser(User newUser);
        void saveChanges();
        DbContextTransaction Transaction();


    }
}