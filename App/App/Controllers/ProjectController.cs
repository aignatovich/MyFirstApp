using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Service;

namespace App.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDataAccessObject dataAccessObject = new ProjectDataAccessObject();
        private ProjectService projectService = new ProjectService();

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectViewModel projectViewModel)
        {
            ProjectModel project = projectService.AsProject(projectViewModel);

            if (ModelState.IsValid)
            {
                dataAccessObject.Add(project);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ShowProjects()
        {
            ICollection<ProjectViewModel> toTransfer = projectService.GetAllViewModels();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveProject(int id)
        {
            ProjectViewModel project = new ProjectViewModel(dataAccessObject.GetSingle(id));
            return View(project);
        }

        [HttpPost]
        public ActionResult RemoveConfirmed(int id)
        {
            dataAccessObject.Remove(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditProject(int id)
        {
            ProjectViewModel toTransfer = new ProjectViewModel(dataAccessObject.GetSingle(id));
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult EditConfirmed(ProjectViewModel projectViewModel)
        {
            ProjectModel toTransfer = projectService.AsProject(projectViewModel);

            if (ModelState.IsValid)
            {
                dataAccessObject.Edit(toTransfer);
                return RedirectToAction("Index", "Home");
            }

            return View("Apologize");
        }
    }
}