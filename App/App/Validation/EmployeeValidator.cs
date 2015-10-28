using App.Models;
using CodeFirst;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.DAL;

namespace App.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        private EmployeeDAO DAO = new EmployeeDAO();

        public EmployeeValidator()
        {
            RuleFor(x => x).Must(BeValueUnique).WithMessage("This employee already exists");
        }

        private bool BeValueUnique(Employee employee)
        {
            if (DAO.Exists(employee))
            {
                return true;
            }
            return false;
        }
       
    }
}