using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace NNH
{
    class NeuralNetwork
    {
        List<Matrix<float>> _weights;
        List<Matrix<float>> _biases;
        Matrix<float> result;

        public void init(List<int> layers, int output_size){
            int prev_layer = layers[0];
            for(int i = 1; i < layers.Count; i++){
                _weights.Add(CreateMatrix.Dense<float>(prev_layer, layers[i]));
                _biases.Add(CreateMatrix.Dense<float>(layers[i], 1));

                prev_layer = layers[i];
            }   
            
            _weights.Add(CreateMatrix.Dense<float>(prev_layer, output_size));
            _biases.Add(CreateMatrix.Dense<float>(output_size, 1));
        }
    }
}
