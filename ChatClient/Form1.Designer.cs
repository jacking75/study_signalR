namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxReqChat = new System.Windows.Forms.TextBox();
            this.btnRoomChat = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxRoomNumber = new System.Windows.Forms.TextBox();
            this.btnRoomEnter = new System.Windows.Forms.Button();
            this.btnRoomLeave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.btnNickName = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "http://localhost:19000/ChatHub";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "연결";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(318, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "끊기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxReqChat
            // 
            this.textBoxReqChat.Location = new System.Drawing.Point(13, 59);
            this.textBoxReqChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxReqChat.Name = "textBoxReqChat";
            this.textBoxReqChat.Size = new System.Drawing.Size(579, 25);
            this.textBoxReqChat.TabIndex = 4;
            // 
            // btnRoomChat
            // 
            this.btnRoomChat.Enabled = false;
            this.btnRoomChat.Location = new System.Drawing.Point(519, 21);
            this.btnRoomChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoomChat.Name = "btnRoomChat";
            this.btnRoomChat.Size = new System.Drawing.Size(73, 32);
            this.btnRoomChat.TabIndex = 5;
            this.btnRoomChat.Text = "채팅";
            this.btnRoomChat.UseVisualStyleBackColor = true;
            this.btnRoomChat.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(26, 400);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(610, 169);
            this.listBox1.TabIndex = 6;
            // 
            // textBoxRoomNumber
            // 
            this.textBoxRoomNumber.Location = new System.Drawing.Point(13, 27);
            this.textBoxRoomNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRoomNumber.Name = "textBoxRoomNumber";
            this.textBoxRoomNumber.Size = new System.Drawing.Size(69, 25);
            this.textBoxRoomNumber.TabIndex = 7;
            this.textBoxRoomNumber.Text = "-1";
            // 
            // btnRoomEnter
            // 
            this.btnRoomEnter.Location = new System.Drawing.Point(88, 23);
            this.btnRoomEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoomEnter.Name = "btnRoomEnter";
            this.btnRoomEnter.Size = new System.Drawing.Size(73, 32);
            this.btnRoomEnter.TabIndex = 8;
            this.btnRoomEnter.Text = "방 입장";
            this.btnRoomEnter.UseVisualStyleBackColor = true;
            this.btnRoomEnter.Click += new System.EventHandler(this.btnRoomEnter_Click);
            // 
            // btnRoomLeave
            // 
            this.btnRoomLeave.Location = new System.Drawing.Point(167, 23);
            this.btnRoomLeave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoomLeave.Name = "btnRoomLeave";
            this.btnRoomLeave.Size = new System.Drawing.Size(87, 32);
            this.btnRoomLeave.TabIndex = 9;
            this.btnRoomLeave.Text = "방 나가기";
            this.btnRoomLeave.UseVisualStyleBackColor = true;
            this.btnRoomLeave.Click += new System.EventHandler(this.btnRoomLeave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNickName);
            this.groupBox1.Controls.Add(this.textBoxNickName);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(26, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 70);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "서버 접속";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxChat);
            this.groupBox2.Controls.Add(this.btnRoomLeave);
            this.groupBox2.Controls.Add(this.textBoxRoomNumber);
            this.groupBox2.Controls.Add(this.btnRoomEnter);
            this.groupBox2.Controls.Add(this.btnRoomChat);
            this.groupBox2.Controls.Add(this.textBoxReqChat);
            this.groupBox2.Location = new System.Drawing.Point(26, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 308);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "방";
            // 
            // listBoxChat
            // 
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.ItemHeight = 15;
            this.listBoxChat.Location = new System.Drawing.Point(13, 100);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(579, 199);
            this.listBoxChat.TabIndex = 10;
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.Location = new System.Drawing.Point(392, 26);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(102, 25);
            this.textBoxNickName.TabIndex = 4;
            // 
            // btnNickName
            // 
            this.btnNickName.Enabled = false;
            this.btnNickName.Location = new System.Drawing.Point(496, 22);
            this.btnNickName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNickName.Name = "btnNickName";
            this.btnNickName.Size = new System.Drawing.Size(100, 32);
            this.btnNickName.TabIndex = 5;
            this.btnNickName.Text = "닉네임 변경";
            this.btnNickName.UseVisualStyleBackColor = true;
            this.btnNickName.Click += new System.EventHandler(this.btnNickName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "EchoClient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxReqChat;
        private System.Windows.Forms.Button btnRoomChat;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxRoomNumber;
        private System.Windows.Forms.Button btnRoomEnter;
        private System.Windows.Forms.Button btnRoomLeave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.Button btnNickName;
        private System.Windows.Forms.TextBox textBoxNickName;
    }
}

