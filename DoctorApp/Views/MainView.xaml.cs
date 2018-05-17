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
        void NavigateTo(string page);
    }

    public class MyFrame : Frame, INavigation
    {
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
