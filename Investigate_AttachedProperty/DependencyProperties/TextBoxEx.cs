using System.Windows;
using System.Windows.Controls;

namespace Investigate_AttachedProperty.DependencyProperties
{
    public class TextBoxEx : TextBox
    {
        public string SecurityId
        {
            get { return (string)GetValue(SecurityIdProperty); }
            set { SetValue(SecurityIdProperty, value); }
        }

        public static readonly DependencyProperty SecurityIdProperty = DependencyProperty.Register("SecurityId",
            typeof(string), typeof(TextBoxEx),
            new PropertyMetadata(null, OnSecurityIDChanged)
        );

        private static void OnSecurityIDChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && d is TextBoxEx)
            {
                TextBoxEx textBoxEx = d as TextBoxEx;

                textBoxEx.Text = textBoxEx.SecurityId;
            }
        }


        public bool SelectOnEntry
        {
            get { return (bool)GetValue(SelectOnEntryProperty); }
            set { SetValue(SelectOnEntryProperty, value); }
        }

        public static readonly DependencyProperty SelectOnEntryProperty = DependencyProperty.Register("SelectOnEntry",
            typeof(bool), typeof(TextBoxEx),
            new PropertyMetadata(false, OnSelectOnEntryChanged)
        );

        private static void OnSelectOnEntryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue && d is TextBoxEx)
            {
                TextBoxEx textBoxEx = d as TextBoxEx;

                textBoxEx.GotFocus += (first, second) =>
                {
                    TextBoxEx textbE = first as TextBoxEx;

                    if (textbE != null)
                    {
                        textbE.SelectionStart = 1;
                        textbE.SelectionLength = textbE.Text.Length - 1;
                    }
                };
            }

        }

    }

}
