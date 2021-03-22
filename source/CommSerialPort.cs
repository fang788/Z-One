using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z_One.source
{
    class CommSerialPort : SerialPort
    {
        private static CommSerialPort portInstanse = null;

        private static int timeout;

        private const int SLEEP_TIMES = 3;

        //private static object thisLock = 12;

        //recieveDateTime = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff.f");

        // public string error;
        /*
         * 串口参数配置文件是否被修改标志
         * 0：未被修改
         * 1：已被修改
         * 串口类与界面线程通讯的变量
         */
        public static int isChange = 0; /* 配置文件是否已经被修改 */

        public static bool configIsChange = false;

        //public static int hasFrameFlag = 0x55;

        /*
        * frameCnt:上位机与工装有通讯交互标志
        * frameOut == frameIn：没有通讯交互
        * frameOut != frameIn：有通讯交互
        * 串口类与控制台界面通讯的变量
        */
        public const int MAX_FRAME_LEN = 10;

        //public static string[] frame = new string[MAX_FRAME_LEN];
        //public static int frameCnt = 0;
        //public static int frameOut = 0;
        //public static int frameIn = 0;

        public static ConcurrentQueue<string> frameQueue = new ConcurrentQueue<string>();

        public static string CONFIG_FILE_PATH = Application.StartupPath + "//config.ini";

        private static SerialPort serialPort = new SerialPort();

        private static Mutex commMutex = new Mutex();

        private static EventWaitHandle commEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

        // private static ConcurrentQueue<CommFrame1> frameQueue1 = new ConcurrentQueue<CommFrame1>();
        private CommSerialPort()
        {

        }

        public static void SerialPortInit()
        {
            serialPort.PortName = INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "com", "COM1").Trim();
            serialPort.BaudRate = Convert.ToInt32(INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "baud", "115200").Trim(), 10);

            serialPort.DataBits = (byte)Convert.ToByte(INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "Bits", "8"), 10);

            string parity = INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "Parity", "None");
            if (parity == "None")
            {
                serialPort.Parity = (Parity)0;
            }
            else if (parity == "Odd")
            {
                serialPort.Parity = (Parity)1;
            }
            else if (parity == "Even")
            {
                serialPort.Parity = (Parity)2;
            }
            else if (parity == "Mark")
            {
                serialPort.Parity = (Parity)3;
            }

            serialPort.StopBits = (StopBits)Convert.ToByte(INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "StopBits", "1"), 10);  //停止位1
            serialPort.ReadTimeout = 5000;
            timeout = Convert.ToInt32(INIOperationClass.INIGetStringValue(CONFIG_FILE_PATH, "Config", "Timeout", "2"), 10);
        }
        // public static bool Communicating(ref CommFrame1 frame)
        // {
        //     // int len, count = 0;
        //     // byte[] buff = new byte[1024];
        //     // bool rst = false;
        //     // commMutex.WaitOne();
        //     // SerialPortInit();
        //     // if(isChange > 0)
        //     // {
        //     //     SerialPortInit();
        //     //     Interlocked.Exchange(ref isChange, 0);
        //     // }
        //     // try
        //     // {
        //     //     /* 另一个进程打开该串口时后报异常导致程序退出，后续修改 */
        //     //     serialPort.Open();
        //     //     if (!serialPort.IsOpen)
        //     //     {
        //     //         MessageBox.Show("打开串口失败!");
        //     //     }
        //     //     else
        //     //     {
        //     //         serialPort.DiscardInBuffer();
        //     //         serialPort.Write(frame.sendBuff, 0, frame.sendLen);
        //     //         frame.sendTime = DateTime.Now;
        //     //         while (true)
        //     //         {
        //     //             System.Threading.Thread.Sleep(SLEEP_TIMES);
        //     //             len = serialPort.BytesToRead;
        //     //             if (len != 0)
        //     //             {
        //     //                 if (len <= buff.Length)
        //     //                 {
        //     //                     serialPort.Read(buff, 0, len);

        //     //                     if (frame.FindFrame(buff, len, ref frame.recieveBuff, ref frame.recieveLen) == true)
        //     //                     {
        //     //                         rst = true;
        //     //                         break;
        //     //                     }
        //     //                 }
        //     //                 else
        //     //                 {
        //     //                     MessageBox.Show("接收缓存不足！", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     //                     frame.error = "接收缓存不足！";
        //     //                     break;
        //     //                 }
        //     //             }
        //     //             count++;
        //     //             if ((count * SLEEP_TIMES) > (timeout * 1000))
        //     //             {
        //     //                 MessageBox.Show("响应超时！", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     //                 frame.error = "响应超时!";
        //     //                 break;
        //     //             }
        //     //         }
        //     //     }
        //     // }
        //     // catch (IOException e)
        //     // {
        //     //     MessageBox.Show($"串口有问题{e.ToString()}", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     // }
        //     // catch (UnauthorizedAccessException)
        //     // {
        //     //     MessageBox.Show("串口" + serialPort.PortName + "打开失败", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     //     frame.error = "串口"+ serialPort.PortName+"打开失败";
        //     // }
        //     // finally
        //     // {
        //     //     if (serialPort != null)
        //     //     {
        //     //         if (serialPort.IsOpen)
        //     //         {
        //     //             serialPort.Close();
        //     //         }
        //     //     }
        //     //     frame.recieveTime = DateTime.Now;
        //     //     if ((MainForm.console != null) && (MainForm.console.Created == true))
        //     //     {
        //     //         frameQueue.Enqueue(frame.getCommFrame());
        //     //     }   
        //     //     commMutex.ReleaseMutex();
        //     // }

        //     // return rst;
        // }
        // public static void CommunicateTask()
        // {
        //     CommFrame1 cf;
        //     while(true)
        //     {
        //         commEvent.WaitOne();
        //         while(!frameQueue1.IsEmpty)
        //         {
        //             if(frameQueue1.TryDequeue(out cf))
        //             {
        //                 Communicating(ref cf);
        //             }
        //         }
        //     }
        // }

        // public static bool StartCommunicate(ref CommFrame1 f)
        // {
        //     frameQueue1.Enqueue(f);
        //     return commEvent.Set();
        // }

        public static CommSerialPort GetCommSerialPortInstanse()
        {
            if (CommSerialPort.portInstanse == null)
            {
                CommSerialPort.portInstanse = new CommSerialPort();
                Updata(CommSerialPort.portInstanse);
            }

            return CommSerialPort.portInstanse;
        }

        private static void Updata(SerialPort srlport)
        {
            string iniFilePath = Application.StartupPath + "//config.ini";
            srlport.PortName = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "com", "COM1").Trim();
            srlport.BaudRate = Convert.ToInt32(INIOperationClass.INIGetStringValue(iniFilePath, "Config", "baud", "115200").Trim(), 10);

            srlport.DataBits = (byte)Convert.ToByte(INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Bits", "8"), 10);

            string parity = INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Parity", "None");
            if (parity == "None")
            {
                srlport.Parity = (Parity)0;
            }
            else if (parity == "Odd")
            {
                srlport.Parity = (Parity)1;
            }
            else if (parity == "Even")
            {
                srlport.Parity = (Parity)2;
            }
            else if (parity == "Mark")
            {
                srlport.Parity = (Parity)3;
            }

            srlport.StopBits = (StopBits)Convert.ToByte(INIOperationClass.INIGetStringValue(iniFilePath, "Config", "StopBits", "1"), 10);  //停止位1
            srlport.ReadTimeout = 5000;
            timeout = Convert.ToInt32(INIOperationClass.INIGetStringValue(iniFilePath, "Config", "Timeout", "2"), 10);
        }

        //public static bool Communicate(ref CommFrame frame, IFindFrame ff, ref string error)
        //{
        //    bool rst = false;
        //    int len = 0;
        //    int count = 0;
        //    //int offset = 0;
        //    byte[] buff = new byte[1024];
        //    commMutex.WaitOne();

        //    // SerialPort srlport = this;

        //    if (CommSerialPort.isChange == 1)
        //    {
        //        Updata(serialPort);
        //        //CommSerialPort.isChange = false;
        //        Interlocked.Exchange(ref isChange, 0);
        //    }
        //    try
        //    {
        //        /* 另一个进程打开该串口时后报异常导致程序退出，后续修改 */
        //        serialPort.Open();
        //        if (!serialPort.IsOpen)
        //        {
        //            MessageBox.Show("打开串口失败!");
        //            error = "打开串口失败";
        //        }
        //        else
        //        {
        //            serialPort.DiscardInBuffer();
        //            serialPort.Write(frame.sendBuff, 0, frame.sendLen);
        //            frame.sendTime = DateTime.Now;
        //            while (true)
        //            {
        //                System.Threading.Thread.Sleep(SLEEP_TIMES);
        //                len = serialPort.BytesToRead;
        //                if (len != 0)
        //                {
        //                    if (len <= buff.Length)
        //                    {
        //                        serialPort.Read(buff, 0, len);

        //                        if (ff.FindFrame(buff, len, ref frame.recieveBuff, ref frame.recieveLen) == true)
        //                        {
        //                            rst = true;
        //                            break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("接收缓存不足！", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        //MessageBox.Show("接收缓存不足");
        //                        error = "接收缓存不足";
        //                        break;
        //                    }
        //                }
        //                count++;
        //                if ((count * SLEEP_TIMES) > (timeout * 1000))
        //                {
        //                    MessageBox.Show("响应超时！", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    //MessageBox.Show("响应超时");
        //                    error = "响应超时";
        //                    break;
        //                }
        //            }
        //        }

        //    }
        //    catch (IOException e)
        //    {
        //        //MessageBox.Show($"串口有问题{e.ToString()}");
        //        MessageBox.Show($"串口有问题{e.ToString()}", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        //MessageBox.Show("串口" + srlport.PortName + "打开失败");
        //        MessageBox.Show("串口" + serialPort.PortName + "打开失败", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        error = "串口" + serialPort.PortName + "打开失败";
        //    }
        //    finally
        //    {
        //        if (serialPort != null)
        //        {
        //            if (serialPort.IsOpen)
        //            {
        //                serialPort.Close();
        //            }
        //        }
        //        frame.recieveTime = DateTime.Now;
        //        if ((ZOneMain.console != null) && (ZOneMain.console.Created == true))
        //        {
        //            frameQueue.Enqueue(frame.getCommFrame());
        //        }
        //        commMutex.ReleaseMutex();
        //    }

        //    return rst;
        //}

        //public bool CommunicateData(string s, string ack, ref int index, ref string error)
        //{
        //    bool rst = false;
        //    char[] buff = new char[100];
        //    SerialPort srlport = this;
        //    if (CommSerialPort.isChange == 1)
        //    {
        //        Updata(this);
        //        Interlocked.Exchange(ref isChange, 0);
        //    }
        //    try
        //    {
        //        /* 另一个进程打开该串口时后报异常导致程序退出，后续修改 */
        //        srlport.Open();
        //        if (!srlport.IsOpen)
        //        {
        //            MessageBox.Show("打开串口失败!");
        //            error = "打开串口失败";
        //        }
        //        else
        //        {
        //            srlport.DiscardInBuffer();
        //            srlport.Write(s);

        //            System.Threading.Thread.Sleep(500);
        //            this.Read(buff, 0, 100);
        //            index = new string(buff).IndexOf(ack);
        //            if (index > 0)
        //            {
        //                rst = true;
        //            }

        //        }

        //    }
        //    catch (IOException e)
        //    {
        //        MessageBox.Show($"串口有问题{e.ToString()}", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        MessageBox.Show("串口" + srlport.PortName + "打开失败", "J6Comm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        error = "串口" + srlport.PortName + "打开失败";
        //    }
        //    finally
        //    {
        //        if (srlport != null)
        //        {
        //            if (srlport.IsOpen)
        //            {
        //                srlport.Close();
        //            }
        //        }
        //    }

        //    return rst;
        //}
   
    }

}
