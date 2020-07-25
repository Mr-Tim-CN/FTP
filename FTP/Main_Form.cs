using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region 登录功能

        private void Anonymous_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            cmdServer = new TcpClient(IP_Box.Text, Convert.ToInt32(21));
            Log_Box.Text = "";

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
                Log("ERROR:" + err.Message.ToString());
            }
            finally
            {
                Cursor.Current = cr;
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
