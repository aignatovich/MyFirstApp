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
        EmployeeDataAccessObject dataAccessObject = new EmployeeDataAccessObject();
        public ICollection<EmployeeModel> GetEmployeesByIds(string ids)
        {
            ICollection<EmployeeModel> employees = new List<EmployeeModel>();
            string[] employeeIds = ids.Trim().Split(' ');
            int id = 0;

            foreach (string employeeId in employeeIds)
            {
                if (Int32.TryParse(employeeId, out id))
                {
                    employees.Add(dataAccessObject.GetSingle(id));
                }
            }

            return employees;
        }
    }
}