
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using XPlaneConnector;
using XPlaneConnector.DataRefs;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private XPlaneConnector.XPlaneConnector _xp;
        private Dictionary<DataRefElement, Action<DataRefElement>> _elementsDictionary = new();

        private float? _lat, _lng;
        private GMapOverlay _mapOverlay = new();
        private GMapRoute _mapRoute = new("flight");

        private DateTime _tickMapUpd;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            map.MapProvider = OpenStreetMapGraphHopperProvider.Instance;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.Overlays.Add(_mapOverlay);
            _mapOverlay.Routes.Add(_mapRoute);

            map.MaxZoom = 100;
            map.MinZoom = 0;
            map.Zoom = 15;

            gaugeFlaps.Max = 1;

            _xp = new("127.0.0.1", 49000);
            SubscribeAll();
            _xp.OnDataRefReceived += OnDataRefReceived;
            _xp.Start();
        }

        private void SubscribeAll()
        {
            Subscribe(DataRefs.FlightmodelControlsFlaprqst, d =>
            {
                gaugeFlaps.PosRqst = d.Value;
                gaugeFlaps.Recalc();
            });
            Subscribe(DataRefs.Flightmodel2ControlsFlapHandleDeployRatio, d =>
            {
                gaugeFlaps.PosFinal = d.Value;
                gaugeFlaps.Recalc();
            });
            Subscribe(DataRefs.Cockpit2EngineActuatorsThrottleRatioAll, d =>
            {
                gaugeThrottle.PosRqst = d.Value;
                gaugeThrottle.Recalc();
            });
            Subscribe(DataRefs.Cockpit2GaugesIndicatorsAltitudeFtPilot, d =>
            {
                lbAltitude.Text = Utils.RoundToInt(d.Value).ToString() + " ft";
            });
            Subscribe(DataRefs.Cockpit2GaugesIndicatorsAirspeedKtsPilot, d =>
            {
                lbAirspeed.Text = Utils.RoundToInt(d.Value).ToString() + " kts";
            });
            Subscribe(DataRefs.FlightmodelPositionGroundspeed, d =>
            {
                //original value in m/s - converting to knots
                lbGroundspeed.Text = Utils.RoundToInt((float)(d.Value * 1.943844492441)).ToString() + " kts";
            });
            Subscribe(DataRefs.FlightmodelPositionVhIndFpm, d =>
            {
                lbVerticalspeed.Text = Utils.RoundToInt(d.Value).ToString() + " ft/m";
            });
            Subscribe(DataRefs.Cockpit2GaugesIndicatorsRadioAltimeterHeightFtPilot, d =>
            {
                lbRadioAltimeter.Text = Utils.RoundToInt(d.Value).ToString() + " ft";
            });

            Subscribe(DataRefs.FlightmodelPositionLatitude, d =>
            {
                _lat = d.Value;
                UpdateMap();
            });
            Subscribe(DataRefs.FlightmodelPositionLongitude, d =>
            {
                _lng = d.Value;
                UpdateMap();
            });
        }

        private void UpdateMap()
        {
            if (!_lat.HasValue || !_lng.HasValue) return;

            if ((DateTime.Now - _tickMapUpd).TotalMilliseconds < 1000) return;
            _tickMapUpd = DateTime.Now;

            var pos = new GMap.NET.PointLatLng(_lat.Value, _lng.Value);
            var marker = new GMarkerGoogle(pos, GMarkerGoogleType.blue);

            map.Position = pos;

            _mapRoute.Points.Add(pos);
            
            _mapOverlay.Markers.Clear();
            _mapOverlay.Markers.Add(marker);
        }

        private void Subscribe(DataRefElement element, Action<DataRefElement> action)
        {
            _xp.Subscribe(element, 2);
            _elementsDictionary.Add(element, action);
        }

        private void OnDataRefReceived(DataRefElement d)
        {
            var ev = _elementsDictionary.First(x => x.Key.DataRef == d.DataRef);
            Invoke(() => ev.Value(d));
        }

    }
}