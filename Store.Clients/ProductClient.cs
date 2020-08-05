using Microsoft.Extensions.Configuration;
using Store.Domain;
using Store.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Store.Clients
{
	public class ProductClient : BaseClient, IProductService
	{
		protected override string ServiceAddress { get; } = "api/products";
		public ProductClient(IConfiguration configuration) : base(configuration)
		{

		}

		public IEnumerable<Product> GetProducts(ProductFilter filter = null)
		{
			var response = Post(ServiceAddress, filter);
			var result = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
			return result;
		}

		public Task<Product> GetProductByIdAsync(int id)
		{
			return GetAsync<Product>($"{ServiceAddress}/id");
		}
	}
}
