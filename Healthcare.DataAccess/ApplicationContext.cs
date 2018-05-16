using System.Data.Entity;

namespace Healthcare.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new ApplicationInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            //modelBuilder.Entity<Patient>().ToTable("PatientsTable");
            //modelBuilder.Entity<Patient>().HasKey(c => c.Id);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }

    public class ApplicationInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.Accounts.Add(new Account()
            {
                Username = "admin",
                Password = "admin"
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
