using ACME.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ACME.DAL
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext()
            : this("AcmeEntities")
        {
        }

        public GeneralDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Person>().Property(x => x.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Employee>().Property(x => x.EmployeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}
