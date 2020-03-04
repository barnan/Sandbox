using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Investigate_AttachedProperty.AttachedProperties
{
    public class AttachedText : DependencyObject
    {

        public static readonly DependencyProperty SecurityIdProperty =
            DependencyProperty.RegisterAttached(
                "SecurityId",
                typeof(string),
                typeof(AttachedText),
                new FrameworkPropertyMetadata(null, OnTextChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                }
            );

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs eventArgs)
        {
            ;
            if (d is TextBox)
            {
                (d as TextBox).Text = GetSecurityId(d as UIElement);
            }

            if (d is Button)
            {
                (d as Button).Content = GetSecurityId(d as UIElement);
            }
        }

        public static string GetSecurityId(UIElement element)
        {
            return (string)element.GetValue(SecurityIdProperty);
        }

        public static void SetSecurityId(UIElement element, string value)
        {
            element.SetValue(SecurityIdProperty, value);
        }
    }
}
