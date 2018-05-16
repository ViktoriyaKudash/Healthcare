using Healthcare.DataAccess;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DoctorApp
{
    public class PatientDataContext : DataContextBase
    {
        private static readonly Image defaultPhoto;

        private bool? dialogResult;
        private string firstName;
        private string lastName;
        private string okButtonText;
        private string birthday;
        private string homeadress;

        private Image photo;

        static PatientDataContext()
        {
            defaultPhoto = Image.FromFile("Resources\\No-Avatar-High-Definition.jpg");
        }

        public PatientDataContext()
        {
            AddCommand = new MyCommand(Add, CanAdd);
            SelectPhotoCommand = new MyCommand(SelectPhoto);

            OkButtonText = "Add";
            Photo = defaultPhoto;
        }

        public PatientDataContext(Patient patient)
            : this()
        {
            FirstName = patient.FirstName;
            LastName = patient.LastName;

            using (var stream = new MemoryStream(patient.PhotoBytes))
            {
                photo = Image.FromStream(stream);
            }

            Patient = patient;

            OkButtonText = "Save";
        }

        public ICommand AddCommand { get; set; }
        public ICommand SelectPhotoCommand { get; set; }

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

        public string Homeadress
        {
            get { return homeadress; }
            set
            {
                if (homeadress != value)
                {
                    homeadress = value;
                    OnPropertyChanged("Homeadress");
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

        public Image Photo
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

        public Patient Patient { get; set; }

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

        private bool CanAdd()
        {
            return string.IsNullOrEmpty(LastName) == false;
        }

        private void Add()
        {
            if (Patient == null)
            {
                Patient = new Patient()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Birthday = LastName,
                    Gender = LastName,
                    HomeAddress = LastName,
                    PhotoBytes = ImageToByteArray(Photo)
                };

                App.ApplicationState.UnitOfWork.Patients.Create(Patient);

                DialogResult = true;
            }
            else
            {
                var patient = App.ApplicationState.UnitOfWork.Patients.FindById(Patient.Id);

                patient.LastName = LastName;
                patient.FirstName = FirstName;

                App.ApplicationState.UnitOfWork.Patients.Update(patient);

                Patient.LastName = LastName;
                Patient.FirstName = FirstName;

                DialogResult = true;
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
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

            if (dlg.ShowDialog() == true)
            {
                Photo = Image.FromFile(dlg.FileName);
            }
        }
    }

    public class ImageToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Image)
            {
                var image = value as Image;
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    ms.Seek(0, SeekOrigin.Begin);

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
