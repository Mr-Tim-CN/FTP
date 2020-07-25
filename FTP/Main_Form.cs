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
        #region 打印日志的功能

        /// <summary>
        /// 调用Log(string)可以直接在日志区新增一行日志。
        /// </summary>
        /// <param name="logContent"></param>
        
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

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Upload_Button_Click(object sender, EventArgs e)
        {

        }
        
    }
}
