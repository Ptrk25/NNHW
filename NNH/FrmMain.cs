﻿using System;
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

        private List<Label> numPercentageLbl;

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

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            numPercentageLbl = new List<Label>();
            numPercentageLbl.Add(lblP0);
            numPercentageLbl.Add(lblP1);
            numPercentageLbl.Add(lblP2);
            numPercentageLbl.Add(lblP3);
            numPercentageLbl.Add(lblP4);
            numPercentageLbl.Add(lblP5);
            numPercentageLbl.Add(lblP6);
            numPercentageLbl.Add(lblP7);
            numPercentageLbl.Add(lblP8);
            numPercentageLbl.Add(lblP9);
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
                clearResults();
            }
        }

        private void btnNNLearn_Click(object sender, EventArgs e)
        {
            mNISTLearn = new FrmMNISTLearn();
            mNISTLearn.StartPosition = FormStartPosition.CenterParent;
            mNISTLearn.setMaxProgress(Int32.Parse(tbEinheit.Text));
            bwNNLearn.RunWorkerAsync();
            mNISTLearn.FormClosed += new FormClosedEventHandler(FormMNISTLearn_FormClosed);
            mNISTLearn.ShowDialog();
        }

        // Stop Learning if NN Learning was aborted
        private void FormMNISTLearn_FormClosed(object sender, FormClosedEventArgs e)
        {
            bwNNLearn.CancelAsync();
        }

        private void btnNNOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdNN = new OpenFileDialog();
            ofdNN.Filter = "Neuronales Netzwerk (*.nn)|*.nn";

            if(ofdNN.ShowDialog() == DialogResult.OK)
            {
                nn_parser = new NeuralNetworkParser();
                nn_parser.network.Load(ofdNN.FileName);
                lblSuccessCount.Text = Math.Round(calculateNNAccuracy() * 100, 2).ToString() + " %";
            }            
        }

        private void btnNNSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdNN = new SaveFileDialog();
            sfdNN.Filter = "Neuronales Netzwerk (*.nn)|*.nn";

            if(sfdNN.ShowDialog() == DialogResult.OK)
            {
                nn_parser.network.Save(sfdNN.FileName);
            }
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
                btnNNOpen.Enabled = true;
            });
        }

        private void bwNNLearn_DoWork(object sender, DoWorkEventArgs e)
        {
            bwNNLearn.WorkerReportsProgress = true;
            bwNNLearn.WorkerSupportsCancellation = true;

            nn_parser = new NeuralNetworkParser();
            int einheiten = Int32.Parse(tbEinheit.Text);
            int picsPerEinheit = Int32.Parse(tbPicPerEinheit.Text);
            float lr = float.Parse(tbLR.Text);

            for (int i = 0; i < einheiten; i++)
            {
                nn_parser.Train(mnist_parser.GetRndImages(picsPerEinheit), lr);
                bwNNLearn.ReportProgress(i+1);
                if (bwNNLearn.CancellationPending)
                {
                    e.Cancel = true;
                    Invoke((MethodInvoker)delegate
                    {
                        btnNNSave.Enabled = true;
                    });
                    return;
                }
            }

            float success_rate = calculateNNAccuracy();

            Invoke((MethodInvoker)delegate
            {
                mNISTLearn.Close();
                lblSuccessCount.Text = Math.Round(success_rate * 100, 2).ToString() + " %";
                lblGenCount.Text = einheiten.ToString();
                btnNNSave.Enabled = true;
            });
            
        }

        private float calculateNNAccuracy()
        {
            int success = 0;
            float maxnum = 0;
            int num = 0;
            //int[] nums = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] numsC = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            List<MNISTImage> imgList = mnist_parser.GetRndImages(1000);

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
                //nums[num]++;
                if (num == img.label)
                {
                    //numsC[num]++;
                    success++;
                }
            }
        
            return (float)success / (float)1000;
        }

        private void picBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            if(nn_parser != null)
                isMouseDown = true;
        }

        private void picBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                if (lastPoint != null)
                {

                    if (picBoxImage.Image == null)
                    {
                        Bitmap bmp = new Bitmap(picBoxImage.Width, picBoxImage.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        g.Clear(Color.White);

                        picBoxImage.Image = bmp; 
                    }

                    using (Graphics g = Graphics.FromImage(picBoxImage.Image))

                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        lastPoint.X -= 8;
                        lastPoint.Y -= 8;
                        //g.DrawLine(new Pen(Color.Black, 10), lastPoint, e.Location);
                        Rectangle rect = new Rectangle(lastPoint, new Size(16, 16));
                        Brush brush = new SolidBrush(Color.Black);
                        
                        g.DrawEllipse(new Pen(Color.Black, 1), rect);
                        g.FillEllipse(brush, rect);
                        
                    }
           
                    picBoxImage.Invalidate();
                    lastPoint = e.Location;
                }

            }
        }

        private void picBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = Point.Empty;
            isMouseDown = false;

            if(nn_parser != null && picBoxImage.Image != null)
            {
                ImageProcessor imageProcessor = new ImageProcessor();
                Bitmap drawnPic = imageProcessor.processImage(new Bitmap(picBoxImage.Image));
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

        private void bwNNLearn_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mNISTLearn.updateProgress(e.ProgressPercentage);
        }

        private void outputResults(Matrix<float> result)
        {
            List<double> percentages = new List<double>();

            for (int i = 0; i < 10; i++)
                percentages.Add(Math.Round(result[i, 0] * 100, 2));

            for (int i = 0; i < 10; i++)
            {
                numPercentageLbl[i].Text = String.Format("{0:0.00} %", percentages[i]);
                numPercentageLbl[i].BackColor = Color.FromArgb(255, 255 - Convert.ToInt32(255 * percentages[i] / 100), 255, 255 - Convert.ToInt32(255 * percentages[i] / 100));
            }   
        }

        private void clearResults()
        {
            foreach (Label lbl in numPercentageLbl)
            {
                lbl.Text = "0,00 %";
                lbl.BackColor = Color.Transparent;
            }
        }

    }
}
