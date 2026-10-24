using XPlaneMonitorApp.Functions;
using System.ComponentModel;

namespace XPlaneMonitorApp.Controls
{
    public partial class GridPanel : UserControl
    {
        public GridPanel()
        {
            InitializeComponent();

            Utils.SetDoubleBuffered(boxDraw);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
