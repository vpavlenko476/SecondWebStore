using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Store.ServicesHosting.Abstract
{
	public interface IValueService
	{
		/// <summary>
		/// Get all values async
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<string>> GetAsync();

		/// <summary>
		/// Get value by id async
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> GetAsync(int id);

		/// <summary>
		/// Add new value async
		/// </summary>
		/// <param name="value">value</param>
		/// <returns>Location</returns>
		Task<Uri> PostAsync(string value);

		/// <summary>
		/// Update value async
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		Task<HttpStatusCode> PutAsync(int id, string value);

		/// <summary>
		/// Delete value async
		/// </summary>
		/// <param name="id">id</param>
		/// <returns></returns>
		Task<HttpStatusCode> DeleteAsync(int id);
	}
}
