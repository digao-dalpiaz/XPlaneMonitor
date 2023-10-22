using System.Reflection;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp
{
    public partial class GaugePanel : UserControl
    {

        public class Bar
        {
            public string Name;
            public string Extra;
            public readonly Color Color;

            public float Max;

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
        public Image GaugeImage
        {
            get => icon.Image; set => icon.Image = value;
        }

        public int ShowBarsCount = -1;

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
            var count = ShowBarsCount > -1 ? ShowBarsCount : Bars.Count;
            if (count == 0) return;

            var list = Bars.Take(count);

            float y = 0;
            float h = boxDraw.Height / count;

            foreach (var bar in list)
            {
                if (bar.Max == 0) continue;
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

                if (bar.Extra != null)
                {
                    text = bar.Extra;
                    strSize = e.Graphics.MeasureString(text, this.Font);
                    e.Graphics.DrawString(text, this.Font, Brushes.Black, boxDraw.Width - strSize.Width, textY);
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
