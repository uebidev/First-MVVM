using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RJAplicationWPF.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Propriedades
        private readonly Action<object>? _executeAction;
        private readonly Predicate<object>? _canExecuteAction;

        //Cosntrutores
        #region Construtores
        public ViewModelCommand(Action<object>? executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object>? executeAction, Predicate<object>? canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        #endregion

        //Event
        #region Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        //Metódos
        #region Métodos
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
        #endregion
    }
}
