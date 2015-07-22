using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

// required Ghostscript.NET namespaces
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;

namespace Pdf2Jpg
{
    public class ConvertPdf2Jpg
    {
        private GhostscriptVersionInfo _ghostScriptVersion = null;

        public void Start(String ghostScriptLibPath, String inputPdfPath, string outputFileName)
        {
            int target_x_dpi = 300;
            int target_y_dpi = 300;

            _ghostScriptVersion = new GhostscriptVersionInfo(new Version(0, 0, 0), ghostScriptLibPath, string.Empty, GhostscriptLicense.GPL);
            GhostscriptRasterizer rasterizer = new GhostscriptRasterizer();
            
            var width = 0;
            var height = 0;

            rasterizer.Open(inputPdfPath, _ghostScriptVersion, false);
            
            List<Bitmap> bmpList = new List<Bitmap>();

            // Get an image for each page in the pdf
            for (int pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
            {
                Image img = rasterizer.GetPage(target_x_dpi, target_y_dpi, pageNumber);
                if (img.Width > width)
                    width = img.Width;
                height += img.Height;


                Bitmap bmp = new Bitmap(img);
                Bitmap bmp2 = (Bitmap)bmp.Clone();
                bmpList.Add(bmp2);
            }


            // Add each image to the output bitmap, using canvas as the drawing vehicle 
            var bitmap = new Bitmap(width, height);
            var canvas = Graphics.FromImage(bitmap);
            var curHeight = 0;
            for (int i = 0; i < bmpList.Count; i++)
            {
                canvas.DrawImage(bmpList[i], new Point(0, curHeight));
                curHeight += bmpList[i].Height;
            }
            canvas.Save();

            // Save the output bitmap to file.
            bitmap.Save(outputFileName, ImageFormat.Jpeg);
        }
    }
}

