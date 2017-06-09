using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _2048
{
    public static class AllBitmapImages
    {
        //https://msdn.microsoft.com/en-us/library/aa970269(v=vs.110).aspx
        //Add all the bitmapimages with resource and check if it works
        public static BitmapImage firstPic = new BitmapImage();
        public static BitmapImage secondPic = new BitmapImage();
        public static BitmapImage[] allPics = new BitmapImage[2];
        public static void IntializeImages()
        {
            firstPic = BitmapToImageSource(Properties.Resources.Number2);
            secondPic = BitmapToImageSource(Properties.Resources.Number21);
            allPics[0] = firstPic;
            allPics[1] = secondPic;
        }
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        //public static BitmapImage firstPic = new BitmapImage(new Uri("C:/C# Projects/2048/2048/2048/Number2.png", UriKind.RelativeOrAbsolute));
    }
}
