using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ManagingTableModels
{
    public class ManagingTableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<EmployeeModel, List<Int32>> AbsenceList { get; set; }
    }
}