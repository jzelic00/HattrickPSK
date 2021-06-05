using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickPSK.DataAcces;
using HattrickPSK.Services;
using HattrickPSK.Messages;
using HattrickPSK.Models;
using System;
using HattrickPSK.RoleProvides;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
namespace HattrickPSK.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly IDataAccess dataAccess;

        public AdminController(IDataAccess _db)
        {
            dataAccess = _db;
        }
        
        public ActionResult AdminHome()
        {            
            return View(dataAccess.getAllUsers());
        }
    }
}
    