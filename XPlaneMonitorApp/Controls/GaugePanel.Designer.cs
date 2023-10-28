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
            boxExternal=new Panel();
            icon=new PictureBox();
            boxInternal=new Panel();
            boxDraw=new Panel();
            boxExternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            boxInternal.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Dock=DockStyle.Top;
            lbTitle.Font=new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.ForeColor=Color.WhiteSmoke;
            lbTitle.Location=new Point(0, 0);
            lbTitle.Name="lbTitle";
            lbTitle.Size=new Size(373, 32);
            lbTitle.TabIndex=2;
            lbTitle.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // boxExternal
            // 
            boxExternal.BackColor=Color.FromArgb(64, 64, 64);
            boxExternal.Controls.Add(icon);
            boxExternal.Controls.Add(boxInternal);
            boxExternal.Dock=DockStyle.Fill;
            boxExternal.Location=new Point(0, 0);
            boxExternal.Name="boxExternal";
            boxExternal.Padding=new Padding(5);
            boxExternal.Size=new Size(383, 212);
            boxExternal.TabIndex=9;
            // 
            // icon
            // 
            icon.Location=new Point(9, 2);
            icon.Name="icon";
            icon.Size=new Size(32, 32);
            icon.SizeMode=PictureBoxSizeMode.Zoom;
            icon.TabIndex=0;
            icon.TabStop=false;
            // 
            // boxInternal
            // 
            boxInternal.Controls.Add(boxDraw);
            boxInternal.Controls.Add(lbTitle);
            boxInternal.Dock=DockStyle.Fill;
            boxInternal.Location=new Point(5, 5);
            boxInternal.Name="boxInternal";
            boxInternal.Size=new Size(373, 202);
            boxInternal.TabIndex=0;
            // 
            // boxDraw
            // 
            boxDraw.BackColor=Color.Black;
            boxDraw.Dock=DockStyle.Fill;
            boxDraw.Location=new Point(0, 32);
            boxDraw.Name="boxDraw";
            boxDraw.Size=new Size(373, 170);
            boxDraw.TabIndex=3;
            boxDraw.Paint+=boxDraw_Paint;
            // 
            // GaugePanel
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(boxExternal);
            Name="GaugePanel";
            Size=new Size(383, 212);
            boxExternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            boxInternal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Panel boxExternal;
        private Panel boxInternal;
        private Panel boxDraw;
        private PictureBox icon;
    }
}
