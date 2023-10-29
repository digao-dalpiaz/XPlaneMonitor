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
            boxRamp=new Panel();
            boxSpacing=new Panel();
            icoParkingBrake=new PictureBox();
            lbAirSpeed=new Controls.BorderControl();
            lbVerticalSpeed=new Controls.BorderControl();
            lbGroundSpeed=new Controls.BorderControl();
            lbAltitude=new Controls.BorderControl();
            lbRadioAltimeter=new Controls.BorderControl();
            lbHeading=new Controls.BorderControl();
            lbAutoBrake=new Controls.BorderControl();
            lbHeadingTrue=new Controls.BorderControl();
            lbParkingBrake=new Controls.BorderControl();
            lbRunwayElevation=new Controls.BorderControl();
            lbRunwayHeadingTrue=new Controls.BorderControl();
            lbRunwaySize=new Controls.BorderControl();
            lbApproachDist=new Controls.BorderControl();
            lbRunwayDist=new Controls.BorderControl();
            lbRunwayPoints=new Controls.BorderControl();
            lbSpacing=new Controls.BorderControl();
            lbBoxDescentRamp=new Label();
            lbBoxAlign=new Label();
            statusBar=new StatusStrip();
            stDigaoDalpiaz=new ToolStripStatusLabel();
            stVersion=new ToolStripStatusLabel();
            stConnStatus=new ToolStripStatusLabel();
            stLastTimeRec=new ToolStripStatusLabel();
            stAmmountDataReceived=new ToolStripStatusLabel();
            stSimTimeElapsed=new ToolStripStatusLabel();
            stFlightDistance=new ToolStripStatusLabel();
            stScenaryClock=new ToolStripStatusLabel();
            lbAltitudeTrue=new Controls.BorderControl();
            lbWindInfo=new Controls.BorderControl();
            gaugeAPU=new GaugePanel();
            lbOutsideTemp=new Controls.BorderControl();
            lbAutopilotMode=new Controls.BorderControl();
            lbAutoThrottle=new Controls.BorderControl();
            icoVerticalSpeed=new PictureBox();
            lbAutopilotHeading=new Controls.BorderControl();
            icoAutoThrottle=new PictureBox();
            icoAutopilot=new PictureBox();
            icoAutoBrake=new PictureBox();
            lbRunwayHeadingMag=new Controls.BorderControl();
            toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).BeginInit();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icoVerticalSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icoAutoThrottle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icoAutopilot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icoAutoBrake).BeginInit();
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeImage=Properties.Resources.wings;
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.Location=new Point(8, 168);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(296, 112);
            gaugeFlaps.TabIndex=0;
            // 
            // gaugeThrottle
            // 
            gaugeThrottle.GaugeImage=Properties.Resources.engine;
            gaugeThrottle.GaugeTitle="Engines";
            gaugeThrottle.Location=new Point(8, 688);
            gaugeThrottle.Name="gaugeThrottle";
            gaugeThrottle.Size=new Size(296, 272);
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
            map.Location=new Point(312, 288);
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
            map.Size=new Size(904, 672);
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
            gaugeElvTrim.Location=new Point(312, 168);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(296, 112);
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
            toolBar.Size=new Size(1834, 33);
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
            gaugeFuel.Location=new Point(8, 528);
            gaugeFuel.Name="gaugeFuel";
            gaugeFuel.Size=new Size(296, 152);
            gaugeFuel.TabIndex=49;
            // 
            // gaugeGear
            // 
            gaugeGear.GaugeImage=Properties.Resources.landing_gear;
            gaugeGear.GaugeTitle="Landing Gear";
            gaugeGear.Location=new Point(616, 168);
            gaugeGear.Name="gaugeGear";
            gaugeGear.Size=new Size(296, 112);
            gaugeGear.TabIndex=50;
            // 
            // gaugeSpoilers
            // 
            gaugeSpoilers.GaugeImage=Properties.Resources.spoiler;
            gaugeSpoilers.GaugeTitle="Spoilers";
            gaugeSpoilers.Location=new Point(8, 288);
            gaugeSpoilers.Name="gaugeSpoilers";
            gaugeSpoilers.Size=new Size(296, 112);
            gaugeSpoilers.TabIndex=51;
            // 
            // gaugeSpeedBrake
            // 
            gaugeSpeedBrake.GaugeImage=Properties.Resources.flight;
            gaugeSpeedBrake.GaugeTitle="Speed Brakes";
            gaugeSpeedBrake.Location=new Point(8, 408);
            gaugeSpeedBrake.Name="gaugeSpeedBrake";
            gaugeSpeedBrake.Size=new Size(296, 112);
            gaugeSpeedBrake.TabIndex=52;
            // 
            // gaugeWheelBrake
            // 
            gaugeWheelBrake.GaugeImage=Properties.Resources.brakes;
            gaugeWheelBrake.GaugeTitle="Wheel Brakes";
            gaugeWheelBrake.Location=new Point(920, 168);
            gaugeWheelBrake.Name="gaugeWheelBrake";
            gaugeWheelBrake.Size=new Size(296, 112);
            gaugeWheelBrake.TabIndex=55;
            // 
            // boxRamp
            // 
            boxRamp.Location=new Point(1224, 312);
            boxRamp.Name="boxRamp";
            boxRamp.Size=new Size(600, 280);
            boxRamp.TabIndex=56;
            boxRamp.Paint+=boxRamp_Paint;
            // 
            // boxSpacing
            // 
            boxSpacing.Location=new Point(1224, 624);
            boxSpacing.Name="boxSpacing";
            boxSpacing.Size=new Size(600, 288);
            boxSpacing.TabIndex=59;
            boxSpacing.Paint+=boxSpacing_Paint;
            // 
            // icoParkingBrake
            // 
            icoParkingBrake.Image=Properties.Resources.alert;
            icoParkingBrake.Location=new Point(1176, 83);
            icoParkingBrake.Name="icoParkingBrake";
            icoParkingBrake.Size=new Size(32, 32);
            icoParkingBrake.SizeMode=PictureBoxSizeMode.Zoom;
            icoParkingBrake.TabIndex=69;
            icoParkingBrake.TabStop=false;
            // 
            // lbAirSpeed
            // 
            lbAirSpeed.ForeColor=Color.DeepSkyBlue;
            lbAirSpeed.Location=new Point(8, 40);
            lbAirSpeed.Name="lbAirSpeed";
            lbAirSpeed.Padding=new Padding(1);
            lbAirSpeed.Size=new Size(296, 40);
            lbAirSpeed.TabIndex=70;
            lbAirSpeed.Title="Air Speed";
            // 
            // lbVerticalSpeed
            // 
            lbVerticalSpeed.ForeColor=Color.White;
            lbVerticalSpeed.Location=new Point(8, 79);
            lbVerticalSpeed.Name="lbVerticalSpeed";
            lbVerticalSpeed.Padding=new Padding(1);
            lbVerticalSpeed.Size=new Size(296, 40);
            lbVerticalSpeed.TabIndex=71;
            lbVerticalSpeed.Title="Vertical Speed";
            // 
            // lbGroundSpeed
            // 
            lbGroundSpeed.ForeColor=Color.FromArgb(0, 0, 160);
            lbGroundSpeed.Location=new Point(8, 118);
            lbGroundSpeed.Name="lbGroundSpeed";
            lbGroundSpeed.Padding=new Padding(1);
            lbGroundSpeed.Size=new Size(296, 40);
            lbGroundSpeed.TabIndex=72;
            lbGroundSpeed.Title="Ground Speed";
            // 
            // lbAltitude
            // 
            lbAltitude.ForeColor=Color.BlueViolet;
            lbAltitude.Location=new Point(312, 79);
            lbAltitude.Name="lbAltitude";
            lbAltitude.Padding=new Padding(1);
            lbAltitude.Size=new Size(296, 40);
            lbAltitude.TabIndex=73;
            lbAltitude.Title="Altitude";
            // 
            // lbRadioAltimeter
            // 
            lbRadioAltimeter.ForeColor=Color.Teal;
            lbRadioAltimeter.Location=new Point(312, 118);
            lbRadioAltimeter.Name="lbRadioAltimeter";
            lbRadioAltimeter.Padding=new Padding(1);
            lbRadioAltimeter.Size=new Size(296, 40);
            lbRadioAltimeter.TabIndex=74;
            lbRadioAltimeter.Title="Radio Alt. (AGL)";
            // 
            // lbHeading
            // 
            lbHeading.ForeColor=Color.DarkKhaki;
            lbHeading.Location=new Point(312, 40);
            lbHeading.Name="lbHeading";
            lbHeading.Padding=new Padding(1);
            lbHeading.Size=new Size(296, 40);
            lbHeading.TabIndex=75;
            lbHeading.Title="Heading";
            // 
            // lbAutoBrake
            // 
            lbAutoBrake.ForeColor=Color.White;
            lbAutoBrake.Location=new Point(920, 40);
            lbAutoBrake.Name="lbAutoBrake";
            lbAutoBrake.Padding=new Padding(1);
            lbAutoBrake.Size=new Size(296, 40);
            lbAutoBrake.TabIndex=76;
            lbAutoBrake.Title="Auto Brake";
            // 
            // lbHeadingTrue
            // 
            lbHeadingTrue.ForeColor=Color.Gray;
            lbHeadingTrue.Location=new Point(616, 40);
            lbHeadingTrue.Name="lbHeadingTrue";
            lbHeadingTrue.Padding=new Padding(1);
            lbHeadingTrue.Size=new Size(296, 40);
            lbHeadingTrue.TabIndex=77;
            lbHeadingTrue.Title="True Heading";
            // 
            // lbParkingBrake
            // 
            lbParkingBrake.ForeColor=Color.White;
            lbParkingBrake.Location=new Point(920, 79);
            lbParkingBrake.Name="lbParkingBrake";
            lbParkingBrake.Padding=new Padding(1);
            lbParkingBrake.Size=new Size(296, 40);
            lbParkingBrake.TabIndex=78;
            lbParkingBrake.Title="Parking Brake";
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.ForeColor=Color.SteelBlue;
            lbRunwayElevation.Location=new Point(1528, 79);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Padding=new Padding(1);
            lbRunwayElevation.Size=new Size(296, 40);
            lbRunwayElevation.TabIndex=79;
            lbRunwayElevation.Title="Runway Elevation";
            // 
            // lbRunwayHeadingTrue
            // 
            lbRunwayHeadingTrue.ForeColor=Color.SteelBlue;
            lbRunwayHeadingTrue.Location=new Point(1528, 118);
            lbRunwayHeadingTrue.Name="lbRunwayHeadingTrue";
            lbRunwayHeadingTrue.Padding=new Padding(1);
            lbRunwayHeadingTrue.Size=new Size(296, 40);
            lbRunwayHeadingTrue.TabIndex=80;
            lbRunwayHeadingTrue.Title="Runway True Head.";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.ForeColor=Color.SteelBlue;
            lbRunwaySize.Location=new Point(1528, 157);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Padding=new Padding(1);
            lbRunwaySize.Size=new Size(296, 40);
            lbRunwaySize.TabIndex=81;
            lbRunwaySize.Title="Runway Size";
            // 
            // lbApproachDist
            // 
            lbApproachDist.ForeColor=Color.White;
            lbApproachDist.Location=new Point(1528, 201);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Padding=new Padding(1);
            lbApproachDist.Size=new Size(296, 40);
            lbApproachDist.TabIndex=82;
            lbApproachDist.Title="Approach Dist.";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.ForeColor=Color.White;
            lbRunwayDist.Location=new Point(1528, 240);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Padding=new Padding(1);
            lbRunwayDist.Size=new Size(296, 40);
            lbRunwayDist.TabIndex=83;
            lbRunwayDist.Title="Runway Distance";
            // 
            // lbRunwayPoints
            // 
            lbRunwayPoints.ForeColor=Color.White;
            lbRunwayPoints.Location=new Point(1528, 40);
            lbRunwayPoints.Name="lbRunwayPoints";
            lbRunwayPoints.Padding=new Padding(1);
            lbRunwayPoints.Size=new Size(296, 40);
            lbRunwayPoints.TabIndex=84;
            lbRunwayPoints.Title="Runway Points";
            // 
            // lbSpacing
            // 
            lbSpacing.ForeColor=Color.Plum;
            lbSpacing.Location=new Point(1528, 920);
            lbSpacing.Name="lbSpacing";
            lbSpacing.Padding=new Padding(1);
            lbSpacing.Size=new Size(296, 40);
            lbSpacing.TabIndex=85;
            lbSpacing.Title="Align Deviation";
            // 
            // lbBoxDescentRamp
            // 
            lbBoxDescentRamp.BackColor=Color.FromArgb(64, 64, 64);
            lbBoxDescentRamp.ForeColor=Color.Silver;
            lbBoxDescentRamp.Location=new Point(1224, 288);
            lbBoxDescentRamp.Name="lbBoxDescentRamp";
            lbBoxDescentRamp.Size=new Size(600, 24);
            lbBoxDescentRamp.TabIndex=86;
            lbBoxDescentRamp.Text="Descent Ramp";
            lbBoxDescentRamp.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // lbBoxAlign
            // 
            lbBoxAlign.BackColor=Color.FromArgb(64, 64, 64);
            lbBoxAlign.ForeColor=Color.Silver;
            lbBoxAlign.Location=new Point(1224, 600);
            lbBoxAlign.Name="lbBoxAlign";
            lbBoxAlign.Size=new Size(600, 24);
            lbBoxAlign.TabIndex=87;
            lbBoxAlign.Text="Approach Alignment";
            lbBoxAlign.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // statusBar
            // 
            statusBar.AutoSize=false;
            statusBar.GripStyle=ToolStripGripStyle.Visible;
            statusBar.ImageScalingSize=new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { stDigaoDalpiaz, stVersion, stConnStatus, stLastTimeRec, stAmmountDataReceived, stSimTimeElapsed, stFlightDistance, stScenaryClock });
            statusBar.Location=new Point(0, 966);
            statusBar.Name="statusBar";
            statusBar.RenderMode=ToolStripRenderMode.ManagerRenderMode;
            statusBar.Size=new Size(1834, 27);
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
            lbAltitudeTrue.Location=new Point(616, 79);
            lbAltitudeTrue.Name="lbAltitudeTrue";
            lbAltitudeTrue.Padding=new Padding(1);
            lbAltitudeTrue.Size=new Size(296, 40);
            lbAltitudeTrue.TabIndex=89;
            lbAltitudeTrue.Title="True Altitude";
            // 
            // lbWindInfo
            // 
            lbWindInfo.ForeColor=Color.RoyalBlue;
            lbWindInfo.Location=new Point(616, 118);
            lbWindInfo.Name="lbWindInfo";
            lbWindInfo.Padding=new Padding(1);
            lbWindInfo.Size=new Size(296, 40);
            lbWindInfo.TabIndex=90;
            lbWindInfo.Title="Wind Spd/Head.";
            // 
            // gaugeAPU
            // 
            gaugeAPU.GaugeImage=Properties.Resources.cone;
            gaugeAPU.GaugeTitle="APU N1";
            gaugeAPU.Location=new Point(1224, 168);
            gaugeAPU.Name="gaugeAPU";
            gaugeAPU.Size=new Size(296, 112);
            gaugeAPU.TabIndex=92;
            // 
            // lbOutsideTemp
            // 
            lbOutsideTemp.ForeColor=Color.Tan;
            lbOutsideTemp.Location=new Point(920, 118);
            lbOutsideTemp.Name="lbOutsideTemp";
            lbOutsideTemp.Padding=new Padding(1);
            lbOutsideTemp.Size=new Size(296, 40);
            lbOutsideTemp.TabIndex=93;
            lbOutsideTemp.Title="Outside Temp.";
            // 
            // lbAutopilotMode
            // 
            lbAutopilotMode.ForeColor=Color.DeepPink;
            lbAutopilotMode.Location=new Point(1224, 79);
            lbAutopilotMode.Name="lbAutopilotMode";
            lbAutopilotMode.Padding=new Padding(1);
            lbAutopilotMode.Size=new Size(296, 40);
            lbAutopilotMode.TabIndex=94;
            lbAutopilotMode.Title="Autopilot Mode";
            // 
            // lbAutoThrottle
            // 
            lbAutoThrottle.ForeColor=Color.Plum;
            lbAutoThrottle.Location=new Point(1224, 40);
            lbAutoThrottle.Name="lbAutoThrottle";
            lbAutoThrottle.Padding=new Padding(1);
            lbAutoThrottle.Size=new Size(296, 40);
            lbAutoThrottle.TabIndex=95;
            lbAutoThrottle.Title="Auto Throttle";
            // 
            // icoVerticalSpeed
            // 
            icoVerticalSpeed.Location=new Point(264, 83);
            icoVerticalSpeed.Name="icoVerticalSpeed";
            icoVerticalSpeed.Size=new Size(32, 32);
            icoVerticalSpeed.SizeMode=PictureBoxSizeMode.Zoom;
            icoVerticalSpeed.TabIndex=97;
            icoVerticalSpeed.TabStop=false;
            // 
            // lbAutopilotHeading
            // 
            lbAutopilotHeading.ForeColor=Color.Sienna;
            lbAutopilotHeading.Location=new Point(1224, 118);
            lbAutopilotHeading.Name="lbAutopilotHeading";
            lbAutopilotHeading.Padding=new Padding(1);
            lbAutopilotHeading.Size=new Size(296, 40);
            lbAutopilotHeading.TabIndex=98;
            lbAutopilotHeading.Title="Autopilot Head.";
            // 
            // icoAutoThrottle
            // 
            icoAutoThrottle.Image=Properties.Resources.speedometer;
            icoAutoThrottle.Location=new Point(1480, 44);
            icoAutoThrottle.Name="icoAutoThrottle";
            icoAutoThrottle.Size=new Size(32, 32);
            icoAutoThrottle.SizeMode=PictureBoxSizeMode.Zoom;
            icoAutoThrottle.TabIndex=99;
            icoAutoThrottle.TabStop=false;
            // 
            // icoAutopilot
            // 
            icoAutopilot.Image=Properties.Resources.autopilot;
            icoAutopilot.Location=new Point(1480, 83);
            icoAutopilot.Name="icoAutopilot";
            icoAutopilot.Size=new Size(32, 32);
            icoAutopilot.SizeMode=PictureBoxSizeMode.Zoom;
            icoAutopilot.TabIndex=100;
            icoAutopilot.TabStop=false;
            // 
            // icoAutoBrake
            // 
            icoAutoBrake.Image=Properties.Resources.pedal;
            icoAutoBrake.Location=new Point(1176, 44);
            icoAutoBrake.Name="icoAutoBrake";
            icoAutoBrake.Size=new Size(32, 32);
            icoAutoBrake.SizeMode=PictureBoxSizeMode.Zoom;
            icoAutoBrake.TabIndex=101;
            icoAutoBrake.TabStop=false;
            // 
            // lbRunwayHeadingMag
            // 
            lbRunwayHeadingMag.ForeColor=Color.Blue;
            lbRunwayHeadingMag.Location=new Point(1224, 920);
            lbRunwayHeadingMag.Name="lbRunwayHeadingMag";
            lbRunwayHeadingMag.Padding=new Padding(1);
            lbRunwayHeadingMag.Size=new Size(296, 40);
            lbRunwayHeadingMag.TabIndex=102;
            lbRunwayHeadingMag.Title="Runway Heading";
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Black;
            ClientSize=new Size(1834, 993);
            Controls.Add(statusBar);
            Controls.Add(toolBar);
            Controls.Add(lbRunwayHeadingMag);
            Controls.Add(lbSpacing);
            Controls.Add(icoAutoBrake);
            Controls.Add(icoAutopilot);
            Controls.Add(icoAutoThrottle);
            Controls.Add(icoParkingBrake);
            Controls.Add(lbAutopilotHeading);
            Controls.Add(lbAutoBrake);
            Controls.Add(lbOutsideTemp);
            Controls.Add(icoVerticalSpeed);
            Controls.Add(lbParkingBrake);
            Controls.Add(lbAutoThrottle);
            Controls.Add(lbAutopilotMode);
            Controls.Add(gaugeAPU);
            Controls.Add(lbWindInfo);
            Controls.Add(lbAltitudeTrue);
            Controls.Add(lbBoxAlign);
            Controls.Add(lbBoxDescentRamp);
            Controls.Add(boxSpacing);
            Controls.Add(lbRunwayPoints);
            Controls.Add(lbRunwayDist);
            Controls.Add(lbApproachDist);
            Controls.Add(lbRunwaySize);
            Controls.Add(lbRunwayHeadingTrue);
            Controls.Add(lbRunwayElevation);
            Controls.Add(lbHeadingTrue);
            Controls.Add(boxRamp);
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
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icoVerticalSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)icoAutoThrottle).EndInit();
            ((System.ComponentModel.ISupportInitialize)icoAutopilot).EndInit();
            ((System.ComponentModel.ISupportInitialize)icoAutoBrake).EndInit();
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
        private Panel boxRamp;
        private Panel boxSpacing;
        private PictureBox icoParkingBrake;
        private Controls.BorderControl lbAirSpeed;
        private Controls.BorderControl lbVerticalSpeed;
        private Controls.BorderControl lbGroundSpeed;
        private Controls.BorderControl lbAltitude;
        private Controls.BorderControl lbRadioAltimeter;
        private Controls.BorderControl lbHeading;
        private Controls.BorderControl lbAutoBrake;
        private Controls.BorderControl lbHeadingTrue;
        private Controls.BorderControl lbParkingBrake;
        private ToolStripSeparator toolStripSeparator1;
        private Controls.BorderControl lbRunwayElevation;
        private Controls.BorderControl lbRunwayHeadingTrue;
        private Controls.BorderControl lbRunwaySize;
        private Controls.BorderControl lbApproachDist;
        private Controls.BorderControl lbRunwayDist;
        private Controls.BorderControl lbRunwayPoints;
        private Controls.BorderControl lbSpacing;
        private ToolStripButton btnConfig;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnCenterMap;
        private Label lbBoxDescentRamp;
        private Label lbBoxAlign;
        private StatusStrip statusBar;
        private ToolStripStatusLabel stLastTimeRec;
        private Controls.BorderControl lbAltitudeTrue;
        private ToolStripStatusLabel stVersion;
        private ToolStripButton btnClearRoute;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripStatusLabel stDigaoDalpiaz;
        private ToolStripStatusLabel stConnStatus;
        private Controls.BorderControl lbWindInfo;
        private GaugePanel gaugeAPU;
        private Controls.BorderControl lbOutsideTemp;
        private Controls.BorderControl lbAutopilotMode;
        private Controls.BorderControl lbAutoThrottle;
        private ToolStripStatusLabel stSimTimeElapsed;
        private ToolStripStatusLabel stAmmountDataReceived;
        private PictureBox icoVerticalSpeed;
        private ToolStripButton btnGotoGooglePoint;
        private ToolStripStatusLabel stFlightDistance;
        private Controls.BorderControl lbAutopilotHeading;
        private PictureBox icoAutoThrottle;
        private PictureBox icoAutopilot;
        private PictureBox icoAutoBrake;
        private Controls.BorderControl lbRunwayHeadingMag;
        private ToolStripStatusLabel stScenaryClock;
    }
}