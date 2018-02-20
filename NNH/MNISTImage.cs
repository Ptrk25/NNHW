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
        public int[,] pixels;
        public int label;

        public MNISTImage(int width, int height, int label)
        {
            this.width = width;
            this.height = height;
            this.label = label;
            pixels = new int[width, height];
        }

        public MNISTImage(Bitmap img)
        {
            this.width = img.Width;
            this.height = img.Height;
            pixels = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pixels[x, y] = 255 - img.GetPixel(x,y).R;
                }
            }
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
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    int intensity = 255 - pixels[x, y];
                    image.SetPixel(x, y, Color.FromArgb(255, intensity, intensity, intensity));
                }
            }

            return image;
        }

    }
}
