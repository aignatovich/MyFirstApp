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

        public ProjectModel AsProject(ProjectViewModel projectViewModel)
        {
            ProjectModel project = new ProjectModel();
            project.Id = projectViewModel.Id;
            project.Name = projectViewModel.Name;
            DateTime temporaryDate = new DateTime();
            DateTime.TryParse(projectViewModel.StartDate, out temporaryDate);
            project.StartDate = temporaryDate;
            project.CurrentEmployees = projectViewModel.CurrentEmployees;

            if (projectViewModel.EndDate != null)
            {
                DateTime.TryParse(projectViewModel.EndDate, out temporaryDate);
                project.EndDate = temporaryDate;
            }

            return project;
        }

        public void EmployInProject(int projectId, string employeeIds)
        {
            ProjectModel project = projectDataAccessObject.GetSingle(projectId);
            ICollection<EmployeeModel> employees = employeeService.GetEmployeesByIds(employeeIds);
            project.CurrentEmployees.Clear();
            project.CurrentEmployees = employees;

            foreach (EmployeeModel employee in project.CurrentEmployees)
            {
                employee.ActualProjects.Add(project);
            }
        }

        public void Add(ProjectViewModel projectViewModel)
        {
            ProjectModel projectModel = AsProject(projectViewModel);
            projectDataAccessObject.Add(projectModel);
        }

        public ProjectViewModel GetSingle(int id)
        {
            return new ProjectViewModel(projectDataAccessObject.GetSingle(id));
        }

        public void Edit(ProjectViewModel projectViewModel)
        {
            ProjectModel toEdit = AsProject(projectViewModel);
            projectDataAccessObject.Edit(toEdit);
        }

        public void Remove(ProjectViewModel project)
        {
            projectDataAccessObject.Remove(project.Id);
        }
    }
}