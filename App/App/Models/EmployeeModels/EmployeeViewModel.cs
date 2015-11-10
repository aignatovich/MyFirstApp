using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models;
using App.Validation;

namespace App.Models
{
    [EmployeeValidationAttribute]
    public class EmployeeViewModel : IViewModel<EmployeeViewModel>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        public Roles Position { get; set; }

        public  ICollection<ProjectViewModel> ActualProjects { get; set; }

        public EmployeeViewModel()
        {
            ActualProjects = new List<ProjectViewModel>();
        }

        public EmployeeViewModel(EmployeeModel employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Position = employee.Position;

            foreach (ProjectModel project in employee.ActualProjects)
            {
                //ActualProjects.Add(new ProjectViewModel(project));
                //preventing circulative constructor calls
                //need to solve
            }

        }

        public EmployeeModel AsEmployeeModel()
        {
            EmployeeModel toTransfer = new EmployeeModel();
            toTransfer.Id = this.Id;
            toTransfer.Name = this.Name;
            toTransfer.Surname = this.Surname;
            toTransfer.Position = this.Position;
            ICollection<ProjectModel> projectList = new List<ProjectModel>();
            foreach (ProjectViewModel project in this.ActualProjects)
            {
                projectList.Add(project.AsProjectModel());
            }

            toTransfer.ActualProjects = new List<ProjectModel>(projectList);

            return toTransfer;
        }

        public EmployeeViewModel ConvertToModel()
        {
            throw new NotImplementedException();
        }
    }
}
