using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WheaterApp.Core
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute = null;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute(parameter);
    }
}
