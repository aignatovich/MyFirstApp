using App.DAL;
using App.Models;
using App.Service;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Validation
{
    public class EmployeeValidationAttribute: ValidationAttribute
    {
        private  EmployeeDataAccessObject EmployeeDataAccessObject = new EmployeeDataAccessObject();
        private EmployeeService employeeService = new EmployeeService();

        protected override  ValidationResult IsValid(object value,  ValidationContext validationContext)
        {
            if (!EmployeeDataAccessObject.Exists(employeeService.AsEmployee(validationContext.ObjectInstance as EmployeeViewModel)))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Oops, something went wrong, seems this employee has already been added");
        }
       
    }
}