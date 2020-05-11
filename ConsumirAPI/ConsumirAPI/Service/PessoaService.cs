using ConsumirAPI.DTO;
using ConsumirAPI.Interface;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirAPI.Service
{  
    public class PessoaService : IPessoaService
    {
        private readonly PessoaService _pessoaService; 
        private string appSettingsUrlApi;

        public PessoaService()
        {
            appSettingsUrlApi = ConfigurationSettings.AppSettings["UrlApi"];
        }

        public async Task<string> GetURI()
        {
            var response = string.Empty;
            var u = new Uri($"{appSettingsUrlApi}API/values/GetGenerico");

            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }
       
        public async Task<string> PostURI(PessoaDTO obj)
        {
            var response = string.Empty;

            Uri u = new Uri($"{appSettingsUrlApi}API/values");
            HttpContent c = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }
    }
}
