using AutoMapper;
using Store.DAL.Contracts;
using Store.Domain;
using Store.Entities;
using Store.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IBaseRepo<EmployeeEntity> _employeeRepo;
		private readonly IMapper _mapper;
		public EmployeeService(IBaseRepo<EmployeeEntity> employeeRepo, IMapper mapper)
		{
			_employeeRepo = employeeRepo;
			_mapper = mapper;
		}

		public async Task Delete(int employeeId)
		{
			await _employeeRepo.Delete(_employeeRepo.GetAll().Where(e => e.Id == employeeId).Single());
		}

		public async Task Edit(Employee employee)
		{
			await _employeeRepo.Update(_mapper.Map<EmployeeEntity>(employee));
		}

		public async Task<Employee> GetById(int id)
		{
			return _mapper.Map<Employee>(await _employeeRepo.GetOne(id));
		}
		
		public Task<int> Add(Employee employee)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Employee> GetAll()
		{
			return _employeeRepo.GetAll().Select(e => _mapper.Map<Employee>(e)).AsEnumerable<Employee>();
		}
	}
}
