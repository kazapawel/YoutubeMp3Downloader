using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using YoutubeToMp3.UserSettings;

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
        DispatcherTimer? _timer;

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.Register("TextChangedCommand", typeof(ICommand), typeof(MainControl), new PropertyMetadata(null));

        public ICommand LoadedCommand
        {
            get { return (ICommand)GetValue(LoadedCommandProperty); }
            set { SetValue(LoadedCommandProperty, value); }
        }

        public static readonly DependencyProperty LoadedCommandProperty =
            DependencyProperty.Register("LoadedCommand", typeof(ICommand), typeof(MainControl), new PropertyMetadata(null));

        public ICommand ClosingCommand
        {
            get { return (ICommand)GetValue(ClosingCommandProperty); }
            set { SetValue(ClosingCommandProperty, value); }
        }

        public static readonly DependencyProperty ClosingCommandProperty =
            DependencyProperty.Register("ClosingCommand", typeof(ICommand), typeof(MainControl), new PropertyMetadata(null));

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

        /// <summary>
        /// Opens file dialog for selectin ffmpeg.exe.
        /// </summary>
        private void BrowseFfpmegButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                // disables selection of multiple files
                Multiselect = false,

                // sets filter for files that can be chosen
                Filter = "application |*.exe"
            };

            // if user selects files and presses OK
            if (dialog.ShowDialog() == true)
            {
                // invokes command
                var path = (dialog.FileName);
                //SetFfmpegPathCommand.Execute(path);

                // sets textbox value
                ffmpegPathTextbox.Text = path;
            }
        }

        /// <summary>
        /// Opens 
        /// </summary>
        private void BrowseDownloadDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();

            if(dialog.ShowDialog()==true)
            {
                var path = dialog.SelectedPath;
                downloadDirectoryTextbox.Text = path;
            }
        }

        /// <summary>
        /// Executes loaded command.
        /// </summary>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadedCommand?.Execute(sender);
        }

        /// <summary>
        /// Executes closed command.
        /// </summary>
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            ClosingCommand?.Execute(sender);
        }
    }
}
