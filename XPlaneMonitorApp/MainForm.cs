using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using XPlaneMonitorApp.Communicator;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private RefDataList _refsData = new();
        private XPlaneCommunicator _communicator;
        private float? _lat, _lng;
        private GMapOverlay _mapOverlay = new();
        private GMapRoute _mapRoute = new("flight");
        private GMapRoute _runwayRoute = new("runway");

        private DateTime _tickMapUpd;

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

            //gaugeElvTrim.Max = 2;

            //gaugeN1_1.Max = 100;

            gaugeFlaps.AddBar(null, Color.Orange, 1);
            gaugeFlaps.AddBar(null, Color.Green, 1);

            SubscribeAll();
            _communicator = new(_refsData, this);
            _communicator.OnReceived += OnDataRefReceived;
            _communicator.OnStatusChanged += OnStatusChanged;

            OnStatusChanged(); //update buttons
        }

        

        private void SubscribeAll()
        {
            _refsData.Subscribe("sim/flightmodel/controls/flaprqst", v =>
            {
                gaugeFlaps.Bars[0].Pos = v;
                gaugeFlaps.Reload();
            });
            _refsData.Subscribe("sim/cockpit2/controls/flap_system_deploy_ratio", v =>
            {
                gaugeFlaps.Bars[1].Pos = v;
                gaugeFlaps.Reload();
            });
            /*
            Subscribe(DataRefs.Cockpit2EngineActuatorsThrottleRatioAll, d =>
            {
                gaugeThrottle.PosFinal = d.Value;
                gaugeThrottle.Recalc();
            });
            */
            _refsData.Subscribe("sim/flightmodel/misc/h_ind", v =>
            {
                lbAltitude.Text = Utils.RoundToInt(v).ToString() + " ft";
            });

            _refsData.Subscribe("sim/flightmodel/position/indicated_airspeed", v =>
            {
                lbAirspeed.Text = Utils.RoundToInt(v).ToString() + " kts";
            });
            _refsData.Subscribe("sim/flightmodel/position/groundspeed", v =>
            {
                //original value in m/s
                lbGroundspeed.Text = Utils.RoundToInt(v * 3.6).ToString() + " km/h";
            });

            _refsData.Subscribe("sim/flightmodel/position/vh_ind_fpm", v =>
            {
                lbVerticalspeed.Text = Utils.RoundToInt(v).ToString() + " ft/m";
                lbVerticalspeed.ForeColor = v > 0 ? Color.Green : Color.Red;
            });
            _refsData.Subscribe("sim/cockpit2/gauges/indicators/radio_altimeter_height_ft_pilot", v =>
            {
                lbRadioAltimeter.Text = Utils.RoundToInt(v).ToString() + " ft";
            });
            _refsData.Subscribe("sim/cockpit2/gauges/indicators/compass_heading_deg_mag", v =>
            {
                lbHeading.Text = Utils.RoundToInt(v).ToString() + "º";
            });
            _refsData.Subscribe("sim/flightmodel/position/latitude", v =>
            {
                _lat = v;
                UpdateMap();
            });
            _refsData.Subscribe("sim/flightmodel/position/longitude", v =>
            {
                _lng = v;
                UpdateMap();
            });
            _refsData.Subscribe("sim/cockpit2/controls/elevator_trim", v =>
            {
                //gaugeElvTrim.PosFinal = v + 1;
                //gaugeElvTrim.Recalc();
            });
            _refsData.Subscribe("sim/cockpit2/controls/parking_brake_ratio", v =>
            {
                lbParking.Text = "PARKING BRAKE " + (v == 1 ? "ON" : "OFF");
                lbParking.ForeColor = v == 1 ? Color.Red : Color.Green;
            });

            _refsData.Subscribe("sim/cockpit2/engine/actuators/throttle_ratio[1]", v =>
            {
                //gaugeN1_1.PosRqst = v * 100;
                //gaugeN1_1.Recalc();
            });
            _refsData.Subscribe("sim/cockpit2/engine/indicators/N1_percent[1]", v =>
            {
                //gaugeN1_1.PosFinal = v;
                //gaugeN1_1.Recalc();
            });
            /*
            
            Subscribe(DataRefs.AircraftPartsAcfGearDeploy, d =>
            {
                gaugeGear.PosFinal = d.Value;
                gaugeGear.Recalc();
            });*/
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

        private void OnDataRefReceived()
        {
            lbLastReceive.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void OnStatusChanged()
        {
            btnConnect.Enabled = _communicator.Status == ConnectionStatus.DISCONNECTED;
            btnDisconnect.Enabled = _communicator.Status == ConnectionStatus.CONNECTED;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_communicator.Status == ConnectionStatus.CONNECTED)
            {
                _communicator.Disconnect();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _communicator.Connect("127.0.0.1", 49009);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _communicator.Disconnect();
        }
    }
}