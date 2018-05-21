using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorApp
{
    public class MainViewModel : ViewModelBase
    {
        private string searchText;

        public MainViewModel()
        {
            OpenPatientsCommand = new MyCommand(() => Navigation.NavigateTo("PatientsPage"));
            OpenVisitsCommand = new MyCommand(() => Navigation.NavigateTo("VisitsPage"));

            WhiteThemeCommand = new MyCommand(() => ThemeManager.WhiteTheme());
            DarkThemeCommand = new MyCommand(() => ThemeManager.DarkTheme());

            SearchCommand = new MyCommand(() => SearchExecute());
            CancelSearchCommand = new MyCommand(() => CancelSearchExecute());
        }

        public IThemeManager ThemeManager { get; set; }
        public INavigation Navigation { get; set; }

        public ICommand OpenPatientsCommand { get; set; }
        public ICommand OpenVisitsCommand { get; set; }

        public ICommand WhiteThemeCommand { get; set; }
        public ICommand DarkThemeCommand { get; set; }

        
        public ICommand SearchCommand { get; set; }
        public ICommand CancelSearchCommand { get; set; }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");

                    //SearchExecute();
                }
            }
        }

        private void SearchExecute()
        {
            if (string.IsNullOrEmpty(SearchText) == false)
            {
                var searchable = Navigation.CurrentView as ISearchable;
                if (searchable != null)
                {
                    searchable.Search(SearchText);
                }
            }
        }

        private void CancelSearchExecute()
        {
            var searchable = Navigation.CurrentView as ISearchable;
            if (searchable != null)
            {
                searchable.CancelSearch();
            }
        }

        public override async Task LoadedAsync()
        {
            Navigation.NavigateTo("PatientsPage");
        }
    }

    public interface ISearchable
    {
        void Search(string value);
        void CancelSearch();
    }
}
