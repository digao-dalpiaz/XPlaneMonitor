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
            gaugeN2=new GaugePanel();
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeHigh="Extended";
            gaugeFlaps.GaugeLow="Retracted";
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.Location=new Point(96, 104);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(344, 176);
            gaugeFlaps.TabIndex=0;
            // 
            // gaugeThrottle
            // 
            gaugeThrottle.GaugeHigh="Full Power";
            gaugeThrottle.GaugeLow="Idle";
            gaugeThrottle.GaugeTitle="Throttle";
            gaugeThrottle.Location=new Point(96, 288);
            gaugeThrottle.Name="gaugeThrottle";
            gaugeThrottle.Size=new Size(344, 176);
            gaugeThrottle.TabIndex=1;
            // 
            // gaugeN2
            // 
            gaugeN2.GaugeHigh="High";
            gaugeN2.GaugeLow="Low";
            gaugeN2.GaugeTitle="N2";
            gaugeN2.Location=new Point(504, 80);
            gaugeN2.Name="gaugeN2";
            gaugeN2.Size=new Size(344, 176);
            gaugeN2.TabIndex=2;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(995, 537);
            Controls.Add(gaugeN2);
            Controls.Add(gaugeThrottle);
            Controls.Add(gaugeFlaps);
            Name="MainForm";
            Text="X-Plane Monitor";
            Load+=MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private GaugePanel gaugeFlaps;
        private GaugePanel gaugeThrottle;
        private GaugePanel gaugeN2;
    }
}