using System.ComponentModel;

namespace XPlaneMonitorApp.Controls
{
    public partial class ParamPanel : UserControl
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

        public ParamPanel()
        {
            InitializeComponent();
        }

    }
}
