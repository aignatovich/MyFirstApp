using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class ExtendedProjectService
    {
        private EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();
        private ProjectDataAccessObject projectDataAccessObject = new ProjectDataAccessObject();
        private EmployeeService employeeService = new EmployeeService();
        private ProjectService projectService = new ProjectService();

        public ExtendedProjectViewModel Create(int projectId)
        {
            ExtendedProjectViewModel toTransfer = new ExtendedProjectViewModel(employeeService.GetAllViewModels(), projectService.GetSingle(projectId));
            return toTransfer;
        }
    }
}