using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NNH
{
    class ImageProcessor
    {
        private int xStart = 255, yStart = 255, xEnd = 0, yEnd = 0;
        private int margin = 15;

        public ImageProcessor()
        {

        }

        public Bitmap processImage(Bitmap img)
        {
            Bitmap newImage;
            getBounds(img);
            img = cropImage(img);
            newImage = new Bitmap(img, 28, 28);

            return newImage;
        }

        private void getBounds(Bitmap img)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    // Get xStart
                    if (img.GetPixel(x, y).R < 255 && x < xStart)
                        xStart = x;

                    // Get xEnd
                    if (img.GetPixel(x, y).R == 255 && img.GetPixel(Math.Abs(x - 1), y).R < 255 && x > xEnd)
                        xEnd = x-1;

                }
            }

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    // Get yStart
                    if (img.GetPixel(x, y).R < 255 && y < yStart)
                        yStart = y;

                    // Get yEnd
                    if (img.GetPixel(x, y).R == 255 && img.GetPixel(x, Math.Abs(y-1)).R < 255 && y > yEnd)
                        yEnd = y - 1;

                }
            }

        }

        private Bitmap cropImage(Bitmap img)
        {
            int size = 0;
            bool isYLarger = false;

            size = xEnd - xStart + 2 * margin;

            if (yEnd - yStart + 2 * margin > size)
            {
                size = yEnd - yStart + 2 * margin;
                isYLarger = true;
            }

            Bitmap newImg = new Bitmap(size, size);

            // Set BG Color (white)
            using (Graphics gfx = Graphics.FromImage(newImg))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
            {
                gfx.FillRectangle(brush, 0, 0, newImg.Width, newImg.Height);
            }

            // Write new Image
            for (int y = yStart; y < yEnd; y++)
            {
                for(int x = xStart; x < xEnd; x++)
                {
                    if (isYLarger)
                        newImg.SetPixel(newImg.Width / 2 - ((xEnd - xStart) / 2) + x - xStart, y - yStart + margin, img.GetPixel(x,y));
                    else
                        newImg.SetPixel(x - xStart + margin, newImg.Height / 2 - ((yEnd-yStart) / 2) + y - yStart, img.GetPixel(x, y));
                }
            }

            return newImg;
        }
        
    }
}

