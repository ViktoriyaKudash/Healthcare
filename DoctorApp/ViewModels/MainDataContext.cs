using System;
using System.Windows.Input;

namespace DoctorApp
{
    public class MainDataContext : DataContextBase
    {
        public MainDataContext()
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

        public void Loaded()
        {
            Navigation.NavigateTo("PatientsPage");
        }
    }
}
