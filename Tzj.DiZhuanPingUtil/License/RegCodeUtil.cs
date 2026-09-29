using System;
using System.Security.Cryptography;
using System.Text;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>注册码生成与校验（HMAC-SHA256，与机器码绑定）。</summary>
    public static class RegCodeUtil
    {
        private static readonly byte[] SecretKey =
            Encoding.UTF8.GetBytes("Tzj.DiZhuanPing.Reg.2026!Secret#Key");

        /// <summary>根据机器码生成注册码。</summary>
        public static string Generate(string machineCode)
        {
            string normalizedMachine = Normalize(machineCode);
            if (normalizedMachine.Length == 0)
                throw new ArgumentException("机器码不能为空。", "machineCode");

            string data = "DiZhuanPing|" + normalizedMachine;
            using (var hmac = new HMACSHA256(SecretKey))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return MachineCodeUtil.FormatCode(hash);
            }
        }

        /// <summary>校验注册码是否与指定机器码匹配。</summary>
        public static bool Validate(string machineCode, string regCode)
        {
            if (string.IsNullOrWhiteSpace(machineCode) || string.IsNullOrWhiteSpace(regCode))
                return false;

            try
            {
                string expected = Generate(machineCode);
                return string.Equals(
                    Normalize(expected),
                    Normalize(regCode),
                    StringComparison.Ordinal);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>用本机机器码校验注册码。</summary>
        public static bool ValidateOnThisMachine(string regCode)
        {
            return Validate(MachineCodeUtil.GetMachineCode(), regCode);
        }

        /// <summary>去掉横线/空白并转大写，便于比较与输入容错。</summary>
        public static string Normalize(string code)
        {
            if (string.IsNullOrEmpty(code))
                return string.Empty;

            var sb = new StringBuilder(code.Length);
            for (int i = 0; i < code.Length; i++)
            {
                char c = code[i];
                if (c == '-' || c == ' ' || c == '\r' || c == '\n' || c == '\t')
                    continue;
                sb.Append(char.ToUpperInvariant(c));
            }
            return sb.ToString();
        }
    }
}
