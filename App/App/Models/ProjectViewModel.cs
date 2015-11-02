using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class ProjectViewModel : IViewModel<ProjectModel>
    {
        private const string EMPTY_DATE_VALUE_PLACEHOLDER = "...";
        private  DateTime DEFAULT_DATE_VALUE = DateTime.MaxValue;

        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public ProjectViewModel()
        {

        }

        public ProjectViewModel(ProjectModel project)
        {
            Id = project.Id;
            Name = project.Name;
            StartDate = project.StartDate.ToString();

            if (!project.EndDate.ToString().Equals(DEFAULT_DATE_VALUE.ToString()))
            {
                EndDate = project.EndDate.ToString();
            }
            else
            {
                EndDate = EMPTY_DATE_VALUE_PLACEHOLDER;
            }
        }

        public ProjectModel AsProject()
        {
            ProjectModel project = new ProjectModel();
            project.Id = Id;
            project.Name = Name;
            project.StartDate = ToDateTime(StartDate);

            if (EndDate != null)
            {
                project.EndDate = ToDateTime(EndDate);
            }
            else
            {
                project.EndDate = DEFAULT_DATE_VALUE;
            }

            return project;
        }

        public DateTime ToDateTime(string convertable)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(convertable, out dateTime))
            {
                if (!convertable.Equals(EMPTY_DATE_VALUE_PLACEHOLDER))
                {
                    int month = Convert.ToInt32(convertable.Substring(0, convertable.IndexOf("/")));
                    int searchStartIndex = convertable.IndexOf("/", 0) + 1;
                    int searchEndIndex = convertable.IndexOf("/", searchStartIndex);
                    int day = Convert.ToInt32(convertable.Substring(searchStartIndex, searchEndIndex - searchStartIndex));
                    int year = Convert.ToInt32(convertable.Substring(convertable.LastIndexOf("/") + 1, 4));
                    dateTime = new DateTime(year, month, day);
                }
                else
                {
                    dateTime = DEFAULT_DATE_VALUE;
                }
            }
            return dateTime;
        }

        public ProjectModel ConvertToModel()
        {
            throw new NotImplementedException();
        }
    }
}