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

		public IEnumerable<Product> GetProducts(int? sectionId = null, int? brandId = null)
		{
			var products = _unitOfWork.ProductRepository.GetAll();
			if(sectionId != null)
			{
				return _mapper.Map<List<Product>>(products.Where(p => p.SectionId == sectionId));				
			}
			if (brandId != null)
			{
				return _mapper.Map<List<Product>>(products.Where(p => p.BrandId == brandId));				
			}			
			return _mapper.Map<List<Product>>(products);
		}
	}
}
