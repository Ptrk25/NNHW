using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NNH
{
    public partial class FrmMNISTLearn : Form
    {
        private int startTime, endTime, remainProgress;
        private Stopwatch stopwatch;

        public FrmMNISTLearn()
        {
            InitializeComponent();
        }

        public void updateProgress(int progress)
        {
            pbProgress.Value = progress;
            remainProgress++;
            if(remainProgress == 500)
            {
                remainProgress = 0;
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                double remainingTime = ((pbProgress.Maximum - progress) / 500) * ts.TotalMilliseconds;
                TimeSpan remainingTS = TimeSpan.FromMilliseconds(remainingTime);

                lblRemainingTime.Text = remainingTS.ToString(@"hh\:mm\:ss");
                stopwatch.Restart();
            }
        }

        public void setMaxProgress(int maxProg)
        {
            pbProgress.Maximum = maxProg;
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void pbProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
