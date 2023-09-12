using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace YoutubeToMp3
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        /// <summary>
        /// Timer for delaying textchanged event.
        /// </summary>
        DispatcherTimer _timer;

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.Register("TextChangedCommand", typeof(ICommand), typeof(MainControl), new PropertyMetadata(null));


        public MainControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invokes TextChangedCommand after delay.
        /// </summary>
        private void UrlTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(200)
                };
                _timer.Tick += InvokeTextChangedCommand;
            }

            // Resets the timer
            _timer.Stop();
            _timer.Start();
        }

        /// <summary>
        /// Invokes TextChanged command and stops the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvokeTextChangedCommand(object sender, EventArgs e)
        {
            var timer = sender as DispatcherTimer;
            if (timer == null)
                return;
            var textFromTextbox = this.urlTextBox.Text;
            TextChangedCommand?.Execute(textFromTextbox);
            timer.Stop();
        }

        /// <summary>
        /// Pastes text from clipboard to url textbox.
        /// </summary>
        private void PasteButtonClick(object sender, RoutedEventArgs e)
        {
            urlTextBox.Text = Clipboard.GetText();
        }
    }
}
