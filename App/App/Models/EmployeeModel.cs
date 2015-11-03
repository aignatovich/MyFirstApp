using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models;
using App.Validation;

namespace App.Models
{
    [EmployeeValidationAttribute]
    public class EmployeeModel : IViewModel<EmployeeModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        public RolesTemporary Position { get; set; }

        public EmployeeModel ConvertToModel()
        {
            throw new NotImplementedException();
        }
    }
}
