
namespace Z_One
{
    partial class ZOneMain
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
            this.groupBoxUpadat = new System.Windows.Forms.GroupBox();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.StopbitsLabel = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.ParityLabel = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.DataBitsLabel = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.Port = new System.Windows.Forms.Label();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.BaudRateLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.控制台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxUpadat.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUpadat
            // 
            this.groupBoxUpadat.Controls.Add(this.textBoxTimeout);
            this.groupBoxUpadat.Controls.Add(this.label1);
            this.groupBoxUpadat.Controls.Add(this.comboBoxStopBits);
            this.groupBoxUpadat.Controls.Add(this.StopbitsLabel);
            this.groupBoxUpadat.Controls.Add(this.comboBoxParity);
            this.groupBoxUpadat.Controls.Add(this.ParityLabel);
            this.groupBoxUpadat.Controls.Add(this.comboBoxDataBits);
            this.groupBoxUpadat.Controls.Add(this.DataBitsLabel);
            this.groupBoxUpadat.Controls.Add(this.comboBoxPort);
            this.groupBoxUpadat.Controls.Add(this.Port);
            this.groupBoxUpadat.Controls.Add(this.comboBaudRate);
            this.groupBoxUpadat.Controls.Add(this.BaudRateLabel);
            this.groupBoxUpadat.Location = new System.Drawing.Point(12, 39);
            this.groupBoxUpadat.Name = "groupBoxUpadat";
            this.groupBoxUpadat.Size = new System.Drawing.Size(193, 181);
            this.groupBoxUpadat.TabIndex = 4;
            this.groupBoxUpadat.TabStop = false;
            this.groupBoxUpadat.Text = "串口参数";
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(85, 148);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(84, 21);
            this.textBoxTimeout.TabIndex = 16;
            this.textBoxTimeout.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "超时时间";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(85, 122);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(84, 20);
            this.comboBoxStopBits.TabIndex = 12;
            this.comboBoxStopBits.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            // 
            // StopbitsLabel
            // 
            this.StopbitsLabel.AutoSize = true;
            this.StopbitsLabel.Location = new System.Drawing.Point(6, 126);
            this.StopbitsLabel.Name = "StopbitsLabel";
            this.StopbitsLabel.Size = new System.Drawing.Size(41, 12);
            this.StopbitsLabel.TabIndex = 11;
            this.StopbitsLabel.Text = "停止位";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(85, 96);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(84, 20);
            this.comboBoxParity.TabIndex = 10;
            this.comboBoxParity.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            // 
            // ParityLabel
            // 
            this.ParityLabel.AutoSize = true;
            this.ParityLabel.Location = new System.Drawing.Point(6, 100);
            this.ParityLabel.Name = "ParityLabel";
            this.ParityLabel.Size = new System.Drawing.Size(41, 12);
            this.ParityLabel.TabIndex = 9;
            this.ParityLabel.Text = "校验位";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(85, 70);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(84, 20);
            this.comboBoxDataBits.TabIndex = 8;
            this.comboBoxDataBits.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            // 
            // DataBitsLabel
            // 
            this.DataBitsLabel.AutoSize = true;
            this.DataBitsLabel.Location = new System.Drawing.Point(6, 74);
            this.DataBitsLabel.Name = "DataBitsLabel";
            this.DataBitsLabel.Size = new System.Drawing.Size(41, 12);
            this.DataBitsLabel.TabIndex = 7;
            this.DataBitsLabel.Text = "数据位";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "COM1"});
            this.comboBoxPort.Location = new System.Drawing.Point(85, 18);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(84, 20);
            this.comboBoxPort.TabIndex = 5;
            this.comboBoxPort.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            this.comboBoxPort.Click += new System.EventHandler(this.comboBoxPort_Click);
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(8, 22);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(29, 12);
            this.Port.TabIndex = 4;
            this.Port.Text = "串口";
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "115200"});
            this.comboBaudRate.Location = new System.Drawing.Point(85, 44);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(84, 20);
            this.comboBaudRate.TabIndex = 3;
            this.comboBaudRate.TextChanged += new System.EventHandler(this.PortConfigFileUpdata);
            // 
            // BaudRateLabel
            // 
            this.BaudRateLabel.AutoSize = true;
            this.BaudRateLabel.Location = new System.Drawing.Point(6, 48);
            this.BaudRateLabel.Name = "BaudRateLabel";
            this.BaudRateLabel.Size = new System.Drawing.Size(41, 12);
            this.BaudRateLabel.TabIndex = 2;
            this.BaudRateLabel.Text = "波特率";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
            this.版本信息ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.控制台ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 控制台ToolStripMenuItem
            // 
            this.控制台ToolStripMenuItem.Name = "控制台ToolStripMenuItem";
            this.控制台ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.控制台ToolStripMenuItem.Text = "控制台";
            this.控制台ToolStripMenuItem.Click += new System.EventHandler(this.控制台ToolStripMenuItem_Click);
            // 
            // 版本信息ToolStripMenuItem
            // 
            this.版本信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版本信息ToolStripMenuItem1});
            this.版本信息ToolStripMenuItem.Name = "版本信息ToolStripMenuItem";
            this.版本信息ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.版本信息ToolStripMenuItem.Text = "帮助";
            // 
            // 版本信息ToolStripMenuItem1
            // 
            this.版本信息ToolStripMenuItem1.Name = "版本信息ToolStripMenuItem1";
            this.版本信息ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.版本信息ToolStripMenuItem1.Text = "版本信息";
            this.版本信息ToolStripMenuItem1.Click += new System.EventHandler(this.版本信息ToolStripMenuItem1_Click);
            // 
            // ZOneMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 474);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxUpadat);
            this.Name = "ZOneMain";
            this.Text = "Z-One";
            this.Load += new System.EventHandler(this.ZOneMain_Load);
            this.groupBoxUpadat.ResumeLayout(false);
            this.groupBoxUpadat.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUpadat;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Label StopbitsLabel;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label ParityLabel;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.Label DataBitsLabel;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Label BaudRateLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 控制台ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本信息ToolStripMenuItem1;
    }
}

