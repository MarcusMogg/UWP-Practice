using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace ScrollableTextBlock
{
    public sealed partial class ScrollableTextBlock : UserControl
    {
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                ParseText();
            }
        }

        public ScrollableTextBlock()
        {
            this.InitializeComponent();
        }

        private void ParseText()
        {
            foreach (var i in _text.Split(" "))
            {
                TextBlock tmp = GetTextBlock();
                tmp.Text = i;
                MyStackPanel.Children.Add(tmp);
            }
        }

        private TextBlock GetTextBlock()
        {
            var res = new TextBlock
            {
                FontFamily = FontFamily,
                TextWrapping = TextWrapping.Wrap,
                FontSize = FontSize,
                FontWeight = FontWeight,
                Foreground = Foreground,
                Margin = new Thickness(0, 12, 0, 0)
            };

            return res;
        }
    }
}
