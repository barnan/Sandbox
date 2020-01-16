using System.Windows;
using System.Windows.Controls;
using WpfDataBase.ViewMod;

namespace WpfDataBase.View.UserControls
{
    /// <summary>
    /// Interaction logic for Verb.xaml
    /// </summary>
    public partial class VerbUserControl : UserControl
    {
        public VerbUserControl()
        {
            InitializeComponent();
        }


        public VerbViewModel ElementViewModel
        {
            get { return (VerbViewModel)GetValue(ElementViewModelProperty); }
            set { SetValue(ElementViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdjectiveVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementViewModelProperty =
            DependencyProperty.Register("ElementViewModel", typeof(VerbViewModel), typeof(VerbUserControl), new PropertyMetadata(new VerbViewModel()));

    }
}
