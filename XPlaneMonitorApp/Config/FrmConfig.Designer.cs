﻿namespace XPlaneMonitorApp
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
            lbInfoReconnect=new Label();
            edDegreesUnit=new ComboBox();
            label7=new Label();
            label6=new Label();
            edUpdPerSecond=new TextBox();
            label5=new Label();
            groupBox2=new GroupBox();
            edRampDistance=new TextBox();
            edRampElevation=new TextBox();
            label3=new Label();
            label4=new Label();
            btnOK=new Button();
            btnCancel=new Button();
            groupBox3=new GroupBox();
            ckMapDarkMode=new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            edHost.TabIndex=0;
            // 
            // edPort
            // 
            edPort.Location=new Point(432, 64);
            edPort.Name="edPort";
            edPort.Size=new Size(88, 27);
            edPort.TabIndex=1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbInfoReconnect);
            groupBox1.Controls.Add(edDegreesUnit);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(edUpdPerSecond);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(edHost);
            groupBox1.Controls.Add(edPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location=new Point(16, 16);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(536, 232);
            groupBox1.TabIndex=0;
            groupBox1.TabStop=false;
            groupBox1.Text="X-Plane Connection";
            // 
            // lbInfoReconnect
            // 
            lbInfoReconnect.AutoSize=true;
            lbInfoReconnect.ForeColor=Color.IndianRed;
            lbInfoReconnect.Location=new Point(16, 192);
            lbInfoReconnect.Name="lbInfoReconnect";
            lbInfoReconnect.Size=new Size(314, 20);
            lbInfoReconnect.TabIndex=9;
            lbInfoReconnect.Text="If you change these settings, please reconnect.";
            // 
            // edDegreesUnit
            // 
            edDegreesUnit.DropDownStyle=ComboBoxStyle.DropDownList;
            edDegreesUnit.FormattingEnabled=true;
            edDegreesUnit.Items.AddRange(new object[] { "Celsius", "Fahrenheit" });
            edDegreesUnit.Location=new Point(352, 136);
            edDegreesUnit.Name="edDegreesUnit";
            edDegreesUnit.Size=new Size(168, 28);
            edDegreesUnit.TabIndex=3;
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(350, 112);
            label7.Name="label7";
            label7.Size=new Size(93, 20);
            label7.TabIndex=7;
            label7.Text="Degrees unit";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.ForeColor=Color.Gray;
            label6.Location=new Point(168, 139);
            label6.Name="label6";
            label6.Size=new Size(80, 20);
            label6.TabIndex=6;
            label6.Text="Values: 1..5";
            // 
            // edUpdPerSecond
            // 
            edUpdPerSecond.Location=new Point(16, 136);
            edUpdPerSecond.Name="edUpdPerSecond";
            edUpdPerSecond.Size=new Size(144, 27);
            edUpdPerSecond.TabIndex=2;
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(14, 112);
            label5.Name="label5";
            label5.Size=new Size(141, 20);
            label5.TabIndex=4;
            label5.Text="Updates per second";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(edRampDistance);
            groupBox2.Controls.Add(edRampElevation);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location=new Point(16, 264);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new Size(536, 112);
            groupBox2.TabIndex=1;
            groupBox2.TabStop=false;
            groupBox2.Text="Ideal Descent Ramp";
            // 
            // edRampDistance
            // 
            edRampDistance.Location=new Point(17, 63);
            edRampDistance.Name="edRampDistance";
            edRampDistance.Size=new Size(159, 27);
            edRampDistance.TabIndex=0;
            // 
            // edRampElevation
            // 
            edRampElevation.Location=new Point(192, 64);
            edRampElevation.Name="edRampElevation";
            edRampElevation.Size=new Size(160, 27);
            edRampElevation.TabIndex=1;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(15, 39);
            label3.Name="label3";
            label3.Size=new Size(101, 20);
            label3.TabIndex=4;
            label3.Text="Distance (nm)";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(190, 40);
            label4.Name="label4";
            label4.Size=new Size(94, 20);
            label4.TabIndex=5;
            label4.Text="Elevation (ft)";
            // 
            // btnOK
            // 
            btnOK.Location=new Point(176, 472);
            btnOK.Name="btnOK";
            btnOK.Size=new Size(104, 40);
            btnOK.TabIndex=11;
            btnOK.Text="OK";
            btnOK.UseVisualStyleBackColor=true;
            btnOK.Click+=btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult=DialogResult.Cancel;
            btnCancel.Location=new Point(288, 472);
            btnCancel.Name="btnCancel";
            btnCancel.Size=new Size(104, 40);
            btnCancel.TabIndex=12;
            btnCancel.Text="Cancel";
            btnCancel.UseVisualStyleBackColor=true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ckMapDarkMode);
            groupBox3.Location=new Point(16, 392);
            groupBox3.Name="groupBox3";
            groupBox3.Size=new Size(536, 72);
            groupBox3.TabIndex=2;
            groupBox3.TabStop=false;
            groupBox3.Text="Other";
            // 
            // ckMapDarkMode
            // 
            ckMapDarkMode.AutoSize=true;
            ckMapDarkMode.Location=new Point(16, 32);
            ckMapDarkMode.Name="ckMapDarkMode";
            ckMapDarkMode.Size=new Size(211, 24);
            ckMapDarkMode.TabIndex=0;
            ckMapDarkMode.Text="Use dark mode on the map";
            ckMapDarkMode.UseVisualStyleBackColor=true;
            // 
            // FrmConfig
            // 
            AcceptButton=btnOK;
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            CancelButton=btnCancel;
            ClientSize=new Size(569, 527);
            Controls.Add(groupBox3);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            MaximizeBox=false;
            MinimizeBox=false;
            Name="FrmConfig";
            ShowInTaskbar=false;
            StartPosition=FormStartPosition.CenterScreen;
            Text="Settings";
            Load+=FrmConfig_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private TextBox edUpdPerSecond;
        private Label label5;
        private Label label6;
        private ComboBox edDegreesUnit;
        private Label label7;
        private Label lbInfoReconnect;
        private GroupBox groupBox3;
        private CheckBox ckMapDarkMode;
    }
}