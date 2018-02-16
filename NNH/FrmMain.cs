using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using MathNet.Numerics.LinearAlgebra;

namespace NNH
{
    public partial class FrmMain : Form, IMessageFilter
    {
        // Notwendige Variablen zum verschieben des Fensters
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private MNISTParser mnist_parser;

        private NeuralNetwork nn;

        public FrmMain()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            controlsToMove.Add(this);
            controlsToMove.Add(this.pnlTitlebar);

        }

        // Fensterverschiebungscode
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
            controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            nn = new NeuralNetwork();
            List<int> layers = new List<int> { 3, 2 };
            nn.Init(layers);

            float[] vals = new[] { 3.0f, 2.0f, 1.0f };
            Matrix<float> input = CreateMatrix.Dense<float>(3, 1, vals);

            float[] dout = new[] { 1.0f, 0.0f };
            Matrix<float> doutput = CreateMatrix.Dense<float>(2, 1, dout);

            Matrix<float> result = nn.FeedForward(input);
            lblP0.Text = result[0, 0].ToString();
            lblP1.Text = result[1, 0].ToString();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oFDMNIST_FileOk(object sender, CancelEventArgs e)
        {
            //mnist_parser = new MNISTParser(oFDMNIST.FileName);
        }

        private void btnMNISTOpen_Click(object sender, EventArgs e)
        {

            /*float[] vals = new[] { 3.0f, 2.0f, 1.0f };
            Matrix<float> input = CreateMatrix.Dense<float>(3, 1, vals);

            float[] dout = new[] { 1.0f, 0.0f };
            Matrix<float> doutput = CreateMatrix.Dense<float>(2, 1, dout);

            List<TrainingData> data = new List<TrainingData>();
            data.Add(new TrainingData(input, doutput));

            nn.TrainingEpoch(data, 0.1f);

            Matrix<float> result = nn.FeedForward(input);
            lblP0.Text = result[0, 0].ToString();
            lblP1.Text = result[1, 0].ToString();*/

            
            oFDMNIST.ShowDialog();
            mnist_parser = new MNISTParser("C:/Users/Patrick/Downloads/train-images.idx3-ubyte", "C:/Users/Patrick/Downloads/train-labels.idx1-ubyte");
            mnist_parser.parseMNIST();

            NeuralNetworkHandler nnhandler = new NeuralNetworkHandler();
            nnhandler.Train(mnist_parser.get100RndImages());
            
        }

        private void btnImgDelete_Click(object sender, EventArgs e)
        {

        }

        private void pnlTitlebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
