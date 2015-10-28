using App.Models;
using System.Data.Entity;

namespace CodeFirst
{
    public class DatabaseModelContainer : DbContext
    {

        public DatabaseModelContainer()           
        {
            Database.SetInitializer<DatabaseModelContainer>(null);
        }

        public DbSet<Employee> EmployeeSet { get; set; }
    }
}