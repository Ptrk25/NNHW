﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

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

        private void oFDMNIST_FileOk(object sender, CancelEventArgs e)
        {
            //mnist_parser = new MNISTParser(oFDMNIST.FileName);
        }

        private void btnMNISTOpen_Click(object sender, EventArgs e)
        {
            /*
            oFDMNIST.ShowDialog();
            mnist_parser = new MNISTParser("C:/Users/Patrick/Downloads/train-images.idx3-ubyte", "C:/Users/Patrick/Downloads/train-labels.idx1-ubyte");
            mnist_parser.parseMNIST();
            */
        }
    }
}
