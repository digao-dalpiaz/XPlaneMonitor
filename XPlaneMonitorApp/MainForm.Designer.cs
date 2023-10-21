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
            lbAirspeed=new Label();
            lbAltitude=new Label();
            lbGroundspeed=new Label();
            lbVerticalspeed=new Label();
            lbRadioAltimeter=new Label();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            map=new GMap.NET.WindowsForms.GMapControl();
            lbParking=new Label();
            gaugeElvTrim=new GaugePanel();
            btnSetRunwayBegin=new Button();
            btnSetRunwayEnd=new Button();
            btnTurnOffSettingMode=new Button();
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
            btnClearRunwayApproach=new Button();
            label13=new Label();
            edRampDistance=new TextBox();
            edRampHeight=new TextBox();
            label16=new Label();
            lbHeading=new Label();
            label17=new Label();
            gaugeGear=new GaugePanel();
            lbLastReceive=new Label();
            gaugeN1_1=new GaugePanel();
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeHigh="Extended";
            gaugeFlaps.GaugeLow="Retracted";
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.GaugeUnique=false;
            gaugeFlaps.Location=new Point(16, 136);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(344, 144);
            gaugeFlaps.TabIndex=0;
            // 
            // gaugeThrottle
            // 
            gaugeThrottle.GaugeHigh="Full Power";
            gaugeThrottle.GaugeLow="Idle";
            gaugeThrottle.GaugeTitle="Throttle";
            gaugeThrottle.GaugeUnique=true;
            gaugeThrottle.Location=new Point(368, 136);
            gaugeThrottle.Name="gaugeThrottle";
            gaugeThrottle.Size=new Size(344, 144);
            gaugeThrottle.TabIndex=1;
            // 
            // lbAirspeed
            // 
            lbAirspeed.AutoSize=true;
            lbAirspeed.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbAirspeed.ForeColor=Color.FromArgb(192, 0, 192);
            lbAirspeed.Location=new Point(128, 8);
            lbAirspeed.Name="lbAirspeed";
            lbAirspeed.Size=new Size(91, 36);
            lbAirspeed.TabIndex=3;
            lbAirspeed.Text="####";
            // 
            // lbAltitude
            // 
            lbAltitude.AutoSize=true;
            lbAltitude.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbAltitude.ForeColor=Color.FromArgb(192, 64, 0);
            lbAltitude.Location=new Point(392, 8);
            lbAltitude.Name="lbAltitude";
            lbAltitude.Size=new Size(91, 36);
            lbAltitude.TabIndex=4;
            lbAltitude.Text="####";
            // 
            // lbGroundspeed
            // 
            lbGroundspeed.AutoSize=true;
            lbGroundspeed.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbGroundspeed.ForeColor=Color.DimGray;
            lbGroundspeed.Location=new Point(128, 88);
            lbGroundspeed.Name="lbGroundspeed";
            lbGroundspeed.Size=new Size(91, 36);
            lbGroundspeed.TabIndex=5;
            lbGroundspeed.Text="####";
            // 
            // lbVerticalspeed
            // 
            lbVerticalspeed.AutoSize=true;
            lbVerticalspeed.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbVerticalspeed.ForeColor=Color.White;
            lbVerticalspeed.Location=new Point(128, 48);
            lbVerticalspeed.Name="lbVerticalspeed";
            lbVerticalspeed.Size=new Size(91, 36);
            lbVerticalspeed.TabIndex=6;
            lbVerticalspeed.Text="####";
            // 
            // lbRadioAltimeter
            // 
            lbRadioAltimeter.AutoSize=true;
            lbRadioAltimeter.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbRadioAltimeter.ForeColor=Color.FromArgb(0, 0, 192);
            lbRadioAltimeter.Location=new Point(392, 48);
            lbRadioAltimeter.Name="lbRadioAltimeter";
            lbRadioAltimeter.Size=new Size(91, 36);
            lbRadioAltimeter.TabIndex=7;
            lbRadioAltimeter.Text="####";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(272, 56);
            label1.Name="label1";
            label1.Size=new Size(117, 20);
            label1.TabIndex=8;
            label1.Text="Radio Altimeter:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(272, 16);
            label2.Name="label2";
            label2.Size=new Size(65, 20);
            label2.TabIndex=9;
            label2.Text="Altitude:";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(16, 56);
            label3.Name="label3";
            label3.Size=new Size(107, 20);
            label3.TabIndex=10;
            label3.Text="Vertical Speed:";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(16, 96);
            label4.Name="label4";
            label4.Size=new Size(107, 20);
            label4.TabIndex=11;
            label4.Text="Ground Speed:";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(16, 16);
            label5.Name="label5";
            label5.Size=new Size(77, 20);
            label5.TabIndex=12;
            label5.Text="Air Speed:";
            // 
            // map
            // 
            map.Bearing=0F;
            map.CanDragMap=true;
            map.EmptyTileColor=Color.Navy;
            map.GrayScaleMode=false;
            map.HelperLineOption=GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            map.LevelsKeepInMemory=5;
            map.Location=new Point(16, 288);
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
            map.Size=new Size(1048, 440);
            map.TabIndex=13;
            map.Zoom=0D;
            map.OnMapClick+=map_OnMapClick;
            // 
            // lbParking
            // 
            lbParking.AutoSize=true;
            lbParking.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbParking.Location=new Point(536, 16);
            lbParking.Name="lbParking";
            lbParking.Size=new Size(169, 28);
            lbParking.TabIndex=14;
            lbParking.Text="PARKING BRAKE";
            // 
            // gaugeElvTrim
            // 
            gaugeElvTrim.GaugeHigh="Up";
            gaugeElvTrim.GaugeLow="Down";
            gaugeElvTrim.GaugeTitle="Elevator Trim";
            gaugeElvTrim.GaugeUnique=true;
            gaugeElvTrim.Location=new Point(720, 136);
            gaugeElvTrim.Name="gaugeElvTrim";
            gaugeElvTrim.Size=new Size(344, 144);
            gaugeElvTrim.TabIndex=15;
            // 
            // btnSetRunwayBegin
            // 
            btnSetRunwayBegin.Location=new Point(728, 16);
            btnSetRunwayBegin.Name="btnSetRunwayBegin";
            btnSetRunwayBegin.Size=new Size(152, 32);
            btnSetRunwayBegin.TabIndex=16;
            btnSetRunwayBegin.Text="Set runway begin";
            btnSetRunwayBegin.UseVisualStyleBackColor=true;
            btnSetRunwayBegin.Click+=btnSetRunwayBegin_Click;
            // 
            // btnSetRunwayEnd
            // 
            btnSetRunwayEnd.Location=new Point(728, 48);
            btnSetRunwayEnd.Name="btnSetRunwayEnd";
            btnSetRunwayEnd.Size=new Size(152, 32);
            btnSetRunwayEnd.TabIndex=17;
            btnSetRunwayEnd.Text="Set runway end";
            btnSetRunwayEnd.UseVisualStyleBackColor=true;
            btnSetRunwayEnd.Click+=btnSetRunwayEnd_Click;
            // 
            // btnTurnOffSettingMode
            // 
            btnTurnOffSettingMode.Location=new Point(728, 80);
            btnTurnOffSettingMode.Name="btnTurnOffSettingMode";
            btnTurnOffSettingMode.Size=new Size(152, 32);
            btnTurnOffSettingMode.TabIndex=18;
            btnTurnOffSettingMode.Text="Turn off runway cfg";
            btnTurnOffSettingMode.UseVisualStyleBackColor=true;
            btnTurnOffSettingMode.Click+=btnTurnOffSettingMode_Click;
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(1072, 32);
            label6.Name="label6";
            label6.Size=new Size(105, 20);
            label6.TabIndex=19;
            label6.Text="Runway begin:";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(1072, 64);
            label7.Name="label7";
            label7.Size=new Size(92, 20);
            label7.TabIndex=20;
            label7.Text="Runway end:";
            // 
            // edRunwayBegin
            // 
            edRunwayBegin.Location=new Point(1184, 32);
            edRunwayBegin.Name="edRunwayBegin";
            edRunwayBegin.ReadOnly=true;
            edRunwayBegin.Size=new Size(320, 27);
            edRunwayBegin.TabIndex=21;
            edRunwayBegin.TabStop=false;
            // 
            // edRunwayEnd
            // 
            edRunwayEnd.Location=new Point(1184, 64);
            edRunwayEnd.Name="edRunwayEnd";
            edRunwayEnd.ReadOnly=true;
            edRunwayEnd.Size=new Size(320, 27);
            edRunwayEnd.TabIndex=22;
            edRunwayEnd.TabStop=false;
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(1072, 104);
            label8.Name="label8";
            label8.Size=new Size(128, 20);
            label8.TabIndex=23;
            label8.Text="Runway elevation:";
            // 
            // lbRunwayElevation
            // 
            lbRunwayElevation.AutoSize=true;
            lbRunwayElevation.Location=new Point(1208, 104);
            lbRunwayElevation.Name="lbRunwayElevation";
            lbRunwayElevation.Size=new Size(39, 20);
            lbRunwayElevation.TabIndex=24;
            lbRunwayElevation.Text="-----";
            // 
            // lbRunwayDegrees
            // 
            lbRunwayDegrees.AutoSize=true;
            lbRunwayDegrees.Location=new Point(1208, 136);
            lbRunwayDegrees.Name="lbRunwayDegrees";
            lbRunwayDegrees.Size=new Size(39, 20);
            lbRunwayDegrees.TabIndex=26;
            lbRunwayDegrees.Text="-----";
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Location=new Point(1072, 136);
            label10.Name="label10";
            label10.Size=new Size(120, 20);
            label10.TabIndex=25;
            label10.Text="Runway degrees:";
            // 
            // lbRunwaySize
            // 
            lbRunwaySize.AutoSize=true;
            lbRunwaySize.Location=new Point(1208, 168);
            lbRunwaySize.Name="lbRunwaySize";
            lbRunwaySize.Size=new Size(39, 20);
            lbRunwaySize.TabIndex=28;
            lbRunwaySize.Text="-----";
            // 
            // label11
            // 
            label11.AutoSize=true;
            label11.Location=new Point(1072, 168);
            label11.Name="label11";
            label11.Size=new Size(92, 20);
            label11.TabIndex=27;
            label11.Text="Runway size:";
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Location=new Point(1072, 216);
            label9.Name="label9";
            label9.Size=new Size(136, 20);
            label9.TabIndex=29;
            label9.Text="Approach distance:";
            // 
            // label12
            // 
            label12.AutoSize=true;
            label12.Location=new Point(1072, 248);
            label12.Name="label12";
            label12.Size=new Size(122, 20);
            label12.TabIndex=30;
            label12.Text="Runway distance:";
            // 
            // lbRunwayDist
            // 
            lbRunwayDist.AutoSize=true;
            lbRunwayDist.Location=new Point(1216, 248);
            lbRunwayDist.Name="lbRunwayDist";
            lbRunwayDist.Size=new Size(39, 20);
            lbRunwayDist.TabIndex=32;
            lbRunwayDist.Text="-----";
            // 
            // lbApproachDist
            // 
            lbApproachDist.AutoSize=true;
            lbApproachDist.Location=new Point(1216, 216);
            lbApproachDist.Name="lbApproachDist";
            lbApproachDist.Size=new Size(39, 20);
            lbApproachDist.TabIndex=31;
            lbApproachDist.Text="-----";
            // 
            // lbCompassToApproach
            // 
            lbCompassToApproach.AutoSize=true;
            lbCompassToApproach.Location=new Point(1448, 216);
            lbCompassToApproach.Name="lbCompassToApproach";
            lbCompassToApproach.Size=new Size(39, 20);
            lbCompassToApproach.TabIndex=34;
            lbCompassToApproach.Text="-----";
            // 
            // label14
            // 
            label14.AutoSize=true;
            label14.Location=new Point(1304, 216);
            label14.Name="label14";
            label14.Size=new Size(135, 20);
            label14.TabIndex=33;
            label14.Text="Compass direction:";
            // 
            // lbCompassToRunway
            // 
            lbCompassToRunway.AutoSize=true;
            lbCompassToRunway.Location=new Point(1448, 248);
            lbCompassToRunway.Name="lbCompassToRunway";
            lbCompassToRunway.Size=new Size(39, 20);
            lbCompassToRunway.TabIndex=36;
            lbCompassToRunway.Text="-----";
            // 
            // label15
            // 
            label15.AutoSize=true;
            label15.Location=new Point(1304, 248);
            label15.Name="label15";
            label15.Size=new Size(135, 20);
            label15.TabIndex=35;
            label15.Text="Compass direction:";
            // 
            // btnClearRunwayApproach
            // 
            btnClearRunwayApproach.Location=new Point(896, 80);
            btnClearRunwayApproach.Name="btnClearRunwayApproach";
            btnClearRunwayApproach.Size=new Size(152, 32);
            btnClearRunwayApproach.TabIndex=37;
            btnClearRunwayApproach.Text="Clear runway cfg";
            btnClearRunwayApproach.UseVisualStyleBackColor=true;
            btnClearRunwayApproach.Click+=btnClearRunwayApproach_Click;
            // 
            // label13
            // 
            label13.AutoSize=true;
            label13.Location=new Point(1072, 296);
            label13.Name="label13";
            label13.Size=new Size(142, 20);
            label13.TabIndex=38;
            label13.Text="Ramp distance (nm)";
            // 
            // edRampDistance
            // 
            edRampDistance.Location=new Point(1072, 320);
            edRampDistance.Name="edRampDistance";
            edRampDistance.Size=new Size(125, 27);
            edRampDistance.TabIndex=39;
            edRampDistance.Text="12";
            // 
            // edRampHeight
            // 
            edRampHeight.Location=new Point(1232, 320);
            edRampHeight.Name="edRampHeight";
            edRampHeight.Size=new Size(125, 27);
            edRampHeight.TabIndex=41;
            edRampHeight.Text="4000";
            // 
            // label16
            // 
            label16.AutoSize=true;
            label16.Location=new Point(1232, 296);
            label16.Name="label16";
            label16.Size=new Size(118, 20);
            label16.TabIndex=40;
            label16.Text="Ramp height (ft)";
            // 
            // lbHeading
            // 
            lbHeading.AutoSize=true;
            lbHeading.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeading.Location=new Point(392, 88);
            lbHeading.Name="lbHeading";
            lbHeading.Size=new Size(91, 36);
            lbHeading.TabIndex=42;
            lbHeading.Text="####";
            // 
            // label17
            // 
            label17.AutoSize=true;
            label17.Location=new Point(272, 96);
            label17.Name="label17";
            label17.Size=new Size(69, 20);
            label17.TabIndex=43;
            label17.Text="Heading:";
            // 
            // gaugeGear
            // 
            gaugeGear.GaugeHigh="Up";
            gaugeGear.GaugeLow="Down";
            gaugeGear.GaugeTitle="Landing Gear";
            gaugeGear.GaugeUnique=true;
            gaugeGear.Location=new Point(1072, 384);
            gaugeGear.Name="gaugeGear";
            gaugeGear.Size=new Size(344, 144);
            gaugeGear.TabIndex=44;
            // 
            // lbLastReceive
            // 
            lbLastReceive.AutoSize=true;
            lbLastReceive.Location=new Point(928, 16);
            lbLastReceive.Name="lbLastReceive";
            lbLastReceive.Size=new Size(63, 20);
            lbLastReceive.TabIndex=45;
            lbLastReceive.Text="00:00:00";
            // 
            // gaugeN1_1
            // 
            gaugeN1_1.GaugeHigh="Up";
            gaugeN1_1.GaugeLow="Down";
            gaugeN1_1.GaugeTitle="Landing Gear";
            gaugeN1_1.GaugeUnique=false;
            gaugeN1_1.Location=new Point(1096, 528);
            gaugeN1_1.Name="gaugeN1_1";
            gaugeN1_1.Size=new Size(344, 152);
            gaugeN1_1.TabIndex=46;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1521, 742);
            Controls.Add(gaugeN1_1);
            Controls.Add(lbLastReceive);
            Controls.Add(gaugeGear);
            Controls.Add(label17);
            Controls.Add(lbHeading);
            Controls.Add(edRampHeight);
            Controls.Add(label16);
            Controls.Add(edRampDistance);
            Controls.Add(label13);
            Controls.Add(btnClearRunwayApproach);
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
            Controls.Add(btnTurnOffSettingMode);
            Controls.Add(btnSetRunwayEnd);
            Controls.Add(btnSetRunwayBegin);
            Controls.Add(gaugeElvTrim);
            Controls.Add(lbParking);
            Controls.Add(map);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbRadioAltimeter);
            Controls.Add(lbVerticalspeed);
            Controls.Add(lbGroundspeed);
            Controls.Add(lbAltitude);
            Controls.Add(lbAirspeed);
            Controls.Add(gaugeThrottle);
            Controls.Add(gaugeFlaps);
            Name="MainForm";
            Text="X-Plane Monitor";
            FormClosed+=MainForm_FormClosed;
            Load+=MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GaugePanel gaugeFlaps;
        private GaugePanel gaugeThrottle;
        private Label lbAirspeed;
        private Label lbAltitude;
        private Label lbGroundspeed;
        private Label lbVerticalspeed;
        private Label lbRadioAltimeter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GMap.NET.WindowsForms.GMapControl map;
        private Label lbParking;
        private GaugePanel gaugeElvTrim;
        private Button btnSetRunwayBegin;
        private Button btnSetRunwayEnd;
        private Button btnTurnOffSettingMode;
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
        private Button btnClearRunwayApproach;
        private Label label13;
        private TextBox edRampDistance;
        private TextBox edRampHeight;
        private Label label16;
        private Label lbHeading;
        private Label label17;
        private GaugePanel gaugeGear;
        private Label lbLastReceive;
        private GaugePanel gaugeN1_1;
    }
}