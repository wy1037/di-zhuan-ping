using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tzj.DiZhuanPingUtil;

namespace DataParsing
{
    public partial class Form1 : MaterialForm
    {
        ///总共是40*48=1920个块，x=40块，y=48块，
        /// <summary>坐标命中块后背景高亮持续时间（毫秒），可按测试效果调整。</summary>
        private const int BlockHighlightMs = 400;

        /// <summary>日志框超过该行数后清空重写，避免无限增长。</summary>
        private const int MaxLogLines = 200;

        private UdpClient _udpClient;
        private CancellationTokenSource _cts;
        private bool _listening;
        private bool _isRegistered;

        private bool _gridReady;
        private int _gridStartX, _gridStartY, _gridEndX, _gridEndY;
        private int _gridStepX, _gridStepY, _gridCols, _gridRows;

        private readonly Dictionary<int, DateTime> _blockHighlightUntil =
            new Dictionary<int, DateTime>();
        /// <summary>命中小格高亮：key = cellY * cellCountX + cellX。</summary>
        private readonly Dictionary<int, DateTime> _cellHighlightUntil =
            new Dictionary<int, DateTime>();
        private readonly System.Windows.Forms.Timer _highlightTimer;
        private readonly System.Windows.Forms.Timer _resizeDebounceTimer;
        private readonly System.Windows.Forms.Timer _scheduleSendTimer;
        private readonly UdpBlockLabelSender _blockLabelSender = new UdpBlockLabelSender();

        /// <summary>定时模式下最后一个待发送的块标签。</summary>
        private string _lastLabel;
        /// <summary>定时模式下最后一个块标签的命中时间（UTC）。</summary>
        private DateTime _lastLabelTime;
        private readonly object _lastLabelLock = new object();

        public Form1()
        {
            InitializeComponent();
            MinimumSize = new Size(1222, 815);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE);

            button2.Enabled = false;

            _highlightTimer = new System.Windows.Forms.Timer();
            _highlightTimer.Interval = 50;
            _highlightTimer.Tick += HighlightTimer_Tick;

            _resizeDebounceTimer = new System.Windows.Forms.Timer();
            _resizeDebounceTimer.Interval = 300;
            _resizeDebounceTimer.Tick += ResizeDebounceTimer_Tick;

            _scheduleSendTimer = new System.Windows.Forms.Timer();
            _scheduleSendTimer.Tick += ScheduleSendTimer_Tick;

            Resize += Form1_Resize;
            Shown += Form1_Shown;

            LoadSettingsToUi();
            RefreshRegistrationState();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Shown -= Form1_Shown;
            ActiveControl = null;

            if (!_isRegistered)
                PromptRegistration();

            // 布局就绪后再按当前参数自动生成分块
            TryBuildBlocksFromUi(silent: true);

            // 已注册则窗体打开后自动开始监听
            if (_isRegistered)
                button1_Click(button1, EventArgs.Empty);
        }

        /// <summary>从配置读取并校验注册状态，更新监听按钮可用性。</summary>
        private void RefreshRegistrationState()
        {
            _isRegistered = false;
            try
            {
                AppSettings settings = AppSettingsUtil.LoadOrNull();
                if (settings != null
                    && !string.IsNullOrWhiteSpace(settings.RegCode)
                    && RegCodeUtil.ValidateOnThisMachine(settings.RegCode))
                {
                    _isRegistered = true;
                }
            }
            catch
            {
                _isRegistered = false;
            }

            UpdateListenButtonByRegistration();
        }

        private void UpdateListenButtonByRegistration()
        {
            if (_listening)
                return;

            button1.Enabled = _isRegistered;
        }

        private bool PromptRegistration()
        {
            using (var dlg = new RegForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshRegistrationState();
                    if (_isRegistered)
                        ShowMessage("软件已注册，可以启动监听。");
                    return _isRegistered;
                }
            }

            ShowMessage("软件未注册，无法启动监听。请先完成注册。");
            UpdateListenButtonByRegistration();
            return false;
        }

        private bool EnsureRegistered()
        {
            RefreshRegistrationState();
            if (_isRegistered)
                return true;

            return PromptRegistration();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // 连续改变大小时反复重置，停止 500ms 后再重建
            _resizeDebounceTimer.Stop();
            _resizeDebounceTimer.Start();
        }

        private void ResizeDebounceTimer_Tick(object sender, EventArgs e)
        {
            _resizeDebounceTimer.Stop();
            TryBuildBlocksFromUi(silent: true);
        }

        private void LoadSettingsToUi()
        {
            try
            {
                AppSettings settings = AppSettingsUtil.LoadOrNull();
                if (settings == null)
                    return;

                ApplySettingsToUi(settings);
                ShowMessage("已从配置文件加载设置。");
            }
            catch (Exception ex)
            {
                ShowMessage("加载配置失败: " + ex.Message);
            }
        }

        private void ApplySettingsToUi(AppSettings settings)
        {
            if (settings == null)
                return;

            textBox1.Text = settings.UdpPort.ToString();
            tboxTargetIP.Text = settings.TargetIP ?? "";
            tboxTargetPort.Text = settings.TargetPort.ToString();
            tbox_start_x_axis.Text = settings.StartX.ToString();
            tbox_start_y_axis.Text = settings.StartY.ToString();
            tbox_end_x_axis.Text = settings.EndX.ToString();
            tbox_end_y_axis.Text = settings.EndY.ToString();
            tbox_x_step.Text = settings.StepX.ToString();
            textBox2.Text = settings.StepY.ToString();
            tbox_cols.Text = settings.Cols.ToString();
            tbox_rows.Text = settings.Rows.ToString();

            rbRealtimeSend.Checked = !"Schedule".Equals(settings.SendMode, StringComparison.OrdinalIgnoreCase);
            rbScheduleSend.Checked = !rbRealtimeSend.Checked;
            tboxSendingInterval.Text = settings.SendingInterval.ToString();
        }

        private bool TryReadSettingsFromUi(out AppSettings settings)
        {
            settings = null;

            string targetIp = tboxTargetIP.Text.Trim();
            if (string.IsNullOrEmpty(targetIp))
            {
                ShowMessage("保存失败：目标 IP 不能为空。");
                return false;
            }

            int udpPort, targetPort, startX, startY, endX, endY, stepX, stepY, cols, rows, sendingInterval;
            if (!int.TryParse(textBox1.Text.Trim(), out udpPort) ||
                !int.TryParse(tboxTargetPort.Text.Trim(), out targetPort) ||
                !int.TryParse(tbox_start_x_axis.Text.Trim(), out startX) ||
                !int.TryParse(tbox_start_y_axis.Text.Trim(), out startY) ||
                !int.TryParse(tbox_end_x_axis.Text.Trim(), out endX) ||
                !int.TryParse(tbox_end_y_axis.Text.Trim(), out endY) ||
                !int.TryParse(tbox_x_step.Text.Trim(), out stepX) ||
                !int.TryParse(textBox2.Text.Trim(), out stepY) ||
                !int.TryParse(tbox_cols.Text.Trim(), out cols) ||
                !int.TryParse(tbox_rows.Text.Trim(), out rows) ||
                !int.TryParse(tboxSendingInterval.Text.Trim(), out sendingInterval) ||
                sendingInterval <= 0)
            {
                ShowMessage("保存失败：请输入有效的整数参数，且发送间隔必须大于 0。");
                return false;
            }

            settings = new AppSettings
            {
                UdpPort = udpPort,
                TargetIP = targetIp,
                TargetPort = targetPort,
                StartX = startX,
                StartY = startY,
                EndX = endX,
                EndY = endY,
                StepX = stepX,
                StepY = stepY,
                Cols = cols,
                Rows = rows,
                SendMode = rbScheduleSend.Checked ? "Schedule" : "Realtime",
                SendingInterval = sendingInterval
            };
            return true;
        }

        /// <summary>向 tboxMessge 追加带时间戳的运行消息，便于排查。</summary>
        public void ShowMessage(string message)
        {
            if (IsDisposed || string.IsNullOrEmpty(message))
                return;

            string line = string.Format("[{0:HH:mm:ss}] {1}{2}",
                DateTime.Now, message, Environment.NewLine);

            Action append = () => AppendLogLine(tboxMessge, line);

            if (InvokeRequired)
                BeginInvoke(append);
            else
                append();
        }

        /// <summary>追加一行日志；超过 MaxLogLines 则清空后重新开始。</summary>
        private static void AppendLogLine(Control box, string line)
        {
            if (box == null || string.IsNullOrEmpty(line))
                return;

            var textBox = box as TextBoxBase;
            if (textBox == null)
                return;

            if (textBox.Lines != null && textBox.Lines.Length >= MaxLogLines)
                textBox.Clear();

            textBox.AppendText(line);
            textBox.SelectionStart = textBox.TextLength;
            textBox.ScrollToCaret();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_listening)
                return;

            if (!EnsureRegistered())
                return;

            int port;
            if (!int.TryParse(textBox1.Text.Trim(), out port) || port < 1 || port > 65535)
            {
                ShowMessage("请输入有效的端口号 (1-65535)。");
                return;
            }

            try
            {
                ShowMessage(string.Format("正在打开 UDP 端口 {0} …", port));
                _udpClient = new UdpClient(port);
                _cts = new CancellationTokenSource();
                _listening = true;
                button1.Enabled = false;
                button2.Enabled = true;
                textBox1.Enabled = false;

                ShowMessage(string.Format(
                    "端口 {0} 监听成功，等待接收设备的数据。", port));

                RefreshScheduleTimer();

                await ReceiveLoopAsync(_cts.Token);
            }
            catch (SocketException ex)
            {
                ShowMessage(string.Format(
                    "打开端口失败: {0}（SocketError={1}, ErrorCode={2}）",
                    ex.Message, ex.SocketErrorCode, ex.ErrorCode));
                StopListening();
            }
            catch (Exception ex)
            {
                ShowMessage(string.Format(
                    "监听异常: {0}\r\n{1}", ex.Message, ex));
                StopListening();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopListening();
            ShowMessage("已停止监听。");
        }

        private void StopListening()
        {
            _listening = false;
            _scheduleSendTimer.Stop();

            if (_cts != null)
            {
                try { _cts.Cancel(); } catch { }
                _cts.Dispose();
                _cts = null;
            }

            if (_udpClient != null)
            {
                try { _udpClient.Close(); } catch { }
                _udpClient = null;
            }

            if (IsDisposed)
                return;

            if (InvokeRequired)
                BeginInvoke(new Action(UpdateUiStopped));
            else
                UpdateUiStopped();
        }

        private void UpdateUiStopped()
        {
            button1.Enabled = _isRegistered;
            button2.Enabled = false;
            textBox1.Enabled = true;
        }

        private async Task ReceiveLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested && _udpClient != null)
            {
                try
                {
                    UdpReceiveResult result = await _udpClient.ReceiveAsync().ConfigureAwait(false);
                    AppendReceived(result.Buffer);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (SocketException)
                {
                    if (token.IsCancellationRequested)
                        break;
                }
                catch
                {
                    if (token.IsCancellationRequested)
                        break;
                }
            }
        }

        private void AppendReceived(byte[] data)
        {
            List<Point> points;
            string parsed = ParseCoordinates(data, out points);
            string rawHex = BitConverter.ToString(data).Replace("-", " ");
            Action append = () =>
            {
                AppendLogLine(tboxHex, rawHex+"  "+ parsed + Environment.NewLine);
                ProcessBlockHits(points);
            };

            if (InvokeRequired)
                BeginInvoke(append);
            else
                append();
        }

        /// <summary>
        /// 协议: 55 55 | frame | data_size(H L) | 坐标内容(每点4字节) | SUM(H L)
        /// 多字节为大端；校验为坐标内容字节求和取低16位。
        /// </summary>
        private static string ParseCoordinates(byte[] data, out List<Point> points)
        {
            points = new List<Point>();

            if (data == null || data.Length < 7)
                return "[数据过短]";

            if (data[0] != 0x55 || data[1] != 0x55)
                return "[字头错误]";

            int dataSize = (data[3] << 8) | data[4];
            if (data.Length < 5 + dataSize + 2)
                return "[长度不足]";

            if (dataSize % 4 != 0)
                return "[内容长度不是4的倍数]";

            int sum = 0;
            for (int i = 0; i < dataSize; i++)
                sum += data[5 + i];

            int checksum = (data[5 + dataSize] << 8) | data[6 + dataSize];

            int pointCount = dataSize / 4;
            if (pointCount == 0)
                return "[无坐标点]";

            var sb = new StringBuilder();
            for (int i = 0; i < pointCount; i++)
            {
                int offset = 5 + i * 4;
                int x = (data[offset] << 8) | data[offset + 1];
                int y = (data[offset + 2] << 8) | data[offset + 3];
                points.Add(new Point(x, y));
                if (i > 0)
                    sb.Append(", ");
                sb.AppendFormat("({0}, {1})", x, y);
            }

            if ((sum & 0xFFFF) != checksum)
                sb.Append(" [校验失败]");

            return sb.ToString();
        }

        /// <summary>坐标命中：小格标红、所属大块标绿，并按模式发送块标签。</summary>
        private void ProcessBlockHits(List<Point> points)
        {
            if (!_gridReady || points == null || points.Count == 0)
                return;

            DateTime until = DateTime.UtcNow.AddMilliseconds(BlockHighlightMs);
            bool any = false;
            bool scheduleMode = rbScheduleSend.Checked;
            var sentLabels = new HashSet<string>(StringComparer.Ordinal);

            for (int i = 0; i < points.Count; i++)
            {
                int cellIndex = FindCellIndex(points[i].X, points[i].Y);
                if (cellIndex < 0)
                    continue;

                _cellHighlightUntil[cellIndex] = until;
                any = true;

                int blockIndex = FindBlockIndex(points[i].X, points[i].Y);
                if (blockIndex < 0)
                    continue;

                _blockHighlightUntil[blockIndex] = until;

                string label = ToBlockLabel(blockIndex);
                if (scheduleMode)
                {
                    lock (_lastLabelLock)
                    {
                        _lastLabel = label;
                        _lastLabelTime = DateTime.UtcNow;
                    }
                }
                else if (sentLabels.Add(label))
                {
                    SendBlockLabel(label);
                }
            }

            if (!any)
                return;

            RedrawGrid();
            if (!_highlightTimer.Enabled)
                _highlightTimer.Start();
        }

        /// <summary>按当前界面上的目标地址发送块标签；发送实现可替换。</summary>
        private void SendBlockLabel(string label)
        {
            string targetIp = tboxTargetIP.Text.Trim();
            int targetPort;
            if (string.IsNullOrEmpty(targetIp)
                || !int.TryParse(tboxTargetPort.Text.Trim(), out targetPort)
                || targetPort < 1 || targetPort > 65535)
            {
                ShowMessage("发送跳过：目标 IP/端口无效。");
                return;
            }

            _blockLabelSender.TargetHost = targetIp;
            _blockLabelSender.TargetPort = targetPort;

            string error;
            if (!_blockLabelSender.TrySend(label, out error))
            {
                ShowMessage(string.Format("发送块标签 {0} 失败: {1}", label, error));
                return;
            }

            ShowMessage(string.Format("已发送块标签 {0} -> {1}:{2}",
                label, targetIp, targetPort));
        }

        /// <summary>
        /// 命中离散小格索引。坐标必须落在步长网格上（无小数）。
        /// key = cellY * cellCountX + cellX。
        /// </summary>
        private int FindCellIndex(int x, int y)
        {
            if (!_gridReady)
                return -1;

            if (x < _gridStartX || x > _gridEndX || y < _gridStartY || y > _gridEndY)
                return -1;

            // 必须对齐步长网格，例如 (2585,12)、(2635,12)、(2585,37)…
            if ((x - _gridStartX) % _gridStepX != 0
                || (y - _gridStartY) % _gridStepY != 0)
                return -1;

            int cellCountX = (_gridEndX - _gridStartX) / _gridStepX + 1;
            int cellX = (x - _gridStartX) / _gridStepX;
            int cellY = (y - _gridStartY) / _gridStepY;
            return cellY * cellCountX + cellX;
        }

        /// <summary>
        /// 按离散小格命中合并块。坐标必须落在步长网格上（无小数）。
        /// 例：40×48 小格，合并为 5×3；每大块含 8×16 小格。
        /// </summary>
        private int FindBlockIndex(int x, int y)
        {
            int cellIndex = FindCellIndex(x, y);
            if (cellIndex < 0)
                return -1;

            int cellsPerBlockX, cellsPerBlockY;
            if (!TryGetCellsPerBlock(
                    _gridStartX, _gridStartY, _gridEndX, _gridEndY,
                    _gridStepX, _gridStepY, _gridCols, _gridRows,
                    out cellsPerBlockX, out cellsPerBlockY))
                return -1;

            int cellCountX = (_gridEndX - _gridStartX) / _gridStepX + 1;
            int cellX = cellIndex % cellCountX;
            int cellY = cellIndex / cellCountX;

            int c = cellX / cellsPerBlockX;
            int r = cellY / cellsPerBlockY;

            if (c < 0 || r < 0 || c >= _gridCols || r >= _gridRows)
                return -1;

            return r * _gridCols + c;
        }

        /// <summary>计算每块包含的小格数；参数无法整分时返回 false。</summary>
        private static bool TryGetCellsPerBlock(
            int startX, int startY, int endX, int endY,
            int stepX, int stepY, int cols, int rows,
            out int cellsPerBlockX, out int cellsPerBlockY)
        {
            cellsPerBlockX = 0;
            cellsPerBlockY = 0;

            if (stepX <= 0 || stepY <= 0 || cols <= 0 || rows <= 0)
                return false;
            if (endX <= startX || endY <= startY)
                return false;
            if ((endX - startX) % stepX != 0 || (endY - startY) % stepY != 0)
                return false;

            int cellCountX = (endX - startX) / stepX + 1;
            int cellCountY = (endY - startY) / stepY + 1;
            if (cellCountX % cols != 0 || cellCountY % rows != 0)
                return false;

            cellsPerBlockX = cellCountX / cols;
            cellsPerBlockY = cellCountY / rows;
            return cellsPerBlockX > 0 && cellsPerBlockY > 0;
        }

        private void HighlightTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.UtcNow;
            var expiredBlocks = new List<int>();
            var expiredCells = new List<int>();

            foreach (var kv in _blockHighlightUntil)
            {
                if (kv.Value <= now)
                    expiredBlocks.Add(kv.Key);
            }
            foreach (var kv in _cellHighlightUntil)
            {
                if (kv.Value <= now)
                    expiredCells.Add(kv.Key);
            }

            if (expiredBlocks.Count == 0 && expiredCells.Count == 0)
                return;

            for (int i = 0; i < expiredBlocks.Count; i++)
                _blockHighlightUntil.Remove(expiredBlocks[i]);
            for (int i = 0; i < expiredCells.Count; i++)
                _cellHighlightUntil.Remove(expiredCells[i]);

            RedrawGrid();

            if (_blockHighlightUntil.Count == 0 && _cellHighlightUntil.Count == 0)
                _highlightTimer.Stop();
        }

        /// <summary>按当前界面设置刷新定时发送定时器。</summary>
        private void RefreshScheduleTimer()
        {
            _scheduleSendTimer.Stop();

            int intervalSeconds;
            if (!int.TryParse(tboxSendingInterval.Text.Trim(), out intervalSeconds) || intervalSeconds <= 0)
                intervalSeconds = 5;

            _scheduleSendTimer.Interval = intervalSeconds * 1000;

            if (_listening && rbScheduleSend.Checked)
                _scheduleSendTimer.Start();
        }

        /// <summary>定时发送：取出最后一个标签，仅当其在间隔内有效时才发送。</summary>
        private void ScheduleSendTimer_Tick(object sender, EventArgs e)
        {
            string label;
            DateTime labelTime;
            lock (_lastLabelLock)
            {
                label = _lastLabel;
                labelTime = _lastLabelTime;
                _lastLabel = null;
            }

            if (string.IsNullOrEmpty(label))
                return;

            int intervalSeconds;
            if (!int.TryParse(tboxSendingInterval.Text.Trim(), out intervalSeconds) || intervalSeconds <= 0)
                intervalSeconds = 5;

            if ((DateTime.UtcNow - labelTime).TotalSeconds > intervalSeconds)
                return;

            SendBlockLabel(label);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AppSettings uiSettings;
            if (!TryReadSettingsFromUi(out uiSettings))
                return;

            try
            {
                AppSettingsUtil.SaveMerged(uiSettings);
                RefreshScheduleTimer();
                ShowMessage("设置已保存到: " + AppSettingsUtil.ConfigFilePath);
            }
            catch (Exception ex)
            {
                ShowMessage("保存设置失败: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Resize -= Form1_Resize;
            _resizeDebounceTimer.Stop();
            _resizeDebounceTimer.Dispose();
            _highlightTimer.Stop();
            _highlightTimer.Dispose();
            _scheduleSendTimer.Stop();
            _scheduleSendTimer.Dispose();
            StopListening();
            _blockLabelSender.Dispose();
            base.OnFormClosing(e);
        }

        private void btn_buildblock_Click(object sender, EventArgs e)
        {
            TryBuildBlocksFromUi(silent: false);
        }

        /// <summary>根据界面参数生成分块；silent 时参数无效不弹框（启动/缩放场景）。</summary>
        private void TryBuildBlocksFromUi(bool silent)
        {
            int startX, startY, endX, endY, stepX, stepY, cols, rows;
            if (!TryParseGridInputs(out startX, out startY, out endX, out endY,
                    out stepX, out stepY, out cols, out rows, silent))
                return;

            _gridStartX = startX;
            _gridStartY = startY;
            _gridEndX = endX;
            _gridEndY = endY;
            _gridStepX = stepX;
            _gridStepY = stepY;
            _gridCols = cols;
            _gridRows = rows;
            _gridReady = true;

            _blockHighlightUntil.Clear();
            _cellHighlightUntil.Clear();
            _highlightTimer.Stop();
            RedrawGrid();

            if (!silent)
            {
                int cellCountX = (endX - startX) / stepX + 1;
                int cellCountY = (endY - startY) / stepY + 1;
                ShowMessage(string.Format(
                    "已生成分块：小格 {0}×{1}，合并为 {2}×{3}（每块 {4}×{5} 小格）。",
                    cellCountX, cellCountY, cols, rows,
                    cellCountX / cols, cellCountY / rows));
            }
        }

        private void RedrawGrid()
        {
            if (!_gridReady)
                return;

            int width = Math.Max(pictureBox1.ClientSize.Width, 1);
            int height = Math.Max(pictureBox1.ClientSize.Height, 1);
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                DrawGridSchematic(g, width, height,
                    _gridStartX, _gridStartY, _gridEndX, _gridEndY,
                    _gridStepX, _gridStepY, _gridCols, _gridRows,
                    _blockHighlightUntil.Keys, _cellHighlightUntil.Keys);
            }

            Image old = pictureBox1.Image;
            pictureBox1.Image = bmp;
            if (old != null)
                old.Dispose();
        }

        private bool TryParseGridInputs(
            out int startX, out int startY, out int endX, out int endY,
            out int stepX, out int stepY, out int cols, out int rows,
            bool silent = false)
        {
            startX = startY = endX = endY = stepX = stepY = cols = rows = 0;

            if (!int.TryParse(tbox_start_x_axis.Text.Trim(), out startX) ||
                !int.TryParse(tbox_start_y_axis.Text.Trim(), out startY) ||
                !int.TryParse(tbox_end_x_axis.Text.Trim(), out endX) ||
                !int.TryParse(tbox_end_y_axis.Text.Trim(), out endY) ||
                !int.TryParse(tbox_x_step.Text.Trim(), out stepX) ||
                !int.TryParse(textBox2.Text.Trim(), out stepY) ||
                !int.TryParse(tbox_cols.Text.Trim(), out cols) ||
                !int.TryParse(tbox_rows.Text.Trim(), out rows))
            {
                if (!silent)
                    MessageBox.Show("请输入有效的整数参数", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (endX <= startX || endY <= startY)
            {
                if (!silent)
                    MessageBox.Show("结束坐标必须大于起始坐标", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (stepX <= 0 || stepY <= 0)
            {
                if (!silent)
                    MessageBox.Show("步长必须大于 0", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cols <= 0 || rows <= 0)
            {
                if (!silent)
                    MessageBox.Show("块数必须大于 0", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // 跨度必须被步长整除，形成整数小格网格
            if ((endX - startX) % stepX != 0 || (endY - startY) % stepY != 0)
            {
                if (!silent)
                    MessageBox.Show("起终点跨度必须能被步长整除（小格坐标为整数）。", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int cellCountX = (endX - startX) / stepX + 1;
            int cellCountY = (endY - startY) / stepY + 1;
            if (cellCountX % cols != 0 || cellCountY % rows != 0)
            {
                if (!silent)
                    MessageBox.Show(string.Format(
                        "小格数 {0}×{1} 无法被块数 {2}×{3} 整除。",
                        cellCountX, cellCountY, cols, rows), "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private static void DrawGridSchematic(
            Graphics g, int width, int height,
            int startX, int startY, int endX, int endY,
            int stepX, int stepY, int cols, int rows,
            ICollection<int> highlightedBlocks,
            ICollection<int> highlightedCells)
        {
            const int marginL = 16;
            const int marginT = 18;
            const int marginR = 12;
            const int marginB = 32;

            float plotW = width - marginL - marginR;
            float plotH = height - marginT - marginB;
            if (plotW < 10 || plotH < 10)
                return;

            if (endX <= startX || endY <= startY)
                return;

            int cellsPerBlockX, cellsPerBlockY;
            if (!TryGetCellsPerBlock(startX, startY, endX, endY,
                    stepX, stepY, cols, rows,
                    out cellsPerBlockX, out cellsPerBlockY))
                return;

            int cellCountX = (endX - startX) / stepX + 1;
            int cellCountY = (endY - startY) / stepY + 1;
            int blockSpanX = cellsPerBlockX * stepX;
            int blockSpanY = cellsPerBlockY * stepY;

            // 每个坐标点是格子左上角；绘图范围再延伸一个步长，才能画满最后一行/列
            float farX = startX + cellCountX * stepX;
            float farY = startY + cellCountY * stepY;
            float mapWorldW = farX - startX;
            float mapWorldH = farY - startY;

            // 起始点在左上、结束点在右下（Y 向下增大，与块顺序一致）
            Func<float, float> mapX = x => marginL + (x - startX) / mapWorldW * plotW;
            Func<float, float> mapY = y => marginT + (y - startY) / mapWorldH * plotH;

            float left = mapX(startX);
            float right = mapX(farX);
            float top = mapY(startY);
            float bottom = mapY(farY);

            // 背景
            using (var bg = new SolidBrush(Color.FromArgb(248, 250, 252)))
                g.FillRectangle(bg, left, top, right - left, bottom - top);

            // 步长细网格（过密时抽稀；40×48 时 stride=1，画满全部小格）
            int xStride = Math.Max(1, (int)Math.Ceiling((double)cellCountX / 40.0));
            int yStride = Math.Max(1, (int)Math.Ceiling((double)cellCountY / 48.0));

            using (var finePen = new Pen(Color.FromArgb(220, 226, 232), 1f))
            {
                for (int i = 0; i <= cellCountX; i += xStride)
                {
                    float px = mapX(startX + i * stepX);
                    g.DrawLine(finePen, px, top, px, bottom);
                }
                // 保证画出最右侧边界
                if ((cellCountX % xStride) != 0)
                {
                    float px = mapX(farX);
                    g.DrawLine(finePen, px, top, px, bottom);
                }

                for (int j = 0; j <= cellCountY; j += yStride)
                {
                    float py = mapY(startY + j * stepY);
                    g.DrawLine(finePen, left, py, right, py);
                }
                if ((cellCountY % yStride) != 0)
                {
                    float py = mapY(farY);
                    g.DrawLine(finePen, left, py, right, py);
                }
            }

            // 分块粗网格：按小格整数合并（每块 blockSpanX × blockSpanY）
            using (var highlightBrush = new SolidBrush(Color.FromArgb(160, 187, 247, 208)))
            using (var blockPen = new Pen(Color.FromArgb(37, 99, 235), 1.5f))
            using (var labelFont = new Font("Microsoft YaHei UI", 8f))
            using (var labelBrush = new SolidBrush(Color.FromArgb(30, 64, 175)))
            using (var rangeBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            using (var rangeFont = new Font("Microsoft YaHei UI", 6.5f))
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int bx0 = startX + c * blockSpanX;
                        int by0 = startY + r * blockSpanY;
                        // 右/下边界取下一块起点（含最后一块延伸一个完整块宽/高）
                        int bx1 = startX + (c + 1) * blockSpanX;
                        int by1 = startY + (r + 1) * blockSpanY;

                        float px0 = mapX(bx0);
                        float px1 = mapX(bx1);
                        float py0 = mapY(by0);
                        float py1 = mapY(by1);

                        int blockIndex = r * cols + c;
                        if (highlightedBlocks != null && highlightedBlocks.Contains(blockIndex))
                            g.FillRectangle(highlightBrush, px0, py0, px1 - px0, py1 - py0);

                        g.DrawRectangle(blockPen, px0, py0, px1 - px0, py1 - py0);

                        // (startX,startY) 为 A，向右 B、C…，再往下一行
                        string title = ToBlockLabel(blockIndex);
                        SizeF titleSize = g.MeasureString(title, labelFont);
                        float tx = px0 + (px1 - px0 - titleSize.Width) / 2f;
                        float ty = py0 + (py1 - py0) / 2f - titleSize.Height;

                        if (px1 - px0 > titleSize.Width + 4 && py1 - py0 > titleSize.Height + 4)
                            g.DrawString(title, labelFont, labelBrush, tx, ty);

                        string range = string.Format("({0},{1})", bx0, by0);
                        SizeF rangeSize = g.MeasureString(range, rangeFont);
                        if (px1 - px0 > rangeSize.Width + 4 && py1 - py0 > titleSize.Height + rangeSize.Height + 6)
                            g.DrawString(range, rangeFont, rangeBrush,
                                px0 + (px1 - px0 - rangeSize.Width) / 2f,
                                ty + titleSize.Height);
                    }
                }
            }

            // 命中小格：从格子左上角画到右下角（下一格起点），画满整格
            if (highlightedCells != null && highlightedCells.Count > 0)
            {
                using (var cellBrush = new SolidBrush(Color.FromArgb(200, 239, 68, 68)))
                {
                    foreach (int cellIndex in highlightedCells)
                    {
                        if (cellIndex < 0)
                            continue;

                        int cellX = cellIndex % cellCountX;
                        int cellY = cellIndex / cellCountX;
                        if (cellX < 0 || cellY < 0 || cellX >= cellCountX || cellY >= cellCountY)
                            continue;

                        int wx0 = startX + cellX * stepX;
                        int wy0 = startY + cellY * stepY;
                        float px0 = mapX(wx0);
                        float py0 = mapY(wy0);
                        float px1 = mapX(wx0 + stepX);
                        float py1 = mapY(wy0 + stepY);
                        g.FillRectangle(cellBrush, px0, py0, px1 - px0, py1 - py0);
                    }
                }
            }

            // 外框
            using (var borderPen = new Pen(Color.FromArgb(15, 23, 42), 2f))
                g.DrawRectangle(borderPen, left, top, right - left, bottom - top);

            // 坐标标注
            using (var axisFont = new Font("Microsoft YaHei UI", 7.5f))
            using (var axisBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                string startLabel = string.Format("({0},{1})", startX, startY);
                string endLabel = string.Format("({0},{1})", endX, endY);
                SizeF startSize = g.MeasureString(startLabel, axisFont);
                g.DrawString(startLabel, axisFont, axisBrush, left, top - startSize.Height - 1);
                SizeF endSize = g.MeasureString(endLabel, axisFont);
                g.DrawString(endLabel, axisFont, axisBrush, right - endSize.Width, bottom + 4);

                string info = string.Format("小格 {0}×{1}  |  合并 {2}×{3} 块（每块 {4}×{5}）",
                    cellCountX, cellCountY, cols, rows, cellsPerBlockX, cellsPerBlockY);
                SizeF infoSize = g.MeasureString(info, axisFont);
                g.DrawString(info, axisFont, axisBrush, right - infoSize.Width, 2);
            }
        }

        /// <summary>0→A, 1→B … 25→Z, 26→AA …</summary>
        private static string ToBlockLabel(int index)
        {
            if (index < 0)
                index = 0;

            var sb = new StringBuilder();
            do
            {
                sb.Insert(0, (char)('A' + (index % 26)));
                index = index / 26 - 1;
            } while (index >= 0);

            return sb.ToString();
        }
    }
}
