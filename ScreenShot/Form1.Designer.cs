namespace ScreenShot
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.ddFileformat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.btnShowFolder = new System.Windows.Forms.Button();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.screenshotTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblCreatedImages = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLastFileName = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(395, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(395, 38);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interval (ms):";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(131, 15);
            this.maskedTextBox1.Mask = "999990";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.Text = "5000";
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // ddFileformat
            // 
            this.ddFileformat.FormattingEnabled = true;
            this.ddFileformat.Location = new System.Drawing.Point(131, 43);
            this.ddFileformat.Name = "ddFileformat";
            this.ddFileformat.Size = new System.Drawing.Size(100, 21);
            this.ddFileformat.TabIndex = 4;
            this.ddFileformat.SelectedIndexChanged += new System.EventHandler(this.ddFileformat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File format:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Directory:";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(131, 78);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(266, 20);
            this.txtFolderName.TabIndex = 7;
            this.txtFolderName.TextChanged += new System.EventHandler(this.txtFolderName_TextChanged);
            // 
            // btnShowFolder
            // 
            this.btnShowFolder.Location = new System.Drawing.Point(403, 78);
            this.btnShowFolder.Name = "btnShowFolder";
            this.btnShowFolder.Size = new System.Drawing.Size(28, 23);
            this.btnShowFolder.TabIndex = 8;
            this.btnShowFolder.Text = "...";
            this.btnShowFolder.UseVisualStyleBackColor = true;
            this.btnShowFolder.Click += new System.EventHandler(this.btnShowFolder_Click);
            // 
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Checked = true;
            this.chkSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubFolder.Location = new System.Drawing.Point(131, 116);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(145, 17);
            this.chkSubFolder.TabIndex = 9;
            this.chkSubFolder.Text = "Create Subfolder as Date";
            this.chkSubFolder.UseVisualStyleBackColor = true;
            this.chkSubFolder.CheckedChanged += new System.EventHandler(this.chkSubFolder_CheckedChanged);
            // 
            // screenshotTimer
            // 
            this.screenshotTimer.Tick += new System.EventHandler(this.screenshotTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Created images:";
            // 
            // lblCreatedImages
            // 
            this.lblCreatedImages.AutoSize = true;
            this.lblCreatedImages.Location = new System.Drawing.Point(128, 157);
            this.lblCreatedImages.Name = "lblCreatedImages";
            this.lblCreatedImages.Size = new System.Drawing.Size(10, 13);
            this.lblCreatedImages.TabIndex = 11;
            this.lblCreatedImages.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Last filename:";
            // 
            // lblLastFileName
            // 
            this.lblLastFileName.AutoSize = true;
            this.lblLastFileName.Location = new System.Drawing.Point(128, 181);
            this.lblLastFileName.MaximumSize = new System.Drawing.Size(266, 0);
            this.lblLastFileName.MinimumSize = new System.Drawing.Size(266, 0);
            this.lblLastFileName.Name = "lblLastFileName";
            this.lblLastFileName.Size = new System.Drawing.Size(266, 13);
            this.lblLastFileName.TabIndex = 13;
            this.lblLastFileName.Text = " ";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(395, 168);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 14;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 203);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.lblLastFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCreatedImages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSubFolder);
            this.Controls.Add(this.btnShowFolder);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddFileformat);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox ddFileformat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Button btnShowFolder;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.Timer screenshotTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCreatedImages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLastFileName;
        private System.Windows.Forms.Button btnCapture;
    }
}

