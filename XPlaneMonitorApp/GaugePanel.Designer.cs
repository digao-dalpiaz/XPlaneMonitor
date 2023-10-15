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
            barRqst=new Label();
            barFinal=new Label();
            lbLow=new Label();
            lbHigh=new Label();
            lbPercRqst=new Label();
            lbPercFinal=new Label();
            panel1=new Panel();
            internalBox=new Panel();
            panel1.SuspendLayout();
            internalBox.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.BackColor=Color.Gray;
            lbTitle.Dock=DockStyle.Top;
            lbTitle.Font=new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.ForeColor=Color.WhiteSmoke;
            lbTitle.Location=new Point(0, 0);
            lbTitle.Name="lbTitle";
            lbTitle.Size=new Size(373, 40);
            lbTitle.TabIndex=2;
            lbTitle.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // barRqst
            // 
            barRqst.BackColor=Color.Gold;
            barRqst.Location=new Point(64, 72);
            barRqst.Name="barRqst";
            barRqst.Size=new Size(298, 24);
            barRqst.TabIndex=3;
            // 
            // barFinal
            // 
            barFinal.BackColor=Color.ForestGreen;
            barFinal.Location=new Point(64, 98);
            barFinal.Name="barFinal";
            barFinal.Size=new Size(298, 40);
            barFinal.TabIndex=4;
            // 
            // lbLow
            // 
            lbLow.Font=new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbLow.ForeColor=Color.Gray;
            lbLow.Location=new Point(64, 48);
            lbLow.Name="lbLow";
            lbLow.Size=new Size(120, 24);
            lbLow.TabIndex=5;
            lbLow.Text="low";
            // 
            // lbHigh
            // 
            lbHigh.Font=new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbHigh.ForeColor=Color.Gray;
            lbHigh.Location=new Point(248, 48);
            lbHigh.Name="lbHigh";
            lbHigh.Size=new Size(120, 24);
            lbHigh.TabIndex=6;
            lbHigh.Text="high";
            lbHigh.TextAlign=ContentAlignment.TopRight;
            // 
            // lbPercRqst
            // 
            lbPercRqst.ForeColor=Color.Black;
            lbPercRqst.Location=new Point(8, 72);
            lbPercRqst.Name="lbPercRqst";
            lbPercRqst.Size=new Size(50, 24);
            lbPercRqst.TabIndex=7;
            lbPercRqst.Text="100%";
            lbPercRqst.TextAlign=ContentAlignment.TopRight;
            // 
            // lbPercFinal
            // 
            lbPercFinal.ForeColor=Color.Black;
            lbPercFinal.Location=new Point(8, 104);
            lbPercFinal.Name="lbPercFinal";
            lbPercFinal.Size=new Size(50, 24);
            lbPercFinal.TabIndex=8;
            lbPercFinal.Text="100%";
            lbPercFinal.TextAlign=ContentAlignment.TopRight;
            // 
            // panel1
            // 
            panel1.BackColor=Color.Gray;
            panel1.Controls.Add(internalBox);
            panel1.Dock=DockStyle.Fill;
            panel1.Location=new Point(0, 0);
            panel1.Name="panel1";
            panel1.Padding=new Padding(5);
            panel1.Size=new Size(383, 212);
            panel1.TabIndex=9;
            // 
            // internalBox
            // 
            internalBox.BackColor=Color.White;
            internalBox.Controls.Add(barFinal);
            internalBox.Controls.Add(lbTitle);
            internalBox.Controls.Add(lbPercFinal);
            internalBox.Controls.Add(barRqst);
            internalBox.Controls.Add(lbPercRqst);
            internalBox.Controls.Add(lbLow);
            internalBox.Controls.Add(lbHigh);
            internalBox.Dock=DockStyle.Fill;
            internalBox.Location=new Point(5, 5);
            internalBox.Name="internalBox";
            internalBox.Size=new Size(373, 202);
            internalBox.TabIndex=0;
            // 
            // GaugePanel
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(panel1);
            Name="GaugePanel";
            Size=new Size(383, 212);
            Resize+=GaugePanel_Resize;
            panel1.ResumeLayout(false);
            internalBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label barRqst;
        private Label barFinal;
        private Label lbLow;
        private Label lbHigh;
        private Label lbPercRqst;
        private Label lbPercFinal;
        private Panel panel1;
        private Panel internalBox;
    }
}
