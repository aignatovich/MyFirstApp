using App.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
namespace App.Models
{
    [Validator(typeof(EmployeeValidator))]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        public string Position { get; set; }

        public bool Equals(Employee employee)
        {
            return Name.Equals(employee.Name) &&
                   Surname.Equals(employee.Surname) &&
                   Position.Equals(employee.Position);
        }
    }
}
