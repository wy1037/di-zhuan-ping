using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>保证本机仅运行一个程序实例；重复启动时激活已有窗口。</summary>
    public static class SingleInstanceUtil
    {
        private const int SwRestore = 9;

        private static Mutex _mutex;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// 尝试取得唯一实例。若已有实例在运行则将其窗口置前并返回 false。
        /// </summary>
        public static bool TryEnter(string mutexName)
        {
            if (string.IsNullOrEmpty(mutexName))
                throw new ArgumentNullException("mutexName");

            bool createdNew;
            _mutex = new Mutex(true, mutexName, out createdNew);
            if (createdNew)
                return true;

            ActivateExistingInstance();
            return false;
        }

        /// <summary>程序退出前释放互斥量。</summary>
        public static void Release()
        {
            if (_mutex == null)
                return;

            try
            {
                _mutex.ReleaseMutex();
            }
            catch
            {
            }

            _mutex.Dispose();
            _mutex = null;
        }

        private static void ActivateExistingInstance()
        {
            Process current = Process.GetCurrentProcess();
            string processName = current.ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);

            for (int i = 0; i < processes.Length; i++)
            {
                Process process = processes[i];
                try
                {
                    if (process.Id == current.Id)
                        continue;

                    IntPtr handle = process.MainWindowHandle;
                    if (handle == IntPtr.Zero)
                        continue;

                    if (IsIconic(handle))
                        ShowWindow(handle, SwRestore);

                    SetForegroundWindow(handle);
                    return;
                }
                catch
                {
                }
                finally
                {
                    process.Dispose();
                }
            }
        }
    }
}
