using Healthcare.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoctorApp
{
    public class VisitsDataContext : DataContextBase
    {
        private Visit selectedVisit;

        public VisitsDataContext()
        {
            AddVisitCommand = new MyCommand(AddVisit);
            EditVisitCommand = new MyCommand(EditVisit, CanEditVisit);

            Visits = new ObservableCollection<Visit>(App.ApplicationState.UnitOfWork.Visits.Get());
        }

        public ICommand AddVisitCommand { get; set; }
        public ICommand EditVisitCommand { get; set; }

        public Visit SelectedVisit
        {
            get { return selectedVisit; }
            set
            {
                if (selectedVisit != value)
                {
                    selectedVisit = value;
                    OnPropertyChanged("SelectedVisit");
                }
            }
        }

        public ObservableCollection<Visit> Visits { get; set; }

        private void AddVisit()
        {
            var window = new VisitWindow();
            var dataContext = new VisitDataContext();
            window.DataContext = dataContext;
            if (window.ShowDialog() == true && dataContext.Visit != null)
            {
                Visits.Add(dataContext.Visit);
            }
        }

        private bool CanEditVisit()
        {
            return SelectedVisit != null;
        }

        private void EditVisit()
        {
            var window = new VisitWindow();
            var dataContext = new VisitDataContext(SelectedVisit);
            window.DataContext = dataContext;
            if (window.ShowDialog() == true)
            {
                SelectedVisit.OnPropertyChanged();
            }
        }
    }
}
