using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;

using System;

namespace NNH
{
    struct TrainingData
    {
        public TrainingData(Matrix<float> input , Matrix<float> output)
        {
            _input = input;
            _output = output;
        }
        
        public Matrix<float> _input;
        public Matrix<float> _output;
    }

    class GradientDescent
    {
        public List<Matrix<float>> _gdb, _gdw;

        public GradientDescent()
        {
            _gdb = new List<Matrix<float>>();
            _gdw = new List<Matrix<float>>();
        }

        public void Add(GradientDescent G1)
        {
            for (int i = 0; i < G1._gdw.Count; i++)
            {
                _gdw[i] = _gdw[i].Add(G1._gdw[i]);
                _gdb[i] = _gdb[i].Add(G1._gdb[i]);
            }
        }

        public void AvgDescent(float rate, int batch_size)
        {
            foreach(Matrix<float> m in _gdb)
            {
                for(int x = 0; x < m.RowCount; x++)
                {
                    for(int y = 0; y < m.ColumnCount; y++)
                    {
                        m[x, y] = -rate * m[x, y] / (float)batch_size;
                    }    
                }
            }
            foreach(Matrix<float> m in _gdw)
            {
                for(int x = 0; x < m.RowCount; x++)
                {
                    for(int y = 0; y < m.ColumnCount; y++)
                    {
                        m[x, y] = -rate * m[x, y] / (float)batch_size;
                    }    
                }
            }


        }

    }


    class NeuralNetwork
    {
        private List<Matrix<float>> _weights, _biases;

        public void Init(List<int> layers)
        {
            _weights = new List<Matrix<float>>();
            _biases = new List<Matrix<float>>();

            int prev_layer = layers[0];
            for(int i = 1; i < layers.Count; i++)
            {
                _weights.Add(CreateMatrix.Random<float>(layers[i], prev_layer));
                _biases.Add(CreateMatrix.Random<float>(layers[i], 1));

                prev_layer = layers[i];
            }   
        }

        public Matrix<float> FeedForward(Matrix<float> input)
        {
            Matrix<float> a = input;//activation off current layer
            for(int i = 0; i < _weights.Count; i++)
            {
                a = _weights[i].Multiply(a).Subtract(_biases[i]);

                for(int x = 0; x < a.RowCount; x++)
                    a[x, 0] = (float)Sigmoid(a[x, 0]);
            }
            return a;
        }

        public void TrainingEpoch(List<TrainingData> data, float rate)
        {
            GradientDescent g = Backpropagation(data[0]);
            for(int i = 1; i < data.Count; i++)
            {
                GradientDescent temp = Backpropagation(data[i]);
                g.Add(temp);
            }
            g.AvgDescent(rate, data.Count);
               
            for( int i = 0; i < _weights.Count; i++)
            {
                _weights[i] = _weights[i].Add(g._gdw[i]);
            }

            for(int i = 0; i < _weights.Count; i++)
            {
                _biases[i] = _biases[i].Add(g._gdb[i]);
            }
        }

        private GradientDescent Backpropagation(TrainingData data)
        {
            //feedforward

            List<Matrix<float>> la = new List<Matrix<float>>(), lz = new List<Matrix<float>>();

            Matrix<float> a = data._input;
            la.Insert(0, a);
            for(int i = 0; i < _weights.Count; i++)
            {
                Matrix<float> z = _weights[i].Multiply(a).Subtract(_biases[i]);
                lz.Add(z);

                a = CreateMatrix.Dense<float>(z.RowCount, z.ColumnCount, 0);

                for(int x = 0; x < z.RowCount; x++)
                    a[x, 0] = (float)Sigmoid(z[x, 0]);

                la.Add(a);                   
            }

            //gradient of weights, biases, and zs
            List<Matrix<float>> gdb = new List<Matrix<float>>(), gdw = new List<Matrix<float>>();
            Matrix<float> db = CreateMatrix.Dense<float>(a.RowCount, a.ColumnCount, 0);
            Matrix<float> dw;
            for(int x = 0; x < db.RowCount; x++)
            {
                db[x, 0]= (float)CostDerivative(a[x, 0], data._output[x, 0] ) * (float)Derivative(lz[lz.Count - 1][x, 0]);
            }
            dw = db.Multiply(la[la.Count - 2].Transpose());
       
            gdb.Insert(0, db);
            gdw.Insert(0, dw);
       
            for(int i = _weights.Count - 2; i >= 0; i--)
            {
                db = _weights[i+1].Transpose().Multiply(db);
                for (int x = 0; x < db.RowCount; x++)
                {
                    db[x, 0] = db[x, 0] * (float)Derivative(lz[i][x, 0]);
                }
                dw = db.Multiply(la[i].Transpose());

                gdw.Insert(0, dw);
                gdb.Insert(0, db);
            }
            GradientDescent result = new GradientDescent();
            result._gdw = gdw;
            result._gdb = gdb;
            return result;
        }

        public void Save()
        {
        }

        public void Load()
        {
            
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        private double Derivative(double x)
        {
            double s = Sigmoid(x);
            return s * (1 - s);
        }

        private double CostDerivative(float x, float y)
        {
            return 2*(x - y);
        }
    }
}
