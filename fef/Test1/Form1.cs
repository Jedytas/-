using System.IO;
using Test1.Neuro;

namespace Test1
{
    public partial class Form1 : Form
    {
        private bool[] _bStates;
        private Network net;

        public Form1()
        {
            InitializeComponent();
            this._bStates = new bool[15];
            this.net = new Network();
        }

        private void buttonEND_Click(object sender, EventArgs e)
        {
            double[] d = new double[15];
            for (int i = 0; i < 15; i++)
            {
                d[i] = this._bStates[i] ? 1.0d : 0.0d;
            }
            net.ForwardPass(this.net, d);
            Answer.Text = net.fact.ToList().IndexOf(net.fact.Max()).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tag = int.Parse((string)((Button)sender).Tag);
            this._bStates[tag] = !this._bStates[tag];
            ((Button)sender).BackColor = this._bStates[tag] ? Color.Black : Color.White;
        }

        private void buttonSaveTrainSample_Click(object sender, EventArgs e)
        {
            this.SaveTrain(this.numericUpDownTest.Value, this._bStates);
        }

        private void buttonSaveTestSample_Click(object sender, EventArgs e)
        {
            this.SaveTest(this.numericUpDownTest.Value, this._bStates);
        }

        private void SaveTest(decimal value, bool[] input)
        {
            string pathDir = AppDomain.CurrentDomain.BaseDirectory;
            string nameFileTest = pathDir + "test.txt";

            string[] temp = new string[1];
            temp[0] = value.ToString() + " ";

            for (int i = 0; i < 15; i++)
            {
                temp[0] += input[i] ? "1" : "0";
            }

            File.AppendAllLines(nameFileTest, temp);
        }

        private void SaveTrain(decimal value, bool[] input)
        {
            string pathDir = AppDomain.CurrentDomain.BaseDirectory;
            string nameFileTrain = pathDir + "train.txt";

            string[] temp = new string[1];
            temp[0] = value.ToString() + " ";

            for (int i = 0; i < 15; i++)
            {
                temp[0] += input[i] ? "1" : "0";
            }

            File.AppendAllLines(nameFileTrain, temp);
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            this.net.Train(this.net);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
// LeakyRelu
//15-71-30-10