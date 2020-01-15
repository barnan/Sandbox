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
        }


        public AdjectiveViewModel ElementViewModel
        {
            get { return (AdjectiveViewModel)GetValue(ElementViewModelProperty); }
            set { SetValue(ElementViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdjectiveVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementViewModelProperty =
            DependencyProperty.Register("ElementViewModel", typeof(AdjectiveViewModel), typeof(AdjectiveUserControl), new PropertyMetadata(new AdjectiveViewModel()));





    }
}
