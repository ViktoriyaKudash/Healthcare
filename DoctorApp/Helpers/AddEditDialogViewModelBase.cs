using System.Windows.Input;

namespace DoctorApp
{
	public abstract class AddEditDialogViewModelBase<TViewModel> : DialogViewModelBase
		where TViewModel : ViewModelBase
	{
		public AddEditDialogViewModelBase()
		{
			OkCommand = new MyCommand(OkExecute, CanOkExecute);
			OkButtonText = "Add";
			IsInEditMode = false;
		}

		public AddEditDialogViewModelBase(TViewModel model)
			: this()
		{
			OkButtonText = "Save";
			IsInEditMode = true;
			Model = model;
		}

		public bool IsInEditMode { get; protected set; }

		public TViewModel Model { get; protected set; }

		public ICommand OkCommand { get; private set; }

		protected virtual bool CanOkExecute()
		{
			return true;
		}

		protected virtual void OkExecute()
		{
			Ok();
		}
	}
}
