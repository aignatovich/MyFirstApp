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

        protected override  ValidationResult IsValid(object value,  ValidationContext validationContext)
        {
            if (!EmployeeDataAccessObject.Exists((validationContext.ObjectInstance as EmployeeViewModel).AsEmployeeModel()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Oops, something went wrong, seems this employee has already been added");
        }
       
    }
}