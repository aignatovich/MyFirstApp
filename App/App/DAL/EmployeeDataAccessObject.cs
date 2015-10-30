using App.Models;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace App.DAL
{
    public class EmployeeDataAccessObject:IOperations<Employee>
    {
        public void Add(Employee employee)
        {                   
            DatabaseModelContainer.Current.EmployeeSet.Add(employee);
        }

        public void Edit(Employee employee)
        {
            Employee editableEmployee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == employee.Id).FirstOrDefault();
            editableEmployee.Name = employee.Name;
            editableEmployee.Surname = employee.Surname;
            editableEmployee.Position = employee.Position;
        }

        public void Remove(int id)
        {
            Employee employee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            DatabaseModelContainer.Current.EmployeeSet.Remove(employee);
        }

        public ICollection<Employee> GetAll()
        {
            ICollection<Employee> employeeList = DatabaseModelContainer.Current.EmployeeSet.ToList();
            return employeeList;
        }

        public Employee GetSingle(int id)
        {
            Employee employee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        public static bool Exists(Employee employee)
        {         
            return (DatabaseModelContainer.Current.EmployeeSet.Any(x =>
                               x.Name.Equals(employee.Name) &&
                               x.Surname.Equals(employee.Surname) &&
                               x.Position.ToString().Equals(employee.Position.ToString()))) ||
                               (employee.Name == null || 
                               employee.Surname == null);
       }
    }
}