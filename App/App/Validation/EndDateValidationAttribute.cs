using App.DAL;
using App.Models;
using App.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static App.DAL.ProjectDataAccessObject;

namespace App.Validation
{
    public class EndDateValidationAttribute: ValidationAttribute
    {
        private ProjectDataAccessObject ProjectDataAccessObject = new ProjectDataAccessObject();
        private ProjectService projectService = new ProjectService();
        protected override ValidationResult IsValid(object project, ValidationContext validationContext)
        {
            ProjectViewModel projectViewModel = validationContext.ObjectInstance as ProjectViewModel;
            ProjectModel projectModel = projectService.AsProject(projectViewModel);

            if (!ProjectDataAccessObject.Exists(projectModel) && isDateValid(projectModel))
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