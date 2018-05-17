namespace DoctorApp
{
	public abstract class DialogViewModelBase : ViewModelBase
	{
		private bool? dialogResult;
		private string okButtonText;
		private string cancelButtonText;

		public bool? DialogResult
		{
			get { return dialogResult; }
			set
			{
				if(dialogResult != value)
				{
					dialogResult = value;
					OnPropertyChanged("DialogResult");
				}
			}
		}

		public string OkButtonText
		{
			get { return okButtonText; }
			set
			{
				if(okButtonText != value)
				{
					okButtonText = value;
					OnPropertyChanged("OkButtonText");
				}
			}
		}

		public string CancelButtonText
		{
			get { return cancelButtonText; }
			set
			{
				if(cancelButtonText != value)
				{
					cancelButtonText = value;
					OnPropertyChanged("CancelButtonText");
				}
			}
		}

		public void Ok()
		{
			DialogResult = true;
		}

		public void Cancel()
		{
			DialogResult = false;
		}
	}
}
