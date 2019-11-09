using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ScreenShot
{
    public partial class Form1 : Form
    {
        #region declaration
        private int fileNameCnt = 1;
        private int fileFormatIndex = 0;
        private int createdImages = 0;
        private Options options;
        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();

            this.InitOptions();

            foreach (FileFormatData d in ScreenShot.FileFormatList)
            {
                ddFileformat.Items.Add(d.Name);
                if (d.Name == this.options.FileFormat)
                {
                    ddFileformat.SelectedIndex = ddFileformat.Items.Count - 1;
                    this.fileFormatIndex = ddFileformat.SelectedIndex;
                }
            }

            txtFolderName.Text = this.options.Destination;

            this.SetDirectory(isCheckFiles: true, isCreateDirectory: false);
            this.SetInterval();
        }
        #endregion

        #region init
        private void InitOptions()
        {
            try
            {
                string filepath = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "Options.xml");
                string xml = File.ReadAllText(filepath);
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(xml);
                XmlSerializer xs = new XmlSerializer(typeof(Options));
                MemoryStream stream = new MemoryStream(bytes);

                this.options = (Options)xs.Deserialize(stream);
            }
            catch (Exception)
            {
                this.options = new Options();
            }

            this.options.InitComponent();

            if (String.IsNullOrWhiteSpace(this.options.Destination))
                this.options.Destination = Directory.GetCurrentDirectory();
        }
        #endregion

        #region capture
        private void CaptureScreen()
        {
            string filename = "";
            string fullname = "";
            string extension = ScreenShot.FileFormatList[this.fileFormatIndex].Extension;
            string path = this.options.Destination;
            DateTime time = DateTime.Now;
            Point startPoint;
            Rectangle bounds;

            if (chkSubFolder.Checked)
            {
                path = String.Format("{0}\\{1:yyyyMMdd}", path, time);
            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            filename = String.Format("{0:000000}_{1:yyyyMMdd}_{1:HHmmss}{2}", this.fileNameCnt, time, extension);
            fullname = String.Format("{0}\\{1}", path, filename);

            startPoint = new Point();

            bounds = Screen.PrimaryScreen.Bounds;
            ScreenShot.CaptureImage(startPoint, Point.Empty, fullname, bounds, this.fileFormatIndex);

            this.fileNameCnt++;
            this.createdImages++;

            lblLastFileName.Text = filename;
            lblCreatedImages.Text = String.Format("{0}", this.createdImages);
        }
        #endregion

        #region control events
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            btnCapture.Enabled = false;
            this.SetDirectory(isCreateDirectory: true);

            screenshotTimer.Enabled = true;
            screenshotTimer.Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            
            this.SetDirectory(isCheckFiles: false);
            this.CaptureScreen();

            this.Opacity = 1;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnCapture.Enabled = true;
            screenshotTimer.Enabled = false;
            screenshotTimer.Stop();
            this.createdImages = 0;
        }

        private void btnShowFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            this.options.Destination = folderBrowserDialog1.SelectedPath;
            txtFolderName.Text = this.options.Destination;
        }

        private void ddFileformat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fileFormatIndex = ddFileformat.SelectedIndex;
            this.options.FileFormat = ScreenShot.FileFormatList[this.fileFormatIndex].Name;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.SetInterval();
        }

        private void chkSubFolder_CheckedChanged(object sender, EventArgs e)
        {
            this.options.IsSubfolderEnabled = chkSubFolder.Checked;
            this.SetDirectory(isCheckFiles: true, isCreateDirectory: false);
        }

        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            this.SetDirectory(isCheckFiles: true, isCreateDirectory: false, isResetFileNames: true);
        }
        #endregion

        #region methods
        private void screenshotTimer_Tick(object sender, EventArgs e)
        {
            this.CaptureScreen();
        }

        private void SetInterval()
        {
            int interval = 250;
            bool restart = screenshotTimer.Enabled;

            Int32.TryParse(maskedTextBox1.Text, out interval);


            if (interval > 0)
            {
                this.options.Interval = interval;

                if (screenshotTimer.Enabled)
                {
                    screenshotTimer.Enabled = false;
                    screenshotTimer.Stop();
                }
                screenshotTimer.Interval = interval;

                if (restart)
                {
                    screenshotTimer.Enabled = true;
                    screenshotTimer.Start();
                }
            }
        }

        private void SetDirectory(bool isCheckFiles = true, bool isCreateDirectory = false, bool isResetFileNames = false)
        {
            int filesCnt = 0;
            string path = this.options.Destination;

            if (chkSubFolder.Checked)
            {
                path = String.Format("{0}\\{1:yyyyMMdd}", path, DateTime.Now);
            }

            if (isCreateDirectory)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            if (isCheckFiles)
            {
                string filter = String.Format("*{0}", ScreenShot.FileFormatList[this.fileFormatIndex].Extension);
                filesCnt = (Directory.Exists(path)) ? Directory.GetFiles(path, filter).Length : 0;

                if (isResetFileNames || (filesCnt > this.fileNameCnt))
                    this.fileNameCnt = filesCnt + 1;
            }
        }
        #endregion
    }
}
