namespace XPlaneMonitorApp
{
    partial class FrmConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1=new Label();
            label2=new Label();
            edHost=new TextBox();
            edPort=new TextBox();
            groupBox1=new GroupBox();
            groupBox2=new GroupBox();
            edRampDistance=new TextBox();
            edRampElevation=new TextBox();
            label3=new Label();
            label4=new Label();
            btnOK=new Button();
            btnCancel=new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(14, 40);
            label1.Name="label1";
            label1.Size=new Size(40, 20);
            label1.TabIndex=0;
            label1.Text="Host";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(430, 40);
            label2.Name="label2";
            label2.Size=new Size(35, 20);
            label2.TabIndex=1;
            label2.Text="Port";
            // 
            // edHost
            // 
            edHost.Location=new Point(16, 64);
            edHost.Name="edHost";
            edHost.Size=new Size(408, 27);
            edHost.TabIndex=2;
            // 
            // edPort
            // 
            edPort.Location=new Point(432, 64);
            edPort.Name="edPort";
            edPort.Size=new Size(88, 27);
            edPort.TabIndex=3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(edHost);
            groupBox1.Controls.Add(edPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location=new Point(16, 16);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(536, 112);
            groupBox1.TabIndex=4;
            groupBox1.TabStop=false;
            groupBox1.Text="X-Plane Connection";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(edRampDistance);
            groupBox2.Controls.Add(edRampElevation);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location=new Point(16, 144);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new Size(536, 120);
            groupBox2.TabIndex=5;
            groupBox2.TabStop=false;
            groupBox2.Text="Ideal Descent Ramp";
            // 
            // edRampDistance
            // 
            edRampDistance.Location=new Point(17, 71);
            edRampDistance.Name="edRampDistance";
            edRampDistance.Size=new Size(159, 27);
            edRampDistance.TabIndex=6;
            // 
            // edRampElevation
            // 
            edRampElevation.Location=new Point(192, 72);
            edRampElevation.Name="edRampElevation";
            edRampElevation.Size=new Size(160, 27);
            edRampElevation.TabIndex=7;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(15, 47);
            label3.Name="label3";
            label3.Size=new Size(101, 20);
            label3.TabIndex=4;
            label3.Text="Distance (nm)";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(190, 48);
            label4.Name="label4";
            label4.Size=new Size(94, 20);
            label4.TabIndex=5;
            label4.Text="Elevation (ft)";
            // 
            // btnOK
            // 
            btnOK.Location=new Point(176, 280);
            btnOK.Name="btnOK";
            btnOK.Size=new Size(104, 40);
            btnOK.TabIndex=6;
            btnOK.Text="OK";
            btnOK.UseVisualStyleBackColor=true;
            btnOK.Click+=btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult=DialogResult.Cancel;
            btnCancel.Location=new Point(288, 280);
            btnCancel.Name="btnCancel";
            btnCancel.Size=new Size(104, 40);
            btnCancel.TabIndex=7;
            btnCancel.Text="Cancel";
            btnCancel.UseVisualStyleBackColor=true;
            // 
            // FrmConfig
            // 
            AcceptButton=btnOK;
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            CancelButton=btnCancel;
            ClientSize=new Size(569, 334);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            Name="FrmConfig";
            ShowInTaskbar=false;
            StartPosition=FormStartPosition.CenterScreen;
            Text="Settings";
            Load+=FrmConfig_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox edHost;
        private TextBox edPort;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox edRampDistance;
        private TextBox edRampElevation;
        private Label label3;
        private Label label4;
        private Button btnOK;
        private Button btnCancel;
    }
}