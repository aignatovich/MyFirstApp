using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class PositionsEnum
    {
        private IEnumerable<String> Roles { get; set; } = new List<String> { "-", "Dev", "BA", "QA", "PM", "Other" };
        public IEnumerable<String> GetRoles()
        {
            return Roles;
        }
            
    }
}