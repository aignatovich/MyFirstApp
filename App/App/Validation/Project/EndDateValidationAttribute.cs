using App.DAL;
using App.Models;
using App.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Validation
{
    public class EndDateValidationAttribute: ValidationAttribute
    {
        private ProjectDataAccessObject ProjectDataAccessObject = new ProjectDataAccessObject();

        protected override ValidationResult IsValid(object project, ValidationContext validationContext)
        {
            ProjectViewModel projectViewModel = validationContext.ObjectInstance as ProjectViewModel;
            ProjectModel projectModel = projectViewModel.AsProjectModel();

            if (isDateValid(projectModel))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Are you a timetraveller? Check if end date is valid");
        }

        public static bool isDateValid(ProjectModel project)
        {
            return (project.EndDate == null || !(project.StartDate > project.EndDate));
        }
    }
}