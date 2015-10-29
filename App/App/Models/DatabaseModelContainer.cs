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


        //public StoredRole Roles { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
    }
}