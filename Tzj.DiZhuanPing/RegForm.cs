using System;
using System.Windows.Forms;
using Tzj.DiZhuanPingUtil;

namespace DataParsing
{
    /// <summary>软件注册窗口：展示机器码，校验并保存注册码。</summary>
    public partial class RegForm : Form
    {
        private readonly string _machineCode;

        public RegForm()
        {
            InitializeComponent();
            _machineCode = MachineCodeUtil.GetMachineCode();
            tboxMachineCode.Text = _machineCode;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(_machineCode ?? string.Empty);
                MessageBox.Show("机器码已复制到剪贴板。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制失败: " + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string regCode = tboxRegCode.Text.Trim();
            if (string.IsNullOrEmpty(regCode))
            {
                MessageBox.Show("请输入注册码。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxRegCode.Focus();
                return;
            }

            if (!RegCodeUtil.Validate(_machineCode, regCode))
            {
                MessageBox.Show("注册码不正确，请核对后重试。", "注册失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tboxRegCode.Focus();
                tboxRegCode.SelectAll();
                return;
            }

            try
            {
                string normalized = RegCodeUtil.Generate(_machineCode);
                AppSettingsUtil.SaveRegCode(normalized);
                MessageBox.Show("注册成功。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存注册码失败: " + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
