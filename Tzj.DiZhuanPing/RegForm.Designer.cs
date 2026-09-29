namespace DataParsing
{
    partial class RegForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.lblMachine = new System.Windows.Forms.Label();
            this.tboxMachineCode = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblReg = new System.Windows.Forms.Label();
            this.tboxRegCode = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(24, 22);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(41, 12);
            this.lblMachine.TabIndex = 0;
            this.lblMachine.Text = "机器码";
            // 
            // tboxMachineCode
            // 
            this.tboxMachineCode.Font = new System.Drawing.Font("Consolas", 11F);
            this.tboxMachineCode.Location = new System.Drawing.Point(26, 45);
            this.tboxMachineCode.Name = "tboxMachineCode";
            this.tboxMachineCode.ReadOnly = true;
            this.tboxMachineCode.Size = new System.Drawing.Size(360, 25);
            this.tboxMachineCode.TabIndex = 1;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(392, 44);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 26);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTip.Location = new System.Drawing.Point(24, 82);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(305, 12);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = "请将机器码发送给管理员，获取注册码后填入下方。";
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(24, 118);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(41, 12);
            this.lblReg.TabIndex = 4;
            this.lblReg.Text = "注册码";
            // 
            // tboxRegCode
            // 
            this.tboxRegCode.Font = new System.Drawing.Font("Consolas", 11F);
            this.tboxRegCode.Location = new System.Drawing.Point(26, 141);
            this.tboxRegCode.Name = "tboxRegCode";
            this.tboxRegCode.Size = new System.Drawing.Size(441, 25);
            this.tboxRegCode.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(311, 188);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(392, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RegForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 236);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tboxRegCode);
            this.Controls.Add(this.lblReg);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tboxMachineCode);
            this.Controls.Add(this.lblMachine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "软件注册";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.TextBox tboxMachineCode;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.TextBox tboxRegCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
