using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace CustomRichEditTextBoxTest
{
    public sealed class CustomRichEditBox : RichEditBox
    {
        public CustomRichEditBox()
        {
            this.DefaultStyleKey = typeof(RichEditBox);
            this.TextChanged += CustomRichEditBox_TextChanged;
        }

        private void CustomRichEditBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string value = string.Empty;
            this.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            CustomText = value;
        }

        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set
            {
                SetValue(CustomTextProperty, value);
            }
        }

        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register("CustomText", typeof(string), typeof(CustomRichEditBox), new PropertyMetadata(null, new PropertyChangedCallback(OnCustomTextChanged)));

        private static void OnCustomTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomRichEditBox rich = d as CustomRichEditBox;
            if (e.NewValue != e.OldValue)
            {
                rich.Document.SetText(Windows.UI.Text.TextSetOptions.None, e.NewValue.ToString());
            }
        }
    }
}