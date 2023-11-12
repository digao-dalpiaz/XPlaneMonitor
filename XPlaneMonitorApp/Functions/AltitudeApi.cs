using GMap.NET;
using System.Globalization;

namespace XPlaneMonitorApp.Functions
{
    public class AltitudeApi
    {

        public static double GetElevationMeters(PointLatLng point)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            string latStr = point.Lat.ToString(culture);
            string lonStr = point.Lng.ToString(culture);

            string apiUrl = $"https://api.open-elevation.com/api/v1/lookup?locations={latStr},{lonStr}";

            using var client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (!response.IsSuccessStatusCode) throw new Exception("Status code: " + response.StatusCode);

                string responseBody = response.Content.ReadAsStringAsync().Result;
                dynamic elevationData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody) ?? throw new Exception("Null response");
                return elevationData.results[0].elevation;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving elevation: " + ex.Message);
            }
        }

    }
}
