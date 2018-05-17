using Healthcare.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DoctorApp
{
	public class VisitAddEditViewModel : AddEditDialogViewModelBase<VisitViewModel>
	{
		private string text;
		private string date;
		private PatientViewModel patient;

		public VisitAddEditViewModel()
			: base()
		{
			Date = DateTime.Now.ToString();
			Patients = new ObservableCollection<PatientViewModel>(App.ApplicationState.UnitOfWork.Patients.Get().Select(p => new PatientViewModel(p)));
		}

		public VisitAddEditViewModel(VisitViewModel visit)
			: base(visit)
		{
			Text = visit.Text;
			Date = visit.Date.ToString();
			Patient = visit.Patient;

			Patients = new ObservableCollection<PatientViewModel>();
		}

		public string Date
		{
			get { return date; }
			set
			{
				if(date != value)
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
				if(text != value)
				{
					text = value;
					OnPropertyChanged("Text");
				}
			}
		}

		public ObservableCollection<PatientViewModel> Patients { get; set; }

		public PatientViewModel Patient
		{
			get { return patient; }
			set
			{
				if(patient != value)
				{
					patient = value;
					OnPropertyChanged("Patient");
				}
			}
		}

		protected override bool CanOkExecute()
		{
			return string.IsNullOrEmpty(Text) == false && DateTime.TryParse(Date, out DateTime date) && Patient != null;
		}

		protected override void OkExecute()
		{
			if(Model == null)
			{
				var visit = new Visit()
				{
					Date = DateTime.Parse(Date),
					PatientId = Patient.Id,
					Text = Text
				};

				App.ApplicationState.UnitOfWork.Visits.Create(visit);

				Model = new VisitViewModel(visit);

				Ok();
			}
			else
			{
				var visit = App.ApplicationState.UnitOfWork.Visits.FindById(Model.Id);

				visit.Date = DateTime.Parse(Date);
				visit.Text = Text;

				App.ApplicationState.UnitOfWork.Visits.Update(visit);

				Model.Date = Date;
				Model.Text = Text;

				Ok();
			}
		}
	}
}
