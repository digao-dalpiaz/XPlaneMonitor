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
            gaugeFlaps.Size=new Size(344, 160);
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
            gaugeThrottle.Size=new Size(344, 160);
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
            lbAirspeed.Text="label1";
            // 
            // lbAltitude
            // 
            lbAltitude.AutoSize=true;
            lbAltitude.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbAltitude.ForeColor=Color.FromArgb(192, 64, 0);
            lbAltitude.Location=new Point(392, 8);
            lbAltitude.Name="lbAltitude";
            lbAltitude.Size=new Size(96, 36);
            lbAltitude.TabIndex=4;
            lbAltitude.Text="label2";
            // 
            // lbGroundspeed
            // 
            lbGroundspeed.AutoSize=true;
            lbGroundspeed.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbGroundspeed.ForeColor=Color.DimGray;
            lbGroundspeed.Location=new Point(128, 88);
            lbGroundspeed.Name="lbGroundspeed";
            lbGroundspeed.Size=new Size(96, 36);
            lbGroundspeed.TabIndex=5;
            lbGroundspeed.Text="label2";
            // 
            // lbVerticalspeed
            // 
            lbVerticalspeed.AutoSize=true;
            lbVerticalspeed.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbVerticalspeed.ForeColor=Color.White;
            lbVerticalspeed.Location=new Point(128, 48);
            lbVerticalspeed.Name="lbVerticalspeed";
            lbVerticalspeed.Size=new Size(96, 36);
            lbVerticalspeed.TabIndex=6;
            lbVerticalspeed.Text="label2";
            // 
            // lbRadioAltimeter
            // 
            lbRadioAltimeter.AutoSize=true;
            lbRadioAltimeter.Font=new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbRadioAltimeter.ForeColor=Color.FromArgb(0, 0, 192);
            lbRadioAltimeter.Location=new Point(392, 48);
            lbRadioAltimeter.Name="lbRadioAltimeter";
            lbRadioAltimeter.Size=new Size(96, 36);
            lbRadioAltimeter.TabIndex=7;
            lbRadioAltimeter.Text="label2";
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
            map.Location=new Point(16, 304);
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
            map.Size=new Size(1048, 424);
            map.TabIndex=13;
            map.Zoom=0D;
            map.OnMapClick+=map_OnMapClick;
            // 
            // lbParking
            // 
            lbParking.AutoSize=true;
            lbParking.Location=new Point(560, 72);
            lbParking.Name="lbParking";
            lbParking.Size=new Size(118, 20);
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
            gaugeElvTrim.Size=new Size(344, 160);
            gaugeElvTrim.TabIndex=15;
            // 
            // btnSetRunwayBegin
            // 
            btnSetRunwayBegin.Location=new Point(824, 32);
            btnSetRunwayBegin.Name="btnSetRunwayBegin";
            btnSetRunwayBegin.Size=new Size(152, 32);
            btnSetRunwayBegin.TabIndex=16;
            btnSetRunwayBegin.Text="Set runway begin";
            btnSetRunwayBegin.UseVisualStyleBackColor=true;
            btnSetRunwayBegin.Click+=btnSetRunwayBegin_Click;
            // 
            // btnSetRunwayEnd
            // 
            btnSetRunwayEnd.Location=new Point(824, 64);
            btnSetRunwayEnd.Name="btnSetRunwayEnd";
            btnSetRunwayEnd.Size=new Size(152, 32);
            btnSetRunwayEnd.TabIndex=17;
            btnSetRunwayEnd.Text="Set runway end";
            btnSetRunwayEnd.UseVisualStyleBackColor=true;
            btnSetRunwayEnd.Click+=btnSetRunwayEnd_Click;
            // 
            // btnTurnOffSettingMode
            // 
            btnTurnOffSettingMode.Location=new Point(824, 96);
            btnTurnOffSettingMode.Name="btnTurnOffSettingMode";
            btnTurnOffSettingMode.Size=new Size(152, 32);
            btnTurnOffSettingMode.TabIndex=18;
            btnTurnOffSettingMode.Text="Turn off runway cfg";
            btnTurnOffSettingMode.UseVisualStyleBackColor=true;
            btnTurnOffSettingMode.Click+=btnTurnOffSettingMode_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1078, 742);
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
    }
}