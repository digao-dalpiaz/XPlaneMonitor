namespace XPlaneMonitorApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gaugeFlaps=new GaugePanel();
            gaugeThrottle=new GaugePanel();
            map=new GMap.NET.WindowsForms.GMapControl();
            gaugeElvTrim=new GaugePanel();
            toolBar=new ToolStrip();
            btnConnect=new ToolStripButton();
            btnDisconnect=new ToolStripButton();
            toolStripSeparator1=new ToolStripSeparator();
            btnGotoGooglePoint=new ToolStripButton();
            btnCenterMap=new ToolStripButton();
            btnClearRoute=new ToolStripButton();
            toolStripSeparator3=new ToolStripSeparator();
            btnSetRunwayBegin=new ToolStripButton();
            btnSetRunwayEnd=new ToolStripButton();
            btnClearRunwayApproach=new ToolStripButton();
            toolStripSeparator2=new ToolStripSeparator();
            btnConfig=new ToolStripButton();
            gaugeFuel=new GaugePanel();
            gaugeGear=new GaugePanel();
            gaugeSpoilers=new GaugePanel();
            gaugeSpeedBrake=new GaugePanel();
            gaugeWheelBrake=new GaugePanel();
            lbAirSpeed=new Controls.ParamPanel();
            lbVerticalSpeed=new Controls.ParamPanel();
            lbGroundSpeed=new Controls.ParamPanel();
            lbAltitude=new Controls.ParamPanel();
            lbRadioAltimeter=new Controls.ParamPanel();
            lbHeading=new Controls.ParamPanel();
            lbAutoBrake=new Controls.ParamPanel();
            lbHeadingTrue=new Controls.ParamPanel();
            lbParkingBrake=new Controls.ParamPanel();
            lbRunwayElevation=new Controls.ParamPanel();
            lbRunwayHeadingTrue=new Controls.ParamPanel();
            lbRunwaySize=new Controls.ParamPanel();
            lbApproachDist=new Controls.ParamPanel();
            lbRunwayDist=new Controls.ParamPanel();
            lbRunwayPoints=new Controls.ParamPanel();
            lbSpacing=new Controls.ParamPanel();
            statusBar=new StatusStrip();
            stDigaoDalpiaz=new ToolStripStatusLabel();
            stVersion=new ToolStripStatusLabel();
            stConnStatus=new ToolStripStatusLabel();
            stLastTimeRec=new ToolStripStatusLabel();
            stAmmountDataReceived=new ToolStripStatusLabel();
            stSimTimeElapsed=new ToolStripStatusLabel();
            stFlightDistance=new ToolStripStatusLabel();
            stScenaryClock=new ToolStripStatusLabel();
            lbAltitudeTrue=new Controls.ParamPanel();
            lbWindInfo=new Controls.ParamPanel();
            gaugeAPU=new GaugePanel();
            lbOutsideTemp=new Controls.ParamPanel();
            lbAutopilotMode=new Controls.ParamPanel();
            lbAutoThrottle=new Controls.ParamPanel();
            lbAutopilotHeading=new Controls.ParamPanel();
            lbRunwayHeadingMag=new Controls.ParamPanel();
            gridDescentRamp=new Controls.GridPanel();
            gridAlignment=new Controls.GridPanel();
            toolBar.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeImage=Properties.Resources.wings;
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.Location=new Point(0, 160);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(280, 120);
            gaugeFlaps.TabIndex=0;
            // 
            // gaugeThrottle
            // 
            gaugeThrottle.GaugeImage=Properties.Resources.engine;
            gaugeThrottle.GaugeTitle="Engines";
            gaugeThrottle.Location=new Point(0, 680);
            gaugeThrottle.Name="gaugeThrottle";
            gaugeThrottle.Size=new Size(280, 240);
            gaugeThrottle.TabIndex=1;
            // 
            // map
            // 
            map.Bearing=0F;
            map.CanDragMap=true;
            map.EmptyTileColor=Color.Navy;
            map.GrayScaleMode=false;
            map.HelperLineOption=GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            map.LevelsKeepInMemory=5;
            map.Location=new Point(280, 280);
            map.MarkersEnabled=true;
            map.MaxZoom=2;
            map.MinZoom=2;
            map.MouseWheelZoomEnabled=true;
            map.MouseWheelZoomType=GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            map.Name="map";
            map.NegativeMode=false;
            map.PolygonsEnabled=true;
            map.RetryLoadTile=0;
            map.RoutesEnabled=true;
            map.ScaleMode=GMap.NET.WindowsForms.ScaleModes.Integer;
            map.SelectedAreaFillColor=Color.FromArgb(33, 65, 105, 225);
            map.ShowTileGridLines=false;
            map.Size=new Size(840, 640);
            map.TabIndex=13;
            map.Zoom=0D;
            map.OnMapClick+=map_OnMapClick;
            map.OnMapDrag+=map_OnMapDrag;
            map.OnMapZoomChanged+=map_OnMapZoomChanged;
            // 
            // gaugeElvTrim
            // 
            gaugeElvTrim.GaugeImage=Properties.Resources.flip;
            gaugeElvTrim.GaugeTitle="Elevator Trim";
            gaugeElvTrim.Location=new Point(280, 160);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(280, 120);
            gaugeElvTrim.TabIndex=15;
            // 
            // toolBar
            // 
            toolBar.AutoSize=false;
            toolBar.ImageScalingSize=new Size(24, 24);
            toolBar.Items.AddRange(new ToolStripItem[] { btnConnect, btnDisconnect, toolStripSeparator1, btnGotoGooglePoint, btnCenterMap, btnClearRoute, toolStripSeparator3, btnSetRunwayBegin, btnSetRunwayEnd, btnClearRunwayApproach, toolStripSeparator2, btnConfig });
            toolBar.Location=new Point(0, 0);
            toolBar.Name="toolBar";
            toolBar.Padding=new Padding(2, 0, 2, 0);
            toolBar.ShowItemToolTips=false;
            toolBar.Size=new Size(1709, 33);
            toolBar.TabIndex=48;
            // 
            // btnConnect
            // 
            btnConnect.Image=Properties.Resources.link;
            btnConnect.ImageTransparentColor=Color.Magenta;
            btnConnect.Name="btnConnect";
            btnConnect.Size=new Size(91, 30);
            btnConnect.Text="Connect";
            btnConnect.Click+=btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Image=Properties.Resources.cloud_computing;
            btnDisconnect.ImageTransparentColor=Color.Magenta;
            btnDisconnect.Name="btnDisconnect";
            btnDisconnect.Size=new Size(110, 30);
            btnDisconnect.Text="Disconnect";
            btnDisconnect.Click+=btnDisconnect_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name="toolStripSeparator1";
            toolStripSeparator1.Size=new Size(6, 33);
            // 
            // btnGotoGooglePoint
            // 
            btnGotoGooglePoint.Image=Properties.Resources.map;
            btnGotoGooglePoint.ImageTransparentColor=Color.Magenta;
            btnGotoGooglePoint.Name="btnGotoGooglePoint";
            btnGotoGooglePoint.Size=new Size(163, 30);
            btnGotoGooglePoint.Text="Google Maps Point";
            btnGotoGooglePoint.Click+=btnGotoGooglePoint_Click;
            // 
            // btnCenterMap
            // 
            btnCenterMap.Image=Properties.Resources.maps_and_flags;
            btnCenterMap.ImageTransparentColor=Color.Magenta;
            btnCenterMap.Name="btnCenterMap";
            btnCenterMap.Size=new Size(114, 30);
            btnCenterMap.Text="Center Map";
            btnCenterMap.Click+=btnCenterMap_Click;
            // 
            // btnClearRoute
            // 
            btnClearRoute.Image=Properties.Resources.delete_route;
            btnClearRoute.ImageTransparentColor=Color.Magenta;
            btnClearRoute.Name="btnClearRoute";
            btnClearRoute.Size=new Size(114, 30);
            btnClearRoute.Text="Clear Route";
            btnClearRoute.Click+=btnClearRoute_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name="toolStripSeparator3";
            toolStripSeparator3.Size=new Size(6, 33);
            // 
            // btnSetRunwayBegin
            // 
            btnSetRunwayBegin.Image=Properties.Resources.runway;
            btnSetRunwayBegin.ImageTransparentColor=Color.Magenta;
            btnSetRunwayBegin.Name="btnSetRunwayBegin";
            btnSetRunwayBegin.Size=new Size(155, 30);
            btnSetRunwayBegin.Text="Set Runway Begin";
            btnSetRunwayBegin.Click+=btnSetRunwayBegin_Click;
            // 
            // btnSetRunwayEnd
            // 
            btnSetRunwayEnd.Image=Properties.Resources.runway2;
            btnSetRunwayEnd.ImageTransparentColor=Color.Magenta;
            btnSetRunwayEnd.Name="btnSetRunwayEnd";
            btnSetRunwayEnd.Size=new Size(142, 30);
            btnSetRunwayEnd.Text="Set Runway End";
            btnSetRunwayEnd.Click+=btnSetRunwayEnd_Click;
            // 
            // btnClearRunwayApproach
            // 
            btnClearRunwayApproach.Image=Properties.Resources.cleaning;
            btnClearRunwayApproach.ImageTransparentColor=Color.Magenta;
            btnClearRunwayApproach.Name="btnClearRunwayApproach";
            btnClearRunwayApproach.Size=new Size(195, 30);
            btnClearRunwayApproach.Text="Clear Runway Approach";
            btnClearRunwayApproach.Click+=btnClearRunwayApproach_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name="toolStripSeparator2";
            toolStripSeparator2.Size=new Size(6, 33);
            // 
            // btnConfig
            // 
            btnConfig.Image=Properties.Resources.cogwheel;
            btnConfig.ImageTransparentColor=Color.Magenta;
            btnConfig.Name="btnConfig";
            btnConfig.Size=new Size(90, 30);
            btnConfig.Text="Settings";
            btnConfig.Click+=btnConfig_Click;
            // 
            // gaugeFuel
            // 
            gaugeFuel.GaugeImage=Properties.Resources.fuel;
            gaugeFuel.GaugeTitle="Fuel";
            gaugeFuel.Location=new Point(0, 520);
            gaugeFuel.Name="gaugeFuel";
            gaugeFuel.Size=new Size(280, 160);
            gaugeFuel.TabIndex=49;
            // 
            // gaugeGear
            // 
            gaugeGear.GaugeImage=Properties.Resources.landing_gear;
            gaugeGear.GaugeTitle="Landing Gear";
            gaugeGear.Location=new Point(560, 160);
            gaugeGear.Name="gaugeGear";
            gaugeGear.Size=new Size(280, 120);
            gaugeGear.TabIndex=50;
            // 
            // gaugeSpoilers
            // 
            gaugeSpoilers.GaugeImage=Properties.Resources.spoiler;
            gaugeSpoilers.GaugeTitle="Spoilers";
            gaugeSpoilers.Location=new Point(0, 280);
            gaugeSpoilers.Name="gaugeSpoilers";
            gaugeSpoilers.Size=new Size(280, 120);
            gaugeSpoilers.TabIndex=51;
            // 
            // gaugeSpeedBrake
            // 
            gaugeSpeedBrake.GaugeImage=Properties.Resources.flight;
            gaugeSpeedBrake.GaugeTitle="Speed Brakes";
            gaugeSpeedBrake.Location=new Point(0, 400);
            gaugeSpeedBrake.Name="gaugeSpeedBrake";
            gaugeSpeedBrake.Size=new Size(280, 120);
            gaugeSpeedBrake.TabIndex=52;
            // 
            // gaugeWheelBrake
            // 
            gaugeWheelBrake.GaugeImage=Properties.Resources.brakes;
            gaugeWheelBrake.GaugeTitle="Wheel Brakes";
            gaugeWheelBrake.Location=new Point(840, 160);
            gaugeWheelBrake.Name="gaugeWheelBrake";
            gaugeWheelBrake.Size=new Size(280, 120);
            gaugeWheelBrake.TabIndex=55;
            // 
            // lbAirSpeed
            // 
            lbAirSpeed.ForeColor=Color.DeepSkyBlue;
            lbAirSpeed.Location=new Point(0, 40);
            lbAirSpeed.Name="lbAirSpeed";
            lbAirSpeed.Size=new Size(280, 40);
            lbAirSpeed.TabIndex=70;
            lbAirSpeed.Title="Air Speed";
            // 
            // lbVerticalSpeed
            // 
            lbVerticalSpeed.ForeColor=Color.White;
            lbVerticalSpeed.Location=new Point(0, 80);
            lbVerticalSpeed.Name="lbVerticalSpeed";
            lbVerticalSpeed.Size=new Size(280, 40);
            lbVerticalSpeed.TabIndex=71;
            lbVerticalSpeed.Title="Vertical Speed";
            // 
            // lbGroundSpeed
            // 
            lbGroundSpeed.ForeColor=Color.FromArgb(0, 0, 160);
            lbGroundSpeed.Location=new Point(0, 120);
            lbGroundSpeed.Name="lbGroundSpeed";
            lbGroundSpeed.Size=new Size(280, 40);
            lbGroundSpeed.TabIndex=72;
            lbGroundSpeed.Title="Ground Speed";
            // 
            // lbAltitude
            // 
            lbAltitude.ForeColor=Color.BlueViolet;
            lbAltitude.Location=new Point(280, 80);
            lbAltitude.Name="lbAltitude";
            lbAltitude.Size=new Size(280, 40);
            lbAltitude.TabIndex=73;
            lbAltitude.Title="Altitude";
            // 
            // lbRadioAltimeter
            // 
            lbRadioAltimeter.ForeColor=Color.Teal;
            lbRadioAltimeter.Location=new Point(280, 120);
            lbRadioAltimeter.Name="lbRadioAltimeter";
            lbRadioAltimeter.Size=new Size(280, 40);
            lbRadioAltimeter.TabIndex=74;
            lbRadioAltimeter.Title="Radio Alt. (AGL)";
            // 
            // lbHeading
            // 
            lbHeading.ForeColor=Color.DarkKhaki;
            lbHeading.Location=new Point(280, 40);
            lbHeading.Name="lbHeading";
            lbHeading.Size=new Size(280, 40);
            lbHeading.TabIndex=75;
            lbHeading.Title="Heading";
            // 
            // lbAutoBrake
            // 
            lbAutoBrake.ForeColor=Color.White;
            lbAutoBrake.Location=new Point(840, 40);
            lbAutoBrake.Name="lbAutoBrake";
            lbAutoBrake.Size=new Size(280, 40);
            lbAutoBrake.TabIndex=76;
            lbAutoBrake.Title="Auto Brake";
            lbAutoBrake.ValueImage=Properties.Resources.pedal;
            // 
            // lbHeadingTrue
            // 
            lbHeadingTrue.ForeColor=Color.Gray;
            lbHeadingTrue.Location=new Point(560, 40);
            lbHeadingTrue.Name="lbHeadingTrue";
            lbHeadingTrue.Size=new Size(280, 40);
            lbHeadingTrue.TabIndex=77;
            lbHeadingTrue.Title="True Heading";
            // 
            // lbParkingBrake
            // 
            lbParkingBrake.ForeColor=Color.White;
            lbParkingBrake.Location=new Point(840, 80);
            lbParkingBrake.Name="lbParkingBrake";
            lbParkingBrake.Size=new Size(280, 40);
            lbParkingBrake.TabIndex=78;
            lbParkingBrake.Title="Parking Brake";
            lbParkingBrake.ValueImage=Properties.Resources.alert;
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.ForeColor=Color.SteelBlue;
            lbRunwayElevation.Location=new Point(1400, 80);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Size=new Size(280, 40);
            lbRunwayElevation.TabIndex=79;
            lbRunwayElevation.Title="Runway Elevation";
            // 
            // lbRunwayHeadingTrue
            // 
            lbRunwayHeadingTrue.ForeColor=Color.SteelBlue;
            lbRunwayHeadingTrue.Location=new Point(1400, 120);
            lbRunwayHeadingTrue.Name="lbRunwayHeadingTrue";
            lbRunwayHeadingTrue.Size=new Size(280, 40);
            lbRunwayHeadingTrue.TabIndex=80;
            lbRunwayHeadingTrue.Title="Runway True Head.";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.ForeColor=Color.SteelBlue;
            lbRunwaySize.Location=new Point(1400, 160);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Size=new Size(280, 40);
            lbRunwaySize.TabIndex=81;
            lbRunwaySize.Title="Runway Size";
            // 
            // lbApproachDist
            // 
            lbApproachDist.ForeColor=Color.White;
            lbApproachDist.Location=new Point(1400, 200);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Size=new Size(280, 40);
            lbApproachDist.TabIndex=82;
            lbApproachDist.Title="Approach Dist.";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.ForeColor=Color.White;
            lbRunwayDist.Location=new Point(1400, 240);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Size=new Size(280, 40);
            lbRunwayDist.TabIndex=83;
            lbRunwayDist.Title="Runway Distance";
            // 
            // lbRunwayPoints
            // 
            lbRunwayPoints.ForeColor=Color.White;
            lbRunwayPoints.Location=new Point(1400, 40);
            lbRunwayPoints.Name="lbRunwayPoints";
            lbRunwayPoints.Size=new Size(280, 40);
            lbRunwayPoints.TabIndex=84;
            lbRunwayPoints.Title="Runway Points";
            // 
            // lbSpacing
            // 
            lbSpacing.ForeColor=Color.Plum;
            lbSpacing.Location=new Point(1400, 880);
            lbSpacing.Name="lbSpacing";
            lbSpacing.Size=new Size(280, 40);
            lbSpacing.TabIndex=85;
            lbSpacing.Title="Align Deviation";
            // 
            // statusBar
            // 
            statusBar.AutoSize=false;
            statusBar.GripStyle=ToolStripGripStyle.Visible;
            statusBar.ImageScalingSize=new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { stDigaoDalpiaz, stVersion, stConnStatus, stLastTimeRec, stAmmountDataReceived, stSimTimeElapsed, stFlightDistance, stScenaryClock });
            statusBar.Location=new Point(0, 922);
            statusBar.Name="statusBar";
            statusBar.RenderMode=ToolStripRenderMode.ManagerRenderMode;
            statusBar.Size=new Size(1709, 27);
            statusBar.TabIndex=88;
            // 
            // stDigaoDalpiaz
            // 
            stDigaoDalpiaz.IsLink=true;
            stDigaoDalpiaz.LinkColor=Color.FromArgb(128, 128, 255);
            stDigaoDalpiaz.Name="stDigaoDalpiaz";
            stDigaoDalpiaz.Size=new Size(105, 21);
            stDigaoDalpiaz.Text="Digao Dalpiaz";
            stDigaoDalpiaz.Click+=stDigaoDalpiaz_Click;
            // 
            // stVersion
            // 
            stVersion.ForeColor=Color.Teal;
            stVersion.Name="stVersion";
            stVersion.Size=new Size(57, 21);
            stVersion.Text="Version";
            // 
            // stConnStatus
            // 
            stConnStatus.Font=new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            stConnStatus.Name="stConnStatus";
            stConnStatus.Size=new Size(53, 21);
            stConnStatus.Text="Status";
            // 
            // stLastTimeRec
            // 
            stLastTimeRec.Name="stLastTimeRec";
            stLastTimeRec.Size=new Size(155, 21);
            stLastTimeRec.Text="Last package received";
            // 
            // stAmmountDataReceived
            // 
            stAmmountDataReceived.Name="stAmmountDataReceived";
            stAmmountDataReceived.Size=new Size(169, 21);
            stAmmountDataReceived.Text="Ammount data received";
            // 
            // stSimTimeElapsed
            // 
            stSimTimeElapsed.Name="stSimTimeElapsed";
            stSimTimeElapsed.Size=new Size(163, 21);
            stSimTimeElapsed.Text="Simulator elapsed time";
            // 
            // stFlightDistance
            // 
            stFlightDistance.Name="stFlightDistance";
            stFlightDistance.Size=new Size(101, 21);
            stFlightDistance.Text="Fight distance";
            // 
            // stScenaryClock
            // 
            stScenaryClock.Name="stScenaryClock";
            stScenaryClock.Size=new Size(98, 21);
            stScenaryClock.Text="Scenary clock";
            // 
            // lbAltitudeTrue
            // 
            lbAltitudeTrue.ForeColor=Color.Gray;
            lbAltitudeTrue.Location=new Point(560, 80);
            lbAltitudeTrue.Name="lbAltitudeTrue";
            lbAltitudeTrue.Size=new Size(280, 40);
            lbAltitudeTrue.TabIndex=89;
            lbAltitudeTrue.Title="True Altitude";
            // 
            // lbWindInfo
            // 
            lbWindInfo.ForeColor=Color.RoyalBlue;
            lbWindInfo.Location=new Point(560, 120);
            lbWindInfo.Name="lbWindInfo";
            lbWindInfo.Size=new Size(280, 40);
            lbWindInfo.TabIndex=90;
            lbWindInfo.Title="Wind Spd/Head.";
            // 
            // gaugeAPU
            // 
            gaugeAPU.GaugeImage=Properties.Resources.cone;
            gaugeAPU.GaugeTitle="APU N1";
            gaugeAPU.Location=new Point(1120, 160);
            gaugeAPU.Name="gaugeAPU";
            gaugeAPU.Size=new Size(280, 120);
            gaugeAPU.TabIndex=92;
            // 
            // lbOutsideTemp
            // 
            lbOutsideTemp.ForeColor=Color.Tan;
            lbOutsideTemp.Location=new Point(840, 120);
            lbOutsideTemp.Name="lbOutsideTemp";
            lbOutsideTemp.Size=new Size(280, 40);
            lbOutsideTemp.TabIndex=93;
            lbOutsideTemp.Title="Outside Temp.";
            // 
            // lbAutopilotMode
            // 
            lbAutopilotMode.ForeColor=Color.DeepPink;
            lbAutopilotMode.Location=new Point(1120, 80);
            lbAutopilotMode.Name="lbAutopilotMode";
            lbAutopilotMode.Size=new Size(280, 40);
            lbAutopilotMode.TabIndex=94;
            lbAutopilotMode.Title="Autopilot Mode";
            lbAutopilotMode.ValueImage=Properties.Resources.autopilot;
            // 
            // lbAutoThrottle
            // 
            lbAutoThrottle.ForeColor=Color.Plum;
            lbAutoThrottle.Location=new Point(1120, 40);
            lbAutoThrottle.Name="lbAutoThrottle";
            lbAutoThrottle.Size=new Size(280, 40);
            lbAutoThrottle.TabIndex=95;
            lbAutoThrottle.Title="Auto Throttle";
            lbAutoThrottle.ValueImage=Properties.Resources.speedometer;
            // 
            // lbAutopilotHeading
            // 
            lbAutopilotHeading.ForeColor=Color.Sienna;
            lbAutopilotHeading.Location=new Point(1120, 120);
            lbAutopilotHeading.Name="lbAutopilotHeading";
            lbAutopilotHeading.Size=new Size(280, 40);
            lbAutopilotHeading.TabIndex=98;
            lbAutopilotHeading.Title="Autopilot Head.";
            // 
            // lbRunwayHeadingMag
            // 
            lbRunwayHeadingMag.ForeColor=Color.Blue;
            lbRunwayHeadingMag.Location=new Point(1120, 880);
            lbRunwayHeadingMag.Name="lbRunwayHeadingMag";
            lbRunwayHeadingMag.Size=new Size(280, 40);
            lbRunwayHeadingMag.TabIndex=102;
            lbRunwayHeadingMag.Title="Runway Heading";
            // 
            // gridDescentRamp
            // 
            gridDescentRamp.Location=new Point(1120, 280);
            gridDescentRamp.Name="gridDescentRamp";
            gridDescentRamp.Size=new Size(560, 296);
            gridDescentRamp.TabIndex=103;
            gridDescentRamp.Title="Descent Ramp";
            gridDescentRamp.OnBoxPaint+=boxRamp_Paint;
            // 
            // gridAlignment
            // 
            gridAlignment.Location=new Point(1120, 576);
            gridAlignment.Name="gridAlignment";
            gridAlignment.Size=new Size(560, 304);
            gridAlignment.TabIndex=104;
            gridAlignment.Title="Approach Alignment";
            gridAlignment.OnBoxPaint+=boxSpacing_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Black;
            ClientSize=new Size(1709, 949);
            Controls.Add(gridAlignment);
            Controls.Add(gridDescentRamp);
            Controls.Add(statusBar);
            Controls.Add(toolBar);
            Controls.Add(lbRunwayHeadingMag);
            Controls.Add(lbSpacing);
            Controls.Add(lbAutopilotHeading);
            Controls.Add(lbAutoBrake);
            Controls.Add(lbOutsideTemp);
            Controls.Add(lbParkingBrake);
            Controls.Add(lbAutoThrottle);
            Controls.Add(lbAutopilotMode);
            Controls.Add(gaugeAPU);
            Controls.Add(lbWindInfo);
            Controls.Add(lbAltitudeTrue);
            Controls.Add(lbRunwayPoints);
            Controls.Add(lbRunwayDist);
            Controls.Add(lbApproachDist);
            Controls.Add(lbRunwaySize);
            Controls.Add(lbRunwayHeadingTrue);
            Controls.Add(lbRunwayElevation);
            Controls.Add(lbHeadingTrue);
            Controls.Add(gaugeWheelBrake);
            Controls.Add(gaugeSpeedBrake);
            Controls.Add(gaugeSpoilers);
            Controls.Add(gaugeGear);
            Controls.Add(gaugeFuel);
            Controls.Add(gaugeElvTrim);
            Controls.Add(map);
            Controls.Add(gaugeThrottle);
            Controls.Add(gaugeFlaps);
            Controls.Add(lbAirSpeed);
            Controls.Add(lbGroundSpeed);
            Controls.Add(lbAltitude);
            Controls.Add(lbRadioAltimeter);
            Controls.Add(lbHeading);
            Controls.Add(lbVerticalSpeed);
            Name="MainForm";
            Text="X-Plane Monitor";
            FormClosing+=MainForm_FormClosing;
            Load+=MainForm_Load;
            Resize+=MainForm_Resize;
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GaugePanel gaugeFlaps;
        private GaugePanel gaugeThrottle;
        private GMap.NET.WindowsForms.GMapControl map;
        private GaugePanel gaugeElvTrim;
        private ToolStrip toolBar;
        private ToolStripButton btnConnect;
        private ToolStripButton btnDisconnect;
        private ToolStripButton btnSetRunwayBegin;
        private ToolStripButton btnSetRunwayEnd;
        private ToolStripButton btnClearRunwayApproach;
        private GaugePanel gaugeFuel;
        private GaugePanel gaugeGear;
        private GaugePanel gaugeSpoilers;
        private GaugePanel gaugeSpeedBrake;
        private GaugePanel gaugeWheelBrake;
        private Controls.ParamPanel lbAirSpeed;
        private Controls.ParamPanel lbVerticalSpeed;
        private Controls.ParamPanel lbGroundSpeed;
        private Controls.ParamPanel lbAltitude;
        private Controls.ParamPanel lbRadioAltimeter;
        private Controls.ParamPanel lbHeading;
        private Controls.ParamPanel lbAutoBrake;
        private Controls.ParamPanel lbHeadingTrue;
        private Controls.ParamPanel lbParkingBrake;
        private ToolStripSeparator toolStripSeparator1;
        private Controls.ParamPanel lbRunwayElevation;
        private Controls.ParamPanel lbRunwayHeadingTrue;
        private Controls.ParamPanel lbRunwaySize;
        private Controls.ParamPanel lbApproachDist;
        private Controls.ParamPanel lbRunwayDist;
        private Controls.ParamPanel lbRunwayPoints;
        private Controls.ParamPanel lbSpacing;
        private ToolStripButton btnConfig;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnCenterMap;
        private StatusStrip statusBar;
        private ToolStripStatusLabel stLastTimeRec;
        private Controls.ParamPanel lbAltitudeTrue;
        private ToolStripStatusLabel stVersion;
        private ToolStripButton btnClearRoute;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripStatusLabel stDigaoDalpiaz;
        private ToolStripStatusLabel stConnStatus;
        private Controls.ParamPanel lbWindInfo;
        private GaugePanel gaugeAPU;
        private Controls.ParamPanel lbOutsideTemp;
        private Controls.ParamPanel lbAutopilotMode;
        private Controls.ParamPanel lbAutoThrottle;
        private ToolStripStatusLabel stSimTimeElapsed;
        private ToolStripStatusLabel stAmmountDataReceived;
        private ToolStripButton btnGotoGooglePoint;
        private ToolStripStatusLabel stFlightDistance;
        private Controls.ParamPanel lbAutopilotHeading;
        private Controls.ParamPanel lbRunwayHeadingMag;
        private ToolStripStatusLabel stScenaryClock;
        private Controls.GridPanel gridDescentRamp;
        private Controls.GridPanel gridAlignment;
    }
}