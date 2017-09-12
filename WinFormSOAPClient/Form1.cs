using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSOAPClient
{
    public partial class Form1 : Form
    {
        private Services.MeteoService proxy;
        public Form1()
        {
            InitializeComponent();
            proxy = new Services.MeteoService();
            proxy.GetPrevisioneCompleted += Proxy_GetPrevisioneCompleted;
            proxy.GetEmployeesViaASMXCompleted += Proxy_GetEmployeesViaASMXCompleted;
            
        }

        private void Proxy_GetEmployeesViaASMXCompleted(object sender, Services.GetEmployeesViaASMXCompletedEventArgs e)
        {
            foreach (var item in e.Result)
            {
                this.listView1.Items.Add(item.LastName + " " + item.FirstName);
            }
        }

        private void Proxy_GetPrevisioneCompleted(object sender, Services.GetPrevisioneCompletedEventArgs e)
        {
            this.label1.Text = e.Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            proxy.GetPrevisioneAsync(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proxy.GetEmployeesViaASMXAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17570/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            String path = "api/employees";
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                //IEnumerable<CommonNet4.DTO.Employee> lst
                String content = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<IEnumerable<CommonNet4.DTO.Employee>>(content);

                foreach (var item in lst)
                {
                    this.listView1.Items.Add(item.LastName + " " + item.FirstName);
                }
            }
        }
    }
}
