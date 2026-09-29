using System;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>本机机器码（硬件指纹哈希，格式 XXXX-XXXX-XXXX-XXXX）。</summary>
    public static class MachineCodeUtil
    {
        /// <summary>获取当前机器的机器码。</summary>
        public static string GetMachineCode()
        {
            string cpu = GetWmiProperty("Win32_Processor", "ProcessorId");
            string board = GetWmiProperty("Win32_BaseBoard", "SerialNumber");
            string mac = GetPrimaryMac();

            string material;
            if (string.IsNullOrWhiteSpace(cpu)
                && string.IsNullOrWhiteSpace(board)
                && string.IsNullOrWhiteSpace(mac))
            {
                material = Environment.MachineName + "|" + Environment.OSVersion;
            }
            else
            {
                material = string.Join("|",
                    (cpu ?? string.Empty).Trim(),
                    (board ?? string.Empty).Trim(),
                    (mac ?? string.Empty).Trim());
            }

            return FormatCode(Sha256(material));
        }

        private static string GetWmiProperty(string className, string propertyName)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(
                    "SELECT " + propertyName + " FROM " + className))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object value = obj[propertyName];
                        if (value == null)
                            continue;

                        string text = value.ToString().Trim();
                        if (text.Length == 0)
                            continue;

                        string upper = text.ToUpperInvariant();
                        if (upper == "NONE" || upper == "TO BE FILLED BY O.E.M."
                            || upper == "DEFAULT STRING" || upper == "0")
                            continue;

                        return text;
                    }
                }
            }
            catch
            {
                // WMI 不可用时降级
            }

            return null;
        }

        private static string GetPrimaryMac()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                if (nics == null || nics.Length == 0)
                    return null;

                foreach (NetworkInterface nic in nics)
                {
                    if (nic.OperationalStatus != OperationalStatus.Up)
                        continue;
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                        continue;
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                        continue;
                    if (nic.Description != null)
                    {
                        string desc = nic.Description.ToUpperInvariant();
                        if (desc.Contains("VIRTUAL") || desc.Contains("VMWARE")
                            || desc.Contains("VIRTUALBOX") || desc.Contains("HYPER-V"))
                            continue;
                    }

                    byte[] bytes = nic.GetPhysicalAddress().GetAddressBytes();
                    if (bytes == null || bytes.Length == 0)
                        continue;

                    var sb = new StringBuilder(bytes.Length * 2);
                    for (int i = 0; i < bytes.Length; i++)
                        sb.Append(bytes[i].ToString("X2"));
                    return sb.ToString();
                }
            }
            catch
            {
                // 忽略
            }

            return null;
        }

        private static byte[] Sha256(string text)
        {
            using (var sha = SHA256.Create())
                return sha.ComputeHash(Encoding.UTF8.GetBytes(text ?? string.Empty));
        }

        /// <summary>取哈希前 8 字节，格式化为 XXXX-XXXX-XXXX-XXXX。</summary>
        internal static string FormatCode(byte[] hash)
        {
            if (hash == null || hash.Length < 8)
                throw new ArgumentException("hash too short", "hash");

            var sb = new StringBuilder(19);
            for (int i = 0; i < 8; i++)
            {
                if (i > 0 && i % 2 == 0)
                    sb.Append('-');
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
