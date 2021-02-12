using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp23.MVVM
{
    public class MvvmCommand : ICommand
    {
        Action action;
        Func<bool> canExecute;

        public MvvmCommand(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
