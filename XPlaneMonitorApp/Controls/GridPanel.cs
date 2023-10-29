using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp.Controls
{
    public partial class GridPanel : UserControl
    {
        public GridPanel()
        {
            InitializeComponent();

            Utils.SetDoubleBuffered(box);
        }

        public string Title
        {
            get => lbTitle.Text; set => lbTitle.Text = value;
        }

        public event PaintEventHandler OnBoxPaint
        {
            add { box.Paint += value; }
            remove { box.Paint -= value; }
        }

        public void Reload()
        {
            box.Invalidate();
        }

        private void GridPanel_Resize(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
