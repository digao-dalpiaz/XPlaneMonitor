namespace XPlaneMonitorApp.Config
{
    public class ConfigData
    {
        public string Host = "127.0.0.1";
        public int Port = 49000;

        public int UpdPerSecond = 3;
        public DegreesUnitType DegreesUnit = DegreesUnitType.CELSIUS;

        public int RampDistance = 12;
        public int RampElevation = 4000;
    }

    public enum DegreesUnitType
    {
        CELSIUS,
        FAHRENHEIT
    }
}
