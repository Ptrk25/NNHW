using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MathNet.Numerics.LinearAlgebra;

namespace NNH
{

    class NeuralNetworkHandler
    {
        public NeuralNetwork network;
        private int input_size;
        private Matrix<float> results;

        public NeuralNetworkHandler()
        {
            input_size = 748;
            network = new NeuralNetwork();
        
            List<int> layers = new List<int> { input_size, 16, 16, 10 };
            network.Init(layers);
        }

        public void Train(List<MNISTImage> images)
        {
            List<TrainingData> data = new List<TrainingData>();
            foreach(MNISTImage img in images)
            {
                TrainingData d = new TrainingData();

                Matrix<float> input = CreateMatrix.Dense<float>(input_size, 1, 0);
                int x = 0;
                foreach(int grey in img.pixels)
                {
                    input[x, 0] = (float)grey / 255;
                    x++;
                }

                Matrix<float> output = CreateMatrix.Dense<float>(10, 1, 0);
                for(x = 0; x < output.RowCount; x++)
                {
                    if(x == img.label)
                    {
                        output[x, 0] = 1.0f;
                    }
                }

                d._input = input;
                d._output = output;
                data.Add(d);
            }

            network.TrainingEpoch(data, 0.2f);
            //results = network.FeedForward(input);
        }

        public void getResults()
        {
            //Matrix<float> result = network.FeedForward(input);
        }

    }
}
