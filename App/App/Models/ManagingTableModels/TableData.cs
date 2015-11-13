using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ManagingTableModels
{
    public class TableData
    {
        public IPagedList<EmployeeViewModel> Employees { get; set; }

        public Month Month { get; set; }

        public int Year { get; set; }

        public int DayLimit { get; set; }

        public DayEnum FirstDay { get; set; }

        public int StartYear { get; set; }

        public TableData()
        {
        }

        public  TableData(IPagedList<EmployeeViewModel> employees, ManagingRequest request)
        {
            int year = (request.Year ?? DateTime.Now.Year);
            int month = (request.Month ?? DateTime.Now.Month);

            Employees = employees;
            Month = (Month)month;
            Year = year;
            DayLimit = DateTime.DaysInMonth(year, month);
            FirstDay = (DayEnum)(int)(new DateTime(year, month, 1)).DayOfWeek;
            StartYear = 2010;
        }
    }
}