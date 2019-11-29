using System.Windows;
using System.Windows.Documents;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            ;
        }

        
        private void App_OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }


        private void Application_OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow _mainWindow = new MainWindow();

            _mainWindow.Title = "Something";

            _mainWindow.Show();
        }
    }
}
