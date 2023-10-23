using System.Reflection;

namespace XPlaneMonitorApp.Functions
{
    public class Utils
    {
        public static void SetDoubleBuffered<T>(T control) where T : Control
        {
            typeof(T).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, control, new object[] { true });
        }

        public static int RoundToInt(float value)
        {
            return (int)Math.Round(value);
        }

        public static int RoundToInt(double value)
        {
            return (int)Math.Round(value);
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * 180.0 / Math.PI;
        }

        public static double InvertDegree(double angle)
        {
            double invertedAngle = (angle + 180) % 360;
            return invertedAngle;
        }

        public static double ConvertMetersToFeet(double metros)
        {
            const double metrosPorPe = 0.3048;
            return metros / metrosPorPe;
        }

        public static double ConverterMilhaNauticaParaKm(double nm)
        {
            const double milhasNauticasEmQuilometros = 1.852;
            return nm * milhasNauticasEmQuilometros;
        }

        public static double ConverterKmParaMilhaNautica(double km)
        {
            const double quilometrosPorMilhaNautica = 1.852;
            return km / quilometrosPorMilhaNautica;
        }

        public static void DrawGrid(Graphics g, double xUnit, double xTotal, double yUnit, double yTotal, Rectangle r)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), r);

            double xSpacing = r.Width * xUnit / xTotal;
            double x = 0;
            while (x < r.Width)
            {
                x += xSpacing;
                g.DrawLine(new Pen(Color.Black), (float)x, 0, (float)x, r.Height);
            }

            double ySpacing = r.Height * yUnit / yTotal;
            double y = 0;
            while (y < r.Height)
            {
                y += ySpacing;
                g.DrawLine(new Pen(Color.Black), 0, (float)y, r.Width, (float)y);
            }
        }

    }
}
