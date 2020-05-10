using ConsumirAPI.DTO;
using ConsumirAPI.Interface;
using ConsumirAPI.Service;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumirAPI
{
    public partial class Form1 : Form
    {
        //private string appSettingsUrlApi;
        // static HttpClient client = new HttpClient();
        //private readonly PessoaService pessoaService;

        public Form1()
        {          

            InitializeComponent();
                     
        }          

        private void Get_Click(object sender, EventArgs e)
        {
            var pessoaService = new PessoaService();
            var t = Task.Run(() => pessoaService.GetURI());
            t.Wait();
            textBox1.Text = t.Result;
        }
        private void Post_Click(object sender, EventArgs e)
        {
            var pessoaService = new PessoaService();
            var pessoaDTO = new PessoaDTO { Nome = "Joao", Idade = 100};

            var t = Task.Run(() => pessoaService.PostURI(pessoaDTO));
            t.Wait();
            textBox1.Text = t.Result;
        }
    }
}
