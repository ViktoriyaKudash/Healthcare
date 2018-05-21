using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorApp
{
	public class VisitsViewModel : ViewModelBase, ISearchable
    {
        private VisitViewModel selectedVisit;

        private List<VisitViewModel> refferenceList;

        public VisitsViewModel()
        {
            AddVisitCommand = new MyCommand(AddVisit);
            EditVisitCommand = new MyCommand(EditVisit, CanEditVisit);

			Visits = new ObservableCollection<VisitViewModel>();
        }

        public ICommand AddVisitCommand { get; set; }
        public ICommand EditVisitCommand { get; set; }

        public VisitViewModel SelectedVisit
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

        public ObservableCollection<VisitViewModel> Visits { get; set; }

		public override async Task LoadedAsync()
		{
			Visits.Clear();
			var visits = await App.ApplicationState.UnitOfWork.Visits.GetAsync();
			foreach(var visit in visits)
			{
				Visits.Add(new VisitViewModel(visit));
			}

            refferenceList = new List<VisitViewModel>();
            refferenceList.AddRange(Visits);
        }

        private void AddVisit()
        {
            var window = new VisitAddEdtiView();
            var dataContext = new VisitAddEditViewModel();
            window.DataContext = dataContext;
            if (window.ShowDialog() == true && dataContext.Model != null)
            {
                Visits.Add(dataContext.Model);
            }
        }

        private bool CanEditVisit()
        {
            return SelectedVisit != null;
        }


        private void EditVisit()
        {
            var window = new VisitAddEdtiView();
            var dataContext = new VisitAddEditViewModel(SelectedVisit);
            window.DataContext = dataContext;
            if (window.ShowDialog() == true)
            {
                SelectedVisit.OnPropertyChanged();
            }
        }

        public void Search(string value)
        {
            Visits.Clear();
            foreach (var item in refferenceList.Where(v => v.Patient.LastName.ToLower().Contains(value.ToLower()) ||
                v.Patient.FirstName.ToLower().Contains(value.ToLower()) ||
                v.Patient.HomeAddress.ToLower().Contains(value.ToLower()) ||
                v.Text.ToLower().Contains(value.ToLower())))
            {
                Visits.Add(item);
            }
        }

        public void CancelSearch()
        {
            Visits.Clear();
            foreach (var item in refferenceList)
            {
                Visits.Add(item);
            }
        }
    }
}
