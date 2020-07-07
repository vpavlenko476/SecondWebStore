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
		public StoreUnitOfWork(StoreContext storeContext)
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
		public IBaseRepo<SectionEntity> SectionRepository
		{
			get
			{
				if (_sectionRepo == null)
				{
					_sectionRepo = new BaseRepo<SectionEntity>(_storeContext);
				}
				return _sectionRepo;
			}
		}
		public IBaseRepo<BrandEntity> BrandRepository
		{
			get
			{
				if (_brandRepo == null)
				{
					_brandRepo = new BaseRepo<BrandEntity>(_storeContext);
				}
				return _brandRepo;
			}
		}
		public IBaseRepo<ProdctEntity> ProductRepository
		{
			get
			{
				if (_productRepo == null)
				{
					_productRepo = new BaseRepo<ProdctEntity>(_storeContext);
				}
				return _productRepo;
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
