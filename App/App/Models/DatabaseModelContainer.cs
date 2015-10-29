using App.Models;
using System.Data.Entity;

namespace CodeFirst
{
    public class DatabaseModelContainer : DbContext
    {

        public DatabaseModelContainer()           
        {
            Database.SetInitializer<DatabaseModelContainer>(null);
            Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseModelContainer>());
        }

        public DbSet<Employee> EmployeeSet { get; set; }
    }
}