using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Tamplate_1.Models
{
    public class ImageModel
    {
         
        /// <summary>
        /// method to return tow uniqe direction for pc and phone image
        /// </summary>
        /// <param name="FileName">the name of image</param>
        /// <param name="SectionName">the name of section folder</param>
        /// <returns>ScsPc for pc and ScsPh for phone</returns>
        public Tuple<string, string> SaveImage(string FileName, string SectionName)
        {
            var s = @FileName;
            var r = s.Substring(s.IndexOf(@".") + 1);
            string direct = SectionName + "/" + SectionName + Guid.NewGuid() + "." + r;
            string ScsPc = "Images/" + direct;
            string ScsPh = "Mobile/Images/" + direct;
            return Tuple.Create(ScsPc, ScsPh);
        }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, string SectionName)
        {
            int newWidth = 0;
            int newHeight = 0;


            int originalWidth = image.Width;
            int originalHeight = image.Height;
            if (SectionName=="headre")
            {
                 newWidth = Convert.ToInt32(originalWidth);
            newHeight = Convert.ToInt32(originalHeight);
            }
            else {
            newWidth = Convert.ToInt32(originalWidth / 3);
            newHeight = Convert.ToInt32(originalHeight / 3);
            }


            System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

    }
}