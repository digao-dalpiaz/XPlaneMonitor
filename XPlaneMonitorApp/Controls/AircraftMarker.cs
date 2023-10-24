using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp.Controls
{
    public class AircraftMarker : GMarkerGoogle
    {

        public float Angle;

        public AircraftMarker(PointLatLng p, GMarkerGoogleType type) : base(p, type)
        {
        }

        public override void OnRender(Graphics g)
        {
            var img = Drawing.RotateImage(Properties.Resources.black_plane, Angle);
            var w = img.Width;
            var h = img.Height;
            g.DrawImage(img, LocalPosition.X - w / 5, LocalPosition.Y + h / 5, w, h);
        }

    }
}
