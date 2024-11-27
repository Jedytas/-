using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Neuro
{
    class Network
    {
        private InputLayer _inputLayer = null;
        private HiddenLayer _hiddenLayer1 = new HiddenLayer(72, 15, NeuronType.Hidden, nameof(_hiddenLayer1));
        private HiddenLayer _hiddenLayer2 = new HiddenLayer(30, 72, NeuronType.Hidden, nameof(_hiddenLayer2));
        private OutputLayer _outputLayer = new OutputLayer(10, 30, NeuronType.Hidden, nameof(_outputLayer));

        public double[] fact = new double[10];
        private double e_error_avr;

        public double[] Fact { get => this.fact; }

        public double E_error_avr { get => e_error_avr; set => e_error_avr = value; }

        public Network()
        {

        }

        public void Train(Network network)
        {
            int iterations = 70;
            network._inputLayer = new InputLayer(NeuronMode.Train);
            double tempSummError;
            double[] errors;
            double[] temp_gradient_summ1l;
            double[] temp_gradient_summ2l;


        }

        public void ForwardPass(Network net, double[] netInput)
        {
            net._hiddenLayer1.data = netInput;
            net._hiddenLayer1.Recognize(null, net._hiddenLayer2);
            net._hiddenLayer2.Recognize(null, net._outputLayer);
            net._outputLayer.Recognize(net, null);
        }
    }
}
