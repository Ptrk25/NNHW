using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MathNet.Numerics.LinearAlgebra;

namespace NNH
{

    class NeuralNetworkParser
    {
        public NeuralNetwork network;
        private int input_size;

        public NeuralNetworkParser(int inputSize = 784)
        {
            input_size = inputSize;
            network = new NeuralNetwork();

            List<int> layers = new List<int> { input_size, 30, 10 };

            network.Init(layers);
        }

        public Matrix<float> FeedForward(MNISTImage image)
        {
            return network.FeedForward(ToTrainingData(image)._input);
        }

        public TrainingData ToTrainingData(MNISTImage img)
        {
            TrainingData d = new TrainingData();

            Matrix<float> input = CreateMatrix.Dense<float>(input_size, 1, 0);
            int x = 0;
            foreach (int grey in img.pixels)
            {
                input[x, 0] = (float)grey / 255;
                x++;
            }

            Matrix<float> output = CreateMatrix.Dense<float>(10, 1, 0);
            for (x = 0; x < output.RowCount; x++)
            {
                if (x == img.label)
                {
                    output[x, 0] = 1.0f;
                }
            }

            d._input = input;
            d._output = output;
            return d;
        }

        public void Train(List<MNISTImage> images, float rate = .2f)
        {
            List<TrainingData> data = new List<TrainingData>();
            foreach(MNISTImage img in images)
            {
                data.Add(ToTrainingData(img));
            }

            network.TrainingEpoch(data, rate);
        }

    }
}
