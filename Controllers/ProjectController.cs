using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTHWebapp.Models;
using FTHWebapp.Repository;
using FTHWebapp.Interfaces;
using FTHWebapp.SqlContext;
using Microsoft.AspNetCore.Http;
using FTHWebapp.ViewModels;

namespace FTHWebapp.Controllers

{
    public class ProjectController : Controller
    {
        private readonly ProjectRepo projectrepo = new ProjectRepo(new ProjectSqlContext());

        public IActionResult Index()
        {
            List<Project> P = projectrepo.GetAllProjects();
            ProjectViewModel Pro = new ProjectViewModel(P);
            return View(Pro);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Project P = projectrepo.GetDetails(id);
            string file = "/images" + P.Pictures;
            return View(P);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(projectrepo.GetDetails(id));
        }

        public IActionResult subscribe()
        {
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {

            projectrepo.AddProject(project);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit (Project project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("Edit");
            }

            projectrepo.Edit(project);
            return View();
        }

        public IActionResult Delete (int id)
        {
            projectrepo.Delete(id);
            return View("Index");
        }
    }
}
