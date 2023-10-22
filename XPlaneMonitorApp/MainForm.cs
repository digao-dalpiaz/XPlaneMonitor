using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms.VisualStyles;
using XPlaneMonitorApp.Communicator;
using XPlaneMonitorApp.Config;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private XPlaneCommunicator _communicator;

        private readonly GMapOverlay _mapOverlay = new();
        private readonly GMapRoute _mapRoute = new("flight");
        private readonly GMapRoute _runwayRoute = new("runway");

        private DateTime _tickMapUpd;

        private float? _lat, _lng;

        private float _fuelTotalCapacity;
        private float _altitude;
        private float _runwayElevation;
        private float _runwayDistance;
        private float _spacing;
        private float _headingTrue;
        private float _runwayHeading;

        private enum RunwaySettingMode
        {
            NONE,
            RUNWAY_BEGIN,
            RUNWAY_END
        }
        private RunwaySettingMode _runwaySettingMode = RunwaySettingMode.NONE;

        private PointLatLng? _runwayBegin, _runwayEnd, _runwayApproach;

        public MainForm()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigEngine.Load();
            InitMap();
            BuildGaugeBars();

            _communicator = new(GetRefDataContractList(), this);
            _communicator.OnReceived += OnDataRefReceived;
            _communicator.OnStatusChanged += OnStatusChanged;

            OnStatusChanged(); //update connection buttons
        }

        private void InitMap()
        {
            map.MapProvider = OpenStreetMapGraphHopperProvider.Instance;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.MaxZoom = 100;
            map.MinZoom = 0;
            map.Zoom = 15;
            map.Overlays.Add(_mapOverlay);
            _mapOverlay.Routes.Add(_mapRoute);
            _mapOverlay.Routes.Add(_runwayRoute);
        }

        private void BuildGaugeBars()
        {
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

                gaugeFuel.AddBar(string.Format("Tank {0}", i+1), Color.Aquamarine, 1); //initial Max=1 only to better initial show, because max will be replaced when connected
            }
        }

        private RefDataContractList GetRefDataContractList()
        {
            RefDataContractList lst = new();

            lst.Subscribe("sim/flightmodel/position/latitude", r =>
            {
                _lat = r.Value;
                UpdateMap();
            });
            lst.Subscribe("sim/flightmodel/position/longitude", r =>
            {
                _lng = r.Value;
                UpdateMap();
            });

            lst.Subscribe("sim/flightmodel/position/indicated_airspeed", r =>
            {
                lbAirSpeed.Value = Utils.RoundToInt(r.Value) + " kts";
            });
            lst.Subscribe("sim/flightmodel/position/vh_ind_fpm", r =>
            {
                lbVerticalSpeed.Value = Utils.RoundToInt(r.Value) + " ft/m";
                lbVerticalSpeed.ForeColor = r.Value >= 0 ? Color.Green : Color.Red;
            });
            lst.Subscribe("sim/flightmodel/position/groundspeed", r =>
            {
                //original value in m/s
                lbGroundSpeed.Value = Utils.RoundToInt(r.Value * 3.6) + " km/h";
            });
            lst.Subscribe("sim/flightmodel/misc/h_ind", r =>
            {
                _altitude = r.Value;
                lbAltitude.Value = Utils.RoundToInt(r.Value) + " ft";
            });
            lst.Subscribe("sim/cockpit2/gauges/indicators/radio_altimeter_height_ft_pilot", r =>
            {
                lbRadioAltimeter.Value = Utils.RoundToInt(r.Value) + " ft";
            });
            lst.Subscribe("sim/cockpit2/gauges/indicators/compass_heading_deg_mag", r =>
            {
                lbHeading.Value = Utils.RoundToInt(r.Value) + "º";
            });
            lst.Subscribe("sim/flightmodel2/position/true_psi", r =>
            {
                _headingTrue = r.Value;
                lbHeadingTrue.Value = Utils.RoundToInt(r.Value) + "º";
            });

            lst.Subscribe("sim/cockpit2/switches/auto_brake_level", r =>
            {
                lbAutoBrake.Value = r.Value == 0 ? "RTO" : r.Value == 1 ? "OFF" : "ON " + (r.Value-1);
            });
            lst.Subscribe("sim/flightmodel/controls/parkbrake", r =>
            {
                bool on = r.Value == 1;

                lbParkingBrake.Value = on ? "SET" : "RELEASED";
                lbParkingBrake.ForeColor = on ? Color.Red : Color.Green;

                icoParkingBrake.Visible = on;
            });

            lst.Subscribe("sim/flightmodel/controls/flaprqst", r =>
            {
                gaugeFlaps.Bars[0].Pos = r.Value;
                gaugeFlaps.Reload();
            });
            lst.Subscribe("sim/cockpit2/controls/flap_system_deploy_ratio", r =>
            {
                gaugeFlaps.Bars[1].Pos = r.Value;
                gaugeFlaps.Reload();
            });

            lst.Subscribe("sim/aircraft/weight/acf_m_fuel_tot", r =>
            {
                _fuelTotalCapacity = r.Value;
                //** if total capacity received after gauge calc, the value will remain wrong until next update
            });
            lst.Subscribe("sim/aircraft/overflow/acf_num_tanks", r =>
            {
                gaugeFuel.ShowBarsCount = (int)r.Value;
                gaugeFuel.Reload();
            });
            lst.Subscribe("sim/aircraft/overflow/acf_tank_rat", r =>
            {
                gaugeFuel.Bars[r.ArrayIndex].Max = r.Value * _fuelTotalCapacity;
                gaugeFuel.Reload();
            }, 4);
            lst.Subscribe("sim/cockpit2/fuel/fuel_quantity", r =>
            {
                gaugeFuel.Bars[r.ArrayIndex].Pos = r.Value;
                gaugeFuel.Reload();
            }, 4);

            lst.Subscribe("sim/cockpit/switches/gear_handle_status", r =>
            {
                var bar = gaugeGear.Bars[0];
                bar.Pos = r.Value;
                bar.Extra = r.Value < 0 ? "OFF" : r.Value >= 1 ? "DOWN" : "PREPARED";
                gaugeGear.Reload();
            });
            lst.Subscribe("sim/flightmodel/movingparts/gear1def", r =>
            {
                gaugeGear.Bars[1].Pos = r.Value;
                gaugeGear.Reload();
            });

            lst.Subscribe("sim/cockpit2/controls/left_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[0].Pos = r.Value;
                gaugeWheelBrake.Reload();
            });
            lst.Subscribe("sim/cockpit2/controls/right_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[1].Pos = r.Value;
                gaugeWheelBrake.Reload();
            });

            lst.Subscribe("sim/flightmodel/controls/lsplrdef", r =>
            {
                gaugeSpoilers.Bars[0].Pos = r.Value;
                gaugeSpoilers.Reload();
            });
            lst.Subscribe("sim/flightmodel/controls/rsplrdef", r =>
            {
                gaugeSpoilers.Bars[1].Pos = r.Value;
                gaugeSpoilers.Reload();
            });

            lst.Subscribe("sim/flightmodel/controls/sbrkrqst", r =>
            {
                var bar = gaugeSpeedBrake.Bars[0];
                bar.Pos = r.Value;
                bar.Extra = r.Value < 0 ? "ARMED" : null;
                gaugeSpeedBrake.Reload();
            });
            lst.Subscribe("sim/flightmodel/controls/sbrkrat", r =>
            {
                gaugeSpeedBrake.Bars[1].Pos = r.Value;
                gaugeSpeedBrake.Reload();
            });

            lst.Subscribe("sim/cockpit2/controls/elevator_trim", r =>
            {
                gaugeElvTrim.Bars[0].Pos = r.Value + 1;
                gaugeElvTrim.Reload();
            });

            //--Engines
            lst.Subscribe("sim/aircraft/engine/acf_num_engines", r =>
            {
                gaugeThrottle.ShowBarsCount = (int)r.Value * 3;
                gaugeThrottle.Reload();
            });

            void updEngine(RefDataSubscription r, int barIndex)
            {
                gaugeThrottle.Bars[(r.ArrayIndex * 3) + barIndex].Pos = r.Value;
                gaugeThrottle.Reload();
            }

            lst.Subscribe("sim/cockpit2/engine/actuators/throttle_ratio", r => updEngine(r, 0), 4);
            lst.Subscribe("sim/cockpit2/engine/indicators/N1_percent", r => updEngine(r, 1), 4);
            lst.Subscribe("sim/cockpit2/engine/indicators/N2_percent", r => updEngine(r, 2), 4);
            //--
            
            return lst;
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

        private void SetRunwaySettingMode(RunwaySettingMode setting)
        {
            _runwaySettingMode = setting;

            btnSetRunwayBegin.Checked = setting == RunwaySettingMode.RUNWAY_BEGIN;
            btnSetRunwayEnd.Checked = setting == RunwaySettingMode.RUNWAY_END;
        }

        private void map_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (_runwaySettingMode == RunwaySettingMode.RUNWAY_BEGIN)
            {
                _runwayBegin = pointClick;
                SetRunwaySettingMode(RunwaySettingMode.RUNWAY_END);
            }
            else if (_runwaySettingMode == RunwaySettingMode.RUNWAY_END)
            {
                _runwayEnd = pointClick;
                SetRunwaySettingMode(RunwaySettingMode.NONE);
            }

            UpdateRunwayPointsLabel();
            CheckRunwayPoints();
        }

        private void UpdateRunwayPointsLabel()
        {
            bool none = !_runwayBegin.HasValue && !_runwayEnd.HasValue;
            bool all = _runwayBegin.HasValue && _runwayEnd.HasValue;

            lbRunwayPoints.Value = none ? "NOT SET" : (_runwayBegin.HasValue ? "[<]" : "") + (_runwayEnd.HasValue ? "[>]" : "");
            lbRunwayPoints.ForeColor = none ? Color.Gray : all ? Color.Green : Color.Red;
        }

        private void CheckRunwayPoints()
        {
            if (_runwayBegin.HasValue && _runwayEnd.HasValue)
            {
                _runwayHeading = (float)GeoCalculator.CalculateBearing(
                    _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                    _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

                var elevMeters = AltitudeApi.GetElevationMeters(_runwayBegin.Value.Lat, _runwayBegin.Value.Lng);

                var size = GeoCalculator.CalculateDistance(
                    _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                    _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

                _runwayElevation = (float)GeoCalculator.ConvertMetersToFeet(elevMeters);

                lbRunwayElevation.Value = elevMeters.ToString() + " m / " + Utils.RoundToInt(_runwayElevation) + " ft";
                lbRunwayDegrees.Value = Utils.RoundToInt(_runwayHeading).ToString() + "º";
                lbRunwaySize.Value = Utils.RoundToInt(size * 1000).ToString() + " m";

                var approach = GeoCalculator.CalculateDestinationPoint(_runwayBegin.Value.Lat, _runwayBegin.Value.Lng, GeoCalculator.InvertDegree(_runwayHeading), 22);

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
                _runwayDistance = (float)GeoCalculator.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat.Value, _lng.Value, _runwayBegin.Value.Lat, _runwayBegin.Value.Lng));

                lbApproachDist.Value = Math.Round(GeoCalculator.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat.Value, _lng.Value, _runwayApproach.Value.Lat, _runwayApproach.Value.Lng)), 1) + " nm";
                lbRunwayDist.Value = Math.Round(_runwayDistance, 1) + " nm";

                _spacing = (float)ProximityCalculator.CalcularDistanciaAteLinhaAeroporto2(
                    new double[] { _runwayBegin.Value.Lat, _runwayBegin.Value.Lng },
                    new double[] { _runwayEnd.Value.Lat, _runwayEnd.Value.Lng },
                    new double[] { _lat.Value, _lng.Value });

                lbSpacing.Value = Utils.RoundToInt(_spacing) + " m";

                boxRamp.Invalidate();
                boxSpacing.Invalidate();
            }
        }

        private void btnSetRunwayBegin_Click(object sender, EventArgs e)
        {
            if (!btnSetRunwayBegin.Checked)
            {
                SetRunwaySettingMode(RunwaySettingMode.RUNWAY_BEGIN);
            }
            else
            {
                SetRunwaySettingMode(RunwaySettingMode.NONE);
            }
        }

        private void btnSetRunwayEnd_Click(object sender, EventArgs e)
        {
            if (!btnSetRunwayEnd.Checked)
            {
                SetRunwaySettingMode(RunwaySettingMode.RUNWAY_END);
            }
            else
            {
                SetRunwaySettingMode(RunwaySettingMode.NONE);
            }
        }

        private void btnClearRunwayApproach_Click(object sender, EventArgs e)
        {
            SetRunwaySettingMode(RunwaySettingMode.NONE);

            _runwayBegin = null;
            _runwayEnd = null;
            _runwayApproach = null;

            _runwayRoute.Points.Clear();
            map.UpdateRouteLocalPosition(_runwayRoute);

            UpdateRunwayPointsLabel();
            lbRunwayElevation.Value = string.Empty;
            lbRunwayDegrees.Value = string.Empty;
            lbRunwaySize.Value = string.Empty;
            lbApproachDist.Value = string.Empty;
            lbRunwayDist.Value = string.Empty;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            map.Manager.CancelTileCaching();

            if (_communicator.Status == ConnectionStatus.CONNECTED)
            {
                _communicator.Disconnect();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _communicator.Connect(Vars.Cfg.Host, Vars.Cfg.Port);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _communicator.Disconnect();
        }

        private void boxRamp_Paint(object sender, PaintEventArgs e)
        {
            var rampDistance = Vars.Cfg.RampDistance;
            var rampHeight = Vars.Cfg.RampElevation;

            var fullDistance = rampDistance * 1.25;
            if (_runwayDistance > fullDistance) return;

            var fullHeight = rampHeight * 1.5;

            var aircraftHeight = _altitude - _runwayElevation;

            double calcX(float distance)
            {
                return boxRamp.Width - ((distance / fullDistance) * boxRamp.Width);
            }
            double calcY(float height)
            {
                return boxRamp.Height - ((height / fullHeight) * boxRamp.Height);
            }

            e.Graphics.FillRectangle(Brushes.Black, boxRamp.ClientRectangle);
            e.Graphics.DrawLine(new Pen(Color.Red, 3), (float)calcX(_runwayDistance), (float)calcY(aircraftHeight), boxRamp.Width, boxRamp.Height); //real
            e.Graphics.DrawLine(new Pen(Color.Green), (float)calcX(rampDistance), (float)calcY(rampHeight), boxRamp.Width, boxRamp.Height); //ideal
        }

        private void boxSpacing_Paint(object sender, PaintEventArgs e)
        {
            const int margin = 250;
            var s = _spacing;
            if (s > margin) s = margin;
            if (s < -margin) s = -margin;

            s += margin;

            var x = boxSpacing.Width * s / (margin*2);

            var xIdeal = boxSpacing.Width / 2;

            e.Graphics.FillRectangle(Brushes.Black, boxSpacing.ClientRectangle);
            //e.Graphics.DrawLine(new Pen(Color.Purple, 3), x, 0, x, boxSpacing.Height);
            e.Graphics.DrawLine(new Pen(Color.Green), xIdeal, 0, xIdeal, boxSpacing.Height);

            //

            double angleInDegrees = 90 + (_runwayHeading - _headingTrue); // Ângulo em graus

            // Converter o ângulo de graus para radianos
            double angleInRadians = angleInDegrees * (Math.PI / 180);

            var endX = x + (boxSpacing.Height / Math.Tan(angleInRadians));

            e.Graphics.DrawLine(new Pen(Color.Purple, 3), (float)endX, 0, x, boxSpacing.Height);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig f = new();
            f.ShowDialog();
        }
    }
}