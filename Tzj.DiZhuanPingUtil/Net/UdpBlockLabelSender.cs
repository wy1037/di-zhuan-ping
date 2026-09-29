using System;
using System.Net.Sockets;
using System.Text;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>通过 UDP 向指定目标发送块标签文本。</summary>
    public sealed class UdpBlockLabelSender : IBlockLabelSender, IDisposable
    {
        private readonly object _sync = new object();
        private UdpClient _udpClient;
        private bool _disposed;

        public UdpBlockLabelSender()
        {
            Encoding = Encoding.UTF8;
        }

        /// <summary>目标 IP 或主机名。</summary>
        public string TargetHost { get; set; }

        /// <summary>目标端口。</summary>
        public int TargetPort { get; set; }

        /// <summary>发送文本编码，默认 UTF-8。</summary>
        public Encoding Encoding { get; set; }

        public bool TrySend(string blockLabel, out string error)
        {
            error = null;

            if (_disposed)
            {
                error = "发送器已释放。";
                return false;
            }

            if (string.IsNullOrEmpty(blockLabel))
            {
                error = "块标签为空。";
                return false;
            }

            string host = TargetHost == null ? string.Empty : TargetHost.Trim();
            if (string.IsNullOrEmpty(host))
            {
                error = "目标 IP 未设置。";
                return false;
            }

            if (TargetPort < 1 || TargetPort > 65535)
            {
                error = "目标端口无效。";
                return false;
            }

            try
            {
                Encoding encoding = Encoding ?? Encoding.UTF8;
                byte[] bytes = encoding.GetBytes(blockLabel);

                lock (_sync)
                {
                    EnsureClient();
                    _udpClient.Send(bytes, bytes.Length, host, TargetPort);
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private void EnsureClient()
        {
            if (_udpClient != null)
                return;

            _udpClient = new UdpClient();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            lock (_sync)
            {
                if (_udpClient != null)
                {
                    try { _udpClient.Close(); } catch { }
                    _udpClient = null;
                }
            }
        }
    }
}
