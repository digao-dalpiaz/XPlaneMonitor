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
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Dock=DockStyle.Left;
            lbTitle.Location=new Point(1, 1);
            lbTitle.Name="lbTitle";
            lbTitle.Padding=new Padding(10, 0, 0, 0);
            lbTitle.Size=new Size(136, 148);
            lbTitle.TabIndex=0;
            lbTitle.Text="Title";
            lbTitle.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // lbValue
            // 
            lbValue.Dock=DockStyle.Fill;
            lbValue.Font=new Font("Bahnschrift SemiCondensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbValue.Location=new Point(137, 1);
            lbValue.Name="lbValue";
            lbValue.Size=new Size(189, 148);
            lbValue.TabIndex=1;
            lbValue.Text="Value";
            lbValue.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // BorderControl
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            Controls.Add(lbValue);
            Controls.Add(lbTitle);
            Name="BorderControl";
            Padding=new Padding(1);
            Size=new Size(327, 150);
            Paint+=BorderPanel_Paint;
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label lbValue;
    }
}
