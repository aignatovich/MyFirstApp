using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.ModelBinding
{
    public class IdsArrayBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(IEnumerable<Int32>))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                string[] idsSequence = request.Form.Get("ids").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string[] ids = idsSequence[0].Trim().Split(' ');
                ICollection<Int32> list = new List<int>();
                foreach (string id in ids)
                {
                    int tmp;
                    if (int.TryParse(id, out tmp))
                    {
                        list.Add(tmp);
                    }
                }

                return list;
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }

    }
}