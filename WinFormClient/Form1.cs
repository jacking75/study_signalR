﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.AspNetCore.SignalR.Client;

namespace EchoClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        int Seq1 = 0;
        int Seq2 = 0;

        public Form1()
        {
            InitializeComponent();            
        }

        // 연결
        private async void button1_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(textBox1.Text)
                .Build();

            connection.On<string, string, string>("Receive", (type, param1, param2) =>
            {
                // Run UI Thread ...
                Invoke((Action)(() =>
                {
                    listBox1.Items.Add($"[{type}] {param1} : {param2}");
                    button1.Enabled = true;
                }));
            });

            connection.Closed += HubClosed;

            try
            {
                await connection.StartAsync();
                listBox1.Items.Add("Connection started");
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
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

        // 에코 보내기
        private async void button3_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("Broadcast", textBox2.Text);
        }

        async Task HubClosed(Exception ex)
        {
            await Task.Delay(2);

            Invoke((Action)(() =>
            {
                listBox1.Items.Add("연결이 끊어졌다");

                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }));            
        }

        // 자신을 짤라달라고 서버에 요청
        private async void button4_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SelfKickOff");
        }

        // 서버에 부하가 큰 일을 요청. 서버는 Thread.Sleep 사용
        private async void button5_Click(object sender, EventArgs e)
        {            
            listBox1.Items.Add("Request Heavy Work 1");

            ++Seq1;
            await connection.InvokeAsync("DelayTast1", Seq1);
        }

        // 서버에 부하가 큰 일을 요청. 서버는 async/await 사용
        private async void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Request Heavy Work 2");

            ++Seq2;
            await connection.InvokeAsync("DelayTast2", Seq2);
        }
    }
}

