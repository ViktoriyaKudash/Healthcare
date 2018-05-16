using Healthcare.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorApp
{
    public class PatientsDataContext : DataContextBase
    {
        private Patient selectedPatient;

        public PatientsDataContext()
        {
            AddPatientCommand = new MyCommand(AddPatient);
            EditPatientCommand = new MyCommand(EditPatient, CanEditPatient);

            Patients = new ObservableCollection<Patient>();
        }

        public ICommand AddPatientCommand { get; set; }

        public ICommand EditPatientCommand { get; set; }

        public Patient SelectedPatient
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

        public ObservableCollection<Patient> Patients { get; set; }

        public async Task Loaded()
        {
            var patients = await App.ApplicationState.UnitOfWork.Patients.GetAsync();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }

        private void AddPatient()
        {
            var window = new PatientWindow();
            var dataContext = new PatientDataContext();
            window.DataContext = dataContext;
            if (window.ShowDialog() == true && dataContext.Patient != null)
            {
                Patients.Add(dataContext.Patient);
            }
        }

        private bool CanEditPatient()
        {
            return SelectedPatient != null;
        }

        private void EditPatient()
        {
            var window = new PatientWindow();
            var dataContext = new PatientDataContext(SelectedPatient);
            window.DataContext = dataContext;
            if (window.ShowDialog() == true)
            {
                SelectedPatient.OnPropertyChanged();
            }
        }
    }
}
