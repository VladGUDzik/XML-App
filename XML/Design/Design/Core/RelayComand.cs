using System;
using System.Windows.Input;

namespace Design.Core
{
    class RelayComand:ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
            
        }
        public RelayComand(Action<object>execute,Func<object,bool>canExecute=null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayComand()
        {
        }

        public bool CanExecute(object parametr)
        {
            return _canExecute == null || _canExecute(parametr);
        }

        public void Execute(object paramter) {
            _execute(paramter);
        }

    }
}
