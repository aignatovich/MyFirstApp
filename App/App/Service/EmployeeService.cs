using App.DAL;
using App.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class EmployeeService
    {
        private EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();
        private int pageSize = 50;

        public ICollection<EmployeeModel> GetEmployeesByIds(IEnumerable<Int32> ids)
        {
            ICollection<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (Int32 employeeId in ids)
            {
                employees.Add(employeeDataAccessObject.GetSingle(employeeId));
            }

            return employees;
        }

        public void Add(EmployeeViewModel employee)
        {
            EmployeeModel toTransfer = employee.AsEmployeeModel();
            employeeDataAccessObject.Add(toTransfer);
        }

        public ICollection<EmployeeViewModel> GetAllViewModels()
        {
            ICollection<EmployeeViewModel> toTransfer = new List<EmployeeViewModel>();
            ICollection<EmployeeModel> employees = employeeDataAccessObject.GetAll();

            foreach (EmployeeModel e in employees)
            {
                toTransfer.Add(new EmployeeViewModel(e));
            }

            return toTransfer;
        }

        public EmployeeViewModel GetSingle(int id)
        {
            return new EmployeeViewModel (employeeDataAccessObject.GetSingle(id));
        }

        public void Remove(EmployeeViewModel employee)
        {
            employeeDataAccessObject.Remove(employee.Id);
        }

        public void Edit(EmployeeViewModel employee)
        {
            EmployeeModel toTransfer = employee.AsEmployeeModel();
            employeeDataAccessObject.Edit(toTransfer);
        }

        public IPagedList<EmployeeViewModel> GetAllAsIPagedList(int? page, int? sorting)
        {
            int pageNumber = (page ?? 1);
            int sortingOrder = (sorting ?? 2);
            List<EmployeeViewModel> employees = GetAllViewModels().ToList();
            List<EmployeeViewModel> toTransfer = new List<EmployeeViewModel>();
            switch (sortingOrder)
            {
                case 1:
                    toTransfer = employees.OrderBy(x => x.Position.ToString()).ToList();
                    break;
                case 2:
                    toTransfer = employees.OrderBy(x => x.Name).ToList();
                    break;
                case 3:
                    toTransfer = employees.OrderBy(x => x.Surname).ToList();
                    break;
            }
            return toTransfer.ToPagedList(pageNumber, pageSize);
        }
    }
}