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
            btnCenterMap=new ToolStripButton();
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
            lbRunwayDegrees=new Controls.BorderControl();
            lbRunwaySize=new Controls.BorderControl();
            lbApproachDist=new Controls.BorderControl();
            lbRunwayDist=new Controls.BorderControl();
            lbRunwayPoints=new Controls.BorderControl();
            lbSpacing=new Controls.BorderControl();
            lbBoxDescentRamp=new Label();
            lbBoxAlign=new Label();
            statusBar=new StatusStrip();
            stVersion=new ToolStripStatusLabel();
            stLastTimeRec=new ToolStripStatusLabel();
            lbAltitudeTrue=new Controls.BorderControl();
            toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).BeginInit();
            statusBar.SuspendLayout();
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
            gaugeThrottle.Location=new Point(8, 648);
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
            map.Size=new Size(904, 632);
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
            gaugeElvTrim.Location=new Point(8, 528);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(296, 112);
            gaugeElvTrim.TabIndex=15;
            // 
            // toolBar
            // 
            toolBar.ImageScalingSize=new Size(20, 20);
            toolBar.Items.AddRange(new ToolStripItem[] { btnConnect, btnDisconnect, toolStripSeparator1, btnCenterMap, btnSetRunwayBegin, btnSetRunwayEnd, btnClearRunwayApproach, toolStripSeparator2, btnConfig });
            toolBar.Location=new Point(0, 0);
            toolBar.Name="toolBar";
            toolBar.Size=new Size(1720, 31);
            toolBar.TabIndex=48;
            // 
            // btnConnect
            // 
            btnConnect.Image=Properties.Resources.link;
            btnConnect.ImageScaling=ToolStripItemImageScaling.None;
            btnConnect.ImageTransparentColor=Color.Magenta;
            btnConnect.Name="btnConnect";
            btnConnect.Size=new Size(91, 28);
            btnConnect.Text="Connect";
            btnConnect.Click+=btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Image=Properties.Resources.cloud_computing;
            btnDisconnect.ImageScaling=ToolStripItemImageScaling.None;
            btnDisconnect.ImageTransparentColor=Color.Magenta;
            btnDisconnect.Name="btnDisconnect";
            btnDisconnect.Size=new Size(110, 28);
            btnDisconnect.Text="Disconnect";
            btnDisconnect.Click+=btnDisconnect_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name="toolStripSeparator1";
            toolStripSeparator1.Size=new Size(6, 31);
            // 
            // btnCenterMap
            // 
            btnCenterMap.Image=Properties.Resources.maps_and_flags;
            btnCenterMap.ImageTransparentColor=Color.Magenta;
            btnCenterMap.Name="btnCenterMap";
            btnCenterMap.Size=new Size(110, 28);
            btnCenterMap.Text="Center Map";
            btnCenterMap.Click+=btnCenterMap_Click;
            // 
            // btnSetRunwayBegin
            // 
            btnSetRunwayBegin.Image=Properties.Resources.runway;
            btnSetRunwayBegin.ImageScaling=ToolStripItemImageScaling.None;
            btnSetRunwayBegin.ImageTransparentColor=Color.Magenta;
            btnSetRunwayBegin.Name="btnSetRunwayBegin";
            btnSetRunwayBegin.Size=new Size(155, 28);
            btnSetRunwayBegin.Text="Set Runway Begin";
            btnSetRunwayBegin.Click+=btnSetRunwayBegin_Click;
            // 
            // btnSetRunwayEnd
            // 
            btnSetRunwayEnd.Image=Properties.Resources.runway2;
            btnSetRunwayEnd.ImageScaling=ToolStripItemImageScaling.None;
            btnSetRunwayEnd.ImageTransparentColor=Color.Magenta;
            btnSetRunwayEnd.Name="btnSetRunwayEnd";
            btnSetRunwayEnd.Size=new Size(142, 28);
            btnSetRunwayEnd.Text="Set Runway End";
            btnSetRunwayEnd.Click+=btnSetRunwayEnd_Click;
            // 
            // btnClearRunwayApproach
            // 
            btnClearRunwayApproach.Image=Properties.Resources.cleaning;
            btnClearRunwayApproach.ImageScaling=ToolStripItemImageScaling.None;
            btnClearRunwayApproach.ImageTransparentColor=Color.Magenta;
            btnClearRunwayApproach.Name="btnClearRunwayApproach";
            btnClearRunwayApproach.Size=new Size(195, 28);
            btnClearRunwayApproach.Text="Clear Runway Approach";
            btnClearRunwayApproach.Click+=btnClearRunwayApproach_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name="toolStripSeparator2";
            toolStripSeparator2.Size=new Size(6, 31);
            // 
            // btnConfig
            // 
            btnConfig.Image=Properties.Resources.cogwheel;
            btnConfig.ImageScaling=ToolStripItemImageScaling.None;
            btnConfig.ImageTransparentColor=Color.Magenta;
            btnConfig.Name="btnConfig";
            btnConfig.Size=new Size(90, 28);
            btnConfig.Text="Settings";
            btnConfig.Click+=btnConfig_Click;
            // 
            // gaugeFuel
            // 
            gaugeFuel.GaugeImage=Properties.Resources.fuel;
            gaugeFuel.GaugeTitle="Fuel";
            gaugeFuel.Location=new Point(312, 168);
            gaugeFuel.Name="gaugeFuel";
            gaugeFuel.Size=new Size(296, 112);
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
            boxRamp.Location=new Point(1224, 320);
            boxRamp.Name="boxRamp";
            boxRamp.Size=new Size(488, 264);
            boxRamp.TabIndex=56;
            boxRamp.Paint+=boxRamp_Paint;
            // 
            // boxSpacing
            // 
            boxSpacing.Location=new Point(1224, 616);
            boxSpacing.Name="boxSpacing";
            boxSpacing.Size=new Size(488, 264);
            boxSpacing.TabIndex=59;
            boxSpacing.Paint+=boxSpacing_Paint;
            // 
            // icoParkingBrake
            // 
            icoParkingBrake.BackColor=Color.White;
            icoParkingBrake.Image=Properties.Resources.alert;
            icoParkingBrake.Location=new Point(872, 83);
            icoParkingBrake.Name="icoParkingBrake";
            icoParkingBrake.Size=new Size(32, 32);
            icoParkingBrake.SizeMode=PictureBoxSizeMode.AutoSize;
            icoParkingBrake.TabIndex=69;
            icoParkingBrake.TabStop=false;
            // 
            // lbAirSpeed
            // 
            lbAirSpeed.BackColor=Color.White;
            lbAirSpeed.ForeColor=Color.OrangeRed;
            lbAirSpeed.Location=new Point(8, 40);
            lbAirSpeed.Name="lbAirSpeed";
            lbAirSpeed.Padding=new Padding(1);
            lbAirSpeed.Size=new Size(296, 40);
            lbAirSpeed.TabIndex=70;
            lbAirSpeed.Title="Air Speed";
            // 
            // lbVerticalSpeed
            // 
            lbVerticalSpeed.BackColor=Color.White;
            lbVerticalSpeed.Location=new Point(8, 79);
            lbVerticalSpeed.Name="lbVerticalSpeed";
            lbVerticalSpeed.Padding=new Padding(1);
            lbVerticalSpeed.Size=new Size(296, 40);
            lbVerticalSpeed.TabIndex=71;
            lbVerticalSpeed.Title="Vertical Speed";
            // 
            // lbGroundSpeed
            // 
            lbGroundSpeed.BackColor=Color.White;
            lbGroundSpeed.ForeColor=Color.SkyBlue;
            lbGroundSpeed.Location=new Point(8, 118);
            lbGroundSpeed.Name="lbGroundSpeed";
            lbGroundSpeed.Padding=new Padding(1);
            lbGroundSpeed.Size=new Size(296, 40);
            lbGroundSpeed.TabIndex=72;
            lbGroundSpeed.Title="Ground Speed";
            // 
            // lbAltitude
            // 
            lbAltitude.BackColor=Color.White;
            lbAltitude.ForeColor=Color.BlueViolet;
            lbAltitude.Location=new Point(312, 40);
            lbAltitude.Name="lbAltitude";
            lbAltitude.Padding=new Padding(1);
            lbAltitude.Size=new Size(296, 40);
            lbAltitude.TabIndex=73;
            lbAltitude.Title="Altitude";
            // 
            // lbRadioAltimeter
            // 
            lbRadioAltimeter.BackColor=Color.White;
            lbRadioAltimeter.ForeColor=Color.Teal;
            lbRadioAltimeter.Location=new Point(312, 79);
            lbRadioAltimeter.Name="lbRadioAltimeter";
            lbRadioAltimeter.Padding=new Padding(1);
            lbRadioAltimeter.Size=new Size(296, 40);
            lbRadioAltimeter.TabIndex=74;
            lbRadioAltimeter.Title="Radio Altimeter";
            // 
            // lbHeading
            // 
            lbHeading.BackColor=Color.White;
            lbHeading.ForeColor=Color.FromArgb(192, 192, 0);
            lbHeading.Location=new Point(312, 118);
            lbHeading.Name="lbHeading";
            lbHeading.Padding=new Padding(1);
            lbHeading.Size=new Size(296, 40);
            lbHeading.TabIndex=75;
            lbHeading.Title="Heading";
            // 
            // lbAutoBrake
            // 
            lbAutoBrake.BackColor=Color.White;
            lbAutoBrake.Location=new Point(616, 40);
            lbAutoBrake.Name="lbAutoBrake";
            lbAutoBrake.Padding=new Padding(1);
            lbAutoBrake.Size=new Size(296, 40);
            lbAutoBrake.TabIndex=76;
            lbAutoBrake.Title="Auto Brake";
            // 
            // lbHeadingTrue
            // 
            lbHeadingTrue.BackColor=Color.White;
            lbHeadingTrue.ForeColor=Color.Gray;
            lbHeadingTrue.Location=new Point(616, 118);
            lbHeadingTrue.Name="lbHeadingTrue";
            lbHeadingTrue.Padding=new Padding(1);
            lbHeadingTrue.Size=new Size(296, 40);
            lbHeadingTrue.TabIndex=77;
            lbHeadingTrue.Title="True Heading";
            // 
            // lbParkingBrake
            // 
            lbParkingBrake.BackColor=Color.White;
            lbParkingBrake.Location=new Point(616, 79);
            lbParkingBrake.Name="lbParkingBrake";
            lbParkingBrake.Padding=new Padding(1);
            lbParkingBrake.Size=new Size(296, 40);
            lbParkingBrake.TabIndex=78;
            lbParkingBrake.Title="Parking Brake";
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.BackColor=Color.White;
            lbRunwayElevation.Location=new Point(1224, 79);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Padding=new Padding(1);
            lbRunwayElevation.Size=new Size(296, 40);
            lbRunwayElevation.TabIndex=79;
            lbRunwayElevation.Title="Runway Elevation";
            // 
            // lbRunwayDegrees
            // 
            lbRunwayDegrees.BackColor=Color.White;
            lbRunwayDegrees.Location=new Point(1224, 118);
            lbRunwayDegrees.Name="lbRunwayDegrees";
            lbRunwayDegrees.Padding=new Padding(1);
            lbRunwayDegrees.Size=new Size(296, 40);
            lbRunwayDegrees.TabIndex=80;
            lbRunwayDegrees.Title="Runway Heading";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.BackColor=Color.White;
            lbRunwaySize.Location=new Point(1224, 157);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Padding=new Padding(1);
            lbRunwaySize.Size=new Size(296, 40);
            lbRunwaySize.TabIndex=81;
            lbRunwaySize.Title="Runway Size";
            // 
            // lbApproachDist
            // 
            lbApproachDist.BackColor=Color.White;
            lbApproachDist.Location=new Point(1224, 208);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Padding=new Padding(1);
            lbApproachDist.Size=new Size(296, 40);
            lbApproachDist.TabIndex=82;
            lbApproachDist.Title="Approach Dist.";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.BackColor=Color.White;
            lbRunwayDist.Location=new Point(1224, 247);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Padding=new Padding(1);
            lbRunwayDist.Size=new Size(296, 40);
            lbRunwayDist.TabIndex=83;
            lbRunwayDist.Title="Runway Distance";
            // 
            // lbRunwayPoints
            // 
            lbRunwayPoints.BackColor=Color.White;
            lbRunwayPoints.Location=new Point(1224, 40);
            lbRunwayPoints.Name="lbRunwayPoints";
            lbRunwayPoints.Padding=new Padding(1);
            lbRunwayPoints.Size=new Size(296, 40);
            lbRunwayPoints.TabIndex=84;
            lbRunwayPoints.Title="Runway Points";
            // 
            // lbSpacing
            // 
            lbSpacing.BackColor=Color.White;
            lbSpacing.Location=new Point(1224, 880);
            lbSpacing.Name="lbSpacing";
            lbSpacing.Padding=new Padding(1);
            lbSpacing.Size=new Size(296, 40);
            lbSpacing.TabIndex=85;
            lbSpacing.Title="Align Deviation";
            // 
            // lbBoxDescentRamp
            // 
            lbBoxDescentRamp.BackColor=Color.Gray;
            lbBoxDescentRamp.Location=new Point(1224, 296);
            lbBoxDescentRamp.Name="lbBoxDescentRamp";
            lbBoxDescentRamp.Size=new Size(488, 24);
            lbBoxDescentRamp.TabIndex=86;
            lbBoxDescentRamp.Text="Descent Ramp";
            lbBoxDescentRamp.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // lbBoxAlign
            // 
            lbBoxAlign.BackColor=Color.Gray;
            lbBoxAlign.Location=new Point(1224, 592);
            lbBoxAlign.Name="lbBoxAlign";
            lbBoxAlign.Size=new Size(488, 24);
            lbBoxAlign.TabIndex=87;
            lbBoxAlign.Text="Approach Alignment";
            lbBoxAlign.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize=new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { stVersion, stLastTimeRec });
            statusBar.Location=new Point(0, 929);
            statusBar.Name="statusBar";
            statusBar.Size=new Size(1720, 26);
            statusBar.TabIndex=88;
            statusBar.Text="statusStrip1";
            // 
            // stVersion
            // 
            stVersion.Name="stVersion";
            stVersion.Size=new Size(57, 20);
            stVersion.Text="Version";
            // 
            // stLastTimeRec
            // 
            stLastTimeRec.Name="stLastTimeRec";
            stLastTimeRec.Size=new Size(238, 20);
            stLastTimeRec.Text="Nothing received yet from X-Plane";
            // 
            // lbAltitudeTrue
            // 
            lbAltitudeTrue.BackColor=Color.White;
            lbAltitudeTrue.ForeColor=Color.Gray;
            lbAltitudeTrue.Location=new Point(920, 118);
            lbAltitudeTrue.Name="lbAltitudeTrue";
            lbAltitudeTrue.Padding=new Padding(1);
            lbAltitudeTrue.Size=new Size(296, 40);
            lbAltitudeTrue.TabIndex=89;
            lbAltitudeTrue.Title="True Altitude";
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(1720, 955);
            Controls.Add(lbAltitudeTrue);
            Controls.Add(statusBar);
            Controls.Add(lbBoxAlign);
            Controls.Add(lbBoxDescentRamp);
            Controls.Add(lbSpacing);
            Controls.Add(boxSpacing);
            Controls.Add(lbRunwayPoints);
            Controls.Add(lbRunwayDist);
            Controls.Add(lbApproachDist);
            Controls.Add(lbRunwaySize);
            Controls.Add(lbRunwayDegrees);
            Controls.Add(lbRunwayElevation);
            Controls.Add(lbHeadingTrue);
            Controls.Add(lbAutoBrake);
            Controls.Add(icoParkingBrake);
            Controls.Add(boxRamp);
            Controls.Add(gaugeWheelBrake);
            Controls.Add(gaugeSpeedBrake);
            Controls.Add(gaugeSpoilers);
            Controls.Add(gaugeGear);
            Controls.Add(gaugeFuel);
            Controls.Add(toolBar);
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
            Controls.Add(lbParkingBrake);
            Name="MainForm";
            Text="X-Plane Monitor";
            FormClosing+=MainForm_FormClosing;
            Load+=MainForm_Load;
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Controls.BorderControl lbRunwayDegrees;
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
    }
}