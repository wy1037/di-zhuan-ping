namespace Tzj.DiZhuanPingReg
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_mac_code = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbox_reg_code = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码";
            // 
            // tbox_mac_code
            // 
            this.tbox_mac_code.Location = new System.Drawing.Point(100, 37);
            this.tbox_mac_code.Name = "tbox_mac_code";
            this.tbox_mac_code.Size = new System.Drawing.Size(447, 90);
            this.tbox_mac_code.TabIndex = 1;
            this.tbox_mac_code.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成注册码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbox_reg_code
            // 
            this.tbox_reg_code.Location = new System.Drawing.Point(100, 163);
            this.tbox_reg_code.Name = "tbox_reg_code";
            this.tbox_reg_code.Size = new System.Drawing.Size(447, 90);
            this.tbox_reg_code.TabIndex = 1;
            this.tbox_reg_code.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbox_reg_code);
            this.Controls.Add(this.tbox_mac_code);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册码生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbox_mac_code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox tbox_reg_code;
    }
}

