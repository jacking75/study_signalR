using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        public Form1()
        {
            InitializeComponent();            
        }

        async Task HubClosed(Exception ex)
        {
            await Task.Delay(2);

            Invoke((Action)(() =>
            {
                listBox1.Items.Add("연결이 끊어졌다");

                button1.Enabled = true;
                button2.Enabled = false;
                btnRoomChat.Enabled = false;
            }));
        }

        void ResChangeNickName(ErrorCode error)
        {
            Invoke((Action)(() =>
            {
                listBox1.Items.Add($"닉네임 변경 요청 결과: {error.ToString()}");

                if(error != ErrorCode.NONE)
                {
                    textBoxNickName.Text = "";
                }
            }));
        }

        // 연결
        private async void button1_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(textBox1.Text)
                .Build();

            connection.Closed += HubClosed;

            connection.On<string, string>("Receive", (message, timestamp) =>
            {
                // Run UI Thread ...
                Invoke((Action)(() =>
                {
                    listBox1.Items.Add($"{ timestamp} : {message}");
                    button1.Enabled = true;
                }));
            });

            connection.On<ErrorCode>("ResChangeNickName", ResChangeNickName);           
            

            try
            {
                await connection.StartAsync();
                listBox1.Items.Add("Connection started");
                button1.Enabled = false;
                button2.Enabled = true;
                btnRoomChat.Enabled = true;
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        // 끊기
        private async void button2_Click(object sender, EventArgs e)
        {
            await connection.StopAsync();            
        }

        // 방 채팅
        private async void button3_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("Broadcast", textBoxReqChat.Text);
        }               
       
        private void btnNickName_Click(object sender, EventArgs e)
        {

        }

        // 방 입장
        private void btnRoomEnter_Click(object sender, EventArgs e)
        {

        }

        // 방 나가기
        private void btnRoomLeave_Click(object sender, EventArgs e)
        {

        }
        
        //textBoxNickName textBoxNickName textBoxRoomNumber   textBoxReqChat  listBoxChat
    }
}

