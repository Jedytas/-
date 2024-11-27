using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Neuro
{
    abstract class Layer
    {
        protected string name;
        private string pathDirWeights;
        private string pathFileWeights;
        protected int totalNeurons;
        protected int totalPrevNeurons;
        protected const double learningRate = 5.0e-3d;
        protected const double momentum = 5.0e-2d;
        protected double[,] lastDeltaWeights;
        private Neuron[] _neurons;

        public Neuron[] Neurons { get => this._neurons; set => this._neurons = value; }
        public double[] data { set 
            { 
                for (int i = 0; i < Neurons.Length; i++)
                {
                    Neurons[i].Inputs = value;
                    Neurons[i].Activator(Neurons[i].Inputs, Neurons[i].Weights);
                }
            }
        }

        public Layer(int non, int nopn, NeuronType nt, string nm_layer) {
            this.totalNeurons = non;
            this.totalPrevNeurons = nopn;
            this.Neurons = new Neuron[non];
            this.name = nm_layer;
            this.pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            this.pathFileWeights = this.pathDirWeights + nm_layer + "_memory.csv";

            double[,] weights;
            if (File.Exists(this.pathFileWeights))
            {
                weights = this.WeightsInitialize(MemMode.GET, this.pathFileWeights);
            } else
            {
                Directory.CreateDirectory(this.pathDirWeights);    
                weights = this.WeightsInitialize(MemMode.INIT, this.pathFileWeights);
            }

            this.lastDeltaWeights = new double[non, nopn + 1];

            for (int i = 0; i < non; i++)
            {
                double[] temp_weights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; j++)
                {
                    temp_weights[j] = weights[i, j];
                }
                this.Neurons[i] = new Neuron(temp_weights, nt);
            }
        }

        public double[,] WeightsInitialize(MemMode mm, string path)
        {
            char[] splitter = new char[] { ';', ' ', };
            string tempStr;
            string[] tempStringWeights;
            double[,] weights = new double[this.totalNeurons, this.totalPrevNeurons + 1];

            switch (mm)
            {
                case MemMode.GET:
                    {
                        tempStringWeights = File.ReadAllLines(path);
                        string[] mem_element;
                        for (int i = 0; i < this.totalNeurons; i++)
                        {
                            mem_element = tempStringWeights[i].Split(splitter);
                            for (int j = 0; j < this.totalPrevNeurons + 1; j++)
                            {
                                weights[i, j] = double.Parse(mem_element[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }
                        break;
                    }
                case MemMode.SET:
                    {
                        string[] weightStrings = new string[totalNeurons];
                        for (int i = 0; i < totalNeurons; i++)
                        {
                            string[] lineWeights = new string[totalPrevNeurons + 1];
                            for (int j = 0; j < totalPrevNeurons + 1; j++)
                            {
                                lineWeights[j] = weights[i, j].ToString(CultureInfo.InvariantCulture);
                            }
                            weightStrings[i] = string.Join(splitter.ToString(), lineWeights);
                        }
                        File.WriteAllLines(path, weightStrings);
                        break;
                    }
                case MemMode.INIT:
                    {
                        const float maxValue = 1.0f;
                        const float minValue = -1.0f;

                        Random random = new Random();
                        for (int i = 0; i < totalNeurons; i++)
                        {
                            for (int j = 0; j < totalPrevNeurons + 1; j++)
                            {
                                weights[i, j] = random.NextDouble() * (maxValue - minValue) + minValue;
                            }
                        }
                        break;
                    }
            }

            return weights;
        }

        public abstract void Recognize(Network net, Layer nextLayer);
        public abstract double[] BackwardPass(double[] stuff);
    }
}
