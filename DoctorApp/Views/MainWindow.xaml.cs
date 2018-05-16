using System.Windows;
using System.Windows.Controls;

namespace DoctorApp
{
    public partial class MainWindow : Window
    {
        private MainDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            dataContext = new MainDataContext();
            DataContext = dataContext;

            dataContext.Navigation = mainFrame;
            dataContext.ThemeManager = App.Current as App;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext.Loaded();
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
                    Navigate(new PatientsUserControl());
                    break;

                case "VisitsPage":
                    Navigate(new VisitsUserControl());
                    break;

                default:
                    break;
            }
        }
    }
}
