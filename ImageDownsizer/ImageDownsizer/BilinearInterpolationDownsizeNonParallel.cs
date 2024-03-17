using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    public static class BilinearInterpolationDownsizeNonParallel
    {
        private static Bitmap originalImage;

        private static double downsizeFactor = 0;
        private static int newImageWidth = 0;
        private static int newImageHeight = 0;


        public static Bitmap DownsizeImage(Bitmap originalImage, double downsizeFactor)
        {
            BilinearInterpolationDownsizeNonParallel.originalImage = originalImage;
            BilinearInterpolationDownsizeNonParallel.downsizeFactor = downsizeFactor;

            CalculateNewImageSize();
            Bitmap resizedImage = new Bitmap(newImageWidth, newImageHeight);





            //TODO must calculate resizedImage
            return resizedImage;
        } 

        private static void CalculateNewImageSize()
        {
            newImageHeight = (int)Math.Round(originalImage.Height * (downsizeFactor / 100.0));
            newImageWidth = (int)Math.Round(originalImage.Width * (downsizeFactor / 100.0));
        }
    }
}
