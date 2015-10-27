using App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App.DAL
{
    public class EmployeeDAL
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
            dbContext.EmployeeSet.Attach(employee);
            dbContext.Entry(employee).State = EntityState.Modified;
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
    }
}