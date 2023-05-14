using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YoutubeToMp3
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
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
        /// Invokes TextChangedCommand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UrlTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            // Textbox value as variable
            var text = this.urlTextBox.Text;

            // Sends textbox value as command parameter
            TextChangedCommand?.Execute(text);
        }

        /// <summary>
        /// Pastes text from clipboard to url textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteButtonClick(object sender, RoutedEventArgs e)
        {
            urlTextBox.Text = Clipboard.GetText();
        }
    }
}
