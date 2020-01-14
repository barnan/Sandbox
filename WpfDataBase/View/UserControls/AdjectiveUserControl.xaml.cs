using System.Windows;
using System.Windows.Controls;
using WpfDataBase.ViewMod;

namespace WpfDataBase.View.UserControls
{
    /// <summary>
    /// Interaction logic for AdjectiveUserControl.xaml
    /// </summary>
    public partial class AdjectiveUserControl : UserControl
    {
        public AdjectiveUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }


        public AdjectiveViewModel AdjectiveVM
        {
            get { return (AdjectiveViewModel)GetValue(AdjectiveVMProperty); }
            set { SetValue(AdjectiveVMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdjectiveVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdjectiveVMProperty =
            DependencyProperty.Register("AdjectiveVM", typeof(AdjectiveViewModel), typeof(AdjectiveUserControl), new PropertyMetadata(0));




    }
}
