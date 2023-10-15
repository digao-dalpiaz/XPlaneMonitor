namespace XPlaneMonitorApp
{
    partial class GaugePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbTitle=new Label();
            barReq=new Label();
            barReal=new Label();
            lbLow=new Label();
            lbHigh=new Label();
            lbPercReq=new Label();
            lbPercReal=new Label();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.BackColor=Color.Gray;
            lbTitle.Dock=DockStyle.Top;
            lbTitle.ForeColor=Color.WhiteSmoke;
            lbTitle.Location=new Point(0, 0);
            lbTitle.Name="lbTitle";
            lbTitle.Size=new Size(300, 40);
            lbTitle.TabIndex=2;
            lbTitle.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // barReq
            // 
            barReq.BackColor=Color.FromArgb(255, 128, 0);
            barReq.Location=new Point(56, 80);
            barReq.Name="barReq";
            barReq.Size=new Size(232, 24);
            barReq.TabIndex=3;
            barReq.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // barReal
            // 
            barReal.BackColor=Color.Lime;
            barReal.Location=new Point(56, 112);
            barReal.Name="barReal";
            barReal.Size=new Size(232, 48);
            barReal.TabIndex=4;
            barReal.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // lbLow
            // 
            lbLow.Location=new Point(56, 48);
            lbLow.Name="lbLow";
            lbLow.Size=new Size(104, 25);
            lbLow.TabIndex=5;
            lbLow.Text="low";
            // 
            // lbHigh
            // 
            lbHigh.Location=new Point(168, 48);
            lbHigh.Name="lbHigh";
            lbHigh.Size=new Size(120, 25);
            lbHigh.TabIndex=6;
            lbHigh.Text="high";
            lbHigh.TextAlign=ContentAlignment.TopRight;
            // 
            // lbPercReq
            // 
            lbPercReq.Location=new Point(0, 80);
            lbPercReq.Name="lbPercReq";
            lbPercReq.Size=new Size(56, 24);
            lbPercReq.TabIndex=7;
            lbPercReq.Text="100%";
            lbPercReq.TextAlign=ContentAlignment.TopRight;
            // 
            // lbPercReal
            // 
            lbPercReal.Location=new Point(0, 112);
            lbPercReal.Name="lbPercReal";
            lbPercReal.Size=new Size(56, 24);
            lbPercReal.TabIndex=8;
            lbPercReal.Text="100%";
            lbPercReal.TextAlign=ContentAlignment.TopRight;
            // 
            // GaugePanel
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(lbPercReal);
            Controls.Add(lbPercReq);
            Controls.Add(lbHigh);
            Controls.Add(lbLow);
            Controls.Add(barReal);
            Controls.Add(barReq);
            Controls.Add(lbTitle);
            Name="GaugePanel";
            Size=new Size(300, 168);
            Resize+=GaugePanel_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label barReq;
        private Label barReal;
        private Label lbLow;
        private Label lbHigh;
        private Label lbPercReq;
        private Label lbPercReal;
    }
}
