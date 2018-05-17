using System;
using System.Configuration;

namespace Healthcare.DataAccess
{
    public class UnitOfWork
    {
        private static string connectionString;

        static UnitOfWork()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                connectionString = appSettings["DbConnetionString"];
            }
            catch (ConfigurationErrorsException)
            { }
        }

        public static void CreateDatabaseIfNotExists()
        {
            using (var context = new ApplicationContext(connectionString))
            {
                context.Database.CreateIfNotExists();
            }
        }

        public UnitOfWork()
        {
            Visits = new GenericRepository<Visit>(CreateContext);
            Accounts = new GenericRepository<Account>(CreateContext);
            Patients = new GenericRepository<Patient>(CreateContext);
        }

		private ApplicationContext CreateContext()
		{
			return new ApplicationContext(connectionString);
		}

        public GenericRepository<Visit> Visits { get; private set; }
        public GenericRepository<Account> Accounts { get; private set; }
        public GenericRepository<Patient> Patients { get; private set; }
    }
}
