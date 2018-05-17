using System;
using System.Windows.Input;

namespace DoctorApp
{
    public class MyCommand : ICommand
    {
        public delegate void MyAction();
        public delegate bool MyActionWithBool();

        private MyAction execute;
        private MyActionWithBool canExecute;

        public MyCommand(MyAction execute, MyActionWithBool canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public MyCommand(MyAction execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute();
            }
            else return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
