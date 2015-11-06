using App.DAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class EmployeeService
    {
        private ProjectService projectService = new ProjectService();
        private EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();


        public ICollection<EmployeeViewModel> GetEmployeesByIds(IEnumerable<Int32> ids)
        {
            ICollection<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            foreach (Int32 employeeId in ids)
            {
                employees.Add(new EmployeeViewModel(employeeDataAccessObject.GetSingle(employeeId)));
            }

            return employees;
        }

        public void Add(EmployeeViewModel employee)
        {
            employeeDataAccessObject.Add(AsEmployee(employee));
        }

        public ICollection<EmployeeViewModel> GetAll()
        {
            ICollection<EmployeeViewModel> toTransfer = new List<EmployeeViewModel>();
            ICollection<EmployeeModel> employees = employeeDataAccessObject.GetAll();

            foreach (EmployeeModel e in employees)
            {
                toTransfer.Add(new EmployeeViewModel(e));
            }

            return toTransfer;
        }

        public EmployeeViewModel GetSingle(int id)
        {
            return new EmployeeViewModel (employeeDataAccessObject.GetSingle(id));
        }

        public void Remove(EmployeeViewModel employee)
        {
            employeeDataAccessObject.Remove(employee.Id);
        }

        public void Edit(EmployeeViewModel employee)
        {
            employeeDataAccessObject.Edit(AsEmployee(employee));
        }

        public EmployeeModel AsEmployee(EmployeeViewModel employee)
        {
            EmployeeModel toTransfer = new EmployeeModel();
            toTransfer.Id = employee.Id;
            toTransfer.Name = employee.Name;
            toTransfer.Surname = employee.Surname;
            toTransfer.Position = employee.Position;
            ICollection<ProjectModel> projectList = new List<ProjectModel>();
            foreach (ProjectViewModel project in employee.ActualProjects)
            {
                projectList.Add(projectService.AsProject(project));
            }

            toTransfer.ActualProjects = new List<ProjectModel>(projectList);

            return toTransfer;
        }
    }
}