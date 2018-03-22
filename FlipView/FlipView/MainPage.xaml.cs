using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using FlipView.Models;

namespace FlipView
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<MyImage> mImgs;
        private string[] types = {".png", ".jpg", ".jepg"};
 
        public MainPage()
        {
            this.InitializeComponent();
            mImgs = new ObservableCollection<MyImage>();
        }

        private async void ChooseImg_OnClick(object sender, RoutedEventArgs e)
        {
            MyProgress.IsActive = true;

            mImgs.Clear();
            var imgs = await ReadFileAsync();
            imgs.ForEach(async p=>mImgs.Add(await GetImg(p)));

            MyProgress.IsActive = false;
        }

        private async Task<MyImage> GetImg(StorageFile file)
        {
            var img = new MyImage
            {
                Name = file.DisplayName,
                Source = new BitmapImage()
            };

            var stream = await file.OpenAsync(FileAccessMode.Read);
            await img.Source.SetSourceAsync(stream);

            return img;
        }
            
        private async Task<List<StorageFile>> ReadFileAsync()
        {
            List<StorageFile> imgs = new List<StorageFile>();

            Windows.Storage.Pickers.FolderPicker folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            if (folder == null) return imgs;

            var items = await folder.GetFilesAsync();

            imgs = items.Where(p => types.Contains(p.FileType)).Select(p => p).ToList();

            return imgs;
        }
    }
}
