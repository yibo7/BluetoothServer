using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BluetoothServer
{
    public class Bluetooth
    {
        private BluetoothListener _listener;
        private CancellationTokenSource _cancelSource;

        public List<BluetoothClientExt> clients;
        public Action<string, string> onReceive;
        public Action<int> onClientJoin;


        public Bluetooth()
        {
            clients = new List<BluetoothClientExt>();
        }
 


        public  (bool,string)Start()
        {
            BluetoothRadio myRadio = BluetoothRadio.PrimaryRadio;
            
            if (myRadio == null)
                return (false,"");
            _cancelSource = new CancellationTokenSource();

            _listener = new BluetoothListener(myRadio.LocalAddress, BluetoothService.SerialPort);
            //_listener.SetPin(myRadio.LocalAddress, "1234");
            _listener.Start();
            
            Task.Run(() => Listener(_cancelSource));
            return (true, myRadio.LocalAddress.ToString());
        }

        public void Stop()
        {
            _cancelSource.Cancel();
            _listener.Stop();
            for (int i = 0; i < clients.Count; i++)
                clients[i].Stop();
        }

        public int GetConnectedClients()
        {
            int result = 0;

            for (int i = clients.Count - 1; i >= 0; i--)
            {
                if (clients[i].isConnected == false)
                    clients.RemoveAt(i);
                else
                    result++;
            }
            return result;
        }

        private void OnDisconnect()
        {
            for (int i = clients.Count - 1; i >= 0; i--)
            {
                if (clients[i].isConnected == false)
                {
                    clients.RemoveAt(i);
                    onClientJoin?.Invoke(clients.Count);
                }
            }
        }

        private void Listener(CancellationTokenSource token)
        {
            try
            {
                while (Common.IsApplicationRunning)
                {

                    if (token.IsCancellationRequested)
                        break;

                    var client = new BluetoothClientExt(onReceive);
                    client.handler = _listener.AcceptBluetoothClient();
                    if (client.handler != null)
                    {
                        client.onDisconnect = OnDisconnect;
                        client.Start();
                        clients.Add(client);
                        onClientJoin?.Invoke(clients.Count);
                    }

                    for (int i = clients.Count - 1; i >= 0; i--)
                    {
                        if (clients[i].isConnected == false)
                        {
                            clients.RemoveAt(i);
                            onClientJoin?.Invoke(clients.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("监听取消发生异常："+ex.Message);
            }

            for (int i = clients.Count - 1; i >= 0; i--)
                clients[i].Stop();

            clients.Clear();
        }

        public void RefreshTimer(string address)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].handler.RemoteEndPoint.Address.ToString() == address)
                    clients[i].RefreshTimer();
            }
        }

        public void Send(string address, string message)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                
                if (clients[i].handler.RemoteEndPoint.Address.ToString() == address)
                    clients[i].Send(message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cancelSource != null)
                {
                    _listener.Stop();
                    _listener = null;
                    _cancelSource.Dispose();
                    _cancelSource = null;
                }
            }
        }
    }
}