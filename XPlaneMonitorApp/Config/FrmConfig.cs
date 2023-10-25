using XPlaneMonitorApp.Config;
using XPlaneMonitorApp.Functions;

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

            edUpdPerSecond.Text = Vars.Cfg.UpdPerSecond.ToString();
            edDegreesUnit.SelectedIndex = (int)Vars.Cfg.DegreesUnit;

            edRampDistance.Text = Vars.Cfg.RampDistance.ToString();
            edRampElevation.Text = Vars.Cfg.RampElevation.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckBlank(edHost)) return;
            if (CheckBlank(edPort)) return;
            if (CheckBlank(edUpdPerSecond)) return;
            if (CheckBlank(edRampDistance)) return;
            if (CheckBlank(edRampElevation)) return;

            if (CheckInvalidInteger(edPort)) return;
            if (CheckInvalidInteger(edUpdPerSecond)) return;
            if (CheckInvalidInteger(edRampDistance)) return;
            if (CheckInvalidInteger(edRampElevation)) return;

            var interval = int.Parse(edUpdPerSecond.Text);
            if (interval < 1 || interval > 5)
            {
                Messages.Error("Updates per second must be from 1 to 5");
                edUpdPerSecond.Select();
                return;
            }

            //

            Vars.Cfg.Host = edHost.Text;
            Vars.Cfg.Port = int.Parse(edPort.Text);

            Vars.Cfg.UpdPerSecond = interval;
            Vars.Cfg.DegreesUnit = (DegreesUnitType)edDegreesUnit.SelectedIndex;

            Vars.Cfg.RampDistance = int.Parse(edRampDistance.Text);
            Vars.Cfg.RampElevation = int.Parse(edRampElevation.Text);

            ConfigEngine.Save();

            DialogResult = DialogResult.OK;
        }

        private bool CheckInvalidInteger(TextBox ed)
        {
            if (!int.TryParse(ed.Text, out _))
            {
                Messages.Error("Please, type only numbers");
                ed.Select();
                return true;
            }
            return false;
        }

        private bool CheckBlank(TextBox ed)
        {
            ed.Text = ed.Text.Trim();
            if (ed.Text == string.Empty)
            {
                Messages.Error("Required field is empty");
                ed.Select();
                return true;
            }
            return false;
        }

    }
}
