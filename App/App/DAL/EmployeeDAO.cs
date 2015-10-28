using App.Models;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App.DAL
{
    public class EmployeeDAO
    {
        private DatabaseModelContainer dbContext;

        public void AddEmployee(Employee employee)
        {
            dbContext = new DatabaseModelContainer();
            dbContext.EmployeeSet.Add(employee);
            dbContext.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            dbContext = new DatabaseModelContainer();
            Employee editableEmployee = dbContext.EmployeeSet.Where(x => x.Id.Equals(employee.Id)).FirstOrDefault();
            editableEmployee.Name = employee.Name;
            editableEmployee.Surname = employee.Surname;
            editableEmployee.Position = employee.Position;
            dbContext.SaveChanges();
        }

        public void RemoveEmployee(int id)
        {
            dbContext = new DatabaseModelContainer();
            Employee employee = dbContext.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            dbContext.EmployeeSet.Remove(employee);
            dbContext.SaveChanges();
        }

        public ICollection<Employee> GetAllEmployees()
        {
            dbContext = new DatabaseModelContainer();
            ICollection<Employee> employeeList = dbContext.EmployeeSet.ToList();
            return employeeList;
        }

        public Employee GetSingleEmployee(int id)
        {
            dbContext = new DatabaseModelContainer();
            Employee employee = dbContext.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        public bool Exists(Employee employee)
        {
            dbContext = new DatabaseModelContainer();
            if (dbContext.EmployeeSet.Where(x => x.Equals(employee)).FirstOrDefault() == null)
            {
                return true;
            }
            return false;               
       }
    }
}