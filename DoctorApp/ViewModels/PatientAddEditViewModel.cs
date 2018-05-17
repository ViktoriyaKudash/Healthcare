using Healthcare.DataAccess;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows.Input;

namespace DoctorApp
{
	public class PatientAddEditViewModel : AddEditDialogViewModelBase<PatientViewModel>
	{
		private int id;
		private string firstName;
		private string lastName;
		private string birthday;
		private string homeadress;
		private string gender;
		private string homeAddress;

		private Bitmap photo;	

		public PatientAddEditViewModel()
			: base()
		{
			Photo = PatientViewModel.DefaulPhoto;
		}

		public PatientAddEditViewModel(PatientViewModel patient)
			: base(patient)
		{
			Id = patient.Id;
			FirstName = patient.FirstName;
			LastName = patient.LastName;
			Gender = patient.Gender;
			HomeAddress = patient.HomeAddress;
			Birthday = patient.Birthday;
			Photo = patient.Photo;
		}
		
		public ICommand SelectPhotoCommand => new MyCommand(SelectPhoto);

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

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if(firstName != value)
				{
					firstName = value;
					OnPropertyChanged("FirstName");
				}
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if(lastName != value)
				{
					lastName = value;
					OnPropertyChanged("LastName");
				}
			}
		}

		public string Gender
		{
			get { return gender; }
			set
			{
				if(gender != value)
				{
					gender = value;
					OnPropertyChanged("Gender");
				}
			}
		}

		public string HomeAddress
		{
			get { return homeAddress; }
			set
			{
				if(homeAddress != value)
				{
					homeAddress = value;
					OnPropertyChanged("HomeAddress");
				}
			}
		}

		public string Birthday
		{
			get { return birthday; }
			set
			{
				if(birthday != value)
				{
					birthday = value;
					OnPropertyChanged("Birthday");
				}
			}
		}

		public string Homeadress
		{
			get { return homeadress; }
			set
			{
				if(homeadress != value)
				{
					homeadress = value;
					OnPropertyChanged("Homeadress");
				}
			}
		}

		public Bitmap Photo
		{
			get { return photo; }
			set
			{
				if(photo != value)
				{
					photo = value;
					OnPropertyChanged("Photo");
				}
			}
		}

		protected override bool CanOkExecute()
		{
			return string.IsNullOrEmpty(LastName) == false;
		}

		protected override void OkExecute()
		{
			if(Model == null)
			{
				var patient = new Patient()
				{
					FirstName = FirstName,
					LastName = LastName,
					Birthday = Birthday,
					Gender = Gender,
					HomeAddress = HomeAddress,
					PhotoBytes = ImageToByteArray(Photo)
				};

				App.ApplicationState.UnitOfWork.Patients.Create(patient);

				Model = new PatientViewModel(patient);

				Ok();
			}
			else
			{
				var patient = App.ApplicationState.UnitOfWork.Patients.FindById(Model.Id);

				patient.LastName = LastName;
				patient.FirstName = FirstName;
				patient.Birthday = Birthday;
				patient.Gender = Gender;
				patient.HomeAddress = HomeAddress;
				patient.PhotoBytes = ImageToByteArray(Photo);

				App.ApplicationState.UnitOfWork.Patients.Update(patient);

				Model.LastName = LastName;
				Model.FirstName = FirstName;
				Model.Birthday = Birthday;
				Model.Gender = Gender;
				Model.HomeAddress = HomeAddress;
				Model.Photo = Photo;

				Ok();
			}
		}

		public byte[] ImageToByteArray(Image imageIn)
		{
			using(var ms = new MemoryStream())
			{
				imageIn.Save(ms, imageIn.RawFormat);
				return ms.ToArray();
			}
		}

		private void SelectPhoto()
		{
			OpenFileDialog dlg = new OpenFileDialog
			{
				DefaultExt = ".jpg", // Default file extension
				Filter = "Images (.jpg)|*.jpg" // Filter files by extension
			};

			if(dlg.ShowDialog() == true)
			{
				Photo = (Bitmap)Image.FromFile(dlg.FileName);
			}
		}
	}
}
