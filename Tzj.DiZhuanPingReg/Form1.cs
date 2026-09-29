using System;
using System.Windows.Forms;
using Tzj.DiZhuanPingUtil;

namespace Tzj.DiZhuanPingReg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "注册码生成工具";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string machineCode = tbox_mac_code.Text.Trim();
            if (string.IsNullOrEmpty(machineCode))
            {
                MessageBox.Show("请先粘贴机器码。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_mac_code.Focus();
                return;
            }

            try
            {
                tbox_reg_code.Text = RegCodeUtil.Generate(machineCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败: " + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
