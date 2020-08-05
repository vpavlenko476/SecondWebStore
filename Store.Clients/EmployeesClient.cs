using Microsoft.Extensions.Configuration;
using Store.Domain;
using Store.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Store.Clients
{
	public class EmployeesClient : BaseClient, IEmployeeService
	{
		protected override string ServiceAddress { get; } = "api/employees";
		public EmployeesClient(IConfiguration configuration) : base(configuration)
		{

		}

		public IEnumerable<Employee> GetAll()
		{
			return Get<List<Employee>>(ServiceAddress);
		}

		public Task Edit(Employee employee)
		{
			return PutAsync(ServiceAddress, employee);
		}

		public Task Delete(int employeeId)
		{
			return DeleteAsync($"{ServiceAddress}/{employeeId}");
		}

		public async Task<int> Add(Employee employee)
		{
			var result = await PostAsync(ServiceAddress, employee);
			return (int)Enum.Parse(typeof(HttpStatusCode), result.StatusCode.ToString());
		}

		public Task<Employee> GetById(int id)
		{
			return GetAsync<Employee>($"{ServiceAddress}/{id}");
		}
	}
}
