
namespace BluetoothServer
{
    partial class Main
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLocBlue = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbConnectCount = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lsClients = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbLocBlue);
            this.groupBox2.Controls.Add(this.btnListen);
            this.groupBox2.Location = new System.Drawing.Point(26, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 140);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地";
            // 
            // lbLocBlue
            // 
            this.lbLocBlue.AutoSize = true;
            this.lbLocBlue.Location = new System.Drawing.Point(6, 90);
            this.lbLocBlue.Name = "lbLocBlue";
            this.lbLocBlue.Size = new System.Drawing.Size(97, 15);
            this.lbLocBlue.TabIndex = 2;
            this.lbLocBlue.Text = "本地蓝牙名称";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(9, 41);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(137, 32);
            this.btnListen.TabIndex = 1;
            this.btnListen.Text = "开始监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.lsClients);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.lbConnectCount);
            this.groupBox1.Location = new System.Drawing.Point(26, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 300);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端";
            // 
            // lbConnectCount
            // 
            this.lbConnectCount.AutoSize = true;
            this.lbConnectCount.Location = new System.Drawing.Point(15, 41);
            this.lbConnectCount.Name = "lbConnectCount";
            this.lbConnectCount.Size = new System.Drawing.Size(52, 15);
            this.lbConnectCount.TabIndex = 3;
            this.lbConnectCount.Text = "连接数";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(376, 64);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(435, 415);
            this.txtMsg.TabIndex = 10;
            this.txtMsg.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "消息:";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(18, 140);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(274, 80);
            this.txtSend.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(18, 245);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(274, 34);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lsClients
            // 
            this.lsClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lsClients.FormattingEnabled = true;
            this.lsClients.Location = new System.Drawing.Point(18, 72);
            this.lsClients.Name = "lsClients";
            this.lsClients.Size = new System.Drawing.Size(274, 23);
            this.lsClients.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "发送消息";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "蓝牙服务器";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbLocBlue;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbConnectCount;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox lsClients;
        private System.Windows.Forms.Label label2;
    }
}

