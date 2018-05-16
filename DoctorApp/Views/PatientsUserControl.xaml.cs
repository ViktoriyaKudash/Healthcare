using System.Windows.Controls;

namespace DoctorApp
{
    public partial class PatientsUserControl : UserControl
    {
        private PatientsDataContext dataContext;

        public PatientsUserControl()
        {
            InitializeComponent();

            dataContext = new PatientsDataContext();

            DataContext = dataContext;

            Loaded += PatientsUserControl_Loaded;
        }

        private async void PatientsUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await dataContext.Loaded();
        }
    }
}
