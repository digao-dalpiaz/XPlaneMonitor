using System.Net;
using System.Net.Sockets;
using System.Text;

namespace XPlaneMonitorApp.Communicator
{
    public class XPlaneCommunicator
    {

        private readonly Control _invokeControl;

        private readonly List<RefDataSubscription> _subscriptions = new();

        private string[] nnnnnnnnnnnnnn =
        {
            "sim/aircraft/view/acf_Vso", //parametro de velocidade: de stol
            "sim/aircraft/view/acf_Vfe", //parametro de velocidade: máxima com flaps full
            "sim/aircraft/view/acf_Vs", //parametro de velocidade:
            "sim/aircraft/view/acf_Vno", //parametro de velocidade:
            "sim/aircraft/view/acf_Vne", //parametro de velocidade:
            "sim/aircraft/gear/acf_gear_retract", //trem de pouso extensível
            "sim/cockpit/autopilot/autopilot_mode",
            "sim/cockpit/autopilot/airspeed",
            "sim/cockpit/autopilot/heading",
            "sim/cockpit/autopilot/heading_mag",
            "sim/cockpit/engine/APU_running",
            "sim/cockpit/engine/APU_N1",
            "sim/cockpit/misc/compass_indicated", //proa em graus
            "sim/cockpit/switches/auto_brake_settings",
            "sim/cockpit/switches/dumping_fuel",
            "sim/flightmodel/controls/dist", //distancia viajada em metros
            "sim/flightmodel/position/true_psi", //norte absoluto
            "sim/flightmodel/position/mag_psi", //norte magnetico
            "sim/flightmodel/position/magnetic_variation",
            "sim/time/total_flight_time_sec",
            "sim/cockpit2/autopilot/autothrottle_enabled", //Auto-throttle: -1=hard off, not even armed. 0=servos declutched (arm, hold), 1=airspeed hold, 2=N1 target hold, 3=retard, 4=reserved for future use	
            "sim/cockpit2/gauges/indicators/wind_heading_deg_mag",
            "sim/cockpit2/gauges/indicators/wind_speed_kts",
            "sim/cockpit2/gauges/indicators/airspeed_acceleration_kts_sec_pilot",
            "sim/cockpit2/gauges/indicators/airspeed_kts_pilot",
            "sim/cockpit2/gauges/indicators/altitude_ft_pilot",
            "sim/cockpit2/gauges/indicators/vvi_fpm_pilot",
            "sim/cockpit2/gauges/indicators/true_airspeed_kts_pilot",
            "sim/cockpit2/gauges/indicators/ground_speed_kt",
            "sim/cockpit2/gauges/indicators/radio_altimeter_height_ft_pilot",
            "sim/cockpit2/switches/dump_fuel",
            "sim/cockpit2/temperature/outside_air_temp_degc",
            "sim/flightmodel2/position/true_psi",
            "sim/flightmodel2/position/mag_psi",
            "sim/flightmodel2/position/true_airspeed"
        };

        private UdpClient _server;
        private UdpClient _client;

        private ConnectionStatus _connectionStatus = ConnectionStatus.DISCONNECTED;
        public ConnectionStatus Status { get { return _connectionStatus; } }

        public event Action OnReceived;
        public event Action OnStatusChanged;

        private string _host;
        private int _port;

        public XPlaneCommunicator(RefDataContractList refsData, Control invokeControl)
        {
            _invokeControl = invokeControl;

            _subscriptions = refsData.GetSubscriptions();
        }

        private void ChangeStatus(ConnectionStatus status)
        {
            _connectionStatus = status;
            RunSync(() => OnStatusChanged.Invoke());
        }

        public void Connect(string host, int port)
        {
            _host = host;
            _port = port;

            ChangeStatus(ConnectionStatus.CONNECTING);

            _client = new UdpClient(host, port);

            var ep = (IPEndPoint)_client.Client.LocalEndPoint;
            _server = new UdpClient(ep);
            _server.BeginReceive(ReceiveCallback, null);

            RequestRefs(true);
        }

        public void Disconnect()
        {
            RequestRefs(false);

            _server.Close();
            _client.Close();

            ChangeStatus(ConnectionStatus.DISCONNECTED);
        }

        private void RequestRefs(bool subscribe)
        {
            for (int i = 0; i < _subscriptions.Count; i++)
            {
                SendRef(_subscriptions[i].GetName(), i+1, subscribe ? 2 : 0);
            }
        }

        private void SendRef(string refName, int refId, int interval)
        {
            var data = new byte[413];

            int pos = 0;

            var incPart = (byte[] part) =>
            {
                Array.Copy(part, 0, data, pos, part.Length);
                pos += part.Length;
            };

            incPart(Encoding.ASCII.GetBytes("RREF\0"));
            incPart(BitConverter.GetBytes(interval));
            incPart(BitConverter.GetBytes(refId));
            incPart(Encoding.ASCII.GetBytes(refName));

            _client.Send(data);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] response;
            try
            {
                IPEndPoint? remoteEndPoint = null;
                response = _server.EndReceive(ar, ref remoteEndPoint);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (SocketException ex)
            {
                Disconnect();
                RunSync(() =>
                {
                    string msg = ex.ErrorCode == 10054 ? string.Format("X-Plane not found running at {0}:{1}", _host, _port) : ex.Message;
                    MessageBox.Show(msg, "Error");
                });
                return;
            }
            if (Status == ConnectionStatus.CONNECTING) ChangeStatus(ConnectionStatus.CONNECTED);
            ParseResponse(response);
            _server.BeginReceive(ReceiveCallback, null);
        }

        private void ParseResponse(byte[] buffer)
        {
            var header = Encoding.ASCII.GetString(buffer, 0, 5);
            if (header != "RREF,") throw new Exception("Wrong message header received: " + header);

            RunSync(() => OnReceived.Invoke());

            for (int i = 5; i < buffer.Length; i += 8)
            {
                var id = BitConverter.ToInt32(buffer, i);
                var value = BitConverter.ToSingle(buffer, i + 4);

                var r = _subscriptions[id - 1];
                
                if (!r.AlreadyLoadedOnce || r.Value != value)
                {
                    r.Value = value;
                    r.AlreadyLoadedOnce = true;

                    RunSync(() => r.Contract.Proc(r));
                }
            }
        }

        private void RunSync(Action action)
        {
            try
            {
                _invokeControl.Invoke(action);
            } catch (ObjectDisposedException) { }
        }

    }
}
