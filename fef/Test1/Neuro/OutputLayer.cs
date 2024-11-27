using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Neuro
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, NeuronType neuronType, string type) : base(non, nopn, neuronType, type) { }

        public override double[] BackwardPass(double[] stuff)
        {
            double[] gr_summ = new double[this.totalPrevNeurons + 1];

            return gr_summ;
        }

        public override void Recognize(Network net, Layer nextLayer)
        {
            double e_summ = 0.0d;

            for (int i = 0; i < this.Neurons.Length; i++) {
                e_summ += this.Neurons[i].Output;
            }

            for (int i = 0; i < this.Neurons.Length; i++)
            {
                net.fact[i] = this.Neurons[i].Output / e_summ;
            }
        }
    }
}
