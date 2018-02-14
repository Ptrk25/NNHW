using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.Data.;
using System;

namespace NNH
{
    struct TrainingData
    {
        public Matrix<float> _input;
        public Matrix<float> _output;
    }

    struct GradientDescent
    {
        public List<Matrix<float>> _gdb, _dgw;

        public static GradientDescent operator +(GradientDescent G1, GradientDescent G2)
        {
            GradientDescent result;
            for(int i = 0; i < G1._dgw.Count; i++)
            {
                result._dgw.Add(G1._dgw[i].Add(G2._dgw[i]));
                result._dgb.Add(G1._dgb[i].Add(G2._dgb[i]));
            }
        }

        public void AvgDescend(int samplesize, float rate)
        {
            double sum = 0;
            foreach(Matrix<float> m in _gdb)
            {
                foreach(float f in m)
                {
                    sum += f*f;
                }
            }
            foreach(Matrix<float> m in _gdw)
            {
                foreach(float f in m)
                {
                    sum += f*f;
                }
            }

            double len = Math.Sqrt(sum);

            foreach(Matrix<float> m in _gdb)
            {
                foreach(float f in m)
                {
                    f = - rate * f / sum;
                }
            }
            foreach(Matrix<float> m in _gdw)
            {
                foreach(float f in m)
                {
                    f = - rate * f / sum;
                }
            }


        }

    }


    class NeuralNetwork
    {
        private List<Matrix<float>> _weights, _biases;

        public void Init(List<int> layers)
        {
            int prev_layer = layers[0];
            for(int i = 1; i < layers.Count; i++)
            {
                _weights.Add(CreateMatrix.Random<float>(prev_layer, layers[i]));
                _biases.Add(CreateVector.Random<float>(layers[i]));

                prev_layer = layers[i];
            }   
        }

        public Matrix<float> FeedForward(Matrix<float> input)
        {
            Matrix<float> a = input;//activation off current layer
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
            GradientDescent g = Backpropagation(data[0]);
            for(int i = 1; i < data.Count; i++)
            {
                g = g + Backpropagation(data[0]);
            }
            g.AvgDescend(data.Count, 0.2);
               
            for(int i = 0; i < _weights.Count; i++)
            {
                _weights[i].Add(g._dgw[i]);
            }

            for(int i = 0; i < _weights.Count; i++)
            {
                _biases[i].Add(g._dgb[i]);
            }
        }

        private GradientDescent Backpropagation(TrainingData data)
        {
            //feedforward

            List<Matrix<float>> la, lz;
            Matrix<float> a = data._input;
            la.Insert(0, a);
            for(int i = 0; i < _weights.Count; i++)
            {
                a = _weights[i].Multiply(a).Subtract(_biases[i]);
                lz.Insert(0, a);

                foreach(float f in a.AsArray())
                {
                     f = Sigmoid(f);
                }

                la.Insert(0, a);                   
            }

            //gradient of weights, biases, and zs
            List<Matrix<float>> ldb, ldw;
            Matrix<float> db = a;
            Matrix<float> dw;
            for(int x = 0; x < db; x++)
            {
                db[x]= CostDerivative(c[x] - a[x]) * Derivative(lz[lz.Count - 1][x]);
            }
            dw = db.Multiply(la[la.Count - 2].Transpose());
       
            ldb.Insert(0, db);
            ldw.Insert(0, dw);
       
            for(int i = _weights.Count - 2; i > 0; i--)
            {
                db = _weights[i+1].Transpose().Multiply(db);
                for(int x = 0; x < db; x++)
                {
                    db[x]= CostDerivative(c[x] - a[x]) * Derivative(lz[i][x]);
                }
                dw = db.Multiply(la[la.Count - 2].Transpose());

                ldw.Insert(0, dw);
                ldb.Insert(0, db);
            }
            GradientDescent result;
            result._dgw = dw;
            result._gdb = db;
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
            return 2 / (1 + Math.Exp(-2 * x)) - 1;
        }

        private double Derivative(double x)
        {
            double s = Sigmoid(x);
            return 1 - (Math.Pow(s, 2));
        }

        private double CostDerivative(float x, float y)
        {
            return 2*(x + y);
        }
    }
}
