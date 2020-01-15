using System.Windows;
using System.Windows.Controls;
using WpfDataBase.ViewMod;

namespace WpfDataBase.View.UserControls
{
    /// <summary>
    /// Interaction logic for Noun.xaml
    /// </summary>
    public partial class NounUserControl : UserControl
    {
        public NounUserControl()
        {
            InitializeComponent();
        }

        public NounViewModel ElementViewModel
        {
            get { return (NounViewModel)GetValue(ElementViewModelProperty); }
            set { SetValue(ElementViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdjectiveVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementViewModelProperty =
            DependencyProperty.Register("ElementViewModel", typeof(NounViewModel), typeof(NounUserControl), new PropertyMetadata(new NounViewModel()));


    }
}
