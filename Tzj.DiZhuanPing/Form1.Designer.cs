namespace DataParsing
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
            this.textBox1 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.button2 = new MaterialSkin.Controls.MaterialButton();
            this.tboxHex = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_start_x_axis = new MaterialSkin.Controls.MaterialTextBox2();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_start_y_axis = new MaterialSkin.Controls.MaterialTextBox2();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.label6 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_end_x_axis = new MaterialSkin.Controls.MaterialTextBox2();
            this.label7 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_end_y_axis = new MaterialSkin.Controls.MaterialTextBox2();
            this.label8 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_x_step = new MaterialSkin.Controls.MaterialTextBox2();
            this.label9 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox2 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label10 = new MaterialSkin.Controls.MaterialLabel();
            this.label11 = new MaterialSkin.Controls.MaterialLabel();
            this.tbox_cols = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbox_rows = new MaterialSkin.Controls.MaterialTextBox2();
            this.btn_buildblock = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new MaterialSkin.Controls.MaterialCard();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetting = new MaterialSkin.Controls.MaterialButton();
            this.tboxTargetIP = new MaterialSkin.Controls.MaterialTextBox2();
            this.tboxTargetPort = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.tboxMessge = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.rbRealtimeSend = new System.Windows.Forms.RadioButton();
            this.rbScheduleSend = new System.Windows.Forms.RadioButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.tboxSendingInterval = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.materialCard4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AnimateReadOnly = false;
            this.textBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.HideSelection = true;
            this.textBox1.LeadingIcon = null;
            this.textBox1.Location = new System.Drawing.Point(117, 11);
            this.textBox1.MaxLength = 32767;
            this.textBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PrefixSuffixText = null;
            this.textBox1.ReadOnly = false;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(100, 36);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "20001";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TrailingIcon = null;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.UseTallSize = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "本机Udp端口";
            // 
            // button1
            // 
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(237, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始监听";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = false;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.button2.Depth = 0;
            this.button2.HighEmphasis = true;
            this.button2.Icon = null;
            this.button2.Location = new System.Drawing.Point(341, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button2.Size = new System.Drawing.Size(96, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "停止监听";
            this.button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.button2.UseAccentColor = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tboxHex
            // 
            this.tboxHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tboxHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxHex.Depth = 0;
            this.tboxHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tboxHex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tboxHex.Hint = "解析坐标";
            this.tboxHex.Location = new System.Drawing.Point(14, 14);
            this.tboxHex.Margin = new System.Windows.Forms.Padding(0);
            this.tboxHex.MouseState = MaterialSkin.MouseState.HOVER;
            this.tboxHex.Name = "tboxHex";
            this.tboxHex.Size = new System.Drawing.Size(430, 274);
            this.tboxHex.TabIndex = 3;
            this.tboxHex.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "坐标起点";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(96, 14);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // tbox_start_x_axis
            // 
            this.tbox_start_x_axis.AnimateReadOnly = false;
            this.tbox_start_x_axis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_start_x_axis.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_start_x_axis.Depth = 0;
            this.tbox_start_x_axis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_start_x_axis.HideSelection = true;
            this.tbox_start_x_axis.LeadingIcon = null;
            this.tbox_start_x_axis.Location = new System.Drawing.Point(116, 5);
            this.tbox_start_x_axis.MaxLength = 32767;
            this.tbox_start_x_axis.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_start_x_axis.Name = "tbox_start_x_axis";
            this.tbox_start_x_axis.PasswordChar = '\0';
            this.tbox_start_x_axis.PrefixSuffixText = null;
            this.tbox_start_x_axis.ReadOnly = false;
            this.tbox_start_x_axis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_start_x_axis.SelectedText = "";
            this.tbox_start_x_axis.SelectionLength = 0;
            this.tbox_start_x_axis.SelectionStart = 0;
            this.tbox_start_x_axis.ShortcutsEnabled = true;
            this.tbox_start_x_axis.Size = new System.Drawing.Size(69, 36);
            this.tbox_start_x_axis.TabIndex = 6;
            this.tbox_start_x_axis.TabStop = false;
            this.tbox_start_x_axis.Text = "2585";
            this.tbox_start_x_axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_start_x_axis.TrailingIcon = null;
            this.tbox_start_x_axis.UseSystemPasswordChar = false;
            this.tbox_start_x_axis.UseTallSize = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(191, 14);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y";
            // 
            // tbox_start_y_axis
            // 
            this.tbox_start_y_axis.AnimateReadOnly = false;
            this.tbox_start_y_axis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_start_y_axis.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_start_y_axis.Depth = 0;
            this.tbox_start_y_axis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_start_y_axis.HideSelection = true;
            this.tbox_start_y_axis.LeadingIcon = null;
            this.tbox_start_y_axis.Location = new System.Drawing.Point(211, 5);
            this.tbox_start_y_axis.MaxLength = 32767;
            this.tbox_start_y_axis.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_start_y_axis.Name = "tbox_start_y_axis";
            this.tbox_start_y_axis.PasswordChar = '\0';
            this.tbox_start_y_axis.PrefixSuffixText = null;
            this.tbox_start_y_axis.ReadOnly = false;
            this.tbox_start_y_axis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_start_y_axis.SelectedText = "";
            this.tbox_start_y_axis.SelectionLength = 0;
            this.tbox_start_y_axis.SelectionStart = 0;
            this.tbox_start_y_axis.ShortcutsEnabled = true;
            this.tbox_start_y_axis.Size = new System.Drawing.Size(69, 36);
            this.tbox_start_y_axis.TabIndex = 6;
            this.tbox_start_y_axis.TabStop = false;
            this.tbox_start_y_axis.Text = "12";
            this.tbox_start_y_axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_start_y_axis.TrailingIcon = null;
            this.tbox_start_y_axis.UseSystemPasswordChar = false;
            this.tbox_start_y_axis.UseTallSize = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(13, 62);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "坐标结束";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(96, 62);
            this.label6.MouseState = MaterialSkin.MouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "X";
            // 
            // tbox_end_x_axis
            // 
            this.tbox_end_x_axis.AnimateReadOnly = false;
            this.tbox_end_x_axis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_end_x_axis.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_end_x_axis.Depth = 0;
            this.tbox_end_x_axis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_end_x_axis.HideSelection = true;
            this.tbox_end_x_axis.LeadingIcon = null;
            this.tbox_end_x_axis.Location = new System.Drawing.Point(116, 54);
            this.tbox_end_x_axis.MaxLength = 32767;
            this.tbox_end_x_axis.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_end_x_axis.Name = "tbox_end_x_axis";
            this.tbox_end_x_axis.PasswordChar = '\0';
            this.tbox_end_x_axis.PrefixSuffixText = null;
            this.tbox_end_x_axis.ReadOnly = false;
            this.tbox_end_x_axis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_end_x_axis.SelectedText = "";
            this.tbox_end_x_axis.SelectionLength = 0;
            this.tbox_end_x_axis.SelectionStart = 0;
            this.tbox_end_x_axis.ShortcutsEnabled = true;
            this.tbox_end_x_axis.Size = new System.Drawing.Size(69, 36);
            this.tbox_end_x_axis.TabIndex = 6;
            this.tbox_end_x_axis.TabStop = false;
            this.tbox_end_x_axis.Text = "4535";
            this.tbox_end_x_axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_end_x_axis.TrailingIcon = null;
            this.tbox_end_x_axis.UseSystemPasswordChar = false;
            this.tbox_end_x_axis.UseTallSize = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Depth = 0;
            this.label7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.Location = new System.Drawing.Point(191, 62);
            this.label7.MouseState = MaterialSkin.MouseState.HOVER;
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Y";
            // 
            // tbox_end_y_axis
            // 
            this.tbox_end_y_axis.AnimateReadOnly = false;
            this.tbox_end_y_axis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_end_y_axis.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_end_y_axis.Depth = 0;
            this.tbox_end_y_axis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_end_y_axis.HideSelection = true;
            this.tbox_end_y_axis.LeadingIcon = null;
            this.tbox_end_y_axis.Location = new System.Drawing.Point(211, 54);
            this.tbox_end_y_axis.MaxLength = 32767;
            this.tbox_end_y_axis.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_end_y_axis.Name = "tbox_end_y_axis";
            this.tbox_end_y_axis.PasswordChar = '\0';
            this.tbox_end_y_axis.PrefixSuffixText = null;
            this.tbox_end_y_axis.ReadOnly = false;
            this.tbox_end_y_axis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_end_y_axis.SelectedText = "";
            this.tbox_end_y_axis.SelectionLength = 0;
            this.tbox_end_y_axis.SelectionStart = 0;
            this.tbox_end_y_axis.ShortcutsEnabled = true;
            this.tbox_end_y_axis.Size = new System.Drawing.Size(69, 36);
            this.tbox_end_y_axis.TabIndex = 6;
            this.tbox_end_y_axis.TabStop = false;
            this.tbox_end_y_axis.Text = "1187";
            this.tbox_end_y_axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_end_y_axis.TrailingIcon = null;
            this.tbox_end_y_axis.UseSystemPasswordChar = false;
            this.tbox_end_y_axis.UseTallSize = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.Location = new System.Drawing.Point(331, 14);
            this.label8.MouseState = MaterialSkin.MouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "X步长";
            // 
            // tbox_x_step
            // 
            this.tbox_x_step.AnimateReadOnly = false;
            this.tbox_x_step.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_x_step.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_x_step.Depth = 0;
            this.tbox_x_step.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_x_step.HideSelection = true;
            this.tbox_x_step.LeadingIcon = null;
            this.tbox_x_step.Location = new System.Drawing.Point(382, 5);
            this.tbox_x_step.MaxLength = 32767;
            this.tbox_x_step.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_x_step.Name = "tbox_x_step";
            this.tbox_x_step.PasswordChar = '\0';
            this.tbox_x_step.PrefixSuffixText = null;
            this.tbox_x_step.ReadOnly = false;
            this.tbox_x_step.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_x_step.SelectedText = "";
            this.tbox_x_step.SelectionLength = 0;
            this.tbox_x_step.SelectionStart = 0;
            this.tbox_x_step.ShortcutsEnabled = true;
            this.tbox_x_step.Size = new System.Drawing.Size(69, 36);
            this.tbox_x_step.TabIndex = 6;
            this.tbox_x_step.TabStop = false;
            this.tbox_x_step.Text = "50";
            this.tbox_x_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_x_step.TrailingIcon = null;
            this.tbox_x_step.UseSystemPasswordChar = false;
            this.tbox_x_step.UseTallSize = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Depth = 0;
            this.label9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.Location = new System.Drawing.Point(471, 14);
            this.label9.MouseState = MaterialSkin.MouseState.HOVER;
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 19);
            this.label9.TabIndex = 5;
            this.label9.Text = "Y步长";
            // 
            // textBox2
            // 
            this.textBox2.AnimateReadOnly = false;
            this.textBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.Depth = 0;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.HideSelection = true;
            this.textBox2.LeadingIcon = null;
            this.textBox2.Location = new System.Drawing.Point(520, 5);
            this.textBox2.MaxLength = 32767;
            this.textBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PrefixSuffixText = null;
            this.textBox2.ReadOnly = false;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(69, 36);
            this.textBox2.TabIndex = 6;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "25";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox2.TrailingIcon = null;
            this.textBox2.UseSystemPasswordChar = false;
            this.textBox2.UseTallSize = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Depth = 0;
            this.label10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.Location = new System.Drawing.Point(331, 62);
            this.label10.MouseState = MaterialSkin.MouseState.HOVER;
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 19);
            this.label10.TabIndex = 5;
            this.label10.Text = "X块数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Depth = 0;
            this.label11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.Location = new System.Drawing.Point(471, 62);
            this.label11.MouseState = MaterialSkin.MouseState.HOVER;
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 19);
            this.label11.TabIndex = 5;
            this.label11.Text = "Y块数";
            // 
            // tbox_cols
            // 
            this.tbox_cols.AnimateReadOnly = false;
            this.tbox_cols.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_cols.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_cols.Depth = 0;
            this.tbox_cols.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_cols.HideSelection = true;
            this.tbox_cols.LeadingIcon = null;
            this.tbox_cols.Location = new System.Drawing.Point(382, 54);
            this.tbox_cols.MaxLength = 32767;
            this.tbox_cols.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_cols.Name = "tbox_cols";
            this.tbox_cols.PasswordChar = '\0';
            this.tbox_cols.PrefixSuffixText = null;
            this.tbox_cols.ReadOnly = false;
            this.tbox_cols.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_cols.SelectedText = "";
            this.tbox_cols.SelectionLength = 0;
            this.tbox_cols.SelectionStart = 0;
            this.tbox_cols.ShortcutsEnabled = true;
            this.tbox_cols.Size = new System.Drawing.Size(69, 36);
            this.tbox_cols.TabIndex = 6;
            this.tbox_cols.TabStop = false;
            this.tbox_cols.Text = "5";
            this.tbox_cols.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_cols.TrailingIcon = null;
            this.tbox_cols.UseSystemPasswordChar = false;
            this.tbox_cols.UseTallSize = false;
            // 
            // tbox_rows
            // 
            this.tbox_rows.AnimateReadOnly = false;
            this.tbox_rows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbox_rows.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbox_rows.Depth = 0;
            this.tbox_rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbox_rows.HideSelection = true;
            this.tbox_rows.LeadingIcon = null;
            this.tbox_rows.Location = new System.Drawing.Point(520, 54);
            this.tbox_rows.MaxLength = 32767;
            this.tbox_rows.MouseState = MaterialSkin.MouseState.OUT;
            this.tbox_rows.Name = "tbox_rows";
            this.tbox_rows.PasswordChar = '\0';
            this.tbox_rows.PrefixSuffixText = null;
            this.tbox_rows.ReadOnly = false;
            this.tbox_rows.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbox_rows.SelectedText = "";
            this.tbox_rows.SelectionLength = 0;
            this.tbox_rows.SelectionStart = 0;
            this.tbox_rows.ShortcutsEnabled = true;
            this.tbox_rows.Size = new System.Drawing.Size(69, 36);
            this.tbox_rows.TabIndex = 6;
            this.tbox_rows.TabStop = false;
            this.tbox_rows.Text = "3";
            this.tbox_rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbox_rows.TrailingIcon = null;
            this.tbox_rows.UseSystemPasswordChar = false;
            this.tbox_rows.UseTallSize = false;
            // 
            // btn_buildblock
            // 
            this.btn_buildblock.AutoSize = false;
            this.btn_buildblock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_buildblock.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btn_buildblock.Depth = 0;
            this.btn_buildblock.HighEmphasis = true;
            this.btn_buildblock.Icon = null;
            this.btn_buildblock.Location = new System.Drawing.Point(604, 54);
            this.btn_buildblock.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_buildblock.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_buildblock.Name = "btn_buildblock";
            this.btn_buildblock.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn_buildblock.Size = new System.Drawing.Size(88, 36);
            this.btn_buildblock.TabIndex = 7;
            this.btn_buildblock.Text = "生成分块";
            this.btn_buildblock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_buildblock.UseAccentColor = false;
            this.btn_buildblock.UseVisualStyleBackColor = true;
            this.btn_buildblock.Click += new System.EventHandler(this.btn_buildblock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(674, 494);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.tboxTargetIP);
            this.groupBox1.Controls.Add(this.tboxTargetPort);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Depth = 0;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox1.Size = new System.Drawing.Size(1188, 170);
            this.groupBox1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbox_end_x_axis);
            this.panel1.Controls.Add(this.tbox_x_step);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btn_buildblock);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbox_cols);
            this.panel1.Controls.Add(this.tbox_end_y_axis);
            this.panel1.Controls.Add(this.tbox_start_x_axis);
            this.panel1.Controls.Add(this.tbox_rows);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbox_start_y_axis);
            this.panel1.Location = new System.Drawing.Point(475, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 95);
            this.panel1.TabIndex = 8;
            // 
            // btnSetting
            // 
            this.btnSetting.AutoSize = false;
            this.btnSetting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetting.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btnSetting.Depth = 0;
            this.btnSetting.HighEmphasis = true;
            this.btnSetting.Icon = null;
            this.btnSetting.Location = new System.Drawing.Point(604, 5);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSetting.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSetting.Size = new System.Drawing.Size(88, 36);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "保存设置";
            this.btnSetting.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSetting.UseAccentColor = false;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // tboxTargetIP
            // 
            this.tboxTargetIP.AnimateReadOnly = false;
            this.tboxTargetIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tboxTargetIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tboxTargetIP.Depth = 0;
            this.tboxTargetIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tboxTargetIP.HideSelection = true;
            this.tboxTargetIP.LeadingIcon = null;
            this.tboxTargetIP.Location = new System.Drawing.Point(117, 60);
            this.tboxTargetIP.MaxLength = 32767;
            this.tboxTargetIP.MouseState = MaterialSkin.MouseState.OUT;
            this.tboxTargetIP.Name = "tboxTargetIP";
            this.tboxTargetIP.PasswordChar = '\0';
            this.tboxTargetIP.PrefixSuffixText = null;
            this.tboxTargetIP.ReadOnly = false;
            this.tboxTargetIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tboxTargetIP.SelectedText = "";
            this.tboxTargetIP.SelectionLength = 0;
            this.tboxTargetIP.SelectionStart = 0;
            this.tboxTargetIP.ShortcutsEnabled = true;
            this.tboxTargetIP.Size = new System.Drawing.Size(155, 36);
            this.tboxTargetIP.TabIndex = 0;
            this.tboxTargetIP.TabStop = false;
            this.tboxTargetIP.Text = "192.168.0.106";
            this.tboxTargetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tboxTargetIP.TrailingIcon = null;
            this.tboxTargetIP.UseSystemPasswordChar = false;
            this.tboxTargetIP.UseTallSize = false;
            // 
            // tboxTargetPort
            // 
            this.tboxTargetPort.AnimateReadOnly = false;
            this.tboxTargetPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tboxTargetPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tboxTargetPort.Depth = 0;
            this.tboxTargetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tboxTargetPort.HideSelection = true;
            this.tboxTargetPort.LeadingIcon = null;
            this.tboxTargetPort.Location = new System.Drawing.Point(341, 60);
            this.tboxTargetPort.MaxLength = 32767;
            this.tboxTargetPort.MouseState = MaterialSkin.MouseState.OUT;
            this.tboxTargetPort.Name = "tboxTargetPort";
            this.tboxTargetPort.PasswordChar = '\0';
            this.tboxTargetPort.PrefixSuffixText = null;
            this.tboxTargetPort.ReadOnly = false;
            this.tboxTargetPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tboxTargetPort.SelectedText = "";
            this.tboxTargetPort.SelectionLength = 0;
            this.tboxTargetPort.SelectionStart = 0;
            this.tboxTargetPort.ShortcutsEnabled = true;
            this.tboxTargetPort.Size = new System.Drawing.Size(96, 36);
            this.tboxTargetPort.TabIndex = 0;
            this.tboxTargetPort.TabStop = false;
            this.tboxTargetPort.Text = "20002";
            this.tboxTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tboxTargetPort.TrailingIcon = null;
            this.tboxTargetPort.UseSystemPasswordChar = false;
            this.tboxTargetPort.UseTallSize = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(278, 69);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(65, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "中控端口";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 69);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(95, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "目标中控机IP";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialCard1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialCard3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialCard4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1216, 748);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.tboxHex);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(14, 212);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(458, 302);
            this.materialCard1.TabIndex = 11;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.pictureBox1);
            this.materialCard3.Depth = 0;
            this.materialCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(500, 212);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.tableLayoutPanel1.SetRowSpan(this.materialCard3, 2);
            this.materialCard3.Size = new System.Drawing.Size(702, 522);
            this.materialCard3.TabIndex = 13;
            // 
            // materialCard4
            // 
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.tboxMessge);
            this.materialCard4.Depth = 0;
            this.materialCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(14, 542);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard4.Size = new System.Drawing.Size(458, 192);
            this.materialCard4.TabIndex = 14;
            // 
            // tboxMessge
            // 
            this.tboxMessge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tboxMessge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxMessge.Depth = 0;
            this.tboxMessge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxMessge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tboxMessge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tboxMessge.Location = new System.Drawing.Point(14, 14);
            this.tboxMessge.MouseState = MaterialSkin.MouseState.HOVER;
            this.tboxMessge.Name = "tboxMessge";
            this.tboxMessge.Size = new System.Drawing.Size(430, 164);
            this.tboxMessge.TabIndex = 0;
            this.tboxMessge.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbScheduleSend);
            this.groupBox2.Controls.Add(this.rbRealtimeSend);
            this.groupBox2.Controls.Add(this.materialLabel4);
            this.groupBox2.Controls.Add(this.tboxSendingInterval);
            this.groupBox2.Controls.Add(this.materialLabel5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.Location = new System.Drawing.Point(117, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(17, 124);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(97, 19);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "数据发送模式";
            // 
            // rbRealtimeSend
            // 
            this.rbRealtimeSend.Checked = true;
            this.rbRealtimeSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rbRealtimeSend.Location = new System.Drawing.Point(30, 17);
            this.rbRealtimeSend.Name = "rbRealtimeSend";
            this.rbRealtimeSend.Size = new System.Drawing.Size(104, 24);
            this.rbRealtimeSend.TabIndex = 0;
            this.rbRealtimeSend.TabStop = true;
            this.rbRealtimeSend.Text = "实时发送";
            this.rbRealtimeSend.UseVisualStyleBackColor = true;
            // 
            // rbScheduleSend
            // 
            this.rbScheduleSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rbScheduleSend.Location = new System.Drawing.Point(164, 17);
            this.rbScheduleSend.Name = "rbScheduleSend";
            this.rbScheduleSend.Size = new System.Drawing.Size(82, 24);
            this.rbScheduleSend.TabIndex = 1;
            this.rbScheduleSend.Text = "定时发送";
            this.rbScheduleSend.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(300, 22);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(65, 19);
            this.materialLabel4.TabIndex = 1;
            this.materialLabel4.Text = "发送间隔";
            // 
            // tboxSendingInterval
            // 
            this.tboxSendingInterval.AnimateReadOnly = false;
            this.tboxSendingInterval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tboxSendingInterval.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tboxSendingInterval.Depth = 0;
            this.tboxSendingInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tboxSendingInterval.HideSelection = true;
            this.tboxSendingInterval.LeadingIcon = null;
            this.tboxSendingInterval.Location = new System.Drawing.Point(371, 11);
            this.tboxSendingInterval.MaxLength = 32767;
            this.tboxSendingInterval.MouseState = MaterialSkin.MouseState.OUT;
            this.tboxSendingInterval.Name = "tboxSendingInterval";
            this.tboxSendingInterval.PasswordChar = '\0';
            this.tboxSendingInterval.PrefixSuffixText = null;
            this.tboxSendingInterval.ReadOnly = false;
            this.tboxSendingInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tboxSendingInterval.SelectedText = "";
            this.tboxSendingInterval.SelectionLength = 0;
            this.tboxSendingInterval.SelectionStart = 0;
            this.tboxSendingInterval.ShortcutsEnabled = true;
            this.tboxSendingInterval.Size = new System.Drawing.Size(69, 36);
            this.tboxSendingInterval.TabIndex = 6;
            this.tboxSendingInterval.TabStop = false;
            this.tboxSendingInterval.Text = "5";
            this.tboxSendingInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tboxSendingInterval.TrailingIcon = null;
            this.tboxSendingInterval.UseSystemPasswordChar = false;
            this.tboxSendingInterval.UseTallSize = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(446, 22);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(140, 19);
            this.materialLabel5.TabIndex = 5;
            this.materialLabel5.Text = "秒(仅定时模式生效)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 815);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DrawerShowIconsWhenHidden = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地砖屏数据解析";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard3.ResumeLayout(false);
            this.materialCard4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 textBox1;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tboxHex;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_start_x_axis;
        private MaterialSkin.Controls.MaterialLabel label4;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_start_y_axis;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialLabel label6;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_end_x_axis;
        private MaterialSkin.Controls.MaterialLabel label7;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_end_y_axis;
        private MaterialSkin.Controls.MaterialLabel label8;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_x_step;
        private MaterialSkin.Controls.MaterialLabel label9;
        private MaterialSkin.Controls.MaterialTextBox2 textBox2;
        private MaterialSkin.Controls.MaterialLabel label10;
        private MaterialSkin.Controls.MaterialLabel label11;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_cols;
        private MaterialSkin.Controls.MaterialTextBox2 tbox_rows;
        private MaterialSkin.Controls.MaterialButton btn_buildblock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialCard groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tboxMessge;
        private MaterialSkin.Controls.MaterialTextBox2 tboxTargetIP;
        private MaterialSkin.Controls.MaterialTextBox2 tboxTargetPort;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.RadioButton rbScheduleSend;
        private System.Windows.Forms.RadioButton rbRealtimeSend;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox2 tboxSendingInterval;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}
