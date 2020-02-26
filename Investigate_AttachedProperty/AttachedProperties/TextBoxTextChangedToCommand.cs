using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Investigate_AttachedProperty.AttachedProperties
{
    public class TextBoxTextChangedToCommand
    {

        public static readonly DependencyProperty NorbiTextProperty =
            DependencyProperty.RegisterAttached(
                "NorbiText",
                typeof(string),
                typeof(TextBoxTextChangedToCommand),
                new FrameworkPropertyMetadata("empty", OnTextChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                }
            );

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs eventArgs)
        {
            ;
        }

        public static string GetNorbiText(UIElement element)
        {
            return (string)element.GetValue(NorbiTextProperty);
        }

        public static void SetNorbiText(UIElement element, string value)
        {
            element.SetValue(NorbiTextProperty, value);
        }


        //public static string GetAText(UIElement element)
        //{
        //    var textBox = element as TextBox;
        //    return textBox.Text.Split(',')[1];
        //}

        //public static void SetAText(UIElement element, string value)
        //{
        //    var textBox = element as TextBox;
        //    textBox.Text = $"kkkk {value} kkkk";
        //}
    }
}
