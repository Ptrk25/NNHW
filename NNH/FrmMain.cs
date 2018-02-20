using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private OpenFileDialog ofdLabels, ofdImages;
        private FrmMNISTOpen mNISTOpen;
        private FrmMNISTLearn mNISTLearn;
        private MNISTParser mnist_parser;
        private NeuralNetworkParser nn_parser;

        private Point lastPoint = Point.Empty;
        private bool isMouseDown = false;
        
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
            this.WindowState = FormWindowState.Minimized;  
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMNISTOpen_Click(object sender, EventArgs e)
        {
            ofdLabels = new OpenFileDialog();
            ofdImages = new OpenFileDialog();
            ofdLabels.Filter = "MNIST label file (*.idx1-ubyte)|*.idx1-ubyte";
            ofdImages.Filter = "MNIST images file (*.idx3-ubyte)|*.idx3-ubyte";

            if(ofdLabels.ShowDialog() == DialogResult.OK && ofdImages.ShowDialog() == DialogResult.OK)
            {

                mNISTOpen = new FrmMNISTOpen();
                mNISTOpen.StartPosition = FormStartPosition.CenterParent;
                bwLoadMNIST.RunWorkerAsync();
                mNISTOpen.ShowDialog(this);
               
            }
        }

        private void btnImgDelete_Click(object sender, EventArgs e)
        {
            if(picBoxImage.Image != null)
            {
                picBoxImage.Image = null;
                Invalidate();
                lblRecognizedNumBig.Text = "";

                lblP0.Text = "0,00 %";
                lblP1.Text = "0,00 %";
                lblP2.Text = "0,00 %";
                lblP3.Text = "0,00 %";
                lblP4.Text = "0,00 %";
                lblP5.Text = "0,00 %";
                lblP6.Text = "0,00 %";
                lblP7.Text = "0,00 %";
                lblP8.Text = "0,00 %";
                lblP9.Text = "0,00 %";
            }
        }

        private void btnNNOpen_Click(object sender, EventArgs e)
        {
  
            
        }

        private void btnNNSave_Click(object sender, EventArgs e)
        {
            
        }

        private void bwLoadMNIST_DoWork(object sender, DoWorkEventArgs e)
        {
            mnist_parser = new MNISTParser(ofdImages.FileName, ofdLabels.FileName);
            // Lese MNIST Lables ein
            if (!mnist_parser.parseLabels())
            {
                MessageBox.Show("Fehler", "Fehlerhafte Labeldatenbank!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Lese MNIST Bilder ein
            if (!mnist_parser.parseImages())
            {
                MessageBox.Show("Fehler", "Fehlerhafte Bilderdatenbank!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close Dialog + Set Labels
            Invoke((MethodInvoker)delegate
            {
                mNISTOpen.Close();
                lblEntriesCount.Text = mnist_parser.getEntriesCount().ToString();
                lblSizeCount.Text = mnist_parser.getSizeInMB().ToString() + " MB";
                btnNNLearn.Enabled = true;
            });
        }

        private void bwNNLearn_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MNISTImage> imgList = mnist_parser.GetRndImages(1000);
            nn_parser = new NeuralNetworkParser();
            int einheiten = Int32.Parse(tbEinheit.Text);
            int picsPerEinheit = Int32.Parse(tbPicPerEinheit.Text);
            float lr = float.Parse(tbLR.Text);

            for (int i = 0; i < einheiten; i++)
                nn_parser.Train(mnist_parser.GetRndImages(picsPerEinheit), lr);

            int success = 0;
            float maxnum = 0;
            int num = 0;
            int[] nums = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] numsC = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (MNISTImage img in imgList)
            {
                Matrix<float> result = nn_parser.FeedForward(img);

                for (int i = 0; i < 10; i++)
                {

                    if (result[i, 0] > maxnum)
                    {
                        maxnum = result[i, 0];
                        num = i;
                    }

                }
                maxnum = 0;
                nums[num]++;
                if (num == img.label)
                {
                    numsC[num]++;
                    success++;
                }
            }
            float success_rate = ((float)success / (float)imgList.Count);

            Invoke((MethodInvoker)delegate
            {
                mNISTLearn.Close();
                lblErrorCount.Text = (Math.Round(success_rate * 100, 2)).ToString() + " %";
                lblGenCount.Text = einheiten.ToString();
            });
            
        }

        private void btnNNLearn_Click(object sender, EventArgs e)
        {
            mNISTLearn = new FrmMNISTLearn();
            mNISTLearn.StartPosition = FormStartPosition.CenterParent;
            bwNNLearn.RunWorkerAsync();
            mNISTLearn.ShowDialog();

        }

        private void picBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            if(nn_parser != null)
                isMouseDown = true;
        }

        private void picBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)//check to see if the mouse button is down

            {

                if (lastPoint != null)//if our last point is not null, which in this case we have assigned above

                {

                    if (picBoxImage.Image == null)//if no available bitmap exists on the picturebox to draw on

                    {
                        //create a new bitmap
                        Bitmap bmp = new Bitmap(picBoxImage.Width, picBoxImage.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        g.Clear(Color.White);

                        picBoxImage.Image = bmp; //assign the picturebox.Image property to the bitmap created

                    }

                    using (Graphics g = Graphics.FromImage(picBoxImage.Image))

                    {//we need to create a Graphics object to draw on the picture box, its our main tool

                        //when making a Pen object, you can just give it color only or give it color and pen size

                        // g.DrawLine(new Pen(Color.Black, 10), lastPoint, e.Location);
                        Rectangle rect = new Rectangle(lastPoint, new Size(15, 15));
                        Brush brush = new SolidBrush(Color.Black);
                        g.DrawEllipse(new Pen(Color.Black, 2), rect);
                        g.FillEllipse(brush, rect);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        //this is to give the drawing a more smoother, less sharper look

                    }

                    picBoxImage.Invalidate();//refreshes the picturebox

                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position

                }

            }
        }

        private void picBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = Point.Empty;
            isMouseDown = false;

            if(nn_parser != null)
            {
                Bitmap drawnPic = new Bitmap(picBoxImage.Image, 28, 28);
                MNISTImage drawnImg = new MNISTImage(drawnPic);

                Matrix<float> result = nn_parser.FeedForward(drawnImg);

                drawnImg.getImageAsBitmap().Save("test.png");

                float maxnum = 0;
                int num = 0;

                for (int i = 0; i < 10; i++)
                {

                    if (result[i, 0] > maxnum)
                    {
                        maxnum = result[i, 0];
                        num = i;
                    }

                }

                lblRecognizedNumBig.Text = num.ToString();
                outputResults(result);
            }

        }

        private void outputResults(Matrix<float> result)
        {
            double p0 = Math.Round(result[0, 0] * 100, 2);
            double p1 = Math.Round(result[1, 0] * 100, 2);
            double p2 = Math.Round(result[2, 0] * 100, 2);
            double p3 = Math.Round(result[3, 0] * 100, 2);
            double p4 = Math.Round(result[4, 0] * 100, 2);
            double p5 = Math.Round(result[5, 0] * 100, 2);
            double p6 = Math.Round(result[6, 0] * 100, 2);
            double p7 = Math.Round(result[7, 0] * 100, 2);
            double p8 = Math.Round(result[8, 0] * 100, 2);
            double p9 = Math.Round(result[9, 0] * 100, 2);

            lblP0.Text = p0.ToString() + " %";
            lblP1.Text = p1.ToString() + " %";
            lblP2.Text = p2.ToString() + " %";
            lblP3.Text = p3.ToString() + " %";
            lblP4.Text = p4.ToString() + " %";
            lblP5.Text = p5.ToString() + " %";
            lblP6.Text = p6.ToString() + " %";
            lblP7.Text = p7.ToString() + " %";
            lblP8.Text = p8.ToString() + " %";
            lblP9.Text = p9.ToString() + " %";

            //lblP0.BackColor = Color.FromArgb(0, Convert.ToInt32(255*p0), Convert.ToInt32(255 * p0), Convert.ToInt32(255 * p0));
        }

    }
}
