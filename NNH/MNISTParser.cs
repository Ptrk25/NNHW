using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NNH
{
    class MNISTParser
    {
        private readonly int LABEL_MAGIC = 17301504;
        private readonly int IMAGES_MAGIC = 50855936;

        private string imagesPath, labelsPath;
        private byte[] fileImages, fileLabels;
        private Random rnd;
        private List<MNISTImage> mnistImages, mnistImage_copy;

        public MNISTParser(string imagesPath, string labelsPath)
        {
            this.imagesPath = imagesPath;
            this.labelsPath = labelsPath;
            mnistImages = new List<MNISTImage>();
            mnistImage_copy = new List<MNISTImage>();
            rnd = new Random();
        }

        public bool parseLabels()
        {
            fileLabels = File.ReadAllBytes(labelsPath);

            // Check MAGIC
            if (BitConverter.ToInt32(fileLabels, 0) != LABEL_MAGIC)
                return false;

            for (int i = 8; i < fileLabels.Length; i++)
            {
                MNISTImage num_image = new MNISTImage(28, 28, fileLabels[i]);
                mnistImages.Add(num_image);
            }

            return true;
        }

        public bool parseImages()
        {
            fileImages = File.ReadAllBytes(imagesPath);

            // Check MAGIC
            if (BitConverter.ToInt32(fileImages, 0) != IMAGES_MAGIC)
                return false;

            int x = 0, y = 0, image = 0;

            for (int i = 16; i < fileImages.Length; i++)
            {
                MNISTImage current_image = mnistImages[image];
                current_image.setPixel(fileImages[i], x, y % 28);
                mnistImages[image] = current_image;

                x = (i + 13) % 28;

                if (y % 28 == 0 && x == 0 && y != 0)
                    image++;

                if (x == 0)
                    y++;
                
            }

            return true;
        }

        public int getSizeInMB()
        {
            return (fileImages.Length + fileLabels.Length) / 1024 / 1024;
        }

        public int getEntriesCount()
        {
            return mnistImages.Count;
        }

        public List<MNISTImage> GetRndImages(int amount)
        {
            List<MNISTImage> rndImages = new List<MNISTImage>();

            if (mnistImages.Count == 0)
                mnistImages = mnistImage_copy;

            for (int i = 0; i < amount; i++)
            {
                if(amount > mnistImages.Count)
                {
                    mnistImage_copy.AddRange(mnistImages);
                    mnistImages = mnistImage_copy;
                    mnistImages.Reverse();
                }

                int number = rnd.Next(0, mnistImages.Count-1);
                rndImages.Add(mnistImages[number]);
                mnistImage_copy.Add(mnistImages[number]);
                mnistImages.RemoveAt(number);
            }

            return rndImages;
        }

        public List<MNISTImage> GetImages(int from, int to)
        {
            List<MNISTImage> result = new List<MNISTImage>();
            for(int i = from; i <= to; i++)
            {
                result.Add(mnistImages[i]);
            }
            return result;
        }

        public MNISTImage GetImage(int index)
        {
            return mnistImages[index];
        }



    }
}
