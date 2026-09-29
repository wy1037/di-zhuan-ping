using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tzj.DiZhuanPingUtil;

namespace DataParsing
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 会话内唯一互斥名，避免同机多开
            const string mutexName = "Local\\DiZhuanPing_SingleInstance";

            if (!SingleInstanceUtil.TryEnter(mutexName))
                return;

            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += OnUiThreadException;
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
                TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                HandleException(ex, "Main");
            }
            finally
            {
                SingleInstanceUtil.Release();
            }
        }

        private static void OnUiThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, "UI");
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception
                ?? new Exception(Convert.ToString(e.ExceptionObject));
            HandleException(ex, e.IsTerminating ? "Unhandled(Terminating)" : "Unhandled");
        }

        private static void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception, "Task");
            e.SetObserved();
        }

        /// <summary>写 error.log.txt，并尽量在主窗体 ShowMessage；无窗体时弹 MessageBox。</summary>
        private static void HandleException(Exception ex, string source)
        {
            if (ex == null)
                return;

            ErrorLogUtil.Write(ex, source);

            string brief = string.Format("发生未处理异常（{0}）：{1}", source, ex.Message);
            bool shownOnForm = TryShowOnMainForm(brief);

            if (!shownOnForm)
            {
                try
                {
                    MessageBox.Show(
                        brief + Environment.NewLine + Environment.NewLine
                        + "详情已写入：" + ErrorLogUtil.LogFilePath,
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // 弹窗失败忽略
                }
            }
        }

        private static bool TryShowOnMainForm(string message)
        {
            try
            {
                if (Application.OpenForms == null || Application.OpenForms.Count == 0)
                    return false;

                foreach (Form form in Application.OpenForms)
                {
                    var main = form as Form1;
                    if (main == null || main.IsDisposed)
                        continue;

                    main.ShowMessage(message);
                    main.ShowMessage("详情已写入：" + ErrorLogUtil.LogFilePath);
                    return true;
                }
            }
            catch
            {
                // 界面可能已不可用
            }

            return false;
        }
    }
}
