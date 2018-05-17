using System.ComponentModel;
using System.Threading.Tasks;

namespace DoctorApp
{
	public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

		public void OnPropertyChanged()
		{
			OnPropertyChanged(string.Empty);
		}

		public virtual async Task LoadedAsync()
		{
			await Task.Delay(1);
		}
	}
}
