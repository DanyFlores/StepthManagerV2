using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephManager.ClasesAux
{
    public class ComprimirImagen
    {
        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight, ImageFormat Formato)
        {
            try
            {
                using (Bitmap imagenBitmap =
                   new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
                {
                    imagenBitmap.SetResolution(
                       Convert.ToInt32(srcImage.HorizontalResolution),
                       Convert.ToInt32(srcImage.HorizontalResolution));

                    using (Graphics imagenGraphics =
                            Graphics.FromImage(imagenBitmap))
                    {
                        imagenGraphics.SmoothingMode =
                           SmoothingMode.AntiAlias;
                        imagenGraphics.InterpolationMode =
                           InterpolationMode.HighQualityBicubic;
                        imagenGraphics.PixelOffsetMode =
                           PixelOffsetMode.HighQuality;
                        imagenGraphics.DrawImage(srcImage,
                           new Rectangle(0, 0, newWidth, newHeight),
                           new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                           GraphicsUnit.Pixel);
                        MemoryStream imagenMemoryStream = new MemoryStream();
                        imagenBitmap.Save(imagenMemoryStream, Formato);
                        srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                    }
                }
                return srcImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            try
            {
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newWidth * 100) / Width;
                newHeight = (int)(Heigth * (Porc / 100));
                ImageFormat Formato = ImageFormat.Jpeg;
                using (Bitmap imagenBitmap =
                   new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
                {
                    imagenBitmap.SetResolution(
                       Convert.ToInt32(srcImage.HorizontalResolution),
                       Convert.ToInt32(srcImage.HorizontalResolution));

                    using (Graphics imagenGraphics =
                            Graphics.FromImage(imagenBitmap))
                    {
                        imagenGraphics.SmoothingMode =
                           SmoothingMode.AntiAlias;
                        imagenGraphics.InterpolationMode =
                           InterpolationMode.HighQualityBicubic;
                        imagenGraphics.PixelOffsetMode =
                           PixelOffsetMode.HighQuality;
                        imagenGraphics.DrawImage(srcImage,
                           new Rectangle(0, 0, newWidth, newHeight),
                           new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                           GraphicsUnit.Pixel);
                        MemoryStream imagenMemoryStream = new MemoryStream();
                        imagenBitmap.Save(imagenMemoryStream, Formato);
                        srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                    }
                }
                return srcImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image ResizeImage2(Image srcImage, int newWidth, int newHeight)
        {
            try
            {
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newWidth * 100) / Width;
                newHeight = (int)(Heigth * (Porc / 100));
                Bitmap imagen = new Bitmap(srcImage);
                Bitmap nuevaImagen = new Bitmap(newWidth, newHeight);                
                Graphics gr = Graphics.FromImage(nuevaImagen);
                //DIBUJAMOS LA NUEVA IMAGEN
                gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);
                //LIBERAMOS RECURSOS
                gr.Dispose();
                return nuevaImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}