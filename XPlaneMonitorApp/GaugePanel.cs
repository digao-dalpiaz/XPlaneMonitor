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
        public float PosReq;
        public float PosReal;

        public GaugePanel()
        {
            InitializeComponent();
        }

        private void GaugePanel_Resize(object sender, EventArgs e)
        {
            lbHigh.Left = Width - lbHigh.Width - 8;

            RecalcCommon();
        }

        private float GetPercReq()
        {
            return PosReq / Max;
        }

        private float GetPercReal()
        {
            return PosReal / Max;
        }

        private void RecalcCommon()
        {
            int fullSize = Width - barReq.Left - 8;

            barReq.Width = RoundToInt(fullSize * GetPercReq());
            barReal.Width = RoundToInt(fullSize * GetPercReal());
        }

        public void Recalc()
        {
            lbPercReq.Text = RoundToInt(GetPercReq()).ToString() + "%";
            lbPercReal.Text = RoundToInt(GetPercReal()).ToString() + "%";

            RecalcCommon();
        }

        private static int RoundToInt(float value)
        {
            return (int)Math.Round(value);
        }

    }
}
