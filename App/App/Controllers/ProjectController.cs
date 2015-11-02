using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Validation;
using static App.Validation.ProjectValidator;

namespace App.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDataAccessObject dataAccessObject = new ProjectDataAccessObject();

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectViewModel projectViewModel)
        {
            ProjectModel project = projectViewModel.AsProject();
            if (BeValueUnique(project))
            {
                dataAccessObject.Add(project);
                return RedirectToAction("Index", "Home");
            }

            return View("Apologize");
        }

        [HttpGet]
        public ActionResult ShowProjects()
        {
            ICollection<ProjectViewModel> toTransfer = dataAccessObject.GetAllViewModels();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveProject(int id)
        {
            ProjectModel project = dataAccessObject.GetSingle(id);
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
            ProjectModel project = dataAccessObject.GetSingle(id);
            ProjectViewModel toTransfer = new ProjectViewModel(project);
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult EditConfirmed(ProjectViewModel project)
        {
            ProjectModel toTransfer = project.AsProject();
            dataAccessObject.Edit(toTransfer);
            return RedirectToAction("Index", "Home");
        }
    }
}