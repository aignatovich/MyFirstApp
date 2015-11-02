using App.DAL;
using App.Models;
using CodeFirst;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Validation
{
    public class EmployeeValidator
    {
        private static EmployeeDataAccessObject EmployeeDataAccessObject = new EmployeeDataAccessObject();
        public static bool BeValueUnique(EmployeeModel employee)
        {
            if (!EmployeeDataAccessObject.Exists(employee))
            {
                return true;
            }
            return false;
        }
       
    }
}