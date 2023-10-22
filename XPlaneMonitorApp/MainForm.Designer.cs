﻿namespace XPlaneMonitorApp
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
            label6=new Label();
            label7=new Label();
            edRunwayBegin=new TextBox();
            edRunwayEnd=new TextBox();
            label8=new Label();
            lbRunwayElevation=new Label();
            lbRunwayDegrees=new Label();
            label10=new Label();
            lbRunwaySize=new Label();
            label11=new Label();
            label9=new Label();
            label12=new Label();
            lbRunwayDist=new Label();
            lbApproachDist=new Label();
            lbCompassToApproach=new Label();
            label14=new Label();
            lbCompassToRunway=new Label();
            label15=new Label();
            label13=new Label();
            edRampDistance=new TextBox();
            edRampHeight=new TextBox();
            label16=new Label();
            lbLastReceive=new Label();
            toolStrip1=new ToolStrip();
            btnConnect=new ToolStripButton();
            btnDisconnect=new ToolStripButton();
            btnSetRunwayBegin=new ToolStripButton();
            btnSetRunwayEnd=new ToolStripButton();
            btnClearRunwayApproach=new ToolStripButton();
            gaugeFuel=new GaugePanel();
            gaugeGear=new GaugePanel();
            gaugeSpoilers=new GaugePanel();
            gaugeSpeedBrake=new GaugePanel();
            gaugeWheelBrake=new GaugePanel();
            boxRamp=new Panel();
            lbSpacing=new Label();
            label20=new Label();
            boxSpacing=new Panel();
            pictureBox1=new PictureBox();
            pictureBox2=new PictureBox();
            pictureBox3=new PictureBox();
            pictureBox4=new PictureBox();
            pictureBox5=new PictureBox();
            pictureBox6=new PictureBox();
            pictureBox7=new PictureBox();
            pictureBox8=new PictureBox();
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
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).BeginInit();
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.Location=new Point(8, 168);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(296, 112);
            gaugeFlaps.TabIndex=0;
            // 
            // gaugeThrottle
            // 
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
            map.Load+=map_Load;
            // 
            // gaugeElvTrim
            // 
            gaugeElvTrim.GaugeTitle="Elevator Trim";
            gaugeElvTrim.Location=new Point(8, 528);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(296, 112);
            gaugeElvTrim.TabIndex=15;
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(1272, 48);
            label6.Name="label6";
            label6.Size=new Size(105, 20);
            label6.TabIndex=19;
            label6.Text="Runway begin:";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(1272, 80);
            label7.Name="label7";
            label7.Size=new Size(92, 20);
            label7.TabIndex=20;
            label7.Text="Runway end:";
            // 
            // edRunwayBegin
            // 
            edRunwayBegin.Location=new Point(1384, 48);
            edRunwayBegin.Name="edRunwayBegin";
            edRunwayBegin.ReadOnly=true;
            edRunwayBegin.Size=new Size(320, 27);
            edRunwayBegin.TabIndex=21;
            edRunwayBegin.TabStop=false;
            // 
            // edRunwayEnd
            // 
            edRunwayEnd.Location=new Point(1384, 80);
            edRunwayEnd.Name="edRunwayEnd";
            edRunwayEnd.ReadOnly=true;
            edRunwayEnd.Size=new Size(320, 27);
            edRunwayEnd.TabIndex=22;
            edRunwayEnd.TabStop=false;
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(1272, 120);
            label8.Name="label8";
            label8.Size=new Size(128, 20);
            label8.TabIndex=23;
            label8.Text="Runway elevation:";
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.AutoSize=true;
            lbRunwayElevation.Location=new Point(1408, 120);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Size=new Size(39, 20);
            lbRunwayElevation.TabIndex=24;
            lbRunwayElevation.Text="-----";
            // 
            // lbRunwayDegrees
            // 
            lbRunwayDegrees.AutoSize=true;
            lbRunwayDegrees.Location=new Point(1408, 152);
            lbRunwayDegrees.Name="lbRunwayDegrees";
            lbRunwayDegrees.Size=new Size(39, 20);
            lbRunwayDegrees.TabIndex=26;
            lbRunwayDegrees.Text="-----";
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Location=new Point(1272, 152);
            label10.Name="label10";
            label10.Size=new Size(120, 20);
            label10.TabIndex=25;
            label10.Text="Runway degrees:";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.AutoSize=true;
            lbRunwaySize.Location=new Point(1408, 184);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Size=new Size(39, 20);
            lbRunwaySize.TabIndex=28;
            lbRunwaySize.Text="-----";
            // 
            // label11
            // 
            label11.AutoSize=true;
            label11.Location=new Point(1272, 184);
            label11.Name="label11";
            label11.Size=new Size(92, 20);
            label11.TabIndex=27;
            label11.Text="Runway size:";
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Location=new Point(1272, 232);
            label9.Name="label9";
            label9.Size=new Size(136, 20);
            label9.TabIndex=29;
            label9.Text="Approach distance:";
            // 
            // label12
            // 
            label12.AutoSize=true;
            label12.Location=new Point(1272, 264);
            label12.Name="label12";
            label12.Size=new Size(122, 20);
            label12.TabIndex=30;
            label12.Text="Runway distance:";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.AutoSize=true;
            lbRunwayDist.Location=new Point(1416, 264);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Size=new Size(39, 20);
            lbRunwayDist.TabIndex=32;
            lbRunwayDist.Text="-----";
            // 
            // lbApproachDist
            // 
            lbApproachDist.AutoSize=true;
            lbApproachDist.Location=new Point(1416, 232);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Size=new Size(39, 20);
            lbApproachDist.TabIndex=31;
            lbApproachDist.Text="-----";
            // 
            // lbCompassToApproach
            // 
            lbCompassToApproach.AutoSize=true;
            lbCompassToApproach.Location=new Point(1648, 232);
            lbCompassToApproach.Name="lbCompassToApproach";
            lbCompassToApproach.Size=new Size(39, 20);
            lbCompassToApproach.TabIndex=34;
            lbCompassToApproach.Text="-----";
            // 
            // label14
            // 
            label14.AutoSize=true;
            label14.Location=new Point(1504, 232);
            label14.Name="label14";
            label14.Size=new Size(135, 20);
            label14.TabIndex=33;
            label14.Text="Compass direction:";
            // 
            // lbCompassToRunway
            // 
            lbCompassToRunway.AutoSize=true;
            lbCompassToRunway.Location=new Point(1648, 264);
            lbCompassToRunway.Name="lbCompassToRunway";
            lbCompassToRunway.Size=new Size(39, 20);
            lbCompassToRunway.TabIndex=36;
            lbCompassToRunway.Text="-----";
            // 
            // label15
            // 
            label15.AutoSize=true;
            label15.Location=new Point(1504, 264);
            label15.Name="label15";
            label15.Size=new Size(135, 20);
            label15.TabIndex=35;
            label15.Text="Compass direction:";
            // 
            // label13
            // 
            label13.AutoSize=true;
            label13.Location=new Point(1272, 312);
            label13.Name="label13";
            label13.Size=new Size(142, 20);
            label13.TabIndex=38;
            label13.Text="Ramp distance (nm)";
            // 
            // edRampDistance
            // 
            edRampDistance.Location=new Point(1272, 336);
            edRampDistance.Name="edRampDistance";
            edRampDistance.Size=new Size(125, 27);
            edRampDistance.TabIndex=39;
            edRampDistance.Text="12";
            // 
            // edRampHeight
            // 
            edRampHeight.Location=new Point(1432, 336);
            edRampHeight.Name="edRampHeight";
            edRampHeight.Size=new Size(125, 27);
            edRampHeight.TabIndex=41;
            edRampHeight.Text="4000";
            // 
            // label16
            // 
            label16.AutoSize=true;
            label16.Location=new Point(1432, 312);
            label16.Name="label16";
            label16.Size=new Size(118, 20);
            label16.TabIndex=40;
            label16.Text="Ramp height (ft)";
            // 
            // lbLastReceive
            // 
            lbLastReceive.AutoSize=true;
            lbLastReceive.Location=new Point(928, 40);
            lbLastReceive.Name="lbLastReceive";
            lbLastReceive.Size=new Size(63, 20);
            lbLastReceive.TabIndex=45;
            lbLastReceive.Text="00:00:00";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize=new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnConnect, btnDisconnect, btnSetRunwayBegin, btnSetRunwayEnd, btnClearRunwayApproach });
            toolStrip1.Location=new Point(0, 0);
            toolStrip1.Name="toolStrip1";
            toolStrip1.Size=new Size(1720, 31);
            toolStrip1.TabIndex=48;
            toolStrip1.Text="toolStrip1";
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
            btnClearRunwayApproach.ImageTransparentColor=Color.Magenta;
            btnClearRunwayApproach.Name="btnClearRunwayApproach";
            btnClearRunwayApproach.Size=new Size(191, 28);
            btnClearRunwayApproach.Text="Clear Runway Approach";
            btnClearRunwayApproach.Click+=btnClearRunwayApproach_Click;
            // 
            // gaugeFuel
            // 
            gaugeFuel.GaugeTitle="Fuel";
            gaugeFuel.Location=new Point(312, 168);
            gaugeFuel.Name="gaugeFuel";
            gaugeFuel.Size=new Size(296, 112);
            gaugeFuel.TabIndex=49;
            // 
            // gaugeGear
            // 
            gaugeGear.GaugeTitle="Landing Gear";
            gaugeGear.Location=new Point(616, 168);
            gaugeGear.Name="gaugeGear";
            gaugeGear.Size=new Size(296, 112);
            gaugeGear.TabIndex=50;
            // 
            // gaugeSpoilers
            // 
            gaugeSpoilers.GaugeTitle="Spoilers";
            gaugeSpoilers.Location=new Point(8, 288);
            gaugeSpoilers.Name="gaugeSpoilers";
            gaugeSpoilers.Size=new Size(296, 112);
            gaugeSpoilers.TabIndex=51;
            // 
            // gaugeSpeedBrake
            // 
            gaugeSpeedBrake.GaugeTitle="Speed Brakes";
            gaugeSpeedBrake.Location=new Point(8, 408);
            gaugeSpeedBrake.Name="gaugeSpeedBrake";
            gaugeSpeedBrake.Size=new Size(296, 112);
            gaugeSpeedBrake.TabIndex=52;
            // 
            // gaugeWheelBrake
            // 
            gaugeWheelBrake.GaugeTitle="Wheel Brakes";
            gaugeWheelBrake.Location=new Point(920, 168);
            gaugeWheelBrake.Name="gaugeWheelBrake";
            gaugeWheelBrake.Size=new Size(296, 112);
            gaugeWheelBrake.TabIndex=55;
            // 
            // boxRamp
            // 
            boxRamp.Location=new Point(1272, 384);
            boxRamp.Name="boxRamp";
            boxRamp.Size=new Size(432, 216);
            boxRamp.TabIndex=56;
            boxRamp.Paint+=boxRamp_Paint;
            // 
            // lbSpacing
            // 
            lbSpacing.AutoSize=true;
            lbSpacing.Location=new Point(1408, 608);
            lbSpacing.Name="lbSpacing";
            lbSpacing.Size=new Size(39, 20);
            lbSpacing.TabIndex=58;
            lbSpacing.Text="-----";
            // 
            // label20
            // 
            label20.AutoSize=true;
            label20.Location=new Point(1272, 608);
            label20.Name="label20";
            label20.Size=new Size(65, 20);
            label20.TabIndex=57;
            label20.Text="Spacing:";
            // 
            // boxSpacing
            // 
            boxSpacing.Location=new Point(1272, 640);
            boxSpacing.Name="boxSpacing";
            boxSpacing.Size=new Size(432, 192);
            boxSpacing.TabIndex=59;
            boxSpacing.Paint+=boxSpacing_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor=Color.Gray;
            pictureBox1.Image=Properties.Resources.engine;
            pictureBox1.Location=new Point(16, 651);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(32, 32);
            pictureBox1.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex=61;
            pictureBox1.TabStop=false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor=Color.Gray;
            pictureBox2.Image=Properties.Resources.flip;
            pictureBox2.Location=new Point(16, 531);
            pictureBox2.Name="pictureBox2";
            pictureBox2.Size=new Size(32, 32);
            pictureBox2.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex=62;
            pictureBox2.TabStop=false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor=Color.Gray;
            pictureBox3.Image=Properties.Resources.fuel;
            pictureBox3.Location=new Point(320, 171);
            pictureBox3.Name="pictureBox3";
            pictureBox3.Size=new Size(32, 32);
            pictureBox3.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex=63;
            pictureBox3.TabStop=false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor=Color.Gray;
            pictureBox4.Image=Properties.Resources.landing_gear;
            pictureBox4.Location=new Point(624, 171);
            pictureBox4.Name="pictureBox4";
            pictureBox4.Size=new Size(32, 32);
            pictureBox4.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox4.TabIndex=64;
            pictureBox4.TabStop=false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor=Color.Gray;
            pictureBox5.Image=Properties.Resources.brakes;
            pictureBox5.Location=new Point(928, 171);
            pictureBox5.Name="pictureBox5";
            pictureBox5.Size=new Size(32, 32);
            pictureBox5.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox5.TabIndex=65;
            pictureBox5.TabStop=false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor=Color.Gray;
            pictureBox6.Image=Properties.Resources.wings;
            pictureBox6.Location=new Point(16, 171);
            pictureBox6.Name="pictureBox6";
            pictureBox6.Size=new Size(32, 32);
            pictureBox6.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox6.TabIndex=66;
            pictureBox6.TabStop=false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor=Color.Gray;
            pictureBox7.Image=Properties.Resources.spoiler;
            pictureBox7.Location=new Point(16, 291);
            pictureBox7.Name="pictureBox7";
            pictureBox7.Size=new Size(32, 32);
            pictureBox7.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox7.TabIndex=67;
            pictureBox7.TabStop=false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor=Color.Gray;
            pictureBox8.Image=Properties.Resources.flight;
            pictureBox8.Location=new Point(16, 411);
            pictureBox8.Name="pictureBox8";
            pictureBox8.Size=new Size(32, 32);
            pictureBox8.SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBox8.TabIndex=68;
            pictureBox8.TabStop=false;
            // 
            // icoParkingBrake
            // 
            icoParkingBrake.BackColor=Color.White;
            icoParkingBrake.Image=Properties.Resources.alert;
            icoParkingBrake.Location=new Point(880, 80);
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
            lbAirSpeed.Value="Value";
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
            lbVerticalSpeed.Value="Value";
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
            lbGroundSpeed.Value="Value";
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
            lbAltitude.Value="Value";
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
            lbRadioAltimeter.Value="Value";
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
            lbHeading.Value="Value";
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
            lbAutoBrake.Value="Value";
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
            lbHeadingTrue.Value="Value";
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
            lbParkingBrake.Value="Value";
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(1720, 926);
            Controls.Add(lbHeadingTrue);
            Controls.Add(lbAutoBrake);
            Controls.Add(icoParkingBrake);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(boxSpacing);
            Controls.Add(lbSpacing);
            Controls.Add(label20);
            Controls.Add(boxRamp);
            Controls.Add(gaugeWheelBrake);
            Controls.Add(gaugeSpeedBrake);
            Controls.Add(gaugeSpoilers);
            Controls.Add(gaugeGear);
            Controls.Add(gaugeFuel);
            Controls.Add(toolStrip1);
            Controls.Add(lbLastReceive);
            Controls.Add(edRampHeight);
            Controls.Add(label16);
            Controls.Add(edRampDistance);
            Controls.Add(label13);
            Controls.Add(lbCompassToRunway);
            Controls.Add(label15);
            Controls.Add(lbCompassToApproach);
            Controls.Add(label14);
            Controls.Add(lbRunwayDist);
            Controls.Add(lbApproachDist);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(lbRunwaySize);
            Controls.Add(label11);
            Controls.Add(lbRunwayDegrees);
            Controls.Add(label10);
            Controls.Add(lbRunwayElevation);
            Controls.Add(label8);
            Controls.Add(edRunwayEnd);
            Controls.Add(edRunwayBegin);
            Controls.Add(label7);
            Controls.Add(label6);
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
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)icoParkingBrake).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GaugePanel gaugeFlaps;
        private GaugePanel gaugeThrottle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GMap.NET.WindowsForms.GMapControl map;
        private GaugePanel gaugeElvTrim;
        private Label label6;
        private Label label7;
        private TextBox edRunwayBegin;
        private TextBox edRunwayEnd;
        private Label label8;
        private Label lbRunwayElevation;
        private Label lbRunwayDegrees;
        private Label label10;
        private Label lbRunwaySize;
        private Label label11;
        private Label label9;
        private Label label12;
        private Label lbRunwayDist;
        private Label lbApproachDist;
        private Label lbCompassToApproach;
        private Label label14;
        private Label lbCompassToRunway;
        private Label label15;
        private Label label13;
        private TextBox edRampDistance;
        private TextBox edRampHeight;
        private Label label16;
        private Label label17;
        private Label lbLastReceive;
        private ToolStrip toolStrip1;
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
        private Label lbSpacing;
        private Label label20;
        private Panel boxSpacing;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
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
    }
}