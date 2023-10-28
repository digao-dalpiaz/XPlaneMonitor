﻿using System.Reflection;

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

        public static double ConverterMilhaNauticaParaKm(double nm)
        {
            return nm * 1.852;
        }

        public static double ConverterKmParaMilhaNautica(double km)
        {
            return km / 1.852;
        }

        public static void DrawGrid(Graphics g, double xUnit, double xTotal, double yUnit, double yTotal, Rectangle r)
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

    }
}
