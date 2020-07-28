using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace FTP
{

    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }
        
        #region 全局变量
        /// <summary>
        /// cmd：控制
        /// data：数据
        /// </summary>
        private TcpClient cmdServer;
        private TcpClient dataServer;
        private NetworkStream cmdStrmWtr;
        private StreamReader cmdStrmRdr;
        private NetworkStream dataStrmWtr;
        private StreamReader dataStrmRdr;
        private string cmdData;
        private byte[] szData;
        private const string CRLF = "\r\n";
        #endregion

        #region 打印日志
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

        #region 获取控制连接返回的数据
        private string GetStatus()
        {
            string ret;
            try
            {
                ret = cmdStrmRdr.ReadLine();
                Log("<控制连接> 返回信息：" + ret);
                return ret;
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
            return "Failed";
        }
        #endregion

        #region 打开被动模式并打开数据连接
        private void OpenDataPort()
        {
            string retstr;
            string[] retArray;
            int dataPort;
            try
            {
                //打开被动模式
                Log("<控制连接> 发送PASV，进入被动模式");
                cmdData = "PASV" + CRLF;
                szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                retstr = GetStatus();

                //计算将要连接的端口号
                retArray = Regex.Split(retstr, ",");

                if (retArray[5][1] == ')')                  //1位数
                    retstr = retArray[5].Substring(0, 1);
                else if (retArray[5][2] == ')')             //2位数
                    retstr = retArray[5].Substring(0, 2);
                else                                        //3位数
                    retstr = retArray[5].Substring(0, 3);

                dataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
                Log("<数据连接> 连接端口" + dataPort);

                //连接端口
                dataServer = new TcpClient(IP_Box.Text, dataPort);
                dataStrmRdr = new StreamReader(dataServer.GetStream());
                dataStrmWtr = dataServer.GetStream();
            }
            catch(Exception x)
            {
                Log("<系统提示> " + x.Message);
            }
        }
        #endregion
        
        #region 断开数据连接
        private void CloseDataPort()
        {
            try
            {
                Log("<数据连接> 本地断开数据连接");
                dataStrmRdr.Close();
                dataStrmWtr.Close();
                GetStatus();

                Log("<控制连接> 发送ABOR，请服务器断开数据连接");
                cmdData = "ABOR" + CRLF;
                szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                GetStatus();
            }
            catch(Exception x)
            {
                Log("<系统提示> " + x.Message);
            }
        }
        #endregion

        #region 加载文件列表
        private void LoadFolderBox()
        {

            OpenDataPort();

            //获取文件列表
            Log("<控制连接> 发送LIST，获取文件列表");
            cmdData = "LIST" + CRLF;
            szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            GetStatus();




            //需要解码！！！
            //Log("以下是文件列表：\r\n" + dataStrmRdr.ReadToEnd());




            Folder_Box.Items.Clear();
            File_Box.Items.Clear();

            Log("<数据连接> 正在接收文件列表");
            string fileInfo = dataStrmRdr.ReadToEnd();
            string[] fileLineArray = Regex.Split(fileInfo, "\n");
            foreach (var Info in fileLineArray)
            {
                if (Info == "")
                {
                    break;
                }
                Regex regex = new Regex("\\s+");
                string[] fileInfoSplit = regex.Split(Info, 4);
                string name = fileInfoSplit[fileInfoSplit.Length - 1];  //文件名或文件夹名
                if (fileInfoSplit[2] == "<DIR>")
                {
                    Folder_Box.Items.Add(name);
                }
                else
                {
                    File_Box.Items.Add(name);
                }
            }
            Log("<数据连接> 文件列表的数据处理完毕");
            CloseDataPort();
        }
        #endregion

        #region 登录

        private void Anonymous_Check_CheckedChanged(object sender, EventArgs e)     //匿名登录
        {
            if (Anonymous_Check.Checked)
            {
                User_Box.Text = "anonymous";
                User_Box.Enabled = false;
                Pwd_Box.Text = "";
                Pwd_Box.Enabled = false;
            }
            else
            {
                User_Box.Text = "";
                User_Box.Enabled = true;
                Pwd_Box.Enabled = true;
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Log("----------------------------------------------------------");
            try
            {
                Log("<控制连接> 尝试连接" + IP_Box.Text + ":21");
                cmdServer = new TcpClient(IP_Box.Text, 21);     //21是FTP协议规定的控制进程端口号
                Log("<控制连接> 连接成功");
            }
            catch (Exception x)
            {
                Log("<系统提示> " + x.Message);
                return;
            }

            try 
            {
                cmdStrmRdr = new StreamReader(cmdServer.GetStream());
                cmdStrmWtr = cmdServer.GetStream();

                //避免连接上不受支持的服务器
                string[] x = GetStatus().Split(' ');
                if (x[1] != "Microsoft")
                {
                    Log("<系统提示> 该程序只支持IIS，请连接受支持的服务器");

                    Log("<控制连接> 发送QUIT，请服务器断开控制连接");
                    cmdData = "QUIT" + CRLF;
                    szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    GetStatus();

                    Log("<控制连接> 本地断开控制连接");
                    cmdStrmWtr.Close();
                    cmdStrmRdr.Close();

                    return;
                }
                string retstr;

                //登录
                Log("<控制连接> 发送用户名");
                cmdData = "USER " + User_Box.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                retstr = GetStatus().Substring(0, 3);
                if (Convert.ToInt32(retstr) == 501) throw new InvalidOperationException("帐号不合法");

                Log("<控制连接> 发送密码");
                cmdData = "PASS " + Pwd_Box.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                retstr = GetStatus().Substring(0, 3);
                if (Convert.ToInt32(retstr) == 530) throw new InvalidOperationException("帐号密码错误");

                LoadFolderBox();

                IP_Box.Enabled = false;
                User_Box.Enabled = false;
                Pwd_Box.Enabled = false;
                Anonymous_Check.Enabled = false;
                Login_Button.Enabled = false;
                Logout_Button.Enabled = true;
                Upload_Button.Enabled = true;
                Download_Button.Enabled = true;
            }
            catch(Exception x)
            {
                Log("<系统提示> " + x.Message);
            }
        }
        #endregion

        #region 断开控制连接

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Log("<控制连接> 发送QUIT，请服务器断开控制连接");
                cmdData = "QUIT" + CRLF;
                szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                GetStatus();
            }
            catch (Exception x)
            {
                Log("<系统提示> " + x.Message);
            }

            Log("<控制连接> 本地断开控制连接");
            cmdStrmWtr.Close();
            cmdStrmRdr.Close();

            IP_Box.Enabled = true;
            if (!Anonymous_Check.Checked)
            {
                User_Box.Enabled = true;
                Pwd_Box.Enabled = true;
            }
            Anonymous_Check.Enabled = true;
            Login_Button.Enabled = true;
            Logout_Button.Enabled = false;
            Upload_Button.Enabled = false;
            Download_Button.Enabled = false;
            File_Box.Items.Clear();
            Folder_Box.Items.Clear();
        }

        #endregion

        #region 上传

        private void Upload_Button_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 下载

        private void Download_Button_Click(object sender, EventArgs e)
        {
            if (Folder_Box.Text == "" || File_Box.SelectedIndex < 0)
            {
                MessageBox.Show("请选择目标文件和下载路径", "ERROR");
                return;
            }

            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = File_Box.Items[File_Box.SelectedIndex].ToString();
            string filePath = Folder_Box.Text + "\\" + fileName;

            this.OpenDataPort();

            cmdData = "RETR " + fileName + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.GetStatus();

            FileStream fstrm = new FileStream(filePath, FileMode.OpenOrCreate);
            char[] fchars = new char[1030];
            byte[] fbytes = new byte[1030];
            int cnt = 0;
            while ((cnt = dataStrmWtr.Read(fbytes, 0, 1024)) > 0)
            {
                fstrm.Write(fbytes, 0, cnt);
            }
            fstrm.Close();

            this.CloseDataPort();

            this.LoadFolderBox();

            Cursor.Current = cr;
        }

        #endregion


    }
}
