using GMap.NET;
using System.Globalization;

namespace XPlaneMonitorApp.Functions
{
    public class GoogleMapsLinkDecoder
    {
        public static PointLatLng ReadFromClipboard()
        {
            var text = Clipboard.GetText() ?? throw new MsgException("Nothing found in clipboard");

            const string START_IDENT = "/@";
            var i = text.IndexOf(START_IDENT);
            if (i == -1) throw new MsgException("Clipboard does not contain Google Maps position link");

            text = text[(i + START_IDENT.Length)..];
            var parts = text.Split(',');
            if (parts.Length < 3) throw new MsgException("Incorrect parts of Google Maps position link");

            CultureInfo culture = new("en-US");

            if (!double.TryParse(parts[0], NumberStyles.Float, culture, out double lat) ||
                !double.TryParse(parts[1], NumberStyles.Float, culture, out double lng))
            {
                throw new MsgException("Latitude/longitude with invalid values");
            }

            return new PointLatLng(lat, lng);
        }
    }
}
