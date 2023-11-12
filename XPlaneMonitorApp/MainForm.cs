using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Diagnostics;
using XPlaneMonitorApp.Communicator;
using XPlaneMonitorApp.Config;
using XPlaneMonitorApp.Controls;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private const float LIGHT_COLOR = 0.5f;

        private const double RAMP_DISTANCE_FATOR = 1.25;
        private const double RAMP_ALTITUDE_FATOR = 1.5;

        private XPlaneCommunicator _communicator;

        private readonly GMapOverlay _mapOverlay = new();
        private readonly GMapRoute _mapRoute = new("flight");
        private readonly GMapRoute _runwayRoute = new("runway");

        private readonly AircraftMarker _aircraftMarker = new(new PointLatLng(), GMarkerGoogleType.blue_dot);
        private readonly GMarkerGoogle _runwayApproachMarker = new(new PointLatLng(), GMarkerGoogleType.purple_small);
        private readonly GMarkerGoogle _runwayBeginMarker = new(new PointLatLng(), GMarkerGoogleType.green_small);
        private readonly GMarkerGoogle _runwayEndMarker = new(new PointLatLng(), GMarkerGoogleType.red_small);

        private long _ammountDataReceived;

        private PointLatLng _location = new(-23.4305305, -46.4696579);

        private double _runwayElevation;
        private double _runwayHeadingTrue;
        private double _runwayDistance;
        private double _spacing;

        private enum RunwaySettingMode
        {
            NONE,
            RUNWAY_BEGIN,
            RUNWAY_END
        }
        private RunwaySettingMode _runwaySettingMode = RunwaySettingMode.NONE;

        private PointLatLng? _runwayBegin, _runwayEnd, _runwayApproach, _lastAirportRetrievedAltitude;

        public MainForm()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            stVersion.Text = "Version " + Vars.VERSION;

            stLastTimeRec.Text = string.Empty;
            stSimTimeElapsed.Text = string.Empty;
            stAmmountDataReceived.Text = string.Empty;
            stFlightDistance.Text = string.Empty;
            stScenaryClock.Text = string.Empty;
            stMagneticVariation.Text = string.Empty;
            stTrueHeading.Text = string.Empty;
            stTrueAltitude.Text = string.Empty;

            toolBar.ImageScalingSize = new Size(toolBar.Height - 9, toolBar.Height - 9); //multi DPI support

            WinDarkMode.UseImmersiveDarkMode(this.Handle);
            TSRenderer.SetToolStrip(toolBar);
            TSRenderer.SetStatusStrip(statusBar);
        }

        private void ScaleControls()
        {
            const int FIRST_LINE_TOP = 40;

            const int DESIGN_BLOCK_WIDTH = 280;
            const int DESIGN_BLOCK_HEIGHT = 8;

            const int SPACE = 4;

            var blockW = ClientSize.Width / 6;
            var blockH = (ClientSize.Height - toolBar.Height - statusBar.Height) / 110;

            foreach (Control c in this.Controls)
            {
                if (c is GaugePanel || c is ParamPanel || c is GMapControl || c is GridPanel)
                {
                    if (c.Tag == null)
                    {
                        if (c.Left % DESIGN_BLOCK_WIDTH != 0) throw new Exception("Invalid control left");
                        if (c.Width % DESIGN_BLOCK_WIDTH != 0) throw new Exception("Invalid control width");
                        if (c.Top % DESIGN_BLOCK_HEIGHT != 0) throw new Exception("Invalid control top");
                        if (c.Height % DESIGN_BLOCK_HEIGHT != 0) throw new Exception("Invalid control height");
                        c.Tag = new int[] {
                            c.Left / DESIGN_BLOCK_WIDTH, c.Width / DESIGN_BLOCK_WIDTH,
                            (c.Top-FIRST_LINE_TOP) / DESIGN_BLOCK_HEIGHT, c.Height / DESIGN_BLOCK_HEIGHT
                        };
                    }

                    var t = (int[])c.Tag;

                    c.Left = (blockW * t[0]) + (SPACE / 2);
                    c.Width = (blockW * t[1]) - SPACE;

                    c.Top = (blockH * t[2]) + toolBar.Height + SPACE;
                    c.Height = (blockH * t[3]) - SPACE;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigEngine.Load();
            InitMap();
            BuildGaugeBars();

            ScaleControls();

            _communicator = new(GetRefDataContractList(), this);
            _communicator.OnReceived += OnDataRefReceived;
            _communicator.OnStatusChanged += OnStatusChanged;

            OnStatusChanged(); //update connection buttons

            UpdateRunwayPointsLabel();
        }

        private void InitMap()
        {
            map.MapProvider = OpenStreetMapProvider.Instance;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.MaxZoom = 20;
            map.MinZoom = 0;
            map.Zoom = 14;
            map.Overlays.Add(_mapOverlay);

            _mapOverlay.Routes.Add(_runwayRoute);
            _mapOverlay.Routes.Add(_mapRoute);

            _mapOverlay.Markers.Add(_aircraftMarker);
            _mapOverlay.Markers.Add(_runwayApproachMarker);
            _mapOverlay.Markers.Add(_runwayBeginMarker);
            _mapOverlay.Markers.Add(_runwayEndMarker);

            _runwayRoute.Stroke = (Pen)_runwayRoute.Stroke.Clone();
            _runwayRoute.Stroke.Color = Color.Orange;

            _mapRoute.Stroke = (Pen)_mapRoute.Stroke.Clone();
            _mapRoute.Stroke.Color = Color.Gray;

            _aircraftMarker.IsVisible = false;
            _runwayApproachMarker.IsVisible = false;
            _runwayBeginMarker.IsVisible = false;
            _runwayEndMarker.IsVisible = false;

            ReloadMapParams();
            GotoPositionOnMap();
        }

        private void ReloadMapParams()
        {
            map.NegativeMode = Vars.Cfg.MapDarkMode;
        }

        private void BuildGaugeBars()
        {
            gaugeFlaps.AddBar("Requested", ControlPaint.Light(Color.Green, LIGHT_COLOR), 1);
            gaugeFlaps.AddBar("Actual", Color.Green, 1);

            gaugeElvTrim.AddBar(null, Color.Gold, 2);

            gaugeGear.AddBar("Requested", ControlPaint.Light(Color.Firebrick, LIGHT_COLOR), 1, true);
            gaugeGear.AddBar("Actual", Color.Firebrick, 1);

            gaugeSpoilers.AddBar("Left", Color.Purple, 20);
            gaugeSpoilers.AddBar("Right", Color.Purple, 20);

            gaugeSpeedBrake.AddBar("Requested", ControlPaint.Light(Color.MediumBlue, LIGHT_COLOR), 1);
            gaugeSpeedBrake.AddBar("Actual", Color.MediumBlue, 1);

            gaugeWheelBrake.AddBar("Left", Color.MediumPurple, 1);
            gaugeWheelBrake.AddBar("Right", Color.MediumPurple, 1);

            gaugeAPU.AddBar("Switch", ControlPaint.Light(Color.SteelBlue, LIGHT_COLOR), 1, true);
            gaugeAPU.AddBar("N1", Color.SteelBlue, 100);

            for (int i = 0; i < MAX_ENGINES; i++)
            {
                gaugeThrottle.AddBar(string.Format("[{0}] Throttle", i+1), ControlPaint.Light(Color.SaddleBrown, LIGHT_COLOR * 2), 1);
                gaugeThrottle.AddBar(string.Format("[{0}] N1", i+1), ControlPaint.Light(Color.SaddleBrown, LIGHT_COLOR), 100);
                gaugeThrottle.AddBar(string.Format("[{0}] N2", i+1), Color.SaddleBrown, 100);
            }

            for (int i = 0; i < MAX_TANKS; i++)
            {
                gaugeFuel.AddBar(string.Format("Tank {0}", i+1), Color.LightSeaGreen, 1); //initial Max=1 only to better initial show, because max will be replaced when connected
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            map.Manager.CancelTileCaching();

            if (_communicator.Status == ConnectionStatus.CONNECTED)
            {
                _communicator.Disconnect();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ScaleControls();
        }

        private void stDigaoDalpiaz_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/digao-dalpiaz/XPlaneMonitor");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _ammountDataReceived = 0;
            _communicator.Connect(Vars.Cfg.Host, Vars.Cfg.Port);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _communicator.Disconnect();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig f = new();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ReloadMapParams();

                //force update drawing boxes here, because BuildApproch may exit if runway not defined
                UpdateGrids();

                BuildApproach();
            }
        }

        private void OnDataRefReceived(int size)
        {
            _ammountDataReceived += size;
            var bytesReceived = _ammountDataReceived / 1024; //integer value, so result is integer too!

            stLastTimeRec.Text = "Last package received: " + DateTime.Now.ToString("HH:mm:ss");
            stAmmountDataReceived.Text = "Ammount data received: " + bytesReceived + " kb";
        }

        private void OnStatusChanged()
        {
            btnConnect.Enabled = _communicator.Status == ConnectionStatus.DISCONNECTED;
            btnDisconnect.Enabled = _communicator.Status == ConnectionStatus.CONNECTED;

            stConnStatus.Text = _communicator.Status switch
            {
                ConnectionStatus.CONNECTED => "Connected",
                ConnectionStatus.DISCONNECTED => "Disconnected",
                ConnectionStatus.CONNECTING => "Connecting...",
                _ => throw new Exception("Invalid connection status"),
            };
        }

        private void btnCenterMap_Click(object sender, EventArgs e)
        {
            GotoPositionOnMap();
        }

        private void btnClearRoute_Click(object sender, EventArgs e)
        {
            _mapRoute.Points.Clear();
            map.UpdateRouteLocalPosition(_mapRoute);
            map.Invalidate(); //there is a bug in GMap when clearing route
        }

        private void map_OnMapDrag()
        {
            btnCenterMap.Enabled = true;
        }

        private void map_OnMapZoomChanged()
        {
            map_OnMapDrag();
        }

        private void btnGotoGooglePoint_Click(object sender, EventArgs e)
        {
            PointLatLng p;

            try
            {
                p = GoogleMapsLinkDecoder.ReadFromClipboard();
            }
            catch (MsgException exMsg)
            {
                Messages.Error(exMsg.Message);
                return;
            }

            map.Position = p;

            map_OnMapDrag();
        }

        private void GotoPositionOnMap()
        {
            map.Position = _location;

            btnCenterMap.Enabled = false;
        }

        private void ReceivedAircraftPosition()
        {
            var pos = _location;
            _aircraftMarker.Position = pos;
            _aircraftMarker.IsVisible = true;

            if (!btnCenterMap.Enabled)
            {
                map.Position = pos;
            }

            _mapRoute.Points.Add(pos);
            map.UpdateRouteLocalPosition(_mapRoute);

            UpdateApproachParams();
        }

        private void SetRunwaySettingMode(RunwaySettingMode setting)
        {
            _runwaySettingMode = setting;

            btnSetRunwayBegin.Checked = setting == RunwaySettingMode.RUNWAY_BEGIN;
            btnSetRunwayEnd.Checked = setting == RunwaySettingMode.RUNWAY_END;
        }

        private void map_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            bool someDefined = false;

            if (_runwaySettingMode == RunwaySettingMode.RUNWAY_BEGIN)
            {
                _runwayBegin = pointClick;
                _runwayBeginMarker.Position = pointClick;
                _runwayBeginMarker.IsVisible = true;
                SetRunwaySettingMode(RunwaySettingMode.RUNWAY_END);
                someDefined = true;
            }
            else if (_runwaySettingMode == RunwaySettingMode.RUNWAY_END)
            {
                _runwayEnd = pointClick;
                _runwayEndMarker.Position = pointClick;
                _runwayEndMarker.IsVisible = true;
                SetRunwaySettingMode(RunwaySettingMode.NONE);
                someDefined = true;
            }

            if (someDefined)
            {
                map.Refresh(); //force refresh map before getting airport altitude on the Internet

                UpdateRunwayPointsLabel();
                BuildApproach();
            }
        }

        private void UpdateRunwayPointsLabel()
        {
            bool none = !_runwayBegin.HasValue && !_runwayEnd.HasValue;
            bool all = _runwayBegin.HasValue && _runwayEnd.HasValue;

            lbRunwayPoints.Value = none ? "NOT SET" : (_runwayBegin.HasValue ? "[<]" : "") + (_runwayEnd.HasValue ? "[>]" : "");
            lbRunwayPoints.ForeColor = none ? Color.Gray : all ? Color.Green : Color.Red;

            btnClearRunwayApproach.Enabled = !none;
        }

        private void BuildApproach()
        {
            if (!_runwayBegin.HasValue || !_runwayEnd.HasValue) return;

            if (_lastAirportRetrievedAltitude != _runwayBegin)
            {
                lbRunwayElevation.Value = "wait...";
                lbRunwayElevation.Refresh();
                try
                {
                    var elevMeters = AltitudeApi.GetElevationMeters(_runwayBegin.Value);
                    _runwayElevation = Utils.ConvertMetersToFeet(elevMeters);

                    _lastAirportRetrievedAltitude = _runwayBegin;
                }
                catch (Exception ex)
                {
                    _runwayElevation = 0;
                    Messages.Error(ex.Message);
                }
            }

            _runwayHeadingTrue = GeoCalculator.CalculateBearing(_runwayBegin.Value, _runwayEnd.Value);

            var sizeKm = GeoCalculator.CalculateDistance(_runwayBegin.Value, _runwayEnd.Value);

            lbRunwayElevation.Value = Utils.RoundToInt(_runwayElevation + Vars.Cfg.RampElevation) + ">" + Utils.RoundToInt(_runwayElevation) + " ft";
            lbRunwaySize.Value = Utils.RoundToInt(sizeKm * 1000) + " m";

            _runwayApproach = GeoCalculator.CalculateDestinationPoint(
                _runwayBegin.Value,
                Utils.InvertDegree(_runwayHeadingTrue),
                Utils.ConvertNauticalMilesToKm(Vars.Cfg.RampDistance));

            _runwayApproachMarker.Position = _runwayApproach.Value;
            _runwayApproachMarker.IsVisible = true;

            _runwayRoute.Points.Clear();
            _runwayRoute.Points.Add(_runwayApproach.Value);
            _runwayRoute.Points.Add(_runwayBegin.Value);
            _runwayRoute.Points.Add(_runwayEnd.Value);
            map.UpdateRouteLocalPosition(_runwayRoute);
            map.Invalidate(); //there is a bug in GMap when clearing route

            if (_aircraftMarker.IsVisible) UpdateApproachParams();
        }

        private void UpdateApproachParams()
        {
            if (_runwayBegin.HasValue && _runwayEnd.HasValue && _runwayApproach.HasValue)
            {
                var approachDistKm = GeoCalculator.CalculateDistance(_location, _runwayApproach.Value);
                var approachDist = Utils.ConvertKmToNauticalMiles(approachDistKm);

                var runwayDistKm = GeoCalculator.CalculateDistance(_location, _runwayBegin.Value);
                _runwayDistance = Utils.ConvertKmToNauticalMiles(runwayDistKm);

                bool insideRamp = IsDistanceInsideRamp(); //must stay after runwayDistance set!

                lbApproachTime.Value = Utils.SecondsToTime(approachDistKm * 1000 / _groundSpeedMS);
                lbRunwayTime.Value = Utils.SecondsToTime(runwayDistKm * 1000 / _groundSpeedMS);

                lbApproachDist.Value = Math.Round(approachDist, 1).ToString("0.0") + " nm";
                lbRunwayDist.Value = Math.Round(_runwayDistance, 1).ToString("0.0") + " nm";

                var verticalSpeed = Utils.RoundToInt(Utils.CalculateVerticalRatioInFtPerMin(
                    _altitudeTrue, _runwayElevation + (insideRamp ? 0 : Vars.Cfg.RampElevation), _groundSpeedMS, insideRamp ? _runwayDistance : approachDist));
                lbIdealVS.Value = (verticalSpeed > 0 ? "+" : "") + verticalSpeed + " ft/min";
                lbIdealVS.Title = insideRamp ? "Runway Ideal VS." : "Approach Ideal VS.";

                var runwayCentralPoint = GeoCalculator.CalculateCentralPoint(_runwayBegin.Value, _runwayEnd.Value);
                lbAirportAngle.Value =
                    Utils.RoundToInt(Utils.AddAngles(GeoCalculator.CalculateBearing(_location, _runwayApproach.Value), _magneticVariation)) +
                    ">" +
                    Utils.RoundToInt(Utils.AddAngles(GeoCalculator.CalculateBearing(_location, runwayCentralPoint), _magneticVariation)) + "º";

                _spacing = ProximityCalculator.CalculateLongitudinalClearance(_runwayBegin.Value, _runwayEnd.Value, _location);

                lbSpacing.Value = Math.Abs(_spacing) > 1000 ? "FAR AWAY" : Utils.RoundToInt(_spacing) + " m";

                UpdateGrids();
            }
        }

        private void DoButtonRunwayClick(ToolStripButton btn, RunwaySettingMode mode)
        {
            if (!btn.Checked)
            {
                SetRunwaySettingMode(mode);
            }
            else
            {
                SetRunwaySettingMode(RunwaySettingMode.NONE);
            }
        }

        private void btnSetRunwayBegin_Click(object sender, EventArgs e)
        {
            DoButtonRunwayClick(btnSetRunwayBegin, RunwaySettingMode.RUNWAY_BEGIN);
        }

        private void btnSetRunwayEnd_Click(object sender, EventArgs e)
        {
            DoButtonRunwayClick(btnSetRunwayEnd, RunwaySettingMode.RUNWAY_END);
        }

        private void btnClearRunwayApproach_Click(object sender, EventArgs e)
        {
            SetRunwaySettingMode(RunwaySettingMode.NONE);

            _runwayBegin = null;
            _runwayEnd = null;
            _runwayApproach = null;

            _runwayBeginMarker.IsVisible = false;
            _runwayEndMarker.IsVisible = false;
            _runwayApproachMarker.IsVisible = false;

            _runwayRoute.Points.Clear();
            map.UpdateRouteLocalPosition(_runwayRoute);
            map.Invalidate(); //there is a bug in GMap when clearing route

            UpdateRunwayPointsLabel();
            
            lbRunwayElevation.Value = string.Empty;
            lbRunwaySize.Value = string.Empty;

            lbApproachDist.Value = string.Empty;
            lbApproachTime.Value = string.Empty;
            lbRunwayDist.Value = string.Empty;
            lbRunwayTime.Value = string.Empty;

            lbIdealVS.Title = "App/Rw. Ideal VS.";
            lbIdealVS.Value = string.Empty;

            lbAirportAngle.Value = string.Empty;
            lbSpacing.Value = string.Empty;

            UpdateGrids();
        }

        private void UpdateGrids()
        {
            gridDescentRamp.Reload();
            gridAlignment.Reload();
        }

        private bool IsDistanceInsideRamp()
        {
            return _runwayDistance <= (Vars.Cfg.RampDistance * RAMP_DISTANCE_FATOR);
        }

        private bool IsNotSetOrFarAwayFromAirport()
        {
            return !_aircraftMarker.IsVisible || !_runwayApproach.HasValue || !IsDistanceInsideRamp();
        }

        private void boxRamp_Paint(object sender, PaintEventArgs e)
        {
            var r = e.Graphics.ClipBounds;

            var rampDistance = Vars.Cfg.RampDistance;
            var rampHeight = Vars.Cfg.RampElevation;

            var fullDistance = rampDistance * RAMP_DISTANCE_FATOR;
            var fullHeight = rampHeight * RAMP_ALTITUDE_FATOR;

            Utils.DrawGrid(e.Graphics, 1, fullDistance, 500, fullHeight, r);
            //

            if (IsNotSetOrFarAwayFromAirport()) return;

            double calcX(double distance)
            {
                return r.Width - (Utils.Div(distance, fullDistance) * r.Width);
            }
            double calcY(double height)
            {
                return r.Height - (Utils.Div(height, fullHeight) * r.Height);
            }

            var airplaneX = calcX(_runwayDistance);
            var airplaneY = calcY(_altitudeTrue - _runwayElevation);

            Drawing.DrawLine(e.Graphics, new Pen(Color.Red, 3), airplaneX, airplaneY, r.Width, r.Height); //real
            Drawing.DrawLine(e.Graphics, new Pen(Color.Green), calcX(rampDistance), calcY(rampHeight), r.Width, r.Height); //ideal

            var airplaneImg = Properties.Resources.airplane_ramp;
            Drawing.DrawImage(e.Graphics, airplaneImg, airplaneX - Utils.Div(airplaneImg.Width, 2), airplaneY - Utils.Div(airplaneImg.Height, 2));
        }

        private void boxSpacing_Paint(object sender, PaintEventArgs e)
        {
            var r = e.Graphics.ClipBounds;

            const int marginSide = 250; //meters
            const int marginFull = marginSide * 2; //meters
            Utils.DrawGrid(e.Graphics, 50, marginFull, 1, 1, r);
            //

            if (IsNotSetOrFarAwayFromAirport()) return;

            var xIdeal = Utils.Div(r.Width, 2);
            Drawing.DrawLine(e.Graphics, new Pen(Color.Green), xIdeal, 0, xIdeal, r.Height);

            //

            var s = _spacing; //meters
            if (s > marginSide) s = marginSide; else if (s < -marginSide) s = -marginSide;
            s += marginSide; //move half side to the right

            var difAngle = _runwayHeadingTrue - _headingTrue;
            var airplaneImg = Drawing.RotateImage(Properties.Resources.airplane_align, -difAngle);
            var lineHeight = r.Height - Utils.Div(airplaneImg.Height, 2);

            var startX = Utils.RuleOfThree(marginFull, s, r.Width);
            var endX = startX + Utils.Div(lineHeight, Math.Tan(Utils.DegreesToRadians(90 + difAngle)));

            Drawing.DrawLine(e.Graphics, new Pen(Color.Purple, 3), endX, 0, startX, lineHeight);
            Drawing.DrawImage(e.Graphics, airplaneImg, startX - Utils.Div(airplaneImg.Width, 2), r.Height - airplaneImg.Height);
        }

    }
}