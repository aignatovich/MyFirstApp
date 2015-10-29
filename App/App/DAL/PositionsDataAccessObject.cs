using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Models
{
    public class PositionsDataAccessObject
    {
        public List<SelectListItem> GetRoles()
        {
            IEnumerable<String> RoleList = GetNames();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (String role in RoleList)
            {
                items.Add(new SelectListItem { Text = role, Value = ((int)Enum.Parse(typeof(RolesTemporary), role)).ToString() });
            }

            return items;
        }

        public string GetStringValue(int value)
        {
            RolesTemporary roles = (RolesTemporary)value;
            return roles.ToString();
        }

        public IEnumerable<String> GetNames()
        {
            IEnumerable<String> RoleList = Enum.GetNames(typeof(RolesTemporary)).ToList();
            return RoleList;
        }
        public Array GetValues()
        {
            Array RoleList = Enum.GetValues(typeof(RolesTemporary));
            return RoleList;
        }

    }
}