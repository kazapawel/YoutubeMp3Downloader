﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    /// <summary>
    /// Base class for async class comands.
    /// </summary>
    public abstract class CommandBaseAsync : ICommand
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //System.Windows.Input.CommandManager.InvalidateRequerySuggested();
            //var condition = CanExecuteAsync(parameter);
            var x = Can(parameter);
            var IsNotExecuting = !IsExecuting;
            return IsNotExecuting;// && Can(parameter);// && (_canExecute?.Invoke() ?? true);
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
            
            //System.Windows.Input.CommandManager.InvalidateRequerySuggested();
        }
        protected abstract Task ExecuteAsync(object parameter);
        protected virtual bool Can(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
