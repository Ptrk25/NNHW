using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NNH
{
    class MNISTParser
    {
        private readonly int LABEL_MAGIC = 2049;
        private readonly int IMAGES_MAGIC = 2051;

        private string imagesPath, labelsPath;
        private byte[] fileImages, fileLabels;
        private List<MNISTImage> mnistImages;

        public MNISTParser(string imagesPath, string labelsPath)
        {
            this.imagesPath = imagesPath;
            this.labelsPath = labelsPath;
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

            int entries = BitConverter.ToInt32(fileLabels, 4);

            for (int i = 8; i < fileLabels.Length; i++)
            {
                MNISTImage num_image = new MNISTImage(28, 28, fileLabels[i]);
                mnistImages.Add(num_image);
            }

            if (entries != mnistImages.Count)
                return false;

            return true;
        }

        private bool parseImages()
        {
            // Check MAGIC
            if (BitConverter.ToInt32(fileImages, 0) != IMAGES_MAGIC)
                return false;

            int entries = BitConverter.ToInt32(fileImages, 4);
            int x, y, image;

            if (entries != mnistImages.Count)
                return false;

            for (int i = 16; i < fileImages.Length; i++)
            {
                MNISTImage

                x = i % 16;

            }

            return true;
        }


    }
}
