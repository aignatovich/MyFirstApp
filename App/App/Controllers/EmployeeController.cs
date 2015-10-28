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
        private DatabaseModelContainer dbContext = new DatabaseModelContainer();
        private EmployeeDAO dataAccessObject = new EmployeeDAO();

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            dataAccessObject.AddEmployee(employee);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ShowEmployees()
        {
            ICollection<Employee> toTransfer = dataAccessObject.GetAllEmployees();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(int id)
        {
            Employee employee = dataAccessObject.GetSingleEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult RemoveConfirmed(int id)
        {
            dataAccessObject.RemoveEmployee(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditEmployee(int id)
        {
            Employee employee = dataAccessObject.GetSingleEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditConfirmed(Employee employee)
        {
            dataAccessObject.EditEmployee(employee);
            return RedirectToAction("Index", "Home");          
        }
    }
}