using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.DAL;
using CodeFirst;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDataAccessObject dataAccessObject = new EmployeeDataAccessObject();

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                dataAccessObject.Add(employee);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ShowEmployees()
        {
            ICollection<EmployeeModel> toTransfer = dataAccessObject.GetAll();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(int id)
        {
            EmployeeModel employee = dataAccessObject.GetSingle(id);
            return View(employee);
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
            EmployeeModel employee = dataAccessObject.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditConfirmed(EmployeeModel employee)
        {
            dataAccessObject.Edit(employee);
            return RedirectToAction("Index", "Home");          
        }
    }
}