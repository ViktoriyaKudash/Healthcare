using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorApp
{
	public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            OpenPatientsCommand = new MyCommand(() => Navigation.NavigateTo("PatientsPage"));
            OpenVisitsCommand = new MyCommand(() => Navigation.NavigateTo("VisitsPage"));

            WhiteThemeCommand = new MyCommand(() => ThemeManager.WhiteTheme());
            DarkThemeCommand = new MyCommand(() => ThemeManager.DarkTheme());
        }

        public IThemeManager ThemeManager { get; set; }
        public INavigation Navigation { get; set; }

        public ICommand OpenPatientsCommand { get; set; }
        public ICommand OpenVisitsCommand { get; set; }

        public ICommand WhiteThemeCommand { get; set; }
        public ICommand DarkThemeCommand { get; set; }

		public override async Task LoadedAsync()
		{
            Navigation.NavigateTo("PatientsPage");
        }
    }
}
