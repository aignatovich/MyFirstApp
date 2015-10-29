using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Models
{
    public class Positions
    {
        public enum RolesTemporary { Dev = 1, BA = 2, QA = 3, PM = 4, Other = 5 };

        public List<SelectListItem> GetRoles()
        {
            IEnumerable<String> RoleList = Enum.GetNames(typeof(RolesTemporary)).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (String role in RoleList)
            {
                items.Add(new SelectListItem { Text = role, Value = ((int)Enum.Parse(typeof(RolesTemporary), role)).ToString() });
            }

            return items;
        }

    }
}