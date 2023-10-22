namespace XPlaneMonitorApp.Functions
{
    public class Utils
    {

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

        public static double ConverterKmParaMilhaNautica(double km)
        {
            const double quilometrosPorMilhaNautica = 1.852;
            return km / quilometrosPorMilhaNautica;
        }

    }
}
