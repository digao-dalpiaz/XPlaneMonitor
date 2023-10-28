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

        private double _lat = -23.4305305;
        private double _lng = -46.4696579;

        private double _runwayElevation;
        private double _runwayHeading;
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
            stSimTime.Text = string.Empty;
            stAmmountDataReceived.Text = string.Empty;
            stFlightDistance.Text = string.Empty;

            Utils.SetDoubleBuffered(boxRamp);
            Utils.SetDoubleBuffered(boxSpacing);

            WinDarkMode.UseImmersiveDarkMode(this.Handle);
            TSRenderer.SetToolStrip(toolBar);
            TSRenderer.SetStatusStrip(statusBar);
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

            GotoPositionOnMap();
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

            for (int i = 0; i < 4; i++)
            {
                gaugeThrottle.AddBar(string.Format("[{0}] Throttle", i+1), ControlPaint.Light(Color.Salmon, LIGHT_COLOR * 2), 1);
                gaugeThrottle.AddBar(string.Format("[{0}] N1", i+1), ControlPaint.Light(Color.Salmon, LIGHT_COLOR), 100);
                gaugeThrottle.AddBar(string.Format("[{0}] N2", i+1), Color.Salmon, 100);

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
                //force update drawing boxes here, because BuildApproch may exit if runway not defined
                UpdateGrids();

                BuildApproach();
            }
        }

        private void OnDataRefReceived(int size)
        {
            _ammountDataReceived += size;
            var bytesReceived = _ammountDataReceived / 1024; //integer value, so result is integer too!

            stLastTimeRec.Text = "Last data received: " + DateTime.Now.ToString("HH:mm:ss");
            stAmmountDataReceived.Text = "Ammount data received: " + bytesReceived + " kb";
        }

        private void OnStatusChanged()
        {
            btnConnect.Enabled = _communicator.Status == ConnectionStatus.DISCONNECTED;
            btnDisconnect.Enabled = _communicator.Status == ConnectionStatus.CONNECTED;

            switch (_communicator.Status)
            {
                case ConnectionStatus.CONNECTED:
                    stConnStatus.Text = "Connected";
                    break;
                case ConnectionStatus.DISCONNECTED:
                    stConnStatus.Text = "Disconnected";
                    break;
                case ConnectionStatus.CONNECTING:
                    stConnStatus.Text = "Connecting...";
                    break;
                default:
                    throw new Exception("Invalid connection status");
            }
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
            PointLatLng? p = null;

            if (Messages.SurroundMsgException(() =>
            {
                p = GoogleMapsLinkDecoder.ReadFromClipboard();
            })) return;

            map.Position = p.Value;

            map_OnMapDrag();
        }

        private void GotoPositionOnMap()
        {
            map.Position = new PointLatLng(_lat, _lng);

            btnCenterMap.Enabled = false;
        }

        private void ReceivedAircraftPosition()
        {
            var pos = new PointLatLng(_lat, _lng);
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
                    var elevMeters = AltitudeApi.GetElevationMeters(_runwayBegin.Value.Lat, _runwayBegin.Value.Lng);
                    _runwayElevation = Utils.ConvertMetersToFeet(elevMeters);

                    _lastAirportRetrievedAltitude = _runwayBegin;
                }
                catch (Exception ex)
                {
                    _runwayElevation = 0;
                    lbRunwayElevation.Value = "fail!!!";
                    Messages.Error(ex.Message);
                }
            }

            _runwayHeading = GeoCalculator.CalculateBearing(
                _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

            var sizeKm = GeoCalculator.CalculateDistance(
                _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                _runwayEnd.Value.Lat, _runwayEnd.Value.Lng);

            lbRunwayElevation.Value = Utils.RoundToInt(_runwayElevation) + " ft";
            lbRunwayHeadingTrue.Value = Utils.RoundToInt(_runwayHeading) + "º";
            lbRunwaySize.Value = Utils.RoundToInt(sizeKm * 1000) + " m";

            var approach = GeoCalculator.CalculateDestinationPoint(
                _runwayBegin.Value.Lat, _runwayBegin.Value.Lng,
                Utils.InvertDegree(_runwayHeading),
                Utils.ConverterMilhaNauticaParaKm(Vars.Cfg.RampDistance));

            _runwayApproach = new PointLatLng(approach.Item1, approach.Item2);
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
                var approachDist = Utils.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat, _lng, _runwayApproach.Value.Lat, _runwayApproach.Value.Lng));

                _runwayDistance = Utils.ConverterKmParaMilhaNautica(
                    GeoCalculator.CalculateDistance(_lat, _lng, _runwayBegin.Value.Lat, _runwayBegin.Value.Lng));

                lbApproachDist.Value = Math.Round(approachDist, 1).ToString("0.0") + " nm";
                lbRunwayDist.Value = Math.Round(_runwayDistance, 1).ToString("0.0") + " nm";

                _spacing = ProximityCalculator.CalcularDistanciaAteLinhaAeroporto2(
                    new double[] { _runwayBegin.Value.Lat, _runwayBegin.Value.Lng },
                    new double[] { _runwayEnd.Value.Lat, _runwayEnd.Value.Lng },
                    new double[] { _lat, _lng });

                lbSpacing.Value = Utils.RoundToInt(_spacing) + " m";
                lbRunwayHeadingMag.Value = Utils.RoundToInt(_runwayHeading + _magneticVariation) + "º";

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
            lbRunwayHeadingTrue.Value = string.Empty;
            lbRunwaySize.Value = string.Empty;
            lbApproachDist.Value = string.Empty;
            lbRunwayDist.Value = string.Empty;

            lbSpacing.Value = string.Empty;
            lbRunwayHeadingMag.Value = string.Empty;

            UpdateGrids();
        }

        private void UpdateGrids()
        {
            boxRamp.Invalidate();
            boxSpacing.Invalidate();
        }

        private bool IsNotSetOrFarAwayFromAirport()
        {
            return !_aircraftMarker.IsVisible || !_runwayApproach.HasValue || _runwayDistance > (Vars.Cfg.RampDistance * RAMP_DISTANCE_FATOR);
        }

        private void boxRamp_Paint(object sender, PaintEventArgs e)
        {
            var rampDistance = Vars.Cfg.RampDistance;
            var rampHeight = Vars.Cfg.RampElevation;

            var fullDistance = rampDistance * RAMP_DISTANCE_FATOR;
            var fullHeight = rampHeight * RAMP_ALTITUDE_FATOR;

            Utils.DrawGrid(e.Graphics, 1, fullDistance, 500, fullHeight, boxRamp.ClientRectangle);
            //

            if (IsNotSetOrFarAwayFromAirport()) return;

            double calcX(double distance)
            {
                return boxRamp.Width - (Utils.Div(distance, fullDistance) * boxRamp.Width);
            }
            double calcY(double height)
            {
                return boxRamp.Height - (Utils.Div(height, fullHeight) * boxRamp.Height);
            }

            var airplaneX = calcX(_runwayDistance);
            var airplaneY = calcY(_altitudeTrue - _runwayElevation);

            Drawing.DrawLine(e.Graphics, new Pen(Color.Red, 3), airplaneX, airplaneY, boxRamp.Width, boxRamp.Height); //real
            Drawing.DrawLine(e.Graphics, new Pen(Color.Green), calcX(rampDistance), calcY(rampHeight), boxRamp.Width, boxRamp.Height); //ideal

            var airplaneImg = Properties.Resources.airplane_ramp;
            Drawing.DrawImage(e.Graphics, airplaneImg, airplaneX - Utils.Div(airplaneImg.Width, 2), airplaneY - Utils.Div(airplaneImg.Height, 2));
        }

        private void boxSpacing_Paint(object sender, PaintEventArgs e)
        {
            const int marginSide = 250; //meters
            const int marginFull = marginSide * 2; //meters
            Utils.DrawGrid(e.Graphics, 50, marginFull, 1, 1, boxSpacing.ClientRectangle);
            //

            if (IsNotSetOrFarAwayFromAirport()) return;

            var xIdeal = Utils.Div(boxSpacing.Width, 2);
            Drawing.DrawLine(e.Graphics, new Pen(Color.Green), xIdeal, 0, xIdeal, boxSpacing.Height);

            //

            var s = _spacing; //meters
            if (s > marginSide) s = marginSide; else if (s < -marginSide) s = -marginSide;
            s += marginSide; //move half side to the right

            var difAngle = _runwayHeading - _headingTrue;
            var airplaneImg = Drawing.RotateImage(Properties.Resources.airplane_align, -difAngle);
            var lineHeight = boxSpacing.Height - Utils.Div(airplaneImg.Height, 2);

            var startX = Utils.RuleOfThree(marginFull, s, boxSpacing.Width);
            var endX = startX + Utils.Div(lineHeight, Math.Tan(Utils.DegreesToRadians(90 + difAngle)));

            Drawing.DrawLine(e.Graphics, new Pen(Color.Purple, 3), endX, 0, startX, lineHeight);
            Drawing.DrawImage(e.Graphics, airplaneImg, startX - Utils.Div(airplaneImg.Width, 2), boxSpacing.Height - airplaneImg.Height);
        }

    }
}