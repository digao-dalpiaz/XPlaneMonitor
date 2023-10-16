using GMap.NET;
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
        private GMapRoute _runwayRoute = new("runway");

        private DateTime _tickMapUpd;

        private bool _closed;

        enum SettingMode
        {
            NONE,
            RUNWAY_BEGIN,
            RUNWAY_END
        }
        private SettingMode _settingMode;

        private PointLatLng? _runwayBegin, _runwayEnd, _runwayApproach;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetSettingMode(SettingMode.NONE);

            map.MapProvider = OpenStreetMapGraphHopperProvider.Instance;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.Overlays.Add(_mapOverlay);
            _mapOverlay.Routes.Add(_mapRoute);
            _mapOverlay.Routes.Add(_runwayRoute);

            map.MaxZoom = 100;
            map.MinZoom = 0;
            map.Zoom = 15;

            gaugeElvTrim.Max = 2;

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
                gaugeThrottle.PosFinal = d.Value;
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
                lbGroundspeed.Text = Utils.RoundToInt(d.Value * 1.943844492441).ToString() + " kts";
            });
            Subscribe(DataRefs.FlightmodelPositionVhIndFpm, d =>
            {
                lbVerticalspeed.Text = Utils.RoundToInt(d.Value).ToString() + " ft/m";
                lbVerticalspeed.ForeColor = d.Value > 0 ? Color.Green : Color.Red;
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
            Subscribe(DataRefs.Cockpit2ControlsParkingBrakeRatio, d =>
            {
                lbParking.Text = "PARKING BRAKE " + (d.Value == 1 ? "ON" : "OFF");
                lbParking.ForeColor = d.Value == 1 ? Color.Red : Color.Green;
            });
            Subscribe(DataRefs.Cockpit2ControlsElevatorTrim, d =>
            {
                gaugeElvTrim.PosFinal = d.Value + 1;
                gaugeElvTrim.Recalc();
            });
        }

        private void UpdateMap()
        {
            if (!_lat.HasValue || !_lng.HasValue) return;

            if ((DateTime.Now - _tickMapUpd).TotalMilliseconds < 1000) return;
            _tickMapUpd = DateTime.Now;

            var pos = new PointLatLng(_lat.Value, _lng.Value);
            var marker = new GMarkerGoogle(pos, GMarkerGoogleType.blue);

            map.Position = pos;

            _mapRoute.Points.Add(pos);
            map.UpdateRouteLocalPosition(_mapRoute);

            _mapOverlay.Markers.Clear();
            _mapOverlay.Markers.Add(marker);

            RecalcApproachParams();
        }

        private void Subscribe(DataRefElement element, Action<DataRefElement> action)
        {
            _xp.Subscribe(element, 2);
            _elementsDictionary.Add(element, action);
        }

        private void OnDataRefReceived(DataRefElement d)
        {
            if (_closed) return;

            var ev = _elementsDictionary.First(x => x.Key.DataRef == d.DataRef);
            Invoke(() => ev.Value(d));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _closed = true;
        }

        private void SetSettingMode(SettingMode setting)
        {
            _settingMode = setting;

            btnSetRunwayBegin.BackColor = setting == SettingMode.RUNWAY_BEGIN ? Color.Red : SystemColors.Control;
            btnSetRunwayEnd.BackColor = setting == SettingMode.RUNWAY_END ? Color.Red : SystemColors.Control;

            btnTurnOffSettingMode.Enabled = setting != SettingMode.NONE;
        }

        private void map_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (_settingMode == SettingMode.RUNWAY_BEGIN)
            {
                _runwayBegin = pointClick;
                edRunwayBegin.Text = pointClick.ToString();

                SetSettingMode(SettingMode.RUNWAY_END);
            }
            else if (_settingMode == SettingMode.RUNWAY_END)
            {
                _runwayEnd = pointClick;
                edRunwayEnd.Text = pointClick.ToString();

                SetSettingMode(SettingMode.NONE);
            }

            CheckRunwayPoints();
        }

        private void CheckRunwayPoints()
        {
            if (_runwayBegin.HasValue && _runwayEnd.HasValue)
            {
                var degrees = GeoCalculator.CalculateBearing(
                    _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                    _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

                var elevMeters = AltitudeApi.GetElevationMeters(_runwayBegin.Value.Lat, _runwayBegin.Value.Lng);

                var size = GeoCalculator.CalculateDistance(
                    _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                    _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

                lbRunwayElevation.Text = elevMeters.ToString() + " m / " + Utils.RoundToInt(GeoCalculator.ConvertMetersToFeet(elevMeters)) + " ft";
                lbRunwayDegrees.Text = Utils.RoundToInt(degrees).ToString() + "º";
                lbRunwaySize.Text = Utils.RoundToInt(size * 1000).ToString() + " m";

                var approach = GeoCalculator.CalculateDestinationPoint(_runwayBegin.Value.Lat, _runwayBegin.Value.Lng, GeoCalculator.InvertDegree(degrees), 22);

                _runwayApproach = new PointLatLng(approach.Item1, approach.Item2);

                _runwayRoute.Points.Clear();
                _runwayRoute.Points.Add(_runwayApproach.Value);
                _runwayRoute.Points.Add(_runwayBegin.Value);
                _runwayRoute.Points.Add(_runwayEnd.Value);

                map.UpdateRouteLocalPosition(_runwayRoute);

                RecalcApproachParams();
            }
        }

        private void RecalcApproachParams()
        {
            if (_lat.HasValue && _lng.HasValue && _runwayBegin.HasValue && _runwayEnd.HasValue && _runwayApproach.HasValue)
            {
                lbApproachDist.Text = Utils.RoundToInt(GeoCalculator.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat.Value, _lng.Value, _runwayApproach.Value.Lat, _runwayApproach.Value.Lng))).ToString();
                lbRunwayDist.Text = Utils.RoundToInt(GeoCalculator.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat.Value, _lng.Value, _runwayBegin.Value.Lat, _runwayBegin.Value.Lng))).ToString();

                lbCompassToApproach.Text = Utils.RoundToInt(
                    GeoCalculator.CalculateBearing(_lat.Value, _lng.Value, _runwayApproach.Value.Lat, _runwayApproach.Value.Lng)).ToString();
                lbCompassToRunway.Text = Utils.RoundToInt(
                    GeoCalculator.CalculateBearing(_lat.Value, _lng.Value, _runwayBegin.Value.Lat, _runwayBegin.Value.Lng)).ToString();
            }
        }

        private void btnSetRunwayBegin_Click(object sender, EventArgs e)
        {
            SetSettingMode(SettingMode.RUNWAY_BEGIN);
        }

        private void btnSetRunwayEnd_Click(object sender, EventArgs e)
        {
            SetSettingMode(SettingMode.RUNWAY_END);
        }

        private void btnTurnOffSettingMode_Click(object sender, EventArgs e)
        {
            SetSettingMode(SettingMode.NONE);
        }

        private void btnClearRunwayApproach_Click(object sender, EventArgs e)
        {
            SetSettingMode(SettingMode.NONE);

            _runwayBegin = null;
            _runwayEnd = null;
            _runwayApproach = null;

            _runwayRoute.Points.Clear();
            map.UpdateRouteLocalPosition(_runwayRoute);

            edRunwayBegin.Clear();
            edRunwayEnd.Clear();

            lbRunwayElevation.Text = string.Empty;
            lbRunwayDegrees.Text = string.Empty;
            lbRunwaySize.Text = string.Empty;
            lbApproachDist.Text = string.Empty;
            lbRunwayDist.Text = string.Empty;
            lbCompassToApproach.Text = string.Empty;
            lbCompassToRunway.Text = string.Empty;

        }
    }
}