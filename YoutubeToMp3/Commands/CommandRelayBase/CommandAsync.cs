using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    /// <summary>
    /// Base class for relay async commands.
    /// </summary>
    public class CommandAsync : ICommandAsync
    {
        #region PRIVATE FIELDS

        public event EventHandler? CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        //private readonly IErrorHandler _errorHandler;

        #endregion

        #region CONSTRUCTOR

        public CommandAsync(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object? parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object? parameter)
        {
            ExecuteAsync();//.FireAndForgetSafeAsync(_errorHandler);
        }
    }
}
