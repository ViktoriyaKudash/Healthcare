using System.Drawing;
using System.IO;
using Healthcare.DataAccess;

namespace DoctorApp
{
	public class PatientViewModel : ViewModelBase
    {
		private Patient patient;

		private int id;
		private string firstName;
        private string lastName;
        private string birthday;
        private string homeadress;
		private string gender;

		private Bitmap photo;
		
		static PatientViewModel()
        {
			DefaulPhoto = (Bitmap)Image.FromFile("Resources\\No-Avatar-High-Definition.jpg");
        }

		public PatientViewModel(Patient patient)
		{
			this.patient = patient;

			Id = patient.Id;
			FirstName = patient.FirstName;
			LastName = patient.LastName;
			Birthday = patient.Birthday;
			Gender = patient.Gender;
			HomeAddress = patient.HomeAddress;

			if(patient.PhotoBytes == null || patient.PhotoBytes.Length <= 0)
			{
				Photo = DefaulPhoto;
			}
			else
			{
				using(var stream = new MemoryStream(patient.PhotoBytes))
				{
					photo = (Bitmap)Image.FromStream(stream);
				}
			}
		}

		public static Bitmap DefaulPhoto { get; private set; }

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
                if (firstName != value)
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
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string Birthday
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public string Gender
		{
            get { return gender; }
            set
            {
                if (gender != value)
                {
					gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

		public string HomeAddress
		{
			get { return homeadress; }
			set
			{
				if(homeadress != value)
				{
					homeadress = value;
					OnPropertyChanged("HomeAddress");
				}
			}
		}

		public Bitmap Photo
        {
            get { return photo; }
            set
            {
                if (photo != value)
                {
                    photo = value;
                    OnPropertyChanged("Photo");
                }
            }
        }

		public override string ToString()
		{
			return string.Format("{0} {1}", FirstName, LastName);
		}
	}
}
