namespace XPlaneMonitorApp.Functions
{
    internal class ProximityCalculator
    {
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

        //

        public static double CalcularDistanciaAteLinhaAeroporto2(double[] pontoInicial, double[] pontoFinal, double[] pontoAviao)
        {
            double direcaoPista = CalcularDirecao(pontoInicial, pontoFinal);
            double direcaoAviaoPista = CalcularDirecao(pontoInicial, pontoAviao);

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
            double distancia = Math.Sin(diferencaAngular) * CalcularDistanciaHaversine(pontoInicial, pontoAviao);

            return distancia;
        }

        public static double CalcularDirecao(double[] ponto1, double[] ponto2)
        {
            double latitude1Rad = GrausParaRadianos(ponto1[0]);
            double latitude2Rad = GrausParaRadianos(ponto2[0]);
            double diferencaLongitudeRad = GrausParaRadianos(ponto2[1] - ponto1[1]);

            double y = Math.Sin(diferencaLongitudeRad) * Math.Cos(latitude2Rad);
            double x = Math.Cos(latitude1Rad) * Math.Sin(latitude2Rad) - Math.Sin(latitude1Rad) * Math.Cos(latitude2Rad) * Math.Cos(diferencaLongitudeRad);

            double direcao = Math.Atan2(y, x);
            return direcao;
        }
    }
}
