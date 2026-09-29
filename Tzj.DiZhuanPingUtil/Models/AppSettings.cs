using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>应用配置（JSON）。界面未展示的字段也会保留在文件中。</summary>
    public class AppSettings
    {
        public AppSettings()
        {
            UdpPort = 20001;
            TargetIP = "192.168.111.112";
            TargetPort = 20002;
            StartX = 2585;
            StartY = 12;
            EndX = 4535;
            EndY = 1187;
            StepX = 50;
            StepY = 25;
            Cols = 5;
            Rows = 3;
            SendMode = "Realtime";
            SendingInterval = 5;
        }

        public int UdpPort { get; set; }
        public string TargetIP { get; set; }
        public int TargetPort { get; set; }

        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public int StepX { get; set; }
        public int StepY { get; set; }

        public int Cols { get; set; }
        public int Rows { get; set; }

        /// <summary>数据发送模式：Realtime（实时）或 Schedule（定时）。</summary>
        public string SendMode { get; set; }

        /// <summary>定时发送间隔（秒）。</summary>
        public int SendingInterval { get; set; }

        /// <summary>软件注册码（与本机机器码绑定）。</summary>
        public string RegCode { get; set; }

        /// <summary>手工写入、模型未声明的 JSON 字段，保存时原样保留。</summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData { get; set; }

        /// <summary>仅用界面上的参数覆盖对应字段，其它已有配置不动。</summary>
        public void ApplyUiValues(AppSettings ui)
        {
            if (ui == null)
                return;

            UdpPort = ui.UdpPort;
            TargetIP = ui.TargetIP;
            TargetPort = ui.TargetPort;
            StartX = ui.StartX;
            StartY = ui.StartY;
            EndX = ui.EndX;
            EndY = ui.EndY;
            StepX = ui.StepX;
            StepY = ui.StepY;
            Cols = ui.Cols;
            Rows = ui.Rows;
            SendMode = ui.SendMode;
            SendingInterval = ui.SendingInterval;
        }
    }
}
