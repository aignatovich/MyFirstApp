using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class ProjectService
    {
        private ProjectDataAccessObject projectDataAccessObject = new ProjectDataAccessObject();
        private EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();
        private EmployeeService employeeService = new EmployeeService();

        public ICollection<ProjectViewModel> GetAllViewModels()
        {
            ICollection<ProjectModel> projectList = projectDataAccessObject.GetAll();
            ICollection<ProjectViewModel> toTransfer = new List<ProjectViewModel>();
            foreach (ProjectModel item in projectList)
            {
                toTransfer.Add(new ProjectViewModel(item));
            }
            return toTransfer;
        }

        public void EmployInProject(int projectId, IEnumerable<Int32> ids)
        {
            ProjectModel project = projectDataAccessObject.GetSingle(projectId);
            ICollection<EmployeeModel> employees = employeeService.GetEmployeesByIds(ids);
            project.CurrentEmployees.Clear();
            project.CurrentEmployees = employees;

            foreach (EmployeeModel employee in project.CurrentEmployees)
            {
                employee.ActualProjects.Add(project);
            }
        }

        public void Add(ProjectViewModel projectViewModel)
        {
            ProjectModel projectModel = projectViewModel.AsProjectModel();
            projectDataAccessObject.Add(projectModel);
        }

        public ProjectViewModel GetSingle(int id)
        {
            return new ProjectViewModel(projectDataAccessObject.GetSingle(id));
        }

        public void Edit(ProjectViewModel projectViewModel)
        {
            ProjectModel toEdit =  projectViewModel.AsProjectModel();
            projectDataAccessObject.Edit(toEdit);
        }

        public void Remove(ProjectViewModel project)
        {
            projectDataAccessObject.Remove(project.Id);
        }
    }
}