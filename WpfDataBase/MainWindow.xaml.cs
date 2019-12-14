using System.Windows;

namespace WpfDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static string _connectionString;
        //private static SqlConnection _connection;
        private ViewModel _viewModel;


        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            this.DataContext = _viewModel;

            //_connectionString = ConfigurationManager.ConnectionStrings["WpfDataBase.Properties.Settings.Test01_ConnectionString"].ConnectionString;
            //PopulatePersons();
        }


        //private void PopulatePersons()
        //{
        //    string sqlQuery = "SELECT p.Firstname, p.Lastname, p.Age, Workplace.WorkplaceName " +
        //                        "FROM Person AS p " +
        //                        "INNER JOIN Workplace ON Workplace.Id = p.Workplace";

        //    using (_connection = new SqlConnection(_connectionString))
        //    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _connection))
        //    {
        //        {
        //            DataTable personTable = new DataTable();
        //            DataSet personDataSet = new DataSet();

        //            adapter.Fill(personTable);
        //            adapter.Fill(personDataSet, "Person");

        //            datagrid.DataContext = personTable.DefaultView;
        //            listbox.ItemsSource = personTable.AsDataView();
        //        }


        //    }

        //}

    }
}
