using AutoMapper;
using Store.DAL;
using Store.Domain;
using Store.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
	public class ProductService : IProductService
	{
		private readonly StoreUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ProductService(StoreUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			var productEntity = await _unitOfWork.ProductRepository.GetOne(id);
			var ptoduct = _mapper.Map<Product>(productEntity);
			ptoduct.Brand = _mapper.Map<Brand>(await _unitOfWork.BrandRepository.GetOne(productEntity.BrandId));			
			return ptoduct;
		}

		public IEnumerable<Product> GetProducts(ProductFilter filter)
		{
			var products = _unitOfWork.ProductRepository.GetAll();
			if (filter.Ids != null && filter.Ids.Any())
			{
				return _mapper.Map<List<Product>>(products.Where(p => filter.Ids.Contains(p.Id)));
			}
			else
			{
				if (filter.SectionId != null)
				{
					return _mapper.Map<List<Product>>(products.Where(p => p.SectionId == filter.SectionId));
				}
				if (filter.BrandId != null)
				{
					return _mapper.Map<List<Product>>(products.Where(p => p.BrandId == filter.BrandId));
				}
			}
			return _mapper.Map<List<Product>>(products);
		}
	}
}
