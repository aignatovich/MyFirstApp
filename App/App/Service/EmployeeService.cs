using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class EmployeeService
    {
        EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();
        public ICollection<EmployeeModel> GetEmployeesByIds(string ids)
        {
            ICollection<EmployeeModel> employees = new List<EmployeeModel>();
            string[] employeeIds = ids.Trim().Split(' ');
            int id = 0;

            foreach (string employeeId in employeeIds)
            {
                if (Int32.TryParse(employeeId, out id))
                {
                    employees.Add(employeeDataAccessObject.GetSingle(id));
                }
            }

            return employees;
        }

        public void Add(EmployeeModel employee)
        {
            employeeDataAccessObject.Add(employee);
        }

        public ICollection<EmployeeModel> GetAll()
        {
            return employeeDataAccessObject.GetAll();
        }

        public EmployeeModel GetSingle(int id)
        {
            return employeeDataAccessObject.GetSingle(id);
        }

        public void Remove(EmployeeModel employee)
        {
            employeeDataAccessObject.Remove(employee.Id);
        }

        public void Edit(EmployeeModel employee)
        {
            employeeDataAccessObject.Edit(employee);
        }
    }
}