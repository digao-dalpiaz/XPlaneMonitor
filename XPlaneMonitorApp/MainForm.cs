
using XPlaneConnector;
using XPlaneConnector.DataRefs;

namespace XPlaneMonitorApp
{
    public partial class MainForm : Form
    {

        private XPlaneConnector.XPlaneConnector _xp;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gaugeFlaps.Max = 1;

            _xp = new("127.0.0.1", 49000);
            SubscribeAll();
            _xp.OnDataRefReceived += OnDataRefReceived;
            _xp.Start();
        }

        private void SubscribeAll()
        {
            Subscribe(DataRefs.Cockpit2EngineActuatorsThrottleRatioAll);
            Subscribe(DataRefs.Flightmodel2ControlsFlap1DeployRatio);
            Subscribe(DataRefs.FlightmodelControlsFlaprqst);
            Subscribe(DataRefs.FlightmodelPositionLatitude);
            Subscribe(DataRefs.FlightmodelPositionLongitude);
        }

        private void Subscribe(DataRefElement element)
        {
            _xp.Subscribe(element, 2);
        }

        private void OnDataRefReceived(DataRefElement d)
        {
            Invoke(new Action(() =>
            {
                if (d.DataRef == DataRefs.FlightmodelControlsFlaprqst.DataRef)
                {
                    gaugeFlaps.PosRqst = d.Value;
                    gaugeFlaps.Recalc();
                } else
                if (d.DataRef == DataRefs.Flightmodel2ControlsFlap1DeployRatio.DataRef)
                {
                    gaugeFlaps.PosFinal = d.Value;
                    gaugeFlaps.Recalc();
                }
            }));
        }
        
    }
}