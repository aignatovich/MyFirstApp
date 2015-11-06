using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Binding
{
    public class IntegerArrayFilterAttribute : ActionFilterAttribute
    {
        public string ParameterName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ICollection<Int32> list  = new List<int>();
            string[] idsSequence = filterContext.HttpContext.Request.Form["ids"]
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] ids = idsSequence[0].Trim().Split(' ');

            foreach (string id in ids)
            {
                int tmp;
                if (int.TryParse(id, out tmp))
                {
                    list.Add(tmp);
                }
            }
            filterContext.ActionParameters[ParameterName] = list;
        }
    }
}