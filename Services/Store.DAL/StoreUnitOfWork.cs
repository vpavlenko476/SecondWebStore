using Store.DAL.Context;
using Store.DAL.Contracts;
using System.Threading.Tasks;
using Store.Entities;
using System;
using Store.DAL.Repositories;

namespace Store.DAL
{
	public class StoreUnitOfWork: IDisposable
	{
		private readonly StoreContext _storeContext;
		private IBaseRepo<EmployeeEntity> _employeeRepo;
		private IBaseRepo<SectionEntity> _sectionRepo;
		private IBaseRepo<BrandEntity> _brandRepo;
		private IBaseRepo<ProdctEntity> _productRepo;
		private IBaseRepo<BlogEntity> _blogRepo;
		private IBaseRepo<OrderEntity> _orderRepo;
		public StoreUnitOfWork(StoreContext storeContext)
		{
			_storeContext = storeContext;			
		}
		public IBaseRepo<EmployeeEntity> EmployeeRepository 
		{
			get 
			{
				return _employeeRepo ?? new BaseRepo<EmployeeEntity>(_storeContext);
			}
		}
		public IBaseRepo<SectionEntity> SectionRepository
		{
			get
			{
				return _sectionRepo ?? new BaseRepo<SectionEntity>(_storeContext);
			}
		}
		public IBaseRepo<BrandEntity> BrandRepository
		{
			get
			{
				return _brandRepo ?? new BaseRepo<BrandEntity>(_storeContext);
			}
		}
		public IBaseRepo<ProdctEntity> ProductRepository
		{
			get
			{
				return _productRepo ?? new BaseRepo<ProdctEntity>(_storeContext);
			}
		}

		public IBaseRepo<BlogEntity> BlogRepository
		{
			get
			{
				return _blogRepo ?? new BaseRepo<BlogEntity>(_storeContext);
			}
		}

		public IBaseRepo<OrderEntity> OrderRepository
		{
			get
			{
				return _orderRepo ?? new BaseRepo<OrderEntity>(_storeContext);
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
