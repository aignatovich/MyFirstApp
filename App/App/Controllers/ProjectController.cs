using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Service;
using App.ModelBinding;

namespace App.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService projectService = new ProjectService();
        private EmployeeService employeeService = new EmployeeService();
        private ExtendedProjectService extendedProjectService = new ExtendedProjectService();

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                projectService.Add(project);
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
            ProjectViewModel project = projectService.GetSingle(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult RemoveProject(ProjectViewModel project)
        {
            projectService.Remove(project);
            return Redirect("ShowProjects");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            ProjectViewModel toTransfer = projectService.GetSingle(id);
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                projectService.Edit(project);
                return RedirectToAction("ShowProjects");
            }

            return View("EditProject");
        }

        [HttpGet]
        public ActionResult SetupProject(int id)
        {
            ExtendedProjectViewModel toTransfer = extendedProjectService.Create(id);
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult SetupProject([ModelBinder(typeof(IdsArrayBinder))] IEnumerable<Int32> ids, int projectId)
        {
            projectService.EmployInProject(projectId, ids);
            return RedirectToAction("ShowProjects");
        }
    }
}