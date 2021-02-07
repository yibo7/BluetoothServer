using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//不检查跨线程调用 
            lsClients.DisplayMember = "Name";
            lsClients.ValueMember = "Address";
        }

        private Bluetooth bluetooth;
        
        private void BluetoothOnReceive(string device, string arg)
        {
            //Console.WriteLine($"接收到新消息:{arg} 来自{device}");
            addLog($"接收到新消息:{arg} 来自{device}");
            if (arg.Contains("1")) //自动回复
            {
                bluetooth.Send(device, "dddddddddd");
            }

        }
        private void BluetoothOnClientJoins(int clientsCount)
        {
            lbConnectCount.Text = $"接入数:{clientsCount}";
            List<BluetoothClientExt> datas = bluetooth.clients;
            foreach (BluetoothClientExt model in datas) { 
                BlueModel md = new BlueModel();
                md.Name = model.handler.RemoteMachineName;
                md.Address = model.handler.RemoteEndPoint.Address.ToString();
                lsClients.Items.Add(md);
            }
        } 

        private void btnListen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始监听!");
            bluetooth = new Bluetooth();
            bluetooth.onReceive = BluetoothOnReceive;
            bluetooth.onClientJoin = BluetoothOnClientJoins;
            
            (bool isok, string address) = bluetooth.Start();
            if (isok)
            {
                addLog("监听中,本地地址为：" + address);
                //Console.WriteLine("监听中,本地地址为：" + address);
            }
            else
            {
                addLog("请先开启蓝牙");
                //Console.WriteLine("请先开启蓝牙");
            }
        }
        private void addLog(string msg)
        {
            txtMsg.AppendText("\n\t" + msg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtSend.Text.Trim();
            if (!string.IsNullOrEmpty(msg))
            {
                if(lsClients.SelectedItem != null)
                {
                    BlueModel client = lsClients.SelectedItem as BlueModel;
                    bluetooth.Send(client.Address, msg);
                    txtSend.Text = "";
                }
                else
                {
                    MessageBox.Show("请选择一个客户端");
                }
            }
            else
            {
                MessageBox.Show("请输入发送内容");
            }
            
        }
    }
}
