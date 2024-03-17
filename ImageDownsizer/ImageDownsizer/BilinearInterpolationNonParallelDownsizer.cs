﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    public static class BilinearInterpolationNonParallelDownsizer
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
            BilinearInterpolationNonParallelDownsizer.originalImage = originalImage;
            BilinearInterpolationNonParallelDownsizer.downsizingFactor = downsizeFactor;

            CalculateNewImageSize();
            resizedImage  = new Bitmap(newImageWidth, newImageHeight);

            originalImageData = originalImage.
                LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height), 
                ImageLockMode.ReadOnly, originalImage.PixelFormat);

            resizedImageData = resizedImage.
                LockBits(new Rectangle(0, 0, newImageWidth, newImageHeight),
                ImageLockMode.WriteOnly, originalImage.PixelFormat);

            int pixelSize = Image.GetPixelFormatSize(originalImageData.PixelFormat) / 8;

            int originalStride = originalImageData.Stride;
            int resizedStride = resizedImageData.Stride;

            originalPixelArray = new int[originalStride * originalImageData.Height / 4];
            resizedPixelArray = new int[resizedStride * resizedImageData.Height / 4];

            Marshal.Copy(originalImageData.Scan0, originalPixelArray, 0, originalPixelArray.Length);

            FillNewBitmap(originalStride, resizedStride);

            Marshal.Copy(resizedPixelArray, 0, resizedImageData.Scan0, resizedPixelArray.Length);

            originalImage.UnlockBits(originalImageData);
            resizedImage.UnlockBits(resizedImageData);


            
            //TODO must calculate resizedImage
            return resizedImage;
        }
        public static void FillNewBitmap(int originalStride, int resizedStride)
        {
            for (int yIterator = 0; yIterator < newImageHeight; yIterator++)
            {
                for (int xIterator = 0; xIterator < newImageWidth; xIterator++)
                {
                    //Find x and y coordinates in original image
                    double originalX = xIterator * originalImage.Width / (double)newImageWidth;
                    double originalY = yIterator * originalImage.Height / (double)newImageHeight;

                    //Calculate neighbouring pixels in the original image of the one we want to create
                    //x = 0 y = 0 - upper left corner ; x+ y+ - lower right corner
                    int xLeft = (int)Math.Floor(originalX);
                    int yUp = (int)Math.Floor(originalY);
                    int xRight = Math.Min(xLeft + 1, originalImage.Width - 1);
                    int yDown = Math.Min(yUp + 1, originalImage.Height - 1);

                    //Calculate weights
                    double distanceX = originalX - xLeft; //value should be between 0(left) and 1(right)
                    double distanceY = originalY - yUp; //value should be between 0(up) and 1(down)

                    int pixelIndexUpLeft = yUp * originalStride / 4 + xLeft;
                    int pixelIndexUpRight = yUp * originalStride / 4 + xRight;
                    int pixelIndexDownLeft = yDown * originalStride / 4 + xLeft;
                    int pixelIndexDownRight = yDown * originalStride / 4 + xRight;

                    int interpolatedPixel = (int)(
                                                (originalPixelArray[pixelIndexUpLeft] * (1 - distanceX) * (1 - distanceY)) +
                                                (originalPixelArray[pixelIndexUpRight] * distanceX * (1 - distanceY)) +
                                                (originalPixelArray[pixelIndexDownLeft] * (1 - distanceX) * distanceY) +
                                                (originalPixelArray[pixelIndexDownRight] * distanceX * distanceY)
                        );

                    int pixelIndex = yIterator * (resizedStride / 4) + xIterator;
                    resizedPixelArray[pixelIndex] = interpolatedPixel;

                }
            }
        }

        private static void CalculateNewImageSize()
        {
            newImageHeight = (int)Math.Round(originalImage.Height * downsizingFactor);
            newImageWidth = (int)Math.Round(originalImage.Width * downsizingFactor);
        }
    }
}