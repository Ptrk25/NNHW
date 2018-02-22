namespace NNH
{
    partial class FrmMNISTLearn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblRemainingTitle = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblMNIST = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.DimGray;
            this.pnlMain.Controls.Add(this.lblRemainingTitle);
            this.pnlMain.Controls.Add(this.lblRemainingTime);
            this.pnlMain.Controls.Add(this.lblLoad);
            this.pnlMain.Controls.Add(this.pbProgress);
            this.pnlMain.Location = new System.Drawing.Point(0, 49);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(399, 153);
            this.pnlMain.TabIndex = 5;
            // 
            // lblRemainingTitle
            // 
            this.lblRemainingTitle.AutoSize = true;
            this.lblRemainingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTitle.ForeColor = System.Drawing.Color.White;
            this.lblRemainingTitle.Location = new System.Drawing.Point(7, 94);
            this.lblRemainingTitle.Name = "lblRemainingTitle";
            this.lblRemainingTitle.Size = new System.Drawing.Size(156, 20);
            this.lblRemainingTitle.TabIndex = 5;
            this.lblRemainingTitle.Text = "Verbleibende Zeit:";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTime.ForeColor = System.Drawing.Color.White;
            this.lblRemainingTime.Location = new System.Drawing.Point(169, 94);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(90, 20);
            this.lblRemainingTime.TabIndex = 4;
            this.lblRemainingTime.Text = "Berechne...";
            // 
            // lblLoad
            // 
            this.lblLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.ForeColor = System.Drawing.Color.White;
            this.lblLoad.Location = new System.Drawing.Point(3, 0);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(393, 114);
            this.lblLoad.TabIndex = 3;
            this.lblLoad.Text = "Netzwerk wird trainiert...";
            this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(7, 117);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(380, 23);
            this.pbProgress.Step = 1;
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 0;
            // 
            // lblMNIST
            // 
            this.lblMNIST.BackColor = System.Drawing.Color.Transparent;
            this.lblMNIST.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMNIST.ForeColor = System.Drawing.Color.White;
            this.lblMNIST.Location = new System.Drawing.Point(3, 2);
            this.lblMNIST.Name = "lblMNIST";
            this.lblMNIST.Size = new System.Drawing.Size(396, 44);
            this.lblMNIST.TabIndex = 6;
            this.lblMNIST.Text = "Neuronales Netzwerk";
            this.lblMNIST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMNISTLearn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(399, 202);
            this.Controls.Add(this.lblMNIST);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMNISTLearn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Neuronales Netzwerk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMNISTLearn_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblMNIST;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Label lblRemainingTitle;
    }
}