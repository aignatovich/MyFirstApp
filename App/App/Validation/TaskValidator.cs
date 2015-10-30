using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static App.DAL.TaskDataAccessObject;

namespace App.Validation
{
    public class TaskValidator
    {
        public static bool BeValueUnique(TaskModel task)
        {
            if (!Exists(task))
            {
                return true;
            }
            return false;
        }
    }
}