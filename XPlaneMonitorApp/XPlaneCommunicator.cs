using System.Net;
using System.Net.Sockets;
using System.Text;

namespace XPlaneMonitorApp
{
    public class XPlaneCommunicator
    {

        private readonly List<RefData> _refsData;
        private readonly Control _invokeControl;

        private string[] nnnnnnnnnnnnnn = 
        {
            "sim/aircraft/view/acf_Vso", //parametro de velocidade: de stol
            "sim/aircraft/view/acf_Vfe", //parametro de velocidade: máxima com flaps full
            "sim/aircraft/view/acf_Vs", //parametro de velocidade:
            "sim/aircraft/view/acf_Vno", //parametro de velocidade:
            "sim/aircraft/view/acf_Vne", //parametro de velocidade:
            "sim/aircraft/engine/acf_num_engines", //numero de motores
            "sim/aircraft/controls/acf_flap_detents", //quantidade de dentes de flap
            "sim/aircraft/gear/acf_gear_retract", //trem de pouso extensível
            "sim/aircraft/weight/acf_m_fuel_tot", //capacidade total de combustivel
            "sim/cockpit/autopilot/autopilot_mode",
            "sim/cockpit/autopilot/airspeed",
            "sim/cockpit/autopilot/heading",
            "sim/cockpit/autopilot/heading_mag",
            "sim/cockpit/engine/APU_running",
            "sim/cockpit/engine/APU_N1",
            "sim/cockpit/misc/compass_indicated", //proa em graus
            "sim/cockpit/switches/auto_brake_settings",
            "sim/cockpit/switches/dumping_fuel",
            "sim/cockpit/switches/gear_handle_status",
            "sim/cockpit/switches/no_smoking",
            "sim/cockpit/switches/fasten_seat_belts",
            "sim/flightmodel/controls/sbrkrat", //speed brake deploy
            "sim/flightmodel/controls/dist", //distancia viajada em metros
            "sim/flightmodel/controls/elv_trim",
            "sim/flightmodel/controls/flaprat", //posicao flap atual
            "sim/flightmodel/controls/l_brake_add",
            "sim/flightmodel/controls/r_brake_add",
            "sim/flightmodel/controls/lsplrdef", //left spoiler
            "sim/flightmodel/controls/rsplrdef", //right spoiler
            "sim/flightmodel/controls/sbrkrqst", //speed brake request  -0.5 = armed, 0 = off, 1 = max deployment
            "sim/flightmodel/controls/parkbrake",
            //"sim/flightmodel/engine/ENGN_N1_1",
            //"sim/flightmodel/engine/ENGN_power_"
            //"sim/flightmodel/engine/ENGN_thro_"
            "sim/flightmodel/movingparts/gear1def", //tem do 1 ao 5, aqui peguei só o 1 por enquanto
            "sim/flightmodel/position/latitude",
            "sim/flightmodel/position/longitude",
            "sim/flightmodel/position/true_psi", //norte absoluto
            "sim/flightmodel/position/mag_psi", //norte magnetico
            "sim/flightmodel/position/magnetic_variation",
            "sim/flightmodel/weight/m_fuel1", //kgs
            "sim/flightmodel/weight/m_fuel2",//kgs
            "sim/flightmodel/weight/m_fuel3",//kgs
            "sim/flightmodel/weight/m_fuel_total",//kgs
            "sim/time/total_flight_time_sec",
            "sim/cockpit2/autopilot/autothrottle_enabled", //Auto-throttle: -1=hard off, not even armed. 0=servos declutched (arm, hold), 1=airspeed hold, 2=N1 target hold, 3=retard, 4=reserved for future use	
            "sim/cockpit2/controls/speedbrake_ratio", //deflexao do speed brake
            "sim/cockpit2/controls/parking_brake_ratio",
            "sim/cockpit2/controls/left_brake_ratio",
            "sim/cockpit2/controls/right_brake_ratio",
            "sim/cockpit2/controls/gear_handle_down",
            "sim/cockpit2/controls/gear_handle_request",
            "sim/cockpit2/controls/elevator_trim",
            //"sim/cockpit2/engine/actuators/throttle_ratio_"
            //"sim/cockpit2/engine/indicators/N1_percent_"
            //"sim/cockpit2/fuel/fuel_quantity_"
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
            "sim/cockpit2/switches/auto_brake_level", //Switch, 0 is RTO (Rejected Take-Off), 1 is off, 2->5 are increasing auto-brake levels.
            "sim/cockpit2/temperature/outside_air_temp_degc",
            "sim/flightmodel2/controls/speedbrake_ratio",
            //"sim/flightmodel2/engines/N1_percent_"
            "sim/flightmodel2/position/true_psi",
            "sim/flightmodel2/position/mag_psi",
            "sim/flightmodel2/position/true_airspeed"
        };

        private UdpClient _server;
        private UdpClient _client;

        public event Action OnReceived;

        public XPlaneCommunicator(List<RefData> refsData, Control invokeControl)
        {
            _refsData = refsData;
            _invokeControl = invokeControl;
        }
        
        public void Connect()
        {
            _client = new UdpClient("127.0.0.1", 49000);

            var ep = (IPEndPoint?)_client.Client.LocalEndPoint;
            _server = new UdpClient(ep);
            _server.BeginReceive(ReceiveCallback, null);

            InitRefs();
        }

        private void InitRefs()
        {
            for (int i = 0; i < _refsData.Count; i++)
            {
                SendRef(_refsData[i].Name, i+1, 2);
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
            try
            {
                byte[] response;
                try
                {
                    IPEndPoint? remoteEndPoint = null;
                    response = _server.EndReceive(ar, ref remoteEndPoint);
                }
                catch (SocketException ex)
                {
                    //Invoke(() => richTextBox1.AppendText("Erro no Socket: " + ex.Message + Environment.NewLine));
                    return;
                }
                ParseResponse(response);
            }
            finally
            {
                _server.BeginReceive(ReceiveCallback, null);
            }
        }

        private void ParseResponse(byte[] buffer)
        {
            var header = Encoding.ASCII.GetString(buffer, 0, 5);
            if (header != "RREF,") throw new Exception("Mensagem inválida recebida");

            OnReceived.Invoke();

            for (int i = 5; i < buffer.Length; i += 8)
            {
                var id = BitConverter.ToInt32(buffer, i);
                var value = BitConverter.ToSingle(buffer, i+4);

                var r = _refsData[id-1];

                if (r.Value == null || r.Value.Value != value)
                {
                    r.Value = value;
                    _invokeControl.Invoke(() => r.Proc(value));
                }
            }
        }

    }
}
