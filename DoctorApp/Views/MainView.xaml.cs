using System.Windows.Controls;

namespace DoctorApp
{
	public partial class MainView : MyWindow
    {
        public MainView()
        {
            InitializeComponent();

            var dataContext = new MainViewModel();
            DataContext = dataContext;

            dataContext.Navigation = mainFrame;
            dataContext.ThemeManager = App.Current as App;
        }
    }

    public interface INavigation
    {
        ViewModelBase CurrentView { get; }

        void NavigateTo(string page);
    }

    public class MyFrame : Frame, INavigation
    {
        public ViewModelBase CurrentView
        {
            get
            {
                var element = Content as System.Windows.FrameworkElement;
                if (element != null && element.DataContext != null && element.DataContext is ViewModelBase)
                {
                    return element.DataContext as ViewModelBase;
                }
                return null;
            }
        }

        public void NavigateTo(string page)
        {
            switch (page)
            {
                case "PatientsPage":
                    Navigate(new PatientsView());
                    break;

                case "VisitsPage":
                    Navigate(new VisitsView());
                    break;

                default:
                    break;
            }
        }
    }
}
