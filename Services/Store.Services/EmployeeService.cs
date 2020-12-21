using AutoMapper;
using Store.DAL;
using Store.DAL.Contracts;
using Store.Domain;
using Store.Entities;
using Store.Services.Abstract;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly StoreUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public EmployeeService(StoreUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task Delete(int employeeId)
		{
			var empToDelete = _unitOfWork.EmployeeRepository.GetAll().Single(e => e.Id == employeeId);
			await _unitOfWork.EmployeeRepository.Delete(empToDelete);
		}

		public async Task Edit(Employee employee)
		{
			await _unitOfWork.EmployeeRepository.Update(_mapper.Map<EmployeeEntity>(employee));
		}

		public async Task<Employee> GetById(int id)
		{
			return _mapper.Map<Employee>(await _unitOfWork.EmployeeRepository.GetOne(id));
		}
		
		public Task<int> Add(Employee employee)
		{
			return _unitOfWork.EmployeeRepository.Add(_mapper.Map<EmployeeEntity>(employee));
		}

		public IEnumerable<Employee> GetAll()
		{
			return _mapper.Map<IEnumerable<Employee>>(_unitOfWork.EmployeeRepository.GetAll().ToList());
		}				
	}
}
