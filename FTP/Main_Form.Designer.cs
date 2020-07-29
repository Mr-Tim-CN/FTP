namespace FTP
{
    partial class Main_Form
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
            this.Upload_Button = new System.Windows.Forms.Button();
            this.Download_Button = new System.Windows.Forms.Button();
            this.File_Box = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.User_Box = new System.Windows.Forms.TextBox();
            this.Pwd_Box = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Anonymous_Check = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Logout_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.IP_Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Log_Box = new System.Windows.Forms.TextBox();
            this.Folder_Box = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Upload_Button
            // 
            this.Upload_Button.Enabled = false;
            this.Upload_Button.Location = new System.Drawing.Point(550, 187);
            this.Upload_Button.Name = "Upload_Button";
            this.Upload_Button.Size = new System.Drawing.Size(213, 23);
            this.Upload_Button.TabIndex = 7;
            this.Upload_Button.Text = "选择文件上传至该文件夹";
            this.Upload_Button.UseVisualStyleBackColor = true;
            this.Upload_Button.Click += new System.EventHandler(this.Upload_Button_Click);
            // 
            // Download_Button
            // 
            this.Download_Button.Enabled = false;
            this.Download_Button.Location = new System.Drawing.Point(550, 216);
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.Size = new System.Drawing.Size(213, 23);
            this.Download_Button.TabIndex = 9;
            this.Download_Button.Text = "下载所选的文件";
            this.Download_Button.UseVisualStyleBackColor = true;
            this.Download_Button.Click += new System.EventHandler(this.Download_Button_Click);
            // 
            // File_Box
            // 
            this.File_Box.FormattingEnabled = true;
            this.File_Box.HorizontalScrollbar = true;
            this.File_Box.ItemHeight = 12;
            this.File_Box.Location = new System.Drawing.Point(550, 43);
            this.File_Box.Name = "File_Box";
            this.File_Box.Size = new System.Drawing.Size(213, 136);
            this.File_Box.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前文件夹的文件：";
            // 
            // User_Box
            // 
            this.User_Box.Location = new System.Drawing.Point(111, 84);
            this.User_Box.Name = "User_Box";
            this.User_Box.Size = new System.Drawing.Size(100, 21);
            this.User_Box.TabIndex = 1;
            this.User_Box.Text = "testuser";
            // 
            // Pwd_Box
            // 
            this.Pwd_Box.Location = new System.Drawing.Point(111, 129);
            this.Pwd_Box.Name = "Pwd_Box";
            this.Pwd_Box.Size = new System.Drawing.Size(100, 21);
            this.Pwd_Box.TabIndex = 2;
            this.Pwd_Box.Text = "Test123123";
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(136, 171);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 4;
            this.Login_Button.Text = "登录";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Anonymous_Check
            // 
            this.Anonymous_Check.AutoSize = true;
            this.Anonymous_Check.Location = new System.Drawing.Point(53, 175);
            this.Anonymous_Check.Name = "Anonymous_Check";
            this.Anonymous_Check.Size = new System.Drawing.Size(72, 16);
            this.Anonymous_Check.TabIndex = 3;
            this.Anonymous_Check.Text = "匿名登录";
            this.Anonymous_Check.UseVisualStyleBackColor = true;
            this.Anonymous_Check.CheckedChanged += new System.EventHandler(this.Anonymous_Check_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "密码";
            // 
            // Logout_Button
            // 
            this.Logout_Button.Enabled = false;
            this.Logout_Button.Location = new System.Drawing.Point(53, 209);
            this.Logout_Button.Name = "Logout_Button";
            this.Logout_Button.Size = new System.Drawing.Size(158, 23);
            this.Logout_Button.TabIndex = 5;
            this.Logout_Button.Text = "断开连接";
            this.Logout_Button.UseVisualStyleBackColor = true;
            this.Logout_Button.Click += new System.EventHandler(this.Logout_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "IP地址";
            // 
            // IP_Box
            // 
            this.IP_Box.Location = new System.Drawing.Point(111, 43);
            this.IP_Box.Name = "IP_Box";
            this.IP_Box.Size = new System.Drawing.Size(100, 21);
            this.IP_Box.TabIndex = 0;
            this.IP_Box.Text = "47.115.21.139";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "选择文件夹：";
            // 
            // Log_Box
            // 
            this.Log_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.Log_Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(228)))));
            this.Log_Box.Location = new System.Drawing.Point(6, 20);
            this.Log_Box.Multiline = true;
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.ReadOnly = true;
            this.Log_Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log_Box.Size = new System.Drawing.Size(783, 170);
            this.Log_Box.TabIndex = 10;
            this.Log_Box.TabStop = false;
            this.Log_Box.TextChanged += new System.EventHandler(this.Log_Box_TextChanged);
            // 
            // Folder_Box
            // 
            this.Folder_Box.FormattingEnabled = true;
            this.Folder_Box.HorizontalScrollbar = true;
            this.Folder_Box.ItemHeight = 12;
            this.Folder_Box.Location = new System.Drawing.Point(274, 43);
            this.Folder_Box.Name = "Folder_Box";
            this.Folder_Box.Size = new System.Drawing.Size(212, 196);
            this.Folder_Box.TabIndex = 6;
            this.Folder_Box.SelectedIndexChanged += new System.EventHandler(this.Folder_Box_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Log_Box);
            this.groupBox1.Location = new System.Drawing.Point(12, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 196);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Folder_Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IP_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Logout_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Anonymous_Check);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Pwd_Box);
            this.Controls.Add(this.User_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.File_Box);
            this.Controls.Add(this.Download_Button);
            this.Controls.Add(this.Upload_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP客户端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Upload_Button;
        private System.Windows.Forms.Button Download_Button;
        private System.Windows.Forms.ListBox File_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox User_Box;
        private System.Windows.Forms.TextBox Pwd_Box;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.CheckBox Anonymous_Check;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Logout_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IP_Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Log_Box;
        private System.Windows.Forms.ListBox Folder_Box;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

