using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseColorIndicator
{
    public class ImageProcessor
    {
        public static Bitmap CaptureScreen() // ref: https://stackoverflow.com/questions/4978157/how-to-search-for-an-image-on-screen-in-c
        {
            var image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }
            return image;
        }

        public static Bitmap CaptureMouseRegion(int xpos, int ypos)
        {
            var width = 960;
            var height = 540;
            var image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CopyFromScreen(xpos - width / 2, ypos - height / 2, 0, 0, image.Size, CopyPixelOperation.SourceCopy);
            }

            return image;
        }
    }
}
