using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Store.Clients
{
	public abstract class BaseClient
	{
		/// <summary>
		/// Http клиент
		/// </summary>
		public HttpClient HttpClient { get; set; }

		/// <summary>
		/// Адрес сервиса
		/// </summary>
		protected abstract string ServiceAddress { get; set; }
		public BaseClient(IConfiguration configuration)
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(configuration["ClientAddress"])
			};
			HttpClient.DefaultRequestHeaders.Accept.Clear();
			HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
