﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HattrickPSK.Models;


namespace HattrickPSK.DataAcces
{
    public class DAL : IDataAccess
    {
        public DatabaseContext db { get; set; }

        public DAL()
        { 
        }
        public DAL(DatabaseContext _db)
        {
            db = _db;
        }
        
        public User findUserByID(int userId)
        {               
            return db.User.Where(p=>p.UserID==userId).SingleOrDefault();
        }
        public User UserAutentification(User user)
        {          
            return db.User.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
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

        public IList<User> getAllUsers()
        {
            return db.User.ToList();
        }

        public User fingUserByUsername(string username)
        {
            return db.User.Where(p => p.Username == username).FirstOrDefault();
        }

        public void addUser(User newUser)
        {
            db.User.Add(newUser);
        }

        public void saveChanges()
        {
            db.SaveChanges();
        }

        public DbContextTransaction Transaction()
        {
            return db.Database.BeginTransaction();
        }
    }   
}