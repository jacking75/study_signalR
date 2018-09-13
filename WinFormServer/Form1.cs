using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WinFormServer
{
    public partial class Form1 : Form
    {
        System.Windows.Threading.DispatcherTimer dispatcherUITimer;

        public Form1()
        {
            InitializeComponent();

            dispatcherUITimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherUITimer.Tick += new EventHandler(ProcessLog);
            dispatcherUITimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherUITimer.Start();
        }

        private void ProcessLog(object sender, EventArgs e)
        {
            // 너무 이 작업만 할 수 없으므로 일정 작업 이상을 하면 일단 패스한다.
            int logWorkCount = 0;

            while (true)
            {
                string msg;

                if (DevLog.GetLog(out msg))
                {
                    ++logWorkCount;

                    if (listBox1.Items.Count > 512)
                    {
                        listBox1.Items.Clear();
                    }

                    listBox1.Items.Add(msg);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    break;
                }

                if (logWorkCount > 8)
                {
                    break;
                }
            }
        }

        public IWebHostBuilder CreateWebHostBuilder(string urlAddress) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseKestrel()
                .UseUrls(urlAddress)
                .UseStartup<Startup>();

        // 서버 시작
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBox1.Text;
                string urlAddress = $"http://*:{port}";
                Task.Run(() => CreateWebHostBuilder(urlAddress).Build().Run());

                button1.Enabled = false;

                DevLog.Write("Start Server !!!", LOG_LEVEL.INFO);
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("서버 시작 예외 발생: " + ex.Message);
            }
        }
    }
}
