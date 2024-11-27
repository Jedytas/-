using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Neuro
{
    class InputLayer
    {
        private Random random;

        private double[,] trainSet;
        private double[,] testSet;

        public double[,] TrainSet { get => this.trainSet; }
        public double[,] TestSet { get => this.testSet; }

        public InputLayer(NeuronMode nm) { 
            this.random = new Random();

            this.trainSet = new double[100, 16];
            this.testSet = new double[10, 16];

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] tempStr;
            string[] tempArrStr;
            double[] tempArr;

            switch (nm)
            {
                case NeuronMode.Train:
                    {
                        tempArrStr = File.ReadAllLines(path + "train.txt");
                        for (int i = 0; i < tempArrStr.Length; i++)
                        {
                            tempStr = tempArrStr[i].Split();
                            tempArr = new double[tempStr.Length];
                            for (int j = 0; j < tempArrStr.Length; j++)
                            {
                                tempArr[j] = double.Parse(tempStr[i], System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }

                        for (int n = this.trainSet.GetLength(0) - 1; n >= 1; n--)
                        {
                            int j = this.random.Next(n + 1);
                            double[] temp = new double[this.trainSet.GetLength(1)];

                            for (int i = 0; i < this.trainSet.GetLength(1); i++)
                            {
                                temp[i] = this.trainSet[n, i];
                            }

                            for (int i = 0; i < this.trainSet.GetLength(1); i++)
                            {
                                this.trainSet[n, i] = this.trainSet[j, i];
                                this.trainSet[j, i] = temp[i];
                            }
                        }
                        break;
                    }
            }
        }
    }
}
