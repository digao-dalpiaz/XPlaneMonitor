﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp.Communicator
{
    public class XPlaneCommunicator
    {

        private readonly Control _invokeControl;
        private readonly List<RefDataSubscription> _subscriptions;

        private UdpClient _server;
        private UdpClient _client;

        private ConnectionStatus _connectionStatus = ConnectionStatus.DISCONNECTED;
        public ConnectionStatus Status { get { return _connectionStatus; } }

        public event Action<int> OnReceived;
        public event Action OnStatusChanged;

        private string _host;
        private int _port;

        private long _lastTick;

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

        private void SetConnected()
        {
            ChangeStatus(ConnectionStatus.CONNECTED);

            new Task(() =>
            {
                while (_connectionStatus == ConnectionStatus.CONNECTED)
                {
                    Thread.Sleep(1000);
                    if ((Environment.TickCount64 - _lastTick) > 10000) //10 seconds without receiving means connection lost
                    {
                        Disconnect();
                        RunSync(() => Messages.Error("Connection lost"));
                    }
                }
            }).Start();
        }

        public void Connect(string host, int port)
        {
            _host = host;
            _port = port;

            ChangeStatus(ConnectionStatus.CONNECTING);

            _client = new UdpClient(host, port);

            var ep = (IPEndPoint)_client.Client.LocalEndPoint ?? throw new Exception("LocalEndPoint null");
            _server = new UdpClient(ep);
            _server.BeginReceive(ReceiveCallback, null);

            new Task(() =>
            {
                for (int i = 0; i < 10; i++) //10 seconds in connecting status means time-out
                {
                    Thread.Sleep(1000);
                    if (_connectionStatus != ConnectionStatus.CONNECTING) return;
                }
                Disconnect();
                RunSync(() => Messages.Error("Connection time-out"));
            }).Start();

            RequestRefs(true);
        }

        public void Disconnect()
        {
            if (_connectionStatus == ConnectionStatus.CONNECTED)
            {
                RequestRefs(false);
            }

            _server.Close();
            _client.Close();

            ChangeStatus(ConnectionStatus.DISCONNECTED);
        }

        private void RequestRefs(bool subscribe)
        {
            for (int i = 0; i < _subscriptions.Count; i++)
            {
                SendRef(_subscriptions[i].GetName(), i+1, subscribe ? Vars.Cfg.UpdPerSecond : 0);
            }
        }

        private void SendRef(string refName, int refId, int interval)
        {
            var data = new byte[413];

            int pos = 0;

            void incPart(byte[] part)
            {
                Array.Copy(part, 0, data, pos, part.Length);
                pos += part.Length;
            }

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
                _lastTick = Environment.TickCount64;
                byte[] response;
                try
                {
                    IPEndPoint remoteEndPoint = null;
                    response = _server.EndReceive(ar, ref remoteEndPoint);
                }
                catch (SocketException ex)
                {
                    Disconnect();
                    RunSync(() =>
                    {
                        string msg = ex.ErrorCode == 10054 ? string.Format("X-Plane not found running at {0}:{1}", _host, _port) : ex.Message;
                        Messages.Error(msg);
                    });
                    return;
                }
                if (_connectionStatus == ConnectionStatus.CONNECTING) SetConnected();
                ParseResponse(response);
                _server.BeginReceive(ReceiveCallback, null);
            }
            catch (ObjectDisposedException) { }
        }

        private void ParseResponse(byte[] buffer)
        {
            var header = Encoding.ASCII.GetString(buffer, 0, 5);
            if (header != "RREF,") throw new Exception("Wrong message header received: " + header);

            RunSync(() => OnReceived.Invoke(buffer.Length));

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
                _invokeControl.BeginInvoke(action);
            } catch (ObjectDisposedException) { }
        }

    }
}
