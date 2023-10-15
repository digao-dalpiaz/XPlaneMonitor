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

        public float Max;
        public float PosRqst;
        public float PosFinal;

        public GaugePanel()
        {
            InitializeComponent();
        }

        private void GaugePanel_Resize(object sender, EventArgs e)
        {
            lbHigh.Left = internalBox.Width - lbHigh.Width - 8;

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

            barRqst.Width = RoundToInt(fullSize * GetPercRqst()) + 1;
            barFinal.Width = RoundToInt(fullSize * GetPercFinal()) + 1;
        }

        public void Recalc()
        {
            lbPercRqst.Text = RoundToInt(GetPercRqst() * 100).ToString() + "%";
            lbPercFinal.Text = RoundToInt(GetPercFinal() * 100).ToString() + "%";

            RecalcCommon();
        }

        private static int RoundToInt(float value)
        {
            return (int)Math.Round(value);
        }

    }
}
