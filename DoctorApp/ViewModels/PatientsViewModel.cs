using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorApp
{
	public class PatientsViewModel : ViewModelBase
    {
        private PatientViewModel selectedPatient;

        public PatientsViewModel()
        {
            AddPatientCommand = new MyCommand(AddPatient);
            EditPatientCommand = new MyCommand(EditPatient, CanEditPatient);

            Patients = new ObservableCollection<PatientViewModel>();
        }

        public ICommand AddPatientCommand { get; set; }
        public ICommand EditPatientCommand { get; set; }

		public ObservableCollection<PatientViewModel> Patients { get; set; }

		public PatientViewModel SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (selectedPatient != value)
                {
                    selectedPatient = value;
                    OnPropertyChanged("SelectedPatient");
                }
            }
        }

		public override async Task LoadedAsync()
		{
			Patients.Clear();

			var patients = await App.ApplicationState.UnitOfWork.Patients.GetAsync();
            foreach (var patient in patients)
            {
                Patients.Add(new PatientViewModel(patient));
            }
        }

        private void AddPatient()
        {
            var window = new PatientAddEditView();
            var dataContext = new PatientAddEditViewModel();
            window.DataContext = dataContext;
            if (window.ShowDialog() == true && dataContext.Model != null)
            {
                Patients.Add(dataContext.Model);
            }
        }

        private bool CanEditPatient()
        {
            return SelectedPatient != null;
        }

        private void EditPatient()
        {
            var window = new PatientAddEditView();
            var dataContext = new PatientAddEditViewModel(SelectedPatient);
            window.DataContext = dataContext;
            if (window.ShowDialog() == true)
            {
                SelectedPatient.OnPropertyChanged();
            }
        }
    }
}
