using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ScreenShot
{
    public class FileFormatData
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string MymeType { get; set; }
        public ImageFormat ImageFormat { get; set; }
    }

    public class ScreenShot
    {
        public static List<FileFormatData> FileFormatList = new List<FileFormatData> 
        { 
            new FileFormatData { Name = "jpeg", Extension = ".jpg", MymeType = "", ImageFormat = ImageFormat.Jpeg },
            new FileFormatData { Name = "png", Extension = ".png", MymeType = "", ImageFormat = ImageFormat.Png },
            new FileFormatData { Name = "gif", Extension = ".gif", MymeType = "", ImageFormat = ImageFormat.Gif },
            new FileFormatData { Name = "bmp", Extension = ".bmp", MymeType = "", ImageFormat = ImageFormat.Bmp },
            new FileFormatData { Name = "tiff", Extension = ".tiff", MymeType = "", ImageFormat = ImageFormat.Tiff }
        };

        public static void CaptureImage(
            Point sourcePoint,
            Point destinationPoint,
            string filePath,
            Rectangle selectionRectangle,
            int fileFormatIndex = 0,
            bool isResize = true,
            int newHeight = 576)
        {
            using (Bitmap bitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(sourcePoint, destinationPoint, selectionRectangle.Size);
                }

                SaveImage(bitmap, filePath, fileFormatIndex, isResize, newHeight);
            }
        }

        private static void SaveImage(
            Bitmap bitmapsource,
            string filePath,
            int fileFormatIndex = 0,
            bool isResize = true,
            int newHeight = 576)
        {
            Bitmap bitmap = bitmapsource;
            ImageFormat imageFormat = ScreenShot.FileFormatList[fileFormatIndex].ImageFormat;

            if (isResize)
            {
                bitmap = ResizeImage(bitmap, newHeight);
            }

            bitmap.Save(filePath, imageFormat);

            bitmap.Dispose();
        }

        private static Bitmap ResizeImage(Bitmap bitmapsource, int newHeight = 576)
        {
            int width = bitmapsource.Width;
            int height = bitmapsource.Height;
            decimal ratio = newHeight / (decimal)height;
            int newWidth = (int)(width * ratio);

            Bitmap bitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(bitmapsource, 0, 0, newWidth, newHeight);
            g.Dispose();

            return bitmap;
        }
    }
}
