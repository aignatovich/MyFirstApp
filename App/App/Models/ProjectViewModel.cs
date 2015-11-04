using App.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class ProjectViewModel : IViewModel<ProjectModel>
    {
        private const string EMPTY_DATE_VALUE_PLACEHOLDER = "...";

        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string StartDate { get; set; }

        [EndDateValidationAttribute]
        public string EndDate { get; set; }

        public ICollection<EmployeeModel> CurrentEmployees { get; set; }

        public ProjectViewModel()
        {
            CurrentEmployees = new List<EmployeeModel>();
        }

        public ProjectViewModel(ProjectModel project)
        {
            Id = project.Id;
            Name = project.Name;
            StartDate = project.StartDate.ToShortDateString();
            CurrentEmployees = project.CurrentEmployees;

            if (!(project.EndDate == null))
            {
                EndDate = project.EndDate.Value.ToShortDateString();
            }
            else
            {
                EndDate = EMPTY_DATE_VALUE_PLACEHOLDER;
            }
        }

        public ProjectModel ConvertToModel()
        {
            throw new NotImplementedException();
        }

    }
}