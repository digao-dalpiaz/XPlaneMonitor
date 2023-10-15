using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPlaneMonitorApp
{
    public class GeoCalculator
    {

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double earthRadius = 6371; // Raio médio da Terra em quilômetros

            // Converter graus para radianos
            double radiansLat1 = DegreesToRadians(lat1);
            double radiansLon1 = DegreesToRadians(lon1);
            double radiansLat2 = DegreesToRadians(lat2);
            double radiansLon2 = DegreesToRadians(lon2);

            // Diferença entre as longitudes e latitudes
            double deltaLat = radiansLat2 - radiansLat1;
            double deltaLon = radiansLon2 - radiansLon1;

            // Fórmula de Haversine
            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(radiansLat1) * Math.Cos(radiansLat2) * Math.Pow(Math.Sin(deltaLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;

            return distance;
        }

        public static double CalculateBearing(double lat1, double lon1, double lat2, double lon2)
        {
            double radiansLat1 = DegreesToRadians(lat1);
            double radiansLon1 = DegreesToRadians(lon1);
            double radiansLat2 = DegreesToRadians(lat2);
            double radiansLon2 = DegreesToRadians(lon2);

            double deltaLon = radiansLon2 - radiansLon1;

            double y = Math.Sin(deltaLon) * Math.Cos(radiansLat2);
            double x = Math.Cos(radiansLat1) * Math.Sin(radiansLat2) - Math.Sin(radiansLat1) * Math.Cos(radiansLat2) * Math.Cos(deltaLon);

            double bearing = Math.Atan2(y, x);
            bearing = RadiansToDegrees(bearing);

            return (bearing + 360) % 360; // Garante um ângulo entre 0 e 360 graus
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private static double RadiansToDegrees(double radians)
        {
            return radians * 180.0 / Math.PI;
        }

    }
}
