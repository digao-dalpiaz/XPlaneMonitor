namespace XPlaneMonitorApp
{
    public partial class GaugePanel : UserControl
    {

        public string GaugeTitle
        {
            get => lbTitle.Text; set => lbTitle.Text = value;
        }

        public string GaugeLow
        {
            get => lbLow.Text; set => lbLow.Text = value;
        }

        public string GaugeHigh
        {
            get => lbHigh.Text; set => lbHigh.Text = value;
        }

        public bool GaugeUnique { get; set; }

        public float Max = 1;
        public float PosRqst;
        public float PosFinal;

        public GaugePanel()
        {
            InitializeComponent();
        }

        private void GaugePanel_Resize(object sender, EventArgs e)
        {
            if (GaugeUnique)
            {
                lbPercRqst.Visible = false;
                barRqst.Visible = false;

                lbPercFinal.Top = lbPercRqst.Top;
                barFinal.Top = barRqst.Top;
            }

            lbHigh.Left = internalBox.Width - lbHigh.Width - 8;
            barFinal.Height = internalBox.Height - barFinal.Top - 8;

            RecalcCommon();
        }

        private float GetPercRqst()
        {
            return PosRqst / Max;
        }

        private float GetPercFinal()
        {
            return PosFinal / Max;
        }

        private void RecalcCommon()
        {
            int fullSize = internalBox.Width - barRqst.Left - 8;

            barRqst.Width = Utils.RoundToInt(fullSize * GetPercRqst()) + 1;
            barFinal.Width = Utils.RoundToInt(fullSize * GetPercFinal()) + 1;
        }

        public void Recalc()
        {
            lbPercRqst.Text = Utils.RoundToInt(GetPercRqst() * 100).ToString() + "%";
            lbPercFinal.Text = Utils.RoundToInt(GetPercFinal() * 100).ToString() + "%";

            RecalcCommon();
        }

        

    }
}
