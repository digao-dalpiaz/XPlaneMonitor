using GMap.NET;

namespace XPlaneMonitorApp.Functions
{
    public class GeoCalculator
    {

        const double EARTH_RADIUS_KM = 6371; // Raio médio da Terra em quilômetros

        public static double CalculateDistanceKm(PointLatLng ponto1, PointLatLng ponto2)
        {
            // Converter graus para radianos
            double radiansLat1 = Utils.DegreesToRadians(ponto1.Lat);
            double radiansLon1 = Utils.DegreesToRadians(ponto1.Lng);
            double radiansLat2 = Utils.DegreesToRadians(ponto2.Lat);
            double radiansLon2 = Utils.DegreesToRadians(ponto2.Lng);

            // Diferença entre as longitudes e latitudes
            double deltaLat = radiansLat2 - radiansLat1;
            double deltaLon = radiansLon2 - radiansLon1;

            // Fórmula de Haversine
            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(radiansLat1) * Math.Cos(radiansLat2) * Math.Pow(Math.Sin(deltaLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EARTH_RADIUS_KM * c;

            return distance;
        }

        public static double CalculateBearingDegrees(PointLatLng ponto1, PointLatLng ponto2)
        {
            double radiansLat1 = Utils.DegreesToRadians(ponto1.Lat);
            double radiansLon1 = Utils.DegreesToRadians(ponto1.Lng);
            double radiansLat2 = Utils.DegreesToRadians(ponto2.Lat);
            double radiansLon2 = Utils.DegreesToRadians(ponto2.Lng);

            double deltaLon = radiansLon2 - radiansLon1;

            double y = Math.Sin(deltaLon) * Math.Cos(radiansLat2);
            double x = Math.Cos(radiansLat1) * Math.Sin(radiansLat2) - Math.Sin(radiansLat1) * Math.Cos(radiansLat2) * Math.Cos(deltaLon);

            double bearing = Math.Atan2(y, x);
            bearing = Utils.RadiansToDegrees(bearing);

            return (bearing + 360) % 360; // Garante um ângulo entre 0 e 360 graus
        }

        public static PointLatLng CalculateDestinationPoint(PointLatLng ponto, double initialBearing, double distanceKm)
        {
            // Converter graus para radianos
            double radiansLat1 = Utils.DegreesToRadians(ponto.Lat);
            double radiansLon1 = Utils.DegreesToRadians(ponto.Lng);
            double radiansBearing = Utils.DegreesToRadians(initialBearing);

            // Converter distância para radianos (arc length)
            double angularDistance = distanceKm / EARTH_RADIUS_KM;

            // Calcular a latitude do ponto final
            double finalLat = Math.Asin(Math.Sin(radiansLat1) * Math.Cos(angularDistance) + Math.Cos(radiansLat1) * Math.Sin(angularDistance) * Math.Cos(radiansBearing));

            // Calcular a longitude do ponto final
            double finalLon = radiansLon1 + Math.Atan2(Math.Sin(radiansBearing) * Math.Sin(angularDistance) * Math.Cos(radiansLat1), Math.Cos(angularDistance) - Math.Sin(radiansLat1) * Math.Sin(finalLat));

            finalLat = Utils.RadiansToDegrees(finalLat);
            finalLon = Utils.RadiansToDegrees(finalLon);

            return new(finalLat, finalLon);
        }

        public static PointLatLng CalculateCentralPoint(PointLatLng ponto1, PointLatLng ponto2)
        {
            double lat1 = Utils.DegreesToRadians(ponto1.Lat);
            double lon1 = Utils.DegreesToRadians(ponto1.Lng);
            double lat2 = Utils.DegreesToRadians(ponto2.Lat);
            double lon2 = Utils.DegreesToRadians(ponto2.Lng);

            double dLon = lon2 - lon1;

            double x = Math.Cos(lat2) * Math.Cos(dLon);
            double y = Math.Cos(lat2) * Math.Sin(dLon);

            double lat3 = Math.Atan2(
                Math.Sin(lat1) + Math.Sin(lat2),
                Math.Sqrt((Math.Cos(lat1) + x) * (Math.Cos(lat1) + x) + y * y)
            );

            double lon3 = lon1 + Math.Atan2(y, Math.Cos(lat1) + x);

            return new(Utils.RadiansToDegrees(lat3), Utils.RadiansToDegrees(lon3));
        }

    }
}
