using Healthcare.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DoctorApp
{
    public class VisitDataContext : DataContextBase
    {
        private bool? dialogResult;

        private string text;
        private string date;
        private string okButtonText;
        private Patient patient;
        private bool editMode;

        public VisitDataContext()
        {
            AddCommand = new MyCommand(Add, CanAdd);

            Date = DateTime.Now.ToString();
            Patients = new ObservableCollection<Patient>(App.ApplicationState.UnitOfWork.Patients.Get());
            EditMode = false;
            OkButtonText = "Add";
        }

        public VisitDataContext(Visit visit)
            : this()
        {
            Text = visit.Text;
            Date = visit.Date.ToString();

            Patient = Patients.FirstOrDefault(p => p.Id == visit.PatientId);
            Visit = visit;

            EditMode = true;

            OkButtonText = "Save";
        }

        public ICommand AddCommand { get; set; }

        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string OkButtonText
        {
            get { return okButtonText; }
            set
            {
                if (okButtonText != value)
                {
                    okButtonText = value;
                    OnPropertyChanged("OkButtonText");
                }
            }
        }

        public Visit Visit { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }
        public Patient Patient
        {
            get { return patient; }
            set
            {
                if (patient != value)
                {
                    patient = value;
                    OnPropertyChanged("Patient");
                }
            }
        }

        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                if (dialogResult != value)
                {
                    dialogResult = value;
                    OnPropertyChanged("DialogResult");
                }
            }
        }

        public bool EditMode
        {
            get { return editMode; }
            set
            {
                if (editMode != value)
                {
                    editMode = value;
                    OnPropertyChanged("EditMode");
                }
            }
        }

        private bool CanAdd()
        {
            return string.IsNullOrEmpty(Text) == false && DateTime.TryParse(Date, out DateTime date) && Patient != null;
        }

        private void Add()
        {
            if (Visit == null)
            {
                Visit = new Visit()
                {
                    Date = DateTime.Parse(Date),
                    PatientId = Patient.Id,
                    Text = Text
                };

                App.ApplicationState.UnitOfWork.Visits.Create(Visit);

                DialogResult = true;
            }
            else
            {
                var visit = App.ApplicationState.UnitOfWork.Visits.FindById(Visit.Id);

                visit.Date = DateTime.Parse(Date);
                visit.Text = Text;

                App.ApplicationState.UnitOfWork.Visits.Update(visit);

                Visit.Date = DateTime.Parse(Date);
                Visit.Text = Text;

                DialogResult = true;
            }
        }
    }
}
