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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Navigation
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string s && !string.IsNullOrWhiteSpace(s))
            {
                MyTextBlock.Text = $"Hi, {s}";
            }
            else
            {
                MyTextBlock.Text = "Hi!";
            }
            base.OnNavigatedTo(e);
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var text = MyTextBox.Text;
            Frame.Navigate(typeof(Page4), text);
        }
    }
}
