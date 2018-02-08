using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.;

namespace NNH
{
    struct TrainingData
    {
        Vector<float> _input;
        Vector<float>_output;
    }


    class NeuralNetwork
    {
        private List<Matrix<float>> _weights;
        private List<Vector<float>> _biases;
        private Matrix<float> result;

        public void Init(List<int> layers, int output_size)
        {
            int prev_layer = layers[0];
            for(int i = 1; i < layers.Count; i++)
            {
                _weights.Add(CreateMatrix.Random<float>(prev_layer, layers[i]));
                _biases.Add(CreateVector.Random<float>(layers[i]));

                prev_layer = layers[i];
            }   
            
            _weights.Add(CreateMatrix.Random<float>(prev_layer, output_size));
            _biases.Add(CreateVector.Random<float>(output_size));
        }

        public Vector<float> FeedForward(Vector<float> input)
        {
            Vector<float> a = input;//activation off current layer
            for(int i = 0; i < _weights.Count; i++)
            {
                a = _weights[i].Multiply(a).Subtract(_biases[i]);

                foreach(float f in a.AsArray())
                    f = Sigmoid(f);
            }
            return a;
        }

        public void TrainingEpoch(List<TrainingData> data)
        {
            
        }

        private void Backpropagation(TrainingData data)
        {
            
        }

        public void Save()
        {
        }

        public void Load()
        {
            
        }

        public double Sigmoid(double x)
        {
            return 2 / (1 + Math.Exp(-2 * x)) - 1;
        }

        public double Derivative(double x)
        {
            double s = Sigmoid(x);
            return 1 - (Math.Pow(s, 2));
        }
    }
}
