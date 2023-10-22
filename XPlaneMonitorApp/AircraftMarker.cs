using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace XPlaneMonitorApp
{
    public class AircraftMarker : GMarkerGoogle
    {

        public float Angle;

        public AircraftMarker(PointLatLng p, GMarkerGoogleType type) : base(p, type)
        {
        }

        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            float height = bmp.Height;
            float width = bmp.Width;
            int hypotenuse = Convert.ToInt32(Math.Floor(Math.Sqrt(height * height + width * width)));
            Bitmap rotatedImage = new Bitmap(hypotenuse, hypotenuse);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)rotatedImage.Width / 2, (float)rotatedImage.Height / 2); //set the rotation point as the center into the matrix
                g.RotateTransform(angle); //rotate
                g.TranslateTransform(-(float)rotatedImage.Width / 2, -(float)rotatedImage.Height / 2); //restore rotation point into the matrix
                g.DrawImage(bmp, (hypotenuse - width) / 2, (hypotenuse - height) / 2, width, height);
            }
            return rotatedImage;
        }

        public override void OnRender(Graphics g)
        {
            var img = RotateImage(Properties.Resources.black_plane, Angle);
            var w = img.Width;
            var h = img.Height;
            g.DrawImage(img, base.LocalPosition.X - (w / 5), base.LocalPosition.Y + (h / 5), w, h);
        }

    }
}
