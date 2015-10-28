using App.Models;
using System.Data.Entity;

namespace CodeFirst
{
    public class DatabaseModelContainer : DbContext
    {

        public DatabaseModelContainer()           
        {

        }

        public DbSet<Employee> EmployeeSet { get; set; }
    }
}