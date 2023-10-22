using Newtonsoft.Json;

namespace XPlaneMonitorApp
{
    public class Config
    {
        public string Host = "127.0.0.1";
        public int Port = 49000;

        public int RampDistance = 12;
        public int RampElevation = 4000;
    }

    public class ConfigEngine
    {
        private static string GetFile()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.json");
        }

        public static void Load()
        {
            var file = GetFile();
            if (File.Exists(file))
            {
                var data = File.ReadAllText(file);
                Vars.Cfg = JsonConvert.DeserializeObject<Config>(data);
            } 
            else
            {
                Vars.Cfg = new();
            }
        }

        public static void Save()
        {
            var data = JsonConvert.SerializeObject(Vars.Cfg);
            File.WriteAllText(GetFile(), data);
        }
    }
}
