using System;
using System.Collections.Generic;
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
        public static BitmapImage firstPic = new BitmapImage(new Uri("C:/C# Projects/2048/2048/2048/Number2.png", UriKind.RelativeOrAbsolute));
    }
}
