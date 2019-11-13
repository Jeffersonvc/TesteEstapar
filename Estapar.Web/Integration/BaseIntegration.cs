using System;
using System.Configuration;
using System.Net.Http;

namespace Estapar.Web.Integration
{
    public class BaseIntegration
    {
        protected string _baseURL;
        protected HttpClient httpClient;
        public BaseIntegration()
        {
            _baseURL = ConfigurationManager.AppSettings["estapar.url.api"].ToString();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseURL);
        }
        public string Post<T>(T data, string address)
        {
            HttpResponseMessage message = httpClient.PostAsJsonAsync<T>(address, data).Result;
            if (message.IsSuccessStatusCode)
                return message.Content.ReadAsStringAsync().Result;
            return null;
        }

        public string Put<T>(T data, string address)
        {
            HttpResponseMessage message = httpClient.PutAsJsonAsync<T>(address, data).Result;
            if (message.IsSuccessStatusCode)
                return message.Content.ReadAsStringAsync().Result;
            return null;
        }

        public string Get(string address)
        {
            return httpClient.GetStringAsync(address).Result;
        }
    }
}