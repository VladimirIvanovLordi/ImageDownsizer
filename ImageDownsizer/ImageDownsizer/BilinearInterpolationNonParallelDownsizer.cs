using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    public static class BilinearInterpolationNonParallelDownsizer
    {
        private static Bitmap originalImage;
        private static Bitmap resizedImage;

        private static double downsizeFactor = 0;
        private static int newImageWidth = 0;
        private static int newImageHeight = 0;


        public static Bitmap DownsizeImage(Bitmap originalImage, double downsizeFactor)
        {
            BilinearInterpolationNonParallelDownsizer.originalImage = originalImage;
            BilinearInterpolationNonParallelDownsizer.downsizeFactor = downsizeFactor;

            CalculateNewImageSize();
            resizedImage  = new Bitmap(newImageWidth, newImageHeight);

            for (int yIterator = 0; yIterator < newImageHeight; yIterator++)
            {
                for (int xIterator = 0; xIterator < newImageWidth; xIterator++)
                {

                }
            }




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
