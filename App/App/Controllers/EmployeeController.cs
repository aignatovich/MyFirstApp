using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.DAL;
using CodeFirst;
using App.Service;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService service = new EmployeeService();

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
                service.Add(employee);
                return RedirectToAction("ShowEmployees");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ShowEmployees()
        {
            ICollection<EmployeeModel> toTransfer = service.GetAll();
            return View(toTransfer);
        }

        [HttpGet]
        public ActionResult RemoveEmployee(int id)
        {
            EmployeeModel employee = service.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(EmployeeModel employee)
        {
            service.Remove(employee);
            return RedirectToAction("ShowEmployees");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeModel employee = service.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel employee)
        {
            service.Edit(employee);
            return RedirectToAction("ShowEmployees");          
        }
    }
}