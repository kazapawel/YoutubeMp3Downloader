using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        // Using a DependencyProperty as the backing store for TextChangedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.Register("TextChangedCommand", typeof(ICommand), typeof(MainControl), new PropertyMetadata(null));


        public MainControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = e.Changes.ToList();
            var text = this.urlTextBox.Text;
            
            FocusManager.SetFocusedElement(this.Parent, null);
            TextChangedCommand?.Execute(text);
        }


    }
}
