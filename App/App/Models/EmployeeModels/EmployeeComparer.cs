using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ProjectModels
{
    class EmployeeComparer : IEqualityComparer<EmployeeModel>
    {
        public bool Equals(EmployeeModel x, EmployeeModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(EmployeeModel obj)
        {
            return obj.Id;
        }

    }

}