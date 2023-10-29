using System.ComponentModel;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp.Controls
{
    public partial class BorderControl : UserControl
    {
        public string Title { get { return lbTitle.Text; } set { lbTitle.Text = value; } }

        [DefaultValue("")]
        public string Value { get { return lbValue.Text; } set { lbValue.Text = value; } }

        [DefaultValue(null)]
        public Image ValueImage
        {
            get => icon.Image; set => icon.Image = value;
        }

        [DefaultValue(false)]
        public bool ValueImageVisible
        {
            get => icon.Visible; set => icon.Visible = value;
        }
        
        public BorderControl()
        {
            InitializeComponent();

            Utils.SetDoubleBuffered(panelPadding);
        }

        private void panelPadding_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64)), 0, 0, Width-1, Height-1);
        }
    }
}
