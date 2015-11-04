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
                return RedirectToAction("ShowProjects");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ShowProjects()
        {
            ICollection<ProjectViewModel> toTransfer = projectService.GetAllViewModels();
            return View(toTransfer);
        }

        [HttpGet]
        public ActionResult RemoveProject(int id)
        {
            ProjectViewModel project = new ProjectViewModel(dataAccessObject.GetSingle(id));
            return View(project);
        }

        [HttpPost]
        public ActionResult RemoveProject(ProjectViewModel projectViewModel)
        {
            dataAccessObject.Remove(projectViewModel.Id);
            return Redirect("ShowProjects");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            ProjectViewModel toTransfer = new ProjectViewModel(dataAccessObject.GetSingle(id));
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectViewModel projectViewModel)
        {
            ProjectModel toTransfer = projectService.AsProject(projectViewModel);

            if (ModelState.IsValid)
            {
                dataAccessObject.Edit(toTransfer);
                return RedirectToAction("ShowProjects");
            }

            return View("EditProject");
        }

        [HttpGet]
        public ActionResult SetupProject(int id)
        {
            ProjectViewModel toTransfer = new ProjectViewModel(dataAccessObject.GetSingle(id));
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult SetupProject(string ids, int projectId)
        {
            projectService.EmployInProject(projectId, ids);
            return RedirectToAction("ShowProjects");
        }
    }
}