namespace XPlaneMonitorApp.Controls
{
    partial class GridPanel
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
            box=new Panel();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.BackColor=Color.FromArgb(64, 64, 64);
            lbTitle.Dock=DockStyle.Top;
            lbTitle.ForeColor=Color.Silver;
            lbTitle.Location=new Point(0, 0);
            lbTitle.Name="lbTitle";
            lbTitle.Size=new Size(564, 24);
            lbTitle.TabIndex=88;
            lbTitle.Text="Title";
            lbTitle.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // box
            // 
            box.Dock=DockStyle.Fill;
            box.Location=new Point(0, 24);
            box.Name="box";
            box.Size=new Size(564, 325);
            box.TabIndex=87;
            // 
            // GridPanel
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(box);
            Controls.Add(lbTitle);
            Name="GridPanel";
            Size=new Size(564, 349);
            Resize+=GridPanel_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Panel box;
    }
}
