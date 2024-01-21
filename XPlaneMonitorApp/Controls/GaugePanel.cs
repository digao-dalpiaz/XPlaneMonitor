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
            public readonly bool HidePercent;

            public float Max;
            public float Pos;

            public Bar(string name, Color color, float max, bool hidePercent)
            {
                this.Name = name;
                this.Color = color;
                this.Max = max;
                this.HidePercent = hidePercent;
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

        public readonly List<Bar> Bars = [];

        public GaugePanel()
        {
            InitializeComponent();

            Utils.SetDoubleBuffered(boxDraw);
        }

        private void boxDraw_Paint(object sender, PaintEventArgs e)
        {
            var count = ShowBarsCount > -1 ? ShowBarsCount : Bars.Count;
            if (count == 0) return;

            var list = Bars.Take(count);

            double y = 0;
            double h = Utils.Div(boxDraw.Height, count);

            foreach (var bar in list)
            {
                if (bar.Max == 0) continue;
                var perc = Utils.Div(bar.Pos, bar.Max);

                Drawing.FillRectangle(e.Graphics, new SolidBrush(bar.Color), 0, y, boxDraw.Width * perc, h);

                var fontHeight = e.Graphics.MeasureString("A", this.Font).Height;
                var textY = y + Utils.Div(h - fontHeight, 2);

                if (!bar.HidePercent)
                {
                    var text = Utils.RoundToInt(perc * 100) + "%";
                    var strSize = e.Graphics.MeasureString(text, this.Font);
                    Drawing.DrawString(e.Graphics, text, this.Font, Brushes.Gray, Utils.Div(boxDraw.Width - strSize.Width, 2), textY);
                }

                if (bar.Name != null)
                {
                    Drawing.DrawString(e.Graphics, bar.Name, this.Font, Brushes.White, 4, textY);
                }

                if (bar.Extra != null)
                {
                    Font f = new(this.Font.Name, this.Font.Size, FontStyle.Bold);

                    var text = bar.Extra;
                    var strSize = e.Graphics.MeasureString(text, f);
                    Drawing.DrawString(e.Graphics, text, f, Brushes.White, boxDraw.Width - strSize.Width, textY);
                }

                y += h;
            }
        }

        public void Reload()
        {
            boxDraw.Invalidate();
        }

        public void AddBar(string name, Color color, float max, bool hidePercent = false)
        {
            Bars.Add(new Bar(name, color, max, hidePercent));
        }

        private void GaugePanel_Resize(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
