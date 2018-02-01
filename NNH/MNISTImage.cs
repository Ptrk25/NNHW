using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NNH
{
    class MNISTImage
    {

        private int width, height;
        private int[,] pixels;
        public int label;

        public MNISTImage(int width, int height, int label)
        {
            this.width = width;
            this.height = height;
            this.label = label;
            pixels = new int[width, height];
        }

        public void setPixel(int intensity, int x, int y)
        {
            pixels[x, y] = intensity;
        }
    
        public int getPixel(int x, int y)
        {
            return pixels[x, y];
        }

        public Bitmap getImageAsBitmap()
        {
            Bitmap image = new Bitmap(width, height);

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    int intensity = pixels[x, y];
                    image.SetPixel(x, y, Color.FromArgb(0, intensity, intensity, intensity));
                }
            }

            return image;
        }

    }
}
