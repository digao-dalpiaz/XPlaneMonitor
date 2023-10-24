namespace XPlaneMonitorApp.Functions
{
    public class Drawing
    {

        public static void DrawLine(Graphics g, Pen pen, double x1, double y1, double x2, double y2)
        {
            g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public static void DrawImage(Graphics g, Image img, double x, double y)
        {
            g.DrawImage(img, (float)x, (float)y, img.Width, img.Height);
        }

        public static void FillRectangle(Graphics g, Brush brush, double x, double y, double w, double h)
        {
            g.FillRectangle(brush, (float)x, (float)y, (float)w, (float)h);
        }

        public static void DrawString(Graphics g, string text, Font font, Brush brush, double x, double y)
        {
            g.DrawString(text, font, brush, (float)x, (float)y);
        }

        public static Bitmap RotateImage(Bitmap bmp, double angle)
        {
            float height = bmp.Height;
            float width = bmp.Width;
            int hypotenuse = Convert.ToInt32(Math.Floor(Math.Sqrt(Math.Pow(height, 2) + Math.Pow(width, 2))));
            Bitmap rotatedImage = new Bitmap(hypotenuse, hypotenuse);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)rotatedImage.Width / 2, (float)rotatedImage.Height / 2); //set the rotation point as the center into the matrix
                g.RotateTransform((float)angle); //rotate
                g.TranslateTransform(-(float)rotatedImage.Width / 2, -(float)rotatedImage.Height / 2); //restore rotation point into the matrix
                g.DrawImage(bmp, (hypotenuse - width) / 2, (hypotenuse - height) / 2, width, height);
            }
            return rotatedImage;
        }

    }
}
