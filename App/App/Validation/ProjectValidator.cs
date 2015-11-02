using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static App.DAL.ProjectDataAccessObject;

namespace App.Validation
{
    public class ProjectValidator
    {
        private static ProjectDataAccessObject ProjectDataAccessObject = new ProjectDataAccessObject();
        public static bool BeValueUnique(ProjectModel project)
        {         
            if (!ProjectDataAccessObject.Exists(project) && isDateValid(project))
            {
                return true;
            }
            return false;
        }

        public static bool isDateValid(ProjectModel project)
        {
            return (project.EndDate == null || !(project.StartDate > project.EndDate));
        }
    }
}