using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ActionController : Controller
    {
        private DatabaseModelContainer dbContext;

        public ActionResult AddEmployee()
        {
            return View();
        }

        public ActionResult CreateEmployee(Employee employee)
        {
            dbContext = new DatabaseModelContainer();
            dbContext.EmployeeSet.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}