using App.Models;
using System.Web.Mvc;
using App.Service;
using PagedList;
using System;
using System.Web;

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
        public ActionResult CreateEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                service.Add(employee);
                return RedirectToAction("ShowEmployees");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ShowEmployees(int? page, int? sort, int? month, int? year)
        {
            IPagedList<EmployeeViewModel> toTransfer = service.GetAllAsIPagedList(month,year, page,sort);
            return View(toTransfer);
        }

        [HttpGet]
        public ActionResult RemoveEmployee(int id)
        {
            EmployeeViewModel employee = service.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(EmployeeViewModel employee)
        {
            service.Remove(employee);
            return RedirectToAction("ShowEmployees");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeViewModel employee = service.GetSingle(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeViewModel employee)
        {
            service.Edit(employee);
            return RedirectToAction("ShowEmployees");          
        }

        [HttpGet]
        public ActionResult Manage(int? data)
        {
            HttpRequestBase request = Request;
            return View(service.GetTableData(request));
        }

        [HttpPost]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public void ApplyChanges()
        {
            HttpRequestBase request = Request;
            service.ApplyAbsence(request);
        }
    }
}