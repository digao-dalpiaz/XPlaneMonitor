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

        private void LoadCfg()
        {
            edHost.Text = Vars.Cfg.Host;
            edPort.Text = Vars.Cfg.Port.ToString();

            edUpdPerSecond.Text = Vars.Cfg.UpdPerSecond.ToString();
            edDegreesUnit.SelectedIndex = (int)Vars.Cfg.DegreesUnit;

            edRampDistance.Text = Vars.Cfg.RampDistance.ToString();
            edRampElevation.Text = Vars.Cfg.RampElevation.ToString();

            ckMapDarkMode.Checked = Vars.Cfg.MapDarkMode;
        }

        private void SaveCfg()
        {
            Vars.Cfg.Host = edHost.Text;
            Vars.Cfg.Port = int.Parse(edPort.Text);

            Vars.Cfg.UpdPerSecond = int.Parse(edUpdPerSecond.Text);
            Vars.Cfg.DegreesUnit = (DegreesUnitType)edDegreesUnit.SelectedIndex;

            Vars.Cfg.RampDistance = int.Parse(edRampDistance.Text);
            Vars.Cfg.RampElevation = int.Parse(edRampElevation.Text);

            Vars.Cfg.MapDarkMode = ckMapDarkMode.Checked;
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            LoadCfg();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateField(edHost)) return;
            if (!ValidateField(edPort, true, i => i > 0 && i <= ushort.MaxValue, "Invalid port number")) return;
            if (!ValidateField(edUpdPerSecond, true, i => i >= 1 && i <= 5, "Updates per second must be from 1 to 5")) return;
            if (!ValidateField(edRampDistance, true, i => i > 0, "Ramp distance must be greater than zero")) return;
            if (!ValidateField(edRampElevation, true, i => i > 0, "Ramp elevation must be greater than zero")) return;

            //

            SaveCfg();

            ConfigEngine.Save();

            DialogResult = DialogResult.OK;
        }

        private static bool ValidateField(TextBox ed, bool onlyInt = false, Func<int, bool> intValidation = null, string msgIntValidation = null)
        {
            ed.Text = ed.Text.Trim();
            if (ed.Text == string.Empty)
            {
                Messages.Error("Required field is empty");
                ed.Select();
                return false;
            }

            if (onlyInt)
            {
                if (!int.TryParse(ed.Text, out int i))
                {
                    Messages.Error("Please, type only numbers");
                    ed.Select();
                    return false;
                }

                if (intValidation != null)
                {
                    if (!intValidation(i))
                    {
                        Messages.Error(msgIntValidation);
                        ed.Select();
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
