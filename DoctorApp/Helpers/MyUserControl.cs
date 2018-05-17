using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DoctorApp
{
	public abstract class MyUserControl : UserControl
	{
		private bool loaded;

		public MyUserControl()
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
