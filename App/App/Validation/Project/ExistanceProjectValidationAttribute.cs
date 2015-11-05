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
    public class ExistanceProjectValidationAttribute:ValidationAttribute
    {
        private ProjectDataAccessObject ProjectDataAccessObject = new ProjectDataAccessObject();
        private ProjectService projectService = new ProjectService();
        protected override ValidationResult IsValid(object project, ValidationContext validationContext)
        {
            ProjectViewModel projectViewModel = validationContext.ObjectInstance as ProjectViewModel;
            ProjectModel projectModel = projectService.AsProject(projectViewModel);

            if (!ProjectDataAccessObject.Exists(projectModel))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Project already exists");
        }
    }
}