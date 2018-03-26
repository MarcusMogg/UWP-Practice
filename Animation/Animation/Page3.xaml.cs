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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Animation.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Animation
{
    
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Page3 : Page
    {
        private Book clickBook;
        private List<Book> Books;

        public Page3()
        {
            this.InitializeComponent();
            Books = BookManager.GetBooks();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            clickBook = new Book();
        }


        private void BookListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(e.ClickedItem is Book item)) return;

            BookListView.PrepareConnectedAnimation("Image", item, "SourceImage");
            clickBook = item;

            this.Frame.Navigate(typeof(Page2), item.CoverImage);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Book item = clickBook; // Get persisted item
            if (item != null)
            {
                BookListView.ScrollIntoView(item);
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackImage");
                if (animation != null)
                {
                    await BookListView.TryStartConnectedAnimationAsync(animation, item, "SourceImage");
                }
            }
        }

       
    }
}
