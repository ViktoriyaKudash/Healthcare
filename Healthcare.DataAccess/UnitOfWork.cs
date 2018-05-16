using System;
using System.Configuration;

namespace Healthcare.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private static string connectionString;

        private ApplicationContext context;

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
            context = new ApplicationContext(connectionString);

            Visits = new GenericRepository<Visit>(context);
            Accounts = new GenericRepository<Account>(context);
            Patients = new GenericRepository<Patient>(context);
        }

        public GenericRepository<Visit> Visits { get; private set; }
        public GenericRepository<Account> Accounts { get; private set; }
        public GenericRepository<Patient> Patients { get; private set; }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~UnitOfWork() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
