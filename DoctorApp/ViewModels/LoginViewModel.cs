using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace DoctorApp
{
	public class LoginViewModel : DialogViewModelBase
	{
        private string login;

        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new MyCommand(LoginCommandExecute, LoginCommandCanExecute);
            RegisterCommand = new MyCommand(RegisterCommandExecute);
        }

        private void RegisterCommandExecute()
        {
            var registerWindow = new RegisterView();
            var registerDataContext = new RegisterViewModel();
            registerWindow.DataContext = registerDataContext;
            if (registerWindow.ShowDialog() == true)
            {
                Login = registerDataContext.Login;
            }
        }

        private bool LoginCommandCanExecute()
        {
            return !string.IsNullOrEmpty(Login);
        }

        private void LoginCommandExecute(object securePassword)
        {
            var passwordBox = securePassword as System.Windows.Controls.PasswordBox;
            var password = passwordBox.Password;
            if (App.ApplicationState.UnitOfWork.Accounts.Get(a => a.Username == Login && a.Password == password).Any())
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Ошибка, пользователь с таким паролем не найден", "Ошибка");
            }
        }
    }
}
