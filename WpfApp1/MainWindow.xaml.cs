using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataContext = new viewmodel1();


            Label1.FontSize = 8;

            Label2.FontSize = 10;
            Label2.Margin = new Thickness(10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            s.Trim();
        }


    }
}
