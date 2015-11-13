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

        public Day FirstDay { get; set; }

        public ICollection<String> YearList { get; set; }

        public TableData()
        {
           YearList = new List<String>() { "2015", "2014", "2013", "2012" };
        }

        public  TableData(IPagedList<EmployeeViewModel> employees, HttpRequestBase request)
        {
            int year = Convert.ToInt32(request["year"]);
            int month = Convert.ToInt32(request["month"]);
            if (year == 0)
            {
                year = 2015;
            }
            if (month == 0)
            {
                month = 1;
            }

            YearList = new List<String>() { "2015", "2014", "2013", "2012", "2011" };
            Employees = employees;
            Month = (Month)month;
            Year = year;
            DayLimit = DateTime.DaysInMonth(year, month);
            FirstDay = (Day)(int)(new DateTime(year, month, 1)).DayOfWeek;
        }
    }
}