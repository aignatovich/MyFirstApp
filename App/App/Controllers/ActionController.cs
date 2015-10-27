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
            if (dbContext.EmployeeSet.ToList().Where(x => x.Equals(employee)).FirstOrDefault()  == null)
            {
                dbContext.EmployeeSet.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Apologize");
            }         
        }


        public ActionResult ShowEmployees()
        {
            dbContext = new DatabaseModelContainer();
            ICollection <Employee> toTransfer = dbContext.EmployeeSet.ToList();
            return View(toTransfer);
        }

        public ActionResult RemoveEmployee(string id)
        {
            dbContext = new DatabaseModelContainer();
            int employeeId = Convert.ToInt32(id);
            Employee toTransfer = dbContext.EmployeeSet.Where(x => x.Id == employeeId).FirstOrDefault();
            return View(toTransfer);
        }

        public ActionResult RemoveConfirmed(string id)
        {
            dbContext = new DatabaseModelContainer();
            dbContext.EmployeeSet.Find(Convert.ToInt32(id)).Deleted = true;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult EditEmployee(string id)
        {
            dbContext = new DatabaseModelContainer();
            int employeeId = Convert.ToInt32(id);
            Employee toTransfer = dbContext.EmployeeSet.Where(x => x.Id == employeeId).FirstOrDefault();
            return View(toTransfer);
        }

        public ActionResult EditConfirmed(Employee emp)
        {
            dbContext = new DatabaseModelContainer();
            dbContext.EmployeeSet.Find(Convert.ToInt32(emp.Id)).Deleted = true;
            if (dbContext.EmployeeSet.ToList().Where(x => x.Equals(emp)).FirstOrDefault() == null)
            {
                dbContext.EmployeeSet.Add(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Apologize");
            }
        }
    }
}