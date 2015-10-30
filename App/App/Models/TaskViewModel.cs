using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public TaskModel AsTask()
        {
            TaskModel task = new TaskModel();
            task.Name = this.Name;
            task.StartDate = ToDateTime(StartDate);
            task.EndDate = ToDateTime(EndDate);
            return task;
        }

        public DateTime ToDateTime(string convertable)
        {
            int month = Convert.ToInt32(convertable.Substring(0, convertable.IndexOf("/")));
            int searchStartIndex = convertable.IndexOf("/", 0) + 1;
            int searchEndIndex = convertable.IndexOf("/", searchStartIndex);
            int day = Convert.ToInt32(convertable.Substring(searchStartIndex, searchEndIndex));
            int year = Convert.ToInt32(convertable.Substring(convertable.LastIndexOf("/"), convertable.Length));
            DateTime dateTime = new DateTime(year, month, day);
            return dateTime;
        }

    }
}