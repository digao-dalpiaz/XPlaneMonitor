using Newtonsoft.Json;

namespace XPlaneMonitorApp.Config
{
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
                Vars.Cfg = JsonConvert.DeserializeObject<ConfigData>(data);
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
