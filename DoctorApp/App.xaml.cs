using Healthcare.DataAccess;
using System;
using System.Windows;

namespace DoctorApp
{
    public partial class App : Application, IThemeManager
    {
        static App()
        {
            ApplicationState = new ApplicationState();
        }

        public static ApplicationState ApplicationState { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            MainWindow = new MainWindow();

            UnitOfWork.CreateDatabaseIfNotExists();

            var loginWindow = new LoginWindow();
            var result = loginWindow.ShowDialog();

            if (result.HasValue && result.Value == true)
            {
                MainWindow.Show();
            }
            else
            {
                Shutdown();
            }
        }

        public void DarkTheme()
        {
            Resources.MergedDictionaries.RemoveAt(1);
            Resources.MergedDictionaries.Insert(1, new ResourceDictionary() { Source = new Uri("/Themes/DarkThemeDictionary.xaml", UriKind.RelativeOrAbsolute) });
        }

        public void WhiteTheme()
        {
            Resources.MergedDictionaries.RemoveAt(1);
            Resources.MergedDictionaries.Insert(1, new ResourceDictionary() { Source = new Uri("/Themes/WhiteThemeDictionary.xaml", UriKind.RelativeOrAbsolute) });
        }
    }

    public interface IThemeManager
    {
        void WhiteTheme();
        void DarkTheme();
    }
}
