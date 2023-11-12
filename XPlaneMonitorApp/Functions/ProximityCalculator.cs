using GMap.NET;

namespace XPlaneMonitorApp.Functions
{
    public class ProximityCalculator
    {

        private static double CalculateHaversineDistanceMeters(PointLatLng ponto1, PointLatLng ponto2)
        {
            const double raioTerra = 6371000; // Raio médio da Terra em metros

            double latitude1Rad = Utils.DegreesToRadians(ponto1.Lat);
            double latitude2Rad = Utils.DegreesToRadians(ponto2.Lat);

            double diferencaLatitudeRad = latitude2Rad - latitude1Rad;
            double diferencaLongitudeRad = Utils.DegreesToRadians(ponto2.Lng - ponto1.Lng);

            double a = Math.Sin(diferencaLatitudeRad / 2) * Math.Sin(diferencaLatitudeRad / 2) +
                       Math.Cos(latitude1Rad) * Math.Cos(latitude2Rad) *
                       Math.Sin(diferencaLongitudeRad / 2) * Math.Sin(diferencaLongitudeRad / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return raioTerra * c;
        }

        public static double CalculateLongitudinalClearanceMeters(PointLatLng pontoInicial, PointLatLng pontoFinal, PointLatLng pontoAviao)
        {
            double direcaoPista = CalculateAngleDirection(pontoInicial, pontoFinal);
            double direcaoAviaoPista = CalculateAngleDirection(pontoInicial, pontoAviao);

            // Verifique a orientação da pista
            double diferencaAngular = direcaoAviaoPista - direcaoPista;

            // Normalizar a diferença angular para o intervalo de -180 a 180 graus
            if (diferencaAngular > Math.PI)
            {
                diferencaAngular -= 2 * Math.PI;
            }
            else if (diferencaAngular < -Math.PI)
            {
                diferencaAngular += 2 * Math.PI;
            }

            // Calcular a distância entre o avião e a linha do aeroporto
            double distancia = Math.Sin(diferencaAngular) * CalculateHaversineDistanceMeters(pontoInicial, pontoAviao);

            return distancia;
        }

        private static double CalculateAngleDirection(PointLatLng ponto1, PointLatLng ponto2)
        {
            double latitude1Rad = Utils.DegreesToRadians(ponto1.Lat);
            double latitude2Rad = Utils.DegreesToRadians(ponto2.Lat);
            double diferencaLongitudeRad = Utils.DegreesToRadians(ponto2.Lng - ponto1.Lng);

            double y = Math.Sin(diferencaLongitudeRad) * Math.Cos(latitude2Rad);
            double x = Math.Cos(latitude1Rad) * Math.Sin(latitude2Rad) - Math.Sin(latitude1Rad) * Math.Cos(latitude2Rad) * Math.Cos(diferencaLongitudeRad);

            double direcao = Math.Atan2(y, x);
            return direcao;
        }

    }
}
