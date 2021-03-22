using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z_One.source;

namespace Z_One
{
    public partial class ZOneMain : Form
    {

        public ZOneMain()
        {
            InitializeComponent();
        }

        public static Form console = null;
        private void 控制台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((console == null) || (console.Created == false))
            {
                console = new source.Console();
            }
            else
            {
                ;
            }

            try
            {
                console.Show();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
        }

        private void 版本信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppVersion Version = new AppVersion();

            this.AddOwnedForm(Version);
            Version.StartPosition = FormStartPosition.CenterParent;
            Version.ShowDialog();
        }

        string iniFilePath = Application.StartupPath + "\\config.ini";
        private void ZOneMain_Load(object sender, EventArgs e)
        {
            comboBoxPort.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "com", "COM1");
            comboBaudRate.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "baud", "115200");

            comboBoxDataBits.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Bits", "8");
            comboBoxParity.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Parity", "None");
            comboBoxStopBits.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "StopBits", "1");

            textBoxTimeout.Text = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Timeout", "2");
        }

        private void comboBoxPort_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                //MessageBox.Show(s);
                comboBoxPort.Items.Add(s);
            }
        }

        /*******************************************************************************
         * FUNCTION:        Vps_pcMesageProcess
         * DESCRIPTION:     串口设置界面数据加载
         * INPUT:           none
         * OUTPUT:          none
         * RETURN:          true(成功)/false(失败)
         * OTHERS:          none
         *******************************************************************************/
        void PortConfigFileUpdata(object sender, EventArgs e)
        {
            if (sender == comboBoxPort)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "com", comboBoxPort.Text);
            }
            else if (sender == comboBaudRate)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "baud", comboBaudRate.Text);
            }
            else if (sender == comboBoxDataBits)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "Bits", comboBoxDataBits.Text);
            }
            else if (sender == comboBoxParity)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "Parity", comboBoxParity.Text);
            }
            else if (sender == comboBoxStopBits)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "StopBits", comboBoxStopBits.Text);
            }
            else if (sender == textBoxTimeout)
            {
                INIOperationClass.INIWriteValue(iniFilePath, "Config", "Timeout", textBoxTimeout.Text);
            }
            //else if (sender == textBox_IpAddr)
            //{
            //    INIOperationClass.INIWriteValue(iniFilePath, "Config", "IpAddr", textBox_IpAddr.Text);
            //}
            Interlocked.Exchange(ref CommSerialPort.isChange, 1);
        }
    }
}
