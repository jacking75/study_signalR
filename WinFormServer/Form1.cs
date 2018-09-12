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
        public Form1()
        {
            InitializeComponent();
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
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("서버 시작 예외 발생: " + ex.Message);
            }
        }
    }
}
