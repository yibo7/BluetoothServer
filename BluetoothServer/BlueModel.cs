using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothServer
{
    public class BlueModel
    {
        public string Name { get; set; }                                   //l蓝牙名字
        public string Address { get; set; }               //蓝牙的唯一标识符
        public string ClassOfDevice { get; set; }            //蓝牙是何种类型 
       
    }
}
