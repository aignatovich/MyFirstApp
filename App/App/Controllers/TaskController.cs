using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Validation;
using static App.Validation.TaskValidator;

namespace App.Controllers
{
    public class TaskController : Controller
    {
        private TaskDataAccessObject dataAccessObject = new TaskDataAccessObject();

        [HttpGet]
        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel taskViewModel)
        {
            TaskModel task = taskViewModel.AsTask();
            if (BeValueUnique(task))
            {
                dataAccessObject.Add(task);
                return RedirectToAction("Index", "Home");
            }

            return View("Apologize");
        }

        [HttpGet]
        public ActionResult ShowEmployees()
        {
            ICollection<TaskModel> toTransfer = dataAccessObject.GetAll();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(int id)
        {
            TaskModel task = dataAccessObject.GetSingle(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult RemoveConfirmed(int id)
        {
            dataAccessObject.Remove(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditEmployee(int id)
        {
            TaskModel task = dataAccessObject.GetSingle(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult EditConfirmed(TaskModel task)
        {
            dataAccessObject.Edit(task);
            return RedirectToAction("Index", "Home");
        }
    }
}