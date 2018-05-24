using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTHWebapp.Models;
using Microsoft.AspNetCore.Http;
using FTHWebapp.Repository;
using FTHWebapp.SqlContext;
using FTHWebapp.ViewModels;

namespace FTHWebapp.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly VolunteerRepo volunteerRepo = new VolunteerRepo(new VolunteerSqlContext());
        public IActionResult Create()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Volunteer v = volunteerRepo.GetDetails(id);
            VolunteerViewModel vw = new VolunteerViewModel(v);
   

            return View(vw);
        }

        [HttpPost, ActionName ("Edit")]
        public IActionResult Edit(Volunteer volunteer)
        {
            volunteerRepo.Edit(volunteer);
            //VolunteerViewModel vw = new VolunteerViewModel(volunteer);
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public IActionResult Create(Volunteer volunteer)
        {
            
            volunteerRepo.AddVolunteer(volunteer);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            List<Volunteer> V = volunteerRepo.AddRoles();
            VolunteerViewModel vol = new VolunteerViewModel(V);
            return View(vol);
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Volunteer v = volunteerRepo.GetDetails(id);
            return View(v);    

        }
        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    Volunteer V = volunteerRepo.
        //}
    
    }
}
