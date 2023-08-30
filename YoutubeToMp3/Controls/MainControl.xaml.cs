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
        private void UrlTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textFromTextbox = this.urlTextBox.Text;
            TextChangedCommand?.Execute(textFromTextbox);
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
