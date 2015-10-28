using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Models;
using static App.DAL.EmployeeDAO;
using FluentValidation.Attributes;
using App.Validation;

namespace App.Models
{
    [Validator(typeof(EmployeeValidator))]
    public class Employee
    {      
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        public string Position { get; set; }
        

    }
}
