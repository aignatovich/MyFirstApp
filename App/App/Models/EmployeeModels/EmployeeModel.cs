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
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        public RolesTemporary Position { get; set; }

        public virtual ICollection<ProjectModel> ActualProjects { get; set; }

        public EmployeeModel()
        {
            ActualProjects = new List<ProjectModel>();
        }

        public EmployeeModel ConvertToModel()
        {
            throw new NotImplementedException();
        }
    }
}
