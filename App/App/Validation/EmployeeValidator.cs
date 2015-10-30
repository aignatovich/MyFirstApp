using App.Models;
using CodeFirst;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static App.DAL.EmployeeDataAccessObject;

namespace App.Validation
{
    public class EmployeeValidator
    {
        public static bool BeValueUnique(Employee employee)
        {
            if (!Exists(employee))
            {
                return true;
            }
            return false;
        }
       
    }
}