using System.ComponentModel;

namespace XPlaneMonitorApp.Controls
{
    public partial class BorderControl : UserControl
    {
        public string Title { get { return lbTitle.Text; } set { lbTitle.Text = value; } }

        [DefaultValue("")]
        public string Value { get { return lbValue.Text; } set { lbValue.Text = value; } }

        public BorderControl()
        {
            InitializeComponent();
        }

        private void BorderPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Gray), 0, 0, Width-1, Height-1);
        }
    }
}
