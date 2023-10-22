namespace XPlaneMonitorApp
{
    internal class ProximityCalculator
    {
        public static double CalcularDistanciaAteLinhaAeroporto(double[] pontoInicial, double[] pontoFinal, double[] pontoAviao)
        {
            // Converter graus para radianos
            double latitudeInicialRad = GrausParaRadianos(pontoInicial[0]);
            double longitudeInicialRad = GrausParaRadianos(pontoInicial[1]);
            double latitudeFinalRad = GrausParaRadianos(pontoFinal[0]);
            double longitudeFinalRad = GrausParaRadianos(pontoFinal[1]);
            double latitudeAviaoRad = GrausParaRadianos(pontoAviao[0]);
            double longitudeAviaoRad = GrausParaRadianos(pontoAviao[1]);

            // Calcular a direção da pista
            double direcaoPista = Math.Atan2(Math.Sin(longitudeFinalRad - longitudeInicialRad) * Math.Cos(latitudeFinalRad),
                                              Math.Cos(latitudeInicialRad) * Math.Sin(latitudeFinalRad) -
                                              Math.Sin(latitudeInicialRad) * Math.Cos(latitudeFinalRad) * Math.Cos(longitudeFinalRad - longitudeInicialRad));

            // Calcular a direção da linha do avião em relação à pista
            double direcaoAviaoPista = Math.Atan2(Math.Sin(longitudeAviaoRad - longitudeInicialRad) * Math.Cos(latitudeAviaoRad),
                                                   Math.Cos(latitudeInicialRad) * Math.Sin(latitudeAviaoRad) -
                                                   Math.Sin(latitudeInicialRad) * Math.Cos(latitudeAviaoRad) * Math.Cos(longitudeAviaoRad - longitudeInicialRad));

            // Calcular a diferença angular
            double diferencaAngular = Math.Abs(direcaoAviaoPista - direcaoPista);

            // Calcular a distância entre o avião e a linha do aeroporto
            double distancia = Math.Sin(diferencaAngular) * CalcularDistanciaHaversine(pontoInicial, pontoAviao);

            return distancia;
        }

        public static double GrausParaRadianos(double graus)
        {
            return graus * (Math.PI / 180.0);
        }

        public static double CalcularDistanciaHaversine(double[] ponto1, double[] ponto2)
        {
            const double raioTerra = 6371000; // Raio médio da Terra em metros

            double latitude1Rad = GrausParaRadianos(ponto1[0]);
            double latitude2Rad = GrausParaRadianos(ponto2[0]);

            double diferencaLatitudeRad = latitude2Rad - latitude1Rad;
            double diferencaLongitudeRad = GrausParaRadianos(ponto2[1] - ponto1[1]);

            double a = Math.Sin(diferencaLatitudeRad / 2) * Math.Sin(diferencaLatitudeRad / 2) +
                       Math.Cos(latitude1Rad) * Math.Cos(latitude2Rad) *
                       Math.Sin(diferencaLongitudeRad / 2) * Math.Sin(diferencaLongitudeRad / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return raioTerra * c;
        }
    }
}
