using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DoctorApp
{
    public class LoginDataContext : DataContextBase
    {
        private string password;
        private string login;
        private bool? dialogResult;

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
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                if (dialogResult != value)
                {
                    dialogResult = value;
                    OnPropertyChanged("DialogResult");
                }
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public LoginDataContext()
        {
            LoginCommand = new MyCommand(LoginCommandExecute, LoginCommandCanExecute);
            RegisterCommand = new MyCommand(RegisterCommandExecute);
        }

        private void RegisterCommandExecute()
        {
            var registerWindow = new RegisterWindow();
            var registerDataContext = new RegisterContext();
            registerWindow.DataContext = registerDataContext;
            if (registerWindow.ShowDialog() == true)
            {
                Login = registerDataContext.Login;
            }
        }

        private bool LoginCommandCanExecute()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        private void LoginCommandExecute()
        {
            if (App.ApplicationState.UnitOfWork.Accounts.Get(a => a.Username == Login && a.Password == Password).Any())
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
