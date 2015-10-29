﻿using App.Models;
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
    public class EmployeeDataAccessObject
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
            Employee editableEmployee = dbContext.EmployeeSet.Where(x => x.Id == employee.Id).FirstOrDefault();
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

        public static bool Exists(Employee employee)
        {
            DatabaseModelContainer dbContext = new DatabaseModelContainer();            
            return (dbContext.EmployeeSet.Any(x =>
                               x.Name.Equals(employee.Name) &&
                               x.Surname.Equals(employee.Surname) &&
                               x.Position.ToString().Equals(employee.Position.ToString()))) ||
                               (employee.Name == null || 
                               employee.Surname == null);
       }
    }
}