﻿using App.Models;
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
                return RedirectToAction("ShowEmployees");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ShowEmployees()
        {
            ICollection<EmployeeModel> toTransfer = dataAccessObject.GetAll();
            return View(toTransfer);
        }

        [HttpGet]
        public ActionResult RemoveEmployee(int id)
        {
            EmployeeModel employee = dataAccessObject.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(EmployeeModel employee)
        {
            dataAccessObject.Remove(employee.Id);
            return RedirectToAction("ShowEmployees");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeModel employee = dataAccessObject.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel employee)
        {
            dataAccessObject.Edit(employee);
            return RedirectToAction("ShowEmployees");          
        }
    }
}