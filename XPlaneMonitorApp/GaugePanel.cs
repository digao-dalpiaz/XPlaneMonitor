using System.Reflection;

namespace XPlaneMonitorApp
{
    public partial class GaugePanel : UserControl
    {

        public class Bar
        {
            public readonly string Name;
            public readonly Color Color;
            public readonly float Max;

            public float Pos;

            public Bar(string name, Color color, float max)
            {
                this.Name = name;
                this.Color = color;
                this.Max = max;
            }
        }

        public string GaugeTitle
        {
            get => lbTitle.Text; set => lbTitle.Text = value;
        }

        public string GaugeLow { get; set; }

        public string GaugeHigh { get; set; }

        public readonly List<Bar> Bars = new();

        public GaugePanel()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, boxDraw, new object[] { true });
        }

        private void boxDraw_Paint(object sender, PaintEventArgs e)
        {
            if (Bars.Count == 0) return;

            float y = 0;
            float h = boxDraw.Height / Bars.Count;

            foreach (var bar in Bars)
            {
                var perc = bar.Pos / bar.Max;

                e.Graphics.FillRectangle(new SolidBrush(bar.Color), 0, y, boxDraw.Width * perc, h);

                var text = Utils.RoundToInt(perc * 100).ToString() + "%";
                var strSize = e.Graphics.MeasureString(text, this.Font);
                var textY = y + ((h - strSize.Height) / 2);
                e.Graphics.DrawString(text, this.Font, Brushes.Black,
                    (boxDraw.Width - strSize.Width) / 2, textY);

                if (bar.Name != null)
                {
                    e.Graphics.DrawString(bar.Name, this.Font, Brushes.Gray, 4, textY);
                }

                y += h;
            }
        }
        
        public void Reload()
        {
            boxDraw.Invalidate();
        }

        public void AddBar(string name, Color color, float max)
        {
            Bars.Add(new Bar(name, color, max));
        }

    }
}
