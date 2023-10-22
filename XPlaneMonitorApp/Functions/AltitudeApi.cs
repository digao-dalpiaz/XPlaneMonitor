﻿using System.Globalization;

namespace XPlaneMonitorApp.Functions
{
    public class AltitudeApi
    {

        public static double GetElevationMeters(double lat, double lng)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            string latStr = lat.ToString(culture);
            string lonStr = lng.ToString(culture);

            string apiUrl = $"https://api.open-elevation.com/api/v1/lookup?locations={latStr},{lonStr}";

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (!response.IsSuccessStatusCode) throw new Exception("Status code: " + response.StatusCode);

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    dynamic elevationData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                    if (elevationData == null) throw new Exception("Null response");

                    return elevationData.results[0].elevation;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving elevation: " + ex.Message);
                }
            }
        }

    }
}
