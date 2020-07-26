using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace FTP
{

    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }
        
        #region 全局变量
        private TcpClient cmdServer;
        private TcpClient dataServer;
        private NetworkStream cmdStrmWtr;
        private StreamReader cmdStrmRdr;
        private NetworkStream dataStrmWtr;
        private StreamReader dataStrmRdr;
        private String cmdData;
        private byte[] szData;
        private const String CRLF = "\r\n";
        #endregion

        #region 全局函数

        #region 打印日志功能

        /// <summary>
        /// 调用Log(string)可以直接在日志区新增一行日志。
        /// </summary>

        private void Log(string logContent)                             //打印日志
        {
            string time = DateTime.Now.ToLocalTime().ToString();
            Log_Box.Text += "[" + time + "]：" + logContent + "\r\n";
        }

        private void Log_Box_TextChanged(object sender, EventArgs e)    //将日志区滑至底端
        {
            Log_Box.SelectionStart = Log_Box.Text.Length;
            Log_Box.ScrollToCaret();
        }

        #endregion

        private String getSatus()
        {
            String ret;
            try
            {
                ret = cmdStrmRdr.ReadLine();
                Log(ret);
                return ret;
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
            return "Fail";
        }

        private void openDataPort()
        {
            string retstr;
            string[] retArray;
            int dataPort;

            // Start Passive Mode 
            cmdData = "PASV" + CRLF; 
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            retstr = this.getSatus();

            // Calculate data's port
            retArray = Regex.Split(retstr, ",");
            if (retArray[5][2] != ')') retstr = retArray[5].Substring(0, 3);
            else retstr = retArray[5].Substring(0, 2);
            dataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
            Log("Get dataPort=" + dataPort);


            //Connect to the dataPort
            dataServer = new TcpClient(IP_Box.Text, dataPort);
            dataStrmRdr = new StreamReader(dataServer.GetStream());
            dataStrmWtr = dataServer.GetStream();
        }

        /// <summary>
        /// 断开数据端口的连接
        /// </summary>
        private void closeDataPort()
        {
            dataStrmRdr.Close();
            dataStrmWtr.Close();
            this.getSatus();

            cmdData = "ABOR" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

        }


        private void freshFileBox_Right()
        {

            openDataPort();

            string absFilePath;

            //List
            cmdData = "LIST" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            File_Box.Items.Clear();
            while ((absFilePath = dataStrmRdr.ReadLine()) != null)
            {
                string[] temp = Regex.Split(absFilePath, " ");
                File_Box.Items.Add(temp[temp.Length - 1]);
            }

            closeDataPort();
        }

        #endregion

        #region 登录功能

        private void Anonymous_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            //Cursor cr = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                cmdServer = new TcpClient(IP_Box.Text, 21);     //21是FTP协议规定的控制进程端口号
            }
            catch (Exception x)
            {
                Log(x.Message);
                return;
            }

            try 
            {
                cmdStrmRdr = new StreamReader(cmdServer.GetStream());
                cmdStrmWtr = cmdServer.GetStream();
                this.getSatus();

                string retstr;

                //login
                cmdData = "USER" + Name_Box.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.getSatus();

                cmdData = "PASS" + Pwd_Box.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                retstr = this.getSatus().Substring(0, 3);
                if (Convert.ToInt32(retstr) == 530) throw new InvalidOperationException("帐号密码错误");

                this.freshFileBox_Right();

                IP_Box.Text = IP_Box.Text + ":";
                Upload_Button.Enabled = true;
                Download_Button.Enabled = true;
            }
            catch(InvalidOperationException err)
            {
                Log("ERROR:" + err.Message);
            }
            catch(Exception x)
            {
                Log(x.Message);
            }
            finally
            {
                //Cursor.Current = cr;
            }
        }
        #endregion

        #region 断开连接功能

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            //Logout

            cmdData = "QUIT" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();


            cmdStrmWtr.Close();
            cmdStrmRdr.Close();

            IP_Box.Text = "";
            Upload_Button.Enabled = true;
            Download_Button.Enabled = true;
            Log_Box.Text = "";
            Cursor.Current = cr;
        }

        #endregion

        #region 上传功能

        private void Upload_Button_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 下载功能

        private void Download_Button_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
