using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Store.Clients
{
    public abstract class BaseClient
    {
        /// <summary>
        /// Http клиент
        /// </summary>
        public HttpClient HttpClient { get; private set; }

        /// <summary>
        /// Адрес сервиса
        /// </summary>
        protected abstract string ServiceAddress { get; }

        public BaseClient(IConfiguration configuration)
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration["ClientAddress"]),
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected T Get<T>(string url) where T : new()
        {
            return GetAsync<T>(url).Result;
        }

        protected async Task<T> GetAsync<T>(string url) where T : new()
        {
            var list = new T();
            var response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
                list = await response.Content.ReadAsAsync<T>();
            return list;
        }

        protected HttpResponseMessage Post<T>(string url, T value)
        {
            return PostAsync(url, value).Result;
        }

        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T value)
        {
            var response = await HttpClient.PostAsJsonAsync(url, value);
            return response;
        }

        protected HttpResponseMessage Put<T>(string url, T value)
        {
            return PutAsync(url, value).Result;
        }

        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T value)
        {
            var response = await HttpClient.PutAsJsonAsync(url, value);
            return response;
        }

        protected HttpResponseMessage Delete(string url)
        {
            return DeleteAsync(url).Result;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await HttpClient.DeleteAsync(url);
            ;
        }
    }
}