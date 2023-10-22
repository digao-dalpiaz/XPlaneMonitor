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
            lbLastReceive=new Label();
            toolBar=new ToolStrip();
            btnConnect=new ToolStripButton();
            btnDisconnect=new ToolStripButton();
            toolStripSeparator1=new ToolStripSeparator();
            btnSetRunwayBegin=new ToolStripButton();
            btnSetRunwayEnd=new ToolStripButton();
            btnClearRunwayApproach=new ToolStripButton();
            gaugeFuel=new GaugePanel();
            gaugeGear=new GaugePanel();
            gaugeSpoilers=new GaugePanel();
            gaugeSpeedBrake=new GaugePanel();
            gaugeWheelBrake=new GaugePanel();
            boxRamp=new Panel();
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
            lbRunwayElevation=new Controls.BorderControl();
            lbRunwayDegrees=new Controls.BorderControl();
            lbRunwaySize=new Controls.BorderControl();
            lbApproachDist=new Controls.BorderControl();
            lbRunwayDist=new Controls.BorderControl();
            lbRunwayPoints=new Controls.BorderControl();
            lbSpacing=new Controls.BorderControl();
            toolBar.SuspendLayout();
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
            // 
            // gaugeElvTrim
            // 
            gaugeElvTrim.GaugeTitle="Elevator Trim";
            gaugeElvTrim.Location=new Point(8, 528);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(296, 112);
            gaugeElvTrim.TabIndex=15;
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
            // toolBar
            // 
            toolBar.ImageScalingSize=new Size(20, 20);
            toolBar.Items.AddRange(new ToolStripItem[] { btnConnect, btnDisconnect, toolStripSeparator1, btnSetRunwayBegin, btnSetRunwayEnd, btnClearRunwayApproach });
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
            lbAirSpeed.Value="";
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
            lbVerticalSpeed.Value="";
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
            lbGroundSpeed.Value="";
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
            lbAltitude.Value="";
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
            lbRadioAltimeter.Value="";
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
            lbHeading.Value="";
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
            lbAutoBrake.Value="";
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
            lbHeadingTrue.Value="";
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
            lbParkingBrake.Value="";
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.BackColor=Color.White;
            lbRunwayElevation.Location=new Point(1264, 112);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Padding=new Padding(1);
            lbRunwayElevation.Size=new Size(360, 40);
            lbRunwayElevation.TabIndex=79;
            lbRunwayElevation.Title="Runway Elevation";
            lbRunwayElevation.Value="";
            // 
            // lbRunwayDegrees
            // 
            lbRunwayDegrees.BackColor=Color.White;
            lbRunwayDegrees.Location=new Point(1264, 152);
            lbRunwayDegrees.Name="lbRunwayDegrees";
            lbRunwayDegrees.Padding=new Padding(1);
            lbRunwayDegrees.Size=new Size(360, 40);
            lbRunwayDegrees.TabIndex=80;
            lbRunwayDegrees.Title="Runway Heading";
            lbRunwayDegrees.Value="";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.BackColor=Color.White;
            lbRunwaySize.Location=new Point(1264, 192);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Padding=new Padding(1);
            lbRunwaySize.Size=new Size(360, 40);
            lbRunwaySize.TabIndex=81;
            lbRunwaySize.Title="Runway Size";
            lbRunwaySize.Value="";
            // 
            // lbApproachDist
            // 
            lbApproachDist.BackColor=Color.White;
            lbApproachDist.Location=new Point(1264, 240);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Padding=new Padding(1);
            lbApproachDist.Size=new Size(360, 40);
            lbApproachDist.TabIndex=82;
            lbApproachDist.Title="Approach Dist.";
            lbApproachDist.Value="";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.BackColor=Color.White;
            lbRunwayDist.Location=new Point(1264, 280);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Padding=new Padding(1);
            lbRunwayDist.Size=new Size(360, 40);
            lbRunwayDist.TabIndex=83;
            lbRunwayDist.Title="Runway Distance";
            lbRunwayDist.Value="";
            // 
            // lbRunwayPoints
            // 
            lbRunwayPoints.BackColor=Color.White;
            lbRunwayPoints.Location=new Point(1264, 72);
            lbRunwayPoints.Name="lbRunwayPoints";
            lbRunwayPoints.Padding=new Padding(1);
            lbRunwayPoints.Size=new Size(360, 40);
            lbRunwayPoints.TabIndex=84;
            lbRunwayPoints.Title="Runway Points";
            lbRunwayPoints.Value="";
            // 
            // lbSpacing
            // 
            lbSpacing.BackColor=Color.White;
            lbSpacing.Location=new Point(1272, 600);
            lbSpacing.Name="lbSpacing";
            lbSpacing.Padding=new Padding(1);
            lbSpacing.Size=new Size(264, 48);
            lbSpacing.TabIndex=85;
            lbSpacing.Title="Runway Alignment";
            lbSpacing.Value="";
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(1720, 926);
            Controls.Add(lbSpacing);
            Controls.Add(lbRunwayPoints);
            Controls.Add(lbRunwayDist);
            Controls.Add(lbApproachDist);
            Controls.Add(lbRunwaySize);
            Controls.Add(lbRunwayDegrees);
            Controls.Add(lbRunwayElevation);
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
            Controls.Add(boxRamp);
            Controls.Add(gaugeWheelBrake);
            Controls.Add(gaugeSpeedBrake);
            Controls.Add(gaugeSpoilers);
            Controls.Add(gaugeGear);
            Controls.Add(gaugeFuel);
            Controls.Add(toolBar);
            Controls.Add(lbLastReceive);
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
        private Label label17;
        private Label lbLastReceive;
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
        private ToolStripSeparator toolStripSeparator1;
        private Controls.BorderControl lbRunwayElevation;
        private Controls.BorderControl lbRunwayDegrees;
        private Controls.BorderControl lbRunwaySize;
        private Controls.BorderControl lbApproachDist;
        private Controls.BorderControl lbRunwayDist;
        private Controls.BorderControl lbRunwayPoints;
        private Controls.BorderControl lbSpacing;
    }
}