using App.Models;
using CodeFirst;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static App.DAL.EmployeeDAO;

namespace App.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {

        public EmployeeValidator()
        {
            RuleFor(x => x).Must(BeValueUnique).WithMessage("qwe");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }

        private bool BeValueUnique(Employee employee)
        {
            if (!Exists(employee))
            {
                return true;
            }
            return false;
        }
       
    }
}