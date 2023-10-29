namespace XPlaneMonitorApp.Controls
{
    partial class BorderControl
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
            lbValue=new Label();
            icon=new PictureBox();
            panelPadding=new Panel();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            panelPadding.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Dock=DockStyle.Left;
            lbTitle.Font=new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbTitle.Location=new Point(1, 1);
            lbTitle.Name="lbTitle";
            lbTitle.Size=new Size(128, 132);
            lbTitle.TabIndex=0;
            lbTitle.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // lbValue
            // 
            lbValue.Dock=DockStyle.Fill;
            lbValue.Font=new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lbValue.Location=new Point(129, 1);
            lbValue.Name="lbValue";
            lbValue.Size=new Size(322, 132);
            lbValue.TabIndex=1;
            lbValue.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // icon
            // 
            icon.Dock=DockStyle.Right;
            icon.Location=new Point(451, 1);
            icon.Name="icon";
            icon.Size=new Size(32, 132);
            icon.SizeMode=PictureBoxSizeMode.Zoom;
            icon.TabIndex=98;
            icon.TabStop=false;
            icon.Visible=false;
            // 
            // panelPadding
            // 
            panelPadding.Controls.Add(lbValue);
            panelPadding.Controls.Add(icon);
            panelPadding.Controls.Add(lbTitle);
            panelPadding.Dock=DockStyle.Fill;
            panelPadding.Location=new Point(0, 0);
            panelPadding.Name="panelPadding";
            panelPadding.Padding=new Padding(1);
            panelPadding.Size=new Size(484, 134);
            panelPadding.TabIndex=99;
            panelPadding.Paint+=panelPadding_Paint;
            // 
            // BorderControl
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(panelPadding);
            Name="BorderControl";
            Size=new Size(484, 134);
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            panelPadding.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label lbValue;
        private PictureBox icon;
        private Panel panelPadding;
    }
}
