
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
            gaugeN2.Max = 1;

            _xp = new("127.0.0.1", 49000);
            SubscribeAll();
            _xp.OnDataRefReceived += OnDataRefReceived;
            _xp.Start();
        }

        private void SubscribeAll()
        {
            Subscribe(DataRefs.FlightmodelControlsFlaprqst);
            Subscribe(DataRefs.Flightmodel2ControlsFlapHandleDeployRatio);

            Subscribe(DataRefs.Cockpit2EngineActuatorsThrottleRatioAll);
            Subscribe(DataRefs.FlightmodelEngineENGNEGT);

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
                }
                else
                if (d.DataRef == DataRefs.Flightmodel2ControlsFlapHandleDeployRatio.DataRef)
                {
                    gaugeFlaps.PosFinal = d.Value;
                    gaugeFlaps.Recalc();
                }
                else
                if (d.DataRef == DataRefs.Cockpit2EngineActuatorsThrottleRatioAll.DataRef)
                {
                    gaugeThrottle.PosRqst = d.Value;
                    gaugeThrottle.Recalc();
                }
                else
                if (d.DataRef == DataRefs.FlightmodelEngineENGNEGT.DataRef)
                {
                    gaugeN2.PosFinal = d.Value;
                    gaugeN2.Recalc();
                }
            }));
        }

    }
}