﻿namespace NNH
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlMNIST = new System.Windows.Forms.Panel();
            this.lblEntriesCount = new System.Windows.Forms.Label();
            this.lblSizeCount = new System.Windows.Forms.Label();
            this.lblEntries = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.pnlMNISTHeader = new System.Windows.Forms.Panel();
            this.lblMNIST = new System.Windows.Forms.Label();
            this.pnlNN = new System.Windows.Forms.Panel();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.lblGenCount = new System.Windows.Forms.Label();
            this.btnNNLearn = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.pnlNNHeader = new System.Windows.Forms.Panel();
            this.lblNN = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRecognizedNum = new System.Windows.Forms.Panel();
            this.pnlRegocnizedNumHeader = new System.Windows.Forms.Panel();
            this.lblRecognizedNum = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.pnlImgHeader = new System.Windows.Forms.Panel();
            this.lblImage = new System.Windows.Forms.Label();
            this.pnlNNStatistic = new System.Windows.Forms.Panel();
            this.picBoxArrow = new System.Windows.Forms.PictureBox();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.btnMNISTOpen = new System.Windows.Forms.Button();
            this.btnNNSave = new System.Windows.Forms.Button();
            this.btnNNOpen = new System.Windows.Forms.Button();
            this.picBoxIcon = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTitlebar.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlMNIST.SuspendLayout();
            this.pnlMNISTHeader.SuspendLayout();
            this.pnlNN.SuspendLayout();
            this.pnlNNHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlRecognizedNum.SuspendLayout();
            this.pnlRegocnizedNumHeader.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.pnlImgHeader.SuspendLayout();
            this.pnlNNStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTitlebar.Controls.Add(this.picBoxIcon);
            this.pnlTitlebar.Controls.Add(this.lblTitle);
            this.pnlTitlebar.Controls.Add(this.btnMinimize);
            this.pnlTitlebar.Controls.Add(this.btnClose);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(850, 47);
            this.pnlTitlebar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(54, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Handschrifterkennung";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.DimGray;
            this.pnlOptions.Controls.Add(this.pnlMNIST);
            this.pnlOptions.Controls.Add(this.pnlMNISTHeader);
            this.pnlOptions.Controls.Add(this.pnlNN);
            this.pnlOptions.Controls.Add(this.pnlNNHeader);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOptions.Location = new System.Drawing.Point(0, 47);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(200, 530);
            this.pnlOptions.TabIndex = 2;
            // 
            // pnlMNIST
            // 
            this.pnlMNIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(218)))), ((int)(((byte)(166)))));
            this.pnlMNIST.Controls.Add(this.lblEntriesCount);
            this.pnlMNIST.Controls.Add(this.lblSizeCount);
            this.pnlMNIST.Controls.Add(this.lblEntries);
            this.pnlMNIST.Controls.Add(this.lblSize);
            this.pnlMNIST.Controls.Add(this.btnMNISTOpen);
            this.pnlMNIST.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMNIST.Location = new System.Drawing.Point(0, 306);
            this.pnlMNIST.Name = "pnlMNIST";
            this.pnlMNIST.Size = new System.Drawing.Size(200, 224);
            this.pnlMNIST.TabIndex = 3;
            // 
            // lblEntriesCount
            // 
            this.lblEntriesCount.AutoSize = true;
            this.lblEntriesCount.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntriesCount.Location = new System.Drawing.Point(14, 91);
            this.lblEntriesCount.Name = "lblEntriesCount";
            this.lblEntriesCount.Size = new System.Drawing.Size(18, 20);
            this.lblEntriesCount.TabIndex = 11;
            this.lblEntriesCount.Text = "0";
            // 
            // lblSizeCount
            // 
            this.lblSizeCount.AutoSize = true;
            this.lblSizeCount.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeCount.Location = new System.Drawing.Point(14, 40);
            this.lblSizeCount.Name = "lblSizeCount";
            this.lblSizeCount.Size = new System.Drawing.Size(46, 20);
            this.lblSizeCount.TabIndex = 10;
            this.lblSizeCount.Text = "0 MB";
            // 
            // lblEntries
            // 
            this.lblEntries.AutoSize = true;
            this.lblEntries.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntries.ForeColor = System.Drawing.Color.Black;
            this.lblEntries.Location = new System.Drawing.Point(8, 71);
            this.lblEntries.Name = "lblEntries";
            this.lblEntries.Size = new System.Drawing.Size(69, 20);
            this.lblEntries.TabIndex = 9;
            this.lblEntries.Text = "Einträge";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(8, 20);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(57, 20);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Größe";
            // 
            // pnlMNISTHeader
            // 
            this.pnlMNISTHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(175)))), ((int)(((byte)(123)))));
            this.pnlMNISTHeader.Controls.Add(this.lblMNIST);
            this.pnlMNISTHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMNISTHeader.Location = new System.Drawing.Point(0, 257);
            this.pnlMNISTHeader.Name = "pnlMNISTHeader";
            this.pnlMNISTHeader.Size = new System.Drawing.Size(200, 49);
            this.pnlMNISTHeader.TabIndex = 3;
            // 
            // lblMNIST
            // 
            this.lblMNIST.AutoSize = true;
            this.lblMNIST.Font = new System.Drawing.Font("Lato", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMNIST.ForeColor = System.Drawing.Color.White;
            this.lblMNIST.Location = new System.Drawing.Point(24, 15);
            this.lblMNIST.Name = "lblMNIST";
            this.lblMNIST.Size = new System.Drawing.Size(152, 21);
            this.lblMNIST.TabIndex = 1;
            this.lblMNIST.Text = "MNIST Datenbank";
            // 
            // pnlNN
            // 
            this.pnlNN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(163)))), ((int)(((byte)(219)))));
            this.pnlNN.Controls.Add(this.lblErrorCount);
            this.pnlNN.Controls.Add(this.lblGenCount);
            this.pnlNN.Controls.Add(this.btnNNSave);
            this.pnlNN.Controls.Add(this.btnNNOpen);
            this.pnlNN.Controls.Add(this.lblError);
            this.pnlNN.Controls.Add(this.lblGen);
            this.pnlNN.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNN.Location = new System.Drawing.Point(0, 49);
            this.pnlNN.Name = "pnlNN";
            this.pnlNN.Size = new System.Drawing.Size(200, 208);
            this.pnlNN.TabIndex = 2;
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCount.Location = new System.Drawing.Point(14, 88);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(34, 20);
            this.lblErrorCount.TabIndex = 6;
            this.lblErrorCount.Text = "0 %";
            // 
            // lblGenCount
            // 
            this.lblGenCount.AutoSize = true;
            this.lblGenCount.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenCount.Location = new System.Drawing.Point(14, 35);
            this.lblGenCount.Name = "lblGenCount";
            this.lblGenCount.Size = new System.Drawing.Size(18, 20);
            this.lblGenCount.TabIndex = 5;
            this.lblGenCount.Text = "0";
            // 
            // btnNNLearn
            // 
            this.btnNNLearn.BackColor = System.Drawing.Color.DimGray;
            this.btnNNLearn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNNLearn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNNLearn.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNNLearn.ForeColor = System.Drawing.Color.White;
            this.btnNNLearn.Location = new System.Drawing.Point(3, 207);
            this.btnNNLearn.Name = "btnNNLearn";
            this.btnNNLearn.Size = new System.Drawing.Size(170, 32);
            this.btnNNLearn.TabIndex = 3;
            this.btnNNLearn.Text = "Lernen";
            this.btnNNLearn.UseVisualStyleBackColor = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(8, 68);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(98, 20);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "Fehlerquote";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGen.ForeColor = System.Drawing.Color.Black;
            this.lblGen.Location = new System.Drawing.Point(8, 15);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(91, 20);
            this.lblGen.TabIndex = 0;
            this.lblGen.Text = "Generation";
            // 
            // pnlNNHeader
            // 
            this.pnlNNHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(207)))));
            this.pnlNNHeader.Controls.Add(this.lblNN);
            this.pnlNNHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNNHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlNNHeader.Name = "pnlNNHeader";
            this.pnlNNHeader.Size = new System.Drawing.Size(200, 49);
            this.pnlNNHeader.TabIndex = 1;
            // 
            // lblNN
            // 
            this.lblNN.AutoSize = true;
            this.lblNN.Font = new System.Drawing.Font("Lato", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNN.ForeColor = System.Drawing.Color.White;
            this.lblNN.Location = new System.Drawing.Point(11, 13);
            this.lblNN.Name = "lblNN";
            this.lblNN.Size = new System.Drawing.Size(177, 21);
            this.lblNN.TabIndex = 0;
            this.lblNN.Text = "Neuronales Netzwerk";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Gray;
            this.pnlMain.Controls.Add(this.picBoxArrow);
            this.pnlMain.Controls.Add(this.pnlRecognizedNum);
            this.pnlMain.Controls.Add(this.pnlImage);
            this.pnlMain.Controls.Add(this.pnlNNStatistic);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 47);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(650, 530);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlRecognizedNum
            // 
            this.pnlRecognizedNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecognizedNum.Controls.Add(this.pnlRegocnizedNumHeader);
            this.pnlRecognizedNum.Location = new System.Drawing.Point(417, 272);
            this.pnlRecognizedNum.Name = "pnlRecognizedNum";
            this.pnlRecognizedNum.Size = new System.Drawing.Size(221, 246);
            this.pnlRecognizedNum.TabIndex = 2;
            // 
            // pnlRegocnizedNumHeader
            // 
            this.pnlRegocnizedNumHeader.Controls.Add(this.lblRecognizedNum);
            this.pnlRegocnizedNumHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegocnizedNumHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlRegocnizedNumHeader.Name = "pnlRegocnizedNumHeader";
            this.pnlRegocnizedNumHeader.Size = new System.Drawing.Size(219, 49);
            this.pnlRegocnizedNumHeader.TabIndex = 0;
            // 
            // lblRecognizedNum
            // 
            this.lblRecognizedNum.AutoSize = true;
            this.lblRecognizedNum.Font = new System.Drawing.Font("Lato", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecognizedNum.ForeColor = System.Drawing.Color.White;
            this.lblRecognizedNum.Location = new System.Drawing.Point(53, 15);
            this.lblRecognizedNum.Name = "lblRecognizedNum";
            this.lblRecognizedNum.Size = new System.Drawing.Size(118, 21);
            this.lblRecognizedNum.TabIndex = 2;
            this.lblRecognizedNum.Text = "Erkannte Zahl";
            // 
            // pnlImage
            // 
            this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImage.Controls.Add(this.picBoxImage);
            this.pnlImage.Controls.Add(this.pnlImgHeader);
            this.pnlImage.Location = new System.Drawing.Point(15, 273);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(221, 245);
            this.pnlImage.TabIndex = 1;
            // 
            // pnlImgHeader
            // 
            this.pnlImgHeader.Controls.Add(this.lblImage);
            this.pnlImgHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImgHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlImgHeader.Name = "pnlImgHeader";
            this.pnlImgHeader.Size = new System.Drawing.Size(219, 49);
            this.pnlImgHeader.TabIndex = 0;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Lato", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.ForeColor = System.Drawing.Color.White;
            this.lblImage.Location = new System.Drawing.Point(85, 14);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(40, 21);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "Bild";
            // 
            // pnlNNStatistic
            // 
            this.pnlNNStatistic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNNStatistic.Controls.Add(this.btnNNLearn);
            this.pnlNNStatistic.Location = new System.Drawing.Point(15, 13);
            this.pnlNNStatistic.Name = "pnlNNStatistic";
            this.pnlNNStatistic.Size = new System.Drawing.Size(623, 244);
            this.pnlNNStatistic.TabIndex = 0;
            // 
            // picBoxArrow
            // 
            this.picBoxArrow.Image = global::NNH.Properties.Resources.Right_Arrow_96px;
            this.picBoxArrow.Location = new System.Drawing.Point(279, 357);
            this.picBoxArrow.Name = "picBoxArrow";
            this.picBoxArrow.Size = new System.Drawing.Size(94, 95);
            this.picBoxArrow.TabIndex = 3;
            this.picBoxArrow.TabStop = false;
            // 
            // picBoxImage
            // 
            this.picBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxImage.Location = new System.Drawing.Point(0, 49);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(219, 194);
            this.picBoxImage.TabIndex = 1;
            this.picBoxImage.TabStop = false;
            // 
            // btnMNISTOpen
            // 
            this.btnMNISTOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnMNISTOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMNISTOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMNISTOpen.FlatAppearance.BorderSize = 0;
            this.btnMNISTOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMNISTOpen.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMNISTOpen.ForeColor = System.Drawing.Color.White;
            this.btnMNISTOpen.Image = global::NNH.Properties.Resources.icons8_Open_32;
            this.btnMNISTOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMNISTOpen.Location = new System.Drawing.Point(0, 188);
            this.btnMNISTOpen.Name = "btnMNISTOpen";
            this.btnMNISTOpen.Size = new System.Drawing.Size(200, 36);
            this.btnMNISTOpen.TabIndex = 7;
            this.btnMNISTOpen.Text = "Öffnen";
            this.btnMNISTOpen.UseVisualStyleBackColor = false;
            // 
            // btnNNSave
            // 
            this.btnNNSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(207)))));
            this.btnNNSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNNSave.FlatAppearance.BorderSize = 0;
            this.btnNNSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNNSave.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNNSave.ForeColor = System.Drawing.Color.White;
            this.btnNNSave.Image = global::NNH.Properties.Resources.icons8_Save_32;
            this.btnNNSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNNSave.Location = new System.Drawing.Point(94, 172);
            this.btnNNSave.Name = "btnNNSave";
            this.btnNNSave.Size = new System.Drawing.Size(105, 36);
            this.btnNNSave.TabIndex = 4;
            this.btnNNSave.Text = "Speichern";
            this.btnNNSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNNSave.UseVisualStyleBackColor = false;
            // 
            // btnNNOpen
            // 
            this.btnNNOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(207)))));
            this.btnNNOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNNOpen.FlatAppearance.BorderSize = 0;
            this.btnNNOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNNOpen.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNNOpen.ForeColor = System.Drawing.Color.White;
            this.btnNNOpen.Image = global::NNH.Properties.Resources.icons8_Open_32;
            this.btnNNOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNNOpen.Location = new System.Drawing.Point(0, 172);
            this.btnNNOpen.Name = "btnNNOpen";
            this.btnNNOpen.Size = new System.Drawing.Size(99, 36);
            this.btnNNOpen.TabIndex = 2;
            this.btnNNOpen.Text = "          Öffnen";
            this.btnNNOpen.UseVisualStyleBackColor = false;
            // 
            // picBoxIcon
            // 
            this.picBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBoxIcon.Image = global::NNH.Properties.Resources.icons8_Hand_With_Pen_32;
            this.picBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.picBoxIcon.Name = "picBoxIcon";
            this.picBoxIcon.Size = new System.Drawing.Size(48, 47);
            this.picBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxIcon.TabIndex = 3;
            this.picBoxIcon.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::NNH.Properties.Resources.icons8_Minimize_Window_32;
            this.btnMinimize.Location = new System.Drawing.Point(757, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 47);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::NNH.Properties.Resources.icons8_Close_Window_32;
            this.btnClose.Location = new System.Drawing.Point(802, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 47);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 577);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Handschrifterkennung";
            this.pnlTitlebar.ResumeLayout(false);
            this.pnlTitlebar.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlMNIST.ResumeLayout(false);
            this.pnlMNIST.PerformLayout();
            this.pnlMNISTHeader.ResumeLayout(false);
            this.pnlMNISTHeader.PerformLayout();
            this.pnlNN.ResumeLayout(false);
            this.pnlNN.PerformLayout();
            this.pnlNNHeader.ResumeLayout(false);
            this.pnlNNHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlRecognizedNum.ResumeLayout(false);
            this.pnlRegocnizedNumHeader.ResumeLayout(false);
            this.pnlRegocnizedNumHeader.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            this.pnlImgHeader.ResumeLayout(false);
            this.pnlImgHeader.PerformLayout();
            this.pnlNNStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTitlebar;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlMNIST;
        private System.Windows.Forms.Panel pnlMNISTHeader;
        private System.Windows.Forms.Label lblMNIST;
        private System.Windows.Forms.Panel pnlNN;
        private System.Windows.Forms.Button btnNNSave;
        private System.Windows.Forms.Button btnNNLearn;
        private System.Windows.Forms.Button btnNNOpen;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Panel pnlNNHeader;
        private System.Windows.Forms.Label lblNN;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblGenCount;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.Label lblEntriesCount;
        private System.Windows.Forms.Label lblSizeCount;
        private System.Windows.Forms.Label lblEntries;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnMNISTOpen;
        private System.Windows.Forms.PictureBox picBoxArrow;
        private System.Windows.Forms.Panel pnlRecognizedNum;
        private System.Windows.Forms.Panel pnlRegocnizedNumHeader;
        private System.Windows.Forms.Label lblRecognizedNum;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Panel pnlImgHeader;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Panel pnlNNStatistic;
        private System.Windows.Forms.PictureBox picBoxIcon;
    }
}

