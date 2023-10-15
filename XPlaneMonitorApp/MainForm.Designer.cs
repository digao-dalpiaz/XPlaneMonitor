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
            SuspendLayout();
            // 
            // gaugeFlaps
            // 
            gaugeFlaps.GaugeHigh="Extended";
            gaugeFlaps.GaugeLow="Retracted";
            gaugeFlaps.GaugeTitle="Flaps";
            gaugeFlaps.Location=new Point(96, 104);
            gaugeFlaps.Name="gaugeFlaps";
            gaugeFlaps.Size=new Size(344, 200);
            gaugeFlaps.TabIndex=0;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(gaugeFlaps);
            Name="MainForm";
            Text="X-Plane Monitor";
            Load+=MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private GaugePanel gaugeFlaps;
    }
}