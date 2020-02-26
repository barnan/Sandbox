using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Investigate_AttachedProperty.UserControl1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public object MyProperty
        {
            get { return (object)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(object), typeof(UserControl1), new FrameworkPropertyMetadata("UnInitializedValue", OnTextChanged)
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (int.TryParse(e.NewValue.ToString(), out int szam))
            {
                var uc = d as UserControl1;
                if (szam % 3 == 0)
                {
                    uc.myContentControl.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    uc.myContentControl.Foreground = new SolidColorBrush(Colors.Blue);
                }
            }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click_Event(object sender, RoutedEventArgs e)
        {
            if (myContentControl.Visibility != Visibility.Visible)
            {
                myContentControl.Visibility = Visibility.Visible;
                myButton.Content = "After";
            }
            else
            {
                myContentControl.Visibility = Visibility.Hidden;
                myButton.Content = "Before";
            }
        }
    }
}
