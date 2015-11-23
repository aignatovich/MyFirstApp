using App.Models;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using App.Service;

namespace App.DAL
{
    public class EmployeeDataAccessObject: IEmployeeDAO
    {
        public void Add(EmployeeModel employee)
        {                   
            DatabaseModelContainer.Current.EmployeeSet.Add(employee);
        }

        public void Edit(EmployeeModel employee)
        {
            EmployeeModel editableEmployee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == employee.Id).FirstOrDefault();
            editableEmployee.Name = employee.Name;
            editableEmployee.Surname = employee.Surname;
            editableEmployee.Position = employee.Position;
        }

        public void Remove(int id)
        {
            EmployeeModel employee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            DatabaseModelContainer.Current.EmployeeSet.Remove(employee);
        }

        public ICollection<EmployeeModel> GetAll()
        {
            ICollection<EmployeeModel> employeeList = DatabaseModelContainer.Current.EmployeeSet.ToList();
            return employeeList;
        }

        public EmployeeModel GetSingle(int id)
        {
            EmployeeModel employee = DatabaseModelContainer.Current.EmployeeSet.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        public  bool Exists(EmployeeModel employee)
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