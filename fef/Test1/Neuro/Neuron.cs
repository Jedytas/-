namespace Test1.Neuro
{
    internal class Neuron
    {
        private NeuronType _type;
        private double[] _weights;
        private double[] _inputs;
        private double _output;
        private double _derivative;
        private double a = 0.01f;

        public double[] Weights { get => this._weights; set => this._weights = value; }
        public double[] Inputs { get => this._inputs; set => this._inputs = value; }
        public double Output { get => this._output; }
        public double Derivate { get => this._derivative; }

        public Neuron(double[] weights, NeuronType nt)
        {
            this._weights = weights;
            this._type = nt;
        }

        public void Activator(double[] inputs, double[] weights)
        {
            this._inputs = inputs;
            this._weights = weights;

            double summ = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                summ += this._inputs[i] * this._weights[i + 1];
            }

            this._output = this.LeakyRELU(summ);
            this._derivative = this.LeakyRELUDerivative(summ);
        }

        public double LeakyRELU(double x, double alpha = 0.01d)
        {
            return (x > 0.0d) ? x : alpha * x;
        }

        public double LeakyRELUDerivative(double x, double alpha = 0.01d)
        {
            return (x > 0.0d) ? 1 : alpha;
        }
    }
}
