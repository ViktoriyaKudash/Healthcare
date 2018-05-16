using Healthcare.DataAccess;

namespace DoctorApp
{
    public class ApplicationState
    {
        public ApplicationState()
        {
            UnitOfWork = new UnitOfWork();
        }

        public UnitOfWork UnitOfWork { get; private set; }
    }
}
