using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        #endregion

        #region 断开连接功能

        private void Logout_Button_Click(object sender, EventArgs e)
        {

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
