using System.Windows;

namespace Investigate_AttachedProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void TextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ;
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).VmProperty2 = textBox1.Text;
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            textBox3.Text = textBoxEx1.SecurityId;

        }
    }
}
