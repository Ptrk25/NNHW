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
        private List<MNISTImage> mnistImages;

        public MNISTParser(string imagesPath, string labelsPath)
        {
            this.imagesPath = imagesPath;
            this.labelsPath = labelsPath;
            mnistImages = new List<MNISTImage>();
        }

        public bool parseMNIST()
        {
            bool success = true;
            fileLabels = File.ReadAllBytes(labelsPath);
            fileImages = File.ReadAllBytes(imagesPath);

            success = parseLabels();
            success = parseImages();

            return success;
        }

        private bool parseLabels()
        {
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

        private bool parseImages()
        {
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


    }
}
