using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TDS2
{
    public static class ImageZoom
    {
        /// <summary>
        /// 等比缩放
        /// </summary>
        /// <param name="inImage">输入图片</param>
        /// <param name="OutHeight">输出高</param>
        /// <param name="OutWidth">输出宽</param>
        /// <returns>输出图片</returns>
        public static Image Zoom(Image inImage, int OutHeight, int OutWidth)
        {
            try
            {
                int width = 0, height = 0;
                // 按比例缩放
                int inWidth = inImage.Width;
                int inHeight = inImage.Height;
                if (inHeight > OutHeight || inWidth > OutWidth)
                {
                    if ((inWidth * OutHeight) > (inHeight * OutWidth))
                    {
                        width = OutWidth;
                        height = (OutWidth * inHeight) / inWidth;
                    }
                    else
                    {
                        height = OutHeight;
                        width = (inWidth * OutHeight) / inHeight;
                    }
                }
                else
                {
                    width = inWidth;
                    height = inHeight;
                }
                Bitmap outBitmap = new Bitmap(OutWidth, OutHeight);
                Graphics graphics = Graphics.FromImage(outBitmap);
                graphics.Clear(Color.Transparent);
                // 设置画布的描绘质量           
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(inImage, new Rectangle((OutWidth - width) / 2, (OutHeight - height) / 2, width, height), 0, 0, inImage.Width, inImage.Height, GraphicsUnit.Pixel);
                graphics.Dispose();
                // 设置压缩质量       
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                inImage.Dispose();
                return outBitmap;
            }
            catch
            {
                return inImage;
            }
        }
    }
}
