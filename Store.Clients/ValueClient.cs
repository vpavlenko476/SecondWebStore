using Microsoft.Extensions.Configuration;
using Store.ServicesHosting.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.Clients
{
	public class ValueClient : BaseClient, IValueService
	{
		public ValueClient(IConfiguration configuration) : base(configuration)
		{
			ServiceAddress = "api/values";
		}
		protected override string ServiceAddress { get; }

		public async Task<HttpStatusCode> DeleteAsync(int id)
		{
			var response = await HttpClient.DeleteAsync($"{ServiceAddress}/delete/{id}");
			return response.StatusCode;
		}

		public async Task<IEnumerable<string>> GetAsync()
		{
			var list = new List<string>();
			var response = HttpClient.GetAsync($"{ServiceAddress}").Result;
			if (response.IsSuccessStatusCode)
			{
				list = await response.Content.ReadAsAsync<List<string>>();
			}
			return list;
		}

		public async Task<string> GetAsync(int id)
		{
			var result = string.Empty;
			var response = HttpClient.GetAsync($"{ServiceAddress}/get/{id}").Result;
			if (response.IsSuccessStatusCode)
			{
				result = await response.Content.ReadAsAsync<string>();
			}
			return result;
		}
		
		public async Task<Uri> PostAsync(string value)
		{
			var response = HttpClient.PostAsJsonAsync(ServiceAddress, value).Result;
			return response.EnsureSuccessStatusCode().Headers.Location;
		}
		
		public async Task<HttpStatusCode> PutAsync(int id, string value)
		{
			var response = HttpClient.PutAsJsonAsync($"{ServiceAddress}/{id}", value).Result;
			return response.EnsureSuccessStatusCode().StatusCode;
		}
	}
}
