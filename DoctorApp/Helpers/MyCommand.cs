using System;
using System.Windows.Input;

namespace DoctorApp
{
    public class MyCommand : ICommand
    {
        public delegate void MyAction();
        public delegate bool MyActionWithBool();

        private MyAction execute;
        private Action<object> executeWithArgs;
        private MyActionWithBool canExecute;

        public MyCommand(MyAction execute, MyActionWithBool canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public MyCommand(Action<object> executeWithArgs, MyActionWithBool canExecute)
        {
            this.executeWithArgs = executeWithArgs;
            this.canExecute = canExecute;
        }

        public MyCommand(MyAction execute)
        {
            this.execute = execute;
        }

        public MyCommand(Action<object> executeWithArgs)
        {
            this.executeWithArgs = executeWithArgs;
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
            if (executeWithArgs == null)
            {
                execute();
            }
            else
            {
                executeWithArgs(parameter);
            }
        }
    }
}
