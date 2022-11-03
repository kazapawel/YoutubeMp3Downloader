using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    /// <summary>
    /// Base class for async class comands.
    /// </summary>
    public abstract class CommandBaseAsync : ICommand
    {
        private bool _canExec;
        private bool _isExecuting;

        public bool CanExec
        {
            get => _canExec;
            set
            {
                _canExec = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public bool CanExecute(object parameter)
        {
            ////return !IsExecuting;
            //if (_canExecute is null)
            //    return !_isExecuting;

            return !IsExecuting && CanExec;// && (_canExecute?.Invoke() ?? true);
        }

        /// <summary>
        /// 
        /// </summary>
        public async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract Task ExecuteAsync(object parameter);
    }
}
