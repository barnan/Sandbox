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
    }
}
