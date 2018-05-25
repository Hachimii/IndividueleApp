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
                  return View(volunteerRepo.GetDetails(id));
        }

        public IActionResult Details(int id)
        {
            Volunteer v = volunteerRepo.GetDetails(id);
            return View(v);

        }

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

        //Vanaf hier alleen maar posts!

        [HttpPost]
        public IActionResult Edit(Volunteer V)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("Edit");
            }

            volunteerRepo.Edit(V);
            return View();
            
        }
    
        public IActionResult Create(Volunteer volunteer)
        {
            
            volunteerRepo.AddVolunteer(volunteer);
            return RedirectToAction("Index", "Home");

        }   
  
        public IActionResult Delete(int id)
        {
           volunteerRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
