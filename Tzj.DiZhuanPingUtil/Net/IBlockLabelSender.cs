namespace Tzj.DiZhuanPingUtil
{
    /// <summary>块标签发送抽象，便于更换发送方案（UDP/串口/其它）。</summary>
    public interface IBlockLabelSender
    {
        /// <summary>发送块标签（如 "A"）。成功返回 true。</summary>
        bool TrySend(string blockLabel, out string error);
    }
}
