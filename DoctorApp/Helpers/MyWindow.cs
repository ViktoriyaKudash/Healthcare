using System.ComponentModel;
using System.Windows;

namespace DoctorApp
{
	public abstract class MyWindow : Window
	{
		private bool loaded;

		public MyWindow()
		{
			Loaded += OnLoaded;
		}

		private async void OnLoaded(object sender, RoutedEventArgs e)
		{
			if(DesignerProperties.GetIsInDesignMode(this) == false && loaded == false && DataContext is ViewModelBase)
			{
				await (DataContext as ViewModelBase).LoadedAsync();

				loaded = true;
			}
		}
	}
}
