using App.Models.ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class ExtendedProjectViewModel:ProjectViewModel
    {
        public ICollection<Tuple<String,Int32>> Employees { get; set; }
        public ICollection<Tuple<String, Int32>> Current { get; set; }

        public ExtendedProjectViewModel()
        {
            Employees = new List<Tuple<String, Int32>>();
            Current = new List<Tuple<String, Int32>>();
        }

        public ExtendedProjectViewModel(ICollection<EmployeeModel> employees, ProjectViewModel project):base(project)
        {
            Employees = new List<Tuple<String, Int32>>();
            Current = new List<Tuple<String, Int32>>();

            IEnumerable<EmployeeModel> employeeModels = employees.Except(project.CurrentEmployees, new EmployeeComparer());
            foreach (EmployeeModel e in employeeModels)
            {
                Employees.Add(new Tuple<String,Int32>(String.Format("{2} - {0} {1}", e.Name, e.Surname, e.Position), e.Id));
            }
            foreach (EmployeeModel e in project.CurrentEmployees)
            {
                Current.Add(new Tuple<String, Int32>(String.Format("{2} - {0} {1}", e.Name, e.Surname, e.Position), e.Id));
            }
        }
    }
}