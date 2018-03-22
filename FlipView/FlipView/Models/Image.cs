using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipView.Models
{
    public class MyImage
    {
        public BitmapImage Source { get; set; }
        public string Name { get; set; }

        //public MyImage(StorageFile file)
        //{
        //    Source =  new BitmapImage();
        //    var stream = await file.ope();
        //    Source.SetSourceAsync(file);
        //    Name = file.Path; //file.DisplayName;
        //}
    }
}
