using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp.Controls
{
    public partial class GridPanel : UserControl
    {
        public GridPanel()
        {
            InitializeComponent();

            Utils.SetDoubleBuffered(boxDraw);
        }

        public string Title
        {
            get => lbTitle.Text; set => lbTitle.Text = value;
        }

        public event PaintEventHandler OnBoxPaint
        {
            add { boxDraw.Paint += value; }
            remove { boxDraw.Paint -= value; }
        }

        public void Reload()
        {
            boxDraw.Invalidate();
        }

        private void GridPanel_Resize(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
