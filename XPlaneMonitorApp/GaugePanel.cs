namespace XPlaneMonitorApp
{
    public partial class GaugePanel : UserControl
    {

        public class Bar
        {
            public string Name;
            public Color Color;
            public float Max;

            public float Pos;
        }

        public string GaugeTitle
        {
            get => lbTitle.Text; set => lbTitle.Text = value;
        }

        public string GaugeLow { get; set; }

        public string GaugeHigh { get; set; }

        public bool GaugeUnique { get; set; }

        public List<Bar> Bars { get; set; } = new();

        public GaugePanel()
        {
            InitializeComponent();
        }

        private void boxDraw_Paint(object sender, PaintEventArgs e)
        {
            if (Bars.Count == 0) return;

            float y = 0;
            float h = boxDraw.Height / Bars.Count;

            foreach (var bar in Bars)
            {
                e.Graphics.FillRectangle(new SolidBrush(bar.Color), 0, y, boxDraw.Width * (bar.Pos / bar.Max), h);
                y += h;
            }
        }
        
        public void Reload()
        {
            boxDraw.Invalidate();
        }

        public void AddBar(string name, Color color, float max)
        {
            Bar bar = new();
            bar.Name = name;
            bar.Color = color;  
            bar.Max = max;

            Bars.Add(bar);
        }

    }
}
