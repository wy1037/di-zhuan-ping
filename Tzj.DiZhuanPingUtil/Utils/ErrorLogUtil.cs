using System;
using System.IO;
using System.Text;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>未处理异常写入程序目录下 error.log.txt（追加）。</summary>
    public static class ErrorLogUtil
    {
        private static readonly object SyncRoot = new object();

        /// <summary>默认日志路径（程序目录下 error.log.txt）。</summary>
        public static string LogFilePath
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "error.log.txt");
            }
        }

        /// <summary>追加一条异常记录；写文件失败时静默忽略，避免二次崩溃。</summary>
        public static void Write(Exception ex, string source = null)
        {
            if (ex == null)
                return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("==========");
                sb.AppendLine(string.Format("Time: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now));
                if (!string.IsNullOrEmpty(source))
                    sb.AppendLine("Source: " + source);
                sb.AppendLine("Type: " + ex.GetType().FullName);
                sb.AppendLine("Message: " + ex.Message);
                sb.AppendLine("StackTrace:");
                sb.AppendLine(ex.ToString());
                sb.AppendLine();

                lock (SyncRoot)
                {
                    File.AppendAllText(LogFilePath, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                // 日志失败不再抛出
            }
        }
    }
}
