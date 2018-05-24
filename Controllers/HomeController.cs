using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTHWebapp.Models;
using FTHWebapp.SqlContext;
using FTHWebapp.Interfaces;
using FTHWebapp.Repository;
using FTHWebapp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FTHWebapp.Controllers
{
    public class HomeController : Controller
    {

        Database db = new Database();
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Volunteer VM)
        {
            VolunteerRepo rep = new VolunteerRepo(new VolunteerSqlContext());
            Volunteer Gebruiker = rep.GetGebruiker(VM.Username, VM.Password);


            //if ("@Username" != VM.Username || "@Password" != VM.Password)
            //{
            //    return View();
            //}
            if (Gebruiker == null)
            {
               
            }

            //als gebruiker hier komt is alles goed
            return RedirectToAction("Dashboard", "Volunteer");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
