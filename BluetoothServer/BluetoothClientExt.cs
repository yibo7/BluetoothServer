using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net.Sockets;

namespace BluetoothServer
{
    public class BluetoothClientExt : IDisposable
    {
        public BluetoothClient handler = null;
        public bool isConnected = false;
        private Action<string, string> onReceive;
        private CancellationTokenSource cancelSource;
        public NetworkStream stream;
        private string incomingdata = "";
        private bool ping = false;
        private Stopwatch sw = new Stopwatch();
        public Action onDisconnect;

        public BluetoothClientExt(BluetoothClient _handler)
        {
            isConnected = true;
            handler = _handler;
            cancelSource = new CancellationTokenSource();
            Task.Run(() => Listener(cancelSource));
        }

        public BluetoothClientExt(BluetoothClient _handler, Action<string, string> action)
        {
            isConnected = true;
            handler = _handler;
            this.onReceive = action;
            cancelSource = new CancellationTokenSource();
            Task.Run(() => Listener(cancelSource));
        }

        public BluetoothClientExt(Action<string, string> action)
        {
            isConnected = false;
            this.onReceive = action;
            cancelSource = new CancellationTokenSource();
        }

        public void Start()
        {
            isConnected = true;
            stream = handler.GetStream();
            stream.ReadTimeout = 20;
            stream.WriteTimeout = 20;
            Task.Run(() => Listener(cancelSource));
        }

        public void SetOnReceive(Action<string, string> action)
        {
            onReceive = action;
        }

        public void Send(string arg)
        {
            if (isConnected == false)
                return;
            incomingdata = arg;
        }

        private void PingPong(CancellationTokenSource token)
        {
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    Thread.Sleep(100);
                }
                ping = true;
            }
        }

        public void RefreshTimer()
        {
            sw.Restart();
        }

        
        private void Listener(CancellationTokenSource token)
        {
            // string buffer = "";
            // byte[] arg = new byte[1024 * 2];

            sw.Start();

            try
            {
                while (Common.IsApplicationRunning) //Common.Base.Instance.IsApplicationRunning == true
                {
                    Thread.Sleep(25);
                    if (token.IsCancellationRequested)
                        break;

                    try
                    {
                        if (handler.Connected == false)
                        {
                            isConnected = false;
                            if (handler != null)
                                handler.Client.Disconnect(true);
                            onDisconnect?.Invoke();
                            return;
                        }

                        if (stream.DataAvailable == true)
                        {
                            byte[] arg = new byte[1024*5];//1024 * 2
                            var len = stream.Read(arg, 0, arg.Length);
                            if (len != 0)
                            {
                                // string data = ASCIIEncoding.UTF8.GetString(arg);
                                string data =  ASCIIEncoding.UTF8.GetString(arg, 0, len);
                                // buffer += ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(arg, 0, content).Replace("\n", "").Replace("\r", "")));
                                onReceive?.Invoke(handler.RemoteEndPoint.Address.ToString(), data);
                                // buffer = "";
                            }
                        }
                        else if (incomingdata.Length != 0)
                        {
                            // byte[] ar = Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(incomingdata)));
                            byte[] ar = Encoding.UTF8.GetBytes(incomingdata);
                            stream.Write(ar, 0, ar.Length);
                            // stream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, 2);
                            incomingdata = "";
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("发生异常:" + ex.Message);
                        isConnected = false;
                        if (handler != null)
                            handler.Client.Disconnect(true);
                        onDisconnect?.Invoke();
                        return;
                    }
                }
            }
            catch (Exception)
            {
                isConnected = false;
                if (handler != null)
                    handler.Client.Disconnect(true);
            }
            isConnected = false;
            onDisconnect?.Invoke();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Stop()
        {
            cancelSource.Cancel();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (cancelSource != null)
                {
                    cancelSource.Dispose();
                    cancelSource = null;
                }
            }
        }
    }
}
