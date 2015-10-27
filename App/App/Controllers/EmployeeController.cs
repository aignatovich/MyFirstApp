using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.DAL;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseModelContainer dbContext = new DatabaseModelContainer();
        private EmployeeDAL DAL = new EmployeeDAL();

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            DAL.AddEmployee(employee);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowEmployees()
        {
            ICollection<Employee> toTransfer = DAL.GetAllEmployees();
            return View(toTransfer);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(int id)
        {
            Employee employee = DAL.GetSingleEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult RemoveConfirmed(int id)
        {
            DAL.RemoveEmployee(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditEmployee(int id)
        {
            return View(DAL.GetSingleEmployee(id));
        }

        [HttpPost]
        public ActionResult EditConfirmed(Employee employee)
        {
            DAL.EditEmployee(employee);
            return RedirectToAction("Index", "Home");          
        }
    }
}