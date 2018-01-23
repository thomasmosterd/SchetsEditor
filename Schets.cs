using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SchetsEditor
{
    public class Schets
    {
        private Bitmap bitmap;
        
        public Schets()
        {
            bitmap = new Bitmap(1, 1);
        }
        public void opslaan1(string FileName, int format = 1)
        {
            ImageFormat SaveType;
            if (format == 1) { SaveType = ImageFormat.Png; }
            if (format == 2) { SaveType = ImageFormat.Jpeg; }
            if (format == 3) { SaveType = ImageFormat.Bmp; }
            else { SaveType = ImageFormat.Png; }
            bitmap.Save(FileName, SaveType);

        }
        public Graphics BitmapGraphics
        {
            get { return Graphics.FromImage(bitmap); }
        }
        public void VeranderAfmeting(Size sz)
        {
            if (sz.Width > bitmap.Size.Width || sz.Height > bitmap.Size.Height)
            {
                Bitmap nieuw = new Bitmap( Math.Max(sz.Width,  bitmap.Size.Width)
                                         , Math.Max(sz.Height, bitmap.Size.Height)
                                         );
                Graphics gr = Graphics.FromImage(nieuw);
                gr.FillRectangle(Brushes.White, 0, 0, sz.Width, sz.Height);
                gr.DrawImage(bitmap, 0, 0);
                bitmap = nieuw;
            }
        }
        public void Teken(Graphics gr)
        {
            gr.DrawImage(bitmap, 0, 0);
        }
        public void Schoon()
        {
            Graphics gr = Graphics.FromImage(bitmap);
            gr.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
        }
        public void Roteer()
        {
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
    }
}
