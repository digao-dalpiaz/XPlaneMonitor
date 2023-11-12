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
        
        public static double Div(double a, double b)
        {
            return a / b;
        }

        public static double RuleOfThree(double a1, double a2, double b1)
        {
            return a2 * b1 / a1;
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
            return (angle + 180) % 360;
        }

        public static double AddAngles(double angle1, double angle2)
        {
            double sum = angle1 + angle2;

            while (sum < 0) sum += 360;
            while (sum >= 360) sum -= 360;

            return sum;
        }

        public static double ConvertMetersToFeet(double meters)
        {
            return meters / 0.3048;
        }

        public static double ConvertNauticalMilesToKm(double nm)
        {
            return nm * 1.852;
        }

        public static double ConvertKmToNauticalMiles(double km)
        {
            return km / 1.852;
        }

        public static double ConvertMetersPerSecondToKilometersPerHour(double value)
        {
            return value * 3.6;
        }

        public static double ConvertKilometersToMeters(double value)
        {
            return value * 1000;
        }

        public static double ConvertMetersToKilometers(double value)
        {
            return value / 1000;
        }

        public static void DrawGrid(Graphics g, double xUnit, double xTotal, double yUnit, double yTotal, RectangleF r)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), r);

            double xSpacing = RuleOfThree(xTotal, xUnit, r.Width);
            double x = 0;
            while (x < r.Width)
            {
                x += xSpacing;
                Drawing.DrawLine(g, new Pen(Color.Black), x, 0, x, r.Height);
            }

            double ySpacing = RuleOfThree(yTotal, yUnit, r.Height);
            double y = 0;
            while (y < r.Height)
            {
                y += ySpacing;
                Drawing.DrawLine(g, new Pen(Color.Black), 0, y, r.Width, y);
            }
        }

        public static string SecondsToTime(double totalSeconds)
        {
            var time = TimeSpan.FromSeconds(totalSeconds);

            var hours = time.TotalHours;
            var hoursInt = Math.Floor(hours);
            var min = (hours - hoursInt) * 60;
            var minInt = Math.Floor(min);
            var sec = (min - minInt) * 60;
            var secInt = Math.Floor(sec);

            return hoursInt.ToString("00") + ":" + minInt.ToString("00") + ":" + secInt.ToString("00");
        }

        public static double CalculateVerticalRatioInFtPerMin(double initialAltitudeFt, double finalAltitudeFt, double speedMS, double distanceNm)
        {
            double altitudeFt = finalAltitudeFt - initialAltitudeFt;
            double speedKmH = ConvertMetersPerSecondToKilometersPerHour(speedMS);
            double distanceKm = ConvertNauticalMilesToKm(distanceNm);

            //esta fórmula eu construí fazendo observações no simulador, sem vento e clima zerado
            //a cada 5.000 pés, uso o fator de 0.928 aplicado a velocidade para corrigí-la
            speedKmH = speedKmH * Math.Pow(0.928, -altitudeFt / 1000 / 5);

            double hours = distanceKm / speedKmH;
            double mins = hours * 60;

            return altitudeFt / mins;
        }

    }
}
