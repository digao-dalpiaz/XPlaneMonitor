using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using XPlaneMonitorApp.Communicator;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private RefDataContractList _refsData = new();
        private XPlaneCommunicator _communicator;
        private float? _lat, _lng;
        private GMapOverlay _mapOverlay = new();
        private GMapRoute _mapRoute = new("flight");
        private GMapRoute _runwayRoute = new("runway");

        private DateTime _tickMapUpd;

        private float _fuelTotalCapacity;

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

            gaugeFlaps.AddBar("Requested", Color.Orange, 1);
            gaugeFlaps.AddBar("Actual", Color.Green, 1);

            gaugeElvTrim.AddBar(null, Color.Bisque, 2);

            gaugeGear.AddBar("Requested", Color.Purple, 1);
            gaugeGear.AddBar("Actual", Color.Firebrick, 1);

            gaugeSpoilers.AddBar("Left", Color.Gainsboro, 20);
            gaugeSpoilers.AddBar("Right", Color.Gainsboro, 20);

            gaugeSpeedBrake.AddBar("Requested", Color.Gold, 1);
            gaugeSpeedBrake.AddBar("Actual", Color.MediumBlue, 1);

            gaugeWheelBrake.AddBar("Left", Color.Fuchsia, 1);
            gaugeWheelBrake.AddBar("Right", Color.Fuchsia, 1);

            for (int i = 0; i < 4; i++)
            {
                gaugeThrottle.AddBar(string.Format("[{0}] Throttle", i+1), Color.Green, 1);
                gaugeThrottle.AddBar(string.Format("[{0}] N1", i+1), Color.Red, 100);
                gaugeThrottle.AddBar(string.Format("[{0}] N2", i+1), Color.Orange, 100);

                gaugeFuel.AddBar(string.Format("Tank {0}", i+1), Color.Aquamarine, 0);
            }

            SubscribeAll();
            _communicator = new(_refsData, this);
            _communicator.OnReceived += OnDataRefReceived;
            _communicator.OnStatusChanged += OnStatusChanged;

            OnStatusChanged(); //update buttons
        }

        private void SubscribeAll()
        {
            _refsData.Subscribe("sim/flightmodel/position/latitude", r =>
            {
                _lat = r.Value;
                UpdateMap();
            });
            _refsData.Subscribe("sim/flightmodel/position/longitude", r =>
            {
                _lng = r.Value;
                UpdateMap();
            });

            _refsData.Subscribe("sim/flightmodel/misc/h_ind", r =>
            {
                lbAltitude.Text = Utils.RoundToInt(r.Value).ToString() + " ft";
            });
            _refsData.Subscribe("sim/flightmodel/position/indicated_airspeed", r =>
            {
                lbAirspeed.Text = Utils.RoundToInt(r.Value).ToString() + " kts";
            });
            _refsData.Subscribe("sim/flightmodel/position/groundspeed", r =>
            {
                //original value in m/s
                lbGroundspeed.Text = Utils.RoundToInt(r.Value * 3.6).ToString() + " km/h";
            });
            _refsData.Subscribe("sim/flightmodel/position/vh_ind_fpm", r =>
            {
                lbVerticalspeed.Text = Utils.RoundToInt(r.Value).ToString() + " ft/m";
                lbVerticalspeed.ForeColor = r.Value > 0 ? Color.Green : Color.Red;
            });
            _refsData.Subscribe("sim/cockpit2/gauges/indicators/radio_altimeter_height_ft_pilot", r =>
            {
                lbRadioAltimeter.Text = Utils.RoundToInt(r.Value).ToString() + " ft";
            });
            _refsData.Subscribe("sim/cockpit2/gauges/indicators/compass_heading_deg_mag", r =>
            {
                lbHeading.Text = Utils.RoundToInt(r.Value).ToString() + "º";
            });

            _refsData.Subscribe("sim/flightmodel/controls/parkbrake", r =>
            {
                lbParking.Text = "PARKING BRAKE " + (r.Value == 1 ? "ON" : "OFF");
                lbParking.ForeColor = r.Value == 1 ? Color.Red : Color.Green;
            });

            _refsData.Subscribe("sim/flightmodel/controls/flaprqst", r =>
            {
                gaugeFlaps.Bars[0].Pos = r.Value;
                gaugeFlaps.Reload();
            });
            _refsData.Subscribe("sim/cockpit2/controls/flap_system_deploy_ratio", r =>
            {
                gaugeFlaps.Bars[1].Pos = r.Value;
                gaugeFlaps.Reload();
            });

            _refsData.Subscribe("sim/cockpit2/controls/elevator_trim", r =>
            {
                gaugeElvTrim.Bars[0].Pos = r.Value + 1;
                gaugeElvTrim.Reload();
            });

            var updEngine = (RefDataSubscription r, int barIndex) =>
            {
                gaugeThrottle.Bars[(r.ArrayIndex * 3) + barIndex].Pos = r.Value;
                gaugeThrottle.Reload();
            };

            _refsData.Subscribe("sim/cockpit2/engine/actuators/throttle_ratio", r => updEngine(r, 0), 4);
            _refsData.Subscribe("sim/cockpit2/engine/indicators/N1_percent", r => updEngine(r, 1), 4);
            _refsData.Subscribe("sim/cockpit2/engine/indicators/N2_percent", r => updEngine(r, 2), 4);

            _refsData.Subscribe("sim/aircraft/engine/acf_num_engines", r =>
            {
                gaugeThrottle.ShowBarsCount = (int)r.Value * 3;
                gaugeThrottle.Reload();
            });

            _refsData.Subscribe("sim/aircraft/weight/acf_m_fuel_tot", r =>
            {
                _fuelTotalCapacity = r.Value;
                //
            });

            _refsData.Subscribe("sim/aircraft/overflow/acf_tank_rat", r =>
            {
                gaugeFuel.Bars[r.ArrayIndex].Max = r.Value * _fuelTotalCapacity;
                gaugeFuel.Reload();
            }, 4);
            _refsData.Subscribe("sim/cockpit2/fuel/fuel_quantity", r =>
            {
                var bar = gaugeFuel.Bars[r.ArrayIndex];
                bar.Pos = r.Value;
                //bar.Name = bar.Pos + "/" + bar.Max;
                gaugeFuel.Reload();
            }, 4);

            _refsData.Subscribe("sim/aircraft/overflow/acf_num_tanks", r =>
            {
                gaugeFuel.ShowBarsCount = (int)r.Value;
                gaugeFuel.Reload();
            });

            _refsData.Subscribe("sim/cockpit/switches/gear_handle_status", r =>
            {
                gaugeGear.Bars[0].Pos = r.Value;
                gaugeGear.Bars[0].Extra = r.Value < 0 ? "OFF" : r.Value >= 1 ? "DOWN" : "PREPARED";
                gaugeGear.Reload();
            });
            _refsData.Subscribe("sim/flightmodel/movingparts/gear1def", r =>
            {
                gaugeGear.Bars[1].Pos = r.Value;
                gaugeGear.Reload();
            });

            _refsData.Subscribe("sim/flightmodel/controls/lsplrdef", r =>
            {
                gaugeSpoilers.Bars[0].Pos = r.Value;
                gaugeSpoilers.Reload();
            });
            _refsData.Subscribe("sim/flightmodel/controls/rsplrdef", r =>
            {
                gaugeSpoilers.Bars[1].Pos = r.Value;
                gaugeSpoilers.Reload();
            });

            _refsData.Subscribe("sim/flightmodel/controls/sbrkrqst", r =>
            {
                gaugeSpeedBrake.Bars[0].Pos = r.Value;
                gaugeSpeedBrake.Bars[0].Extra = r.Value < 0 ? "ARMED" : null;
                gaugeSpeedBrake.Reload();
            });
            _refsData.Subscribe("sim/flightmodel/controls/sbrkrat", r =>
            {
                gaugeSpeedBrake.Bars[1].Pos = r.Value;
                gaugeSpeedBrake.Reload();
            });

            _refsData.Subscribe("sim/cockpit2/switches/auto_brake_level", r =>
            {
                lbAutoBrake.Text = r.Value == 0 ? "RTO" : r.Value == 1 ? "OFF" : "ON " + (r.Value-1);
            });

            _refsData.Subscribe("sim/cockpit2/controls/left_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[0].Pos = r.Value;
                gaugeWheelBrake.Reload();
            });
            _refsData.Subscribe("sim/cockpit2/controls/right_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[1].Pos = r.Value;
                gaugeWheelBrake.Reload();
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
            _communicator.Connect("127.0.0.1", 49000);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _communicator.Disconnect();
        }

        private void map_Load(object sender, EventArgs e)
        {

        }
    }
}