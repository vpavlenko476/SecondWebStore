﻿using Store.DAL.Context;
using Store.DAL.Contracts;
using System.Threading.Tasks;
using Store.Entities;
using System;
using Store.DAL.Repositories;

namespace Store.DAL
{
	public class UnitOfWork: IDisposable
	{
		private readonly StoreContext _storeContext;
		private IBaseRepo<EmployeeEntity> _employeeRepo;
		public UnitOfWork(StoreContext storeContext)
		{
			_storeContext = storeContext;			
		}
		public IBaseRepo<EmployeeEntity> EmployeeRepository 
		{
			get 
			{
				if(_employeeRepo==null)
				{
					_employeeRepo = new BaseRepo<EmployeeEntity>(_storeContext);
				}
				return _employeeRepo;
			}
		}

		public async Task SaveAsync()
		{
			await _storeContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_storeContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}