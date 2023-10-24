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
            Drawing.DrawImage(g, img, LocalPosition.X - Utils.Div(img.Width, 5), LocalPosition.Y + Utils.Div(img.Height, 5));
        }

    }
}
