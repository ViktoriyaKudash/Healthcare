using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Healthcare.DataAccess
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

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
    }
}
