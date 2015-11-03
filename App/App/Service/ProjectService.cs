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

            if (projectViewModel.EndDate != null)
            {
                DateTime.TryParse(projectViewModel.EndDate, out temporaryDate);
                project.EndDate = temporaryDate;
            }

            return project;
        }
    }
}