using XPlaneMonitorApp.Config;

namespace XPlaneMonitorApp
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            edHost.Text = Vars.Cfg.Host;
            edPort.Text = Vars.Cfg.Port.ToString();

            edRampDistance.Text = Vars.Cfg.RampDistance.ToString();
            edRampElevation.Text = Vars.Cfg.RampElevation.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            edHost.Text = edHost.Text.Trim();
            edPort.Text = edPort.Text.Trim();
            edRampDistance.Text = edRampDistance.Text.Trim();
            edRampElevation.Text = edRampElevation.Text.Trim();

            //

            Vars.Cfg.Host = edHost.Text;
            Vars.Cfg.Port = int.Parse(edPort.Text);

            Vars.Cfg.RampDistance = int.Parse(edRampDistance.Text);
            Vars.Cfg.RampElevation = int.Parse(edRampElevation.Text);

            ConfigEngine.Save();

            DialogResult = DialogResult.OK;
        }
    }
}
