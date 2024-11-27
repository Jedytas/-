using Microsoft.VisualBasic.Devices;

namespace Test1.Neuro
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, NeuronType neuronType, string name)
        : base(non, nopn, neuronType, name) { }

        public override double[] BackwardPass(double[] stuff)
        {
            double[] gradientSumm = new double[this.totalPrevNeurons];
            //TODO
            return gradientSumm;
        }

        public override void Recognize(Network net, Layer nextLayer)
        {
            double[] hidden_out = new double[this.Neurons.Length];

            for (int i = 0; i < this.Neurons.Length; i++)
            {
                hidden_out[i] = this.Neurons[i].Output;
            }

            nextLayer.data = hidden_out;
        }
    }
}