using Healthcare.DataAccess;
using System;

namespace DoctorApp
{
    public class VisitViewModel : ViewModelBase
    {
		private readonly Visit visit;

		private int id;
		private string text;
        private DateTime date;
		private PatientViewModel patient;
        public VisitViewModel(Visit visit)
        {
			this.visit = visit;

			Id = visit.Id;
			Date = visit.Date;
            Text = visit.Text;

            Patient = new PatientViewModel(App.ApplicationState.UnitOfWork.Patients.FindById(visit.PatientId));
		}

		public int Id
		{
			get { return id; }
			set
			{
				if(id != value)
				{
					id = value;
					OnPropertyChanged("Id");
				}
			}
		}

		public DateTime Date
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
       
        public PatientViewModel Patient
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
    }
}
