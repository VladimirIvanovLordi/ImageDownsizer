using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    //NOT COMPLETE
    public static class BilinearInterpolationParallelDownsizer
    {
        private static Bitmap originalImage;
        private static Bitmap resizedImage;

        private static double downsizingFactor = 0;
        private static int newImageWidth = 0;
        private static int newImageHeight = 0;

        private static BitmapData originalImageData;
        private static BitmapData resizedImageData;

        private static int[] originalPixelArray;
        private static int[] resizedPixelArray;


        public static Bitmap DownsizeImage(Bitmap originalImage, double downsizeFactor)
        {
            BilinearInterpolationParallelDownsizer.originalImage = originalImage;
            BilinearInterpolationParallelDownsizer.downsizingFactor = downsizeFactor;

            //
            CalculateNewImageSize();
            //

            resizedImage = new Bitmap(newImageWidth, newImageHeight);

            originalImageData = originalImage.
                LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly, originalImage.PixelFormat);

            // could use newImageWidth and newImageHeight but I have problems with
            // array out of range exception so I changed it for consistency
            resizedImageData = resizedImage.
                LockBits(new Rectangle(0, 0, resizedImage.Width, resizedImage.Height),
                ImageLockMode.WriteOnly, resizedImage.PixelFormat);

            //int pixelSize = Image.GetPixelFormatSize(originalImageData.PixelFormat) / 8;
            int originalPixelSize = Image.GetPixelFormatSize(originalImageData.PixelFormat) / 8;
            int resizedPixelSize = Image.GetPixelFormatSize(resizedImageData.PixelFormat) / 8;

            int originalStride = originalImageData.Stride;
            int resizedStride = resizedImageData.Stride;

            originalPixelArray = new int[originalStride * originalImageData.Height / 4];
            resizedPixelArray = new int[resizedStride * resizedImageData.Height / 4];

            Marshal.Copy(originalImageData.Scan0, originalPixelArray, 0, originalPixelArray.Length);

            int numberOfLogicalCores = Environment.ProcessorCount;
            Thread[] threads = new Thread[numberOfLogicalCores];
            
            for (int i = 0; i < numberOfLogicalCores; i++)
            {
                threads[i] = new Thread(() => FillNewBitmap(originalStride, resizedStride, originalPixelSize, resizedPixelSize, i));
                threads[i].Start();
            }
            //FillNewBitmap(originalStride, resizedStride, originalPixelSize, resizedPixelSize);
            
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Marshal.Copy(resizedPixelArray, 0, resizedImageData.Scan0, resizedPixelArray.Length);

            originalImage.UnlockBits(originalImageData);
            resizedImage.UnlockBits(resizedImageData);


            return resizedImage;
        }
        public static void FillNewBitmap(int originalStride, int resizedStride, int originalPixelSize, int resizedPixelSize, int segmentForParallelProcessing)
        {

            // segmentForParallelProcessing not implemented
            // was supposed to divide the bitmap array that we got into appropriate number of pieces
            // and give each thread a piece with calculated size (starting and ending position) to process



            for (int yIterator = 0; yIterator < newImageHeight; yIterator++)
            {
                for (int xIterator = 0; xIterator < newImageWidth; xIterator++)
                {
                    //Find x and y coordinates in original image
                    double originalX = xIterator / downsizingFactor;
                    double originalY = yIterator / downsizingFactor;


                    //Calculate neighbouring pixels in the original image of the one we want to create
                    //x = 0 y = 0 - upper left corner ; x+ y+ - lower right corner
                    int xLeft = (int)Math.Floor(originalX);
                    int yUp = (int)Math.Floor(originalY);
                    int xRight = Math.Min(xLeft + 1, originalImage.Width - 1);
                    int yDown = Math.Min(yUp + 1, originalImage.Height - 1);

                    //Calculate weights
                    double distanceX = originalX - xLeft;
                    double distanceY = originalY - yUp;


                    int pixelIndexUpLeft = yUp * originalStride / 4 + xLeft;
                    int pixelIndexUpRight = yUp * originalStride / 4 + xRight;
                    int pixelIndexDownLeft = yDown * originalStride / 4 + xLeft;
                    int pixelIndexDownRight = yDown * originalStride / 4 + xRight;

                    //int interpolatedPixel = (int)(
                    //                            (originalPixelArray[pixelIndexUpLeft] * (1 - distanceX) * (1 - distanceY)) +
                    //                            (originalPixelArray[pixelIndexUpRight] * distanceX * (1 - distanceY)) +
                    //                            (originalPixelArray[pixelIndexDownLeft] * (1 - distanceX) * distanceY) +
                    //                            (originalPixelArray[pixelIndexDownRight] * distanceX * distanceY)
                    //    );

                    int[] interpolatedPixel = new int[resizedPixelSize / 4];
                    for (int i = 0; i < originalPixelSize / 4; i++)
                    {
                        double value = (originalPixelArray[pixelIndexUpLeft] * (1 - distanceX) * (1 - distanceY)) +
                                       (originalPixelArray[pixelIndexUpRight] * distanceX * (1 - distanceY)) +
                                       (originalPixelArray[pixelIndexDownLeft] * (1 - distanceX) * distanceY) +
                                       (originalPixelArray[pixelIndexDownRight] * distanceX * distanceY);

                        interpolatedPixel[i] = (int)Math.Round(value);
                    }

                    int pixelIndex = yIterator * (resizedStride / 4) + xIterator;
                    Array.Copy(interpolatedPixel, 0, resizedPixelArray, pixelIndex, resizedPixelSize / 4);
                    //resizedPixelArray[pixelIndex] = interpolatedPixel;

                }
            }
        }

        private static void CalculateNewImageSize()
        {
            newImageHeight = (int)Math.Round(originalImage.Height * downsizingFactor);
            newImageWidth = (int)Math.Round(originalImage.Width * downsizingFactor);
            // Math.Round
        }
    }
}
